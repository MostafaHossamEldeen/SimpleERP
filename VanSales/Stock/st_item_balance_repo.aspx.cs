using DevExpress.Web;
using Emax.Dal;
using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;

namespace VanSales.Stock
{
    public partial class st_item_balance_repo : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "76";
            base.OnInit(e);
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
        DataTable GvdetailSource()
        {
            if (cmb_branchid.Value == null)
            {
                cmb_branchid.Value = 0;
                cmb_branchid.Text = null;
            }
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("branchid", cmb_branchid.Value);
            dict.Add("fromdate", txt_fromdate.Text);
            dict.Add("todate", txt_todate.Text);
            dict.Add("itemid", HF_itemid.Value);

            return SqlCommandHelper.ExcecuteToDataTable("st_item_balance_repo", dict, false).dataTable;
        }

        protected void btn_preview_Click(object sender, EventArgs e)
        {
            try
            {
                gv_itembalance.DataBind();
                gv_itembalance.ExpandAll();
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            gv_itembalance.Columns["branchname"].Visible = true;
            gv_itembalance.Columns["branchname"].Caption = "الفرع";
            gv_itembalance.DataColumns["branchname"].GroupIndex = -1;
            gv_itembalance.DataBind();
            gv_itembalance.ExpandAll();
            string branchname;
            int cellno = 0;
            Dictionary<string, object> dict = new Dictionary<string, object>();
            
        
            var s = gv_itembalance.VisibleRowCount;
            DataTable reptb = new DataTable();
            foreach (GridViewDataColumn item in gv_itembalance.Columns)
            {
                reptb.Columns.Add(item.FieldName);
            }
            for (int i = 0; i < s; i++)
            {
                var ggd = gv_itembalance.GetDataRow(i);
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
            dict.Add("itemcode", txt_itemcode.Text);
            dict.Add("itemname", txt_itemname.Text);

            gv_itembalance.Columns["branchname"].Visible = false;
            gv_itembalance.Columns["branchname"].Caption = " ";
            gv_itembalance.DataColumns["branchname"].GroupIndex = 0;
            PrintPage("Stock/st_item_balance_repo.repx", reptb, dict);
        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {

        }

        protected void gv_itembalance_DataBinding(object sender, EventArgs e)
        {
            gv_itembalance.DataSource = GvdetailSource();
        }
    }
}