using Emax.SharedLib;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace VanSales.HR
{
    public partial class hr_salaryvarables : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "47";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_svdate.Date = DateTime.Now.Date;
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_svtype, "compid,table_name", "24,sys_fillcomp", "citemid", "citemname");
                Util.GenerateCombobox("hr_monthyear_sel_salaryvarables", cmb_monyrid, "monyrid", "monyrname");
              Util.GenerateCombobox("svnatuleid_sel", cmb_svnatuleid, "citemtype", EmaxGlobals.NullToEmpty(cmb_svtype.Value), "citemid", "citemname"); 
            }
         
        }

        List<object> getparam()
        {
            if (EmaxGlobals.NullToIntZero(HF_svid.Value) == 0)
            {
                return new List<object>
                { txt_svno,txt_svdate,txt_svarbalename,txt_empid,txt_empname,txt_salary,txt_ratio,txt_days,txt_vvalue,txt_vnotes,cmb_svtype,cmb_svnatuleid,cmb_monyrid,ck_stopped,ck_addbsalary,HF_empid};
            }
            else
            {
                return new List<object>
                { txt_svno,txt_svdate,txt_svarbalename,txt_empid,txt_empname,txt_salary,txt_ratio,txt_days,txt_vvalue,txt_vnotes,cmb_svtype,cmb_svnatuleid,cmb_monyrid,ck_stopped,ck_addbsalary,HF_empid,HF_svid};
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            var res = SaveData(EmaxGlobals.NullToIntZero(HF_svid.Value) == 0 ? "hr_salaryvarables_ins" : "hr_salaryvarables_upd", getparam(), null,
                  EmaxGlobals.NullToIntZero(HF_svid.Value) == 0 ? new List<string>() { "svid", "svno" } : null,
                  true, true,
                  new List<ParamObject>() { new ParamObject() { ParamName = "svname", ParamValue = cmb_svtype }, new ParamObject() { ParamName = "svnaturename", ParamValue = cmb_svnatuleid },
                      new ParamObject() { ParamName = "monyrname", ParamValue = cmb_monyrid }});
            if (res.errorid == 0)
            {
                if (res.outputparams != null && res.outputparams.Count > 0)
                {
                    HF_svid.Value = EmaxGlobals.NullToEmpty(res.outputparams["svid"]);
                    txt_svno.Text = EmaxGlobals.NullToEmpty(res.outputparams["svno"]);
                }
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('تم الحفظ بنجاح');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + res.errormsg + ")", true);
            }
        }

        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            HF_empid.Value = null;
            HF_svid.Value = null;
            txt_svno.Text = "تلقائى";
            txt_svdate.Date = DateTime.Now.Date;
            txt_svarbalename.Text = null;
            txt_empid.Text = null;
            txt_empname.Text = null;
            txt_salary.Text = null;
            txt_ratio.Text = null;
            txt_days.Text = null;
            txt_vvalue.Text = null;
            txt_vnotes.Text = null;
            cmb_svtype.DataBind();
            cmb_svtype.SelectedIndex = 0;
            Util.GenerateCombobox("svnatuleid_sel", cmb_svnatuleid, "citemtype", EmaxGlobals.NullToEmpty(cmb_svtype.Value), "citemid", "citemname");
            cmb_svnatuleid.SelectedIndex = 0;
            cmb_monyrid.DataBind();
            cmb_monyrid.SelectedIndex = 0;
            ck_stopped.Value = 0;
            ck_addbsalary.Value = 0;
        }

        protected void cmb_svtype_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (string.IsNullOrEmpty(e.Parameter)) return;
            string[] param = e.Parameter.Split(',');

            Util.GenerateCombobox("svnatuleid_sel", cmb_svnatuleid, "citemtype", EmaxGlobals.NullToEmpty(cmb_svtype.Value), "citemid", "citemname");
            if (param.Length > 1)
            {
                cmb_svnatuleid.Value = param[1];
            }
        }
    }
}