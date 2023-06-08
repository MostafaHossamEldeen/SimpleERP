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

namespace VanSales.Sys
{
    public partial class Years : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "13";
            IndexStored = "sys_years_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gvyears.DataBind();
        }
        protected void gvyears_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            List<object> KeyValues = gvyears.GetSelectedFieldValues("yearid");
            if (KeyValues.Count == 0)
            {
                gvyears.JSProperties["cperrors"] = "برجاء إختيار السنه الماليه المراد حذفها";
                gvyears.JSProperties["cpicon"] = "error";
                return;
            }
            StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
            var res = new StoredExecuteResulte();
            foreach (object key in KeyValues)
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("yearid", key);

                res = SqlCommandHelper.ExecuteNonQuery("sys_years_del", dict, true);
                if (res.errorid == 0)
                {
                    gvyears.JSProperties["cperrors"] = "تم الحذف بنجاح";
                    gvyears.JSProperties["cpicon"] = "success";
                }
                else
                {
                    break;
                }
            }
            if (res.errorid != 0)
            {
                gvyears.JSProperties["cperrors"] = res.errormsg;
                gvyears.JSProperties["cpicon"] = "error";

            }
            gvyears.DataBind();
            //try
            //{
            //    List<object> KeyValues = gvyears.GetSelectedFieldValues("branchid");
            //    StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
            //    foreach (object key in KeyValues)
            //    {
            //        SqlDataSource1.DeleteParameters["yearid"] = new Parameter("yearid", TypeCode.Int32, key.ToString());
            //        SqlDataSource1.Delete();
            //    }
            //    gvyears.DataBind();
            //    gvyears.JSProperties["cperrors"] = "تم الحذف بنجاح";
            //    gvyears.JSProperties["cpicon"] = "success";
            //}
            //catch (Exception ex)
            //{
            //    if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
            //    {
            //        gvyears.JSProperties["cperrors"] = "لا يمكن حذف مجمموعة بها أصناف";
            //        gvyears.JSProperties["cpicon"] = "error";
            //    }
            //    else
            //    {
            //        gvyears.JSProperties["cperrors"] = ex.Message;
            //        gvyears.JSProperties["cpicon"] = "error";
            //    }
            //}
        }

        protected void ASPxbtnxlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvyearsExporter, "السنوات المالية", 1, Request.GetOwinContext().Request.User.Identity.Name, gvyears.GetSelectedFieldValues("yearid").Count != 0, false, "السنوات المالية");
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
                ExportingDevExpressUtil.Export(gvyearsExporter, "السنوات المالية", 0, Request.GetOwinContext().Request.User.Identity.Name, gvyears.GetSelectedFieldValues("yearid").Count != 0, false, "السنوات المالية");
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
                ExportingDevExpressUtil.Export(gvyearsExporter, "السنوات المالية", 2, Request.GetOwinContext().Request.User.Identity.Name, gvyears.GetSelectedFieldValues("yearid").Count != 0, false, "السنوات المالية");
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
                ExportingDevExpressUtil.Export(gvyearsExporter, "السنوات المالية", 2, Request.GetOwinContext().Request.User.Identity.Name, gvyears.GetSelectedFieldValues("yearid").Count != 0, true, "السنوات المالية");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void gvyears_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("sys_years_ins", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvyears.CancelEdit();
            }
        }

        protected void gvyears_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("sys_years_upd", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvyears.CancelEdit();
            }
        }

        protected void gvyears_DataBinding(object sender, EventArgs e)
        {
            gvyears.DataSource = IndexDataTable;
        }
    }
}