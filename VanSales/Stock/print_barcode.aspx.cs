using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.Stock
{
    public partial class print_barcode : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "73";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_labelsize, "compid,table_name", "30,sys_fillcomp", "citemid", "citemname");
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                int printcount = Convert.ToInt32(txt_qty.Text);
                if (Convert.ToInt32(cmb_labelsize.SelectedItem.Value) == 0)
                {
                    var dict = new Dictionary<string, object>();
                    dict.Add("itemunitid", HF_itemunitid.Value);
                    //dict.Add("qty", txt_qty.Text);
                    PrintPageDirect("Stock/itembarcode1.repx", dict,printcount);
                }
                else if (Convert.ToInt32(cmb_labelsize.SelectedItem.Value) == 1)
                {
                    var dict = new Dictionary<string, object>();
                    dict.Add("itemunitid", HF_itemunitid.Value);
                    //dict.Add("qty", txt_qty.Text);
                    
                    PrintPageDirect("Stock/itembarcode2.repx", dict,printcount);
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + ex + "+')", true);
            }
        }
    }
}