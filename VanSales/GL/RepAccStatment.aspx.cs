using DevExpress.Web;
using Emax.Core.Utility;
using Emax.Dal;
using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;

namespace VanSales
{
    public partial class RepAccStatment : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "57";
            base.OnInit(e); 
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["dtrep"] = null;
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_ccid, "compid,table_name", "0,sys_costcenter", "ccid", "ccname");
                cmb_ccid.SelectedIndex = -1;
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
                dict.Add("showbalance", null);
                dict.Add("begbalance", null);
                dict.Add("sumtype", null);
                dict.Add("chartid", hf_chartid.Value);
                dict.Add("posted", cmb_posted.Value);
                dict.Add("dtefrom", dtefrom.Value);
                dict.Add("dteto", dteto.Value);
                dict.Add("ccid", cmb_ccid.Value);
                Session["dtrep"] = SqlCommandHelper.ExcecuteToDataTable("Acc_statment",dict).dataTable;
            ASPxGridView1.DataSource = ((DataTable)Session["dtrep"]);
        }

        protected void ASPxGridView1_AfterPerformCallback(object sender, DevExpress.Web.ASPxGridViewAfterPerformCallbackEventArgs e)
        {

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
            dict.Add("aco_id",hf_chartid.Value);
            dict.Add("aco_name", lbl_chartname.Text);
            dict.Add("posted",cmb_posted.Value);
            dict.Add("fromdate",dtefrom.Value);
            dict.Add("todate",dteto.Value);
            PrintPage("GL/rep_acc_statment.repx", reptb, dict);
        }

        protected void ASPxGridView1_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            ASPxGridView1.DataBind();
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {

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
                ExportingDevExpressUtil.Export(gvinvExporter, "كشف حساب", 2, Request.GetOwinContext().Request.User.Identity.Name, false, false, "كشف حساب " );
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
            txt_chartid.Text = null;
            lbl_chartname.Text = null;
            dtefrom.Value = null;
            dteto.Value = null;
            cmb_posted.SelectedIndex = 0;
            cmb_ccid.SelectedIndex = -1;
            ASPxGridView1.DataBind();
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
                            totalSumDebit += EmaxGlobals.NullToZero(e.FieldValue);
                    if ((e.Item as ASPxSummaryItem).Tag == "credit")
                            totalSumCredit += EmaxGlobals.NullToZero(e.FieldValue);
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