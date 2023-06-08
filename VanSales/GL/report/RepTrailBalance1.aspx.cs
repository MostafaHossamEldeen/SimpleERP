using DevExpress.Web;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web;
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
using VanSales.Models;
using VanSales.ReportServices;

namespace VanSales.GL.report
{
    public partial class RepTrailBalance : EmaxBaseReport
    {
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            //childpage = this;
            //this.Master.FindControl("MainContent").FindControl("ASPxDateEdit1");
            
         
            //   ReportDataSet reportDataSet = new ReportDataSet();
            //var rec = reportDataSet.RepHeaderColumn.NewRepHeaderColumnRow();
            //rec.Data = "txt_chartid";
            //rec.RepName = "itemrep"; rec.Caption = "كود الحساب";
            //rec.Rowno = 1;
            //reportDataSet.RepHeaderColumn.AddRepHeaderColumnRow(rec);
            // rec = reportDataSet.RepHeaderColumn.NewRepHeaderColumnRow();
            //rec.Data = "dtefrom";
            //rec.RepName = "itemrep"; rec.Caption = "من";
            //rec.Rowno = 2;
            //rec.DataType = true;
            //reportDataSet.RepHeaderColumn.AddRepHeaderColumnRow(rec);
            
            // rec = reportDataSet.RepHeaderColumn.NewRepHeaderColumnRow();
            //rec.Data = "dteto";
            //rec.RepName = "itemrep"; rec.Caption = "الى";
            //rec.Rowno = 2;
            //rec.DataType = true;
            //reportDataSet.RepHeaderColumn.AddRepHeaderColumnRow(rec);
            //rec = reportDataSet.RepHeaderColumn.NewRepHeaderColumnRow();
            //rec.Data = "cmb_posted";
            //rec.RepName = "itemrep"; rec.Caption = "نوع القيود";
            //rec.Rowno = 3;
            //rec.DataType = false;
          
            //var rec1 = reportDataSet.ReportHeaderRows.NewReportHeaderRowsRow();
            //rec1.RepName = "itemrep";
            //rec1.RowsCount = 4;
            //rec1.ColumnCount = 4;
            //reportDataSet.ReportHeaderRows.AddReportHeaderRowsRow(rec1);
            //reportDataSet.WriteXml(Server.MapPath("/ReportsInfo.xml")); ;
            ////string ReportPath = "Purchase/P_Inv_Page.repx";
            ////XtraReport xtraReport = new XtraReport();
            ////xtraReport.LoadLayout(Server.MapPath("/ReportFiles/Purchase/P_Inv_Page.repx"));

            ////DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(new FilesystemReportStorageWebExtension(this.Context, "/ReportFiles/" + ReportPath.Split('/')[0]));
            //////xtraReport.CreateDocument();
            //////xtraReport.ShowPreview();
            ////var cachedReportSource = new CachedReportSourceWeb(xtraReport);
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_levelno, "compid,table_name", "13,levelno", "citemid", "citemname");
                Session["dtrep"] = null;
               
               
            }
            
           
            //repviewer.OpenReport(xtraReport);

            //repviewer.DataBind();
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();

            // DataTable dt = ASPxGridView1.DataSource as DataTable;
            //     DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(new FilesystemReportStorageWebExtension(this.Context, "/ReportFiles/" + ReportPath.Split('/')[0]));
            //xtraReport.CreateDocument();
            //xtraReport.ShowPreview();

          
           // var cachedReportSource = new CachedReportSourceWeb( xtraReport);
            //  Session["report"] = xtraReport;
            //repviewer.t
          //  repviewer.OpenReport((XtraReport)Session["report"]);
           //repviewer.DataBind();
         

            //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "printreport", "openviewer()", true);
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["dtrep"];
            //if (dt==null)
            //{
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("showbalance", null);
                dict.Add("begbalance", null);
                dict.Add("sumtype", null);
               // dict.Add("chartid", hf_chartid.Value);
                dict.Add("posted", cmb_posted.Value);
                dict.Add("dtefrom", dtefrom.Value);
                dict.Add("dteto", dteto.Value);
                Session["dtrep"] = SqlCommandHelper.ExcecuteToDataTable("Acc_statment",dict).dataTable;
            //}
          
            
            ASPxGridView1.DataSource = ((DataTable)Session["dtrep"]);
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
            ReportDataSet reportDataSet = new ReportDataSet();
            //if (chck_begbalance.Checked!=true)
            //{
            //    PrintPage("sales/itemrep.repx", reptb);
            //}
            //else
            //{
                PrintPage("stock/itemrep.repx", reptb);
            //}
           
           // Session["repitems"] = reptb;
            
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
                ExportingDevExpressUtil.Export(gvinvExporter, "كشف حساب", 1, Request.GetOwinContext().Request.User.Identity.Name,false, false, "كشف حساب " );
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
                ExportingDevExpressUtil.Export(gvinvExporter, "كشف حساب", 0, Request.GetOwinContext().Request.User.Identity.Name, false, false, "كشف حساب  " );
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
                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير فواتير المبعات", 2, Request.GetOwinContext().Request.User.Identity.Name, false, false, "كشف حساب " );
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }
        decimal totalSumDebit, totalSumCredit;

        protected void ASPxGridView1_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {

        }

        protected void ASPxGridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            ASPxGridView Grid = sender as ASPxGridView;
            if ((e.Item as ASPxSummaryItem).Tag == "tot" && (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize))
            {
                ASPxSummaryItem debitSummary = (sender as ASPxGridView).TotalSummary.Find(x => x.Tag == "debit");
                ASPxSummaryItem creditSummary = (sender as ASPxGridView).TotalSummary.Find(x => x.Tag == "credit");
                Decimal debit = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue( debitSummary));
                Decimal credit = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(creditSummary));
                
                e.TotalValue =Math.Abs( debit - credit);
                ASPxSummaryItem totsummary = (sender as ASPxGridView).TotalSummary.Find(x => x.Tag == "tot");
                if ((debit - credit) > 0)
                {
                    totsummary.DisplayFormat = "اجمالى مدين {0}";
                }
                else if ((debit - credit) < 0)
                {
                    totsummary.DisplayFormat = "اجمالى دائن {0}";
                }
              
                
            }
            else
            {
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Start)
                {
                    if ((e.Item as ASPxSummaryItem).Tag == "debit") totalSumDebit = 0;
                    if ((e.Item as ASPxSummaryItem).Tag == "credit") totalSumCredit = 0;
                }
                else if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate)
                {
                    if ((e.Item as ASPxSummaryItem).Tag == "debit")
                       // if (e.GetValue("Type").ToString() == "credit")
                            totalSumDebit += Convert.ToInt32(e.FieldValue);
                    if ((e.Item as ASPxSummaryItem).Tag == "credit")
                       // if (e.GetValue("Type").ToString() == "deduction")
                            totalSumCredit += Convert.ToInt32(e.FieldValue);
                }
                else
                if (e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize)
                {
                    if ((e.Item as ASPxSummaryItem).Tag == "debit") e.TotalValue = totalSumDebit;
                    if ((e.Item as ASPxSummaryItem).Tag == "credit") e.TotalValue = totalSumCredit;
                }
            }
        }
    }
}