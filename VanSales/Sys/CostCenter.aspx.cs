using Emax.Core.Utility;
using Emax.Dal;
using Emax.SharedLib;
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
    public partial class CostCenter : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "12";
            IndexStored = "sys_costcenter_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gvcostcenter.DataBind();
        }

        protected void gvcostcenter_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            try
            {
                List<object> KeyValues = gvcostcenter.GetSelectedFieldValues("ccid");
                if (KeyValues.Count == 0)
                {
                    gvcostcenter.JSProperties["cperrors"] = "برجاء إختيار مركز تكلفة لحذفة";
                    gvcostcenter.JSProperties["cpicon"] = "error";
                    return;
                }
                StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
                var res = new StoredExecuteResulte();
                foreach (object key in KeyValues)
                {
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("ccid", key);

                    res = SqlCommandHelper.ExecuteNonQuery("sys_costcenter_del", dict, true);
                    if (res.errorid == 0)
                    {
                        gvcostcenter.JSProperties["cperrors"] = "تم الحذف بنجاح";
                        gvcostcenter.JSProperties["cpicon"] = "success";
                    }
                    else
                    {
                        break;
                    }
                }
                if (res.errorid != 0)
                {
                    gvcostcenter.JSProperties["cperrors"] = res.errormsg;
                    gvcostcenter.JSProperties["cpicon"] = "error";

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("index is out of range.") || ex.Message.Contains("الفهرس خارج النطاق. يجب ألا يكون قيمته سالبة ويجب ألا يكون أقل من حجم المجموعة."))
                {
                    gvcostcenter.JSProperties["cperrors"] = "برجاء إختيار مركز تكلفة لحذفة";
                    gvcostcenter.JSProperties["cpicon"] = "error";
                }
                else
                {
                    gvcostcenter.JSProperties["cperrors"] = ex.Message;
                    gvcostcenter.JSProperties["cpicon"] = "error";
                }
            }
            gvcostcenter.DataBind();
        }

        protected void ASPxbtnxlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvcostcenterExporter, "مراكز التكلفة", 1, Request.GetOwinContext().Request.User.Identity.Name, gvcostcenter.GetSelectedFieldValues("branchid").Count != 0, false, "مراكز التكلفه");
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
                ExportingDevExpressUtil.Export(gvcostcenterExporter, "مراكز التكلفة", 0, Request.GetOwinContext().Request.User.Identity.Name, gvcostcenter.GetSelectedFieldValues("branchid").Count != 0, false, "مراكز التكلفه");
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
                ExportingDevExpressUtil.Export(gvcostcenterExporter, "مراكز التكلفة", 2, Request.GetOwinContext().Request.User.Identity.Name, gvcostcenter.GetSelectedFieldValues("branchid").Count != 0, false, "مراكز التكلفه");
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
                ExportingDevExpressUtil.Export(gvcostcenterExporter, "مراكز التكلفة", 2, Request.GetOwinContext().Request.User.Identity.Name, gvcostcenter.GetSelectedFieldValues("branchid").Count != 0, true, "مراكز التكلفه");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void gvcostcenter_DataBinding(object sender, EventArgs e)
        {
            gvcostcenter.DataSource = IndexDataTable;
        }

        protected void gvcostcenter_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("sys_costcenter_ins", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvcostcenter.CancelEdit();
            }
        }

        protected void gvcostcenter_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("sys_costcenter_upd", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvcostcenter.CancelEdit();
            }
        }

        protected void gvcostcenter_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
      
        }
    }
}