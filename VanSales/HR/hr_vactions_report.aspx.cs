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

namespace VanSales.HR
{
    public partial class hr_vactions_report : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "62";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("hr_masterfiles_sel", cmb_vnameid, "masterid", "4", "mitemcode", "mitemname");
            }
        }

        DataTable GvdetailSource()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("empid", hf_empid.Value);
            dict.Add("datefrom", txt_datefrom.Value);
            dict.Add("dateto", txt_dateto.Value);
            dict.Add("vnameid", cmb_vnameid.Value);
            return SqlCommandHelper.ExcecuteToDataTable("hr_vactions_report_sel", dict, false).dataTable;
        }

        protected void btn_Review_Click(object sender, EventArgs e)
        {
            try
            {
                gv_vactions.DataBind();
                gv_vactions.ExpandAll();
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            gv_vactions.Columns["empname"].Visible = true;
            gv_vactions.Columns["empname"].Caption = "إسم الموظف";
            gv_vactions.DataColumns["empname"].GroupIndex = -1;
            gv_vactions.DataBind();
            gv_vactions.ExpandAll();

            int cellno = 0;
            Dictionary<string, object> dict = new Dictionary<string, object>();
            var s = gv_vactions.VisibleRowCount;
            DataTable reptb = new DataTable();

            foreach (GridViewDataColumn item in gv_vactions.VisibleColumns)
            {
                reptb.Columns.Add(item.FieldName);
                cellno++;
            }
            for (int i = 0; i < s; i++)
            {
                var ggd = gv_vactions.GetDataRow(i);
                reptb.ImportRow(ggd);
                if (reptb.Columns.Contains("vdate"))
                {
                    var newdate = Convert.ToDateTime(ggd.ItemArray.GetValue(3)).ToString("yyyy-MM-dd");
                    reptb.Rows[i]["vdate"] = newdate;
                }
                try
                {
                    if (reptb.Columns.Contains("vfromd"))
                    {
                        var newdate = Convert.ToDateTime(ggd.ItemArray.GetValue(8)).ToString("yyyy-MM-dd");
                        reptb.Rows[i]["vfromd"] = newdate;
                    }
                    if (reptb.Columns.Contains("vtodate"))
                    {
                        var newdate = Convert.ToDateTime(ggd.ItemArray.GetValue(9)).ToString("yyyy-MM-dd");
                        reptb.Rows[i]["vtodate"] = newdate;
                    }
                }
                catch (Exception)
                {}
            }
            int count = Convert.ToInt32(gv_vactions.GetTotalSummaryValue((ASPxSummaryItem)gv_vactions.TotalSummary["empcode"]));
            int balance = Convert.ToInt32(gv_vactions.GetTotalSummaryValue((ASPxSummaryItem)gv_vactions.TotalSummary["vadd"]));
            int num_of_days = Convert.ToInt32(gv_vactions.GetTotalSummaryValue((ASPxSummaryItem)gv_vactions.TotalSummary["vreq"]));
          
            dict.Add("count", count);
            dict.Add("balance", balance);
            dict.Add("num_of_days", num_of_days);

            dict.Add("vnameid", cmb_vnameid.Text);
            dict.Add("datefrom", txt_datefrom.Text);
            dict.Add("dateto", txt_dateto.Text);
            dict.Add("empname", txt_empname.Text);
            gv_vactions.Columns["empname"].Visible = false;
            gv_vactions.Columns["empname"].Caption = " ";
            gv_vactions.DataColumns["empname"].GroupIndex = 0;
            PrintPage("HR/hr_vactions_report.repx", reptb, dict);
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            txt_datefrom.Value = null;
            txt_dateto.Value = null;
            txt_empid.Text = null;
            txt_empname.Text = null;
            hf_empid.Value = null;
            cmb_vnameid.SelectedIndex = 0;
            gv_vactions.DataBind();
            gv_vactions.FilterExpression = "";
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvempsalaryvarExporter, "تقرير الأجازات", 1, Request.GetOwinContext().Request.User.Identity.Name, gv_vactions.GetSelectedFieldValues("empcode").Count != 0, false, "تقرير الأجازات");
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
                ExportingDevExpressUtil.Export(gvempsalaryvarExporter, "تقرير الأجازات", 0, Request.GetOwinContext().Request.User.Identity.Name, gv_vactions.GetSelectedFieldValues("empcode").Count != 0, false, "تقرير الأجازات");
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
                ExportingDevExpressUtil.Export(gvempsalaryvarExporter, "تقرير الأجازات", 2, Request.GetOwinContext().Request.User.Identity.Name, gv_vactions.GetSelectedFieldValues("empcode").Count != 0, false, "تقرير الأجازات");
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void gv_vactions_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            ASPxSummaryItem summary = e.Item as ASPxSummaryItem;
            switch (summary.FieldName)
            {
                case "vnotes":
                    decimal rest = 0;
                    rest = EmaxGlobals.NullToZero(gv_vactions.GetTotalSummaryValue((ASPxSummaryItem)gv_vactions.TotalSummary["vadd"])) - EmaxGlobals.NullToZero(gv_vactions.GetTotalSummaryValue((ASPxSummaryItem)gv_vactions.TotalSummary["vreq"]));
                    e.TotalValue = "المتبقي = " + rest;
                    e.TotalValueReady = true;
                    break;
            }
        }

        protected void gv_vactions_DataBinding(object sender, EventArgs e)
        {
            gv_vactions.DataSource = GvdetailSource();
        }

        protected void gv_vactions_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != GridViewRowType.Data) return;
            string vv = e.GetValue("vadd").ToString();
            if (vv == "" || vv == null)
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