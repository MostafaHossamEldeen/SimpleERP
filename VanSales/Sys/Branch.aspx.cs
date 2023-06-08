using Emax.Core.Utility;
using Emax.Dal;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace VanSales.Branch
{
    public partial class Branch : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "10";
            IndexStored = "sys_branch_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gvbranch.DataBind();
        }

        protected void gvbranch_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            try
            {
                List<object> KeyValues = gvbranch.GetSelectedFieldValues("branchid");
                if (KeyValues.Count == 0)
                {
                    gvbranch.JSProperties["cperrors"] = "برجاء إختيار فرع لحذفة";
                    gvbranch.JSProperties["cpicon"] = "error";
                    return;
                }
                StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
                var res = new StoredExecuteResulte();
                foreach (object key in KeyValues)
                {
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("branchid", key);

                    res = SqlCommandHelper.ExecuteNonQuery("sys_branch_del", dict, true);
                    if (res.errorid == 0)
                    {
                        gvbranch.JSProperties["cperrors"] = "تم الحذف بنجاح";
                        gvbranch.JSProperties["cpicon"] = "success";
                    }
                    else
                    {
                        break;
                    }
                }
                if (res.errorid != 0)
                {
                    gvbranch.JSProperties["cperrors"] = res.errormsg;
                    gvbranch.JSProperties["cpicon"] = "error";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("index is out of range") || ex.Message.Contains("الفهرس خارج النطاق. يجب ألا يكون قيمته سالبة ويجب ألا يكون أقل من حجم المجموعة."))
                {
                    gvbranch.JSProperties["cperrors"] = "برجاء إختيار فرع لحذفة";
                    gvbranch.JSProperties["cpicon"] = "error";
                }
                else
                {
                    gvbranch.JSProperties["cperrors"] = ex.Message;
                    gvbranch.JSProperties["cpicon"] = "error";
                }
            }

            gvbranch.DataBind();
        }

        protected void ASPxbtnxlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvbranchExporter, "الفروع", 1, Request.GetOwinContext().Request.User.Identity.Name, gvbranch.GetSelectedFieldValues("branchid").Count != 0, false, "الفروع");
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
                ExportingDevExpressUtil.Export(gvbranchExporter, "الفروع", 0, Request.GetOwinContext().Request.User.Identity.Name, gvbranch.GetSelectedFieldValues("branchid").Count != 0, false, "الفروع");
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
                ExportingDevExpressUtil.Export(gvbranchExporter, "الفروع", 2, Request.GetOwinContext().Request.User.Identity.Name, gvbranch.GetSelectedFieldValues("branchid").Count != 0, false, "الفروع");
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
                ExportingDevExpressUtil.Export(gvbranchExporter, "الفروع", 2, Request.GetOwinContext().Request.User.Identity.Name, gvbranch.GetSelectedFieldValues("branchid").Count != 0, true,"الفروع");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void gvbranch_DataBinding(object sender, EventArgs e)
        {
            gvbranch.DataSource = IndexDataTable;
        }

        protected void gvbranch_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("sys_branch_ins", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvbranch.CancelEdit();
            }
        }

        protected void gvbranch_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("sys_branch_upd", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvbranch.CancelEdit();
            }
        }
    }
}