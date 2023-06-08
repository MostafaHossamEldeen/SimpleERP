using DevExpress.Web;
using Emax.Dal;
using Emax.SharedLib;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Web.UI;

namespace VanSales.HR
{
    public partial class hr_salaryprep : EmaxBasepage
    {
        public ButtonRenderMode Secondary { get; private set; }

        protected override void OnInit(EventArgs e)
        {
            pageid = "48";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txt_userprep.Text = Context.User.Identity.Name;
                Util.GenerateCombobox("hr_monthyear_sel_salaryprep", cmb_monyrid, "monyrid", "monyrname");
                Util.GenerateCombobox("sys_branch_sel", cmb_branchid, "", "", "branchid", "branchname");
                Util.GenerateCombobox("hr_masterfiles_sel", cmb_nationid, "masterid", "1", "mitemid", "mitemname");
                Util.GenerateCombobox("hr_masterfiles_sel", cmb_jobid, "masterid", "2", "mitemid", "mitemname");
                Util.GenerateCombobox("sys_costcenter_sel", cmb_ccid, "", "", "ccid", "ccname");
                cmb_branchid.SelectedIndex = -1;
                cmb_monyrid.SelectedIndex = -1;
                cmb_nationid.SelectedIndex = -1;
                cmb_jobid.SelectedIndex = -1;
                cmb_ccid.SelectedIndex = -1;
                txt_sprepdate.Date = DateTime.Now;
            }
        }
        void enable()
        {
            btn_Save.Enabled = true;
            btn_Save.CssClass = "enable";

            btn_delete.Enabled = true;
            btn_delete.CssClass = "enable";

            btn_prep.Enabled = true;
            btn_prep.CssClass = "enable";

            btn_postacc.Enabled = true;
            btn_postacc.CssClass = "enable";
        }
        void disable()
        {
            btn_Save.Enabled = false;
            btn_Save.CssClass = "disable";
            btn_Save.RenderMode = Secondary;

            btn_delete.Enabled = false;
            btn_delete.CssClass = "disable";
            btn_delete.RenderMode = Secondary;

            btn_prep.Enabled = false;
            btn_prep.CssClass = "disable";
            btn_prep.RenderMode = Secondary;

            btn_postacc.Enabled = false;
            btn_postacc.CssClass = "disable";
            btn_postacc.RenderMode = Secondary;
        }
        List<object> getparam()
        {
            if (EmaxGlobals.NullToIntZero(HF_sprepid.Value) == 0)
            {
                return new List<object>
                {txt_sprepno,cmb_monyrid,cmb_branchid,txt_userprep,txt_vchrid,txt_sprepnotes,txt_sprepdate};
            }
            else
            {
                return new List<object>
                { HF_sprepid,txt_sprepno,cmb_monyrid,cmb_branchid,txt_userprep,txt_vchrid,txt_sprepnotes,txt_sprepdate};
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            var res = SaveData(EmaxGlobals.NullToIntZero(HF_sprepid.Value) == 0 ? "hr_salaryprep_ins" : "hr_salaryprep_upd", getparam(), null,
                  EmaxGlobals.NullToIntZero(HF_sprepid.Value) == 0 ? new List<string>() { "sprepid", "sprepno" } : null,
                  true, true,
                  new List<ParamObject>() { new ParamObject() { ParamName = "monyrname", ParamValue = cmb_monyrid }, new ParamObject() { ParamName = "branchname", ParamValue = cmb_branchid } });
            if (res.errorid == 0)
            {
                if (res.outputparams != null && res.outputparams.Count > 0)
                {
                    HF_sprepid.Value = EmaxGlobals.NullToEmpty(res.outputparams["sprepid"]);
                    txt_sprepno.Text = EmaxGlobals.NullToEmpty(res.outputparams["sprepno"]);
                }
                cmb_monyrid.ClientReadOnly = true;
                cmb_branchid.ClientReadOnly = true;
                txt_sprepdate.ClientReadOnly = true;
                PDetiles.Style.Add("display", "block");
                PEmpIns.Style.Add("display", "block");
                gvhr_salarydtls.DataBind();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('تم الحفظ بنجاح');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + res.errormsg + ")", true);
            }
        }
        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            cmb_monyrid.ClientReadOnly = false;
            cmb_branchid.ClientReadOnly = false;
            txt_sprepdate.ClientReadOnly = false;
            PDetiles.Style.Add("display", "none");
            PEmpIns.Style.Add("display", "none");
            txt_sprepno.Text = "تلقائي";
            cmb_monyrid.SelectedIndex = -1;
            cmb_branchid.SelectedIndex = -1;
            cmb_nationid.SelectedIndex = -1;
            cmb_jobid.SelectedIndex = -1;
            cmb_ccid.SelectedIndex = -1;
            txt_userprep.Text = Context.User.Identity.Name;
            txt_vchrid.Text = null;
            lbl_postacc.Text = null;
            txt_sprepnotes.Text = null;
            HF_sprepid.Value = null;
            hf_postacc.Value = null;
            txt_sprepdate.Date = DateTime.Now.Date;
            gvhr_salarydtls.DataBind();
            enable();
        }
        protected void gvhr_salarydtls_DataBinding(object sender, EventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("sprepid", HF_sprepid.Value);
            gvhr_salarydtls.DataSource = SqlCommandHelper.ExcecuteToDataTable("hr_salarydtls_sel", dict).dataTable;
        }
        protected void gvhr_salarydtls_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {

            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("salid", Convert.ToInt32(e.Keys[0]));
            var g = SqlCommandHelper.ExecuteNonQuery("hr_salarydtls_del", dict, true);

            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvhr_salarydtls.CancelEdit();
            }
        }

        List<object> Insemp()
        {
            if (EmaxGlobals.NullToIntZero(hf_empid.Value) != 0)
            {
                return new List<object>
                {HF_sprepid,cmb_monyrid,hf_empid,txt_sprepdate};
            }
            else
            {
                return new List<object>
                {HF_sprepid,cmb_monyrid,cmb_branchid,cmb_nationid,cmb_jobid,cmb_ccid,txt_sprepdate};
            }
        }
        protected void btn_userins_Click(object sender, EventArgs e)
        {
            if (EmaxGlobals.NullToIntZero(HF_sprepid.Value) != 0)
            {
                var res = SaveData(EmaxGlobals.NullToIntZero(hf_empid.Value) != 0 ? "hr_salarydtls_insempsingle" : "hr_salarydtls_insemp", Insemp(), null, null, true, true,
                new List<ParamObject>() { new ParamObject() { ParamName = "monyrname", ParamValue = cmb_monyrid } });
                if (res.errorid == 0)
                {
                    cmb_nationid.SelectedIndex = -1;
                    cmb_jobid.SelectedIndex = -1;
                    cmb_ccid.SelectedIndex = -1;
                    txt_empid.Text = null;
                    txt_empname.Text = null;
                    hf_empid.Value = null;
                    cmb_monyrid.ClientReadOnly = true;
                    cmb_branchid.ClientReadOnly = true;
                    txt_sprepdate.ClientReadOnly = true;
                    PDetiles.Style.Add("display", "block");
                    PEmpIns.Style.Add("display", "block");
                    gvhr_salarydtls.DataBind();
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('تم الحفظ بنجاح');", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + res.errormsg + ")", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('لايوجد مستند إعداد للحفظ')", true);
            }
            PDetiles.Style.Add("display", "block");
            PEmpIns.Style.Add("display", "block");
            gvhr_salarydtls.DataBind();
        }
        protected void gvhr_salarydtls_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            if (hf_postacc.Value == "true")
            {
                disable();
            }
            else
            {
                enable();
            }
            gvhr_salarydtls.DataBind();
        }
        protected void btn_prep_Click(object sender, EventArgs e)
        {
            if (EmaxGlobals.NullToIntZero(HF_sprepid.Value) != 0)
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("sprepid", Convert.ToInt32(EmaxGlobals.NullToIntZero(HF_sprepid.Value)));
                var g = SqlCommandHelper.ExecuteNonQuery("hr_salarydtls_prep", dict, true);
                if (g.errorid == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('تم إعداد الوراتب بنجاح');", true);
                    PDetiles.Style.Add("display", "block");
                    PEmpIns.Style.Add("display", "block");
                    gvhr_salarydtls.DataBind();
                }
                else
                {
                    PDetiles.Style.Add("display", "block");
                    PEmpIns.Style.Add("display", "block");
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + g.errormsg + ")", true);
                }
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('لايوجد مستند لإعداد الرواتب')", true);
            }
        }
    }
}