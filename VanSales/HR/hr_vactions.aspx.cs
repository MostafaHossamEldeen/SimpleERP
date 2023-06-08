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
    public partial class hr_vactions : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {            
            pageid = "43";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_vnature, "compid,table_name", "20,sys_fillcomp", "citemid", "citemname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_vapp, "compid,table_name", "21,sys_fillcomp", "citemid", "citemname");
                Util.GenerateCombobox("hr_masterfiles_sel", cmb_vnameid, "masterid", "4", "mitemcode", "mitemname");
                txt_vdate.Date = DateTime.Now;
                txt_vfromd.Date = DateTime.Now;
                txt_vtodate.Date = DateTime.Now;
                
                txt_vuser.Text = Context.User.Identity.Name;
                txt_vappuser.Text = Context.User.Identity.Name;
                cmb_vapp.ClientEnabled = false;
            }
        }
        void clear()
        {

            txt_empid.Text = string.Empty;
            txt_empname.Text = string.Empty;
            txt_vdays.Text = "1";
            txt_vno.Text = string.Empty;
            txt_vno.Text = "تلقائى";
            txt_vdate.Date= DateTime.Now;
            txt_vfromd.Date = DateTime.Now;
            txt_vtodate.Date = DateTime.Now;
           
            cmb_vnature.Text = string.Empty;
            cmb_vnature.Text = string.Empty;
            cmb_vnature.SelectedIndex = 0;
            
            cmb_vapp.Text = string.Empty;
            cmb_vapp.Text = string.Empty;
            cmb_vapp.SelectedIndex = 0;
            
            cmb_vnameid.Text = string.Empty;
            cmb_vnameid.Text = string.Empty;
            cmb_vnameid.SelectedIndex = 0;

          //  chk_vnametype.Checked = false;
            txt_vnotes.Text = string.Empty;

            rbl_vapp.SelectedIndex = -1;
            rbl_vapp.Value = string.Empty;
            HF_vid.Value = string.Empty;
            HF_empid.Value = string.Empty;
        }
        List<object> GetParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_vid.Value) == 0)
            {
                return new List<object> { cmb_vnature, txt_vdate, HF_empid, txt_empname, txt_vfromd, txt_vtodate, txt_vdays, txt_vuser, txt_vnotes, cmb_vnameid, cmb_vapp };
            }
            else
            {
                return new List<object> { cmb_vnature, txt_vdate, HF_empid, txt_empname, txt_vfromd, txt_vtodate, txt_vdays, txt_vnotes, cmb_vnameid, cmb_vapp, HF_vid };
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                var res = SaveData(EmaxGlobals.NullToIntZero(HF_vid.Value) == 0 ? "hr_vactions_ins" : "hr_vactions_upd"
        , GetParam(), null,
                EmaxGlobals.NullToIntZero(HF_vid.Value) == 0 ? new List<string>() { "vnomax", "id" } : new List<string>() { }, true, true,
                new List<ParamObject>() { new ParamObject() { ParamName = "vnaturenmae", ParamValue =cmb_vnature }
                ,new ParamObject() { ParamName = "vappname", ParamValue = cmb_vapp }
                ,new ParamObject() { ParamName = "vname", ParamValue = cmb_vnameid }});
                if (res.errorid == 0)
                {
                   
                 
                    if (EmaxGlobals.NullToIntZero(HF_vid.Value) != 0)
                    {

                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                    }
                    else
                    {
                        HF_vid.Value = res.outputparams != null && res.outputparams.Count > 0 ? EmaxGlobals.NullToEmpty(res.outputparams["id"]) : "";
                       // txt_sinvtime.Text = res.outputparams.ContainsKey("time") ? EmaxGlobals.NullToEmpty(res.outputparams["time"].ToString()) : "";
                        txt_vno.Text = res.outputparams.ContainsKey("vnomax") ? EmaxGlobals.NullToEmpty(res.outputparams["vnomax"].ToString()) : "";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
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
        List<object> updatevappParam()
        {
             
                return new List<object> { txt_vappuser, rbl_vapp, HF_vid };
        
        }
        protected void update_vapp_Click(object sender, EventArgs e)
        {
            txt_vappuser.Text = Context.User.Identity.Name;
            try
            {
                if(EmaxGlobals.NullToIntZero(HF_vid.Value) == 0 )
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('لايوجد اجازه لاعتمادها ');", true);
                    return;
                }
                var res = SaveData(EmaxGlobals.NullToIntZero(HF_vid.Value) == 0 ? "" : "hr_vactions_vapp_upd"
        , updatevappParam(), null,
                 new List<string>() { }, true, false, null);
                if (res.errorid == 0)
                {


                   // if (EmaxGlobals.NullToIntZero(HF_vid.Value) != 0)
                  //  {

                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                 //   }
                   
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
    }
}