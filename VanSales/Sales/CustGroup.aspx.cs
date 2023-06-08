using DevExpress.Export;
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

namespace VanSales.Group
{
    public partial class CustGroup : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "14";
            IndexStored = "s_custgroup_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gvcustgroup.DataBind();
        }
        protected void gvcustgroup_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            try
            {
                List<object> KeyValues = gvcustgroup.GetSelectedFieldValues("sgrpid");
                
                if (KeyValues.Count == 0)
                {
                    gvcustgroup.JSProperties["cperrors"] = "برجاء إختيار عميل لحذفة";
                    gvcustgroup.JSProperties["cpicon"] = "error";
                    return;
                }
                StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
                var res = new StoredExecuteResulte();
                foreach (object key in KeyValues)
                {
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("sgrpid", key);

                    res = SqlCommandHelper.ExecuteNonQuery("s_custgroup_del", dict, true);
                    if (res.errorid == 0)
                    {
                        gvcustgroup.JSProperties["cperrors"] = "تم الحذف بنجاح";
                        gvcustgroup.JSProperties["cpicon"] = "success";
                    }
                    else
                    {
                        break;
                    }
                }
                if (res.errorid != 0)
                {
                    gvcustgroup.JSProperties["cperrors"] = res.errormsg;
                    gvcustgroup.JSProperties["cpicon"] = "error";
                }
                gvcustgroup.DataBind();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint"))
                {
                    gvcustgroup.JSProperties["cperrors"] = "لا يمكن حذف مجمموعة بها عملاء";
                    gvcustgroup.JSProperties["cpicon"] = "error";
                }
                else if (ex.Message.Contains("الفهرس خارج النطاق. يجب ألا يكون قيمته سالبة ويجب ألا يكون أقل من حجم المجموعة"))
                {
                    gvcustgroup.JSProperties["cperrors"] = "برجاء تحديد مجموعة لحذفها";
                    gvcustgroup.JSProperties["cpicon"] = "info";
                }
                else
                {
                    gvcustgroup.JSProperties["cperrors"] = ex.Message;
                    gvcustgroup.JSProperties["cpicon"] = "error";
                }
            }
        }

        protected void ASPxbtnxlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvcustgroupExporter, "مجموعات العملاء", 1, Request.GetOwinContext().Request.User.Identity.Name, gvcustgroup.GetSelectedFieldValues("sgrpid").Count != 0, false, "مجموعات العملاء");
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
                ExportingDevExpressUtil.Export(gvcustgroupExporter, "مجموعات العملاء", 0, Request.GetOwinContext().Request.User.Identity.Name, gvcustgroup.GetSelectedFieldValues("sgrpid").Count != 0, false, "مجموعات العملاء");
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
                ExportingDevExpressUtil.Export(gvcustgroupExporter, "مجموعات العملاء", 2, Request.GetOwinContext().Request.User.Identity.Name, gvcustgroup.GetSelectedFieldValues("sgrpid").Count != 0, false, "مجموعات العملاء");
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
                ExportingDevExpressUtil.Export(gvcustgroupExporter, "مجموعات العملاء", 2, Request.GetOwinContext().Request.User.Identity.Name, gvcustgroup.GetSelectedFieldValues("sgrpid").Count != 0, true, "مجموعات العملاء");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void gvcustgroup_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("s_custgroup_ins", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvcustgroup.CancelEdit();
            }
        }

        protected void gvcustgroup_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("s_custgroup_upd", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvcustgroup.CancelEdit();
            }
        }

        protected void gvcustgroup_DataBinding(object sender, EventArgs e)
        {
            gvcustgroup.DataSource = IndexDataTable;
        }
    }
}