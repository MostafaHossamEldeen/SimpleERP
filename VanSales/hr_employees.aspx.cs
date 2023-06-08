using Emax.Dal;
using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales
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
                    Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "1,sys_branch", "branchid", "branchname");
                    Util.GenerateCombobox("sys_fillcomp_sel", cmb_ccid, "compid,table_name", "0,sys_costcenter", "ccid", "ccname");
                    Util.GenerateCombobox("hr_masterfiles_sel", cmb_nationid, "masterid", "1", "mitemid", "mitemname");
                    Util.GenerateCombobox("hr_masterfiles_sel", cmb_jobid, "masterid", "2", "mitemid", "mitemname");
                    Util.GenerateCombobox("sys_fillcomp_sel", cmb_empstatus, "compid,table_name", "27,sys_fillcomp", "citemid", "citemname");
                    Util.GenerateCombobox("sys_fillcomp_sel", cmb_paytypeid, "compid,table_name,model", "0,sys-paytype,7", "paytypeid", "paytname");
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
            txt_empbdate.Date = (Convert.ToDateTime(rec["empbdate"]));
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
            txt_empworkdate.Date = (Convert.ToDateTime(rec["empworkdate"]));
            txt_empbankname.Text = EmaxGlobals.NullToEmpty(rec["empbankname"]);
            txt_empbankid.Text = EmaxGlobals.NullToEmpty(rec["empbankid"]);
            txt_annualvaction.Text = EmaxGlobals.NullToEmpty(rec["annualvaction"]);
            txt_empchatid.Text = EmaxGlobals.NullToEmpty(rec["empchatid"]);
            img_itempic.ImageUrl = EmaxGlobals.NullToEmpty(rec["emppic"]);
            cmb_paytypeid.Value = EmaxGlobals.NullToEmpty(rec["paytypeid"]);
            cmb_paytypeid.Text = EmaxGlobals.NullToEmpty(rec["paytypename"]);
            cmb_paychartid.Value = EmaxGlobals.NullToEmpty(rec["paychartid"]);
            cmb_paychartid.Text = EmaxGlobals.NullToEmpty(rec["paychartname"]);
        }

        protected void upd_emppic_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {

        }

        protected void btn_save_Click(object sender, EventArgs e)
        {

        }

        protected void cmb_paychartid_Callback(object sender, DevExpress.Web.CallbackEventArgsBase e)
        {
            if (string.IsNullOrEmpty(e.Parameter)) return;

            Util.GenerateCombobox("paychart_sel", cmb_paychartid, "paytypeid,branchid", "" + EmaxGlobals.NullToEmpty(cmb_paytypeid.Value) + "," + EmaxGlobals.NullToEmpty(cmb_branchid.Value) + "", "paychartid", "paychartname");
        }
    }
}