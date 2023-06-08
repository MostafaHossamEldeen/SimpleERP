using Emax.Dal;
using Emax.SharedLib;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI;

namespace VanSales.HR
{
    public partial class hr_employees : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "41";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), this.pageid, "<script>$(function () {$('#accordion').accordion({ heightStyle: 'content'});})</script>", false);
            if (!IsPostBack)
            {
                try
                {
                    string autoitem = SqlCommandHelper.GetTokenKey("autoemp", Request.Cookies["Token"].Value);
                    if (autoitem == "False")
                    {
                        txt_empcode.Text = string.Empty;
                    }
                    Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "1,sys_branch", "branchid", "branchname");
                    Util.GenerateCombobox("sys_fillcomp_sel", cmb_ccid, "compid,table_name", "0,sys_costcenter", "ccid", "ccname");
                    Util.GenerateCombobox("hr_masterfiles_sel", cmb_nationid, "masterid", "1", "mitemid", "mitemname");
                    Util.GenerateCombobox("hr_masterfiles_sel", cmb_jobid, "masterid", "2", "mitemid", "mitemname");
                    Util.GenerateCombobox("sys_fillcomp_sel", cmb_empstatus, "compid,table_name", "27,sys_fillcomp", "citemid", "citemname");
                    Util.GenerateCombobox("sys_fillcomp_sel", cmb_paytypeid, "compid,table_name,model", "0,sys-paytype,7", "paytypeid", "paytname");
                    if (Request.QueryString["empid"] != null && Request.QueryString["empid"] != string.Empty)
                    {
                        hf_empid.Value = Request.QueryString["empid"];
                        Dictionary<object, object> dict = new Dictionary<object, object>();
                        dict.Add("empid", hf_empid.Value);
                        var f = SqlCommandHelper.ExcecuteToDataTable("hr_employees_sel_empid", dict).dataTable;
                        BindData(f.Rows[0]);
                    }
                    else if (hf_empid.Value != "0")
                    {
                        Dictionary<object, object> dict = new Dictionary<object, object>();
                        dict.Add("empid", hf_empid.Value);
                        var f = SqlCommandHelper.ExcecuteToDataTable("hr_employees_sel_empid", dict).dataTable;
                        BindData(f.Rows[0]);
                    }
                    else
                    {
                        cmb_branchid.SelectedIndex = -1;
                        cmb_ccid.SelectedIndex = -1;
                        cmb_jobid.SelectedIndex = -1;
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("There is no row at position 0") || ex.Message.Contains("لا يوجد صف في الموضع 0"))
                    {
                        Response.Redirect("~/HR/hr_employees.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('عذراً حدث خطأ غير متوقع')", true);
                    }
                }
            }
            Util.GenerateCombobox("paychart_sel", cmb_paychartid, "paytypeid,branchid", "" + EmaxGlobals.NullToEmpty(cmb_paytypeid.Value) + "," + EmaxGlobals.NullToEmpty(cmb_branchid.Value) + "", "paychartid", "paychartname");
        }

        void BindData(DataRow rec)
        {
            txt_empcode.Text = EmaxGlobals.NullToEmpty(rec["empcode"]);
            txt_empname.Text = EmaxGlobals.NullToEmpty(rec["empname"]);
            txt_empmob.Text = EmaxGlobals.NullToEmpty(rec["empmob"]);
            txt_embemail.Text = EmaxGlobals.NullToEmpty(rec["embemail"]);
            txt_empadd.Text = EmaxGlobals.NullToEmpty(rec["empadd"]);
            txt_empidno.Text = EmaxGlobals.NullToEmpty(rec["empidno"]);
            txt_empbdate.Value = rec["empbdate"];
            txt_eduname.Text = EmaxGlobals.NullToEmpty(rec["eduname"]);
            txt_empnotes.Text = EmaxGlobals.NullToEmpty(rec["empnotes"]);
            cmb_branchid.Value = EmaxGlobals.NullToIntZero(rec["branchid"]);
            cmb_branchid.Text = EmaxGlobals.NullToEmpty(rec["branchname"]);
            cmb_ccid.Value = EmaxGlobals.NullToEmpty(rec["ccid"]);
            cmb_ccid.Text = EmaxGlobals.NullToEmpty(rec["ccname"]);
            cmb_nationid.Value = EmaxGlobals.NullToEmpty(rec["nationid"]);
            cmb_nationid.Text = EmaxGlobals.NullToEmpty(rec["nationname"]);
            cmb_jobid.Value = EmaxGlobals.NullToEmpty(rec["jobid"]);
            cmb_jobid.Text = EmaxGlobals.NullToEmpty(rec["jobname"]);
            cmb_empstatus.Value = EmaxGlobals.NullToEmpty(rec["empstatus"]);
            cmb_empstatus.Text = EmaxGlobals.NullToEmpty(rec["empstatusname"]);
            txt_basicsalary.Text = EmaxGlobals.NullToEmpty(rec["basicsalary"]);
            txt_insursalary.Text = EmaxGlobals.NullToEmpty(rec["insursalary"]);
            txt_empworkdate.Value = rec["empworkdate"];
            txt_empbankname.Text = EmaxGlobals.NullToEmpty(rec["empbankname"]);
            txt_empbankid.Text = EmaxGlobals.NullToEmpty(rec["empbankid"]);
            txt_annualvaction.Text = EmaxGlobals.NullToEmpty(rec["annualvaction"]);
            txt_empchatid.Text = EmaxGlobals.NullToEmpty(rec["chartcodename"]);
            HF_empchatid.Value = EmaxGlobals.NullToEmpty(rec["empchatid"]);
            img_emppic.ImageUrl = EmaxGlobals.NullToEmpty(rec["emppic"]);
            cmb_paytypeid.Value = EmaxGlobals.NullToEmpty(rec["paytypeid"]);
            cmb_paytypeid.Text = EmaxGlobals.NullToEmpty(rec["paytypename"]);
            cmb_paychartid.Value = EmaxGlobals.NullToEmpty(rec["paychartid"]);
            cmb_paychartid.Text = EmaxGlobals.NullToEmpty(rec["paychartname"]);
        }

        protected void upd_emppic_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (!Directory.Exists(Server.MapPath("~/Img/Emp/")))
            {
                Directory.CreateDirectory(Server.MapPath("~/FImgiles/Emp/"));
            }
            if (e.IsValid)
            {
                Session["fileName"] = e.UploadedFile.FileNameInStorage;
                Session["filePath"] = "~/Img/Emp/" + Session["fileName"].ToString();
                e.UploadedFile.SaveAs(MapPath(Session["filePath"].ToString()));
            }
        }
        List<object> getparam()
        {
            if (EmaxGlobals.NullToIntZero(hf_empid.Value) == 0)
            {
                return new List<object>
                { txt_empcode,txt_empname,txt_empmob,txt_embemail,txt_empadd,txt_empidno,txt_empbdate,txt_eduname,txt_empnotes,cmb_branchid,cmb_ccid,cmb_nationid,
                cmb_jobid,cmb_empstatus,txt_basicsalary,txt_insursalary,txt_empworkdate,txt_empbankname,txt_empbankid,txt_annualvaction,HF_empchatid,img_emppic,cmb_paytypeid,cmb_paychartid};
            }
            else
            {
                return new List<object>
                { hf_empid,txt_empcode,txt_empname,txt_empmob,txt_embemail,txt_empadd,txt_empidno,txt_empbdate,txt_eduname,txt_empnotes,cmb_branchid,cmb_ccid,cmb_nationid,
                cmb_jobid,cmb_empstatus,txt_basicsalary,txt_insursalary,txt_empworkdate,txt_empbankname,txt_empbankid,txt_annualvaction,HF_empchatid,img_emppic,cmb_paytypeid,cmb_paychartid};
            }
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            Dictionary<object, object> dictother = new Dictionary<object, object>();
            dictother.Add("emppic", Session["filePath"]);
            var res = SaveData(EmaxGlobals.NullToIntZero(hf_empid.Value) == 0 ? "hr_employees_ins" : "hr_employeess_upd", getparam(), null,
                  EmaxGlobals.NullToIntZero(hf_empid.Value) == 0 ? new List<string>() { "empid", "empcodeout" } : null,
                  true, false,
                  new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue = cmb_branchid }, new ParamObject() { ParamName = "ccname", ParamValue = cmb_ccid },
                      new ParamObject() { ParamName = "nationname", ParamValue = cmb_nationid }, new ParamObject() { ParamName = "jobname", ParamValue = cmb_jobid },
                      new ParamObject() { ParamName = "empstatusname", ParamValue = cmb_empstatus },new ParamObject() { ParamName = "paytypename", ParamValue = cmb_paytypeid } },
                  dictother);
            //edit ahmed atef
            if (res.errorid == 0)
            {
                if (res.outputparams != null && res.outputparams.Count > 0)
                {
                    hf_empid.Value = EmaxGlobals.NullToEmpty(res.outputparams["empid"]);
                    txt_empcode.Text = EmaxGlobals.NullToEmpty(res.outputparams["empcodeout"])==null?"" : EmaxGlobals.NullToEmpty(res.outputparams["empcodeout"]);
                    Session.Remove("fileName");
                    Session.Remove("filePath");
                }
                else
                {
                    Session.Remove("fileName");
                    Session.Remove("filePath");
                }
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("empid", hf_empid.Value);
                var f = SqlCommandHelper.ExcecuteToDataTable("hr_employees_sel_empid", dict).dataTable;
                BindData(f.Rows[0]);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('تم الحفظ بنجاح');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + res.errormsg + ")", true);
            }

        }

        protected void cmb_paychartid_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (string.IsNullOrEmpty(e.Parameter)) return;
          
            Util.GenerateCombobox("paychart_sel", cmb_paychartid, "paytypeid,branchid", "" + EmaxGlobals.NullToEmpty(cmb_paytypeid.Value) + "," + EmaxGlobals.NullToEmpty(cmb_branchid.Value) + "", "paychartid", "paychartname");
            if (EmaxGlobals.NullToEmpty(hf_paychartid.Value) != "")
            {
                cmb_paychartid.Value = hf_paychartid.Value;
                hf_paychartid.Value = string.Empty;
            }
        }
    }
}