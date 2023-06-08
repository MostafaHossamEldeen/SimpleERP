using DevExpress.Web;
using Emax.Core.Utility;
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
    public partial class Vouchers : EmaxBasepage
    {
        public ButtonRenderMode Secondary { get; private set; }
        protected override void OnInit(EventArgs e)
        {
            pageid = "33";

            base.OnInit(e);
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

            btn_postacc.Enabled = false;
            btn_postacc.CssClass = "disable";
            btn_postacc.RenderMode = Secondary;

            btn_delete_dtls.Enabled = false;
            btn_delete_dtls.CssClass = "disable";
            btn_delete_dtls.RenderMode = Secondary;

            btn_fastinsert.Enabled = false;
            btn_fastinsert.CssClass = "disable";
            btn_fastinsert.RenderMode = Secondary;

            btn_attach.Enabled = false;
            btn_attach.CssClass = "disable";
            btn_attach.RenderMode = Secondary;

            upload.Enabled = false;
            upload.CssClass = "disable";
            upload.RenderMode = Secondary;
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

            btn_postacc.Enabled = true;
            btn_postacc.CssClass = "enable";

            btn_attach.Enabled = true;
            btn_attach.CssClass = "enable";

            btn_fastinsert.Enabled = true;
            btn_fastinsert.CssClass = "enable";

            upload.Enabled = true;
            upload.CssClass = "enable";
        }
        void clear()
        {

            txt_vchrno.Text = "تلقائى";
            txt_vchrdocno.Text = string.Empty;
            txt_vchrdesc.Text = string.Empty;
            
            cmb_vchrtype.SelectedIndex = 1;
            txt_vchrdate.Date = DateTime.Now;
            HF_vchrid.Value = "";
            hf_postacc.Value = "";
            HF_uservchr.Value = "";
            lbl_postacc.Text = string.Empty;
            lbl_docpath.Text = string.Empty;
            txt_vuser.Text = Context.User.Identity.Name;
            txt_puser.Text = string.Empty;
            txt_vrfrance.Text = string.Empty;
            enable();

            PDetiles.Style.Add("display", "none");
            Clear_dtl();
            gvs_vchrdtls.DataBind();
        }

        private void Clear_dtl()
        {
            txt_chartid.Text = string.Empty;
            txt_chartname.Text = string.Empty;
            txt_ref.Text = string.Empty;
            txt_credit.Text ="0";
            txt_debit.Text = "0";
            HF_chartid.Value = "";
            HF_vchrdtlid.Value = "";
            txt_descp.Text = string.Empty;
            cmb_ccid.Text = string.Empty;
            cmb_ccid.Value = "";
        }
        void binddata(DataRow rec)
        {
            txt_vchrno.Text = EmaxGlobals.NullToEmpty( rec["vchrno"]);
            txt_vchrdocno.Text = EmaxGlobals.NullToEmpty(rec["vchrdocno"]);
            txt_vchrdate.Date = Convert.ToDateTime (rec["vchrdate"]);
            cmb_vchrtype.Value = EmaxGlobals.NullToEmpty(rec["vchrtype"]);
            cmb_vchrtype.Text = EmaxGlobals.NullToEmpty(rec["vchrtypename"]);
            txt_vuser.Text = EmaxGlobals.NullToEmpty(rec["vuser"]);
            txt_vrfrance.Text = EmaxGlobals.NullToEmpty(rec["vrfrance"]);
            txt_puser.Text = EmaxGlobals.NullToEmpty(rec["puser"]);
            ch_uservchr.Value = EmaxGlobals.NullToBool(rec["uservchr"]);
            HF_vchrid.Value= EmaxGlobals.NullToEmpty(rec["vchrid"]);
            txt_vchrdesc.Text= EmaxGlobals.NullToEmpty(rec["vchrdesc"]);
            hf_postacc.Value= EmaxGlobals.NullToEmpty(rec["postacc"]);
            PDetiles.Style.Add("display", "block");
            gvs_vchrdtls.DataBind();
            if (hf_postacc.Value== "True") 
            {
                disable();
                lbl_postacc.Text = "مرحل حسابات";
            }
            else
            {
                enable();
                lbl_postacc.Text = string.Empty;
            }
        }
        public static string RemoveQueryStringByKey(string url, string key)
        {
            var uri = new Uri(url);

            // this gets all the query string key value pairs as a collection
            var newQueryString = HttpUtility.ParseQueryString(uri.Query);

            // this removes the key if exists
            newQueryString.Remove(key);

            // this gets the page path from root without QueryString
            string pagePathWithoutQueryString = uri.GetLeftPart(UriPartial.Path);
            return pagePathWithoutQueryString;
            //return newQueryString.Count > 0
            //    ? String.Format("{0}?{1}", pagePathWithoutQueryString, newQueryString)
            //    : pagePathWithoutQueryString;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_ccid, "compid,table_name", "0,sys_costcenter", "ccid", "ccname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_vchrtype, "compid,table_name", "15,sys_fillcomp", "citemid", "citemname");
               // HF_vchrid.Value = string.Empty;
                txt_vchrdate.Date = DateTime.Now;
                cmb_vchrtype.SelectedIndex = 1;
                txt_vuser.Text = Context.User.Identity.Name;
                cmb_ccid.SelectedIndex = -1;
                  //  cmb_vchrtype.Attributes["disabled"] = "disabled";
               
               
            }
            if (!IsPostBack && (EmaxGlobals.NullToEmpty(Request.QueryString["id"]) != "" || EmaxGlobals.NullToEmpty(Request.QueryString["vchrno"]) != ""))
            {
               
               
                HF_vchrid.Value = Request.QueryString["id"];
                txt_vchrno.Text = Request.QueryString["vchrno"];
                Dictionary<object, object> dict = new Dictionary<object, object>();
                if (EmaxGlobals.NullToEmpty(Request.QueryString["id"]) != "")
                {
                    dict.Add("searchval", HF_vchrid.Value);
                }
                else
                {
                    dict.Add("searchval", txt_vchrno.Text);
                } 
             
                var dt = SqlCommandHelper.ExcecuteToDataTable("GL_vouchers_sel_pop", dict).dataTable;
                if (dt.Rows.Count != 0)
                {
                    binddata(dt.Rows[0]);

                } 
          
          //      var x = RemoveQueryStringByKey("http://localhost:44317/GL/Vouchers.aspx?vchrno=" + txt_vchrno.Text + "", "vchrno");
             //   ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "ChangeUrl('القيود اليومية', "+x+")", true);
            
            //else
            //{
            //   

            //    Server.Transfer(x);
            //}
            //Request.QueryString["vchrno"].Remove(5);
            //Request.QueryString.Remove("vchrno");
        }
        }

        List<object> GetParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_vchrid.Value) == 0)
            {
                return new List<object> { txt_vchrdocno, txt_vchrdate, cmb_vchrtype, txt_vuser, txt_vchrdesc,ch_uservchr,txt_puser,txt_vrfrance, lbl_docpath };
            }
            else
            {
                return new List<object> { txt_vchrdocno, txt_vchrdate, cmb_vchrtype, txt_vchrdesc, HF_vchrid, ch_uservchr,txt_puser, txt_vrfrance, lbl_docpath };
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            var res = SaveData(EmaxGlobals.NullToIntZero(HF_vchrid.Value) == 0 ? "GL_vouchers_ins" : "GL_vouchers_upd"
  , GetParam(), null,
          EmaxGlobals.NullToIntZero(HF_vchrid.Value) == 0 ? new List<string>() { "id", "vchrno" } : new List<string>() { "id" }, true, true,
          new List<ParamObject>() { new ParamObject() { ParamName = "vchrtypename", ParamValue = cmb_vchrtype }

        });

            if (res.errorid == 0)
            {
                if (EmaxGlobals.NullToIntZero(HF_vchrid.Value) != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                }
                HF_vchrid.Value = res.outputparams != null && res.outputparams.Count > 0 ? EmaxGlobals.NullToEmpty(res.outputparams["id"]) : "";

                if (res.outputparams.ContainsKey("vchrno"))
                {
                    txt_vchrno.Text = EmaxGlobals.NullToEmpty(res.outputparams["vchrno"]);
                }
                //txt_vchrno.Text = res.outputparams.ContainsKey("vchrno") ? EmaxGlobals.NullToEmpty(res.outputparams["vchrno"].ToString()) : "";

                PDetiles.Style.Add("display", "block");



            }

        }

        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            clear();
        }
        List<object> GetParam_dtl()
        {
 
            return new List<object>
           {  txt_ref,txt_descp,txt_debit, txt_credit,cmb_ccid,HF_chartid,HF_vchrid,HF_vchrdtlid };
        }
        protected void btn_save_dtls_Click(object sender, EventArgs e)
        {
            Dictionary<object, object> dictmaster = new Dictionary<object, object>();
            var balance = Math.Round(EmaxGlobals.NullToZero(txt_debit.Value) - EmaxGlobals.NullToZero(txt_credit.Value), 2);
            if (EmaxGlobals.NullToZero(txt_credit.Value) > EmaxGlobals.NullToZero(txt_debit.Value))
            {
                balance = balance * -1;
            }
            dictmaster.Add("balance", balance);
            var res = SaveData(EmaxGlobals.NullToIntZero(HF_vchrdtlid.Value) == 0 ? "gl_vocherdtls_ins" : "gl_vocherdtls_upd", GetParam_dtl(), /*dictupd*/null,
                null, true, true, new List<ParamObject>() { new ParamObject() { ParamName = "ccname", ParamValue = cmb_ccid } }, dictmaster);
            if (res.errorid == 0)
            {
                Clear_dtl();
                gvs_vchrdtls.DataBind();

            }
        }
        DataTable GvdetailSource()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("vchrid", HF_vchrid.Value);

            return SqlCommandHelper.ExcecuteToDataTable("gl_vchrdtls_sel", dict).dataTable;

        }

        protected void gvs_vchrdtls_DataBinding(object sender, EventArgs e)
        {
            gvs_vchrdtls.DataSource = GvdetailSource();
        }
        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                // gvitemsExporter.WriteXlsxToResponse(new XlsxExportOptionsEx() { ExportType=ExportType.WYSIWYG});
                ExportingDevExpressUtil.Export(gvitemsExporter, "تفاصيل القيود اليوميه ", 1, Request.GetOwinContext().Request.User.Identity.Name, gvs_vchrdtls.GetSelectedFieldValues("vchrdtlid").Count != 0, false, "تفاصيل  قيد يومية رقم " + txt_vchrno.Text);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

    

    protected void gvs_vchrdtls_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            var post = e.Parameters.Split(',');
            if (post.Length != 1)
            {
                if (EmaxGlobals.NullToBool(post[0]) == true)
                {
                    lbl_postacc.Text = "مرحل حسابات";
                    disable();


                }
                else
                {
                    lbl_postacc.Text = "";
                    enable();

                }
                if (EmaxGlobals.NullToEmpty(post[1]) != "")
                //if(EmaxGlobals.NullToEmpty( HF_uservchr.Value)!="")
                {
                    
                    var res = SaveData("gl_vocherdtls_usedvchr_ins",new List<object> { HF_uservchr,HF_vchrid }, /*dictupd*/null,
                null, true, true, null, null);
                    if(res.errorid==0)
                        HF_uservchr.Value = "";
                }
                if (EmaxGlobals.NullToEmpty(post[2]) != "")
                {
                    lbl_docpath.Text = post[2].ToString();
                }
                else
                {
                    lbl_docpath.Text = "";
                }
            }
            gvs_vchrdtls.DataBind();
            PDetiles.Style.Add("display", "block");


        }

        protected void gvs_vchrdtls_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            decimal total = EmaxGlobals.NullToZero( gvs_vchrdtls.GetTotalSummaryValue((ASPxSummaryItem)gvs_vchrdtls.TotalSummary["debit"])) - EmaxGlobals.NullToZero(gvs_vchrdtls.GetTotalSummaryValue((ASPxSummaryItem)gvs_vchrdtls.TotalSummary["credit"]));
            if (total < 0)
            {
                total = total * -1;

                 // e.TotalValue = "دائـــــــــن  = " + total.ToString();
                  e.TotalValue = "الفـــــــرق  = " + total.ToString();
                
            }
            else if (total == 0) e.TotalValue = "الفـــــــرق  = " + total.ToString();
            else e.TotalValue = "الفـــــــرق  = " + total.ToString();

        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("vchrid", HF_vchrid.Value);

            PrintPage("GL/gl_vouchers_page.repx", dict);
        }

        protected void upload_Click(object sender, EventArgs e)
        {
            try
            {


                if (!Directory.Exists(Server.MapPath("~/Files/gl/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Files/gl/"));
                }

                if (txt_vchrno.Text == "تلقائى")
                {
                    if (FileUpload2.HasFile == false && lbl_docpath.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('لا يوجد ملف للتحميل')", true);
                        return;
                    }
                    FileUpload2.SaveAs(Server.MapPath("~/Files/gl/" + FileUpload2.FileName));
                    string pathfile = "~/Files/gl/" + Path.GetFileName(FileUpload2.PostedFile.FileName);
                    //Session["pathfile"] = pathfile;
                    lbl_docpath.Text = pathfile;
                }
                else
                {
                    string pathfile = null;
                    if (FileUpload2.HasFile == true)
                    {

                        FileUpload2.SaveAs(Server.MapPath("~/Files/gl/" + FileUpload2.FileName));
                        pathfile = "~/Files/gl/" + Path.GetFileName(FileUpload2.PostedFile.FileName);
                        lbl_docpath.Text = pathfile;
                    }

                    else if (FileUpload2.HasFile == false && lbl_docpath.Text != null || lbl_docpath.Text != "")
                    {
                        if (lbl_docpath.Text == "")
                        {
                          
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('لا يوجد ملف للتحميل')", true);
                            return;
                        }
                        pathfile = lbl_docpath.Text;
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
               
                string fileextantion = lbl_docpath.Text;
          
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
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + txt_vchrno.Text + "." + fileextantion + "");
                Response.TransmitFile(Server.MapPath(lbl_docpath.Text));
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

        protected void btn_attach_Click(object sender, EventArgs e)
        {

        }

     
    }
}