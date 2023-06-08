using DevExpress.Web;
using Emax.Core.Utility;
using Emax.Dal;
using Emax.SharedLib;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Web;
using System.Web.UI;

namespace VanSales.Purchases
{
    public partial class inv : EmaxBasepage
    {
        public ButtonRenderMode Secondary { get; private set; }

        protected override void OnInit(EventArgs e)
        {
            pageid = "29";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox("sys_expenses_Sel", cmb_expid, "", "", "expid", "expname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_pinvpay, "compid,table_name", "9,sys_fillcomp", "citemid", "citemname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_ccid, "compid,table_name", "0,sys_costcenter", "ccid", "ccname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_paytypeid, "compid,table_name,model", "0,sys-paytype,6", "paytypeid", "paytname");
                Util.GenerateRadioButtonList("sys_fillcomp_sel", rbl_vattype, "compid,table_name", "3,sys_fillcomp", "citemid", "citemname");
                cmb_ccid.SelectedIndex = -1;
                txt_pinvdate.Date = DateTime.Now;
                txt_puser.Text = Context.User.Identity.Name;
                gv_pinvdtls.DataBind();
            }
            Util.GenerateCombobox("paychart_sel", cmb_paychartid, "paytypeid,branchid", "" + EmaxGlobals.NullToEmpty(cmb_paytypeid.Value) + "," + EmaxGlobals.NullToEmpty(cmb_branchid.Value) + "", "paychartid", "paychartname");
            if (Request.QueryString["pinvno"] != null && Request.QueryString["pinvno"] != string.Empty)
            {
                if (Request.QueryString["pinvno"].StartsWith("9"))
                {
                    Response.Redirect("~\\Purchases\\Rtn_P_Inv.aspx?pinvno=" + Request.QueryString["pinvno"]);
                }
                else
                {
                    txt_pinvno.Text = Request.Params["pinvno"];
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("pinvno", txt_pinvno.Text);
                    var f = SqlCommandHelper.ExcecuteToDataTable("p_inv_sel_code", dict).dataTable;
                    BindData(f.Rows[0]);
                    gv_pinvdtls.DataBind();
                    gv_invpay.DataBind();
                    gv_p_invexp.DataBind();
                    PDetiles.Style.Add("display", "block");
                    p_invpay.Style.Add("display", "block");
                    p_invexp.Style.Add("display", "block");
                    cmb_branchid.ClientEnabled = false;
                }
            }
        }
        void clear()
        {
            txt_pinvno.Text = "تلقائى";
            txt_puser.Text = Context.User.Identity.Name;
            txt_pinvdate.Date = DateTime.Now;
            HF_pinvid.Value = null;
            txt_pinvdocno.Text = null;
            cmb_branchid.SelectedIndex = 0;
            cmb_ccid.SelectedIndex = -1;
            cmb_pinvpay.SelectedIndex = 0;
            txt_suppid.Text = null;
            txt_suppname.Text = null;
            txt_pnotes.Text = null;
            txt_suppvat.Text = null;
            rbl_vattype.SelectedIndex = 0;
            txt_netbvat.Text = "0";
            txt_vatvalue.Text = "0";
            txt_netavat.Text = "0";
            txt_restvalue.Text = "0";
            lbl_invpic.Text = null;
            txt_docno.Text = null;
            lbl_postst.Text = null;
            lbl_postacc.Text = null;
            lbl_vochrno.Text = null;
            hf_vochrno.Value = null;
            HF_docid.Value = null;
            hf_postacc.Value = null;
            hf_postst.Value = null;
            cmb_branchid.ClientReadOnly = false;
            rbl_vattype.ClientReadOnly = false;
            txt_vatvalue.ClientReadOnly = false;
            txt_pinvno.ClientReadOnly = false;
            txt_puser.ClientReadOnly = false;
            txt_pinvdate.ClientReadOnly = false;
            txt_pinvdocno.ClientReadOnly = false;
            cmb_ccid.ClientReadOnly = false;
            cmb_pinvpay.ClientReadOnly = false;
            txt_suppid.ClientReadOnly = false;
            txt_suppname.ClientReadOnly = false;
            txt_pnotes.ClientReadOnly = false;
            txt_suppvat.ClientReadOnly = false;
            txt_netbvat.ClientReadOnly = false;
            txt_netavat.ClientReadOnly = false;
            txt_restvalue.ClientReadOnly = false;
            enable();
            enable_pay();
            btn_postst.Enabled = true;
            btn_postst.CssClass = "enable";
            btn_postacc.Enabled = true;
            btn_postacc.CssClass = "enable";
            PDetiles.Style.Add("display", "none");
            p_invpay.Style.Add("display", "none");
            p_invexp.Style.Add("display", "none");
            cleardtls();
            Clear_pay();
            gv_pinvdtls.DataBind();
            gv_invpay.DataBind();
            gv_p_invexp.DataBind();
        }
        void cleardtls()
        {
            HF_invdtlid.Value = "0";
            HF_itemid.Value = null;
            txt_itemcode.Text = null;
            txt_itemname.Text = null;
            HF_unitid.Value = null;
            HF_factor.Value = null;
            txt_unitname.Text = null;
            txt_qty.Text = "1";
            txt_price.Text = "0";
            txt_value.Text = "0";
            txt_discp.Text = "0";
            txt_discvalue.Text = "0";
            txt_netvalue.Text = "0";
            txt_itemnotes.Text = null;
            Hf_vat.Value = null;
        }
        void Clear_pay()
        {
            txt_payno.Text = string.Empty;
            txt_payref.Text = string.Empty;
            txt_payvalue.Text = 0.ToString();
            cmb_paytypeid.Text = string.Empty;
            cmb_paytypeid.Value = string.Empty;
            cmb_paytypeid.SelectedIndex = 0;
            cmb_paychartid.DataBind();
            Hf_invpayid.Value = "";
        }
        void Clear_exp()
        {
            hf_invexpid.Value = "";
            cmb_expid.SelectedIndex = -1;
            //cmb_expid.Value = string.Empty;
            txt_expvalue.Text = string.Empty;
            txt_chartcode.Text = string.Empty;
            txt_chartename.Text = string.Empty;
            hf_accpaidid.Value = "";
            cmb_expid.DataBind();
        }
        void disable()
        {
            btn_Save.Enabled = false;
            btn_Save.CssClass = "disable";
            btn_Save.RenderMode = Secondary;
          
            btn_delete.Enabled = false;
            btn_delete.CssClass = "disable";
            btn_delete.RenderMode = Secondary;
            
            btn_save_dtls.Enabled = false;
            btn_save_dtls.CssClass = "disable";
            btn_save_dtls.RenderMode = Secondary;
            
            btn_delete_dtls.Enabled = false;
            btn_delete_dtls.CssClass = "disable";
            btn_delete_dtls.RenderMode = Secondary;
            
            btn_new_dtls.Enabled = false;
            btn_new_dtls.CssClass = "disable";
            btn_new_dtls.RenderMode = Secondary;
            
            btn_attach.Enabled = false;
            btn_attach.CssClass = "disable";
            btn_attach.RenderMode = Secondary;
            
            btn_upload.Enabled = false;
            btn_upload.CssClass = "disable";
            btn_upload.RenderMode = Secondary;
        }
        void enable()
        {
            btn_Save.Enabled = true;
            btn_Save.CssClass = "enable";

            btn_delete.Enabled = true;
            btn_delete.CssClass = "enable";

            btn_save_dtls.Enabled = true;
            btn_save_dtls.CssClass = "enable";

            btn_delete_dtls.Enabled = true;
            btn_delete_dtls.CssClass = "enable";

            btn_new_dtls.Enabled = true;
            btn_new_dtls.CssClass = "enable";
            
            btn_attach.Enabled = true;
            btn_attach.CssClass = "enable";

            btn_upload.Enabled = true;
            btn_upload.CssClass = "enable";
          
        }
        void disable_pay()
        {
            btn_save_pay.Enabled = false;
            btn_save_pay.CssClass = "disable";
            btn_save_pay.RenderMode = Secondary;
          
            btn_delete_pay.Enabled = false;
            btn_delete_pay.CssClass = "disable";
            btn_delete_pay.RenderMode = Secondary;
             
            btn_new_pay.Enabled = false;
            btn_new_pay.CssClass = "disable";
            btn_new_pay.RenderMode = Secondary;
        }
        void disable_exp()
        {
            btn_save_exp.Enabled = false;
            btn_save_exp.CssClass = "disable";
            btn_save_exp.RenderMode = Secondary;

            btn_delete_exp.Enabled = false;
            btn_delete_exp.CssClass = "disable";
            btn_delete_exp.RenderMode = Secondary;

            btn_new_exp.Enabled = false;
            btn_new_exp.CssClass = "disable";
            btn_new_exp.RenderMode = Secondary;
        }
        void enable_pay()
        {
          
            btn_save_pay.Enabled = true;
            btn_save_pay.CssClass = "enable";
          
            btn_delete_pay.Enabled = true;
            btn_delete_pay.CssClass = "enable";
           
            btn_new_pay.Enabled = true;
            btn_new_pay.CssClass = "enable";
        }
        void enable_exp()
        {

            btn_save_exp.Enabled = true;
            btn_save_exp.CssClass = "enable";

            btn_delete_exp.Enabled = true;
            btn_delete_exp.CssClass = "enable";

            btn_new_exp.Enabled = true;
            btn_new_exp.CssClass = "enable";
        }
        void BindData(DataRow rec)
        {
            HF_pinvid.Value = EmaxGlobals.NullToEmpty(rec["pinvid"]);
            txt_pinvdocno.Text = EmaxGlobals.NullToEmpty(rec["pinvdocno"]);
            txt_pinvdate.Date = Convert.ToDateTime(rec["pinvdate"]);         
            cmb_branchid.Value = EmaxGlobals.NullToEmpty(rec["branchid"]);
            cmb_branchid.Text = EmaxGlobals.NullToEmpty(rec["branchname"]);
            cmb_pinvpay.Text = EmaxGlobals.NullToEmpty(rec["pinvpayname"]);
            cmb_pinvpay.Value = EmaxGlobals.NullToEmpty(rec["pinvpay"]);
            cmb_ccid.Text = EmaxGlobals.NullToEmpty(rec["ccname"]);
            cmb_ccid.Value = EmaxGlobals.NullToEmpty(rec["ccid"]);          
            txt_suppid.Text = EmaxGlobals.NullToEmpty(rec["suppid"]);
            txt_suppname.Text = EmaxGlobals.NullToEmpty(rec["suppname"]);
            txt_suppvat.Text = EmaxGlobals.NullToEmpty(rec["suppvat"]);
            txt_puser.Text = EmaxGlobals.NullToEmpty(rec["puser"]);
            txt_pnotes.Text = EmaxGlobals.NullToEmpty(rec["pnotes"]);
            txt_docno.Text = EmaxGlobals.NullToEmpty(rec["docno"]);
            txt_netbvat.Text = EmaxGlobals.NullToEmpty(rec["netbvat"]);
            txt_vatvalue.Text = EmaxGlobals.NullToEmpty(rec["vatvalue"]);
            txt_netavat.Text = EmaxGlobals.NullToEmpty(rec["netavat"]);
            txt_restvalue.Text = EmaxGlobals.NullToEmpty(rec["restvalue"]);
            lbl_invpic.Text = EmaxGlobals.NullToEmpty(rec["invpic"]);
            HF_docid.Value = EmaxGlobals.NullToEmpty(rec["docid"]);
            hf_postacc.Value = EmaxGlobals.NullToEmpty(rec["postacc"]);
            hf_postst.Value = EmaxGlobals.NullToEmpty(rec["postst"]);
            if (EmaxGlobals.NullToBool(hf_postst.Value) == true)
            {
                lbl_postst.Text = "مرحل مستودعات";
                btn_postst.Enabled = false;
                btn_postst.CssClass = "disable";
                btn_postst.RenderMode = Secondary;
            }
            else
            {
                lbl_postst.Text = "";
                btn_postst.Enabled = true;
                btn_postst.CssClass = "enable";
            }
            if (EmaxGlobals.NullToBool(hf_postacc.Value) == true)
            {
                lbl_postacc.Text = "مرحل حـسابـات";
                lbl_vochrno.Text = EmaxGlobals.NullToEmpty(rec["vochrno"]);
                hf_vochrno.Value = EmaxGlobals.NullToEmpty(rec["vochrno"]);
                btn_postacc.Enabled = false;
                btn_postacc.CssClass = "disable";
                btn_postacc.RenderMode = Secondary;
                disable_pay();
                disable_exp();
            }
            else
            {
                lbl_postacc.Text = "";
                lbl_vochrno.Text = "";
                hf_vochrno.Value = "";
                btn_postacc.Enabled = true;
                btn_postacc.CssClass = "enable";
                enable_pay();
            }
            if (EmaxGlobals.NullToBool(hf_postst.Value) == true || EmaxGlobals.NullToBool(hf_postacc.Value) == true)
            {
                disable();
            }
            else
            {
                enable();
            }
        }
        List<object> MasterParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_pinvid.Value) == 0)
            {
                return new List<object> { txt_pinvdocno, txt_pinvdate, cmb_branchid, cmb_ccid, cmb_pinvpay, txt_suppid, txt_suppname, txt_pnotes, txt_suppvat, txt_puser, rbl_vattype, txt_netbvat, txt_vatvalue, txt_netavat, txt_restvalue, lbl_invpic };
            }
            else
            {
                return new List<object> { HF_pinvid, txt_pinvno, txt_pinvdocno, txt_pinvdate, cmb_branchid, cmb_ccid, cmb_pinvpay, txt_suppid, txt_suppname, txt_pnotes, txt_suppvat, txt_puser, rbl_vattype, txt_netbvat, txt_vatvalue, txt_netavat, txt_restvalue, lbl_invpic };
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<object, object> dictvattypename = new Dictionary<object, object>();
                dictvattypename.Add("vattypename", rbl_vattype.SelectedItem.Text);
                var res = SaveData(EmaxGlobals.NullToIntZero(HF_pinvid.Value) == 0 ? "p_inv_ins" : "p_inv_upd", MasterParam(), null,
                EmaxGlobals.NullToIntZero(HF_pinvid.Value) == 0 ? new List<string>() { "pinvid", "pinvno" } : new List<string>() { }, true, true,
                new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue =cmb_branchid }
                ,new ParamObject() { ParamName = "pinvpayname", ParamValue = cmb_pinvpay }
                ,new ParamObject() { ParamName = "ccname", ParamValue = cmb_ccid } }
                ,EmaxGlobals.NullToIntZero(HF_pinvid.Value) == 0 ? dictvattypename : null);
                if (res.errorid == 0)
                {
                    cmb_branchid.ClientReadOnly = true;
                    rbl_vattype.ClientReadOnly = true;
                    PDetiles.Style.Add("display", "block");
                    p_invpay.Style.Add("display", "block");
                    p_invexp.Style.Add("display", "block");
                    if (EmaxGlobals.NullToIntZero(HF_pinvid.Value) != 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                    }
                    else
                    {
                        HF_pinvid.Value = res.outputparams != null && res.outputparams.Count > 0 ? EmaxGlobals.NullToEmpty(res.outputparams["pinvid"]) : "";
                        txt_pinvno.Text = res.outputparams.ContainsKey("pinvno") ? EmaxGlobals.NullToEmpty(res.outputparams["pinvno"].ToString()) : "";
                    }
                    if (cmb_pinvpay.SelectedItem.Value.ToString() == "2")
                    {
                        disable_pay();                        
                    }
                    else if (cmb_pinvpay.SelectedItem.Value.ToString() == "1" )
                    {
                        enable_pay();
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
        List<object> dtlsParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_invdtlid.Value) == 0)
            {
                return new List<object> { HF_pinvid, HF_itemid, HF_unitid, txt_unitname, txt_qty, HF_factor, txt_price, txt_value, txt_discp, txt_discvalue, txt_netvalue, txt_itemnotes, txt_itemvatvalue };
            }
            else
            {
                return new List<object> { HF_invdtlid, txt_qty, txt_price, txt_value, txt_discp, txt_discvalue, txt_netvalue, txt_itemnotes, txt_itemvatvalue };
            }
        }
        List<object> GetVatParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_pinvid.Value) != 0)
            {
                return new List<object> { HF_pinvid, txt_netbvat, txt_vatvalue, txt_netavat, txt_restvalue };
            }
            else
            {
                return null;
            }
        }
        protected void btn_save_dtls_Click(object sender, EventArgs e)
        {
            var res = SaveData(EmaxGlobals.NullToIntZero(HF_invdtlid.Value) == 0 ? "p_invdtls_ins" : "p_invdtls_upd", dtlsParam(), null, null, true);
            if (res.errorid == 0)
            {
                gv_pinvdtls.DataBind();
                cleardtls();
                var res2 = SaveData("P_inv_vat_upd", GetVatParam(), null, null, true, false, null);
            }
        }
        protected void gv_pinvdtls_DataBinding(object sender, EventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("pinvid", HF_pinvid.Value);
            gv_pinvdtls.DataSource = SqlCommandHelper.ExcecuteToDataTable("p_invdtls_sel", dict).dataTable;
        }
        protected void gv_pinvdtls_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            var rcase = e.Parameters.Split(',');
            if (rcase.Length != 1)
            {
                if (rcase[0] == "true")
                {
                    btn_postst.Enabled = false;
                    btn_postst.CssClass = "disable";
                    btn_postst.RenderMode = Secondary;
                    lbl_postst.Text = "مرحل مستودعات";
                }
                else
                {
                    btn_postst.Enabled = true;
                    btn_postst.CssClass = "enable";
                    lbl_postst.Text = "";
                }
                if (rcase[1] == "null")
                {
                    txt_docno.Text = null;
                }
                else
                {
                    txt_docno.Text = rcase[1];
                }
                if (rcase[2] == "null")
                {
                    lbl_invpic.Text = null;
                }
                else
                {
                    lbl_invpic.Text = rcase[2];
                }
                if (rcase[3] == "true")
                {
                    disable_pay();
                    disable_exp();
                    btn_postacc.Enabled = false;
                    btn_postacc.CssClass = "disable";
                    btn_postacc.RenderMode = Secondary;
                    lbl_postacc.Text = "مرحل حسابات";
                    lbl_vochrno.Text = hf_vochrno.Value;
                }
                else
                {
                    enable_pay();
                    enable_exp();
                    btn_postacc.Enabled = true;
                    btn_postacc.CssClass = "enable";
                    lbl_postacc.Text = "";
                    lbl_vochrno.Text = "";
                    hf_vochrno.Value = "";
                }
                if (rcase.Length > 4)
                {
                    if (rcase[4] != "" || rcase[4] != null)
                    {
                        lbl_vochrno.Text = rcase[4];
                    }
                }
                if (rcase[0] == "true" || rcase[3] == "true")
                {
                    disable();
                }
                else
                {
                    enable();
                }
            }
            if (cmb_pinvpay.SelectedItem.Value.ToString() == "2")
            {
                disable_pay();
            }
            else if (cmb_pinvpay.SelectedItem.Value.ToString() == "1" && EmaxGlobals.NullToBool(hf_postacc.Value) == false)
            {
                enable_pay();
            }
            PDetiles.Style.Add("display", "block");
            p_invpay.Style.Add("display", "block");
            p_invexp.Style.Add("display", "block");
            HF_invdtlid.Value = "0";
            gv_pinvdtls.DataBind();
            gv_pinvdtls.FocusedRowIndex = -1;
            gv_invpay.DataBind();
            gv_p_invexp.DataBind();
            cleardtls();
        }
        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle;
                exptitle = "أصناف الفاتوره رقم " + txt_pinvno.Text;
                ExportingDevExpressUtil.Export(gvitemsExporter, "اصناف الفاتوره", 1 , Request.GetOwinContext().Request.User.Identity.Name, gv_pinvdtls.GetSelectedFieldValues("invtdtlsid").Count != 0, false, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }
        DataTable GvpaySource()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("pinvid", HF_pinvid.Value);
            return SqlCommandHelper.ExcecuteToDataTable("p_invpay_sel", dict).dataTable;
        }
        protected void gv_invpay_DataBinding(object sender, EventArgs e)
        {
            gv_invpay.DataSource = GvpaySource();
        }
        List<object> GetParam_pay()
        {
            if (EmaxGlobals.NullToIntZero(Hf_invpayid.Value) == 0)
            {
                return new List<object> { HF_pinvid, cmb_paytypeid , txt_payvalue, txt_payno, txt_payref, cmb_paychartid };
            }
            else
            {

                return new List<object> { Hf_invpayid, HF_pinvid, cmb_paytypeid, txt_payvalue, txt_payno, txt_payref, cmb_paychartid };
            }
        }
        protected void btn_save_pay_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_payvalue.Text == "" || txt_payvalue.Text == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('برجاء ادخال القيمه اولا')", true);
                    return;
                }
                var res = SaveData(EmaxGlobals.NullToIntZero(Hf_invpayid.Value) == 0 ? "p_invpay_ins" : "p_invpay_upd", GetParam_pay(), null, null, true, true,
                new List<ParamObject>() { new ParamObject() { ParamName = "payname", ParamValue = cmb_paytypeid } },null);
                if (res.errorid == 0)
                {
                    gv_invpay.DataBind();
                    Clear_pay();
                    var res2 = SaveData("P_inv_vat_upd", GetVatParam(), null, null, true, false, null);
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
        protected void gv_pinvdtls_DataBound(object sender, EventArgs e)
        {
            ASPxGridView gridView = sender as ASPxGridView;
            if (gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]) == null || gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]).ToString() == "")
            {
                return;
            }
            //شامل الضريبه
            if (rbl_vattype.Value.ToString() == "1")
            {
                txt_netavat.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]).ToString();
                txt_vatvalue.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["vatvalue"]).ToString();
                txt_netbvat.Text = (EmaxGlobals.NullToZero(txt_netavat.Text) - EmaxGlobals.NullToZero(txt_vatvalue.Text)).ToString();
                if (txt_restvalue.Text == "0")
                    txt_restvalue.Text = txt_netavat.Text;
            }
            ///غير شامل الصريبه
            else if (rbl_vattype.Value.ToString() == "2")
            {
                txt_netbvat.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]).ToString();
                txt_vatvalue.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["vatvalue"]).ToString();
                txt_netavat.Text = (EmaxGlobals.NullToZero(txt_netbvat.Text) + EmaxGlobals.NullToZero(txt_vatvalue.Text)).ToString();
                if (txt_restvalue.Text == "0")
                    txt_restvalue.Text = txt_netavat.Text;
            }
            else if (rbl_vattype.Value.ToString() == "3")
            {
                txt_netbvat.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]).ToString();
                txt_netavat.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]).ToString();
                txt_vatvalue.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["vatvalue"]).ToString();
                if (txt_restvalue.Text == "0")
                    txt_restvalue.Text = txt_netavat.Text;
            }
            if (EmaxGlobals.NullToIntZero(HF_pinvid.Value).ToString() != "0")
            {
                cmb_branchid.ClientReadOnly = true;
                rbl_vattype.ClientReadOnly = true;
                //txt_vatvalue.ClientReadOnly = true;
            }
            try
            {
                decimal rest = EmaxGlobals.NullToZero(gv_invpay.GetTotalSummaryValue(gv_invpay.TotalSummary["payvalue"]));
                txt_restvalue.Text = (EmaxGlobals.NullToZero(txt_netavat.Text) - rest).ToString();
            }
            catch
            { 

            }
        }
        protected void gv_invpay_DataBound(object sender, EventArgs e)
        {
            ASPxGridView gridView1 = sender as ASPxGridView;

            if (gridView1.GetTotalSummaryValue(gridView1.TotalSummary["payvalue"]) == null || gridView1.GetTotalSummaryValue(gridView1.TotalSummary["payvalue"]).ToString() == "")
            {
                return;
            }
            decimal rest = EmaxGlobals.NullToZero(gridView1.GetTotalSummaryValue(gridView1.TotalSummary["payvalue"]));

            txt_restvalue.Text = (EmaxGlobals.NullToZero(txt_netavat.Text) - rest).ToString();
        }
        protected void gv_invpay_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            PDetiles.Style.Add("display", "block");
            p_invpay.Style.Add("display", "block");
            p_invexp.Style.Add("display", "block");
            Clear_pay();
            gv_pinvdtls.DataBind();
            gv_invpay.DataBind();
            gv_p_invexp.DataBind();
        }

        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(Server.MapPath("~/Files/Purchases/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Files/Purchases/"));
                }
                if (txt_pinvno.Text == "تلقائى")
                {
                    if (fub_invpic.HasFile == false && lbl_invpic.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('لا يوجد ملف للتحميل')", true);
                        return;
                    }
                    fub_invpic.SaveAs(Server.MapPath("~/Files/Purchases/" + fub_invpic.FileName));
                    string pathfile = "~/Files/Purchases/" + Path.GetFileName(fub_invpic.PostedFile.FileName);
                    lbl_invpic.Text = pathfile;
                }
                else
                {
                    string pathfile = null;
                    if (fub_invpic.HasFile == true)
                    {
                        fub_invpic.SaveAs(Server.MapPath("~/Files/Purchases/" + fub_invpic.FileName));
                        pathfile = "~/Files/Purchases/" + Path.GetFileName(fub_invpic.PostedFile.FileName);
                        lbl_invpic.Text = pathfile;
                    }
                    else if (fub_invpic.HasFile == false && lbl_invpic.Text != null || lbl_invpic.Text != "")
                    {
                        if (lbl_invpic.Text == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('لا يوجد ملف للتحميل')", true);
                            return;
                        }
                        pathfile = lbl_invpic.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
            }
        }

        protected void btn_download_Click(object sender, EventArgs e)
        {
            try
            {
                string fileextantion = lbl_invpic.Text;
                fileextantion = fileextantion.Substring(fileextantion.Length - 3, 3);
                if (fileextantion == "lsx" || fileextantion == "LSX")
                {
                    fileextantion = "xlsx";
                }
                else if (fileextantion == "peg" || fileextantion == "PEG")
                {
                    fileextantion = "jpeg";
                }
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "File/" + fileextantion + "";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + txt_pinvno.Text + "." + fileextantion + "");
                Response.TransmitFile(Server.MapPath(lbl_invpic.Text));
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                if (msg.Contains("لا يمكن أن يكون StartIndex أقل من الصفر.\\r\\nاسم المعلمة: startIndex") || msg.Contains("StartIndex cannot be less than zero.\\r\\nParameter name: startIndex"))
                {
                    msg = "لا يوجد ملف لتحميله";
                }
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('" + msg + "')", true);
            }
        }
        protected void btn_attach_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(Server.MapPath("~/Files/Purchases/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Files/Purchases/"));
                }


                //Upload and save the file
                string excelPath = Server.MapPath("~/Files/Purchases") + Path.GetFileName(fub_dtlfile.PostedFile.FileName);
                //var  f=Request.Files[0];
                fub_dtlfile.SaveAs(excelPath);

                string conString = string.Empty;
                string extension = Path.GetExtension(fub_dtlfile.PostedFile.FileName);
                switch (extension)
                {
                    case ".xls": //Excel 97-03
                        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx": //Excel 07 or higher
                        conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                        break;

                }
                conString = string.Format(conString, excelPath);
                Dictionary<object, object> dict = new Dictionary<object, object>();

                using (OleDbConnection excel_con = new OleDbConnection(conString))
                {
                    excel_con.Open();
                    string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                    DataTable dtExcelData = new DataTable();

                    //[OPTIONAL]: It is recommended as otherwise the data will be considered as String by default.
                    //dtExcelData.Columns.AddRange(new DataColumn[3] { new DataColumn("Id", typeof(int)),
                    //new DataColumn("Name", typeof(string)),
                    //new DataColumn("Salary", typeof(decimal)) });

                    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                    {
                        //DataColumn column = new DataColumn("itemid", typeof(int))
                        //{
                        //    DefaultValue = DBNull.Value
                        //};
                        //DataColumn column2 = new DataColumn("unitname", typeof(string))
                        //{
                        //    DefaultValue = DBNull.Value
                        //};
                        //dtExcelData.Columns.Add(column);
                        //dtExcelData.Columns.Add(column2);
                        oda.Fill(dtExcelData);


                    }

                    excel_con.Close();

                    string consString = ConfigurationManager.ConnectionStrings["VanSales"].ConnectionString;
                    SqlCommandHelper.ExecuteNonQuery("items_excel_del", dict, true);
                    using (SqlConnection con = new SqlConnection(consString))
                    {

                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = "dbo.items_excel";

                            //[OPTIONAL]: Map the Excel columns with that of the database table
                            // sqlBulkCopy.ColumnMappings.Add("Name", "branchname");
                            // sqlBulkCopy.ColumnMappings.Add("Phone", "branchtel");
                            //  sqlBulkCopy.ColumnMappings.Add("Salary", "Salary");

                            con.Open();
                            sqlBulkCopy.WriteToServer(dtExcelData);
                            con.Close();
                        }
                    }
                }

                var res = SaveData("p_inv_itemexcel_ins", new List<object> { HF_pinvid, rbl_vattype }, null,
                null, true, true, null
                , null);
                if (res.errorid == 0)
                {
                    cleardtls();
                    gv_pinvdtls.DataBind();

                }
                else
                {
                    if (res.errormsg.Contains("FK_p_invdtls_p_inv") == true)
                    {
                        Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath);
                    }

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('" + res.errormsg + "')", true);
                    gv_pinvdtls.DataBind();
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo(" + res.errormsg + ")", true);
                }
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo(" + ex.Message + ")", true);
            }

            //Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath);
        }
        protected void txt_vatvalue_TextChanged(object sender, EventArgs e)
        {
            //شامل الضريبه
            if (rbl_vattype.Value.ToString() == "1")
            {
                txt_netbvat.Text = (EmaxGlobals.NullToZero(txt_netavat.Text) - EmaxGlobals.NullToZero(txt_vatvalue.Text)).ToString();
                if (txt_restvalue.Text == "0")
                    txt_restvalue.Text = txt_netavat.Text;
            }
            ///غير شامل الصريبه
            else if (rbl_vattype.Value.ToString() == "2")
            {
                txt_netavat.Text = (EmaxGlobals.NullToZero(txt_netbvat.Text) + EmaxGlobals.NullToZero(txt_vatvalue.Text)).ToString();
                if (txt_restvalue.Text == "0")
                    txt_restvalue.Text = txt_netavat.Text;
            }
            else if (rbl_vattype.Value.ToString() == "3")
            {
                if (txt_restvalue.Text == "0")
                    txt_restvalue.Text = txt_netavat.Text;
            }
            if (EmaxGlobals.NullToIntZero(HF_pinvid.Value).ToString() != "0")
            {
                cmb_branchid.ClientReadOnly = true;
                rbl_vattype.ClientReadOnly = true;
            }
            try
            {
                decimal rest = EmaxGlobals.NullToZero(gv_invpay.GetTotalSummaryValue(gv_invpay.TotalSummary["payvalue"]));
                txt_restvalue.Text = (EmaxGlobals.NullToZero(txt_netavat.Text) - rest).ToString();
            }
            catch
            {

            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("pinvid", HF_pinvid.Value);
            PrintPage("Purchase/P_Inv_Page.repx", dict);
        }
        List<object> GetParam_exp()
        {
            if (EmaxGlobals.NullToIntZero(hf_invexpid.Value) == 0)
            {
                return new List<object> { HF_pinvid, cmb_expid, txt_expvalue, hf_accpaidid };
            }
            else
            {

                return new List<object> { hf_invexpid, HF_pinvid, cmb_expid, txt_expvalue, hf_accpaidid };
            }
        }

        protected void btn_save_exp_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_expvalue.Text == "" || txt_expvalue.Text == "0")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('برجاء ادخال القيمه اولا')", true);
                    return;
                }
                var res = SaveData(EmaxGlobals.NullToIntZero(hf_invexpid.Value) == 0 ? "p_invexp_ins" : "p_invexp_upd", GetParam_exp(), null, null, true);
                if (res.errorid == 0)
                {
                    gv_p_invexp.DataBind();
                    Clear_exp();
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
        DataTable gv_p_invexpSource()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("pinvid", HF_pinvid.Value);
            return SqlCommandHelper.ExcecuteToDataTable("p_invexp_sel", dict).dataTable;
        }
        protected void gv_pinvexp_DataBinding(object sender, EventArgs e)
        {
            gv_p_invexp.DataSource = gv_p_invexpSource();
        }
    }
}