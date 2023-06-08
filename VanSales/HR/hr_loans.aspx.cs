using Emax.SharedLib;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.HR
{
    public partial class hr_loans : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "44";
            base.OnInit(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_ltype, "compid,table_name", "22,sys_fillcomp", "citemid", "citemname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_lnature, "compid,table_name,model", "23,lnature," + Convert.ToString(cmb_ltype.SelectedItem.Value) + "", "citemid", "citemname");
                txt_loandate.Date = DateTime.Now;
            }
        }
        void clear()
        {

            txt_empid.Text = string.Empty;
            txt_empname.Text = string.Empty;
            txt_lvalue.Text = "1";
            txt_loanno.Text = string.Empty;
            txt_loanno.Text = "تلقائى";
            txt_loandate.Date = DateTime.Now;

            cmb_ltype.Text = string.Empty;
            cmb_ltype.Text = string.Empty;
            cmb_ltype.SelectedIndex = 0;
            HF_lnature.Value = string.Empty;
            cmb_lnature.Text = string.Empty;
            cmb_lnature.Text = string.Empty;
            cmb_lnature.SelectedIndex = 0;

            txt_loannotes.Text = string.Empty;
            ch_salarydeduct.Checked = false;
            txt_chartid.Text = string.Empty;
            txt_chartname.Text = string.Empty;
            HF_lcrditcahrtid.Value= string.Empty;
            HF_empid.Value = string.Empty;
            HF_loanid.Value = string.Empty;
            Util.GenerateCombobox("sys_fillcomp_sel", cmb_lnature, "compid,table_name,model", "23,lnature," + Convert.ToString(cmb_ltype.SelectedItem.Value) + "", "citemid", "citemname");

        }
        List<object> GetParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_loanid.Value) == 0)
            {
                return new List<object> { cmb_ltype, txt_loandate, HF_empid, txt_empname, HF_lcrditcahrtid, txt_lvalue, cmb_lnature,ch_salarydeduct,txt_loannotes };
            }
            else
            {
                return new List<object> { cmb_ltype, txt_loandate, HF_empid, txt_empname, HF_lcrditcahrtid, txt_lvalue, cmb_lnature, ch_salarydeduct, txt_loannotes, HF_loanid };
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                var res = SaveData(EmaxGlobals.NullToIntZero(HF_loanid.Value) == 0 ? "hr_loans_ins" : "hr_loans_upd"
        , GetParam(), null,
                EmaxGlobals.NullToIntZero(HF_loanid.Value) == 0 ? new List<string>() { "loannomax", "id" } : new List<string>() { }, true, true,
                new List<ParamObject>() { new ParamObject() { ParamName = "lnaturename", ParamValue =cmb_lnature }
                ,new ParamObject() { ParamName = "ltypename", ParamValue = cmb_ltype }});
                if (res.errorid == 0)
                {


                    if (EmaxGlobals.NullToIntZero(HF_loanid.Value) != 0)
                    {

                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                    }
                    else
                    {
                        HF_loanid.Value = res.outputparams != null && res.outputparams.Count > 0 ? EmaxGlobals.NullToEmpty(res.outputparams["id"]) : "";
                       
                        txt_loanno.Text = res.outputparams.ContainsKey("loannomax") ? EmaxGlobals.NullToEmpty(res.outputparams["loannomax"].ToString()) : "";

                        string msg = "تم الحفظ بنجاح";

                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + msg + "');", true);

                    }
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

        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {

        }

        protected void cmb_ltype_ValueChanged(object sender, EventArgs e)
        {
            Util.GenerateCombobox("sys_fillcomp_sel", cmb_lnature, "compid,table_name,model", "23,lnature," + Convert.ToString(cmb_ltype.SelectedItem.Value) + "", "citemid", "citemname");
        }

        protected void cmb_lnature_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
             Util.GenerateCombobox("sys_fillcomp_sel", cmb_lnature, "compid,table_name,model", "23,lnature," + Convert.ToString(cmb_ltype.SelectedItem.Value) + "", "citemid", "citemname");
            if (EmaxGlobals.NullToEmpty( HF_lnature.Value) != "")
            {
                cmb_lnature.Value = HF_lnature.Value;
                HF_lnature.Value = string.Empty;
            }
        }
    }
}