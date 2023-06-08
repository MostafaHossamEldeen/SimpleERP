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

namespace VanSales.Sales
{
    public partial class inv_pay_report : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {

            pageid = "52";

            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                // Util.GenerateCombobox("sys_fillcomp_sel", cmb_smanid, "compid,table_name", "0,s_sman", "smanid", "smanname");
                cmb_branchid.SelectedIndex = -1;
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




            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("branchid", cmb_branchid.Value);
            dict.Add("fromdate", txt_fromdate.Date);
            dict.Add("todate", txt_todate.Date);
            // dict.Add("smanid", HF_smanid.Value);
            dict.Add("cusid", HF_cusid.Value);


            return SqlCommandHelper.ExcecuteToDataTable("s_invpay_sel_report", dict, false).dataTable;
        }
        private void LoopcheckBoxes()
        {

            foreach (var item in FormLayoutcol.Items)
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
                    if (editor.ID == "chk_post_all")
                    {
                        continue;
                    }

                    editor.Value = chk_all.Value;
                    if (editor.ID != "chk_all")
                    {
                        string[] coulms = editor.ID.Split('_');
                        gvs_inv_pay.Columns[coulms[1]].Visible = editor.Checked;
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
            if (txt_custname.Text != "")
            {
                title += " " + "العميل: " + txt_custname.Text;

            }
            //if (txt_smanid.Text != "")
            //{
            //    title += " " + "المندوب: " + txt_smanid.Text;

            //}
            return title;
        }
        protected void btn_Review_Click(object sender, EventArgs e)
        {
            try
            {
                gvs_inv_pay.DataBind();
                gvs_inv_pay.ExpandAll();
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
                gvs_inv_pay.Columns["snaturename"].Visible = true;
                gvs_inv_pay.Columns["snaturename"].Caption = "طبيعة الفاتورة";
                gvs_inv_pay.DataColumns["snaturename"].GroupIndex = -1;
                gvs_inv_pay.DataBind();
                gvs_inv_pay.ExpandAll();
                
               
                Dictionary<string, object> dict = new Dictionary<string, object>();
                int invpayname = 0;
                int rtnpayname = 0;
                int total = 0;
                decimal invpayvalue = 0;
                decimal rtnpayvalue = 0;
                decimal totalvalue = 0;
                var s = gvs_inv_pay.VisibleRowCount;
                DataTable reptb = new DataTable();
            foreach (GridViewDataColumn item in gvs_inv_pay.Columns)
            {
                reptb.Columns.Add(item.FieldName);
            }
            for (int i = 0; i < s; i++)
                {
                    var ggd = gvs_inv_pay.GetDataRow(i);
                    reptb.ImportRow(ggd);
                    if (reptb.Columns.Contains("invdate"))
                    {
                        var newdate = Convert.ToDateTime(ggd.ItemArray.GetValue(10)).ToString("yyyy-MM-dd");
                        reptb.Rows[i]["invdate"] = newdate;
                    }
                    if (ggd.ItemArray.GetValue(6).ToString() == "فاتوره مبيعات")
                    {
                        invpayname = invpayname + 1;
                        invpayvalue = invpayvalue + Convert.ToDecimal(EmaxGlobals.NullToZeroDouble(ggd.ItemArray.GetValue(2)));

                    }
                    else if (ggd.ItemArray.GetValue(6).ToString().ToString() == "مرتجع مبيعات")
                    {
                        rtnpayname = rtnpayname + 1;
                        rtnpayvalue = rtnpayvalue + Convert.ToDecimal(EmaxGlobals.NullToZeroDouble(ggd.ItemArray.GetValue(2)));
                    }
                }
                    total = invpayname + rtnpayname;
                    totalvalue = invpayvalue - rtnpayvalue;
               
                dict.Add("invpayname", invpayname);
                dict.Add("rtnpayname", rtnpayname);
                dict.Add("invpayvalue", invpayvalue);
                dict.Add("rtnpayvalue", rtnpayvalue);
                dict.Add("total", total);
                dict.Add("totalvalue", totalvalue);
            string branchname;

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
                dict.Add("custname", txt_custname.Text);
                gvs_inv_pay.Columns["snaturename"].Visible = false;
                gvs_inv_pay.Columns["snaturename"].Caption = " ";
                gvs_inv_pay.DataColumns["snaturename"].GroupIndex = 0;
                PrintPage("Sales/inv_pay_report.repx", reptb, dict);
            
        }

        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            cmb_branchid.Value = null;

            txt_fromdate.Date = DateTime.Now;
            txt_todate.Date = DateTime.Now;
            // HF_smanid.Value = null;
            HF_cusid.Value = null;
            //  txt_smanid.Text = string.Empty;
            txt_custname.Text = string.Empty;
            gvs_inv_pay.FilterExpression = "";
            gvs_inv_pay.DataBind();
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {

                 
                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير طرف دفع المبعات", 1, Request.GetOwinContext().Request.User.Identity.Name, gvs_inv_pay.GetSelectedFieldValues("invdtlid").Count != 0, false, "تقرير طرف دفع المبيعات" , Title());
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


                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير طرف دفع المبعات", 0, Request.GetOwinContext().Request.User.Identity.Name, gvs_inv_pay.GetSelectedFieldValues("invdtlid").Count != 0, false, "تقرير طرف دفع المبيعات" ,Title());
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
                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير طرف دفع المبعات", 2, Request.GetOwinContext().Request.User.Identity.Name, gvs_inv_pay.GetSelectedFieldValues("invdtlid").Count != 0, false,  "تقرير طرف دفع المبيعات", Title());
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void gvs_inv_pay_DataBinding(object sender, EventArgs e)
        {
            gvs_inv_pay.DataSource = GvdetailSource();
        }

        protected void gvs_inv_pay_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            ASPxSummaryItem summary = e.Item as ASPxSummaryItem;
            switch (summary.FieldName)
            {
                case "payvalue":
                    double payvalue = 0;
                    payvalue = Convert.ToDouble(gvs_inv_pay.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv_pay.GroupSummary["payvalue"])) - Convert.ToDouble(gvs_inv_pay.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv_pay.GroupSummary["payvalue"]));
                    e.TotalValue = payvalue;
                    e.TotalValueReady = true;

                    break;
            }
        }

        protected void chk_payname_CheckedChanged(object sender, EventArgs e)
        {
            var test = sender as ASPxCheckBox;
            string[] coulms = test.ID.Split('_');
            gvs_inv_pay.Columns[coulms[1]].Visible = test.Checked;
        }

        protected void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            LoopcheckBoxes();
        }
    }
}