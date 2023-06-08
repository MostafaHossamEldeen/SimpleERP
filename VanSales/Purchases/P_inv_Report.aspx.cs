using DevExpress.Web;
using Emax.Core.Utility;
using Emax.Dal;
using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;


namespace VanSales.Purchases
{
    public partial class P_inv_Report : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {

            pageid = "63";

            base.OnInit(e);

        }
        DataTable GvdetailSource()
        {
            if (cmb_branchid.Value == null)
            {
                cmb_branchid.Value = 0;
                cmb_branchid.Text = null;
            }

            if (chk_post_stock.Value == null)
                chk_post_stock.Value = false;
            if (chk_post_acc.Value == null)
                chk_post_acc.Value = false;
            if (chk_post_all.Value == null)
                chk_post_all.Value = false;



            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("branchid", cmb_branchid.Value);
            dict.Add("postst", chk_post_stock.Value);
            dict.Add("postacc", chk_post_acc.Value);
            dict.Add("postall", chk_post_all.Value);
            dict.Add("fromdate", txt_fromdate.Date);
            dict.Add("todate", txt_todate.Date);
            dict.Add("suppid", HF_suppid.Value);

            return SqlCommandHelper.ExcecuteToDataTable("p_inv_sel_report", dict, false).dataTable;
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
                    if (editor.ID == "chk_post_stock" || editor.ID == "chk_post_acc" || editor.ID == "chk_post_all")
                    {
                        continue;
                    }

                    editor.Value = chk_all.Value;
                    if (editor.ID != "chk_all")
                    {
                        string[] coulms = editor.ID.Split('_');
                        gvs_inv.Columns[coulms[1]].Visible = editor.Checked;
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
            if (txt_suppname.Text != "")
            {
                title += " " + "المورد: " + txt_suppname.Text;

            }

            return title;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                cmb_branchid.SelectedIndex = -1;
                txt_fromdate.Date = DateTime.Now;
                txt_todate.Date = DateTime.Now;

            }
        }

