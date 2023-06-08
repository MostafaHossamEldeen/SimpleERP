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
    public partial class RepDebtRecovery : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {

            pageid = "75";

            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_fromdate.Date = DateTime.Now;

            }
        }
        DataTable GvdetailSource()
        {
            



            Dictionary<object, object> dict = new Dictionary<object, object>();
       
            dict.Add("fromdate", txt_fromdate.Date);
        


            return SqlCommandHelper.ExcecuteToDataTable("GL_debt_recovery_report", dict, false).dataTable;
        }
        string Title()
        {


            string title = " " + "من تاريخ: " + txt_fromdate.Text + " ";
            

            return title;
        }
        protected void btn_preview_Click(object sender, EventArgs e)
        {
            try
            {
                gvs_debt.DataBind();
                gvs_debt.ExpandAll();
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            var s = gvs_debt.VisibleRowCount;
            var col = gvs_debt.Columns;
            int chartcode;
            decimal period1;
            decimal period2;
            decimal period3;
            decimal period4;
            decimal period5;
            decimal period6;
            decimal period7;
            decimal perioddot;

            
            DataTable reptb = new DataTable();
            foreach (GridViewDataColumn item in gvs_debt.Columns)
            {
                reptb.Columns.Add(item.FieldName);
            }
            for (int i = 0; i < s; i++)
            {
                var ggd = gvs_debt.GetDataRow(i);
                reptb.ImportRow(ggd);
            }

            chartcode = Convert.ToInt32(gvs_debt.GetTotalSummaryValue((ASPxSummaryItem)gvs_debt.TotalSummary["chartcode"]));
            period1 = Convert.ToDecimal(gvs_debt.GetTotalSummaryValue((ASPxSummaryItem)gvs_debt.TotalSummary["period1"]));
            period2 = Convert.ToDecimal(gvs_debt.GetTotalSummaryValue((ASPxSummaryItem)gvs_debt.TotalSummary["period2"]));
            period3 = Convert.ToDecimal(gvs_debt.GetTotalSummaryValue((ASPxSummaryItem)gvs_debt.TotalSummary["period3"]));
            period4 = Convert.ToDecimal(gvs_debt.GetTotalSummaryValue((ASPxSummaryItem)gvs_debt.TotalSummary["period4"]));
            period5 = Convert.ToDecimal(gvs_debt.GetTotalSummaryValue((ASPxSummaryItem)gvs_debt.TotalSummary["period5"]));
            period6 = Convert.ToDecimal(gvs_debt.GetTotalSummaryValue((ASPxSummaryItem)gvs_debt.TotalSummary["period6"]));
            period7 = Convert.ToDecimal(gvs_debt.GetTotalSummaryValue((ASPxSummaryItem)gvs_debt.TotalSummary["period7"]));
            perioddot = Convert.ToDecimal(gvs_debt.GetTotalSummaryValue((ASPxSummaryItem)gvs_debt.TotalSummary["periodtot"]));

            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("chartcode", chartcode);
            dict.Add("period1", period1);
            dict.Add("period2", period2);
            dict.Add("period3", period3);
            dict.Add("period4", period4);
            dict.Add("period5", period5);
            dict.Add("period6", period6);
            dict.Add("period7", period7);
            dict.Add("perioddot", perioddot);

            dict.Add("dtefrom", txt_fromdate.Value);
            
            PrintPage("GL/RepDebtRecovery.repx", reptb, dict);

        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            txt_fromdate.Date = DateTime.Now;
            gvs_debt.FilterExpression = "";
            gvs_debt.DataBind();
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {

                // gvitemsExporter.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType=ExportType.WYSIWYG});
                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير اعمار الديون", 1, Request.GetOwinContext().Request.User.Identity.Name, gvs_debt.GetSelectedFieldValues("id").Count != 0, false, "تقرير اعمار الديون", Title());
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


                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير اعمار الديون", 0, Request.GetOwinContext().Request.User.Identity.Name, gvs_debt.GetSelectedFieldValues("id").Count != 0, false, "تقرير اعمار الديون", Title());
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
                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير اعمار الديون", 2, Request.GetOwinContext().Request.User.Identity.Name, gvs_debt.GetSelectedFieldValues("id").Count != 0, false, "تقرير اعمار الديون", Title());
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void gvs_debt_DataBinding(object sender, EventArgs e)
        {
            gvs_debt.DataSource = GvdetailSource();
        }

        protected void gvs_debt_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {

        }
    }
}