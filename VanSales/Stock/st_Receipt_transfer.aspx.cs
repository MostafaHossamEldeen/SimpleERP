using DevExpress.Web;
using Emax.Core.Utility;
using Emax.Dal;
using Emax.SharedLib;
using Newtonsoft.Json;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.Stock
{
    public partial class st_Receipt_transfer : EmaxBasepage
    {
        public ButtonRenderMode Secondary { get; private set; }

        protected override void OnInit(EventArgs e)
        {
            pageid = "23";

            base.OnInit(e);
        }
        void disable()
        {
            btn_Save.Enabled = false;
            btn_Save.CssClass = "disable";
            btn_Save.RenderMode = Secondary;           
        }
        void enable()
        {
            btn_Save.Enabled = true;
            btn_Save.CssClass = "enable";            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchtoid, "compid,table_name", "1,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_ccid, "compid,table_name", "0,sys_costcenter", "ccid", "ccname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_cctoid, "compid,table_name", "0,sys_costcenter", "ccid", "ccname");
                
                cmb_branchtoid.SelectedIndex = -1;
                cmb_branchid.SelectedIndex = -1;
                cmb_ccid.SelectedIndex = -1;
                cmb_cctoid.SelectedIndex = -1;
                txt_username.Text = Context.User.Identity.Name;
            }
        }
        List<object> GetresevParams()
        {

            return new List<object>
           {  txt_trandocno, txt_trandate, cmb_branchid,cmb_branchtoid, cmb_ccid, cmb_cctoid, txt_trannotes, txt_username,txt_transno,HF_transid };
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            var res = SaveData("st_transactions_resev_ins"
     , GetresevParams(), null,
             new List<string>() { "transno_trans","id" }, true, true,
             new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue = cmb_branchid }
                ,new ParamObject() { ParamName = "branchtoname", ParamValue = cmb_branchtoid }
                ,new ParamObject() { ParamName = "ccname", ParamValue = cmb_ccid }
                ,new ParamObject() { ParamName = "cctoname", ParamValue = cmb_cctoid }});
            if (res.errorid == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                if (res.outputparams.ContainsKey("transno_trans"))
                {
                    //txt_resev.Visible = true;
                    txt_resev.Text = EmaxGlobals.NullToEmpty(res.outputparams["transno_trans"]);
                }
                if (res.outputparams.ContainsKey("id"))
                {
                    //txt_resev.Visible = true;
                    HF_recepitid.Value = EmaxGlobals.NullToEmpty(res.outputparams["id"]);
                }
                disable();

            }
        }
        DataTable GvdetailSource()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("transid", HF_transid.Value);

            return SqlCommandHelper.ExcecuteToDataTable("st_transdtls_trans_sel", dict).dataTable;

        }
        protected void gvs_transdtls_DataBinding(object sender, EventArgs e)
        {
       
            gvs_transdtls.DataSource = GvdetailSource();
        }
        protected void gvs_transdtls_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            var post = e.Parameters.Split(',');
            if (post.Length != 1)
            {
                if (EmaxGlobals.NullToBool(post[0]) == true)
                {
                    lbl_postst.Text = "مرحل مستودعات";
                    disable();

                }
                else
                {
                    lbl_postst.Text = "";
                    enable();
                }

                if (EmaxGlobals.NullToBool(post[1]) == true)
                {
                    lbl_postacc.Text = "مرحل حسابات";
                    disable();

                }
                else
                {
                    lbl_postacc.Text = "";
                    enable();
                }
            }
            gvs_transdtls.DataBind();
            PDetiles.Style.Add("display", "block");

        }

        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            txt_transno.Text=string.Empty;
            txt_trandocno.Text=string.Empty;
            txt_trannotes.Text = string.Empty;
            txt_username.Text = Context.User.Identity.Name;
            //   // txt_trandate.Date = new Date(DateTime.Now);
            cmb_branchid.Text = string.Empty;
            cmb_branchtoid.Text = string.Empty;
            cmb_ccid.Text = string.Empty;
            cmb_cctoid.Text = string.Empty;
            HF_transid.Value = string.Empty;
            HF_recepitid.Value = string.Empty;
            HF_isreceipt.Value = string.Empty;
            hf_postst.Value = string.Empty;
            hf_postacc.Value = string.Empty; 
            lbl_postacc.Text = string.Empty;
            lbl_postst.Text = string.Empty;
            txt_issordno.Text = string.Empty;
            txt_resev.Text = string.Empty;
            enable();
            gvs_transdtls.DataBind();
            PDetiles.Style.Add("display", "none");
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                // gvitemsExporter.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType=ExportType.WYSIWYG});
                ExportingDevExpressUtil.Export(gvitemsExporter, "تفاصيل اذون الاستلام", 1, Request.GetOwinContext().Request.User.Identity.Name, gvs_transdtls.GetSelectedFieldValues("transdtlid").Count != 0, false, "تفاصيل اذن الاستلام رقم " + txt_transno.Text);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }
    }
}