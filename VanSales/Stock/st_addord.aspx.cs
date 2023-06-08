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

namespace VanSales.Stock
{
    public partial class st_addord : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "15";
            IndexStored = "st_transaction_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gv_add_ord.DataBind();
        }

        protected void btn_new_Click(object sender, EventArgs e)
        {
            Response.Redirect("st_Edit_add_ord.aspx");
        }

        protected void btn_xlsx_export_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gv_add_ord_Exporter, "أذون الاضافه", 1, Request.GetOwinContext().Request.User.Identity.Name, gv_add_ord.GetSelectedFieldValues("transid").Count != 0, false);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception('" + msg + "')", true);
            }
        }

        protected void btn_doc_export_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gv_add_ord_Exporter, "أذون الاضافه", 0, Request.GetOwinContext().Request.User.Identity.Name, gv_add_ord.GetSelectedFieldValues("transid").Count != 0, false);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception('" + msg + "')", true);
            }
        }

        protected void btn_pdf_export_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gv_add_ord_Exporter, "أذون الاضافه", 2, Request.GetOwinContext().Request.User.Identity.Name, gv_add_ord.GetSelectedFieldValues("transid").Count != 0, false);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception('" + msg + "')", true);
            }
        }

        protected void btn_print_export_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gv_add_ord_Exporter, "أذون الاضافه", 2, Request.GetOwinContext().Request.User.Identity.Name, gv_add_ord.GetSelectedFieldValues("transid").Count != 0, true);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception('" + msg + "')", true);
            }
        }
   

        protected void gv_add_ord_DataBinding(object sender, EventArgs e)
        {
            gv_add_ord.DataSource = IndexDataTable;
            
        }

        protected void gv_add_ord_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            List<object> KeyValues = gv_add_ord.GetSelectedFieldValues("transid");
            StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
            var res = new StoredExecuteResulte();
            foreach (object key in KeyValues)
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("transid", key);

                res = SqlCommandHelper.ExecuteNonQuery("st_transactions_issord_del", dict, true);
                if (res.errorid == 0)
                {
                    gv_add_ord.JSProperties["cperrors"] = "تم الحذف بنجاح";
                    gv_add_ord.JSProperties["cpicon"] = "success";
                }
                else
                {
                    break;
                }
            }
            if (res.errorid != 0)
            {
                gv_add_ord.JSProperties["cperrors"] = res.errormsg;
                gv_add_ord.JSProperties["cpicon"] = "error";

            }
            gv_add_ord.DataBind();
        }
    }
}