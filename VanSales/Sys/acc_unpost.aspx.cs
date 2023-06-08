using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace VanSales.GL
{
    public partial class acc_unpost : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "74";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_typeid, "compid,table_name", "31,sys_fillcomp", "citemid", "citemname");
            }
        }

        List<object> GetParam()
        {
            return new List<object> { cmb_typeid, txt_docno};
        }
        protected void btn_btn_save_Click(object sender, EventArgs e)
        {
            var res = SaveData("acc_unpost", GetParam(), null,null,true,false,null,null);

            if (res.errorid == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess(" + res.errormsg + ")", true);
                cmb_typeid.SelectedIndex = 0;
                txt_docno.Text = null;
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + res.errormsg + ")", true);
            }

        }
    }
}