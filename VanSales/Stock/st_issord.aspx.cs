using System;
using Emax.Core.Utility;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Repository.Ado;
using Emax.Dal;
using System.IO;

namespace VanSales.Stock
{
    public partial class st_issord : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "17";
            IndexStored = "st_trans_issord_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            gv_issord.DataBind();
        }

        protected void btn_new_Click(object sender, EventArgs e)
        {
            Response.Redirect("st_edit_issord.aspx");
        }

        protected void btn_xlsx_export_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gv_issord_Exporter, "أذون الصرف", 1, Request.GetOwinContext().Request.User.Identity.Name, gv_issord.GetSelectedFieldValues("transid").Count != 0, false);
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
                ExportingDevExpressUtil.Export(gv_issord_Exporter, "أذون الصرف", 0, Request.GetOwinContext().Request.User.Identity.Name, gv_issord.GetSelectedFieldValues("transid").Count != 0, false);
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
                ExportingDevExpressUtil.Export(gv_issord_Exporter, "أذون الصرف", 2, Request.GetOwinContext().Request.User.Identity.Name, gv_issord.GetSelectedFieldValues("transid").Count != 0, false);
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
                ExportingDevExpressUtil.Export(gv_issord_Exporter, "أذون الصرف", 2, Request.GetOwinContext().Request.User.Identity.Name, gv_issord.GetSelectedFieldValues("transid").Count != 0, true);
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception('" + msg + "')", true);
            }
        }


        protected void gv_issord_DataBinding(object sender, EventArgs e)
        {
            gv_issord.DataSource = IndexDataTable;

        }
         
        protected void gv_issord_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            List<object> KeyValues = gv_issord.GetSelectedFieldValues("transid");
            StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
            var res = new StoredExecuteResulte();
            foreach (object key in KeyValues)
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("transid", key);

                res = SqlCommandHelper.ExecuteNonQuery("st_transactions_issord_del", dict, true);
                if (res.errorid == 0)
                {
                    gv_issord.JSProperties["cperrors"] = "تم الحذف بنجاح";
                    gv_issord.JSProperties["cpicon"] = "success";
                }
                else
                {
                    break;
                }
            }
            if (res.errorid != 0)
            {
                gv_issord.JSProperties["cperrors"] = res.errormsg;
                gv_issord.JSProperties["cpicon"] = "error";

            }
            gv_issord.DataBind();
        }
        
    }
}