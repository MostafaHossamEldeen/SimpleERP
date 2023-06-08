using DevExpress.Web;
using Emax.Core.Utility;
using Emax.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;

namespace VanSales.GL
{
    public partial class RepSubTrailBalance : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "71";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["dtrep"] = null;
            }
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("dtefrom", dtefrom.Value);
            dict.Add("dteto", dteto.Value);
            //dict.Add("levelno", cmb_levelno.Value);
            // dict.Add("chartid", hf_chartid.Value);
            //dict.Add("posted", cmb_posted.Value);
            dict.Add("chartid", hf_chartid.Value);
   
            dt = SqlCommandHelper.ExcecuteToDataTable("sub_trail_balance", dict).dataTable;
            //}


            ASPxGridView1.DataSource = dt;// ((DataTable)Session["dtrep"]);
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

            //   var s = ASPxGridView1.VisibleRowCount;
            //   var col = ASPxGridView1.Columns;
            //   DataTable reptb = new DataTable();

            //   foreach (GridViewDataColumn item in ASPxGridView1.Columns)
            //   {
            //       reptb.Columns.Add(item.FieldName);
            //   }
            //   for (int i = 0; i < s; i++)
            //   {
            //       var ggd = ASPxGridView1.GetDataRow(i);


            //       reptb.ImportRow(ggd);
            //   }
            //   //ReportDataSet reportDataSet = new ReportDataSet();
            //   //if (chck_begbalance.Checked!=true)
            //   //{
            //   //    PrintPage("sales/itemrep.repx", reptb);
            //   //}
            //   //else
            //   //{
            ////   PrintPage("stock/itemrep.repx", reptb);
            //   //}

            //   // Session["repitems"] = reptb;.


            try
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("dtefrom", dtefrom.Value);
                dict.Add("dteto", dteto.Value);
                dict.Add("chartid", hf_chartid.Value);
                dict.Add("chartcode", txt_chartcode.Text);
                dict.Add("chartname", txt_chartname.Text);
                PrintPage("GL/sub_trail_balance.repx", dict);
                // gvitemsExporter.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType=ExportType.WYSIWYG});
                //ExportingDevExpressUtil.Export(gvinvExporter, "ميزان المراجعه الرئيسي", 2, Request.GetOwinContext().Request.User.Identity.Name,false ,true, "كشف حساب  ");
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }

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
                ExportingDevExpressUtil.Export(gvinvExporter, "كشف حساب", 1, Request.GetOwinContext().Request.User.Identity.Name, false, false, "كشف حساب ");
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
                ExportingDevExpressUtil.Export(gvinvExporter, "كشف حساب", 0, Request.GetOwinContext().Request.User.Identity.Name, false, false, "كشف حساب  ");
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
                ExportingDevExpressUtil.Export(gvinvExporter, "كشف حساب", 2, Request.GetOwinContext().Request.User.Identity.Name, false, false, "كشف حساب ");
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

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            hf_chartid.Value = null;
            txt_chartcode.Text = null;
            txt_chartname.Text = null;
            dtefrom.Value = null;
            dteto.Value = null;
            ASPxGridView1.DataBind();
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