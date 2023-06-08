using Emax.Core.Utility;
using Emax.Dal;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace VanSales.Group
{
    public partial class SuppGroup : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "24";
            IndexStored = "p_suppgroup_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gvsuppgroup.DataBind();
        }
        protected void gvsuppgroup_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            try 
            { 
            List<object> KeyValues = gvsuppgroup.GetSelectedFieldValues("pgrpid");
                if (KeyValues.Count == 0)
                {
                    gvsuppgroup.JSProperties["cperrors"] = "برجاء تحديد مجموعة لحذفها";
                    gvsuppgroup.JSProperties["cpicon"] = "info";
                    return;
                }
            StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
            var res = new StoredExecuteResulte();
            foreach (object key in KeyValues)
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("pgrpid", key);

                res = SqlCommandHelper.ExecuteNonQuery("p_suppgroup_del", dict, true);
                if (res.errorid == 0)
                {
                    gvsuppgroup.JSProperties["cperrors"] = "تم الحذف بنجاح";
                    gvsuppgroup.JSProperties["cpicon"] = "success";
                }
                else
                {
                    break;
                }
            }
            if (res.errorid != 0)
            {
                gvsuppgroup.JSProperties["cperrors"] = res.errormsg;
                gvsuppgroup.JSProperties["cpicon"] = "error";

            }
            gvsuppgroup.DataBind();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    gvsuppgroup.JSProperties["cperrors"] = "لا يمكن حذف مجمموعة بها عملاء";
                    gvsuppgroup.JSProperties["cpicon"] = "error";
                }
                else if (ex.Message.Contains("الفهرس خارج النطاق. يجب ألا يكون قيمته سالبة ويجب ألا يكون أقل من حجم المجموعة"))
                {
                    gvsuppgroup.JSProperties["cperrors"] = "برجاء تحديد مجموعة لحذفها";
                    gvsuppgroup.JSProperties["cpicon"] = "info";
                }
                else
                {
                    gvsuppgroup.JSProperties["cperrors"] = ex.Message;
                    gvsuppgroup.JSProperties["cpicon"] = "error";
                }
            }
        }


        protected void ASPxbtnxlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvsuppgroupExporter, "مجموعات الموردين", 1, Request.GetOwinContext().Request.User.Identity.Name, gvsuppgroup.GetSelectedFieldValues("pgrpid").Count != 0, false, "مجموعات الموردين");
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
                ExportingDevExpressUtil.Export(gvsuppgroupExporter, "مجموعات الموردين", 0, Request.GetOwinContext().Request.User.Identity.Name, gvsuppgroup.GetSelectedFieldValues("pgrpid").Count != 0, false, "مجموعات الموردين");
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
                ExportingDevExpressUtil.Export(gvsuppgroupExporter, "مجموعات الموردين", 2, Request.GetOwinContext().Request.User.Identity.Name, gvsuppgroup.GetSelectedFieldValues("pgrpid").Count != 0, false, "مجموعات الموردين");
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
                ExportingDevExpressUtil.Export(gvsuppgroupExporter, "مجموعات الموردين", 2, Request.GetOwinContext().Request.User.Identity.Name, gvsuppgroup.GetSelectedFieldValues("pgrpid").Count != 0, true, "مجموعات الموردين");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void gvsuppgroup_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("p_suppgroup_ins", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvsuppgroup.CancelEdit();
            }
        }

        protected void gvsuppgroup_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("p_suppgroup_upd", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvsuppgroup.CancelEdit();
            }
        }

        protected void gvsuppgroup_DataBinding(object sender, EventArgs e)
        {
            gvsuppgroup.DataSource = IndexDataTable;
        }
    }
}