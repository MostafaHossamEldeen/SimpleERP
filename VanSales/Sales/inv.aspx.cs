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
using System.Web.UI.HtmlControls;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using DevExpress.XtraReports.UI;
using Emax.Core;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace VanSales
{
    public partial class inv : EmaxBasepage
    {
        public ButtonRenderMode Secondary { get; private set; }

        //SalesInv ms = new SalesInv();

        protected override void OnInit(EventArgs e)
        {
            // Pop_items.txt_key_valuechanged += new EventHandler(Pop_items_txt_key_valuechanged);
            pageid = "4";

            base.OnInit(e);

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            // btn_print.Attributes.Add("onclick", "this.form.target='_blank'");
            //lbl_msg.Text = ""; 

            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_sinvpay, "compid,table_name", "9,sys_fillcomp", "citemid", "citemname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_smanid, "compid,table_name", "0,s_sman", "smanid", "smanname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_ccid, "compid,table_name", "0,sys_costcenter", "ccid", "ccname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_paytype, "compid,table_name,model", "0,sys-paytype,5", "paytypeid", "paytname");
              
                HF_sinvid.Value = Request.Params["sinvid"];
                cmb_smanid.SelectedIndex = -1;
                cmb_ccid.SelectedIndex = -1;
                txt_sinvdata.Date = DateTime.Now;
                cmb_sinvpay.SelectedIndex = 0;
                cmb_branchid.SelectedIndex = 0;
                cmb_paytype.SelectedIndex = 0;
                txt_suser.Text = Context.User.Identity.Name;

                HF_vattype.Value = SqlCommandHelper.GetTokenKey("vattype", Request.Cookies["Token"].Value);

                //txt_price.ReadOnly = !EmaxGlobals.NullToBool(SqlCommandHelper.GetTokenKey("sprice", Request.Cookies["Token"].Value));
                if (Request.QueryString["sinvno"] != null && Request.QueryString["sinvno"] != string.Empty)
                {
                    txt_sinvno.Text = Request.Params["sinvno"];
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("sinvno", txt_sinvno.Text);
                    var f = SqlCommandHelper.ExcecuteToDataTable("[s_inv_sel_code]", dict).dataTable;
                    BindData(f.Rows[0]);
                    gvs_invdtls.DataBind();
                    gv_invpay.DataBind();
                    PDetiles.Style.Add("display", "block");
                    p_invpay.Style.Add("display", "block");
                    cmb_branchid.ClientEnabled = false;
                }
                //lbl_msg.Text = "";
            }
            if (txt_payvalue.Text=="0")
            {
                Util.GenerateCombobox("s_inv_paychart", cmb_paychartid, "paytypeid,branchid", "" + EmaxGlobals.NullToEmpty(cmb_paytype.Value) + "," + EmaxGlobals.NullToEmpty(cmb_branchid.Value) + "", "paychartid", "paychartname");
            }
            //ClientScript.RegisterOnSubmitStatement(btn_delete.GetType(), "confirm", "return confirm('هل تريدالحذف؟');");
            // );
        }

        private void Pop_items_txt_key_valuechanged(object sender, EventArgs e)
        {
            //var ggg = Pop_items.Value;
        }
        #region  clear methods
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
            hf_qty.Value = "";
            hf_disc.Value = "";



        }
        void clear_inv()
        {
            clear();
            Clear_pay();
            txt_sinvno.Text = string.Empty;
            txt_sinvno.Text = "تلقائى";
            txt_sinvdocno.Text = string.Empty;

            txt_sinvdata.Text = string.Empty;
            txt_sinvtime.Text = string.Empty;
            cmb_sinvpay.Text = string.Empty;
            cmb_sinvpay.Value = string.Empty;
            cmb_smanid.Text = string.Empty;
            cmb_smanid.Value = string.Empty;
            cmb_ccid.Text = string.Empty;
            cmb_ccid.Value = string.Empty;
            cmb_branchid.ClientEnabled = true;
            cmb_branchid.SelectedIndex = 0;
            // cmb_sinvpay.Items.Clear();
            //dll_snature.Items.Clear();
            // txt_cus_id_req.Enabled = false;
            Hf_cusid.Value = string.Empty;
            txt_custid.Text = string.Empty;
            txt_custvat.Text = string.Empty;
            txt_custname.Text = string.Empty;
            txt_custadd.Text = string.Empty;
            txt_custmobile.Text = string.Empty;
            txt_suser.Text = Context.User.Identity.Name;
            txt_snotes.Text = string.Empty;
            txt_restvalue.Text = "0";
            txt_netbvat.Text = "0";
            txt_vatvalue.Text = "0";
            txt_netavat.Text = "0";
            HF_sinvid.Value = "";
            txt_sinvdata.Date = DateTime.Now;
            cmb_sinvpay.SelectedIndex = 0;
            lbl_invdoc.Text = string.Empty;
            txt_docid.Text = string.Empty;
            lbl_postst.Text = "";
            lbl_postacc.Text = "";
            hf_posyacc.Value = "";
            hf_postst.Value = "";
            lbl_vochrno.Text = string.Empty;
            lbl_sinvstatusname.Text = "";
            hf_sinvstatusid.Value = string.Empty;
            enable();
            enable_pay();
            btn_postacc.Enabled = true;
            btn_postacc.CssClass = "enable";
            PDetiles.Style.Add("display", "none");
            p_invpay.Style.Add("display", "none");
            gvs_invdtls.DataBind();
            gv_invpay.DataBind();

            //lbl_msg.Text = string.Empty;
        }
        void Clear_pay()
        {
            txt_payno.Text = string.Empty;
            txt_payref.Text = string.Empty;
            txt_payvalue.Text = 0.ToString();
            cmb_paytype.Text = string.Empty;
            cmb_paytype.Value = string.Empty;
            cmb_paytype.SelectedIndex = 0;
            //cmb_paychartid.Text= string.Empty;
            //cmb_paychartid.Value= string.Empty;
            cmb_paychartid.DataBind();
            Hf_invpayid.Value = "";
            //lbl_msg.Text = string.Empty;
            if (txt_payvalue.Text == "0")
            {
                Util.GenerateCombobox("s_inv_paychart", cmb_paychartid, "paytypeid,branchid", "" + EmaxGlobals.NullToEmpty(cmb_paytype.Value) + "," + EmaxGlobals.NullToEmpty(cmb_branchid.Value) + "", "paychartid", "paychartname");
            }
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



            btn_attach.Enabled = false;
            btn_attach.CssClass = "disable";
            btn_attach.RenderMode = Secondary;

            upload.Enabled = false;
            upload.CssClass = "disable";
            upload.RenderMode = Secondary;


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

            //btn_postacc.Enabled = true;
            //btn_postacc.CssClass = "enable";
        }
        void BindData(DataRow rec)
        {
            HF_sinvid.Value = EmaxGlobals.NullToEmpty(rec["sinvid"]);
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
            txt_docid.Text = EmaxGlobals.NullToEmpty(rec["docno"]);
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
            lbl_sinvstatusname.Text = EmaxGlobals.NullToEmpty(rec["sinvstatusname"]);
            hf_sinvstatusid.Value = EmaxGlobals.NullToEmpty(rec["sinvstatusid"]);
        }
        #endregion
        //void bind()
        //{

        //    DataTable dt = ms.s_inv_sel_id(Convert.ToInt32(HF_sinvid.Value));
        //    txt_sinvno.Text = dt.Rows[0]["sinvno"].ToString();
        //    txt_sinvdocno.Text = dt.Rows[0]["sinvdocno"].ToString();
        //    cmb_sinvpay.Text = dt.Rows[0]["sinvpayname"].ToString();
        //    cmb_sinvpay.Value = dt.Rows[0]["sinvpay"].ToString();
        //    cmb_smanid.Text = dt.Rows[0]["smanname"].ToString();
        //    cmb_smanid.Value = dt.Rows[0]["smanid"].ToString();
        //    if (cmb_smanid.Text == "0" || cmb_smanid.Text == "")
        //    {
        //        cmb_smanid.Text = null;
        //    }
        //    txt_sinvdata.Date = Convert.ToDateTime(dt.Rows[0]["sinvdata"].ToString());
        //    txt_sinvtime.Text = dt.Rows[0]["sinvtime"].ToString();
        //    txt_custid.Text =dt.Rows[0]["custid"].ToString();
        //    txt_custname.Text = dt.Rows[0]["custname"].ToString();
        //    txt_custvat.Text = dt.Rows[0]["custvat"].ToString();
        //    txt_custadd.Text = dt.Rows[0]["custadd"].ToString();
        //    txt_suser.Text = dt.Rows[0]["suser"].ToString();
        //    txt_snotes.Text = dt.Rows[0]["snotes"].ToString();
        //    txt_netbvat.Text = dt.Rows[0]["netbvat"].ToString();
        //    txt_vatvalue.Text = dt.Rows[0]["vatvalue"].ToString();
        //    txt_netavat.Text = dt.Rows[0]["netavat"].ToString();
        //    lbl_invdoc.Text = dt.Rows[0]["invdoc"].ToString();//.Replace("~/Files/","");
        //    //HFsInvid.Value = sinvid;
        //    Visible();
        //   // PDetiles.Visible = true;
        //  //  p_invpay.Visible = true;
        //    // accordion.Visible = true;
        //    //h11.Visible = true;
        //    //decimal x = 0;
        //    //for (int i = 0; i < gvs_invdtls.VisibleRowCount; i++)
        //    //{

        //    //    object value = gvs_invdtls.GetRowValues(i, "netvalue");
        //    //    if (value != null)
        //    //    {
        //    //        x += decimal.Parse(value.ToString());
        //    //    }

        //    //}
        //    //txt_netavat.Text = x.ToString();

        //}
        //void bind_items()
        //{
        //    //DataTable dt = ms.st_items_sel_itemid(HF_itemid.Value);
        //    //if (dt.Rows.Count > 0)
        //    //{
        //    //    txt_item.Text = dt.Rows[0]["itemcode"].ToString();
        //    //    txtitem_name.Text = dt.Rows[0]["itemname"].ToString();
        //    //    txt_price.Text = dt.Rows[0]["fprice"].ToString();
        //    //    txt_unit.Text = dt.Rows[0]["unitname"].ToString();
        //    //    Hf_unitid.Value = dt.Rows[0]["unitid"].ToString();
        //    //    Hf_vat.Value = dt.Rows[0]["vat"].ToString();
        //    //    // HF_itemid.Value = dt.Rows[0]["itemid"].ToString();
        //    //}
        //    //else
        //    //{
        //    //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('هذا الكود غير موجود ')", true);
        //    //    clear();
        //    //}
        //}
        //void Visible()
        //{
        //    PDetiles.Visible = true;
        //    p_invpay.Visible = true;
        //    dll_paytype.SelectedIndex = 0;
        //}
        //void clear_gvinvpay_select()
        //{
        //    int row = gv_invpay.FocusedRowIndex;
        //    gv_invpay.Selection.UnselectRow(row);
        //}
        //void clear_gvs_invdtls_select()
        //{
        //    //int row = gvs_invdtls.FocusedRowIndex;
        //    //gvs_invdtls.Selection.UnselectRow(row);
        //}


        #region  master
        List<object> GetParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_sinvid.Value) == 0)
            {
                return new List<object> { txt_sinvdocno, txt_sinvdata, cmb_sinvpay, txt_custid, txt_custname, txt_custvat, txt_custadd, txt_custmobile, txt_suser, txt_snotes, txt_netbvat, txt_vatvalue, txt_netavat, txt_restvalue, lbl_invdoc, cmb_smanid, cmb_branchid, cmb_ccid };
            }
            else
            {
                return new List<object> { txt_sinvno, txt_sinvdocno, txt_sinvdata, cmb_sinvpay, txt_custid, txt_custname, txt_custvat, txt_custadd, txt_custmobile, txt_suser, txt_snotes, txt_netbvat, txt_vatvalue, txt_netavat, txt_restvalue, lbl_invdoc, cmb_smanid, cmb_branchid, cmb_ccid, HF_sinvid };
            }
        }
        //protected void btn_Save_Click(object sender, ImageClickEventArgs e)
        //{
        //    try
        //    {
        //        //if (!Directory.Exists(@"~\Files"))
        //        //{
        //        //    Directory.CreateDirectory(@"~\Files");
        //        //}

        //        if (txt_sinvno.Text == "تلقائى")
        //        {
        //           // string pathfile = "";
        //            try
        //            {

        //              //  FileUpload1.SaveAs(Server.MapPath("~/Files/" + FileUpload1.FileName));
        //               // pathfile = "~/Files/" + Path.GetFileName(FileUpload1.PostedFile.FileName);

        //            }
        //            catch { }

        //            (int erro_id, string inv_no, string time) = ms.s_inv_ins("فاتوره", txt_sinvdocno.Text, Convert.ToDateTime(txt_sinvdata.Text), Convert.ToInt16(cmb_sinvpay.SelectedItem.Value), cmb_sinvpay.SelectedItem.Text, txt_custid.Text.Length==0?0: Convert.ToInt16(txt_custid.Text), txt_custname.Text, txt_custvat.Text, txt_custadd.Text, txt_suser.Text, txt_snotes.Text, Convert.ToDecimal(txt_netbvat.Text), Convert.ToDecimal(txt_vatvalue.Text), Convert.ToDecimal(txt_netavat.Text), Convert.ToDecimal(txt_restvalue.Text), lbl_invdoc.Text);

        //            if (erro_id == 0)
        //            {
        //                txt_sinvno.Text = inv_no;
        //                txt_sinvtime.Text = time.ToString();
        //                Visible();
        //               // PDetiles.Visible = true;
        //               // p_invpay.Visible = true;
        //                //  accordion.Visible = true;
        //                //  h11.Visible = true;
        //            }
        //        }
        //        else
        //        {
        //            Visible();
        //            //PDetiles.Visible = true;
        //           // p_invpay.Visible = true;
        //            // accordion.Visible = true;
        //            //  h11.Visible = true;
        //            //string pathfile = null;
        //            //if (FileUpload1.HasFile == true)
        //            //{
        //            //    FileUpload1.SaveAs(Server.MapPath("~/Files/" + FileUpload1.FileName));
        //            //    pathfile = "~/Files/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
        //            //    lbl_invdoc.Text = pathfile;
        //            //}

        //            //else if (FileUpload1.HasFile == false && lbl_invdoc.Text != null || lbl_invdoc.Text != "")
        //            //{
        //            //    pathfile = lbl_invdoc.Text;
        //            //}
        //            if (HF_sinvid.Value == "")
        //            {
        //                DataTable dt = ms.s_inv_sel_sinvid(txt_sinvno.Text);
        //                HF_sinvid.Value = dt.Rows[0]["sinvid"].ToString();
        //            }
        //            int erro_id = ms.s_inv_upd(int.Parse(HF_sinvid.Value), txt_sinvno.Text, txt_sinvdocno.Text, Convert.ToDateTime(txt_sinvdata.Text), Convert.ToInt16(cmb_sinvpay.SelectedItem.Value), cmb_sinvpay.SelectedItem.Text, txt_custid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_custid.Text), txt_custname.Text, txt_custvat.Text, txt_custadd.Text, txt_suser.Text, txt_snotes.Text, Convert.ToDecimal(txt_netbvat.Text), Convert.ToDecimal(txt_vatvalue.Text), Convert.ToDecimal(txt_netavat.Text), Convert.ToDecimal(txt_restvalue.Text), lbl_invdoc.Text);
        //            if (erro_id == 0)
        //            {
        //                ms.s_invdtls_upd(0, Convert.ToInt16(HF_sinvid.Value), 0, 0, 0, 0,0,0,0, 0, 0, "", 1, 11, Convert.ToDateTime(txt_sinvdata.Text), Convert.ToInt32(txt_custid.Text), txt_sinvno.Text, "",0);
        //                ms.s_invpay_upd(0, Convert.ToInt16(HF_sinvid.Value), 0, 0, "", "", txt_sinvdata.Date, Convert.ToInt32(txt_custid.Text), txt_sinvno.Text, "",0);

        //                Visible();

        //              //  ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "function_save();", true);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
        //        if (msg == "Input string was not in a correct format.")
        //            msg = "برجاء التأكد من البيانات المدخله";
        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
        //    }
        //}
        protected void btn_Save_Click(object sender, EventArgs e)
        {

            try
            {
                var res = SaveData(EmaxGlobals.NullToIntZero(HF_sinvid.Value) == 0 ? "s_inv_ins" : "s_inv_upd"
        , GetParam(), null,
                EmaxGlobals.NullToIntZero(HF_sinvid.Value) == 0 ? new List<string>() { "sinvnomax", "time", "id" } : new List<string>() { }, true, true,
                new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue =cmb_branchid }
                ,new ParamObject() { ParamName = "sinvpayname", ParamValue = cmb_sinvpay }
                ,new ParamObject() { ParamName = "ccname", ParamValue = cmb_ccid }
                ,new ParamObject() { ParamName = "smanname", ParamValue = cmb_smanid } });
                if (res.errorid == 0)
                {
                    PDetiles.Style.Add("display", "block");
                    p_invpay.Style.Add("display", "block");
                    cmb_branchid.ClientEnabled = false;
                    if (EmaxGlobals.NullToIntZero(HF_sinvid.Value) != 0)
                    {

                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                    }
                    else
                    {
                        HF_sinvid.Value = res.outputparams != null && res.outputparams.Count > 0 ? EmaxGlobals.NullToEmpty(res.outputparams["id"]) : "";
                        txt_sinvtime.Text = res.outputparams.ContainsKey("time") ? EmaxGlobals.NullToEmpty(res.outputparams["time"].ToString()) : "";
                        txt_sinvno.Text = res.outputparams.ContainsKey("sinvnomax") ? EmaxGlobals.NullToEmpty(res.outputparams["sinvnomax"].ToString()) : "";

                    }
                    if (cmb_sinvpay.SelectedItem.Value.ToString() == "2")
                    {
                        disable_pay();
                        btn_postacc.Enabled = true;
                        btn_postacc.CssClass = "enable";
                    }
                    else
                    {
                        enable_pay();
                    }
                    //if (res.outputparams.ContainsKey("sinvnomax"))
                    //{
                    //    txt_sinvno.Text = EmaxGlobals.NullToEmpty(res.outputparams["sinvnomax"]);
                    //}
                    //Visible();





                }

                //if (txt_custname.Text == ""|| cmb_sinvpay.SelectedIndex==1 && txt_custid.Text==""||txt_sinvdata.Text=="")
                //{
                //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "validate(s, e);", true);
                //    return;
                //}
                //var d= SqlCommandHelper.ExecuteNonQuery("", new List<object> { }, true, true);

                /*  if (cmb_smanid.Value == null)
                  {
                      cmb_smanid.Value = 0;
                      cmb_smanid.Text = null;
                  }
                  if (txt_sinvno.Text == "تلقائى")
                  {
                      //// string pathfile = "";
                      //try
                      //{

                      //    //  FileUpload1.SaveAs(Server.MapPath("~/Files/" + FileUpload1.FileName));
                      //    // pathfile = "~/Files/" + Path.GetFileName(FileUpload1.PostedFile.FileName);

                      //}
                      //catch { }

                      (int erro_id, string inv_no, string time,string error_msg) = ms.s_inv_ins("فاتوره", txt_sinvdocno.Text, Convert.ToDateTime(txt_sinvdata.Text), Convert.ToInt16(cmb_sinvpay.SelectedItem.Value), cmb_sinvpay.SelectedItem.Text, txt_custid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_custid.Text), txt_custname.Text, txt_custvat.Text, txt_custadd.Text, txt_suser.Text, txt_snotes.Text, Convert.ToDecimal(txt_netbvat.Text), Convert.ToDecimal(txt_vatvalue.Text), Convert.ToDecimal(txt_netavat.Text), Convert.ToDecimal(txt_restvalue.Text), lbl_invdoc.Text, Convert.ToInt16(cmb_smanid.Value), cmb_smanid.Text, Convert.ToInt16(cmb_branchid.Value), cmb_branchid.Text);

                      if (erro_id == 0)
                      {
                          txt_sinvno.Text = inv_no;
                          txt_sinvtime.Text = time.ToString();
                          Visible();


                      }
                  }
                  else
                  {
                      Visible();


                      if (HF_sinvid.Value == "")
                      {
                          DataTable dt = ms.s_inv_sel_sinvid(txt_sinvno.Text);
                          HF_sinvid.Value = dt.Rows[0]["sinvid"].ToString();
                      }
                      (int erro_id,string err_msg) = ms.s_inv_upd(int.Parse(HF_sinvid.Value), txt_sinvno.Text, txt_sinvdocno.Text, Convert.ToDateTime(txt_sinvdata.Text), Convert.ToInt16(cmb_sinvpay.SelectedItem.Value), cmb_sinvpay.SelectedItem.Text, txt_custid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_custid.Text), txt_custname.Text, txt_custvat.Text, txt_custadd.Text, txt_suser.Text, txt_snotes.Text, Convert.ToDecimal(txt_netbvat.Text), Convert.ToDecimal(txt_vatvalue.Text), Convert.ToDecimal(txt_netavat.Text), Convert.ToDecimal(txt_restvalue.Text), lbl_invdoc.Text, Convert.ToInt16(cmb_smanid.Value), cmb_smanid.Text);
                      if (erro_id == 0)
                      {
                          (int erro_id_dtl, string err_msg_dtl) = ms.s_invdtls_upd(0, Convert.ToInt16(HF_sinvid.Value), 0, 0, 0, 0, 0, 0, 0, 0, 0, "", 1, 11, Convert.ToDateTime(txt_sinvdata.Text), txt_custid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_custid.Text), txt_sinvno.Text, "", 0);
                          (int erro_id_pay, string err_msg_pay) = ms.s_invpay_upd(0, Convert.ToInt16(HF_sinvid.Value), 0, 0, "", "", txt_sinvdata.Date, txt_custid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_custid.Text), txt_sinvno.Text, "", 0);

                          Visible();
                        //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "pop", "openModal();", true);
                        //  UpdatePanel1.Update();
                           // lbl_msg.Text = err_msg;


                            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('"+ err_msg + "');", true);
                      }
                  }*/

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
            //PDetiles.Visible = false;
            // p_invpay.Visible = false; 

            //Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath);
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]

        public static string Deletedata(int sinvid)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("sinvid", sinvid);
            var res = SqlCommandHelper.ExecuteNonQuery("s_inv_del", dict, true);
            return JsonConvert.SerializeObject(res);
        }
        /* protected void btn_delete_Click(object sender, EventArgs e)
         {


             try
             {

                 //  ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Form submitted.');", true);
                 //string confirmValue = Request.Form["conf"];
                 //if (confirmValue == "نعم")
                 //{

                 if (HF_sinvid.Value == "")
                 {
                     DataTable dt = ms.s_inv_sel_sinvid(txt_sinvno.Text);
                     HF_sinvid.Value = dt.Rows[0]["sinvid"].ToString();                
                 }

                 (int erro_id, string error_msg) = ms.s_inv_del(Convert.ToInt32(HF_sinvid.Value));
                     clear_inv();
                     PDetiles.Visible = false;
                     p_invpay.Visible = false;
                 //}
                 //else
                 //{
                 //}
             }
             catch (Exception ex)
             {
                 if (HF_sinvid.Value == "")
                 {
                     ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('لا توجد فاتوره للحذف')", true);
                     return;
                 }
                 string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

                 ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
             }
         }*/
        #endregion
        #region inv dtls
        List<object> GetVatParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_sinvid.Value) != 0)
            {
                return new List<object> { HF_sinvid, txt_netbvat, txt_vatvalue, txt_netavat, txt_restvalue };
            }
            else
            {
                return null;
            }
        }
        List<object> GetParam_dtl()
        {
            Object ob = SqlCommandHelper.GetTokenKey("userid", Request.Cookies["Token"].Value);
            if (EmaxGlobals.NullToIntZero(HF_invdtlid.Value) == 0)
            {
                return new List<object> { HF_sinvid, HF_itemid, HF_unitid, HF_factor, txt_qty, txt_price, txt_value, txt_discp, txt_discvalue, txt_netvalue, txtitem_vatvalue, txt_itemnotes  };
            }
            else
            {

                return new List<object> { HF_invdtlid, HF_sinvid, HF_itemid, HF_unitid, HF_factor, txt_qty, txt_price, txt_value, txt_discp, txt_discvalue, txt_netvalue, txtitem_vatvalue, txt_itemnotes  };
            }
        }

        protected void btn_save_dtls_Click(object sender, EventArgs e)
        {
            
            var res = SaveData(EmaxGlobals.NullToIntZero(HF_invdtlid.Value) == 0 ? "s_invdtls_ins" : "s_invdtls_upd"
     , GetParam_dtl(), null,
             new List<string>() { "invdtlid" }, true, true,
             new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue =cmb_branchid }
                ,new ParamObject() { ParamName = "sinvpayname", ParamValue = cmb_sinvpay }
                ,new ParamObject() { ParamName = "ccname", ParamValue = cmb_ccid }
                ,new ParamObject() { ParamName = "smanname", ParamValue = cmb_smanid } });
            if (res.errorid == 0)
            {
                //if (EmaxGlobals.NullToIntZero(HF_invdtlid.Value) != 0)
                //{
                //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                //}


                //    HF_sinvid.Value = res.outputparams != null && res.outputparams.Count > 0 ? EmaxGlobals.NullToEmpty(res.outputparams["id"]) : "";
                //    txt_sinvtime.Text = res.outputparams.ContainsKey("time") ? EmaxGlobals.NullToEmpty(res.outputparams["time"].ToString()) : "";

                //if (res.outputparams.ContainsKey("sinvnomax"))
                //{
                //    txt_sinvno.Text = EmaxGlobals.NullToEmpty(res.outputparams["sinvnomax"]);
                //}
                //Visible();
                gvs_invdtls.DataBind();
                calac_Total();
                //PDetiles.Style.Add("display", "block");
                clear();
                //clear_gvs_invdtls_select();

                var res2 = SaveData("s_inv_vat_upd", GetVatParam(), null, null, true, false, null);

            }

            /*   if (txt_item.Text == "")
               {
                   ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('برجاء التأكد من البيانات المدخله')", true);
               }
               if (HF_invdtlid.Value == "" || HF_invdtlid.Value == "0")
               {
                   try
                   {
                       DataTable dt = ms.s_inv_sel_sinvid(txt_sinvno.Text);
                       HF_sinvid.Value = dt.Rows[0]["sinvid"].ToString();
                       //, txt_unit.Text

                      ( int error_id, string error_msg) = ms.s_invdtls_ins(Convert.ToInt16(HF_sinvid.Value), Convert.ToInt16(HF_itemid.Value), Convert.ToInt16(Hf_unitid.Value), Convert.ToDecimal(txt_qty.Text), Convert.ToDecimal(txt_price.Text), Convert.ToDecimal(txt_value.Text), Convert.ToDecimal(txt_discp.Text), Convert.ToDecimal(txt_discvalue.Text), Convert.ToDecimal(txt_netvalue.Text), Convert.ToDecimal(txtitem_vatvalue.Text), txt_itemnotes.Text, 1, 11, txt_sinvdata.Date, txt_custid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_custid.Text), txt_sinvno.Text, "");
                       gvs_invdtls.DataBind();
                       ////// update  vatvalue,netavat,netavat
                       update_inv_vatvalue();
                       //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "function_save();", true);
                       clear();
                       clear_gvs_invdtls_select();
                   }
                   catch (Exception ex)
                   {
                       string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                       if (msg == "Input string was not in a correct format.")
                           msg = "برجاء التأكد من البيانات المدخله";
                       ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
                   }
               }
               else
               {
                   try
                   {
                       DataTable dt = ms.st_items_sel_item_code(txt_item.Text);

                       HF_itemid.Value = dt.Rows[0]["itemid"].ToString();
                       //Hf_unitid.Value =  dt.Rows[0]["unitid"].ToString());


                       (int erro_id, string err_msg) = ms.s_invdtls_upd(Convert.ToInt16(HF_invdtlid.Value), Convert.ToInt16(HF_sinvid.Value), Convert.ToInt16(HF_itemid.Value), Convert.ToInt16(Hf_unitid.Value), Convert.ToDecimal(txt_qty.Text), Convert.ToDecimal(txt_price.Text), Convert.ToDecimal(txt_value.Text), Convert.ToDecimal(txt_discp.Text), Convert.ToDecimal(txt_discvalue.Text), Convert.ToDecimal(txt_netvalue.Text), Convert.ToDecimal(txtitem_vatvalue.Text), txt_itemnotes.Text, 1, 11, Convert.ToDateTime(txt_sinvdata.Text), txt_custid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_custid.Text), txt_sinvno.Text, "", 1);
                       gvs_invdtls.DataBind();
                       ////// update  vatvalue,netavat,netavat
                       update_inv_vatvalue();
                       // ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "function_save();", true);
                       clear();
                       clear_gvs_invdtls_select();

                   }
                   catch (Exception ex)
                   {

                       string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                       if (msg == "Input string was not in a correct format.")
                           msg = "برجاء التأكد من البيانات المدخله";
                       ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);

                   }

               }*/
        }
        protected void btn_new_dtls_Click(object sender, EventArgs e)
        {
            //clear_gvs_invdtls_select();
            //clear();

        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static string Deletedatadtls(int invdtlid)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("invdtlid", invdtlid);


            var res = SqlCommandHelper.ExecuteNonQuery("s_invdtls_del", dict, true);
            return JsonConvert.SerializeObject(res);


        }
        protected void btn_delete_dtls_Click(object sender, EventArgs e)
        {
            hf_netbvat.Value = "0";

            //    try
            //    {
            //        if (HF_invdtlid.Value == "" || HF_invdtlid.Value == null)
            //        {
            //            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('برجاء اختيار الصنف للحذف')", true);

            //        }
            //        else
            //        {
            //            (int erro_id, string error_msg) = ms.s_invdtls_del(Convert.ToInt16(HF_invdtlid.Value));
            //            gvs_invdtls.Selection.CancelSelection();
            //            gvs_invdtls.DataBind();
            //            ////// update  vatvalue,netavat,netavat
            //            //update_inv_vatvalue();
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
            //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            //    }
        }

        //protected void HF_inv_id_ValueChanged(object sender, EventArgs e)
        //{
        //    if (HF_sinvid.Value != "")
        //    {
        //        bind();
        //    }
        //}


        //protected void gvs_invdtls_SelectionChanged(object sender, EventArgs e)
        //{
        //  try
        //{
        //    clear();
        //if (gvs_invdtls.GetSelectedFieldValues("itemcode").Count != 0)
        //{


        //    txt_item.Text = gvs_invdtls.GetSelectedFieldValues("itemcode")[0].ToString();
        //    txtitem_name.Text = gvs_invdtls.GetSelectedFieldValues("itemname")[0].ToString();
        //    txt_unit.Text = gvs_invdtls.GetSelectedFieldValues("unitname")[0].ToString();
        //    Hf_unitid.Value = gvs_invdtls.GetSelectedFieldValues("unitid")[0].ToString();
        //    hf_qty.Value = gvs_invdtls.GetSelectedFieldValues("qty")[0].ToString();
        //    txt_qty.Text = gvs_invdtls.GetSelectedFieldValues("qty")[0].ToString();
        //    txt_price.Text = gvs_invdtls.GetSelectedFieldValues("price")[0].ToString();
        //    txt_value.Text = gvs_invdtls.GetSelectedFieldValues("value")[0].ToString();
        //    txt_discp.Text = gvs_invdtls.GetSelectedFieldValues("discp")[0].ToString();
        //    hf_disc.Value = gvs_invdtls.GetSelectedFieldValues("discvalue")[0].ToString();
        //    txt_discvalue.Text = gvs_invdtls.GetSelectedFieldValues("discvalue")[0].ToString();
        //    txt_netvalue.Text = gvs_invdtls.GetSelectedFieldValues("netvalue")[0].ToString();
        //    txtitem_vatvalue.Text = gvs_invdtls.GetSelectedFieldValues("vatvalue")[0].ToString();
        //    txt_itemnotes.Text = gvs_invdtls.GetSelectedFieldValues("itemnotes")[0].ToString();
        //    HF_invdtlid.Value = gvs_invdtls.GetSelectedFieldValues("invdtlid")[0].ToString();
        //}
        //    DataTable dt = ms.st_items_sel_item_code(txt_item.Text);
        //     if (dt.Rows.Count > 0)
        //    {
        //       Hf_vat.Value = dt.Rows[0]["vat"].ToString();
        //    }
        //   }
        //   catch (Exception ex)
        //   {
        //      ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + ex + "')", true);
        //  }
        //}



        //protected void txt_item_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataTable dt = ms.st_items_sel_item_code(txt_item.Text);
        //        if (dt.Rows.Count > 0)
        //        {
        //            txtitem_name.Text = dt.Rows[0]["itemname"].ToString();
        //            txt_price.Text = dt.Rows[0]["fprice"].ToString();
        //            txt_unit.Text = dt.Rows[0]["unitname"].ToString();
        //            Hf_unitid.Value = dt.Rows[0]["unitid"].ToString();
        //            HF_itemid.Value = dt.Rows[0]["itemid"].ToString();
        //            Hf_vat.Value = dt.Rows[0]["vat"].ToString();

        //        }
        //        else
        //        {
        //            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('هذا الكود غير موجود ')", true);
        //            clear();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
        //    }
        //}



        //protected void btn_new_dtls_Click(object sender, ImageClickEventArgs e)
        //{
        //    clear();
        //    gvs_invdtls.Selection.CancelSelection();
        //    gvs_invdtls.DataBind();
        //    clear_gvs_invdtls_select();
        //}

        //protected void btn_delete_dtls_Click(object sender, ImageClickEventArgs e)
        //{
        //    try
        //    {
        //        if (HF_invdtlid.Value == "" || HF_invdtlid.Value == null)
        //        {
        //            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('برجاء اختيار الصنف للحذف')", true);

        //        }
        //        else
        //        {
        //            ms.s_invdtls_del(Convert.ToInt16(HF_invdtlid.Value));
        //            gvs_invdtls.Selection.CancelSelection();
        //            gvs_invdtls.DataBind();
        //            ////// update  vatvalue,netavat,netavat
        //            update_inv_vatvalue();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
        //    }


        //}


        //protected void gvs_invdtls_CustomUnboundColumnData(object sender, DevExpress.Web.ASPxGridViewColumnDataEventArgs e)
        //{
        //    if (e.Column.FieldName == "netvalue")
        //    {
        //        decimal netvalue = Convert.ToDecimal(e.GetListSourceFieldValue("RISK"));
        //        //decimal mv = Convert.ToDecimal(e.GetListSourceFieldValue("MV_BERND"));
        //        //decimal ipotek = Convert.ToDecimal(e.GetListSourceFieldValue("IPOTEK"));
        //        e.Value = netvalue;
        //        txt_netavat.Text = e.Value.ToString();


        //    }

        //}
        //protected void gvs_invdtls_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        //{
        //    ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["netvalue"];
        //  //  ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
        //    Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
        //   // Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
        //    e.TotalValue = income;
        //    txt_netavat.Text = e.TotalValue.ToString();

        //}

        //protected void gvs_invdtls_CustomSummaryCalculate1(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        //{
        //    ASPxSummaryItem incomeSummary = (sender as ASPxGridView).TotalSummary["netvalue"];
        //    //  ASPxSummaryItem expenseSummary = (sender as ASPxGridView).TotalSummary["Expense"];
        //    Decimal income = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(incomeSummary));
        //    // Decimal expense = Convert.ToDecimal(((ASPxGridView)sender).GetTotalSummaryValue(expenseSummary));
        //    e.TotalValue = income;
        //    txt_netavat.Text = e.TotalValue.ToString();

        //}
        //void update_inv_vatvalue()
        //{
        //    ////// update  vatvalue,netavat,netavat
        //    try
        //    {
        //        //string pathfile = null;
        //        //if (FileUpload1.HasFile == true)
        //        //{
        //        //    FileUpload1.SaveAs(Server.MapPath("~/Files/" + FileUpload1.FileName));
        //        //    pathfile = "~/Files/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
        //        //    lbl_invdoc.Text = pathfile;
        //        //}

        //        //else if (FileUpload1.HasFile == false && lbl_invdoc.Text != null || lbl_invdoc.Text != "")
        //        //{
        //        //    pathfile = lbl_invdoc.Text;
        //        //}
        //        (int erro_id,string err_msg) = ms.s_inv_upd(int.Parse(HF_sinvid.Value), txt_sinvno.Text, txt_sinvdocno.Text, Convert.ToDateTime(txt_sinvdata.Text), Convert.ToInt16(cmb_sinvpay.SelectedItem.Value), cmb_sinvpay.SelectedItem.Text, txt_custid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_custid.Text), txt_custname.Text, txt_custvat.Text, txt_custadd.Text, txt_suser.Text, txt_snotes.Text, Convert.ToDecimal(txt_netbvat.Text), Convert.ToDecimal(txt_vatvalue.Text), Convert.ToDecimal(txt_netavat.Text), Convert.ToDecimal(txt_restvalue.Text), lbl_invdoc.Text, Convert.ToInt16(cmb_smanid.Value), cmb_smanid.Text);
        //        if (erro_id == 0)
        //        {
        //            //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "function_save();", true);
        //            // PDetiles.Visible = true;
        //        }
        //        clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
        //    }
        //}
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
                    lbl_invdoc.Text = "";
                }
                if (EmaxGlobals.NullToEmpty(post[1]) != "")
                {
                    txt_docid.Text = post[1].ToString();
                }
                else
                {
                    txt_docid.Text = "";
                }
                if (EmaxGlobals.NullToBool(post[2]) == true)
                {
                    lbl_postst.Text = "مرحل مستودعات";
                    disable();
                    //btn_Save.Enabled = false;
                    //btn_Save.CssClass = "disable";
                    //btn_Save.RenderMode = Secondary;

                    //btn_delete.Enabled = false;
                    //btn_delete.CssClass = "disable";
                    //btn_delete.RenderMode = Secondary;
                    ////btn_addnew.Enabled = false;
                    //btn_save_dtls.Enabled = false;
                    //btn_save_dtls.CssClass = "disable";
                    //btn_save_dtls.RenderMode = Secondary;
                    //// btn_new_dtls.Enabled = false;
                    //btn_postst.Enabled = false;
                    //btn_postst.CssClass = "disable";
                    //btn_postst.RenderMode = Secondary;

                    //btn_delete_dtls.Enabled = false;
                    //btn_delete_dtls.CssClass = "disable";
                    //btn_delete_dtls.RenderMode = Secondary;
                    //btn_fastinsert.Enabled = false;
                    //btn_fastinsert.CssClass = "disable";
                    //btn_fastinsert.RenderMode = Secondary;


                }
                else
                {
                    lbl_postst.Text = "";
                    enable();
                    //btn_Save.Enabled = true;
                    //btn_Save.CssClass = "enable";

                    //btn_delete.Enabled = true;
                    //btn_delete.CssClass = "enable";
                    ////btn_addnew.Enabled = false;
                    //btn_save_dtls.Enabled = true;
                    //btn_save_dtls.CssClass = "enable";
                    //// btn_new_dtls.Enabled = false;
                    //btn_delete_dtls.Enabled = true;
                    //btn_delete_dtls.CssClass = "enable";

                    //btn_postst.Enabled = true;
                    //btn_postst.CssClass = "enable";

                    //btn_fastinsert.Enabled = true;
                    //btn_fastinsert.CssClass = "enable";

                }
                if (EmaxGlobals.NullToBool(post[3]) == true)
                {
                    lbl_postacc.Text = "مرحل حـسابـات";
                    disable();
                    btn_postacc.Enabled = false;
                    btn_postacc.CssClass = "disable";
                    btn_postacc.RenderMode = Secondary;
                    disable_pay();
                    if (EmaxGlobals.NullToBool(post[2]) == false)
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
                    btn_postacc.Enabled = true;
                    btn_postacc.CssClass = "enable";
                    lbl_postacc.Text = "";
                    // enable();
                    enable_pay();
                    //if (EmaxGlobals.NullToBool(post[2]) == true)
                    //{
                    //    btn_postst.Enabled = false;
                    //    btn_postst.CssClass = "disable";
                    //    btn_postst.RenderMode = Secondary;

                    //}
                    //else
                    //{
                    //    btn_postst.Enabled = true;
                    //    btn_postst.CssClass = "enable";
                    //}

                }
            }



            if (txt_docid.Text.StartsWith("2"))
            {
                txt_docid.NavigateUrl = "~/Sales/S_order.aspx" + "?orderno=" + txt_docid.Text + "";
            }
            else
            {
                txt_docid.NavigateUrl = "~/Sales/s_quote_order.aspx" + "?orderno=" + txt_docid.Text + "";

            }
            if (cmb_sinvpay.SelectedItem.Value.ToString() == "2")
            {
                disable_pay();
                //btn_postacc.Enabled = true;
                //btn_postacc.CssClass = "enable";
                if (post.Length==3 && EmaxGlobals.NullToBool(post[3]) == true)
                {
                    disable_pay();
                }
            }
            else if(cmb_sinvpay.SelectedItem.Value.ToString() == "1" && (post.Length==4 && EmaxGlobals.NullToBool(post[3]) != true))
            {
                enable_pay();
            }
            if (post.Length > 4)
            {
                if (post[4] != "" || post[4] != null)
                {
                    lbl_vochrno.Text = post[4];
                   lbl_vochrno.NavigateUrl = "~/GL/Vouchers.aspx" + "?vchrno=" + lbl_vochrno.Text + "";
                }
            }
            if (post.Length > 5)
            {
                if (post[5] != "" || post[5] != null)
                {
                    lbl_sinvstatusname.Text = post[5];
                    //if (hf_sinvstatusid.Value == "1")
                    //{
                    //    disable();
                    //    disable_pay();
                    //    if (EmaxGlobals.NullToBool(hf_postst.Value) == false)
                    //    {
                    //        btn_postst.Enabled = true;
                    //        btn_postst.CssClass = "enable";
                    //    }
                    //    else
                    //    {
                    //        btn_postst.Enabled = false;
                    //        btn_postst.CssClass = "disable";
                    //        btn_postst.RenderMode = Secondary;
                    //    }
                    //    if (EmaxGlobals.NullToBool(hf_posyacc.Value) == false)
                    //    {
                    //        btn_postacc.Enabled = true;
                    //        btn_postacc.CssClass = "enable";
                    //    }
                    //    else
                    //    {
                    //        btn_postacc.Enabled = false;
                    //        btn_postacc.CssClass = "disable";
                    //        btn_postacc.RenderMode = Secondary;
                    //    }
                    //}
                    //else
                    //{
                    //    enable();
                    //    enable_pay();
                    //    if (EmaxGlobals.NullToBool(hf_postst.Value) == false)
                    //    {
                    //        btn_postst.Enabled = true;
                    //        btn_postst.CssClass = "enable";
                    //    }
                    //    else
                    //    {
                    //        btn_postst.Enabled = false;
                    //        btn_postst.CssClass = "disable";
                    //        btn_postst.RenderMode = Secondary;
                    //    }
                    //    if (EmaxGlobals.NullToBool(hf_posyacc.Value) == false)
                    //    {
                    //        btn_postacc.Enabled = true;
                    //        btn_postacc.CssClass = "enable";
                    //    }
                    //    else
                    //    {
                    //        btn_postacc.Enabled = false;
                    //        btn_postacc.CssClass = "disable";
                    //        btn_postacc.RenderMode = Secondary;
                    //    }
                    //}
                }
            }
            gvs_invdtls.DataBind();
            gv_invpay.DataBind();
            if (post.Length ==1 && post[0]=="")
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
            //if (EmaxGlobals.NullToEmpty( txt_custid.Text) != "" || EmaxGlobals.NullToEmpty(Hf_cusid.Value)!="")
            //{
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "cus_validate();", true);
            //}
            
        }
        DataTable GvdetailSource()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("sinvid", HF_sinvid.Value);

            return SqlCommandHelper.ExcecuteToDataTable("s_invdtls_sel", dict).dataTable;

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
            //    txt_netavat.Text = Math.Round(EmaxGlobals.NullToZero(gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]).ToString()), 2).ToString();
            //    txt_vatvalue.Text = Math.Round(EmaxGlobals.NullToZero(gridView.GetTotalSummaryValue(gridView.TotalSummary["vatvalue"]).ToString()), 2).ToString();
            //    txt_netbvat.Text = Math.Round(EmaxGlobals.NullToZero(EmaxGlobals.NullToZero(txt_netavat.Text) - EmaxGlobals.NullToZero(txt_vatvalue.Text)), 2).ToString();
            //    if (txt_restvalue.Text == "0")
            //        txt_restvalue.Text = txt_netavat.Text;
            //}
            /////غير شامل الصريبه
            //else if (HF_vattype.Value == "2")
            //{
            //    txt_netbvat.Text = Math.Round(EmaxGlobals.NullToZero(gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]).ToString()), 2).ToString();
            //    txt_vatvalue.Text = Math.Round(EmaxGlobals.NullToZero(gridView.GetTotalSummaryValue(gridView.TotalSummary["vatvalue"]).ToString()), 2).ToString();
            //    txt_netavat.Text = Math.Round(EmaxGlobals.NullToZero(EmaxGlobals.NullToZero(txt_netbvat.Text) + EmaxGlobals.NullToZero(txt_vatvalue.Text)), 2).ToString();
            //    if (txt_restvalue.Text == "0")
            //        txt_restvalue.Text = txt_netavat.Text;
            //}
            //else if (HF_vattype.Value == "3")
            //{
            //    txt_netbvat.Text = Math.Round(EmaxGlobals.NullToZero(gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]).ToString()), 2).ToString();
            //    txt_netavat.Text = Math.Round(EmaxGlobals.NullToZero(gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]).ToString()), 2).ToString();
            //    txt_vatvalue.Text = Math.Round(EmaxGlobals.NullToZero(gridView.GetTotalSummaryValue(gridView.TotalSummary["vatvalue"]).ToString()), 2).ToString();
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
            //    decimal rest = Math.Round(EmaxGlobals.NullToZero(gv_invpay.GetTotalSummaryValue(gv_invpay.TotalSummary["payvalue"])), 2);

            //    txt_restvalue.Text = Math.Round(EmaxGlobals.NullToZero(txt_netavat.Text) - rest, 2).ToString();
            //}
            //catch { }
            ////}

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
        #endregion
        //protected void HF_itemid_ValueChanged(object sender, EventArgs e)
        //{
        //    if (HF_itemid.Value != "")
        //    {
        //        txt_item.Text = string.Empty;
        //        txt_unit.Text = string.Empty;
        //        txt_qty.Text = "1";
        //        txt_price.Text = "0";
        //        txt_value.Text = "0";
        //        txt_discp.Text = "0";
        //        txt_discvalue.Text = "0";
        //        txt_netvalue.Text = "0";

        //        txtitem_vatvalue.Text = "0";
        //        txt_itemnotes.Text = string.Empty;
        //        txtitem_name.Text = string.Empty;
        //        HF_invdtlid.Value = "";

        //        Hf_vat.Value = "";
        //        bind_items();
        //    }
        //}




        //protected void Hf_cusid_ValueChanged(object sender, EventArgs e)
        //{
        //if (Hf_cusid.Value != "")
        //{
        //    DataTable dt = ms.s_customers_sel_custid(Convert.ToInt32(Hf_cusid.Value));
        //    if (dt.Rows.Count > 0)
        //    {
        //        txt_custid.Text = dt.Rows[0]["custcode"].ToString();
        //        txt_custname.Text = dt.Rows[0]["custname"].ToString();
        //        txt_custadd.Text = dt.Rows[0]["custadd"].ToString();
        //        txt_custvat.Text = dt.Rows[0]["custvat"].ToString();

        //    }
        //    else
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('هذا الكود غير موجود ')", true);
        //        //txt_custid.Text = "0";
        //    }
        //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "cus_validate();", true);
        //}
        //}

        //protected void cmb_sinvpay_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //if (cmb_sinvpay.SelectedIndex == 1)
        //{
        //  //  txt_custid.Text = "";
        //    //txt_cus_id_req.Enabled = true;
        //  //  return;
        //}
        //}

        #region paymant panle


        //protected void gv_invpay_SelectionChanged(object sender, EventArgs e)
        //{
        //    //Clear_pay();
        //    if (gv_invpay.GetSelectedFieldValues("payno").Count != 0)
        //    {

        //        txt_payno.Text = gv_invpay.GetSelectedFieldValues("payno")[0].ToString();
        //    txt_payref.Text = gv_invpay.GetSelectedFieldValues("payref")[0].ToString();
        //    txt_payvalue.Text = gv_invpay.GetSelectedFieldValues("payvalue")[0].ToString();

        //    cmb_paytype.Text = gv_invpay.GetSelectedFieldValues("payname")[0].ToString();
        //    cmb_paytype.Value = gv_invpay.GetSelectedFieldValues("paytypeid")[0].ToString();

        //    Hf_invpayid.Value = gv_invpay.GetSelectedFieldValues("invpayid")[0].ToString();
        //      }
        //}
        List<object> GetParam_pay()
        {
            if (EmaxGlobals.NullToIntZero(Hf_invpayid.Value) == 0)
            {
                return new List<object> { HF_sinvid, cmb_paytype, txt_payvalue, txt_payno, txt_payref, cmb_paychartid };
            }
            else
            {

                return new List<object> { Hf_invpayid, HF_sinvid, cmb_paytype, txt_payvalue, txt_payno, txt_payref, cmb_paychartid };
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
                var res = SaveData(EmaxGlobals.NullToIntZero(Hf_invpayid.Value) == 0 ? "s_invpay_ins" : "s_invpay_upd"
    , GetParam_pay(), null,
            null, true, true,
            new List<ParamObject>() { new ParamObject() { ParamName = "payname", ParamValue = cmb_paytype } });
                if (res.errorid == 0)
                {
                    gv_invpay.DataBind();
                    Clear_pay();
                    var res2 = SaveData("s_inv_vat_upd", GetVatParam(), null, null, true, false, null);
                   

                }
                #region old
                /* if (Hf_invpayid.Value == "")
                 {

                     (int error_id,string error_msg) = ms.s_invpay_ins(Convert.ToInt16(HF_sinvid.Value), Convert.ToInt16(dll_paytype.SelectedItem.Value), Convert.ToDouble(txt_payvalue.Text), txt_payno.Text, txt_payref.Text, txt_sinvdata.Date, txt_custid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_custid.Text), txt_sinvno.Text, "");
                     if (error_id == 1)
                     {
                         ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                     }
                     else
                     {
                         gv_invpay.DataBind();
                         //update_inv_vatvalue();
                         Clear_pay();
                         clear_gvinvpay_select();

                     }
                 }
                 else
                 {
                     (int error_id, string error_msg)  = ms.s_invpay_upd(Convert.ToInt32(Hf_invpayid.Value), Convert.ToInt16(HF_sinvid.Value), Convert.ToInt16(dll_paytype.SelectedItem.Value), Convert.ToDouble(txt_payvalue.Text), txt_payno.Text, txt_payref.Text, txt_sinvdata.Date, txt_custid.Text.Length == 0 ? 0 : Convert.ToInt16(txt_custid.Text), txt_sinvno.Text, "",1);
                     if (error_id == 1)
                     {
                         ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                     }
                     else
                     {
                         gv_invpay.Selection.CancelSelection();
                         gv_invpay.DataBind();
                        // update_inv_vatvalue();
                         Clear_pay();
                         clear_gvinvpay_select();
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

        protected void brn_new_pay_Click(object sender, EventArgs e)
        {
            Clear_pay();

            // clear_gvinvpay_select();

        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]

        public static string Deletedatapay(int invpayid)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("invpayid", invpayid);
            var res = SqlCommandHelper.ExecuteNonQuery("s_invpay_del", dict, true);

            return JsonConvert.SerializeObject(res);
        }
        /* protected void btn_delete_pay_Click(object sender, EventArgs e)
         {
             try
             {
                 if ( Hf_invpayid.Value == "" || Hf_invpayid.Value == null)
                 {
                     ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('برجاء الاختيار  للحذف')", true);

                 }
                 else
                 {

                     (int erro_id, string error_msg) = ms.s_invpay_del(Convert.ToInt32(Hf_invpayid.Value));
                     gv_invpay.DataBind();
                     //update_inv_vatvalue();
                     Clear_pay();

                 }
             }
             catch (Exception ex)
             {
                 string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

                 ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
             }
         }*/

        protected void gv_invpay_DataBound(object sender, EventArgs e)
        {
            ASPxGridView gridView1 = sender as ASPxGridView;

            if (gridView1.GetTotalSummaryValue(gridView1.TotalSummary["payvalue"]) == null || gridView1.GetTotalSummaryValue(gridView1.TotalSummary["payvalue"]).ToString() == "")
            {
                return;
            }
            decimal rest = Math.Round(EmaxGlobals.NullToZero(gridView1.GetTotalSummaryValue(gridView1.TotalSummary["payvalue"])), 2);

            txt_restvalue.Text = Math.Round(EmaxGlobals.NullToZero(txt_netavat.Text) - rest, 2).ToString();
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
            dict.Add("inv_id", HF_sinvid.Value);

            return SqlCommandHelper.ExcecuteToDataTable("s_invpay_sel", dict).dataTable;

        }
        protected void gv_invpay_DataBinding(object sender, EventArgs e)
        {
            gv_invpay.DataSource = GvpaySource();
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

        #endregion



        #region upload and download files
        //ImageClickEventArgs
        protected void upload_Click(object sender, EventArgs e)
        {
            try
            {


                if (!Directory.Exists(Server.MapPath("~/Files/Sales/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Files/Sales/"));
                }

                if (txt_sinvno.Text == "تلقائى")
                {
                    if (FileUpload1.HasFile == false && lbl_invdoc.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('لا يوجد ملف للتحميل')", true);
                        return;
                    }
                    FileUpload1.SaveAs(Server.MapPath("~/Files/Sales/" + FileUpload1.FileName));
                    string pathfile = "~/Files/Sales/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                    //Session["pathfile"] = pathfile;
                    lbl_invdoc.Text = pathfile;
                }
                else
                {
                    string pathfile = null;
                    if (FileUpload1.HasFile == true)
                    {

                        FileUpload1.SaveAs(Server.MapPath("~/Files/Sales/" + FileUpload1.FileName));
                        pathfile = "~/Files/Sales/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                        lbl_invdoc.Text = pathfile;
                    }

                    else if (FileUpload1.HasFile == false && lbl_invdoc.Text != null || lbl_invdoc.Text != "")
                    {
                        if (lbl_invdoc.Text == "")
                        {
                            //sweetexception
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('لا يوجد ملف للتحميل')", true);
                            return;
                        }
                        pathfile = lbl_invdoc.Text;
                    }
                }

            }
            catch (Exception ex)
            {

                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }
        protected void btn_download_Click(object sender, EventArgs e)
        {
            try
            {
                //if (lbl_invdoc.Text == "") 
                //{
                //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('لا يوجد ملف')", true);
                //    return;
                //}
                string fileextantion = lbl_invdoc.Text;
                //int statrindex = ;
                fileextantion = fileextantion.Substring(fileextantion.Length - 3, 3);
                if (fileextantion == "lsx" || fileextantion == "LSX")
                    fileextantion = "xlsx";
                else if (fileextantion == "peg" || fileextantion == "PEG")
                    fileextantion = "jpeg";
                Response.Clear();
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = "File/" + fileextantion + "";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + txt_sinvno.Text + "." + fileextantion + "");
                Response.TransmitFile(Server.MapPath(lbl_invdoc.Text));
                Response.Flush();
                Response.End();
            }

            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                if (msg.Contains("لا يمكن أن يكون StartIndex أقل من الصفر.\\r\\nاسم المعلمة: startIndex") || msg.Contains("StartIndex cannot be less than zero.\\r\\nParameter name: startIndex"))
                    msg = "لا يوجد ملف لتحميله";

                //  ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetinfo('" + msg + "')", true);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }
        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                // gvitemsExporter.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType=ExportType.WYSIWYG});
                ExportingDevExpressUtil.Export(gvitemsExporter, "اصناف الفاتوره", 1, Request.GetOwinContext().Request.User.Identity.Name, gvs_invdtls.GetSelectedFieldValues("invdtlid").Count != 0, false, "أصناف الفاتوره رقم " + txt_sinvno.Text);
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

                var res = SaveData("s_inv_itemexcel_ins", new List<object> { HF_sinvid }, null,
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

        protected  async void btn_print_Click(object sender, EventArgs e)
        {
            var dict = new Dictionary<string, object>();
            RestClient restSharp = new RestClient(ConfigurationManager.AppSettings["apiroot"]+ "/VanSalesService/invoice/GetInvMasterQrData");
            RestRequest restRequest = new RestRequest();
            restRequest.Method = Method.Post;

            //restRequest.AddHeader("compvatno", SqlCommandHelper.GetTokenKey("compvatno", Request.Cookies["Token"].Value));
            //restRequest.AddHeader("fyear", SqlCommandHelper.GetTokenKey("fyear", Request.Cookies["Token"].Value));
            
            restRequest.AddQueryParameter("invno", txt_sinvno.Text);
            restRequest.AddQueryParameter("compenyname", SqlCommandHelper.GetTokenKey("compneyname", Request.Cookies["Token"].Value));
            restRequest.AddQueryParameter("vatnumber", SqlCommandHelper.GetTokenKey("compvatno", Request.Cookies["Token"].Value));
            restRequest.AddHeader("Authorization", "Bearer " + SqlCommandHelper.GetTokenKey("access_token", Request.Cookies["Token"].Value).ToString());
            RestResponse response=  await restSharp.ExecuteAsync(restRequest);
            if (response.IsSuccessful)
            {
                var ff = JObject.Parse(response.Content)["qrdata"].ToString();
                dict.Add("inv_id", HF_sinvid.Value);

                //TlvFormat t = EmaxGlobals.GetQrCodeDateData((SqlCommandHelper.GetTokenKey("compneyname", Request.Cookies["Token"].Value)
                //    , SqlCommandHelper.GetTokenKey("compvatno", Request.Cookies["Token"].Value),
                //    txt_sinvdata.Date,EmaxGlobals.NullToZeroDouble( txt_netavat.Text)
                //    , EmaxGlobals.NullToZeroDouble(txt_vatvalue.Text));
                dict.Add("qrdata", ff);
                PrintPage("sales/s_inv_page.repx", dict);
            }
            else
            {
            Response.Write( response.Content);

            }

        }

        protected void btn_print_paydoc_Click(object sender, EventArgs e)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("inv_id", HF_sinvid.Value);

            PrintPage("sales/s_inv_paydoc_page.repx", dict);
        }

        protected void ASPxPopupControl1_PopupWindowCommand(object source, PopupControlCommandEventArgs e)
        {
            var f = e.CommandName;
         
        }

        protected void ASPxPopupControl1_Unload(object sender, EventArgs e)
        {
            var f = "";
        }

        protected void ctn_add_cus_Click1(object sender, EventArgs e)
        {
          //  cmb_cusgroup.DataSource = "";

        }






        #endregion



        //protected void Pop_items_txt_key_valuechanged1()
        //{

        //}

        //protected void Pop_items_txt_key_valuechanged2()
        //{

        //}



        //protected void txt_custid_TextChanged(object sender, EventArgs e)
        //{
        // DataTable dt=  ms.s_customers_sel_custcode(txt_custid.Text);
        //    if (dt.Rows.Count > 0)
        //    {
        //        txt_custname.Text = dt.Rows[0]["custname"].ToString();
        //        txt_custadd.Text = dt.Rows[0]["custadd"].ToString();
        //        txt_custvat.Text = dt.Rows[0]["custvat"].ToString();
        //        txt_custmobile.Text = dt.Rows[0]["custmob"].ToString();
        //        Hf_cusid.Value = dt.Rows[0]["custid"].ToString();
        //        cmb_smanid.Text= dt.Rows[0]["smanname"].ToString();
        //        cmb_smanid.Value= dt.Rows[0]["smanid"].ToString();
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('هذا العميل غير موجود ')", true);
        //        txt_custid.Text = string.Empty;
        //        txt_custname.Text = string.Empty;
        //        txt_custadd.Text = string.Empty;
        //        txt_custvat.Text = string.Empty;

        //    }
        //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "cus_validate();", true);
        //}
        //protected void txt_custid_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        DataTable dt = ms.s_customers_sel_custcode(txt_custid.Text);
        //        if (dt.Rows.Count > 0)
        //        {
        //            txt_custname.Text = dt.Rows[0]["custname"].ToString();
        //            txt_custvat.Text = dt.Rows[0]["custvat"].ToString();
        //            txt_custadd.Text = dt.Rows[0]["custadd"].ToString();

        //            Hf_cusid.Value = dt.Rows[0]["custid"].ToString();
        //        }
        //        else
        //        {
        //            //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('هذا الكود غير موجود ')", true);
        //            //clear();

        //            txt_custname.Text = "";
        //            txt_custvat.Text = "";
        //            txt_custadd.Text = "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

        //        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
        //    }
        //}
    }

}