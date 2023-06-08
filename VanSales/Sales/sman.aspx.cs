using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using Emax.Core.Utility;
using Emax.Dal;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.sman
{
    public partial class sman : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "6";
            IndexStored = "s_sman_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gvsman.DataBind();
        }

        protected void gvsman_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            //try
            //{
            List<object> KeyValues = gvsman.GetSelectedFieldValues("smanid");
            if (KeyValues.Count == 0)
            {
                gvsman.JSProperties["cperrors"] = "برجاء إختيار مندوب لحذفه";
                gvsman.JSProperties["cpicon"] = "error";
                return;
            }
            StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
            var res = new StoredExecuteResulte();
            foreach (object key in KeyValues)
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("smanid", key);

                res = SqlCommandHelper.ExecuteNonQuery("s_sman_del", dict, true);
                if (res.errorid == 0)
                {
                    gvsman.JSProperties["cperrors"] = "تم الحذف بنجاح";
                    gvsman.JSProperties["cpicon"] = "success";
                }
                else
                {
                    break;
                }
            }
            if (res.errorid != 0)
            {
                gvsman.JSProperties["cperrors"] = res.errormsg;
                gvsman.JSProperties["cpicon"] = "error";

            }
            gvsman.DataBind();
            //    List<object> KeyValues = gvsman.GetSelectedFieldValues("smanid");
            //    StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
            //    foreach (object key in KeyValues)
            //    {
            //        SqlDataSource1.DeleteParameters["smanid"] = new Parameter("smanid", TypeCode.Int32, key.ToString());
            //        SqlDataSource1.Delete();
            //    }
            //    gvsman.DataBind();
            //    gvsman.JSProperties["cperrors"] = "تم الحذف بنجاح";
            //    gvsman.JSProperties["cpicon"] = "success";
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
            //    {
            //        gvsman.JSProperties["cperrors"] = "لا يمكن حذف مجمموعة بها أصناف";
            //        gvsman.JSProperties["cpicon"] = "error";
            //    }
            //    else
            //    {
            //        gvsman.JSProperties["cperrors"] = ex.Message;
            //        gvsman.JSProperties["cpicon"] = "error";
            //    }
            //}
        }

        protected void ASPxbtnxlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvsmanExporter, "المندوبين", 1, Request.GetOwinContext().Request.User.Identity.Name, gvsman.GetSelectedFieldValues("smanid").Count != 0, false, "المندوبين");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void ASPxbtndocexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvsmanExporter, "المندوبين", 0, Request.GetOwinContext().Request.User.Identity.Name, gvsman.GetSelectedFieldValues("smanid").Count != 0, false, "المندوبين");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void ASPxbtnpdfexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvsmanExporter, "المندوبين", 2, Request.GetOwinContext().Request.User.Identity.Name, gvsman.GetSelectedFieldValues("smanid").Count != 0, false, "المندوبين");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void ASPxbtnprintexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvsmanExporter, "المندوبين", 2, Request.GetOwinContext().Request.User.Identity.Name, gvsman.GetSelectedFieldValues("smanid").Count != 0, true, "المندوبين");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void gvsman_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("s_sman_ins", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvsman.CancelEdit();
            }
        }

        protected void gvsman_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("s_sman_upd", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvsman.CancelEdit();
            }
        }

        protected void gvsman_DataBinding(object sender, EventArgs e)
        {
            gvsman.DataSource = IndexDataTable;
        }
    }
}