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


namespace VanSales.Stock
{
    public partial class st_analysis_report : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {

            pageid = "68";

            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox("st_group_sel", cmb_group, "", "", "groupid", "groupname");
                cmb_branchid.SelectedIndex = -1;
                cmb_group.SelectedIndex = -1;
                txt_fromdate.Date = DateTime.Now;
                txt_todate.Date = DateTime.Now;

            }
        }
        DataTable GvdetailSource()
        {
            if (cmb_branchid.Value == null)
            {
                cmb_branchid.Value = 0;
                cmb_branchid.Text = null;
            }
            if (cmb_group.Value == null)
            {
                cmb_group.Value = 0;
                cmb_group.Text = null;
            }



            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("branchid", cmb_branchid.Value);
            dict.Add("fromdate", txt_fromdate.Date);
            dict.Add("todate", txt_todate.Date);
            dict.Add("groupid", cmb_group.Value);


            return SqlCommandHelper.ExcecuteToDataTable("st_itmanalysis_sel_report", dict, false).dataTable;
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
                    //if ( editor.ID == "chk_post_all")
                    //{
                    //    continue;
                    //}

                    editor.Value = chk_all.Value;
                    if (editor.ID != "chk_all")
                    {
                        string[] coulms = editor.ID.Split('_');
                        gvs_itms.Columns[coulms[1]].Visible = editor.Checked;
                    }
                }

            }
        }
        string Title()
        {
            string title = "فرع ";
            if (cmb_branchid.Value == null)
            {
                title += "الكل";
            }
            else
            {
                title += cmb_branchid.Text;
            }
            title += " " + "الفتره من: " + txt_fromdate.Text + " " + " الى:" + txt_todate.Text;
            if (cmb_group.Value == null)
            {
                title += " مجموعه ";
                title += "الكل";
            }
            else
            {
                title += " مجموعه ";
                title += cmb_group.Text;
            }
            return title;
        }
        protected void btn_preview_Click(object sender, EventArgs e)
        {
            try
            {
                gvs_itms.DataBind();
                gvs_itms.ExpandAll();
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            if (gvs_itms.VisibleColumns.Count > 8)
            {
                string error_msg = "لا يمكن طباعة التقرير بأكثر من 8 أعمدة";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                return;
            }
            else if (gvs_itms.VisibleColumns.Count < 1)
            {
                string error_msg = "لا توجد أي بيانات ليتم طباعة التقرير";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                return;
            }
            else
            {
                int itemcode;
                decimal addQty;
                decimal issordQty;
                decimal invQty;
                decimal pinvQty;
                decimal totalvalue;
                gvs_itms.Columns["groupname"].Visible = true;
                gvs_itms.Columns["groupname"].Caption = "اصناف المجموعة";
                gvs_itms.DataColumns["groupname"].GroupIndex = -1;
                gvs_itms.DataBind();
                gvs_itms.ExpandAll();
                string branchname;
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

                

                itemcode = Convert.ToInt32(gvs_itms.GetTotalSummaryValue((ASPxSummaryItem)gvs_itms.TotalSummary["itemcode"]));
                addQty = Convert.ToDecimal(gvs_itms.GetTotalSummaryValue((ASPxSummaryItem)gvs_itms.TotalSummary["addQty"]));
                issordQty = Convert.ToDecimal(gvs_itms.GetTotalSummaryValue((ASPxSummaryItem)gvs_itms.TotalSummary["issordQty"]));
                invQty = Convert.ToDecimal(gvs_itms.GetTotalSummaryValue((ASPxSummaryItem)gvs_itms.TotalSummary["invQty"]));
                pinvQty = Convert.ToDecimal(gvs_itms.GetTotalSummaryValue((ASPxSummaryItem)gvs_itms.TotalSummary["pinvQty"]));
                totalvalue = Convert.ToDecimal(gvs_itms.GetTotalSummaryValue((ASPxSummaryItem)gvs_itms.TotalSummary["totalvalue"]));
                var s = gvs_itms.VisibleRowCount;
                DataTable reptb = new DataTable();
                foreach (GridViewDataColumn item in gvs_itms.VisibleColumns)
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
                    var ggd = gvs_itms.GetDataRow(i);
                    reptb.ImportRow(ggd);
                }
                   
                

                dict.Add("itemcode", itemcode);
                dict.Add("addQty", addQty);
                dict.Add("issordQty", issordQty);
                dict.Add("invQty", invQty);
                dict.Add("pinvQty", pinvQty);
                dict.Add("totalvalue", totalvalue);
               


                if (cmb_branchid.Value == null)
                {
                    cmb_branchid.Value = 0;
                    cmb_branchid.Text = null;
                }
                if (cmb_branchid.Text == null || cmb_branchid.Text == "")
                {
                    branchname = cmb_branchid.NullText;
                }
                else
                {
                    branchname = cmb_branchid.Text;
                }
                dict.Add("branchname", branchname);
                dict.Add("fromdate", txt_fromdate.Date);
                dict.Add("todate", txt_todate.Date);
                dict.Add("group", cmb_group.Text);

                gvs_itms.Columns["groupname"].Visible = false;
                gvs_itms.Columns["groupname"].Caption = " ";
                gvs_itms.DataColumns["groupname"].GroupIndex = 0;
                PrintPage("Stock/st_analysis_report.repx", reptb, dict);
            }
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            cmb_branchid.Value = null;

            txt_fromdate.Date = DateTime.Now;
            txt_todate.Date = DateTime.Now;
            cmb_group.Value = null;
            gvs_itms.FilterExpression = "";
            gvs_itms.DataBind();
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {

            try
            {

                // gvitemsExporter.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType=ExportType.WYSIWYG});
                ExportingDevExpressUtil.Export(gvinvExporter, "تحليل ارصده المخزون", 1, Request.GetOwinContext().Request.User.Identity.Name, gvs_itms.GetSelectedFieldValues("itemid").Count != 0, false, "تحليل ارصده المخزون", Title());
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


                ExportingDevExpressUtil.Export(gvinvExporter, "تحليل ارصده المخزون", 0, Request.GetOwinContext().Request.User.Identity.Name, gvs_itms.GetSelectedFieldValues("itemid").Count != 0, false, "تحليل ارصده المخزون", Title());
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
                ExportingDevExpressUtil.Export(gvinvExporter, "تحليل ارصده المخزون", 2, Request.GetOwinContext().Request.User.Identity.Name, gvs_itms.GetSelectedFieldValues("itemid").Count != 0, false, "تحليل ارصده المخزون", Title());
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void gvs_itms_DataBinding(object sender, EventArgs e)
        {
            gvs_itms.DataSource = GvdetailSource();
        }

        protected void gvs_itms_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            ASPxSummaryItem summary = e.Item as ASPxSummaryItem;
            switch (summary.FieldName)
            {
                case "addQty":
                    double addQty = 0;
                    addQty = Convert.ToDouble(gvs_itms.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_itms.GroupSummary["addQty"])) - Convert.ToDouble(gvs_itms.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_itms.GroupSummary["addQty"]));
                    e.TotalValue = addQty;
                    e.TotalValueReady = true;

                    break;
                case "issordQty":
                    double issordQty = 0;
                    issordQty = Convert.ToDouble(gvs_itms.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_itms.GroupSummary["issordQty"])) - Convert.ToDouble(gvs_itms.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_itms.GroupSummary["issordQty"]));
                    e.TotalValue = issordQty;
                    e.TotalValueReady = true;

                    break;
                case "invQty":
                    double invQty = 0;
                    invQty = Convert.ToDouble(gvs_itms.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_itms.GroupSummary["invQty"])) - Convert.ToDouble(gvs_itms.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_itms.GroupSummary["invQty"]));
                    e.TotalValue = invQty;
                    e.TotalValueReady = true;

                    break;
                case "pinvQty":
                    double pinvQty = 0;
                    pinvQty = Convert.ToDouble(gvs_itms.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_itms.GroupSummary["pinvQty"])) - Convert.ToDouble(gvs_itms.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_itms.GroupSummary["pinvQty"]));
                    e.TotalValue = pinvQty;
                    e.TotalValueReady = true;

                    break;

                case "totalvalue":
                    double totalvalue = 0;
                    totalvalue = Convert.ToDouble(gvs_itms.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_itms.GroupSummary["totalvalue"])) - Convert.ToDouble(gvs_itms.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_itms.GroupSummary["totalvalue"]));
                    e.TotalValue = totalvalue;
                    e.TotalValueReady = true;

                    break;
            }
        }

        protected void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            LoopcheckBoxes();
        }


        protected void chk_groupname_CheckedChanged(object sender, EventArgs e)
        {
            var test = sender as ASPxCheckBox;
            string[] coulms = test.ID.Split('_');
            gvs_itms.Columns[coulms[1]].Visible = test.Checked;
        }
    }
}