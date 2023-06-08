using VanSales.DBClass;
using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Emax.Dal;
using System.Windows.Forms;
using Emax.SharedLib;
using Repository.Ado;
using System.Web.Services;
using System.Web.Script.Services;
using Newtonsoft.Json;
using Emax.Core.Utility;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.OleDb;
using RestSharp;
using Newtonsoft.Json.Linq;
using DevExpress.XtraPrinting;
using DevExpress.Export;

namespace VanSales.Sales
{
    public partial class Rtn_inv : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "5";
            base.OnInit(e);
        }
        SalesInv ms = new SalesInv();

        public ButtonRenderMode Secondary { get; private set; }
        
        //int unitid;
        protected void Page_Load(object sender, EventArgs e)
        {
            // btn_print.Attributes.Add("onclick", "this.form.target='_blank'");
            if (!IsPostBack)
            {
              
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_sinvpay, "compid,table_name", "9,sys_fillcomp", "citemid", "citemname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_smanid, "compid,table_name", "0,s_sman", "smanid", "smanname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_ccid, "compid,table_name", "0,sys_costcenter", "ccid", "ccname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_paytype, "compid,table_name,model", "0,sys-paytype,5", "paytypeid", "paytname");
                            HF_invid.Value = Request.Params["sinvid"];
                cmb_smanid.SelectedIndex = -1;
                cmb_ccid.SelectedIndex = -1;
                txt_sinvdata.Date = DateTime.Now;
                cmb_sinvpay.SelectedIndex = 0;
                cmb_branchid.SelectedIndex = 0;
                cmb_paytype.SelectedIndex = 0;
                txt_suser.Text = Context.User.Identity.Name;
                // HF_vattype.Value = "1";
                HF_vattype.Value = SqlCommandHelper.GetTokenKey("vattype", Request.Cookies["Token"].Value);
            }
            // Util.GenerateCombobox("s_inv_paychart", cmb_paychartid, "paytypeid,branchid"," " + EmaxGlobals.NullToEmpty(cmb_paytype.Value) + "," + EmaxGlobals.NullToEmpty(cmb_branchid.Value) + "", "paychartid", "paychartname");
            if (Request.QueryString["sinvno"] != null && Request.QueryString["sinvno"] != string.Empty)
            {
                txt_rtnsinvno.Text = Request.Params["sinvno"];
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("sinvno", txt_rtnsinvno.Text);
                var f = SqlCommandHelper.ExcecuteToDataTable("[s_inv_sel_code]", dict).dataTable;

                BindData(f.Rows[0]);
                gvs_invdtls.DataBind();
                gv_invpay.DataBind();
                PDetiles.Style.Add("display", "block");
                p_invpay.Style.Add("display", "block");
                cmb_branchid.ClientEnabled = false;
            }
            if (txt_payvalue.Text == "0")
            {
                Util.GenerateCombobox("s_inv_paychart", cmb_paychartid, "paytypeid,branchid", "" + EmaxGlobals.NullToEmpty(cmb_paytype.Value) + "," + EmaxGlobals.NullToEmpty(cmb_branchid.Value) + "", "paychartid", "paychartname");
            }
        }
        void clear()
        {

            txt_item.Text = string.Empty;
            txt_unit.Text = string.Empty;
            txt_qty.Text = "1";
            txt_price.Text = "0";
            txt_value.Text = "0";
            txt_discp.Text = "0";
            txt_discvalue.Text = "0";
            txt_netvalue.Text = "0";

            txtitem_vatvalue.Text = "0";
            txt_itemnotes.Text = string.Empty;
            txtitem_name.Text = string.Empty;
            HF_invdtlid.Value = "";
            HF_itemid.Value = "";
            Hf_vat.Value = "";
            hf_disc.Value = "";
            hf_qty.Value = "";
        }
        void clear_inv()
        {
            clear();
            Clear_pay();
            txt_rtnsinvno.Text = string.Empty;
            txt_rtnsinvno.Text = "تلقائى";
            txt_sinvdocno.Text = string.Empty;
            txt_invno.Text = string.Empty;
            txt_sinvdata.Text = string.Empty;
            txt_sinvtime.Text = string.Empty;
            cmb_sinvpay.Text = string.Empty;
            cmb_sinvpay.Value = string.Empty;
            cmb_branchid.SelectedIndex = 0;
            cmb_branchid.ClientEnabled = true;
            cmb_ccid.Text = string.Empty;
            cmb_ccid.Value = string.Empty;
            cmb_smanid.Text = string.Empty;
            cmb_smanid.Value = string.Empty;
            Hf_cusid.Value = string.Empty;
            txt_custid.Text = string.Empty;
            txt_custname.Text = string.Empty;
            txt_custvat.Text = string.Empty;
            txt_custadd.Text = string.Empty;
            txt_custmobile.Text = string.Empty;
            txt_suser.Text = Context.User.Identity.Name;
            txt_snotes.Text = string.Empty;
            HF_invid.Value = "";
            HF_rtninvid.Value = "";
            txt_sinvdata.Date = DateTime.Now;
            cmb_sinvpay.SelectedIndex = 0;
            ch_withoutinv.Checked = false;
            chk_rtnall.Checked = false;
            txt_invno.ClientEnabled = true;
            //  btn_search_inv.Enabled = true;
            lbl_postst.Text = "";
            lbl_postacc.Text = "";
            hf_posyacc.Value = "";
            hf_postst.Value = "";
            lbl_vochrno.Text = string.Empty;
            enable();
            enable_pay();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "document.querySelector('#btn_search_inv').disabled = false;", true);
            chk_rtnall.ClientEnabled = true;
            ch_withoutinv.ClientEnabled = true;
            lbl_invdoc.Text = string.Empty;
            PDetiles.Style.Add("display", "none");
            p_invpay.Style.Add("display", "none");
            gvs_invdtls.DataBind();
            gv_invpay.DataBind();
            txt_restvalue.Text = "0";
            txt_netbvat.Text = "0";
            txt_vatvalue.Text = "0";
            txt_netavat.Text = "0";
        }
        void Clear_pay()
        {
            txt_payno.Text = string.Empty;
            txt_payref.Text = string.Empty;
            txt_payvalue.Text = 0.ToString();
            cmb_paytype.Text = string.Empty;
            cmb_paytype.Value = string.Empty;
            cmb_paytype.SelectedIndex = 0;
            cmb_paychartid.DataBind();
            Hf_payid.Value = "";
        }
        void disable()
        {
            btn_Save.Enabled = false;
            btn_Save.CssClass = "disable";
            btn_Save.RenderMode = Secondary;

            btn_delete.Enabled = false;
            btn_delete.CssClass = "disable";
            btn_delete.RenderMode = Secondary;
            //btn_addnew.Enabled = false;
            btn_save_dtls.Enabled = false;
            btn_save_dtls.CssClass = "disable";
            btn_save_dtls.RenderMode = Secondary;
            // btn_new_dtls.Enabled = false;
            btn_postst.Enabled = false;
            btn_postst.CssClass = "disable";
            btn_postst.RenderMode = Secondary;

            btn_delete_dtls.Enabled = false;
            btn_delete_dtls.CssClass = "disable";
            btn_delete_dtls.RenderMode = Secondary;

           

            chk_rtnall.Enabled = false;
           
            ch_withoutinv.Enabled = false;

            upload.Enabled = false;
            upload.CssClass = "disable";
            upload.RenderMode = Secondary;

            btn_attach.Enabled = false;
            btn_attach.CssClass = "disable";
            btn_attach.RenderMode = Secondary;

            ASPxButton1.Enabled = false;
            ASPxButton1.CssClass = "disable";
            ASPxButton1.RenderMode = Secondary;
        }
        void enable()
        {
            btn_Save.Enabled = true;
            btn_Save.CssClass = "enable";

            btn_delete.Enabled = true;
            btn_delete.CssClass = "enable";
            //btn_addnew.Enabled = false;
            btn_save_dtls.Enabled = true;
            btn_save_dtls.CssClass = "enable";
            // btn_new_dtls.Enabled = false;
            btn_delete_dtls.Enabled = true;
            btn_delete_dtls.CssClass = "enable";

            btn_postst.Enabled = true;
            btn_postst.CssClass = "enable";

            chk_rtnall.Enabled = true;
            chk_rtnall.CssClass = "enable";
            ch_withoutinv.Enabled = true;

          

            upload.Enabled = true;
            upload.CssClass = "enable";

            btn_attach.Enabled = true;
            btn_attach.CssClass = "enable";

            ASPxButton1.Enabled = true;
            ASPxButton1.CssClass = "enable";
        }
        void disable_pay()
        {
            btn_save_pay.Enabled = false;
            btn_save_pay.CssClass = "disable";
            btn_save_pay.RenderMode = Secondary;

            btn_delete_pay.Enabled = false;
            btn_delete_pay.CssClass = "disable";
            btn_delete_pay.RenderMode = Secondary;

            //btn_postacc.Enabled = false;
            //btn_postacc.CssClass = "disable";
            //btn_postacc.RenderMode = Secondary;
        }
        void enable_pay()
        {
            btn_save_pay.Enabled = true;
            btn_save_pay.CssClass = "enable";


            btn_delete_pay.Enabled = true;
            btn_delete_pay.CssClass = "enable";

            btn_postacc.Enabled = true;
            btn_postacc.CssClass = "enable";
          

        }
        void BindData(DataRow rec)
        {
            HF_rtninvid.Value = EmaxGlobals.NullToEmpty(rec["sinvid"]);
            txt_sinvdocno.Text = EmaxGlobals.NullToEmpty(rec["sinvdocno"]);
            txt_sinvdata.Date = Convert.ToDateTime(rec["sinvdata"]);
            txt_sinvtime.Text = EmaxGlobals.NullToEmpty(rec["sinvtime"]);
            cmb_branchid.Value = EmaxGlobals.NullToEmpty(rec["branchid"]);
            cmb_branchid.Text = EmaxGlobals.NullToEmpty(rec["branchname"]);
            cmb_sinvpay.Text = EmaxGlobals.NullToEmpty(rec["sinvpayname"]);
            cmb_sinvpay.Value = EmaxGlobals.NullToEmpty(rec["sinvpay"]);
            cmb_ccid.Text = EmaxGlobals.NullToEmpty(rec["ccname"]);
            cmb_ccid.Value = EmaxGlobals.NullToEmpty(rec["ccid"]);
            cmb_smanid.Text = EmaxGlobals.NullToEmpty(rec["smanname"]);
            cmb_smanid.Value = EmaxGlobals.NullToEmpty(rec["smanid"]);
            txt_custid.Text = EmaxGlobals.NullToEmpty(rec["custid"]);
            Hf_cusid.Value = EmaxGlobals.NullToEmpty(rec["custid"]);
            txt_custname.Text = EmaxGlobals.NullToEmpty(rec["custname"]);
            txt_custvat.Text = EmaxGlobals.NullToEmpty(rec["custvat"]);
            txt_custadd.Text = EmaxGlobals.NullToEmpty(rec["custadd"]);
            txt_custmobile.Text = EmaxGlobals.NullToEmpty(rec["custmobile"]);
            txt_suser.Text = EmaxGlobals.NullToEmpty(rec["suser"]);
            txt_snotes.Text = EmaxGlobals.NullToEmpty(rec["snotes"]);
           // txt_docid.Text = EmaxGlobals.NullToEmpty(rec["docno"]);
           txt_invno.Text= EmaxGlobals.NullToEmpty(rec["docno"]);
            HF_invid.Value= EmaxGlobals.NullToEmpty(rec["docid"]);
            ch_withoutinv.Checked= EmaxGlobals.NullToBool(rec["withoutinv"]);
            txt_netbvat.Text = EmaxGlobals.NullToEmpty(rec["netbvat"]);
            txt_vatvalue.Text = EmaxGlobals.NullToEmpty(rec["vatvalue"]);
            txt_netavat.Text = EmaxGlobals.NullToEmpty(rec["netavat"]);
            txt_restvalue.Text = EmaxGlobals.NullToEmpty(rec["restvalue"]);
            lbl_invdoc.Text = EmaxGlobals.NullToEmpty(rec["invdoc"]);
            hf_posyacc.Value = EmaxGlobals.NullToEmpty(rec["posyacc"]);
            hf_postst.Value = EmaxGlobals.NullToEmpty(rec["postst"]);
            if (EmaxGlobals.NullToBool(hf_postst.Value) == true)
            {
                lbl_postst.Text = "مرحل مستودعات";
                disable();
            }
            else
            {
                lbl_postst.Text = "";
                enable();
            }
            if (EmaxGlobals.NullToBool(hf_posyacc.Value) == true)
            {
                lbl_postacc.Text = "مرحل حـسابـات";
                disable();
                disable_pay();
                if (EmaxGlobals.NullToBool(hf_postst.Value) == false)
                {
                    btn_postst.Enabled = true;
                    btn_postst.CssClass = "enable";
                }
                else
                {
                    btn_postst.Enabled = false;
                    btn_postst.CssClass = "disable";
                    btn_postst.RenderMode = Secondary;
                }
            }
            else
            {
                lbl_postacc.Text = "";
                //  enable();
                enable_pay();
            }
        }
        /* void bind()
         {

             DataTable dt = ms.s_inv_sel_id(Convert.ToInt32(HF_invid.Value));
             txt_invno.Text = dt.Rows[0]["sinvno"].ToString();
            // txt_sinvdocno.Text = dt.Rows[0]["sinvdocno"].ToString();
             //cmb_sinvpay.Text = dt.Rows[0]["sinvpayname"].ToString();
             //cmb_sinvpay.Value = dt.Rows[0]["sinvpay"].ToString();
             //txt_sinvdata.Date = Convert.ToDateTime(dt.Rows[0]["txt_sinvdata"].ToString());
            // txt_sinvtime.Text = dt.Rows[0]["sinvtime"].ToString();
             txt_custid.Text = dt.Rows[0]["custid"].ToString();
             txt_custname.Text = dt.Rows[0]["custname"].ToString();
             txt_custvat.Text = dt.Rows[0]["custvat"].ToString();
             txt_custadd.Text = dt.Rows[0]["custadd"].ToString();
            // txt_suser.Text = dt.Rows[0]["suser"].ToString();
            // txt_snotes.Text = dt.Rows[0]["snotes"].ToString();
             //txt_netbvat.Text = dt.Rows[0]["netbvat"].ToString();
             //txt_vatvalue.Text = dt.Rows[0]["vatvalue"].ToString();
             //txt_netavat.Text = dt.Rows[0]["netavat"].ToString();
             //lbl_invdoc.Text = dt.Rows[0]["invdoc"].ToString();//.Replace("~/Files/","");
             //HF_invid.Value = dt.Rows[0]["sinvid"].ToString(); 
            // Visible();

         }
         void bind_rtn()
         {

             DataTable dt = ms.s_inv_sel_id(Convert.ToInt32(HF_rtninvid.Value));
              txt_rtnsinvno.Text = dt.Rows[0]["sinvno"].ToString();
              txt_sinvdocno.Text = dt.Rows[0]["sinvdocno"].ToString();
             cmb_sinvpay.Text = dt.Rows[0]["sinvpayname"].ToString();
             cmb_sinvpay.Value = dt.Rows[0]["sinvpay"].ToString();
             cmb_smanid.Text = dt.Rows[0]["smanname"].ToString();
             cmb_smanid.Value = dt.Rows[0]["smanid"].ToString();
             if (cmb_smanid.Text == "0"||cmb_smanid.Text=="")
             {
                 cmb_smanid.Text = null;
             }
             txt_sinvdata.Date = Convert.ToDateTime(dt.Rows[0]["txt_sinvdata"].ToString());
             txt_sinvtime.Text = dt.Rows[0]["sinvtime"].ToString();
             txt_custid.Text = dt.Rows[0]["custid"].ToString();
             txt_custname.Text = dt.Rows[0]["custname"].ToString();
             txt_custvat.Text = dt.Rows[0]["custvat"].ToString();
             txt_custadd.Text = dt.Rows[0]["custadd"].ToString();
              txt_suser.Text = dt.Rows[0]["suser"].ToString();
              txt_snotes.Text = dt.Rows[0]["snotes"].ToString();
             txt_netbvat.Text = dt.Rows[0]["netbvat"].ToString();
             txt_vatvalue.Text = dt.Rows[0]["vatvalue"].ToString();
             txt_netavat.Text = dt.Rows[0]["netavat"].ToString();
             lbl_invdoc.Text = dt.Rows[0]["invdoc"].ToString();//.Replace("~/Files/","");
             HF_invid.Value = dt.Rows[0]["docid"].ToString(); 
             txt_invno.Text= dt.Rows[0]["docno"].ToString();
             try
             {
                 ch_withoutinv.Checked = Convert.ToBoolean(dt.Rows[0]["withoutinv"]);
                 if (ch_withoutinv.Checked == true)
                 {
                     txt_invno.Enabled = false;
                     btn_search_inv.Enabled = false;
                     chk_rtnall.Enabled = false;
                     txt_invno.Text = string.Empty;
                 }
                 else {
                     txt_invno.Enabled = true;
                     btn_search_inv.Enabled = true;
                     chk_rtnall.Enabled = true;

                 }
             }
             catch 
             {
                 if (ch_withoutinv.Checked == null)

                     ch_withoutinv.Checked = false;
             }

             Visible();

         }
         void bind_items()
         {

             DataTable dt = ms.st_items_sel_itemid(HF_itemid.Value);
             if (dt.Rows.Count > 0)
             {
                 txt_item.Text = dt.Rows[0]["itemcode"].ToString();
                 txtitem_name.Text = dt.Rows[0]["itemname"].ToString();
                 txt_price.Text = dt.Rows[0]["fprice"].ToString();
                 txt_unit.Text = dt.Rows[0]["unitname"].ToString();
                 HF_unitid.Value = dt.Rows[0]["unitid"].ToString();
                 Hfvat.Value = dt.Rows[0]["vat"].ToString();
                 // HF_itemid.Value = dt.Rows[0]["itemid"].ToString();
             }
             else
             {
                 ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('هذا الكود غير موجود ')", true);
                 clear();
             }
         }
         //void bind_inv_items()
         //{
         //    DataTable dt = ms.st_items_sel_itemid(HF_itemid.Value);
         //    if (dt.Rows.Count > 0)
         //    {
         //       
         //        // HF_itemid.Value = dt.Rows[0]["itemid"].ToString();
         //    }
         //    else
         //    {
         //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('هذا الكود غير موجود ')", true);
         //        clear();
         //    }
         //}
         private void bind_invdtl()
         {
             DataTable dt = ms.s_rtn_invdtls_sel(Convert.ToInt32(Hf_invdtlID.Value));
             if (dt.Rows.Count > 0)
             {
                 HF_itemid.Value= dt.Rows[0]["itemid"].ToString();
                 txt_item.Text = dt.Rows[0]["itemcode"].ToString();
                 txtitem_name.Text = dt.Rows[0]["itemname"].ToString();
                 hf_qty.Value = dt.Rows[0]["qty"].ToString();
                 txt_qty.Text = dt.Rows[0]["qty"].ToString();
                 txt_price.Text = dt.Rows[0]["price"].ToString();
                 txt_unit.Text = dt.Rows[0]["unitname"].ToString();
                 HF_unitid.Value = dt.Rows[0]["unitid"].ToString();
                 txt_value.Text= dt.Rows[0]["value"].ToString();
                 txt_discp.Text= dt.Rows[0]["discp"].ToString();
                 hf_disc.Value= dt.Rows[0]["discvalue"].ToString();
                 txt_discvalue.Text= dt.Rows[0]["discvalue"].ToString();
                 txt_netvalue.Text= dt.Rows[0]["netvalue"].ToString();
                 txt_netvalue.Text= dt.Rows[0]["netvalue"].ToString();
                 txt_itemnotes.Text = dt.Rows[0]["itemnotes"].ToString();
                 Hfvat.Value = dt.Rows[0]["vatvalue"].ToString();
             }
         }*/
        void Visible()
        {
            PDetiles.Visible = true;
            p_invpay.Visible = true;
            cmb_paytype.SelectedIndex = 0;
        }
        /*    void clear_gvinvpay_select()
            {
                int row = gv_invpay.FocusedRowIndex;
                gv_invpay.Selection.UnselectRow(row);
            }
            void clear_gvs_invdtls_select()
            {
                int row = gvs_invdtls.FocusedRowIndex;
                gvs_invdtls.Selection.UnselectRow(row);
            }
        */


        List<object> GetParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_rtninvid.Value) == 0)
            {
                return new List<object> { txt_sinvdocno, txt_sinvdata, cmb_sinvpay, txt_custid, txt_custname, txt_custvat, txt_custadd, txt_custmobile, txt_suser, txt_snotes, txt_netbvat, txt_vatvalue, txt_netavat, txt_restvalue, lbl_invdoc, cmb_smanid, cmb_branchid, cmb_ccid, HF_invid, txt_invno, ch_withoutinv };
            }
            else
            {
                return new List<object> { txt_sinvdocno, txt_sinvdata, cmb_sinvpay, txt_custid, txt_custname, txt_custvat, txt_custadd, txt_custmobile, txt_suser, txt_snotes, txt_netbvat, txt_vatvalue, txt_netavat, txt_restvalue, lbl_invdoc, cmb_smanid, cmb_ccid, HF_rtninvid, HF_invid, txt_invno, ch_withoutinv };
            }
        }
        List<object> rtn_all()
        {

            return new List<object> { HF_rtninvid, txt_rtnsinvno, HF_invid };
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (ch_withoutinv.Checked == false && txt_invno.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('برجاء ادخال رقم الفاتوره او الاختيار بدون فاتوره')", true);
                    return;
                }
                var res = SaveData(EmaxGlobals.NullToIntZero(HF_rtninvid.Value) == 0 ? "s_rtn_inv_ins" : "s_rtninv_upd"
          , GetParam(), null,
                  EmaxGlobals.NullToIntZero(HF_rtninvid.Value) == 0 ? new List<string>() { "sinvnomax", "time", "id" } : new List<string>() { }, true, true,
                  new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue =cmb_branchid }
                ,new ParamObject() { ParamName = "sinvpayname", ParamValue = cmb_sinvpay }
                ,new ParamObject() { ParamName = "ccname", ParamValue = cmb_ccid }
                ,new ParamObject() { ParamName = "smanname", ParamValue = cmb_smanid } });
                if (res.errorid == 0)
                {
                    if (EmaxGlobals.NullToIntZero(HF_rtninvid.Value) != 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                    }
                    else
                    {
                        HF_rtninvid.Value = res.outputparams != null && res.outputparams.Count > 0 ? EmaxGlobals.NullToEmpty(res.outputparams["id"]) : "";
                        txt_sinvtime.Text = res.outputparams.ContainsKey("time") ? EmaxGlobals.NullToEmpty(res.outputparams["time"].ToString()) : "";
                        txt_rtnsinvno.Text = res.outputparams.ContainsKey("sinvnomax") ? EmaxGlobals.NullToEmpty(res.outputparams["sinvnomax"].ToString()) : "";
                        ch_withoutinv.ClientEnabled = false;
                    }

                    if (chk_rtnall.Checked == true)
                    {
                        var res2 = SaveData("s_rtn_all_invdtls_ins", rtn_all(), null, null, true, false, null);
                        gvs_invdtls.DataBind();
                        calac_Total();
                        var res3 = SaveData("s_rtn_inv_vat_upd", GetVatParam(), null, null, true, false, null);
                    }

                }
                //if (res.outputparams.ContainsKey("sinvnomax"))
                //{
                //    txt_sinvno.Text = EmaxGlobals.NullToEmpty(res.outputparams["sinvnomax"]);
                //}
                //Visible();
                gvs_invdtls.DataBind();
             
                PDetiles.Style.Add("display", "block");
                p_invpay.Style.Add("display", "block");

                #region old
                /*  if (txt_rtnsinvno.Text == "تلقائى")
                  {


                      (int erro_id, string error_msg,string inv_no, string time) = ms.s_rtninv_ins("مرتجع", txt_sinvdocno.Text, Convert.ToDateTime(txt_sinvdata.Text), Convert.ToInt16(cmb_sinvpay.SelectedItem.Value), cmb_sinvpay.SelectedItem.Text, txt_custid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_custid.Text), txt_custname.Text, txt_custvat.Text, txt_custadd.Text, txt_suser.Text, txt_snotes.Text, Convert.ToDecimal(txt_netbvat.Text), Convert.ToDecimal(txt_vatvalue.Text), Convert.ToDecimal(txt_netavat.Text), Convert.ToDecimal(txt_restvalue.Text), lbl_invdoc.Text, HF_invid.Value.Length == 0 ? 0 : Convert.ToInt32(HF_invid.Value),txt_invno.Text,ch_withoutinv.Checked, Convert.ToInt16(cmb_smanid.Value), cmb_smanid.Text);

                      if (erro_id == 0)
                      {
                          txt_rtnsinvno.Text = inv_no;
                          txt_sinvtime.Text = time.ToString();
                          if (chk_rtnall.Checked == true)
                          {
                              DataTable dt = ms.s_inv_sel_sinvid(txt_rtnsinvno.Text);
                              HF_rtninvid.Value = dt.Rows[0]["sinvid"].ToString();

                              (int erroidall, string errormsgall)= ms.s_rtn_allinvdtls_ins(Convert.ToInt16(HF_rtninvid.Value), txt_rtnsinvno.Text, Convert.ToInt32(HF_invid.Value));
                          }
                          Visible();

                      }
                  }
                  else
                  {
                      Visible();    

                      if (HF_rtninvid.Value == "")
                      {
                          DataTable dt = ms.s_inv_sel_sinvid(txt_rtnsinvno.Text);
                          HF_rtninvid.Value = dt.Rows[0]["sinvid"].ToString();
                      }
                      (int erro_id,string error_msg) = ms.s_rtninv_upd(int.Parse(HF_rtninvid.Value), txt_rtnsinvno.Text, txt_sinvdocno.Text, Convert.ToDateTime(txt_sinvdata.Text), Convert.ToInt16(cmb_sinvpay.SelectedItem.Value), cmb_sinvpay.SelectedItem.Text, txt_custid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_custid.Text), txt_custname.Text, txt_custvat.Text, txt_custadd.Text, txt_suser.Text, txt_snotes.Text, Convert.ToDecimal(txt_netbvat.Text), Convert.ToDecimal(txt_vatvalue.Text), Convert.ToDecimal(txt_netavat.Text), Convert.ToDecimal(txt_restvalue.Text), lbl_invdoc.Text, HF_invid.Value.Length == 0 ? 0 : Convert.ToInt32(HF_invid.Value), txt_invno.Text, ch_withoutinv.Checked, Convert.ToInt16(cmb_smanid.Value), cmb_smanid.Text);
                      if (erro_id == 0)
                      {
                          (int erroid_dtl, string errormsgdtl) = ms.s_rtn_invdtls_upd(0, Convert.ToInt16(HF_rtninvid.Value), 0, 0, 0, 0, 0, 0, 0, 0, 0, "", -1, 11, Convert.ToDateTime(txt_sinvdata.Text), txt_custid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_custid.Text), txt_rtnsinvno.Text, "", 0);
                          if (chk_rtnall.Checked == true)
                          {
                              DataTable dt = ms.s_inv_sel_sinvid(txt_rtnsinvno.Text);
                              HF_rtninvid.Value = dt.Rows[0]["sinvid"].ToString();

                              (int erroidalldtl, string errormsgalldtl) = ms.s_rtn_allinvdtls_ins(Convert.ToInt16(HF_rtninvid.Value), txt_rtnsinvno.Text, Convert.ToInt32(HF_invid.Value));
                          }
                          Visible();
                          // string s= "تم حفظ البيانات";
                          // ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetsuccess('" + error_msg + "')", true);

                          ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + error_msg + "')", true);
                      }
                  }*/
                #endregion

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
            clear_inv();


            // Required_cusname.Enabled = false;
            //Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]

        public static string Deletedata(int rtninvid)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("rtninvid", rtninvid);
            var res = SqlCommandHelper.ExecuteNonQuery("s_rtninv_del", dict, true);
            return JsonConvert.SerializeObject(res);
        }
        //protected void btn_delete_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //       // Required_cusname.Enabled = false;
        //        if (HF_rtninvid.Value == "")
        //        {
        //            DataTable dt = ms.s_inv_sel_sinvid(txt_rtnsinvno.Text);
        //            HF_rtninvid.Value = dt.Rows[0]["sinvid"].ToString();

        //        }
        //        (int erro_id, string error_msg) = ms.s_rtninv_del(Convert.ToInt32(HF_rtninvid.Value));
        //        clear_inv();
        //        PDetiles.Visible = false;
        //        p_invpay.Visible = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        if (HF_rtninvid.Value == "")
        //        {
        //            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('لا يوجد مرتجع للحذف')", true);
        //            return;
        //        }
        //        string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
        //    }
        //}

        //protected void HF_invid_ValueChanged(object sender, EventArgs e)
        //{
        //    if (HF_invid.Value != "")
        //    {
        //        clear();
        //        Clear_pay();
        //        bind();
        //    }
        //}
        protected void upload_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(Server.MapPath("~/Files/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Files/"));
                }

                if (txt_rtnsinvno.Text == "تلقائى")
                {
                    if (FileUpload1.HasFile == false && lbl_invdoc.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('لا يوجد ملف للتحميل')", true);
                        return;
                    }
                    FileUpload1.SaveAs(Server.MapPath("~/Files/" + FileUpload1.FileName));
                    string pathfile = "~/Files/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                    //Session["pathfile"] = pathfile;
                    lbl_invdoc.Text = pathfile;
                }
                else
                {
                    string pathfile = null;
                    if (FileUpload1.HasFile == true)
                    {

                        FileUpload1.SaveAs(Server.MapPath("~/Files/" + FileUpload1.FileName));
                        pathfile = "~/Files/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                        lbl_invdoc.Text = pathfile;
                    }

                    else if (FileUpload1.HasFile == false && lbl_invdoc.Text != null || lbl_invdoc.Text != "")
                    {
                        if (lbl_invdoc.Text == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('لا يوجد ملف للتحميل')", true);
                            return;
                        }
                        pathfile = lbl_invdoc.Text;
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
                if (lbl_invdoc.Text == "")
                {
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('لا يوجد ملف')", true);
                    ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetinfo('لا يوجد ملف')", true);
                    return;
                }
                string fileextantion = lbl_invdoc.Text;
                //int statrindex = ;
                fileextantion = fileextantion.Substring(fileextantion.Length - 3, 3);
                if (fileextantion == "lsx" || fileextantion == "LSX")
                    fileextantion = "xlsx";
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "File/" + fileextantion + "";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + txt_rtnsinvno.Text + "." + fileextantion + "");
                Response.TransmitFile(Server.MapPath(lbl_invdoc.Text));
                Response.Flush();
                Response.End();
            }

            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                if (msg.Contains("لا يمكن أن يكون StartIndex أقل من الصفر.\\r\\nاسم المعلمة: startIndex") || msg.Contains("StartIndex cannot be less than zero.\\r\\nParameter name: startIndex"))
                    msg = "لا يوجد ملف لتحميله";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);

            }
        }

        protected void gvs_invdtls_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                clear();
                if (gvs_invdtls.GetSelectedFieldValues("itemcode").Count != 0)
                {



                    HF_itemid.Value = gvs_invdtls.GetSelectedFieldValues("itemid")[0].ToString();
                    txt_item.Text = gvs_invdtls.GetSelectedFieldValues("itemcode")[0].ToString();
                    txtitem_name.Text = gvs_invdtls.GetSelectedFieldValues("itemname")[0].ToString();
                    txt_unit.Text = gvs_invdtls.GetSelectedFieldValues("unitname")[0].ToString();
                    HF_unitid.Value = gvs_invdtls.GetSelectedFieldValues("unitid")[0].ToString();
                    //hf_qty.Value = gvs_invdtls.GetSelectedFieldValues("qty")[0].ToString();
                    txt_qty.Text = gvs_invdtls.GetSelectedFieldValues("qty")[0].ToString();
                    txt_price.Text = gvs_invdtls.GetSelectedFieldValues("price")[0].ToString();
                    txt_value.Text = gvs_invdtls.GetSelectedFieldValues("value")[0].ToString();
                    txt_discp.Text = gvs_invdtls.GetSelectedFieldValues("discp")[0].ToString();
                    txt_discvalue.Text = gvs_invdtls.GetSelectedFieldValues("discvalue")[0].ToString();
                    txt_netvalue.Text = gvs_invdtls.GetSelectedFieldValues("netvalue")[0].ToString();
                    txtitem_vatvalue.Text = (gvs_invdtls.GetSelectedFieldValues("vatvalue")[0].ToString());
                    txt_itemnotes.Text = gvs_invdtls.GetSelectedFieldValues("itemnotes")[0].ToString();
                    HF_invdtlid.Value = gvs_invdtls.GetSelectedFieldValues("invdtlid")[0].ToString();

                }
                DataTable dt = ms.st_items_sel_item_code(txt_item.Text);
                if (dt.Rows.Count > 0)
                {
                    Hf_vat.Value = dt.Rows[0]["vat"].ToString();
                }
                DataTable dt1 = ms.s_rtn_invdtls_qty_sel(Convert.ToInt32(txt_rtnsinvno.Text), Convert.ToInt32(txt_invno.Text), Convert.ToInt32(HF_itemid.Value), 1, Convert.ToInt32(HF_invdtlid.Value));
                if (dt1.Rows.Count > 0)
                {
                    hf_qty.Value = dt1.Rows[0]["qty"].ToString();
                    //if (error == 1)
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "qty_rtn_chk()", true);
                    //    return;
                    //}

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + ex + "')", true);
            }
        }
        List<object> GetVatParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_rtninvid.Value) != 0)
            {
                return new List<object> { HF_rtninvid, txt_netbvat, txt_vatvalue, txt_netavat, txt_restvalue };
            }
            else
            {
                return null;
            }
        }
        List<object> GetParam_dtl()
        {
            if (EmaxGlobals.NullToIntZero(HF_invdtlid.Value) == 0)
            {
                return new List<object> { HF_rtninvid, HF_itemid, HF_unitid, HF_factor, txt_qty, txt_price, txt_value, txt_discp, txt_discvalue, txt_netvalue, txtitem_vatvalue, txt_itemnotes };
            }
            else
            {

                return new List<object> { HF_invdtlid, HF_rtninvid, HF_itemid, HF_unitid, HF_factor, txt_qty, txt_price, txt_value, txt_discp, txt_discvalue, txt_netvalue, txtitem_vatvalue, txt_itemnotes };
            }
        }

        protected void btn_save_dtls_Click(object sender, EventArgs e)
        {
            if (ch_withoutinv.Checked== false)
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("rtn_sinvno", txt_rtnsinvno.Text);
                dict.Add("sinvno", txt_invno.Text);
                dict.Add("itemid", HF_itemid.Value);
                dict.Add("unitid", HF_unitid.Value);
                dict.Add("invdtlid", HF_invdtlid.Value);
                if (EmaxGlobals.NullToIntZero(HF_invdtlid.Value) == 0)
                {
                    dict.Add("actiontype", 0);
                }
                else
                {
                    dict.Add("actiontype", 1);
                }
                var res1 = SqlCommandHelper.ExcecuteToDataTable("s_rtn_invdtls_qty_sel", dict).dataTable;

                if (res1.Rows.Count > 0)
                {
                    hf_qty.Value = res1.Rows[0]["qty"].ToString();
                    
                     if (EmaxGlobals.NullToZero(txt_qty.Text) > EmaxGlobals.NullToZero(hf_qty.Value))
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "qty_rtn_chk()", true);

                        return;
                    }
                    else if (EmaxGlobals.NullToZero(txt_qty.Text) == 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "qty_rtn_chk()", true);

                        return;
                    }

                }
            }
            var res = SaveData(EmaxGlobals.NullToIntZero(HF_invdtlid.Value) == 0 ? "s_rtn_invdtls_ins" : "s_rtn_invdtls_upd"
    , GetParam_dtl(), null,
            null, true, true,
            new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue =cmb_branchid }
                ,new ParamObject() { ParamName = "sinvpayname", ParamValue = cmb_sinvpay }
                ,new ParamObject() { ParamName = "ccname", ParamValue = cmb_ccid }
                ,new ParamObject() { ParamName = "smanname", ParamValue = cmb_smanid } });
            if (res.errorid == 0)
            {

                gvs_invdtls.DataBind();
                calac_Total();
                if (gvs_invdtls.VisibleRowCount > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "validate_other_inv()", true);

                }
                //PDetiles.Style.Add("display", "block");
                
                clear();
                //clear_gvs_invdtls_select();

                var res2 = SaveData("s_rtn_inv_vat_upd", GetVatParam(), null, null, true, false, null);

            }
            #region old
            /* if (txt_item.Text == "")
             {
                 ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('برجاء التأكد من البيانات المدخله')", true);
             }
             if (HF_invdtlid.Value == "" || HF_invdtlid.Value == "0")
             {
                 try
                 {
                     DataTable dt = ms.s_inv_sel_sinvid(txt_rtnsinvno.Text);
                     HF_rtninvid.Value = dt.Rows[0]["sinvid"].ToString();
                     //, txt_unit.Text
                     DataTable dt1 =ms.s_rtn_invdtls_qty_sel(Convert.ToInt32(txt_rtnsinvno.Text), Convert.ToInt32(txt_invno.Text), Convert.ToInt32(HF_itemid.Value),0, Convert.ToInt32(Hf_invdtlID.Value));
                     if (dt1.Rows.Count > 0)
                     {
                         hf_qty.Value = dt1.Rows[0]["qty"].ToString();
                         if (hf_qty.Value == "")
                         { 

                         }
                         else if (Convert.ToDecimal( txt_qty.Text ) > Convert.ToDecimal( hf_qty.Value))
                         {
                             ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "qty_rtn_chk()", true);
                             return;
                         }

                     }
                     (int error_id,string error_msg) = ms.s_rtn_invdtls_ins(Convert.ToInt16(HF_rtninvid.Value), Convert.ToInt16(HF_itemid.Value), Convert.ToInt16(HF_unitid.Value), Convert.ToDecimal(txt_qty.Text), Convert.ToDecimal(txt_price.Text), Convert.ToDecimal(txt_value.Text), Convert.ToDecimal(txt_discp.Text), Convert.ToDecimal(txt_discvalue.Text), Convert.ToDecimal(txt_netvalue.Text), Convert.ToDecimal(txtitem_vatvalue.Text), txt_itemnotes.Text, -1, 11, txt_sinvdata.Date, txt_custid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_custid.Text), txt_rtnsinvno.Text, "");
                     gvs_invdtls.DataBind();
                     ////// update  vatvalue,netavat,netavat
                     update_inv_vatvalue();
                     //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "function_save();", true);
                     clear();
                     //clear_gvs_invdtls_select();
                 }
                 catch (Exception ex)
                 {
                     string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                     ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
                 }
             }
             else
             {
                 try
                 {
                     DataTable dt = ms.st_items_sel_item_code(txt_item.Text);

                     HF_itemid.Value = dt.Rows[0]["itemid"].ToString();
                     //HF_unitid.Value =  dt.Rows[0]["unitid"].ToString());

                     DataTable dtt = ms.s_inv_sel_sinvid(txt_rtnsinvno.Text);
                     HF_rtninvid.Value = dtt.Rows[0]["sinvid"].ToString();
                     // (DataTable dt1, int error) = ms.s_rtn_invdtls_qty_sel(Convert.ToInt32(txt_rtnsinvno.Text), Convert.ToInt32(txt_invno.Text), Convert.ToInt32(HF_itemid.Value), 1);
                     //if (error == 1)
                     //{
                     //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "qty_rtn_chk()", true);
                     //    return;
                     //}
                     //if (dt1.Rows.Count > 0)
                     //{
                     //    hf_qty.Value = dt1.Rows[0]["qty"].ToString();


                     //}
                     (int erro_id, string error_msg) = ms.s_rtn_invdtls_upd(Convert.ToInt16(HF_invdtlid.Value), Convert.ToInt16(HF_rtninvid.Value), Convert.ToInt16(HF_itemid.Value), Convert.ToInt16(HF_unitid.Value), Convert.ToDecimal(txt_qty.Text), Convert.ToDecimal(txt_price.Text), Convert.ToDecimal(txt_value.Text), Convert.ToDecimal(txt_discp.Text), Convert.ToDecimal(txt_discvalue.Text), Convert.ToDecimal(txt_netvalue.Text), Convert.ToDecimal(txtitem_vatvalue.Text), txt_itemnotes.Text, -1, 11, Convert.ToDateTime(txt_sinvdata.Text), txt_custid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_custid.Text), txt_rtnsinvno.Text, "", 1);
                     gvs_invdtls.DataBind();
                     ////// update  vatvalue,netavat,netavat
                     update_inv_vatvalue();
                     // ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "function_save();", true);
                     clear();
                     //clear_gvs_invdtls_select();

                 }
                 catch (Exception ex)
                 {

                     string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

                     ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);

                 }

             }*/
            #endregion
        }

        protected void txt_item_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = ms.st_items_sel_item_code(txt_item.Text);
                if (dt.Rows.Count > 0)
                {
                    txtitem_name.Text = dt.Rows[0]["itemname"].ToString();
                    txt_price.Text = dt.Rows[0]["fprice"].ToString();
                    txt_unit.Text = dt.Rows[0]["unitname"].ToString();
                    HF_unitid.Value = dt.Rows[0]["unitid"].ToString();
                    HF_itemid.Value = dt.Rows[0]["itemid"].ToString();
                    Hf_vat.Value = dt.Rows[0]["vat"].ToString();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('هذا الكود غير موجود ')", true);
                    clear();
                }
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
            }
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static string Deletedatadtls(int invdtlid)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("invdtlid", invdtlid);


            var res = SqlCommandHelper.ExecuteNonQuery("s_rtn_invdtls_del", dict, true);
            return JsonConvert.SerializeObject(res);


        }


        //protected void btn_delete_dtls_Click(object sender, EventArgs e)
        //{
        //    try


        //    {
        //        if (HF_invdtlid.Value == "" || HF_invdtlid.Value == null)
        //        {
        //            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('برجاء اختيار الصنف للحذف')", true);

        //        }
        //        else
        //        {
        //            (int erro_id, string error_msg) = ms.s_rtn_invdtls_del(Convert.ToInt16(HF_invdtlid.Value));
        //            gvs_invdtls.Selection.CancelSelection();
        //            gvs_invdtls.DataBind();
        //            ////// update  vatvalue,netavat,netavat
        //            update_inv_vatvalue();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
        //    }


        //}


        //void update_inv_vatvalue()
        //{
        //    ////// update  vatvalue,netavat,netavat
        //    try
        //    {

        //        if (HF_invid.Value == "")
        //        {
        //            HF_invid.Value = "-1";
        //        }
        //        (int erro_id, string error_msg) = ms.s_rtninv_upd(int.Parse(HF_rtninvid.Value), txt_rtnsinvno.Text, txt_sinvdocno.Text, Convert.ToDateTime(txt_sinvdata.Text), Convert.ToInt16(cmb_sinvpay.SelectedItem.Value), cmb_sinvpay.SelectedItem.Text, txt_custid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_custid.Text), txt_custname.Text, txt_custvat.Text, txt_custadd.Text, txt_suser.Text, txt_snotes.Text, Convert.ToDecimal(txt_netbvat.Text), Convert.ToDecimal(txt_vatvalue.Text), Convert.ToDecimal(txt_netavat.Text), Convert.ToDecimal(txt_restvalue.Text), lbl_invdoc.Text, Convert.ToInt32(HF_invid.Value), txt_invno.Text, ch_withoutinv.Checked, Convert.ToInt16(cmb_smanid.Value), cmb_smanid.Text);
        //        if (erro_id == 0)
        //        {
        //            if (HF_invid.Value == "-1")
        //                HF_invid.Value = "";
        //        }
        //        clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
        //    }
        //}
        DataTable GvdetailSource()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("sinvid", HF_rtninvid.Value);

            return SqlCommandHelper.ExcecuteToDataTable("s_rtn_invdtls_gv_sel", dict).dataTable;

        }
        protected void gvs_invdtls_DataBinding(object sender, EventArgs e)
        {
            gvs_invdtls.DataSource = GvdetailSource();
        }
        protected void gvs_invdtls_DataBound(object sender, EventArgs e)
        {
            //ASPxGridView gridView = sender as ASPxGridView;
            ////  gridView.JSProperties["cpSummary"] = gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]);
            //if (gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]) == null || gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]).ToString() == "")
            //{
            //    return;
            //}
            ////شامل الضريبه
            //if (HF_vattype.Value == "1")
            //{
            //    txt_netavat.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]).ToString();
            //    txt_vatvalue.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["vatvalue"]).ToString();
            //    txt_netbvat.Text = (Convert.ToDecimal(txt_netavat.Text) - Convert.ToDecimal(txt_vatvalue.Text)).ToString();
            //    if (txt_restvalue.Text == "0")
            //        txt_restvalue.Text = txt_netavat.Text;
            //}
            /////غير شامل الصريبه
            //else if (HF_vattype.Value == "2")
            //{
            //    txt_netbvat.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]).ToString();
            //    txt_vatvalue.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["vatvalue"]).ToString();
            //    txt_netavat.Text = (Convert.ToDecimal(txt_netbvat.Text) + Convert.ToDecimal(txt_vatvalue.Text)).ToString();
            //    if (txt_restvalue.Text == "0")
            //        txt_restvalue.Text = txt_netavat.Text;
            //}
            //else if (HF_vattype.Value == "3")
            //{
            //    txt_netbvat.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]).ToString();
            //    txt_netavat.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]).ToString();
            //    txt_vatvalue.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["vatvalue"]).ToString();
            //    if (txt_restvalue.Text == "0")
            //        txt_restvalue.Text = txt_netavat.Text;
            //}
            ////if (hf_netbvat.Value != txt_netbvat.Text && hf_netbvat.Value!="")
            ////{
            ////    var res2 = SaveData("s_inv_vat_upd", GetVatParam(), null, null, true, false, null);
            ////    hf_netbvat.Value = txt_netbvat.Text;
            ////}

            ////else
            ////{
            //try
            //{
            //    decimal rest = EmaxGlobals.NullToZero(gv_invpay.GetTotalSummaryValue(gv_invpay.TotalSummary["payvalue"]));

            //    txt_restvalue.Text = (Convert.ToDecimal(txt_netavat.Text) - rest).ToString();
            //}
            //catch { }
            //}
           
        }
        void calac_Total()
        {
            //ASPxGridView gridView = sender as ASPxGridView;
            //  gridView.JSProperties["cpSummary"] = gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]);
            if (gvs_invdtls.GetTotalSummaryValue(gvs_invdtls.TotalSummary["netvalue"]) == null || gvs_invdtls.GetTotalSummaryValue(gvs_invdtls.TotalSummary["netvalue"]).ToString() == "")
            {
                return;
            }
            //شامل الضريبه
            if (HF_vattype.Value == "1")
            {
                txt_netavat.Text = Math.Round(EmaxGlobals.NullToZero(gvs_invdtls.GetTotalSummaryValue(gvs_invdtls.TotalSummary["netvalue"]).ToString()), 2).ToString();
                txt_vatvalue.Text = Math.Round(EmaxGlobals.NullToZero(gvs_invdtls.GetTotalSummaryValue(gvs_invdtls.TotalSummary["vatvalue"]).ToString()), 2).ToString();
                txt_netbvat.Text = Math.Round(EmaxGlobals.NullToZero(EmaxGlobals.NullToZero(txt_netavat.Text) - EmaxGlobals.NullToZero(txt_vatvalue.Text)), 2).ToString();
                if (txt_restvalue.Text == "0")
                    txt_restvalue.Text = txt_netavat.Text;
            }
            ///غير شامل الصريبه
            else if (HF_vattype.Value == "2")
            {
                txt_netbvat.Text = Math.Round(EmaxGlobals.NullToZero(gvs_invdtls.GetTotalSummaryValue(gvs_invdtls.TotalSummary["netvalue"]).ToString()), 2).ToString();
                txt_vatvalue.Text = Math.Round(EmaxGlobals.NullToZero(gvs_invdtls.GetTotalSummaryValue(gvs_invdtls.TotalSummary["vatvalue"]).ToString()), 2).ToString();
                txt_netavat.Text = Math.Round(EmaxGlobals.NullToZero(EmaxGlobals.NullToZero(txt_netbvat.Text) + EmaxGlobals.NullToZero(txt_vatvalue.Text)), 2).ToString();
                if (txt_restvalue.Text == "0")
                    txt_restvalue.Text = txt_netavat.Text;
            }
            else if (HF_vattype.Value == "3")
            {
                txt_netbvat.Text = Math.Round(EmaxGlobals.NullToZero(gvs_invdtls.GetTotalSummaryValue(gvs_invdtls.TotalSummary["netvalue"]).ToString()), 2).ToString();
                txt_netavat.Text = Math.Round(EmaxGlobals.NullToZero(gvs_invdtls.GetTotalSummaryValue(gvs_invdtls.TotalSummary["netvalue"]).ToString()), 2).ToString();
                txt_vatvalue.Text = Math.Round(EmaxGlobals.NullToZero(gvs_invdtls.GetTotalSummaryValue(gvs_invdtls.TotalSummary["vatvalue"]).ToString()), 2).ToString();
                if (txt_restvalue.Text == "0")
                    txt_restvalue.Text = txt_netavat.Text;
            }
            //if (hf_netbvat.Value != txt_netbvat.Text && hf_netbvat.Value!="")
            //{
            //    var res2 = SaveData("s_inv_vat_upd", GetVatParam(), null, null, true, false, null);
            //    hf_netbvat.Value = txt_netbvat.Text;
            //}

            //else
            //{
            try
            {
                decimal rest = Math.Round(EmaxGlobals.NullToZero(gv_invpay.GetTotalSummaryValue(gv_invpay.TotalSummary["payvalue"])), 2);

                txt_restvalue.Text = Math.Round(EmaxGlobals.NullToZero(txt_netavat.Text) - rest, 2).ToString();
            }
            catch { }
            //}
        }
        protected void gvs_invdtls_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            var post = e.Parameters.Split(',');
            if (post.Length != 1)
            {
                if (EmaxGlobals.NullToEmpty(post[0]) != "")
                {
                    lbl_invdoc.Text = post[0].ToString();
                }
                else
                {
                    lbl_invdoc.Text = string.Empty;
                }
                if (EmaxGlobals.NullToBool(post[1]) == true)
                {
                    lbl_postst.Text = "مرحل مستودعات";
                    disable();
                     


                }
                else
                {
                    lbl_postst.Text = "";
                    enable();                   
                }
                if (EmaxGlobals.NullToBool(post[2]) == true)
                {
                    lbl_postacc.Text = "مرحل حـسابـات";
                    disable();
                    btn_postacc.Enabled = false;
                    btn_postacc.CssClass = "disable";
                    btn_postacc.RenderMode = Secondary;
                    disable_pay();
                    if (EmaxGlobals.NullToBool(post[1]) == false)
                    {
                        btn_postst.Enabled = true;
                        btn_postst.CssClass = "enable";
                    }
                    else
                    {
                        btn_postst.Enabled = false;
                        btn_postst.CssClass = "disable";
                        btn_postst.RenderMode = Secondary;
                    }

                }
                else
                {
                    lbl_postacc.Text = "";
                   // enable();
                    enable_pay();
                }
            }
            if (post.Length > 3)
            {
                if (post[3] != "" || post[3] != null)
                {
                    lbl_vochrno.Text = post[3];
                    lbl_vochrno.NavigateUrl = "~/GL/Vouchers.aspx" + "?vchrno=" + lbl_vochrno.Text + "";
                }
            }
            if (cmb_sinvpay.SelectedItem.Value.ToString() == "2")
            {
                disable_pay();
                //btn_postacc.Enabled = true;
                //btn_postacc.CssClass = "enable";
                if (post.Length == 2 && EmaxGlobals.NullToBool(post[2]) == true)
                {
                    disable_pay();
                }
            }
            else if (cmb_sinvpay.SelectedItem.Value.ToString() == "1" && (post.Length == 3 && EmaxGlobals.NullToBool(post[2]) != true))
            {
                enable_pay();
            }
            if (txt_invno.Text.Length > 0)
            {
                chk_rtnall.ClientEnabled = false;
                txt_invno.ClientEnabled = false;
                ch_withoutinv.ClientEnabled = false;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "document.querySelector('#btn_search_inv').disabled = true;", true);
            }
            else
            {
            //    chk_rtnall.ClientEnabled = true;
            //    txt_invno.ClientEnabled = true;
               ch_withoutinv.Checked = true;
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "document.querySelector('#btn_search_inv').disabled = false;", true);
            }
            gvs_invdtls.DataBind();
            if(gvs_invdtls.VisibleRowCount>0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "validate_other_inv()", true);

            }

            gv_invpay.DataBind();
            if(post.Length>4)
            {
                if (post[4] == "1")
                {
                    
                }

            }
            else
            {
                calac_Total();
            }
    
            PDetiles.Style.Add("display", "block");
            p_invpay.Style.Add("display", "block");
            if (EmaxGlobals.NullToEmpty(HF_itemid.Value) != "")
            {
                txt_qty.Focus();
            }
            cmb_branchid.ClientEnabled = false;
            //if (ch_withoutinv.Checked == true)
            //{
            //    btn_attach.Enabled = true;
            //    btn_attach.CssClass = "enable";
            //}
            //else
            //{
            //    btn_attach.Enabled = false;
            //    btn_attach.CssClass = "disable";
            //    btn_attach.RenderMode = Secondary;
            //}

        }
        protected void HF_itemid_ValueChanged(object sender, EventArgs e)
        {
            if (HF_itemid.Value != "")
            {

                txt_item.Text = string.Empty;
                txt_unit.Text = string.Empty;
                txt_qty.Text = "1";
                txt_price.Text = "0";
                txt_value.Text = "0";
                txt_discp.Text = "0";
                txt_discvalue.Text = "0";
                txt_netvalue.Text = "0";

                txtitem_vatvalue.Text = "0";
                txt_itemnotes.Text = string.Empty;
                txtitem_name.Text = string.Empty;
                HF_invdtlid.Value = "";

                Hf_vat.Value = "";
                //bind_items();
            }
        }

        protected void btn_new_dtls_Click(object sender, EventArgs e)
        {

            clear();
            //clear_gvs_invdtls_select();

        }

        protected void Hf_cusid_ValueChanged(object sender, EventArgs e)
        {
            if (Hf_cusid.Value != "")
            {
                DataTable dt = ms.s_customers_sel_custid(Convert.ToInt32(Hf_cusid.Value));
                if (dt.Rows.Count > 0)
                {
                    txt_custid.Text = dt.Rows[0]["custcode"].ToString();
                    txt_custname.Text = dt.Rows[0]["custname"].ToString();
                    txt_custadd.Text = dt.Rows[0]["custadd"].ToString();
                    txt_custvat.Text = dt.Rows[0]["custvat"].ToString();

                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('هذا الكود غير موجود ')", true);
                    //txt_custid.Text = "0";
                }
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "cus_validate();", true);
            }
        }

        //protected void cmb_sinvpay_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmb_sinvpay.SelectedIndex == 1)
        //    {
        //        txt_custid.Text = "";
        //        //txt_cus_id_req.Enabled = true;
        //    }
        //}



        //protected void gv_invpay_SelectionChanged(object sender, EventArgs e)
        //{
        //    //Clear_pay();
        //    if (gv_invpay.GetSelectedFieldValues("payno").Count != 0)
        //    {

        //        txt_payno.Text = gv_invpay.GetSelectedFieldValues("payno")[0].ToString();
        //        txt_payref.Text = gv_invpay.GetSelectedFieldValues("payref")[0].ToString();
        //        txt_payvalue.Text = gv_invpay.GetSelectedFieldValues("payvalue")[0].ToString();

        //        cmb_paytype.Text = gv_invpay.GetSelectedFieldValues("payname")[0].ToString();
        //        cmb_paytype.Value = gv_invpay.GetSelectedFieldValues("paytypeid")[0].ToString();

        //        Hf_payid.Value = gv_invpay.GetSelectedFieldValues("invpayid")[0].ToString();
        //    }
        //}
        List<object> GetParam_pay()
        {
            if (EmaxGlobals.NullToIntZero(Hf_payid.Value) == 0)
            {
                return new List<object> { HF_rtninvid, cmb_paytype, txt_payvalue, txt_payno, txt_payref, cmb_paychartid };
            }
            else
            {

                return new List<object> { Hf_payid, HF_rtninvid, cmb_paytype, txt_payvalue, txt_payno, txt_payref, cmb_paychartid };
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
                var res = SaveData(EmaxGlobals.NullToIntZero(Hf_payid.Value) == 0 ? "s_rtn_invpay_ins" : "s_rtn_invpay_upd"
    , GetParam_pay(), null,
            null, true, true,
            new List<ParamObject>() { new ParamObject() { ParamName = "payname", ParamValue = cmb_paytype } });
                if (res.errorid == 0)
                {
                    gv_invpay.DataBind();
                    Clear_pay();
                    var res2 = SaveData("s_rtn_inv_vat_upd", GetVatParam(), null, null, true, false, null);


                }
                #region OLD
                /* if (txt_payvalue.Text == "")
                 {
                     ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('برجاء ادخال القيمه اولا')", true);
                 }
                 if (Hf_payid.Value == "")
                 {

                     (int error_id, string error_msg) = ms.s_rtn_invpay_ins(Convert.ToInt16(HF_rtninvid.Value), Convert.ToInt16(cmb_paytype.SelectedItem.Value), Convert.ToDouble(txt_payvalue.Text), txt_payno.Text, txt_payref.Text, txt_sinvdata.Date, txt_custid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_custid.Text), txt_rtnsinvno.Text, "");


                     if (error_id == 1)
                     {
                         ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                     }
                     else
                     {
                         gv_invpay.DataBind();
                         update_inv_vatvalue();
                         Clear_pay();
                         //clear_gvinvpay_select();

                     }
                 }
                 else
                 {
                     (int error_id, string error_msg) = ms.s_rtn_invpay_upd(Convert.ToInt32(Hf_payid.Value), Convert.ToInt16(HF_rtninvid.Value), Convert.ToInt16(cmb_paytype.SelectedItem.Value), Convert.ToDouble(txt_payvalue.Text), txt_payno.Text, txt_payref.Text, txt_sinvdata.Date, txt_custid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_custid.Text), txt_rtnsinvno.Text, "", 1);
                     if (error_id == 1)
                     {
                         ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                     }
                     else
                     {
                         gv_invpay.Selection.CancelSelection();
                         gv_invpay.DataBind();
                         update_inv_vatvalue();
                         Clear_pay();
                         //clear_gvinvpay_select();
                     }
                 }*/
                #endregion
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
            }
        }

        protected void brn_new_pay_Click(object sender, EventArgs e)
        {
            Clear_pay();

            //clear_gvinvpay_select();

        }

        //protected void btn_delete_pay_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Hf_payid.Value == "" || Hf_payid.Value == null)
        //        {
        //            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('برجاء الاختيار  للحذف')", true);

        //        }
        //        else
        //        {

        //            (int erro_id, string error_msg) = ms.s_invpay_del(Convert.ToInt32(Hf_payid.Value));
        //            gv_invpay.DataBind();
        //            update_inv_vatvalue();
        //            Clear_pay();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
        //    }
        //}

        protected void gv_invpay_DataBound(object sender, EventArgs e)
        {
            ASPxGridView gridView = sender as ASPxGridView;

            if (gridView.GetTotalSummaryValue(gridView.TotalSummary["payvalue"]) == null || gridView.GetTotalSummaryValue(gridView.TotalSummary["payvalue"]).ToString() == "")
            {
                return;
            }
            decimal rest = EmaxGlobals.NullToZero(gridView.GetTotalSummaryValue(gridView.TotalSummary["payvalue"]).ToString());

            txt_restvalue.Text = (EmaxGlobals.NullToZero(txt_netavat.Text) - rest).ToString();
        }
        protected void gv_invpay_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {

            gv_invpay.DataBind();
            PDetiles.Style.Add("display", "block");
            p_invpay.Style.Add("display", "block");
            cmb_branchid.ClientEnabled = false;
            Clear_pay();
        }
        DataTable GvpaySource()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("inv_id", HF_rtninvid.Value);

            return SqlCommandHelper.ExcecuteToDataTable("s_rtn_invpay_sel", dict).dataTable;

        }
        protected void gv_invpay_DataBinding(object sender, EventArgs e)
        {
            gv_invpay.DataSource = GvpaySource();
        }
        //protected void btn_print_Click(object sender, ImageClickEventArgs e)
        //{
        //    if (HF_invid.Value == "")
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('لم يتم اختيار فاتوره للطباعه')", true);
        //        return;
        //    }
        //    //  Response.Write("<script>window.open('/Report/Report.aspx?sinvid=" + HF_invid.Value +"/ ','_blank');</script>");
        //    Response.Redirect("/Sales/Report.aspx?sinvid=" + HF_invid.Value);
        //}


        protected void HF_rtninvid_ValueChanged(object sender, EventArgs e)
        {
            if (HF_rtninvid.Value != "")
            {
                ch_withoutinv.Checked = false;
                //bind_rtn();
            }
        }

        protected void ch_withoutinv_CheckedChanged(object sender, EventArgs e)
        {

            if (ch_withoutinv.Checked == true)
            {
                // txt_invno.Enabled = false;
                txt_invno.ClientEnabled = false;
                //btn_search_inv.Enabled = false;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "document.querySelector('#btn_search_inv').disabled = true;", true);
                chk_rtnall.ClientEnabled = false;
                chk_rtnall.Checked = false;
                txt_invno.Text = string.Empty;
                HF_invid.Value= string.Empty;
                btn_attach.Enabled = true;
                btn_attach.CssClass = "enable";
            }
            else
            {
                txt_invno.ClientEnabled = true;

                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "document.querySelector('#btn_search_inv').disabled = false;", true);
                // btn_search_inv.Enabled = true;
                chk_rtnall.ClientEnabled = true;
                btn_attach.Enabled = false;
                btn_attach.CssClass = "disable";
                btn_attach.RenderMode = Secondary;
            }
        }

        //protected void Hf_invdtlID_ValueChanged(object sender, EventArgs e)
        //{
        //    if (Hf_invdtlID.Value != "")
        //    {
        //        //bind_invdtl();
        //    }
        //}
        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                // gvitemsExporter.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType=ExportType.WYSIWYG});
                ExportingDevExpressUtil.Export(gvitemsExporter, "اصناف الفاتوره", 1, Request.GetOwinContext().Request.User.Identity.Name, gvs_invdtls.GetSelectedFieldValues("invdtlid").Count != 0, false, "أصناف الفاتوره رقم " + txt_rtnsinvno.Text);
              
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_attach_Click(object sender, EventArgs e)
        {
            try
            {

                if (!Directory.Exists(Server.MapPath("~/Files/Sales/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Files/Sales/"));
                }
                //Upload and save the file
                string excelPath = Server.MapPath("~/Files/Sales/") + Path.GetFileName(FileUpload2.PostedFile.FileName);
                //var  f=Request.Files[0];
                FileUpload2.SaveAs(excelPath);

                string conString = string.Empty;
                string extension = Path.GetExtension(FileUpload2.PostedFile.FileName);
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

                var res = SaveData("s_rtn_inv_itemexcel_ins", new List<object> { HF_rtninvid }, null,
                null, true, true, null
                , null);
                if (res.errorid == 0)
                {
                    clear();
                    gvs_invdtls.DataBind();

                }
                else
                {
                    if (res.errormsg.Contains("FK_s_invdtls_s_inv") == true)
                    {
                        Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath);
                    }
                    string msg = HttpUtility.JavaScriptStringEncode(res.errormsg);

                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('" + msg + "')", true);

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
                    gvs_invdtls.DataBind();

                }
            }
            catch (Exception ex)
            {


                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                //  ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo(" + ex.Message + ")", true);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);

            }
        }

        protected void cmb_paytype_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("paytypeid", cmb_paytype.Value);
            dict.Add("branchid", cmb_branchid.Value);

            var res = SqlCommandHelper.ExcecuteToDataTable("s_inv_paychart", dict, false);
            cmb_paychartid.DataSource = res.dataTable;
            cmb_paychartid.TextField = "paychartname";
            cmb_paychartid.ValueField = "paychartid";
            cmb_paychartid.DataBind();
            if (res.dataTable.Rows.Count > 0)
            {
                cmb_paychartid.SelectedIndex = 0;
            }
            else
            {
                cmb_paychartid.Text = "";
                cmb_paychartid.Value = "";
            }
        }

        protected async void btn_print_Click1(object sender, EventArgs e)
        {
            var dict = new Dictionary<string, object>();
            RestClient restSharp = new RestClient(ConfigurationManager.AppSettings["apiroot"] + "/VanSalesService/invoice/GetInvMasterQrData");
            RestRequest restRequest = new RestRequest();
            restRequest.Method = Method.Post;

            //restRequest.AddHeader("compvatno", SqlCommandHelper.GetTokenKey("compvatno", Request.Cookies["Token"].Value));
            //restRequest.AddHeader("fyear", SqlCommandHelper.GetTokenKey("fyear", Request.Cookies["Token"].Value));
            restRequest.AddQueryParameter("invno", txt_rtnsinvno.Text);
            restRequest.AddQueryParameter("compenyname", SqlCommandHelper.GetTokenKey("compneyname", Request.Cookies["Token"].Value));
            restRequest.AddQueryParameter("vatnumber", SqlCommandHelper.GetTokenKey("compvatno", Request.Cookies["Token"].Value));
            RestResponse response = await restSharp.ExecuteAsync(restRequest);
            if (response.IsSuccessful)
            {
                var ff = JObject.Parse(response.Content)["qrdata"].ToString();
                dict.Add("inv_id", HF_rtninvid.Value);

                //TlvFormat t = EmaxGlobals.GetQrCodeDateData((SqlCommandHelper.GetTokenKey("compneyname", Request.Cookies["Token"].Value)
                //    , SqlCommandHelper.GetTokenKey("compvatno", Request.Cookies["Token"].Value),
                //    txt_sinvdata.Date,EmaxGlobals.NullToZeroDouble( txt_netavat.Text)
                //    , EmaxGlobals.NullToZeroDouble(txt_vatvalue.Text));
                dict.Add("qrdata", ff);
                /// var dict = new Dictionary<string, object>();


                PrintPage("sales/s_rtninv_page.repx", dict);
            }
            else
            {
                Response.Write(response.Content);

            }
        }

   



        //        protected void txt_invno_TextChanged(object sender, EventArgs e)
        //        {
        //            clear();
        //            DataTable dt = ms.s_rtn_inv_sel_invcode(txt_invno.Text);
        //            if (dt.Rows.Count > 0)
        //            {

        //            txt_custid.Text = dt.Rows[0]["custid"].ToString();
        //            txt_custname.Text = dt.Rows[0]["custname"].ToString();
        //            txt_custvat.Text = dt.Rows[0]["custvat"].ToString();
        //            txt_custadd.Text = dt.Rows[0]["custadd"].ToString();
        //            HF_invid.Value = dt.Rows[0]["sinvid"].ToString(); 
        //           // Visible();
        //        }
        //                else
        //                {
        //                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('هذه الفاتوره غير موجوده ')", true);
        //                txt_invno.Text= string.Empty;
        //                txt_custid.Text = string.Empty;
        //                txt_custname.Text = string.Empty;
        //                txt_custvat.Text = string.Empty;
        //                txt_custadd.Text = string.Empty;
        //            }
        //}

        //protected void txt_custid_TextChanged(object sender, EventArgs e)
        //{
        //    DataTable dt = ms.s_customers_sel_custcode(txt_custid.Text);
        //    if (dt.Rows.Count > 0)
        //    {
        //        txt_custname.Text = dt.Rows[0]["custname"].ToString();
        //        txt_custadd.Text = dt.Rows[0]["custadd"].ToString();
        //        txt_custvat.Text = dt.Rows[0]["custvat"].ToString();
        //        Hf_cusid.Value = dt.Rows[0]["custid"].ToString();

        //    }
        //    else
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('هذا العميل غير موجود ')", true);
        //        txt_custid.Text = string.Empty;
        //        txt_custname.Text = string.Empty;
        //        txt_custadd.Text = string.Empty;
        //        txt_custvat.Text = string.Empty;
        //    }
        //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "cus_validate();", true);
        //}
    }

}