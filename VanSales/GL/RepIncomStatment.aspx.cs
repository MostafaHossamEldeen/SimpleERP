using DevExpress.Web;
using Emax.Core.Utility;
using Emax.Dal;
using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.GL
{
    public partial class RepIncomStatment : EmaxBasepage
    {
        DataTable dt;
        protected override void OnInit(EventArgs e)
        {
            pageid = "70";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_levelno, "compid,table_name", "13,levelno", "citemid", "citemname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_ccid, "compid,table_name", "0,sys_costcenter", "ccid", "ccname");
                Session["dtrep"] = null;
            }
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["dtrep"];
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("dtefrom", dtefrom.Value);
            dict.Add("dteto", dteto.Value);
            dict.Add("levelno", cmb_levelno.Value);
            dict.Add("ccid", cmb_ccid.Value);
            dt= SqlCommandHelper.ExcecuteToDataTable("Income", dict).dataTable;
            
            ASPxGridView1.DataSource = Emax.SharedLib.Utility.AcoStatmentHelper.PrepareIncomeStatment(dt);
            //var summ = new ASPxSummaryItem
            //{
            //    DisplayFormat = "الاجمالى {0}",
            //    FieldName = "",
            //    SummaryType = DevExpress.Data.SummaryItemType.Custom,
            //    ShowInColumn = ""
            //};
            //ASPxGridView1.TotalSummary.Add(summ);

            //Session["repdata"] = (((DataTable)Session["dtrep"]).Select(f)).AsEnumerable();
        }
       
        protected void ASPxGridView1_AfterPerformCallback(object sender, DevExpress.Web.ASPxGridViewAfterPerformCallbackEventArgs e)
        {
            //var g = e.CallbackName;
            //var f = (sender as DevExpress.Web.ASPxGridView);
            //var s = f.VisibleRowCount;
            //DataTable reptb = new DataTable();
            //for (int i = 0; i < s; i++)
            //{
            //    var ggd = f.GetDataRow(i);
            //    reptb.ImportRow(ggd);
            //}

            //Session["repitems"] = reptb;
        }

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            var s = ASPxGridView1.VisibleRowCount;
            var col = ASPxGridView1.Columns;
            DataTable reptb = new DataTable();
            foreach (GridViewDataColumn item in ASPxGridView1.Columns)
            {
                reptb.Columns.Add(item.FieldName);
            }
            for (int i = 0; i < s; i++)
            {
                var ggd = ASPxGridView1.GetDataRow(i);
                reptb.ImportRow(ggd);
            }
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("dtefrom", dtefrom.Value);
            dict.Add("dteto", dteto.Value);
            dict.Add("levelnoname", cmb_levelno.Text);
            dict.Add("ccname", cmb_ccid.Text);
            PrintPage("GL/RepIncomStatment.repx", reptb, dict);
        }

        protected void ASPxGridView1_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            ASPxGridView1.DataBind();
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {

                // gvitemsExporter.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType=ExportType.WYSIWYG});
                ExportingDevExpressUtil.Export(gvinvExporter, "قائمة الدخل", 1, Request.GetOwinContext().Request.User.Identity.Name, false, false, "قائمة الدخل ");
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

                // gvitemsExporter.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType=ExportType.WYSIWYG});
                ExportingDevExpressUtil.Export(gvinvExporter, "قائمة الدخل", 0, Request.GetOwinContext().Request.User.Identity.Name, false, false, "قائمة الدخل  ");
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

                // gvitemsExporter.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType=ExportType.WYSIWYG});
              

               // DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(new FilesystemReportStorageWebExtension(this.Context, "/ReportFiles/" + reportpath.Split('/')[0]));
           
                //Session["report"] = ExportingDevExpressUtil.PerviewPdf(gvinvExporter, "قائمة الدخل", 2, Request.GetOwinContext().Request.User.Identity.Name, false, false, "قائمة الدخل ");
                //  ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "printreport", "openviewer()", true); 
                // ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "showpdf('maintrailbalance')", true);

               // Response.Redirect("/reportviewer/viewrep?p=maintrailbalance");
            }
            catch (Exception ex)
            {
            
            }
        }
        decimal totalSumDebit, totalSumCredit;

        protected void ASPxGridView1_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {

        }

        protected void ASPxGridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            //ASPxGridView Grid = sender as ASPxGridView;
            //if ((e.Item as ASPxSummaryItem).Tag == "tot" && (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize))
            //{
            //    ASPxSummaryItem debitSummary = (sender as ASPxGridView).TotalSummary.Find(x => x.Tag == "debit");
            //    ASPxSummaryItem creditSummary = (sender as ASPxGridView).TotalSummary.Find(x => x.Tag == "credit");
            //    Decimal debit = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(debitSummary));
            //    Decimal credit = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(creditSummary));

            //    e.TotalValue = Math.Abs(debit - credit);
            //    ASPxSummaryItem totsummary = (sender as ASPxGridView).TotalSummary.Find(x => x.Tag == "tot");
            //    if ((debit - credit) > 0)
            //    {
            //        totsummary.DisplayFormat = "اجمالى مدين {0}";
            //    }
            //    else if ((debit - credit) < 0)
            //    {
            //        totsummary.DisplayFormat = "اجمالى دائن {0}";
            //    }


            //}
            //else
            //{
            //    if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
            //    {
            //        if ((e.Item as ASPxSummaryItem).Tag == "debit") totalSumDebit = 0;
            //        if ((e.Item as ASPxSummaryItem).Tag == "credit") totalSumCredit = 0;
            //    }
            //    else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
            //    {
            //        if ((e.Item as ASPxSummaryItem).Tag == "debit")
            //            // if (e.GetValue("Type").ToString() == "credit")
            //            totalSumDebit += Convert.ToInt32(e.FieldValue);
            //        if ((e.Item as ASPxSummaryItem).Tag == "credit")
            //            // if (e.GetValue("Type").ToString() == "deduction")
            //            totalSumCredit += Convert.ToInt32(e.FieldValue);
            //    }
            //    else
            //    if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
            //    {
            //        if ((e.Item as ASPxSummaryItem).Tag == "debit") e.TotalValue = totalSumDebit;
            //        if ((e.Item as ASPxSummaryItem).Tag == "credit") e.TotalValue = totalSumCredit;
            //    }
            //}
        }
    }
}