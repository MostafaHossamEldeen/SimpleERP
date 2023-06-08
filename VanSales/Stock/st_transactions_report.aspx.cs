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
    public partial class st_transactions_report : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {

            pageid = "66";

            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_teanstype, "compid,table_name", "6,sys_fillcomp", "citemid", "citemname");
               // Util.GenerateCombobox("sys_fillcomp_sel", cmb_naturetran, "compid,table_name", "7,sys_fillcomp", "citemid", "citemname");
              
                cmb_branchid.SelectedIndex = -1;
                cmb_naturetran.SelectedIndex = -1;
                cmb_teanstype.SelectedIndex = -1;
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
            if (cmb_naturetran.Value == null)
            {
                cmb_naturetran.Value = 0;
                cmb_naturetran.Text = null;
            }
            if (cmb_teanstype.Value == null)
            {
                cmb_teanstype.Value = 0;
                cmb_teanstype.Text = null;
            }

            if (chk_post_stock.Value == null)
                chk_post_stock.Value = 0;            
            if (chk_post_all.Value == null)
                chk_post_all.Value = 0;





            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("branchid", cmb_branchid.Value);
            dict.Add("postst", chk_post_stock.Value);          
            dict.Add("postall", chk_post_all.Value);
            dict.Add("fromdate", txt_fromdate.Date);
            dict.Add("todate", txt_todate.Date);
            dict.Add("naturetran", cmb_naturetran.Value);
            dict.Add("teanstype", cmb_teanstype.Value);
       


            return SqlCommandHelper.ExcecuteToDataTable("st_transactions_sel_report", dict, false).dataTable;
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
                    if (editor.ID == "chk_post_stock"  || editor.ID == "chk_post_all")
                    {
                        continue;
                    }

                    editor.Value = chk_all.Value;
                    if (editor.ID != "chk_all")
                    {
                        string[] coulms = editor.ID.Split('_');
                        gvs_trans_itms.Columns[coulms[1]].Visible = editor.Checked;
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
            if (cmb_naturetran.Value == null)
            {
                title += "نوع الاذن ";
                title += "الكل";
            }
            else
            {
                title += "نوع الاذن ";
                title += cmb_naturetran.Text;
            }
            return title;
        }
        protected void btn_preview_Click(object sender, EventArgs e)
        {
            try
            {
                gvs_trans_itms.DataBind();
                gvs_trans_itms.ExpandAll();
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            if (gvs_trans_itms.VisibleColumns.Count > 8)
            {
                string error_msg = "لا يمكن طباعة التقرير بأكثر من 8 أعمدة";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                return;
            }
            else if (gvs_trans_itms.VisibleColumns.Count < 1)
            {
                string error_msg = "لا توجد أي بيانات ليتم طباعة التقرير";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                return;
            }
            else
            {

                gvs_trans_itms.Columns["transtypename"].Visible = true;
                gvs_trans_itms.Columns["transtypename"].Caption = "نوع الحركة";
                gvs_trans_itms.DataColumns["transtypename"].GroupIndex = -1;
                gvs_trans_itms.DataBind();
                gvs_trans_itms.ExpandAll();
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
                int AddCount = 0;
                int ExchangeCount = 0;
                int TotalCount = 0;
                decimal AddQty = 0;
                decimal ExchangeQty = 0;
                decimal TotalQty = 0;
                decimal AddValue = 0;
                decimal ExchangeValue = 0;
                decimal TotalValue = 0;
                var s = gvs_trans_itms.VisibleRowCount;
                DataTable reptb = new DataTable();
                foreach (GridViewDataColumn item in gvs_trans_itms.VisibleColumns)
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
                    var ggd = gvs_trans_itms.GetDataRow(i);
                    reptb.ImportRow(ggd);
                    if (reptb.Columns.Contains("trandate"))
                    {
                        var newdate = Convert.ToDateTime(ggd.ItemArray.GetValue(14)).ToString("yyyy-MM-dd");
                        reptb.Rows[i]["trandate"] = newdate;
                    }
                    if (ggd.ItemArray.GetValue(8).ToString() == "اضافه")
                    {
                        AddCount = AddCount + 1;
                        AddQty = AddQty + Convert.ToDecimal(EmaxGlobals.NullToZeroDouble(ggd.ItemArray.GetValue(4)));
                        AddValue = AddValue + Convert.ToDecimal(EmaxGlobals.NullToZeroDouble(ggd.ItemArray.GetValue(6)));
                        
                    }
                    else if (ggd.ItemArray.GetValue(8).ToString().ToString() == "صرف")
                    {
                        ExchangeCount = ExchangeCount + 1;
                        ExchangeQty = ExchangeQty + Convert.ToDecimal(EmaxGlobals.NullToZeroDouble(ggd.ItemArray.GetValue(4)));
                        ExchangeValue = ExchangeValue + Convert.ToDecimal(EmaxGlobals.NullToZeroDouble(ggd.ItemArray.GetValue(6)));
                    }
                }
                if (cmb_teanstype.Text == "اضافه")
                {
                    TotalCount = AddCount + ExchangeCount;
                    TotalQty = AddQty - ExchangeQty;
                    TotalValue = AddValue - ExchangeValue;
                }
                else if(cmb_teanstype.Text == "صرف")
                {
                    TotalCount = ExchangeCount;
                    TotalQty = ExchangeQty;
                    TotalValue = ExchangeValue;
                }
                else
                {
                    TotalCount = AddCount + ExchangeCount;
                    TotalQty = AddQty - ExchangeQty;
                    TotalValue = AddValue - ExchangeValue;
                }

                dict.Add("AddCount", AddCount);
                dict.Add("AddQty", AddQty);
                dict.Add("AddValue", AddValue);
                dict.Add("ExchangeCount", ExchangeCount);
                dict.Add("ExchangeQty", ExchangeQty);
                dict.Add("ExchangeValue", ExchangeValue);
                dict.Add("TotalCount", TotalCount);
                dict.Add("TotalQty", TotalQty);
                dict.Add("TotalValue", TotalValue);
                

                if (cmb_branchid.Value == null)
                {
                    cmb_branchid.Value = 0;
                    cmb_branchid.Text = null;
                }
                if (chk_post_stock.Value == null)
                    chk_post_stock.Value = false;
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
                dict.Add("postall", chk_post_all.Value);
                dict.Add("fromdate", txt_fromdate.Date);
                dict.Add("todate", txt_todate.Date);
                dict.Add("teanstype", cmb_teanstype.Text);
                dict.Add("naturetran", cmb_naturetran.Text);

                gvs_trans_itms.Columns["transtypename"].Visible = false;
                gvs_trans_itms.Columns["transtypename"].Caption = " ";
                gvs_trans_itms.DataColumns["transtypename"].GroupIndex = 0;
                PrintPage("Stock/st_transactions_report.repx", reptb, dict);
            }
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            cmb_branchid.Value = null;
            cmb_naturetran.Value = null;
            txt_fromdate.Date = DateTime.Now;
            txt_todate.Date = DateTime.Now;
            
            gvs_trans_itms.FilterExpression = "";
            gvs_trans_itms.DataBind();
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {

                // gvitemsExporter.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType=ExportType.WYSIWYG});
                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير حركات اصناف المخزون", 1, Request.GetOwinContext().Request.User.Identity.Name, gvs_trans_itms.GetSelectedFieldValues("transdtlid").Count != 0, false, "تقرير حركات اصناف المخزون", Title());
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


                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير حركات اصناف المخزون", 0, Request.GetOwinContext().Request.User.Identity.Name, gvs_trans_itms.GetSelectedFieldValues("transdtlid").Count != 0, false, "تقرير حركات اصناف المخزون", Title());
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
                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير حركات اصناف المخزون", 2, Request.GetOwinContext().Request.User.Identity.Name, gvs_trans_itms.GetSelectedFieldValues("transdtlid").Count != 0, false, "تقرير حركات اصناف المخزون" ,Title());
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void chk_post_stock_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_post_all.Checked)
            {
                
                chk_post_stock.Checked = false;
            }
            else if (chk_post_stock.Checked)
            {
                chk_post_all.Checked = false;
            }
            
        }

        protected void chk_itemcode_CheckedChanged(object sender, EventArgs e)
        {
            var test = sender as ASPxCheckBox;
            string[] coulms = test.ID.Split('_');
            gvs_trans_itms.Columns[coulms[1]].Visible = test.Checked;
        }

        protected void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            LoopcheckBoxes();
        }

        protected void gvs_trans_itms_DataBinding(object sender, EventArgs e)
        {
            gvs_trans_itms.DataSource = GvdetailSource();
        }

        protected void gvs_trans_itms_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            ASPxSummaryItem summary = e.Item as ASPxSummaryItem;
            switch (summary.FieldName)
            {
                case "qty":
                    double qty = 0;
                    qty = Convert.ToDouble(gvs_trans_itms.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_trans_itms.GroupSummary["qty"])) - Convert.ToDouble(gvs_trans_itms.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_trans_itms.GroupSummary["qty"]));
                    e.TotalValue = qty;
                    e.TotalValueReady = true;

                    break;
                case "value":
                    double value = 0;
                    value = Convert.ToDouble(gvs_trans_itms.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_trans_itms.GroupSummary["value"])) - Convert.ToDouble(gvs_trans_itms.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_trans_itms.GroupSummary["value"]));
                    e.TotalValue = value;
                    e.TotalValueReady = true;

                    break;
   
            }
        }

        protected void cmb_teanstype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_teanstype.Value == null)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_naturetran, "compid,table_name", "-1,sys_fillcomp", "citemid", "citemname");
                cmb_naturetran.Value = null;
                cmb_naturetran.SelectedIndex = -1;
            }

           else if (cmb_teanstype.Value.ToString() == "1")
            {

                cmb_naturetran.Value = null;
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_naturetran, "compid,table_name", "7,sys_fillcomp", "citemid", "citemname");
                cmb_naturetran.SelectedIndex = -1;
                cmb_naturetran.ClearButton.DisplayMode = ClearButtonDisplayMode.Always;
            }
            else if (cmb_teanstype.Value.ToString() == "-1")
            {
                cmb_naturetran.Value = null;
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_naturetran, "compid,table_name", "8,sys_fillcomp", "citemid", "citemname");
                cmb_naturetran.SelectedIndex = -1;
                cmb_naturetran.ClearButton.DisplayMode = ClearButtonDisplayMode.Always;
            }
        
        }
    }
}