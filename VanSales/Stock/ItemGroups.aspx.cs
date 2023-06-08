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
    public partial class ItemGroups : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "7";
            IndexStored = "st_group_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gvgroup.DataBind();
        }
        protected void gvgroup_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            try
            {
                List<object> KeyValues = gvgroup.GetSelectedFieldValues("groupid");
                if (KeyValues.Count == 0)
                {
                    gvgroup.JSProperties["cperrors"] = "برجاء إختيار مجموعة لحذفها";
                    gvgroup.JSProperties["cpicon"] = "error";
                    return;
                }
                StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
                var res = new StoredExecuteResulte();
                foreach (object key in KeyValues)
                {
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("groupid", key);

                    res = SqlCommandHelper.ExecuteNonQuery("st_group_del", dict, true);
                    if (res.errorid == 0)
                    {
                        gvgroup.JSProperties["cperrors"] = "تم الحذف بنجاح";
                        gvgroup.JSProperties["cpicon"] = "success";
                    }
                    else
                    {
                        break;
                    }
                }
                if (res.errorid != 0)
                {
                    gvgroup.JSProperties["cperrors"] = res.errormsg;
                    gvgroup.JSProperties["cpicon"] = "error";

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("index-The index is out of range.") || ex.Message.Contains("الفهرس خارج النطاق. يجب ألا يكون قيمته سالبة ويجب ألا يكون أقل من حجم المجموعة."))
                {
                    gvgroup.JSProperties["cperrors"] = "برجاء إختيار مجموعة لحذفها";
                    gvgroup.JSProperties["cpicon"] = "error";
                }
                else
                {
                    gvgroup.JSProperties["cperrors"] = ex.Message;
                    gvgroup.JSProperties["cpicon"] = "error";
                }
            }
            gvgroup.DataBind();
        }

        protected void ASPxbtnxlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvgroupExporter, "مجموعات الأصناف", 1, Request.GetOwinContext().Request.User.Identity.Name, gvgroup.GetSelectedFieldValues("groupid").Count != 0, false, "مجموعات الأصناف");
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
                ExportingDevExpressUtil.Export(gvgroupExporter, "مجموعات الأصناف", 0, Request.GetOwinContext().Request.User.Identity.Name, gvgroup.GetSelectedFieldValues("groupid").Count != 0, false, "مجموعات الأصناف");
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
                ExportingDevExpressUtil.Export(gvgroupExporter, "مجموعات الأصناف", 2, Request.GetOwinContext().Request.User.Identity.Name, gvgroup.GetSelectedFieldValues("groupid").Count != 0, false, "مجموعات الأصناف");
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
                ExportingDevExpressUtil.Export(gvgroupExporter, "مجموعات الأصناف", 2, Request.GetOwinContext().Request.User.Identity.Name, gvgroup.GetSelectedFieldValues("groupid").Count != 0, true, "مجموعات الأصناف");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void gvgroup_DataBinding(object sender, EventArgs e)
        {
            gvgroup.DataSource = IndexDataTable;
        }

        protected void gvgroup_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("st_group_ins", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvgroup.CancelEdit();
            }
        }

        protected void gvgroup_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            var g = SqlCommandHelper.ExecuteNonQuery("st_group_upd", e.NewValues, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvgroup.CancelEdit();
            }
        }
    }
}