using Emax.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.HR
{
    public partial class hr_monthyear : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "46";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gvhr_monthyear.DataBind();
        }

        protected void gvhr_monthyear_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("hr_monthyear_ins", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvhr_monthyear.CancelEdit();
            }
        }

        protected void gvhr_monthyear_DataBinding(object sender, EventArgs e)
        {
            gvhr_monthyear.DataSource = SqlCommandHelper.ExcecuteToDataTable("hr_monthyear_sel").dataTable;
        }

        protected void gvhr_monthyear_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("monyrid", Convert.ToInt32(e.Keys[0]));
            var g = SqlCommandHelper.ExecuteNonQuery("hr_monthyear_del", dict, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvhr_monthyear.CancelEdit();
            }
        }

        protected void gvhr_monthyear_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("hr_monthyear_upd", e.NewValues, true, e.Keys);
            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvhr_monthyear.CancelEdit();
            }
        }

        protected void gvhr_monthyear_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["monthsal"] = DateTime.Now.Month;
            e.NewValues["yearsal"] = DateTime.Now.Year;
        }
    }
}