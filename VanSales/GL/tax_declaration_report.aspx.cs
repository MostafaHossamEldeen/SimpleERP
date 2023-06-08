using DevExpress.Web;
using Emax.Core.Utility;
using Emax.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.GL
{
    public partial class tax_declaration_report : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {

            pageid = "78";

            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_fromdate.Date = DateTime.Now;
                txt_todate.Date = DateTime.Now;
                chk_post_acc.Checked = false;
            }
        }

        protected void btn_preview_Click(object sender, EventArgs e)
        {
            try
            {
                gv_tax_declaration.DataBind();
                gv_tax_declaration.ExpandAll();
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("fromdate", txt_fromdate.Value);
                dict.Add("todate", txt_todate.Value);
                dict.Add("postacc", chk_post_acc.Value);
                PrintPage("GL/tax_declaration.repx", dict);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            txt_fromdate.Date = Convert.ToDateTime(null);
            txt_todate.Date = Convert.ToDateTime(null);
            chk_post_acc.Checked = false;
            gv_tax_declaration.FilterExpression = "";
            gv_tax_declaration.DataBind();
            txt_fromdate.Date = DateTime.Now;
            txt_todate.Date = DateTime.Now;
            chk_post_acc.Checked = false;
        }
        string Title()
        {
            string title = "الإقرار الضريبي ";
            title += " " + "الفتره من: " + txt_fromdate.Text + " " + " الى:" + txt_todate.Text;
            return title;
        }
        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvinvExporter, "الإقرار الضريبي", 1, Request.GetOwinContext().Request.User.Identity.Name, false, false, "الإقرار الضريبي", Title());
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_docexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvinvExporter, "الإقرار الضريبي", 0, Request.GetOwinContext().Request.User.Identity.Name, false, false, "الإقرار الضريبي", Title());
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_pdfexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvinvExporter, "الإقرار الضريبي", 2, Request.GetOwinContext().Request.User.Identity.Name,false, false, "الإقرار الضريبي", Title());
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }
        DataTable GvdetailSource()
        {
            if (chk_post_acc.Value == null)
                chk_post_acc.Value = 0;
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("postacc", chk_post_acc.Value);
            dict.Add("fromdate", txt_fromdate.Date);
            dict.Add("todate", txt_todate.Date);
            return SqlCommandHelper.ExcecuteToDataTable("tax_declaration_report", dict, false).dataTable;
        }
        protected void gv_tax_declaration_DataBinding(object sender, EventArgs e)
        {
            gv_tax_declaration.DataSource = GvdetailSource();
        }

        protected void gv_tax_declaration_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            ASPxSummaryItem summary = e.Item as ASPxSummaryItem;
            switch (summary.FieldName)
            {
                case "vat":
                    double vat = 0;
                    vat = Convert.ToDouble(gv_tax_declaration.GetGroupSummaryValue(0, (ASPxSummaryItem)gv_tax_declaration.GroupSummary["vat"])) - Convert.ToDouble(gv_tax_declaration.GetGroupSummaryValue(1, (ASPxSummaryItem)gv_tax_declaration.GroupSummary["vat"]));
                    e.TotalValue = vat;
                    e.TotalValueReady = true;

                    break;
            }
        }
    }
}