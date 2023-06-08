using DevExpress.Web;
using Emax.Dal;
using Emax.SharedLib;
using Newtonsoft.Json;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;

namespace VanSales.request
{
    public partial class request : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "27";
            IndexStored = "";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CmbItem = Util.GenerateGridViewCmb(gv_reqdtls, "st_items_sel", "itemid", "itemcode");
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_frombranchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                txt_reqdate.Date = DateTime.Now;
                txt_userreq.Text = Context.User.Identity.Name;
                try
                {
                    if (Request.QueryString["reqid"] != null && Request.QueryString["reqid"] != string.Empty)
                    {
                        HF_reqid.Value = Request.QueryString["reqid"];
                        Dictionary<object, object> dict = new Dictionary<object, object>();
                        dict.Add("reqid", HF_reqid.Value);
                        var f = SqlCommandHelper.ExcecuteToDataTable("p_request_sel_reqid", dict).dataTable;
                        gv_reqdtls.DataBind();
                        BindData(f.Rows[0]);
                        PDetiles.Style.Add("display", "block");
                    }
                    else if (HF_reqid.Value != "0")
                    {
                        Dictionary<object, object> dict = new Dictionary<object, object>();
                        dict.Add("reqid", HF_reqid.Value);
                        var f = SqlCommandHelper.ExcecuteToDataTable("p_request_sel_reqid", dict).dataTable;
                        gv_reqdtls.DataBind();
                        BindData(f.Rows[0]);
                        PDetiles.Style.Add("display", "block");
                    }
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("There is no row at position 0") || ex.Message.Contains("لا يوجد صف في الموضع 0"))
                    {
                        Response.Redirect("~/request/request.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('عذراً حدث خطأ غير متوقع')", true);
                    }
                }
            }
        }
        public GridViewDataComboBoxColumn CmbItem { get; set; }
        public ButtonRenderMode Secondary { get; private set; }

        void BindData(DataRow rec)
        {
            txt_reqno.Text = EmaxGlobals.NullToEmpty(rec["reqno"]);
            txt_reqdocno.Text = EmaxGlobals.NullToEmpty(rec["reqdocno"]);
            txt_reqdate.Date = (Convert.ToDateTime(rec["reqdate"]));
            cmb_branchid.Value = EmaxGlobals.NullToEmpty(rec["branchid"]);
            cmb_branchid.Text = EmaxGlobals.NullToEmpty(rec["branchname"]);
            txt_reqdesc.Text = EmaxGlobals.NullToEmpty(rec["reqdesc"]);
            txt_userreq.Text = EmaxGlobals.NullToEmpty(rec["userreq"]);
            lbl_reqaction.Text= EmaxGlobals.NullToEmpty(rec["reqaction"]);
            rbl_reqcase.Value = EmaxGlobals.NullToEmpty(rec["reqcase"]);
            HF_reqid.Value = EmaxGlobals.NullToEmpty(rec["reqid"]);
            txt_reqno.ClientReadOnly = true;
            txt_reqdate.ClientReadOnly = true;
            txt_userreq.ClientReadOnly = true;
            cmb_branchid.ClientReadOnly = true;
            if (rbl_reqcase.SelectedItem.Value.ToString() == "False")
            {
                disable();
                txt_reqno.ClientReadOnly = true;
                txt_reqdate.ClientReadOnly = true;
                cmb_branchid.ClientReadOnly = true;
                txt_userreq.ClientReadOnly = true;
                txt_itemid.ClientReadOnly = true;
                txt_item_name.ClientReadOnly = true;
                txt_unitname.ClientReadOnly = true;
                txt_qty.ClientReadOnly = true;
                txt_itemnotes.ClientReadOnly = true;
            }
            else
            {
                enable();
            }
            gv_reqdtls.DataBind();
        }
        List<object> GetParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_reqid.Value) == 0)
            {
                return new List<object> { txt_reqdocno, txt_reqdate, cmb_branchid, txt_reqdesc, txt_userreq , rbl_reqcase };
            }
            else
            {
                return new List<object> { HF_reqid, txt_reqdocno, txt_reqdesc , rbl_reqcase };
            }
        }

        void Clear()
        {
            txt_itemid.Text = null;
            HF_itemid.Value = null;
            txt_item_name.Text = null;
            txt_unitname.Text = null;
            HF_unitid.Value = null;
            txt_qty.Text = "1";
            txt_itemnotes.Text = null;
            HF_factor.Value = null;
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
            
            btn_transfer.Enabled = false;
            btn_transfer.CssClass = "disable";
            btn_transfer.RenderMode = Secondary;

            btn_delete_dtls.Enabled = false;
            btn_delete_dtls.CssClass = "disable";
            btn_delete_dtls.RenderMode = Secondary;

            btn_new_dtls.Enabled = false;
            btn_new_dtls.CssClass = "disable";
            btn_new_dtls.RenderMode = Secondary;

            btn_pinv.Enabled = false;
            btn_pinv.CssClass = "disable";
            btn_pinv.RenderMode = Secondary;

            rbl_reqcase.ClientReadOnly = true;
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

            btn_transfer.Enabled = true;
            btn_transfer.CssClass = "enable";

            btn_pinv.Enabled = true;
            btn_pinv.CssClass = "enable";


            btn_save_dtls.Enabled = true;
            btn_save_dtls.CssClass = "enable";

            btn_new_dtls.Enabled = true;
            btn_new_dtls.CssClass = "enable";

            rbl_reqcase.ClientReadOnly = false;
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            StoredExecuteResulte res = new StoredExecuteResulte();
            if (EmaxGlobals.NullToIntZero(HF_reqid.Value) == 0)
            {
                res = SaveData("p_request_ins", GetParam(), null, new List<string>() { "reqid", "reqno" }, true, true,
                    new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue = cmb_branchid } });
                PDetiles.Style.Add("display", "block");
                if (res.errorid == 0)
                {
                    if (res.outputparams.ContainsKey("reqid"))
                    {
                        HF_reqid.Value = res.outputparams["reqid"].ToString();
                    }
                    if (res.outputparams.ContainsKey("reqno"))
                    {
                        txt_reqno.Text = res.outputparams["reqno"].ToString();
                    }
                    txt_reqno.ClientReadOnly = true;
                    txt_reqdate.ClientReadOnly = true;
                    cmb_branchid.ClientReadOnly = true;
                    txt_userreq.ClientReadOnly = true;
                    if (rbl_reqcase.SelectedItem.Value.ToString() == "False")
                    {
                        disable();
                        txt_reqno.ClientReadOnly = true;
                        txt_reqdate.ClientReadOnly = true;
                        cmb_branchid.ClientReadOnly = true;
                        txt_userreq.ClientReadOnly = true;
                        txt_itemid.ClientReadOnly = true;
                        txt_item_name.ClientReadOnly = true;
                        txt_unitname.ClientReadOnly = true;
                        txt_qty.ClientReadOnly = true;
                        txt_itemnotes.ClientReadOnly = true;
                    }
                    else
                    {
                        enable();
                    }
                }
            }
            else
            {
                res = SaveData("p_request_upd", GetParam(), null, null, true, false, null);
                if (res.errorid == 0)
                {
                    txt_reqno.ClientReadOnly = true;
                    txt_reqdate.ClientReadOnly = true;
                    cmb_branchid.ClientReadOnly = true;
                    txt_userreq.ClientReadOnly = true;
                    if (rbl_reqcase.SelectedItem.Value.ToString() == "False")
                    {
                        disable();
                        txt_reqno.ClientReadOnly = true;
                        txt_reqdate.ClientReadOnly = true;
                        cmb_branchid.ClientReadOnly = true;
                        txt_userreq.ClientReadOnly = true;
                        txt_itemid.ClientReadOnly = true;
                        txt_item_name.ClientReadOnly = true;
                        txt_unitname.ClientReadOnly = true;
                        txt_qty.ClientReadOnly = true;
                        txt_itemnotes.ClientReadOnly = true;
                    }
                    else
                    {
                        enable();
                    }
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('تم الحفظ بنجاح')", true);
                }
            }
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static string Deletedata(int reqid)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("reqid", reqid);
            var res = SqlCommandHelper.ExecuteNonQuery("p_request_del", dict, true);
            return JsonConvert.SerializeObject(res);
        }

        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            txt_reqno.Text = "تلقائى";
            txt_reqdocno.Text = null;
            txt_reqdate.Date = DateTime.Now.Date;
            cmb_branchid.SelectedIndex = 0;
            txt_reqdesc.Text = null;
            txt_userreq.Text = Context.User.Identity.Name;
            rbl_reqcase.SelectedIndex = 0;
            lbl_reqaction.Text = null;
            txt_itemid.Text = null;
            HF_itemid.Value = null;
            txt_item_name.Text = null;
            txt_unitname.Text = null;
            HF_unitid.Value = null;
            txt_qty.Text = "1";
            txt_qty.ClientReadOnly = false;
            txt_itemnotes.Text = null;
            HF_factor.Value = null;
            HF_reqdtlis.Value = "0";
            HF_reqid.Value = "0";
            gv_reqdtls.DataBind();
            PDetiles.Style.Add("display", "none");
            enable();
        }

        protected void btn_save_dtls_Click(object sender, EventArgs e)
        {
            var res = SaveData(EmaxGlobals.NullToIntZero(HF_reqdtlis.Value) == 0 ? "p_reqdtls_ins": "p_reqdtls_upd", new List<object> { HF_reqdtlis,HF_reqid, HF_itemid, HF_unitid, txt_unitname, HF_factor, txt_qty, txt_itemnotes, cmb_branchid , txt_reqdate},null, null, true, true,null);
            gv_reqdtls.DataBind();
            HF_reqdtlis.Value = "0";
            Clear();
        }

        protected void gv_reqdtls_DataBinding(object sender, EventArgs e)
        
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("reqid", HF_reqid.Value);
            gv_reqdtls.DataSource = SqlCommandHelper.ExcecuteToDataTable("p_reqdtls_sel", dict).dataTable;
        }

        protected void gv_reqdtls_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            var rcase = e.Parameters.Split(',');
            if (rcase.Length !=1)
            {
                if (EmaxGlobals.NullToEmpty( rcase[0]) == "false")
                {
                  
                    rbl_reqcase.SelectedIndex = 1;
                    disable();
                    txt_reqno.ClientReadOnly = true;
                    txt_reqdate.ClientReadOnly = true;
                    cmb_branchid.ClientReadOnly = true;
                    txt_userreq.ClientReadOnly = true;
                    txt_item_name.ClientReadOnly = true;
                    txt_unitname.ClientReadOnly = true;
                    txt_qty.ClientReadOnly = true;
                    txt_itemnotes.ClientReadOnly = true;
                }
                else
                {
                    rbl_reqcase.SelectedIndex = 0;
                    enable();
                    txt_reqno.ClientReadOnly = false;
                    txt_reqdate.ClientReadOnly = false;
                    cmb_branchid.ClientReadOnly = false;
                    txt_userreq.ClientReadOnly = false;
                    txt_item_name.ClientReadOnly = false;
                    txt_unitname.ClientReadOnly = false;
                    txt_qty.ClientReadOnly = false;
                    txt_itemnotes.ClientReadOnly = false;
                }
                if (EmaxGlobals.NullToIntZero(rcase[1]) == 1)
                {
                    lbl_reqaction.Text = null;
                }
                else
                {
                    lbl_reqaction.Text = rcase[1];
                }
                PDetiles.Style.Add("display", "block");
                gv_reqdtls.DataBind();
            }
        }

        protected void btn_pinv_Click(object sender, EventArgs e)
        {
            try
            {
                var res = SaveData("p_inv_ins_req", new List<object> { HF_reqid }, null, new List<string>() { "reqaction" }, true, false, null);
                if (res.errorid == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                    lbl_reqaction.Text = EmaxGlobals.NullToEmpty(res.outputparams["reqaction"]);
                    rbl_reqcase.SelectedIndex = 1;
                    disable();
                }
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + msg + ")", true);
            }
            gv_reqdtls.DataBind();
        }

        protected void btn_transfer_ins_Click(object sender, EventArgs e)
        {
            try
            {
                var res = SaveData("p_req_trans_ins", new List<object> { HF_reqid,cmb_frombranchid }, null, new List<string>() { "reqaction" }, true, true, null);
                if (res.errorid == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                    lbl_reqaction.Text = EmaxGlobals.NullToEmpty(res.outputparams["reqaction"]);
                    rbl_reqcase.SelectedIndex = 1;
                    disable();
                }
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + msg + ")", true);
            }
            gv_reqdtls.DataBind();
        }
    }
}