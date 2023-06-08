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
    public partial class hr_salaryvar_report : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {

            pageid = "55";
            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("hr_monthyear_sel_salaryprep", cmb_monyrid, "monyrid", "monyrname");
                cmb_monyrid.SelectedIndex = -1;
            }
        }
        DataTable GvdetailSource()
        {
            if (cmb_monyrid.SelectedIndex == -1)
            {
                cmb_monyrid.Value = null;
            }
            
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("monyrid", cmb_monyrid.Value);
            dict.Add("empid", hf_empid.Value);
            return SqlCommandHelper.ExcecuteToDataTable("hr_salaryvar_report_sel", dict, false).dataTable;
        }
        string Title()
        {
            string title = "";
            if (cmb_monyrid.SelectedItem != null)
            {
                title = "خاصة شهر /" + " " + cmb_monyrid.SelectedItem.Text;
            }
            return title;
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                gv_empsalaryvar.DataBind();
                gv_empsalaryvar.ExpandAll();
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            if (gv_empsalaryvar.VisibleColumns.Count > 8)
            {
                string error_msg = "لا يمكن طباعة التقرير بأكثر من 8 أعمدة";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                return;
            }
            else if (gv_empsalaryvar.VisibleColumns.Count < 1)
            {
                string error_msg = "لا توجد أي بيانات ليتم طباعة التقرير";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                return;
            }
            else
            {
                gv_empsalaryvar.Columns["svname"].Visible = true;
                gv_empsalaryvar.Columns["svname"].Caption = "النوع";
                gv_empsalaryvar.DataColumns["svname"].GroupIndex = -1;
                gv_empsalaryvar.DataBind();
                gv_empsalaryvar.ExpandAll();

                int invcount = 0;
                int rtncount = 0;
                decimal invvalue = 0;
                decimal rtnvalue = 0;
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
                
                var s = gv_empsalaryvar.VisibleRowCount;
                DataTable reptb = new DataTable();
                foreach (GridViewDataColumn item in gv_empsalaryvar.VisibleColumns)
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
                    var ggd = gv_empsalaryvar.GetDataRow(i);
                    reptb.ImportRow(ggd);
                    if (reptb.Columns.Contains("svdate"))
                    {
                        var newdate = Convert.ToDateTime(ggd.ItemArray.GetValue(5)).ToString("yyyy-MM-dd");
                        reptb.Rows[i]["svdate"] = newdate;
                    }
                    if (ggd.ItemArray.GetValue(6).ToString() == "استحقاق")
                    {
                        invcount = invcount + 1;
                        invvalue = invvalue + Convert.ToDecimal(ggd.ItemArray.GetValue(11));  
                    }
                    else if (ggd.ItemArray.GetValue(6).ToString().ToString() == "استقطاع")
                    {
                        rtncount = rtncount + 1;
                        rtnvalue = rtnvalue + Convert.ToDecimal(ggd.ItemArray.GetValue(11));
                    }
                }

                dict.Add("invcount", invcount);
                dict.Add("rtncount", rtncount);
                dict.Add("invtotal", invvalue);
                dict.Add("rtntotal", rtnvalue);
                dict.Add("empid", txt_empid.Text);
                dict.Add("empname", txt_empname.Text);
                dict.Add("monyrid", cmb_monyrid.Text);

                gv_empsalaryvar.Columns["svname"].Visible = false;
                gv_empsalaryvar.Columns["svname"].Caption = " ";
                gv_empsalaryvar.DataColumns["svname"].GroupIndex = 0;
                PrintPage("HR/hr_salaryvar_report.repx", reptb, dict);
            }
        }

        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            cmb_monyrid.SelectedIndex = -1;
            txt_empid.Text = null;
            txt_empname.Text = null;
            hf_empid.Value = null;
            gv_empsalaryvar.DataBind();
            gv_empsalaryvar.FilterExpression = "";
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvempsalaryvarExporter, "تقرير متغيرات رواتب الموظفين", 1, Request.GetOwinContext().Request.User.Identity.Name, gv_empsalaryvar.GetSelectedFieldValues("empcode").Count != 0, false, "تقرير متغيرات رواتب الموظفين" , Title());
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
                ExportingDevExpressUtil.Export(gvempsalaryvarExporter, "تقرير متغيرات رواتب الموظفين", 0, Request.GetOwinContext().Request.User.Identity.Name, gv_empsalaryvar.GetSelectedFieldValues("empcode").Count != 0, false, "تقرير متغيرات رواتب الموظفين" , Title());
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
                ExportingDevExpressUtil.Export(gvempsalaryvarExporter, "تقرير متغيرات رواتب الموظفين", 2, Request.GetOwinContext().Request.User.Identity.Name, gv_empsalaryvar.GetSelectedFieldValues("empcode").Count != 0, false, "تقرير متغيرات رواتب الموظفين" , Title());
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void chk_empcode_CheckedChanged(object sender, EventArgs e)
        {
            var test = sender as ASPxCheckBox;
            string[] coulms = test.ID.Split('_');
            gv_empsalaryvar.Columns[coulms[1]].Visible = test.Checked;
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
                        gv_empsalaryvar.Columns[coulms[1]].Visible = editor.Checked;
                    }
                }

            }
        }
        protected void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            LoopcheckBoxes();
        }

        protected void gv_empsalaryvar_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            //ASPxSummaryItem summary = e.Item as ASPxSummaryItem;
            //switch (summary.FieldName)
            //{
            //    case "netbvat":
            //        double netbvat = 0;
            //        netbvat = Convert.ToDouble(gvs_inv.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv.GroupSummary["netbvat"])) - Convert.ToDouble(gvs_inv.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv.GroupSummary["netbvat"]));
            //        e.TotalValue = netbvat;
            //        e.TotalValueReady = true;

            //        break;
            //    case "netavat":
            //        double netavat = 0;
            //        netavat = Convert.ToDouble(gvs_inv.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv.GroupSummary["netavat"])) - Convert.ToDouble(gvs_inv.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv.GroupSummary["netavat"]));
            //        e.TotalValue = netavat;
            //        e.TotalValueReady = true;

            //        break;
            //    case "vatvalue":
            //        double vatvalue = 0;
            //        vatvalue = Convert.ToDouble(gvs_inv.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv.GroupSummary["vatvalue"])) - Convert.ToDouble(gvs_inv.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv.GroupSummary["vatvalue"]));
            //        e.TotalValue = vatvalue;
            //        e.TotalValueReady = true;

            //        break;
            //}
        }

        protected void gv_empsalaryvar_DataBinding(object sender, EventArgs e)
        {
            gv_empsalaryvar.DataSource = GvdetailSource();
        }
    }
}