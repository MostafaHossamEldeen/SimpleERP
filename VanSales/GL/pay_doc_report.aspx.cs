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
    public partial class pay_doc_report : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {

            pageid = "61";

            base.OnInit(e);

        }
        DataTable GvdetailSource()
        {
            if (cmb_pdbranchid.Value == null)
            {
                cmb_pdbranchid.Value = 0;
                cmb_pdbranchid.Text = null;
            }

            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("branchid", cmb_pdbranchid.Value);
            dict.Add("paidtype", cmb_paidtype.Value);
            dict.Add("fromdate", txt_fromdate.Date);
            dict.Add("todate", txt_todate.Date);

            return SqlCommandHelper.ExcecuteToDataTable("pay_doc_sel_report", dict, false).dataTable;
        }
        string Title()
        {
            string title = " فرع ";
            if (cmb_pdbranchid.Value == null)
            {
                title += "الكل";
            }
            else
            {
                title += cmb_pdbranchid.Text;
            }
            title += " " + "الفتره من: " + txt_fromdate.Text + " " + " الى:" + txt_todate.Text;
            if (cmb_paidtype.Value != null)
            {
                title += " " + "نوع القبض: " + cmb_paidtype.Text;

            }

            return title;
        }
        private void LoopcheckBoxes()
        {

            foreach (var item in formLayout.Items)
            {
                if (item is LayoutGroupBase)
                    (item as LayoutGroupBase).ForEach(GetNestedControls);
            }
        }
        void GetNestedControls(LayoutItemBase item)
        {
            if (item is LayoutItem)
                SetValue(item as LayoutItem);

        }
        void SetValue(LayoutItem c)
        {
            foreach (Control control in c.Controls)
            {
                ASPxCheckBox editor = control as ASPxCheckBox;
                if (editor != null)
                {


                    editor.Value = chk_all.Value;
                    if (editor.ID != "chk_all")
                    {
                        string[] coulms = editor.ID.Split('_');
                        gvs_pay_doc.Columns[coulms[1]].Visible = editor.Checked;
                    }
                }

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_pdbranchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_paidtype, "compid,table_name", "17,sys_fillcomp", "citemid", "citemname");
                cmb_pdbranchid.SelectedIndex = -1;
                //cmb_paidtype.SelectedIndex = -1;
                txt_fromdate.Date = DateTime.Now;
                txt_todate.Date = DateTime.Now;

            }

        }

        protected void btn_preview_Click(object sender, EventArgs e)
        {
            try
            {
                gvs_pay_doc.DataBind();
                gvs_pay_doc.ExpandAll();
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            if (gvs_pay_doc.VisibleColumns.Count > 8)
            {
                string error_msg = "لا يمكن طباعة التقرير بأكثر من 8 أعمدة";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                return;
            }
            else if (gvs_pay_doc.VisibleColumns.Count < 1)
            {
                string error_msg = "لا توجد أي بيانات ليتم طباعة التقرير";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                return;
            }
            else
            {

                string branchname;
                int count = 0;
                decimal pdbvat = 0;
                decimal vatvalue = 0;
                decimal pdavat = 0;
                int cellno = 0;
                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("cell1hide", false);
                dict.Add("cell2hide", false);
                dict.Add("cell3hide", false);
                dict.Add("cell4hide", false);
                dict.Add("cell5hide", false);
                dict.Add("cell6hide", false);
                dict.Add("cell7hide", false);
                dict.Add("cell8hide", false);
                dict.Add("cell9hide", false);
                dict.Add("cell1caption", null);
                dict.Add("cell2caption", null);
                dict.Add("cell3caption", null);
                dict.Add("cell4caption", null);
                dict.Add("cell5caption", null);
                dict.Add("cell6caption", null);
                dict.Add("cell7caption", null);
                dict.Add("cell8caption", null);
                dict.Add("cell9caption", null);
                dict.Add("cell1value", null);
                dict.Add("cell2value", null);
                dict.Add("cell3value", null);
                dict.Add("cell4value", null);
                dict.Add("cell5value", null);
                dict.Add("cell6value", null);
                dict.Add("cell7value", null);
                dict.Add("cell8value", null);
                dict.Add("cell9value", null);

                var s = gvs_pay_doc.VisibleRowCount;
                DataTable reptb = new DataTable();
                foreach (GridViewDataColumn item in gvs_pay_doc.VisibleColumns)
                {
                    reptb.Columns.Add(item.FieldName);
                    cellno++;
                    dict.Remove("cell" + cellno + "caption");
                    dict.Remove("cell" + cellno + "value");
                    dict.Remove("cell" + cellno + "hide");
                    dict.Add("cell" + cellno + "caption", item.Caption);
                    dict.Add("cell" + cellno + "value", "[" + item.FieldName + "]");
                    dict.Add("cell" + cellno + "hide", true);
                }
                for (int i = 0; i < s; i++)
                {
                    var ggd = gvs_pay_doc.GetDataRow(i);
                    reptb.ImportRow(ggd);
                    if (reptb.Columns.Contains("pddate"))
                    {
                        var newdate = Convert.ToDateTime(ggd.ItemArray.GetValue(4)).ToString("yyyy-MM-dd");
                        reptb.Rows[i]["pddate"] = newdate;
                    }
                }
                count = Convert.ToInt32(gvs_pay_doc.GetTotalSummaryValue((ASPxSummaryItem)gvs_pay_doc.TotalSummary["pdno"]));
                pdbvat = Convert.ToDecimal(gvs_pay_doc.GetTotalSummaryValue((ASPxSummaryItem)gvs_pay_doc.TotalSummary["pdbvat"]));
                vatvalue = Convert.ToDecimal(gvs_pay_doc.GetTotalSummaryValue((ASPxSummaryItem)gvs_pay_doc.TotalSummary["vatvalue"]));
                pdavat = Convert.ToDecimal(gvs_pay_doc.GetTotalSummaryValue((ASPxSummaryItem)gvs_pay_doc.TotalSummary["pdavat"]));
             

                if (cmb_pdbranchid.Value == null)
                {
                    cmb_pdbranchid.Value = 0;
                    cmb_pdbranchid.Text = null;
                }
                if (cmb_pdbranchid.Text == null || cmb_pdbranchid.Text == "")
                {
                    branchname = cmb_pdbranchid.NullText;
                }
                else
                {
                    branchname = cmb_pdbranchid.Text;
                }
                dict.Add("count", count);
                dict.Add("pdbvat", pdbvat);
                dict.Add("vatvalue", vatvalue);
                dict.Add("pdavat", pdavat);
                dict.Add("branchname", branchname);
                dict.Add("paidtype", cmb_paidtype.Text);
                dict.Add("fromdate", txt_fromdate.Text);
                dict.Add("todate", txt_todate.Text);

                PrintPage("GL/pay_doc_report.repx", reptb, dict);
            }
        }
        protected void btn_clear_Click(object sender, EventArgs e)
        {
            cmb_pdbranchid.Value = null;
            cmb_paidtype.Value = null;
            txt_fromdate.Date = DateTime.Now;
            txt_todate.Date = DateTime.Now;
            gvs_pay_doc.FilterExpression = "";
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {


                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير سندات الصرف", 1, Request.GetOwinContext().Request.User.Identity.Name, gvs_pay_doc.GetSelectedFieldValues("pdid").Count != 0, false, "تقرير سندات الصرف ", Title());
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


                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير سندات الصرف", 0, Request.GetOwinContext().Request.User.Identity.Name, gvs_pay_doc.GetSelectedFieldValues("pdid").Count != 0, false, "تقرير سندات الصرف ",Title());
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
                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير سندات الصرف", 2, Request.GetOwinContext().Request.User.Identity.Name, gvs_pay_doc.GetSelectedFieldValues("pdid").Count != 0, false, "تقرير سندات الصرف " ,Title());
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void chk_pdno_CheckedChanged(object sender, EventArgs e)
        {
            var test = sender as ASPxCheckBox;
            string[] coulms = test.ID.Split('_');
            gvs_pay_doc.Columns[coulms[1]].Visible = test.Checked;
        }

        protected void gvs_pay_doc_DataBinding(object sender, EventArgs e)
        {
            gvs_pay_doc.DataSource = GvdetailSource();
        }

        protected void gvs_pay_doc_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {

        }

        protected void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            LoopcheckBoxes();
        }
    }
}