
using Emax.Dal;
using Emax.SharedLib;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.Sys
{
    public partial class sys_settings : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "30";
            base.OnInit(e);
        }
        void bind()
        {
            var res = SqlCommandHelper.ExcecuteToDataTable("sys_setting_sel").dataTable;
            txt_chartlvl.Text =EmaxGlobals.NullToEmpty( res.Rows[0]["chartlvl"]);
            txt_vat.Text= EmaxGlobals.NullToEmpty(res.Rows[0]["vat"]);
            cmb_vattype.Value= EmaxGlobals.NullToEmpty(res.Rows[0]["vattype"]);
            cmb_costcalc.Text= EmaxGlobals.NullToEmpty(res.Rows[0]["costname"]);
            cmb_costcalc.Value= EmaxGlobals.NullToEmpty(res.Rows[0]["costcalc"]);
            chk_allowing.Checked = EmaxGlobals.NullToBool(res.Rows[0]["allowing"]);
            chk_autoemp.Checked = EmaxGlobals.NullToBool(res.Rows[0]["autoemp"]);
            chk_autoitem.Checked= EmaxGlobals.NullToBool(res.Rows[0]["autoitem"]);
            txt_printno.Text= EmaxGlobals.NullToEmpty(res.Rows[0]["printno"]);
            chk_sprice.Checked = EmaxGlobals.NullToBool(res.Rows[0]["sprice"]);
            rbl_wpitem.Value = EmaxGlobals.NullToEmpty(res.Rows[0]["wpitem"]);
            txt_wpitemdigit.Text = EmaxGlobals.NullToEmpty(res.Rows[0]["wpitemdigit"]);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_vattype, "compid,table_name", "3,sys_fillcomp", "citemid", "citemname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_costcalc, "compid,table_name", "19,sys_fillcomp", "citemid", "citemname");
                bind();
            }
        }
        List<object> GetParam()
        {
            return new List<object> { txt_chartlvl, txt_vat, cmb_vattype, chk_allowing, cmb_costcalc, chk_autoemp, chk_autoitem , txt_printno , chk_sprice , rbl_wpitem , txt_wpitemdigit };
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {

                var res = SaveData("sys_setting_upd", GetParam(), null,null, true, false,new List<ParamObject>() { new ParamObject() { ParamName = "costname", ParamValue = cmb_costcalc } });
                if (res.errorid == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('تم تحديث البيانات')", true);
                    Response.Redirect("~/logout.aspx");
                }
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                if (msg == "Input string was not in a correct format.")
                    msg = "برجاء التأكد من البيانات المدخله";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
            }
        }

        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}