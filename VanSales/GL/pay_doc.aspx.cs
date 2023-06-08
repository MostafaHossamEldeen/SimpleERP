using Emax.Dal;
using Emax.SharedLib;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.GL
{
    public partial class pay_doc : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "38";

            base.OnInit(e);
        }
        void clear()
        {
            HF_pdid.Value = string.Empty;
            HF_paychartid.Value = string.Empty;
            HF_paidchartid.Value = string.Empty;
            HF_postacc.Value = string.Empty;
            txt_pddocno.Text = string.Empty;
            txt_pdno.Text = "تلقائى";
            txt_pddate.Date = DateTime.Now;
            cmb_pdbranchid.Value = "";
            cmb_pdbranchid.Text = string.Empty;
            cmb_pdbranchid.SelectedIndex = 0;
            cmb_pdbranchid.ClientEnabled = true;
            rbl_vattype.ClientEnabled = true;
            txt_pdman.Text = string.Empty;
            txt_paidto.Text = string.Empty;
            cmb_ccid.Value = "";
            cmb_ccid.Text = "";
            txt_vchrid.Text = string.Empty;
            txt_pdnotes.Text = string.Empty;
            cmb_paytypeid.Value = "";
            cmb_paytypeid.Text = "";
            cmb_paytypeid.SelectedIndex = 0;
            txt_paychartid.Text = string.Empty;
            txt_chartname.Text = string.Empty;
            txt_payref.Text = string.Empty;
            txt_paidchartid.Text = string.Empty;
            txt_paidchartname.Text = string.Empty;
            txt_paynotes.Text = string.Empty;
            cmb_paidtype.Value = "";
            cmb_paidtype.Text = "";
            cmb_paidtype.SelectedIndex = 0;
            lbl_postacc.Text = string.Empty;
            lbl_pddocimg1.Text = string.Empty;
            lbl_pddocimg.Value = "";
            txt_vatvalue.Text= SqlCommandHelper.GetTokenKey("vat", Request.Cookies["Token"].Value);
            txt_pdavat.Text = "0";
            txt_pdbvat.Text = "0";
            rbl_vattype.SelectedIndex = 0;
            txt_pduser.Text = Context.User.Identity.Name;

        }
        void BindData(DataRow rec)
        {
            HF_pdid.Value = EmaxGlobals.NullToEmpty(rec["pdid"]);
            txt_pddocno.Text = EmaxGlobals.NullToEmpty(rec["pddocno"]);
            txt_pddate.Date = Convert.ToDateTime(rec["pddate"]);
            cmb_pdbranchid.Value = EmaxGlobals.NullToEmpty(rec["pdbranchid"]);
            cmb_pdbranchid.Text = EmaxGlobals.NullToEmpty(rec["branchname"]);
            cmb_paidtype.Text = EmaxGlobals.NullToEmpty(rec["paidtypename"]);
            cmb_paidtype.Value = EmaxGlobals.NullToEmpty(rec["paidtype"]);
            cmb_ccid.Text = EmaxGlobals.NullToEmpty(rec["ccname"]);
            cmb_ccid.Value = EmaxGlobals.NullToEmpty(rec["ccid"]);
            txt_pdman.Text = EmaxGlobals.NullToEmpty(rec["pdman"]);
            HF_paychartid.Value = EmaxGlobals.NullToEmpty(rec["paychartid"]);
            txt_chartname.Text = EmaxGlobals.NullToEmpty(rec["payname"]);
            txt_paychartid.Text = EmaxGlobals.NullToEmpty(rec["paychartno"]);
            HF_paidchartid.Value = EmaxGlobals.NullToEmpty(rec["paidchartid"]);
            txt_paidchartid.Text = EmaxGlobals.NullToEmpty(rec["paidchartid"]);
            txt_paidchartname.Text = EmaxGlobals.NullToEmpty(rec["paidchartname"]);
            txt_vchrid.Text = EmaxGlobals.NullToEmpty(rec["vchrno"]);
            txt_paidto.Text = EmaxGlobals.NullToEmpty(rec["paidto"]);
            rbl_vattype.Value = EmaxGlobals.NullToEmpty(rec["vattype"]);
            txt_pdbvat.Text = EmaxGlobals.NullToEmpty(rec["pdbvat"]);
            txt_pdavat.Text = EmaxGlobals.NullToEmpty(rec["pdavat"]);
            txt_vatvalue.Text = EmaxGlobals.NullToEmpty(rec["vatvalue"]);
            txt_pdnotes.Text = EmaxGlobals.NullToEmpty(rec["pdnotes"]);
            txt_pduser.Text = EmaxGlobals.NullToEmpty(rec["pduser"]);
            cmb_paytypeid.Text = EmaxGlobals.NullToEmpty(rec["paytypename"]);
            cmb_paytypeid.Value = EmaxGlobals.NullToEmpty(rec["paytypeid"]);
            txt_payref.Text = EmaxGlobals.NullToEmpty(rec["payref"]);
            txt_paynotes.Text = EmaxGlobals.NullToEmpty(rec["paynotes"]);
            HF_postacc.Value = EmaxGlobals.NullToEmpty(rec["postacc"]);
            lbl_pddocimg.Value= EmaxGlobals.NullToEmpty(rec["pddocimg"]);
            lbl_pddocimg1.Text= EmaxGlobals.NullToEmpty(rec["pddocimg"]);


        }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                Util.GenerateRadioButtonList("sys_fillcomp_sel", rbl_vattype, "compid,table_name", "3,sys_fillcomp", "citemid", "citemname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_paidtype, "compid,table_name", "17,sys_fillcomp", "citemid", "citemname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_pdbranchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_ccid, "compid,table_name", "0,sys_costcenter", "ccid", "ccname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_paytypeid, "compid,table_name,model", "0,sys-paytype,3", "paytypeid", "paytname");
                txt_pddate.Date = DateTime.Now;
                cmb_ccid.SelectedIndex = -1;
                txt_pduser.Text = Context.User.Identity.Name;
                txt_vatvalue.Text= SqlCommandHelper.GetTokenKey("vat", Request.Cookies["Token"].Value);
                txt_pdavat.Text = "0";
                txt_pdbvat.Text = "0";

                if (Request.QueryString["pdno"] != null && Request.QueryString["pdno"] != string.Empty)
                {
                    txt_pdno.Text = Request.Params["pdno"];
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("pdno", txt_pdno.Text);
                    var f = SqlCommandHelper.ExcecuteToDataTable("pay_doc_pdno_sel", dict).dataTable;

                    BindData(f.Rows[0]);

                    rbl_vattype.ClientEnabled = false;
                    cmb_pdbranchid.ClientEnabled = false;
                }
            }
        }
        List<object> GetParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_pdid.Value) == 0)
            {
                return new List<object> { txt_pddocno, txt_pddate, cmb_pdbranchid, txt_pdman, txt_paidto, cmb_ccid, txt_vchrid, txt_pduser, txt_pdnotes, cmb_paytypeid, HF_paychartid, txt_payref, HF_paidchartid, txt_paynotes, cmb_paidtype, lbl_pddocimg,txt_vatvalue,txt_pdbvat,txt_pdavat, rbl_vattype };
            }
            else
            {
                return new List<object> { HF_pdid, txt_pddocno, txt_pddate, cmb_pdbranchid, txt_pdman, txt_paidto, cmb_ccid, txt_vchrid, txt_pduser, txt_pdnotes, cmb_paytypeid, HF_paychartid, txt_payref, HF_paidchartid, txt_paynotes, cmb_paidtype, lbl_pddocimg, txt_vatvalue, txt_pdbvat, txt_pdavat, rbl_vattype };
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            Dictionary<object, object> dictvattypename = new Dictionary<object, object>();
            dictvattypename.Add("vattypename", rbl_vattype.SelectedItem.Text);
            var res = SaveData(EmaxGlobals.NullToIntZero(HF_pdid.Value) == 0 ? "pay_doc_ins" : "pay_doc_upd"
, GetParam(), null,
        EmaxGlobals.NullToIntZero(HF_pdid.Value) == 0 ? new List<string>() { "id", "pdno" } : new List<string>() { "id" }, true, true,
        new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue = cmb_pdbranchid },
         new ParamObject() { ParamName = "paidtypename", ParamValue = cmb_paidtype },
         new ParamObject() { ParamName = "paytypename", ParamValue = cmb_paytypeid },
         new ParamObject() { ParamName = "ccname", ParamValue = cmb_ccid },
         new ParamObject() { ParamName = "ccname", ParamValue = cmb_ccid }}
        ,dictvattypename);

            if (res.errorid == 0)
            {
                if (EmaxGlobals.NullToIntZero(HF_pdid.Value) != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                    lbl_pddocimg1.Text = lbl_pddocimg.Value;
                }
                HF_pdid.Value = res.outputparams != null && res.outputparams.Count > 0 ? EmaxGlobals.NullToEmpty(res.outputparams["id"]) : "";

                if (res.outputparams.ContainsKey("pdno"))
                {
                    txt_pdno.Text = EmaxGlobals.NullToEmpty(res.outputparams["pdno"]);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                }

                cmb_pdbranchid.ClientEnabled = false;
                //rbl_vattype.ClientEnabled = false;
            }
        }

        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void upload_Click(object sender, EventArgs e)
        {
            try
            {


                if (!Directory.Exists(Server.MapPath("~/Files/pay_doc/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Files/pay_doc/"));
                }

                if (txt_pdno.Text == "تلقائى")
                {
                    if (FileUpload1.HasFile == false && lbl_pddocimg1.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('لا يوجد ملف للتحميل')", true);
                        return;
                    }
                    FileUpload1.SaveAs(Server.MapPath("~/Files/pay_doc/" + FileUpload1.FileName));
                    string pathfile = "~/Files/pay_doc/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                    //Session["pathfile"] = pathfile;
                    lbl_pddocimg1.Text = pathfile;
                    lbl_pddocimg.Value = pathfile;
                }
                else
                {
                    string pathfile = null;
                    if (FileUpload1.HasFile == true)
                    {

                        FileUpload1.SaveAs(Server.MapPath("~/Files/pay_doc/" + FileUpload1.FileName));
                        pathfile = "~/Files/pay_doc/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                        lbl_pddocimg1.Text = pathfile;
                        lbl_pddocimg.Value = pathfile;
                    }

                    else if (FileUpload1.HasFile == false && lbl_pddocimg1.Text != null || lbl_pddocimg1.Text != "")
                    {
                        if (lbl_pddocimg1.Text == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('لا يوجد ملف للتحميل')", true);
                            return;
                        }
                        pathfile = lbl_pddocimg1.Text;
                        pathfile = lbl_pddocimg.Value;
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
                string fileextantion = lbl_pddocimg.Value;
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
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + txt_pdno.Text + "." + fileextantion + "");
                Response.TransmitFile(Server.MapPath(lbl_pddocimg.Value));
                Response.Flush();
                Response.End();
            }

            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                if (msg.Contains("لا يمكن أن يكون StartIndex أقل من الصفر.\\r\\nاسم المعلمة: startIndex") || msg.Contains("StartIndex cannot be less than zero.\\r\\nParameter name: startIndex"))
                    msg = "لا يوجد ملف لتحميله";

                //  ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetinfo('" + msg + "')", true);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('" + msg + "')", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("pdid", HF_pdid.Value);

            PrintPage("pay_rec/pay_doc_page.repx", dict);
        }
    }
}