using Emax.Core.Utility;
using Emax.SharedLib;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.GL
{
    public partial class AccPay : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "36";
            IndexStored = "gl_accpay_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "1,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox("sys_paytype_sel", cmb_paytypeid, "", "", "paytypeid", "paytname");
            }
            gvaccpay.DataBind();
        }
        void clear()
        {
            hf_accpayid.Value = "0";
            cmb_paytypeid.SelectedIndex = 0;
            cmb_branchid.SelectedIndex = 0;
            hf_paychartid.Value = "0";
            txt_paychartcode.Text = null;
            txt_paychartname.Text = null;
            gvaccpay.Selection.CancelSelection();
        }
        protected void gvaccpay_DataBinding(object sender, EventArgs e)
        {
            gvaccpay.DataSource = IndexDataTable;
        }
        List<object> GetParam()
        {
            if (EmaxGlobals.NullToIntZero(hf_accpayid.Value) == 0)
            {
                return new List<object> { cmb_paytypeid, cmb_branchid, hf_paychartid, txt_paychartname };
            }
            else
            {
                return new List<object> { hf_accpayid,cmb_paytypeid, cmb_branchid, hf_paychartid, txt_paychartname };
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (EmaxGlobals.NullToIntZero(hf_paychartid.Value) == 0)
            {
                txt_paychartname.Text = null;
                string msg = "برجاء إختيار الحساب اولا";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('" + msg + "');", true);
                return;
            }
            StoredExecuteResulte res = new StoredExecuteResulte();
            if (EmaxGlobals.NullToIntZero(hf_accpayid.Value) == 0)
            {
                res = SaveData("gl_accpay_ins", GetParam(), null, null, true, false,
                    new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue = cmb_branchid }, new ParamObject() { ParamName = "paytypename", ParamValue = cmb_paytypeid } });
                gvaccpay.DataBind();
                clear();
            }
            else
            {
                res = SaveData("gl_accpay_upd", GetParam(), null, null, true, false,
                    new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue = cmb_branchid }, new ParamObject() { ParamName = "paytypename", ParamValue = cmb_paytypeid } });
                gvaccpay.DataBind();
                clear();
            }
        }

        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btn_xlsx_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle;
                exptitle = "حسابات طرق الدفع";
                ExportingDevExpressUtil.Export(gvaccpayExporter, "حسابات طرق الدفع", 1, Request.GetOwinContext().Request.User.Identity.Name,false, false, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_word_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle;
                exptitle = "حسابات طرق الدفع";
                ExportingDevExpressUtil.Export(gvaccpayExporter, "حسابات طرق الدفع", 0, Request.GetOwinContext().Request.User.Identity.Name, false, false, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_pdf_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle;
                exptitle = "حسابات طرق الدفع";
                ExportingDevExpressUtil.Export(gvaccpayExporter, "حسابات طرق الدفع", 2, Request.GetOwinContext().Request.User.Identity.Name, false, false, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle;
                exptitle = "حسابات طرق الدفع";
                ExportingDevExpressUtil.Export(gvaccpayExporter, "حسابات طرق الدفع", 2, Request.GetOwinContext().Request.User.Identity.Name, false, true, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }
    }
}