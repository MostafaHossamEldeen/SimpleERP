using Emax.Dal;
using Emax.SharedLib;
using Emax.Core.Utility;
using DevExpress.Web;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;

namespace VanSales.GL
{
    public partial class rec_doc : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "35";

            base.OnInit(e);
        }
        void clear()
        {
            HF_recid.Value = string.Empty;
            HF_paychartid.Value = string.Empty;
            HF_fromchartid.Value = string.Empty;
            HF_postacc.Value = string.Empty;
            txt_recdocno.Text = string.Empty;
            txt_recno.Text= "تلقائى";
            txt_recdate.Date = DateTime.Now;
            cmb_recbranchid.Value = "";
            cmb_recbranchid.Text = string.Empty;
            cmb_recbranchid.SelectedIndex = 0;
            cmb_recbranchid.ClientEnabled = true;
            txt_recman.Text = string.Empty;
            txt_recvalue.Text = string.Empty;
            cmb_ccid.Value = "";
            cmb_ccid.Text = "";
            cmb_smanid.Value = "";
            cmb_smanid.Text = "";
            txt_vochrid.Text = string.Empty;
            txt_recnotes.Text = string.Empty;
            cmb_paytypeid.Value = "";
            cmb_paytypeid.Text = "";
            cmb_paytypeid.SelectedIndex = 0;
            txt_paychartid.Text = string.Empty;
            txt_chartname.Text = string.Empty;
            txt_payref.Text = string.Empty;
            txt_fromchartid.Text = string.Empty;
            txt_fromchartname.Text = string.Empty;
            txt_paynotes.Text = string.Empty;
            cmb_rectype.Value = "";
            cmb_rectype.Text = "";
            cmb_rectype.SelectedIndex = 0;
            lbl_postacc.Text = string.Empty;
            lbl_recdocimg1.Text = string.Empty;
            lbl_recdocimg.Value = "";
            txt_recuser.Text= Context.User.Identity.Name;

        }
        void BindData(DataRow rec)
        {
            HF_recid.Value = EmaxGlobals.NullToEmpty(rec["recid"]);
            txt_recdocno.Text = EmaxGlobals.NullToEmpty(rec["recdocno"]);
            txt_recdate.Date = Convert.ToDateTime(rec["recdate"]);
            cmb_recbranchid.Value = EmaxGlobals.NullToEmpty(rec["recbranchid"]);
            cmb_recbranchid.Text = EmaxGlobals.NullToEmpty(rec["branchname"]);
            cmb_rectype.Text = EmaxGlobals.NullToEmpty(rec["rectypename"]);
            cmb_rectype.Value = EmaxGlobals.NullToEmpty(rec["rectype"]);
            cmb_ccid.Text = EmaxGlobals.NullToEmpty(rec["ccname"]);
            cmb_ccid.Value = EmaxGlobals.NullToEmpty(rec["ccid"]);
            cmb_smanid.Text = EmaxGlobals.NullToEmpty(rec["smanname"]);
            cmb_smanid.Value = EmaxGlobals.NullToEmpty(rec["smanid"]);
            txt_recman.Text = EmaxGlobals.NullToEmpty(rec["recman"]);
             HF_paychartid.Value = EmaxGlobals.NullToEmpty(rec["paychartid"]);
             txt_chartname.Text = EmaxGlobals.NullToEmpty(rec["payname"]);
            txt_paychartid.Text= EmaxGlobals.NullToEmpty(rec["paychartno"]);
            HF_fromchartid.Value= EmaxGlobals.NullToEmpty(rec["fromchartid"]);
            txt_fromchartid.Text= EmaxGlobals.NullToEmpty(rec["fromchartno"]);
            txt_fromchartname.Text= EmaxGlobals.NullToEmpty(rec["fromchartname"]);
            txt_vochrid.Text= EmaxGlobals.NullToEmpty(rec["vchrno"]);

            txt_recvalue.Text = EmaxGlobals.NullToEmpty(rec["recvalue"]);
            txt_recnotes.Text = EmaxGlobals.NullToEmpty(rec["recnotes"]);
            txt_recuser.Text = EmaxGlobals.NullToEmpty(rec["recuser"]);
            cmb_paytypeid.Text = EmaxGlobals.NullToEmpty(rec["paytypename"]);
            cmb_paytypeid.Value = EmaxGlobals.NullToEmpty(rec["paytypeid"]);
            txt_payref.Text = EmaxGlobals.NullToEmpty(rec["payref"]);
            txt_paynotes.Text = EmaxGlobals.NullToEmpty(rec["paynotes"]);         
            HF_postacc.Value = EmaxGlobals.NullToEmpty(rec["postacc"]);
            lbl_recdocimg.Value = EmaxGlobals.NullToEmpty(rec["recdocimg"]);
            lbl_recdocimg1.Text = EmaxGlobals.NullToEmpty(rec["recdocimg"]);
            
             
             
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_rectype, "compid,table_name", "16,sys_fillcomp", "citemid", "citemname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_recbranchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_ccid, "compid,table_name", "0,sys_costcenter", "ccid", "ccname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_paytypeid, "compid,table_name,model", "0,sys-paytype,2", "paytypeid", "paytname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_smanid, "compid,table_name", "0,s_sman","smanid","smanname");
                txt_recdate.Date = DateTime.Now;
                cmb_ccid.SelectedIndex = -1;
                cmb_smanid.SelectedIndex = -1;
                
                txt_recuser.Text = Context.User.Identity.Name;


                if (Request.QueryString["recno"] != null && Request.QueryString["recno"] != string.Empty)
                {
                    txt_recno.Text = Request.Params["recno"];
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("recno", txt_recno.Text);
                    var f = SqlCommandHelper.ExcecuteToDataTable("[rec_doc_recno_sel]", dict).dataTable;

                    BindData(f.Rows[0]);

                    cmb_recbranchid.ClientEnabled = false;
                    


                }
            }
           
        }

        List<object> GetParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_recid.Value) == 0)
            {
                return new List<object> { txt_recdocno, txt_recdate, cmb_recbranchid, txt_recman, txt_recvalue, cmb_ccid, txt_vochrid, txt_recuser, txt_recnotes, cmb_paytypeid, HF_paychartid, txt_payref, HF_fromchartid, txt_paynotes, cmb_rectype, lbl_recdocimg1 , cmb_smanid };
            }
            else
            {
                return new List<object> { HF_recid, txt_recdocno, txt_recdate, cmb_recbranchid, txt_recman, txt_recvalue, cmb_ccid, txt_vochrid, txt_recuser, txt_recnotes, cmb_paytypeid, HF_paychartid, txt_payref, HF_fromchartid, txt_paynotes, cmb_rectype, lbl_recdocimg , cmb_smanid };
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            
            var res = SaveData(EmaxGlobals.NullToIntZero(HF_recid.Value) == 0 ? "rec_doc_ins" : "rec_doc_upd"
 , GetParam(), null,
         EmaxGlobals.NullToIntZero(HF_recid.Value) == 0 ? new List<string>() { "id", "recno" } : new List<string>() { "id" }, true, true,
         new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue = cmb_recbranchid },
         new ParamObject() { ParamName = "rectypename", ParamValue = cmb_rectype },
         new ParamObject() { ParamName = "paytypename", ParamValue = cmb_paytypeid },
         new ParamObject() { ParamName = "ccname", ParamValue = cmb_ccid },
         new ParamObject() { ParamName = "smanname", ParamValue = cmb_smanid }
       });

            if (res.errorid == 0)
            {
                if (EmaxGlobals.NullToIntZero(HF_recid.Value) != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                    lbl_recdocimg1.Text = lbl_recdocimg.Value;
                }
                HF_recid.Value = res.outputparams != null && res.outputparams.Count > 0 ? EmaxGlobals.NullToEmpty(res.outputparams["id"]) : "";

                if (res.outputparams.ContainsKey("recno"))
                {
                    txt_recno.Text = EmaxGlobals.NullToEmpty(res.outputparams["recno"]);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                }

                cmb_recbranchid.ClientEnabled = false;

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


                if (!Directory.Exists(Server.MapPath("~/Files/rec_doc/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Files/rec_doc/"));
                }

                if (txt_recno.Text == "تلقائى")
                {
                    if (FileUpload1.HasFile == false && lbl_recdocimg1.Text == "")
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('لا يوجد ملف للتحميل')", true);
                        return;
                    }
                    FileUpload1.SaveAs(Server.MapPath("~/Files/rec_doc/" + FileUpload1.FileName));
                    string pathfile = "~/Files/rec_doc/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                    //Session["pathfile"] = pathfile;
                    lbl_recdocimg1.Text = pathfile;
                    lbl_recdocimg.Value = pathfile;
                }
                else
                {
                    string pathfile = null;
                    if (FileUpload1.HasFile == true)
                    {

                        FileUpload1.SaveAs(Server.MapPath("~/Files/rec_doc/" + FileUpload1.FileName));
                        pathfile = "~/Files/rec_doc/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
                        lbl_recdocimg1.Text = pathfile;
                        lbl_recdocimg.Value = pathfile;
                    }

                    else if (FileUpload1.HasFile == false && lbl_recdocimg1.Text != null || lbl_recdocimg1.Text != "")
                    {
                        if (lbl_recdocimg1.Text == "")
                        {
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('لا يوجد ملف للتحميل')", true);
                            return;
                        }
                        pathfile = lbl_recdocimg1.Text;
                        pathfile = lbl_recdocimg.Value;
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
            string fileextantion = lbl_recdocimg.Value;
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
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + txt_recno.Text + "." + fileextantion + "");
            Response.TransmitFile(Server.MapPath(lbl_recdocimg.Value));
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
            dict.Add("recid", HF_recid.Value);

            PrintPage("pay_rec/rec_doc_page.repx", dict);
        }
    }
}