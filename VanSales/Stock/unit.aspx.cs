using DevExpress.Export;
using DevExpress.XtraPrinting;
using Emax.Core.Utility;
using Emax.Dal;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.unit
{
    public partial class unit : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "8";
            IndexStored = "st_unit_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gvunit.DataBind();
        }
        protected void gvunit_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            try
            {
                List<object> KeyValues = gvunit.GetSelectedFieldValues("unitid");
                if (KeyValues.Count == 0)
                {
                    gvunit.JSProperties["cperrors"] = "برجاء إختيار وحدة لحذفها";
                    gvunit.JSProperties["cpicon"] = "error";
                    return;
                }
                StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
                var res = new StoredExecuteResulte();
                foreach (object key in KeyValues)
                {
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("unitid", key);

                    res = SqlCommandHelper.ExecuteNonQuery("st_unit_del", dict, true);
                    if (res.errorid == 0)
                    {
                        gvunit.JSProperties["cperrors"] = "تم الحذف بنجاح";
                        gvunit.JSProperties["cpicon"] = "success";
                    }
                    else
                    {
                        break;
                    }
                }
                if (res.errorid != 0)
                {
                    gvunit.JSProperties["cperrors"] = res.errormsg;
                    gvunit.JSProperties["cpicon"] = "error";

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("index is out of range.") || ex.Message.Contains("الفهرس خارج النطاق. يجب ألا يكون قيمته سالبة ويجب ألا يكون أقل من حجم المجموعة."))
                {
                    gvunit.JSProperties["cperrors"] = "برجاء إختيار وحدة لحذفها";
                    gvunit.JSProperties["cpicon"] = "error";
                }
                else
                {
                    gvunit.JSProperties["cperrors"] = ex.Message;
                    gvunit.JSProperties["cpicon"] = "error";
                }
            }
            gvunit.DataBind();
        }

        protected void ASPxbtnxlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvunitExporter, "الوحدات", 1, Request.GetOwinContext().Request.User.Identity.Name, gvunit.GetSelectedFieldValues("unitid").Count != 0, false, "الوحدات");
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
                ExportingDevExpressUtil.Export(gvunitExporter, "الوحدات", 0, Request.GetOwinContext().Request.User.Identity.Name, gvunit.GetSelectedFieldValues("unitid").Count != 0, false, "الوحدات");
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
                ExportingDevExpressUtil.Export(gvunitExporter, "الوحدات", 2, Request.GetOwinContext().Request.User.Identity.Name, gvunit.GetSelectedFieldValues("unitid").Count != 0, false, "الوحدات");
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
                ExportingDevExpressUtil.Export(gvunitExporter, "الوحدات", 2, Request.GetOwinContext().Request.User.Identity.Name, gvunit.GetSelectedFieldValues("unitid").Count != 0, true, "الوحدات");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected  void gvunit_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("st_unit_ins", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvunit.CancelEdit();
            }
        }

        protected void gvunit_DataBinding(object sender, EventArgs e)
        {
            gvunit.DataSource = IndexDataTable;
        }

        protected void gvunit_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("st_unit_upd", e.NewValues, true,e.Keys);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvunit.CancelEdit();
            }
        }
    }
}