        protected void btn_preview_Click(object sender, EventArgs e)
        {
            try
            {
                gvs_inv.DataBind();
                gvs_inv.ExpandAll();
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {

            if (gvs_inv.VisibleColumns.Count > 8)
            {
                string error_msg = "لا يمكن طباعة التقرير بأكثر من 8 أعمدة";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                return;
            }
            else if (gvs_inv.VisibleColumns.Count < 1)
            {
                string error_msg = "لا توجد أي بيانات ليتم طباعة التقرير";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                return;
            }
            else
            {
                gvs_inv.Columns["pnaturename"].Visible = true;
                gvs_inv.Columns["pnaturename"].Caption = "طبيعة الفاتورة";
                gvs_inv.DataColumns["pnaturename"].GroupIndex = -1;
                gvs_inv.DataBind();
                gvs_inv.ExpandAll();
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
                int invcount = 0;
                int rtncount = 0;
                int count = 0;
                decimal total = 0;
                decimal invtotal = 0;
                decimal rtntotal = 0;
                decimal invvat = 0;
                decimal rtnvat = 0;
                decimal invnet = 0;
                decimal rtnnet = 0;
                decimal vat = 0;
                decimal net = 0;

                var s = gvs_inv.VisibleRowCount;
                DataTable reptb = new DataTable();
                foreach (GridViewDataColumn item in gvs_inv.VisibleColumns)
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
                    var ggd = gvs_inv.GetDataRow(i);
                    reptb.ImportRow(ggd);
                    if (reptb.Columns.Contains("pinvdate"))
                    {
                        var newdate = Convert.ToDateTime(ggd.ItemArray.GetValue(2)).ToString("yyyy-MM-dd");
                        reptb.Rows[i]["pinvdate"] = newdate;
                    }
                    if (ggd.ItemArray.GetValue(3).ToString() == "فاتوره مشتريات")
                    {
                        invcount = invcount+1;
                        invtotal = invtotal + Convert.ToDecimal(ggd.ItemArray.GetValue(18));
                        invvat = invvat + Convert.ToDecimal(ggd.ItemArray.GetValue(19));
                        invnet = invnet + Convert.ToDecimal(ggd.ItemArray.GetValue(20));
                    }
                    else if (ggd.ItemArray.GetValue(3).ToString().ToString() == "مرتجع مشتريات")
                    {
                        rtncount = rtncount+1;
                        rtntotal = rtntotal + Convert.ToDecimal(ggd.ItemArray.GetValue(18));
                        rtnvat = rtnvat + Convert.ToDecimal(ggd.ItemArray.GetValue(19));
                        rtnnet = rtnnet + Convert.ToDecimal(ggd.ItemArray.GetValue(20));
                    }
                }
                count = invcount + rtncount;
                total = invtotal - rtntotal;
                vat = invvat - rtnvat;
                net = invnet - rtnnet;
                dict.Add("invcount", invcount);
                dict.Add("rtncount", rtncount);
                dict.Add("invtotal", invtotal);
                dict.Add("rtntotal", rtntotal);
                dict.Add("invvat", invvat);
                dict.Add("rtnvat", rtnvat);
                dict.Add("invnet", invnet);
                dict.Add("rtnnet", rtnnet);
                dict.Add("count", count);
                dict.Add("total", total);
                dict.Add("vat", vat);
                dict.Add("net", net);
                if (cmb_branchid.Value == null)
                {
                    cmb_branchid.Value = 0;
                    cmb_branchid.Text = null;
                }
                if (chk_post_stock.Value == null)
                    chk_post_stock.Value = false;
                if (chk_post_acc.Value == null)
                    chk_post_acc.Value = false;
                if (chk_post_all.Value == null)
                    chk_post_all.Value = false;
                if (cmb_branchid.Text == null || cmb_branchid.Text == "")
                {
                    branchname = cmb_branchid.NullText;
                }
                else
                {
                    branchname = cmb_branchid.Text;
                }
                dict.Add("branchname", branchname);
                dict.Add("postst", chk_post_stock.Value);
                dict.Add("postacc", chk_post_acc.Value);
                dict.Add("postall", chk_post_all.Value);
                dict.Add("fromdate", txt_fromdate.Date);
                dict.Add("todate", txt_todate.Date);
                dict.Add("suppname", txt_suppname.Text);
                gvs_inv.Columns["pnaturename"].Visible = false;
                gvs_inv.Columns["pnaturename"].Caption = " ";
                gvs_inv.DataColumns["pnaturename"].GroupIndex = 0;
                PrintPage("Purchase/P_inv_Report.repx", reptb, dict);
            }
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            cmb_branchid.Value = null;
            chk_post_stock.Value = null;
            chk_post_acc.Value = null;
            chk_post_all.Value = null;
            HF_suppid.Value = null;
            txt_suppname.Text = string.Empty;
            gvs_inv.FilterExpression = "";
            txt_fromdate.Value = null;
            txt_todate.Value = null;
            gvs_inv.DataBind();
            txt_fromdate.Date = DateTime.Now;
            txt_todate.Date = DateTime.Now;
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {

                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير فواتير المشتريات", 1, Request.GetOwinContext().Request.User.Identity.Name, gvs_inv.GetSelectedFieldValues("pinvid").Count != 0, false, "تقرير فواتير المشتريات", Title());
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
                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير فواتير المشتريات", 0, Request.GetOwinContext().Request.User.Identity.Name, gvs_inv.GetSelectedFieldValues("pinvid").Count != 0, false, "تقرير فواتير المشتريات", Title());
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
                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير فواتير المشتريات", 2, Request.GetOwinContext().Request.User.Identity.Name, gvs_inv.GetSelectedFieldValues("pinvid").Count != 0, false, "تقرير فواتير المشتريات", Title());
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            LoopcheckBoxes();
        }

        protected void gvs_inv_DataBinding(object sender, EventArgs e)
        {
            gvs_inv.DataSource = GvdetailSource();
        }

        protected void gvs_inv_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            ASPxSummaryItem summary = e.Item as ASPxSummaryItem;
            switch (summary.FieldName)
            {
                case "netbvat":
                    double netbvat = 0;
                    netbvat = Convert.ToDouble(gvs_inv.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv.GroupSummary["netbvat"])) - Convert.ToDouble(gvs_inv.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv.GroupSummary["netbvat"]));
                    e.TotalValue = netbvat;
                    e.TotalValueReady = true;

                    break;
                case "netavat":
                    double netavat = 0;
                    netavat = Convert.ToDouble(gvs_inv.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv.GroupSummary["netavat"])) - Convert.ToDouble(gvs_inv.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv.GroupSummary["netavat"]));
                    e.TotalValue = netavat;
                    e.TotalValueReady = true;

                    break;
                case "vatvalue":
                    double vatvalue = 0;
                    vatvalue = Convert.ToDouble(gvs_inv.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv.GroupSummary["vatvalue"])) - Convert.ToDouble(gvs_inv.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv.GroupSummary["vatvalue"]));
                    e.TotalValue = vatvalue;
                    e.TotalValueReady = true;

                    break;
            }
        }

        protected void chk_pinvno_CheckedChanged(object sender, EventArgs e)
        {
            var test = sender as ASPxCheckBox;
            string[] coulms = test.ID.Split('_');
            gvs_inv.Columns[coulms[1]].Visible = test.Checked;
        }
        protected void chk_post_stock_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_post_all.Checked)
            {
                chk_post_acc.Checked = false;
                chk_post_stock.Checked = false;
            }
            else if (chk_post_stock.Checked)
            {
                chk_post_all.Checked = false;
            }
            else if (chk_post_acc.Checked)
            {
                chk_post_all.Checked = false;
            }
        }
    }
}