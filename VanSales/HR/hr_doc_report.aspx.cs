using DevExpress.Web;
using Emax.Core.Utility;
using Emax.Dal;
using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;

namespace VanSales.HR
{
    public partial class hr_doc_report : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "58";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateRadioButtonList("sys_fillcomp_sel", rbl_doctynature, "compid,table_name", "28,sys_fillcomp", "citemid", "citemname");
                Util.GenerateCombobox("hr_document_type_sel", cmb_doctypeid, "mitemtype", rbl_doctynature.SelectedItem.Value.ToString(), "mitemcode", "mitemname");
            }
        }

        DataTable GvdetailSource()
        {
            if (cmb_doctypeid.SelectedIndex == -1)
            {
                cmb_doctypeid.Value = null;
            }
            
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("doctypeid", cmb_doctypeid.Value);
            dict.Add("doctynature", rbl_doctynature.Value);
            dict.Add("empid", hf_empid.Value);
            dict.Add("datefrom", txt_datefrom.Text);
            dict.Add("dateto", txt_dateto.Text);
            return SqlCommandHelper.ExcecuteToDataTable("hr_doc_report_sel", dict, false).dataTable;
        }

        string Title()
        {
            string title = "";
            if (cmb_doctypeid.SelectedItem != null)
            {
                title = rbl_doctynature.SelectedItem.Text + " " + cmb_doctypeid.SelectedItem.Text;
            }
            return title;
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                gv_doc.DataBind();
                gv_doc.ExpandAll();
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            int cellno = 0;
            Dictionary<string, object> dict = new Dictionary<string, object>();
            var s = gv_doc.VisibleRowCount;
            DataTable reptb = new DataTable();

            foreach (GridViewDataColumn item in gv_doc.VisibleColumns)
            {
                reptb.Columns.Add(item.FieldName);
                cellno++;
            }
            for (int i = 0; i < s; i++)
            {
                var ggd = gv_doc.GetDataRow(i);
                reptb.ImportRow(ggd);
                try
                {
                    if (reptb.Columns.Contains("docexpiredate"))
                    {
                        var newdate = Convert.ToDateTime(ggd.ItemArray.GetValue(6)).ToString("yyyy-MM-dd");
                        reptb.Rows[i]["docexpiredate"] = newdate;
                    }
                }
                catch (Exception) { }
            }

            int count = Convert.ToInt32(gv_doc.GetTotalSummaryValue((ASPxSummaryItem)gv_doc.TotalSummary["empcode"]));
            dict.Add("count", count);
            dict.Add("doctypeid", cmb_doctypeid.Text);
            dict.Add("datefrom", txt_datefrom.Text);
            dict.Add("dateto", txt_dateto.Text);
            dict.Add("empname", txt_empname.Text);
            
            PrintPage("HR/hr_doc_report.repx", reptb, dict);
        }

        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            txt_datefrom.Text = null;
            txt_dateto.Text = null;
            rbl_doctynature.SelectedIndex = 0;
            cmb_doctypeid.SelectedIndex = 0;
            txt_empid.Text = null;
            txt_empname.Text = null;
            hf_empid.Value = null;
            gv_doc.DataBind();
            gv_doc.FilterExpression = "";
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvempsalaryvarExporter, "تقرير الوثائق الرسمية", 1, Request.GetOwinContext().Request.User.Identity.Name, gv_doc.GetSelectedFieldValues("empcode").Count != 0, false, "تقرير الوثائق الرسمية" , Title());
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
                ExportingDevExpressUtil.Export(gvempsalaryvarExporter, "تقرير الوثائق الرسمية", 0, Request.GetOwinContext().Request.User.Identity.Name, gv_doc.GetSelectedFieldValues("empcode").Count != 0, false, "تقرير الوثائق الرسمية" , Title());
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
                ExportingDevExpressUtil.Export(gvempsalaryvarExporter, "تقرير الوثائق الرسمية", 2, Request.GetOwinContext().Request.User.Identity.Name, gv_doc.GetSelectedFieldValues("empcode").Count != 0, false, "تقرير الوثائق الرسمية" , Title());
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void gv_doc_DataBinding(object sender, EventArgs e)
        {
            gv_doc.DataSource = GvdetailSource();
        }

        protected void rbl_doctynature_ValueChanged(object sender, EventArgs e)
        {
            Util.GenerateCombobox("hr_document_type_sel", cmb_doctypeid, "mitemtype", rbl_doctynature.SelectedItem.Value.ToString(), "mitemcode", "mitemname");
        }

        protected void gv_doc_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {
            if (e.RowType != GridViewRowType.Data) return;
            int remain = Convert.ToInt32(e.GetValue("remainingday"));
            if (remain <= 0)
            {
                e.Row.BackColor = System.Drawing.Color.Red;
                e.Row.ForeColor = System.Drawing.Color.White;
            }
        }
    }
}