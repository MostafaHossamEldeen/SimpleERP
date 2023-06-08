using Emax.Core.Utility;
using Emax.Dal;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.payment
{
    public partial class payment_type : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "9";
            IndexStored = "sys_paytype_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gvpaytype.DataBind();
        }
        protected void gvpaytype_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            try
            {
                List<object> KeyValues = gvpaytype.GetSelectedFieldValues("paytypeid");
                if (KeyValues.Count == 0)
                {
                    gvpaytype.JSProperties["cperrors"] = "برجاء إختيار مركز تكلفة لحذفة";
                    gvpaytype.JSProperties["cpicon"] = "error";
                    return;
                }
                StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
                var res = new StoredExecuteResulte();
                foreach (object key in KeyValues)
                {
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("paytypeid", key);

                    res = SqlCommandHelper.ExecuteNonQuery("sys_paytype_del", dict, true);
                    if (res.errorid == 0)
                    {
                        gvpaytype.JSProperties["cperrors"] = "تم الحذف بنجاح";
                        gvpaytype.JSProperties["cpicon"] = "success";
                    }
                    else
                    {
                        break;
                    }
                }
                if (res.errorid != 0)
                {
                    gvpaytype.JSProperties["cperrors"] = res.errormsg;
                    gvpaytype.JSProperties["cpicon"] = "error";

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("index is out of range.") || ex.Message.Contains("الفهرس خارج النطاق. يجب ألا يكون قيمته سالبة ويجب ألا يكون أقل من حجم المجموعة."))
                {
                    gvpaytype.JSProperties["cperrors"] = "برجاء إختيار مركز تكلفة لحذفة";
                    gvpaytype.JSProperties["cpicon"] = "error";
                }
                else
                {
                    gvpaytype.JSProperties["cperrors"] = ex.Message;
                    gvpaytype.JSProperties["cpicon"] = "error";
                }
            }
            gvpaytype.DataBind();
        }

        protected void ASPxbtnxlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvpaytypeExporter, "طرق الدفع", 1, Request.GetOwinContext().Request.User.Identity.Name, gvpaytype.GetSelectedFieldValues("paytypeid").Count != 0, false, "طرق الدفع");
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
                ExportingDevExpressUtil.Export(gvpaytypeExporter, "طرق الدفع", 0, Request.GetOwinContext().Request.User.Identity.Name, gvpaytype.GetSelectedFieldValues("paytypeid").Count != 0, false, "طرق الدفع");
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
                ExportingDevExpressUtil.Export(gvpaytypeExporter, "طرق الدفع", 2, Request.GetOwinContext().Request.User.Identity.Name, gvpaytype.GetSelectedFieldValues("paytypeid").Count != 0, false, "طرق الدفع");
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
                ExportingDevExpressUtil.Export(gvpaytypeExporter, "طرق الدفع", 2, Request.GetOwinContext().Request.User.Identity.Name, gvpaytype.GetSelectedFieldValues("paytypeid").Count != 0, true, "طرق الدفع");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void gvpaytype_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["feeds"] = 0;
        }

        protected void SqlDataSource1_Deleted(object sender, SqlDataSourceStatusEventArgs e)
        {
            Session["errorid"] = e.Command.Parameters["@errorid"].Value.ToString();
        }

        protected void gvpaytype_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("sys_paytype_ins", e.NewValues, true);

            if (g.errorid != 0)
            {
                if (g.errormsg.Contains("Cannot insert duplicate key row in object"))
                {
                    g.errormsg = "لا يمكن إضافة طريقة دفع بإسم مسجل من قبل";
                    throw new Exception(g.errormsg);
                }
            }
            else
            {
                e.Cancel = true;
                gvpaytype.CancelEdit();
            }
        }

        protected void gvpaytype_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("sys_paytype_upd", e.NewValues, true);

            if (g.errorid != 0)
            {
                if (g.errormsg.Contains("Cannot insert duplicate key row in object 'dbo.sys_paytype' with unique index 'IX_sys_paytype"))
                {
                    g.errormsg = "لا يمكن إضافة طريقة دفع بإسم مسجل من قبل";
                    throw new Exception(g.errormsg);
                }
            }
            else
            {
                e.Cancel = true;
                gvpaytype.CancelEdit();
            }
        }

        protected void gvpaytype_DataBinding(object sender, EventArgs e)
        {
            gvpaytype.DataSource = IndexDataTable;
        }
    }
}