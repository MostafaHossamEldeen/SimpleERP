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

namespace VanSales.Purchases
{
    public partial class total_p_inv_items : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {

            pageid = "65";

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


            return SqlCommandHelper.ExcecuteToDataTable("p_invitmtotal_sel_report", dict, false).dataTable;
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
                        gvs_inv_itms.Columns[coulms[1]].Visible = editor.Checked;
                    }
                }

            }
        }
        string Title()
        {
            string title = " فرع ";
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
                title = "الكل";
            }
            else
            {
                title += " " + "مجموعه: " + cmb_group.Text;

            }

            return title;
        }
        protected void btn_preview_Click(object sender, EventArgs e)
        {
            try
            {
                gvs_inv_itms.DataBind();
                gvs_inv_itms.ExpandAll();
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            if (gvs_inv_itms.VisibleColumns.Count > 8)
            {
                string error_msg = "لا يمكن طباعة التقرير بأكثر من 8 أعمدة";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                return;
            }
            else if (gvs_inv_itms.VisibleColumns.Count < 1)
            {
                string error_msg = "لا توجد أي بيانات ليتم طباعة التقرير";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                return;
            }
            else
            {
                int itemcode;
                decimal invQty;
                decimal invvalue;
                decimal rtnQty;
                decimal rtnvalue;
                decimal totalQty;
                decimal totalvalue;
                itemcode = Convert.ToInt32(gvs_inv_itms.GetTotalSummaryValue((ASPxSummaryItem)gvs_inv_itms.TotalSummary["itemcode"]));
                invQty = Convert.ToDecimal(gvs_inv_itms.GetTotalSummaryValue((ASPxSummaryItem)gvs_inv_itms.TotalSummary["invQty"]));
                invvalue = Convert.ToDecimal(gvs_inv_itms.GetTotalSummaryValue((ASPxSummaryItem)gvs_inv_itms.TotalSummary["invvalue"]));
                rtnQty = Convert.ToDecimal(gvs_inv_itms.GetTotalSummaryValue((ASPxSummaryItem)gvs_inv_itms.TotalSummary["rtnQty"]));
                rtnvalue = Convert.ToDecimal(gvs_inv_itms.GetTotalSummaryValue((ASPxSummaryItem)gvs_inv_itms.TotalSummary["rtnvalue"]));
                totalQty = Convert.ToDecimal(gvs_inv_itms.GetTotalSummaryValue((ASPxSummaryItem)gvs_inv_itms.TotalSummary["totalQty"]));
                totalvalue = Convert.ToDecimal(gvs_inv_itms.GetTotalSummaryValue((ASPxSummaryItem)gvs_inv_itms.TotalSummary["totalvalue"]));

                gvs_inv_itms.Columns["groupname"].Visible = true;
                gvs_inv_itms.Columns["groupname"].Caption = "مجموعة الصنف";
                gvs_inv_itms.DataColumns["groupname"].GroupIndex = -1;
                gvs_inv_itms.DataBind();
                gvs_inv_itms.ExpandAll();
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

                var s = gvs_inv_itms.VisibleRowCount;
                //var col = gvs_inv.Columns;
                DataTable reptb = new DataTable();
                foreach (GridViewDataColumn item in gvs_inv_itms.VisibleColumns)
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
                    var ggd = gvs_inv_itms.GetDataRow(i);
                    //var newdate = Convert.ToDateTime(ggd.ItemArray.GetValue(2)).ToString("yyyy-MM-dd");
                    reptb.ImportRow(ggd);
                    //reptb.Rows[i]["pinvdate"] = newdate;
                }

                dict.Add("itemcode", itemcode);
                dict.Add("invQty", invQty);
                dict.Add("invvalue", invvalue);
                dict.Add("rtnQty", rtnQty);
                dict.Add("rtnvalue", rtnvalue);
                dict.Add("totalQty", totalQty);
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
                dict.Add("groupname", cmb_group.Text);
                dict.Add("fromdate", txt_fromdate.Date);
                dict.Add("todate", txt_todate.Date);
                gvs_inv_itms.Columns["groupname"].Visible = false;
                gvs_inv_itms.Columns["groupname"].Caption = " ";
                gvs_inv_itms.DataColumns["groupname"].GroupIndex = 0;
                PrintPage("Purchase/total_p_inv_items.repx", reptb, dict);
            }
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            cmb_branchid.Value = null;
            cmb_group.Value = null;
            gvs_inv_itms.FilterExpression = "";
            txt_fromdate.Value = null;
            txt_todate.Value = null;
            gvs_inv_itms.DataBind();
            txt_fromdate.Date = DateTime.Now;
            txt_todate.Date = DateTime.Now;
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {

                // gvitemsExporter.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType=ExportType.WYSIWYG});
                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير اجمالى اصناف المشتريات", 1, Request.GetOwinContext().Request.User.Identity.Name, gvs_inv_itms.GetSelectedFieldValues("invdtlid").Count != 0, false, "تقرير اجمالى اصناف المشتريات", Title());
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


                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير اجمالى اصناف المشتريات", 0, Request.GetOwinContext().Request.User.Identity.Name, gvs_inv_itms.GetSelectedFieldValues("invdtlid").Count != 0, false, "تقرير اجمالى اصناف المشتريات", Title());
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
                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير اجمالى اصناف المشتريات", 2, Request.GetOwinContext().Request.User.Identity.Name, gvs_inv_itms.GetSelectedFieldValues("invdtlid").Count != 0, false, "تقرير اجمالى اصناف المشتريات", Title());
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void chk_groupname_CheckedChanged(object sender, EventArgs e)
        {
            var test = sender as ASPxCheckBox;
            string[] coulms = test.ID.Split('_');
            gvs_inv_itms.Columns[coulms[1]].Visible = test.Checked;
        }

        protected void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            LoopcheckBoxes();
        }

        protected void gvs_inv_itms_DataBinding(object sender, EventArgs e)
        {
            gvs_inv_itms.DataSource = GvdetailSource();
        }

        protected void gvs_inv_itms_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            ASPxSummaryItem summary = e.Item as ASPxSummaryItem;
            int RowCount = Convert.ToInt32(gvs_inv_itms.GetTotalSummaryValue((ASPxSummaryItem)gvs_inv_itms.TotalSummary["itemcode"]));
            switch (summary.FieldName)
            {
                case "invQty":
                    double invQty = 0;
                    for(int Counter=0;Counter<RowCount;Counter++)
                        //invQty = Convert.ToDouble(gvs_inv_itms.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv_itms.GroupSummary["invQty"])) + Convert.ToDouble(gvs_inv_itms.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv_itms.GroupSummary["invQty"]));
                        invQty += Convert.ToDouble(gvs_inv_itms.GetGroupSummaryValue(Counter, (ASPxSummaryItem)gvs_inv_itms.GroupSummary["invQty"]));
                    e.TotalValue = invQty;
                    e.TotalValueReady = true;
                        
                    break;
                case "invvalue":
                    double invvalue = 0;
                    //invvalue = Convert.ToDouble(gvs_inv_itms.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv_itms.GroupSummary["invvalue"])) + Convert.ToDouble(gvs_inv_itms.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv_itms.GroupSummary["invvalue"]));
                    for (int Counter = 0; Counter < RowCount; Counter++)
                        invvalue += Convert.ToDouble(gvs_inv_itms.GetGroupSummaryValue(Counter, (ASPxSummaryItem)gvs_inv_itms.GroupSummary["invvalue"]));
                    e.TotalValue = invvalue;
                    e.TotalValueReady = true;

                    break;
                case "rtnQty":
                    double rtnQty = 0;
                    for (int Counter = 0; Counter < RowCount; Counter++)
                        rtnQty += Convert.ToDouble(gvs_inv_itms.GetGroupSummaryValue(Counter, (ASPxSummaryItem)gvs_inv_itms.GroupSummary["rtnQty"]));
                    //rtnQty = Convert.ToDouble(gvs_inv_itms.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv_itms.GroupSummary["rtnQty"])) - Convert.ToDouble(gvs_inv_itms.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv_itms.GroupSummary["rtnQty"]));
                    e.TotalValue = rtnQty;
                    e.TotalValueReady = true;

                    break;
                case "rtnvalue":
                    double rtnvalue = 0;
                    for (int Counter = 0; Counter < RowCount; Counter++)
                        rtnvalue += Convert.ToDouble(gvs_inv_itms.GetGroupSummaryValue(Counter, (ASPxSummaryItem)gvs_inv_itms.GroupSummary["rtnvalue"]));
                    //rtnvalue = Convert.ToDouble(gvs_inv_itms.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv_itms.GroupSummary["rtnvalue"])) - Convert.ToDouble(gvs_inv_itms.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv_itms.GroupSummary["rtnvalue"]));
                    e.TotalValue = rtnvalue;
                    e.TotalValueReady = true;

                    break;
                case "totalQty":
                    double totalQty = 0;
                    for (int Counter = 0; Counter < RowCount; Counter++)
                        totalQty += Convert.ToDouble(gvs_inv_itms.GetGroupSummaryValue(Counter, (ASPxSummaryItem)gvs_inv_itms.GroupSummary["totalQty"]));
                    //totalQty = Convert.ToDouble(gvs_inv_itms.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv_itms.GroupSummary["totalQty"])) - Convert.ToDouble(gvs_inv_itms.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv_itms.GroupSummary["totalQty"]));
                    e.TotalValue = totalQty;
                    e.TotalValueReady = true;

                    break;
                case "totalvalue":
                    double totalvalue = 0;
                    for (int Counter = 0; Counter < RowCount; Counter++)
                        totalvalue += Convert.ToDouble(gvs_inv_itms.GetGroupSummaryValue(Counter, (ASPxSummaryItem)gvs_inv_itms.GroupSummary["totalvalue"]));
                    //totalvalue = Convert.ToDouble(gvs_inv_itms.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv_itms.GroupSummary["totalvalue"])) - Convert.ToDouble(gvs_inv_itms.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv_itms.GroupSummary["totalvalue"]));
                    e.TotalValue = totalvalue;
                    e.TotalValueReady = true;

                    break;
            }
        }
    }
}