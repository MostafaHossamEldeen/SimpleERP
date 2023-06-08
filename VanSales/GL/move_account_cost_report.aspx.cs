using DevExpress.Web;
using Emax.Core.Utility;
using Emax.CoreCore;
using Emax.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.GL
{
    public partial class move_account_cost_report : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {

            pageid = "69";

            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                txt_fromdate.Date = DateTime.Now;
                txt_todate.Date = DateTime.Now;

            }
        }
        DataTable GvdetailSource()
        {
            
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("chartid",HF_chartid.Value);
            dict.Add("ccid", HF_ccid.Value);
            dict.Add("fromdate", txt_fromdate.Date);
            dict.Add("todate", txt_todate.Date);           

            return SqlCommandHelper.ExcecuteToDataTable("GL_move_account_cost_report", dict, false).dataTable;
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
                        gvs_vocher.Columns[coulms[1]].Visible = editor.Checked;
                    }
                }

            }
        }
        string Title()
        {
            string title = " حساب  ";
          
                title += txt_chartid.Text;
          
                title += " " + "مركز تكلفه : " + txt_ccname.Text;

            title += " " + "الفتره من: " + txt_fromdate.Text + " " + " الى:" + txt_todate.Text;
           
      
            return title;
        }
        protected void btn_preview_Click(object sender, EventArgs e)
        {
            try
            {
                gvs_vocher.DataBind();
                gvs_vocher.ExpandAll();
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
                if (gvs_vocher.VisibleColumns.Count > 8)
                {
                    string error_msg = "لا يمكن طباعة التقرير بأكثر من 8 أعمدة";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                    return;
                }
                else if (gvs_vocher.VisibleColumns.Count < 1)
                {
                    string error_msg = "لا توجد أي بيانات ليتم طباعة التقرير";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                    return;
                }
                else
                {


               
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

                    var s = gvs_vocher.VisibleRowCount;
                   
                    DataTable reptb = new DataTable();
                    foreach (GridViewDataColumn item in gvs_vocher.VisibleColumns)
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
                    var ggd = gvs_vocher.GetDataRow(i);
                    var newdate = Convert.ToDateTime(ggd.ItemArray.GetValue(1)).ToString("yyyy-MM-dd");
                    reptb.ImportRow(ggd);
                    reptb.Rows[i]["vchtdate"] = newdate;
                
                }

                
                dict.Add("chartname", txt_chartname.Text);
                dict.Add("ccname", txt_ccname.Text);
                dict.Add("dtefrom", txt_fromdate.Date);
                dict.Add("dteto", txt_todate.Date);
                PrintPage("GL/move_account_cost_report.repx", reptb, dict);
                

            }
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {           
            txt_fromdate.Date = DateTime.Now;
            txt_todate.Date = DateTime.Now;
            HF_chartid.Value = null;
            HF_ccid.Value = null;
            txt_chartid.Text = string.Empty;
            txt_chartname.Text = string.Empty;
            txt_ccname.Text = string.Empty;
            gvs_vocher.FilterExpression = "";
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير حركه الحسابات ومراكز التكلفه", 1, Request.GetOwinContext().Request.User.Identity.Name, gvs_vocher.GetSelectedFieldValues("vchrdtlid").Count != 0, false, "تقرير حركه الحسابات ومراكز التكلفه", Title());
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
                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير حركه الحسابات ومراكز التكلفه", 0, Request.GetOwinContext().Request.User.Identity.Name, gvs_vocher.GetSelectedFieldValues("vchrdtlid").Count != 0, false, "تقرير حركه الحسابات ومراكز التكلفه", Title());
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

                ExportingDevExpressUtil.Export(gvinvExporter, "تقرير حركه الحسابات ومراكز التكلفه", 2, Request.GetOwinContext().Request.User.Identity.Name, gvs_vocher.GetSelectedFieldValues("vchrdtlid").Count != 0, false, "تقرير حركه الحسابات ومراكز التكلفه", Title());
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void chk_chartcode_CheckedChanged(object sender, EventArgs e)
        {
            var test = sender as ASPxCheckBox;
            string[] coulms = test.ID.Split('_');
            gvs_vocher.Columns[coulms[1]].Visible = test.Checked;
        }

        protected void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            LoopcheckBoxes();
        }

        protected void gvs_vocher_DataBinding(object sender, EventArgs e)
        {
            gvs_vocher.DataSource = GvdetailSource();
        }

        protected void gvs_vocher_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            decimal total = EmaxGlobals.NullToZero(gvs_vocher.GetTotalSummaryValue((ASPxSummaryItem)gvs_vocher.TotalSummary["debit"])) - EmaxGlobals.NullToZero(gvs_vocher.GetTotalSummaryValue((ASPxSummaryItem)gvs_vocher.TotalSummary["credit"]));
            if (total < 0)
            {
                total = total * -1;

                
                e.TotalValue = total.ToString();

            }
            else if (total == 0) e.TotalValue =  total.ToString();
            else e.TotalValue =  total.ToString();
  

        }
    }
}