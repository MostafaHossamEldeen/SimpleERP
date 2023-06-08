using DevExpress.Web;
using Emax.Core.Utility;
using Emax.CoreCore;
using Emax.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.HR
{
    public partial class hr_loan_report : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "60";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        DataTable GvdetailSource()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("empid", hf_empid.Value);
            dict.Add("datefrom", txt_datefrom.Text);
            dict.Add("dateto", txt_dateto.Text);
            return SqlCommandHelper.ExcecuteToDataTable("hr_loan_report_sel", dict, false).dataTable;
        }

        protected void btn_Review_Click(object sender, EventArgs e)
        {
            try
            {
                gv_loan.DataBind();
                gv_loan.ExpandAll();
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            gv_loan.Columns["empname"].Visible = true;
            gv_loan.Columns["empname"].Caption = "اسم الموظف";
            gv_loan.DataColumns["empname"].GroupIndex = -1;
            gv_loan.DataBind();
            gv_loan.ExpandAll();

            int cellno = 0;
            Dictionary<string, object> dict = new Dictionary<string, object>();
            var s = gv_loan.VisibleRowCount;
            DataTable reptb = new DataTable();

            foreach (GridViewDataColumn item in gv_loan.VisibleColumns)
            {
                reptb.Columns.Add(item.FieldName);
                cellno++;
            }
            for (int i = 0; i < s; i++)
            {
                var ggd = gv_loan.GetDataRow(i);
                reptb.ImportRow(ggd);
                if (reptb.Columns.Contains("loandate"))
                {
                    var newdate = Convert.ToDateTime(ggd.ItemArray.GetValue(2)).ToString("yyyy-MM-dd");
                    reptb.Rows[i]["loandate"] = newdate;
                }
               
            }
            int count = Convert.ToInt32(gv_loan.GetTotalSummaryValue((ASPxSummaryItem)gv_loan.TotalSummary["empcode"]));
            decimal count_loanvalue = Convert.ToDecimal(gv_loan.GetTotalSummaryValue((ASPxSummaryItem)gv_loan.TotalSummary["loanvalue"]));
            decimal count_loanpay = Convert.ToDecimal(gv_loan.GetTotalSummaryValue((ASPxSummaryItem)gv_loan.TotalSummary["loanpay"]));
            decimal remainder = count_loanvalue - count_loanpay;
            dict.Add("count", count);
            dict.Add("total_loanvalue", count_loanvalue);
            dict.Add("total_loanpay", count_loanpay);
            dict.Add("remainder", remainder);
            dict.Add("datefrom", txt_datefrom.Text);
            dict.Add("dateto", txt_dateto.Text);
            dict.Add("empname", txt_empname.Text);
            gv_loan.Columns["empname"].Visible = false;
            gv_loan.Columns["empname"].Caption = " ";
            gv_loan.DataColumns["empname"].GroupIndex = 0;
            PrintPage("HR/hr_loan_report.repx", reptb, dict);
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            txt_datefrom.Text =null;
            txt_dateto.Text =null;
            txt_empid.Text = null;
            txt_empname.Text = null;
            hf_empid.Value = null;
            gv_loan.DataBind();
            gv_loan.FilterExpression = "";
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvempsalaryvarExporter, "تقرير السلف", 1, Request.GetOwinContext().Request.User.Identity.Name, gv_loan.GetSelectedFieldValues("empcode").Count != 0, false, "تقرير السلف");
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
                ExportingDevExpressUtil.Export(gvempsalaryvarExporter, "تقرير السلف", 0, Request.GetOwinContext().Request.User.Identity.Name, gv_loan.GetSelectedFieldValues("empcode").Count != 0, false, "تقرير السلف");
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
                ExportingDevExpressUtil.Export(gvempsalaryvarExporter, "تقرير السلف", 2, Request.GetOwinContext().Request.User.Identity.Name, gv_loan.GetSelectedFieldValues("empcode").Count != 0, false, "تقرير السلف");
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void gv_loan_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            ASPxSummaryItem summary = e.Item as ASPxSummaryItem;
            switch (summary.FieldName)
            {
                case "notes":
                    decimal rest = 0;
                    rest = EmaxGlobals.NullToZero(gv_loan.GetTotalSummaryValue((ASPxSummaryItem)gv_loan.TotalSummary["loanvalue"])) - EmaxGlobals.NullToZero(gv_loan.GetTotalSummaryValue((ASPxSummaryItem)gv_loan.TotalSummary["loanpay"]));
                    e.TotalValue = "المتبقي = " + rest;
                    e.TotalValueReady = true;
                    break;
            }
        }

        protected void gv_loan_DataBinding(object sender, EventArgs e)
        {
            gv_loan.DataSource = GvdetailSource();
        }

        protected void gv_loan_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != GridViewRowType.Data) return;
            string loan = e.GetValue("loanvalue").ToString();
            if (loan == "" || loan == null)
            {
                e.Row.BackColor = System.Drawing.Color.ForestGreen;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                e.Row.BackColor = System.Drawing.Color.Red;
                e.Row.ForeColor = System.Drawing.Color.White;
            }

        }
    }
}