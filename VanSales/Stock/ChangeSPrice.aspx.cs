using Emax.Core.Utility;
using Emax.Dal;
using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;

namespace VanSales.Stock
{
    public partial class ChangeSPrice : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "20";
            IndexStored = "st_itemschaneprice_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("st_group_sel", cmb_groupid, "groupid", "groupname");
                cmb_groupid.SelectedIndex = -1;
            }
            gvchangeprice.DataBind();
        }
        DataTable GvdetailSource()
        {
            return SqlCommandHelper.ExcecuteToDataTable("st_itemschaneprice_sel").dataTable;
        }
        protected void gvchangeprice_DataBinding(object sender, EventArgs e)
        {
            gvchangeprice.DataSource = GvdetailSource();
        }

        protected void gvchangeprice_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            try
            {
                var updated = e.UpdateValues;
                foreach (var item in updated)
                {
                    var g = SqlCommandHelper.ExecuteNonQuery("st_itemschaneprice_upd", item.NewValues, true, item.Keys);

                    if (g.errorid != 0)
                    {
                        ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception(" + g.errormsg + ")", true);
                    }
                    else
                    {
                        e.Handled = true;
                        gvchangeprice.DataBind();
                        ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetsuccess('تم الحفظ بنجاح');", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception(" + ex.Message + ")", true);
            }
        }
        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle = "أسعار الأصناف";
                ExportingDevExpressUtil.Export(gvchangepriceExporter, "أسعار الأصناف", 1, Request.GetOwinContext().Request.User.Identity.Name, gvchangeprice.GetSelectedFieldValues("itemid").Count != 0, false, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_docexport_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle = "أسعار الأصناف";
                ExportingDevExpressUtil.Export(gvchangepriceExporter, "أسعار الأصناف", 0, Request.GetOwinContext().Request.User.Identity.Name, gvchangeprice.GetSelectedFieldValues("itemid").Count != 0, false, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_pdfexport_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle = "أسعار الأصناف";
                ExportingDevExpressUtil.Export(gvchangepriceExporter, "أسعار الأصناف", 2, Request.GetOwinContext().Request.User.Identity.Name, gvchangeprice.GetSelectedFieldValues("itemid").Count != 0, false, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_printexport_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle = "أسعار الأصناف";
                ExportingDevExpressUtil.Export(gvchangepriceExporter, "أسعار الأصناف", 2, Request.GetOwinContext().Request.User.Identity.Name, gvchangeprice.GetSelectedFieldValues("itemid").Count != 0, true, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_apply_Click(object sender, EventArgs e)
        {
            List<object> getparam()
            {
                return new List<object>
                { cmb_groupid,txt_descp,txt_sprice};
            }
            var res = SaveData("st_itemschaneprice_group_upd", getparam(), null,null,true,false,null,null);
            if (res.errorid == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('تم الحفظ بنجاح');", true);
                gvchangeprice.DataBind();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + res.errormsg + ")", true);
            }
        }
    }
}