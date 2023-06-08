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
    public partial class total_inv_pay : EmaxBasepage
    {

        protected override void OnInit(EventArgs e)
        {

            pageid = "57";

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
          //  dict.Add("cusid", HF_cusid.Value);


            return SqlCommandHelper.ExcecuteToDataTable("s_inv_paytotal_sel_report", dict, false).dataTable;
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

                string branchname;
                int cellno = 0;
                int payname;
                decimal sinv;
                decimal rtninv;
                decimal total;
                payname = Convert.ToInt32(gvs_inv_pay.GetTotalSummaryValue((ASPxSummaryItem)gvs_inv_pay.TotalSummary["payname"]));
                sinv = Convert.ToDecimal(gvs_inv_pay.GetTotalSummaryValue((ASPxSummaryItem)gvs_inv_pay.TotalSummary["sinv"]));
                rtninv = Convert.ToDecimal(gvs_inv_pay.GetTotalSummaryValue((ASPxSummaryItem)gvs_inv_pay.TotalSummary["rtninv"]));
                total = Convert.ToDecimal(gvs_inv_pay.GetTotalSummaryValue((ASPxSummaryItem)gvs_inv_pay.TotalSummary["total"]));


            Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("cell1hide", false);
                dict.Add("cell2hide", false);
                dict.Add("cell3hide", false);
                dict.Add("cell4hide", false);
               
                dict.Add("cell1caption", null);
                dict.Add("cell2caption", null);
                dict.Add("cell3caption", null);
                dict.Add("cell4caption", null);
                
                dict.Add("cell1value", null);
                dict.Add("cell2value", null);
                dict.Add("cell3value", null);
                dict.Add("cell4value", null);

                dict.Add("payname", payname);
                dict.Add("sinv", sinv);
                dict.Add("rtninv", rtninv);
                dict.Add("total", total);

            var s = gvs_inv_pay.VisibleRowCount;
                DataTable reptb = new DataTable();
                foreach (GridViewDataColumn item in gvs_inv_pay.VisibleColumns)
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
                    var ggd = gvs_inv_pay.GetDataRow(i);
                    reptb.ImportRow(ggd);
                }
                
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
               
                //gvs_inv_pay.Columns["snaturename"].Visible = false;
                //gvs_inv_pay.Columns["snaturename"].Caption = " ";
                //gvs_inv_pay.DataColumns["snaturename"].GroupIndex = 0;
                PrintPage("Sales/total_inv_pay.repx", reptb, dict);
        }

        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            cmb_branchid.Value = null;

            txt_fromdate.Date = DateTime.Now;
            txt_todate.Date = DateTime.Now;
        
        
            gvs_inv_pay.FilterExpression = "";
            gvs_inv_pay.DataBind();
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {

                // gvitemsExporter.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType=ExportType.WYSIWYG});
                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير اجمالى طرق دفع المبيعات", 1, Request.GetOwinContext().Request.User.Identity.Name, gvs_inv_pay.GetSelectedFieldValues("invdtlid").Count != 0, false, "تقرير اجمالى طرق دفع المبيعات", Title());
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


                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير اجمالى طرق دفع المبيعات", 0, Request.GetOwinContext().Request.User.Identity.Name, gvs_inv_pay.GetSelectedFieldValues("invdtlid").Count != 0, false, "تقرير اجمالى طرق دفع المبيعات", Title());
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
                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير اجمالى طرق دفع المبيعات", 2, Request.GetOwinContext().Request.User.Identity.Name, gvs_inv_pay.GetSelectedFieldValues("invdtlid").Count != 0, false, "تقرير اجمالى طرق دفع المبيعات", Title());
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
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

        protected void gvs_inv_pay_DataBinding(object sender, EventArgs e)
        {
            gvs_inv_pay.DataSource = GvdetailSource();
        }

   

    
    }
}