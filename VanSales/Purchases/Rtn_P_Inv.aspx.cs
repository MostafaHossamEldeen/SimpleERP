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
    public partial class Rtn_P_Inv : EmaxBasepage
    {
        public ButtonRenderMode Secondary { get; private set; }

        protected override void OnInit(EventArgs e)
        {
            pageid = "31";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_pinvpay, "compid,table_name", "9,sys_fillcomp", "citemid", "citemname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_ccid, "compid,table_name", "0,sys_costcenter", "ccid", "ccname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_paytype, "compid,table_name,model", "0,sys-paytype,6", "paytypeid", "paytname");
                Util.GenerateRadioButtonList("sys_fillcomp_sel", rbl_vattype, "compid,table_name", "3,sys_fillcomp", "citemid", "citemname");
                HF_pinvid.Value = Request.Params["pinvid"];
                cmb_ccid.SelectedIndex = -1;
                txt_pinvdate.Date = DateTime.Now;
                cmb_pinvpay.SelectedIndex = 0;
                cmb_branchid.SelectedIndex = 0;
                cmb_paytype.SelectedIndex = 0;
                txt_puser.Text = Context.User.Identity.Name;
                gv_invdtls.DataBind();
            }
            Util.GenerateCombobox("paychart_sel", cmb_paychartid, "paytypeid,branchid", "" + EmaxGlobals.NullToEmpty(cmb_paytype.Value) + "," + EmaxGlobals.NullToEmpty(cmb_branchid.Value) + "", "paychartid", "paychartname");
            if (Request.QueryString["pinvno"] != null && Request.QueryString["pinvno"] != string.Empty)
            {
                    txt_pinvno.Text = Request.Params["pinvno"];
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("pinvno", txt_pinvno.Text);
                    var f = SqlCommandHelper.ExcecuteToDataTable("p_inv_sel_code", dict).dataTable;
                    BindData(f.Rows[0]);
                    gv_invdtls.DataBind();
                    gv_invpay.DataBind();
                    PDetiles.Style.Add("display", "block");
                    p_invpay.Style.Add("display", "block");
                    cmb_branchid.ClientEnabled = false;
            }
        }
        void Clear()
        {
            txt_item.Text = string.Empty;
            txt_unit.Text = string.Empty;
            txt_qty.Text = "1";
            txt_price.Text = "0";
            txt_value.Text = "0";
            txt_discp.Text = "0";
            txt_discvalue.Text = "0";
            txt_netvalue.Text = "0";
            txt_itemvatvalue.Text = "0";
            txt_itemnotes.Text = string.Empty;
            txtitem_name.Text = string.Empty;
            HF_invdtlid.Value = "";
            HF_itemid.Value = "";
            Hf_vat.Value = "";
            hf_disc.Value = "";
            hf_qty.Value = "";
        }
        void Clear_inv()
        {
            Clear();
            Clear_pay();
            txt_pinvno.Text = string.Empty;
            txt_pinvno.Text = "تلقائى";
            txt_pinvdocno.Text = string.Empty;
            txt_docno.Text = string.Empty;
            txt_pinvdate.Text = string.Empty;
            cmb_pinvpay.Text = string.Empty;
            cmb_pinvpay.Value = string.Empty;
            cmb_branchid.SelectedIndex = 0;
            cmb_branchid.ClientEnabled = true;
            rbl_vattype.ClientReadOnly = false;
            rbl_vattype.SelectedIndex = 0;
            cmb_ccid.Text = string.Empty;
            cmb_ccid.Value = string.Empty;
            txt_suppid.Text = null;
            txt_suppname.Text = null;
            txt_pnotes.Text = null;
            txt_suppvat.Text = null;
            txt_puser.Text = Context.User.Identity.Name;
            txt_pnotes.Text = string.Empty;
            HF_pinvid.Value = "";
            txt_pinvdate.Date = DateTime.Now;
            cmb_pinvpay.SelectedIndex = 0;
            ch_withoutinv.Checked = false;
            ch_withoutinv.ClientEnabled = true;
            chk_rtnall.Checked = false;
            txt_docno.ClientEnabled = true;
            lbl_postst.Text = "";
            lbl_postacc.Text = "";
            lbl_vochrno.Text = null;
            hf_vochrno.Value = null;
            HF_docid.Value = "";
            hf_postacc.Value = null;
            hf_postst.Value = null;
            txt_docno.Text = string.Empty;
            Enable();
            enable_pay();
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "document.querySelector('#btn_search_inv').Disabled = false;", true);
            chk_rtnall.ClientEnabled = true;
            lbl_invpic.Text = string.Empty;
            PDetiles.Style.Add("display", "none");
            p_invpay.Style.Add("display", "none");
            gv_invdtls.DataBind();
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

            btn_save_dtls.Enabled = false;
            btn_save_dtls.CssClass = "disable";
            btn_save_dtls.RenderMode = Secondary;

            btn_delete_dtls.Enabled = false;
            btn_delete_dtls.CssClass = "disable";
            btn_delete_dtls.RenderMode = Secondary;

            btn_new_dtls.Enabled = false;
            btn_new_dtls.CssClass = "disable";
            btn_new_dtls.RenderMode = Secondary;

            chk_rtnall.Enabled = false;
            ch_withoutinv.Enabled = false;

            btn_attach.Enabled = false;
            btn_attach.CssClass = "disable";
            btn_attach.RenderMode = Secondary;
        }
        void Enable()
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

            //btn_postst.Enabled = true;
            //btn_postst.CssClass = "enable";

            chk_rtnall.Enabled = true;
            chk_rtnall.CssClass = "enable";
            ch_withoutinv.Enabled = true;

            btn_attach.Enabled = true;
            btn_attach.CssClass = "enable";
        }
        void disable_pay()
        {
            btn_save_pay.Enabled = false;
            btn_save_pay.CssClass = "disable";
            btn_save_pay.RenderMode = Secondary;

            btn_delete_pay.Enabled = false;
            btn_delete_pay.CssClass = "disable";
            btn_delete_pay.RenderMode = Secondary;
        }
        void enable_pay()
        {
            btn_save_pay.Enabled = true;
            btn_save_pay.CssClass = "enable";


            btn_delete_pay.Enabled = true;
            btn_delete_pay.CssClass = "enable";
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
                Enable();
            }
        }
        List<object> GetParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_pinvid.Value) == 0)
            {
                return new List<object> { txt_pinvdocno, txt_pinvdate, cmb_pinvpay, txt_suppid, txt_suppname, txt_pnotes, txt_suppvat, txt_puser, txt_netbvat, txt_vatvalue, txt_netavat, txt_restvalue, lbl_invpic, cmb_branchid, cmb_ccid, txt_docno, ch_withoutinv , txt_docno, HF_docid, rbl_vattype };
            }
            else
            {
                return new List<object> { HF_pinvid, txt_pinvdocno, txt_pinvdate, cmb_pinvpay, txt_suppid, txt_suppname, txt_pnotes, txt_suppvat, txt_puser, txt_netbvat, txt_vatvalue, txt_netavat, txt_restvalue, lbl_invpic, cmb_branchid, cmb_ccid, txt_docno, ch_withoutinv, txt_docno, HF_docid, rbl_vattype };
            }
        }
        List<object> rtn_all()
        {
            return new List<object> { HF_pinvid, txt_pinvno, HF_docid };
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (ch_withoutinv.Checked == false && txt_docno.Text == "")
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('برجاء ادخال رقم الفاتوره او الاختيار بدون فاتوره')", true);
                    return;
                }
                Dictionary<object, object> dictvattypename = new Dictionary<object, object>();
                dictvattypename.Add("vattypename", rbl_vattype.SelectedItem.Text);
                var res = SaveData(EmaxGlobals.NullToIntZero(HF_pinvid.Value) == 0 ? "p_rtn_inv_ins" : "p_rtninv_upd", GetParam(), null,
                    EmaxGlobals.NullToIntZero(HF_pinvid.Value) == 0 ? new List<string>() { "pinvid", "pinvno" } : new List<string>() { },
                    true, true, new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue =cmb_branchid }
                    ,new ParamObject() { ParamName = "pinvpayname", ParamValue = cmb_pinvpay }
                    ,new ParamObject() { ParamName = "ccname", ParamValue = cmb_ccid } }, dictvattypename);
                if (res.errorid == 0)
                {
                    if (EmaxGlobals.NullToIntZero(HF_pinvid.Value) != 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                    }
                    else
                    {
                        HF_pinvid.Value = res.outputparams != null && res.outputparams.Count > 0 ? EmaxGlobals.NullToEmpty(res.outputparams["pinvid"]) : "";
                        txt_pinvno.Text = res.outputparams.ContainsKey("pinvno") ? EmaxGlobals.NullToEmpty(res.outputparams["pinvno"].ToString()) : "";
                    }
                    if (chk_rtnall.Checked == true)
                    {
                        var res2 = SaveData("p_rtn_all_invdtls_ins", rtn_all(), null, null, true, false, null);
                        gv_invdtls.DataBind();
                        var res3 = SaveData("p_rtn_inv_vat_upd", GetVatParam(), null, null, true, false, null);
                    }
                    cmb_branchid.ClientReadOnly = false;
                    rbl_vattype.ClientReadOnly = true;
                    ch_withoutinv.ClientReadOnly = false;
                    gv_invdtls.DataBind();
                    PDetiles.Style.Add("display", "block");
                    p_invpay.Style.Add("display", "block");
                    if (cmb_pinvpay.SelectedItem.Value.ToString() == "2")
                    {
                        disable_pay();
                        btn_postacc.Enabled = true;
                        btn_postacc.CssClass = "enable";

                    }
                    else if (cmb_pinvpay.SelectedItem.Value.ToString() == "1")
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
        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            Clear_inv();
            btn_postst.Enabled = true;
            btn_postst.CssClass = "enable";
            btn_postacc.Enabled = true;
            btn_postacc.CssClass = "enable";
            rbl_vattype.SelectedIndex = 0;
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
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('لا يوجد ملف للتحميل')", true);
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
                            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('لا يوجد ملف للتحميل')", true);
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
                if (lbl_invpic.Text == "")
                {
                    ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetinfo('لا يوجد ملف')", true);
                    return;
                }
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
                    msg = "لا يوجد ملف لتحميله";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
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

                var res = SaveData("p_rtn_inv_itemexcel_ins", new List<object> { HF_pinvid, rbl_vattype }, null,
                null, true, true, null
                , null);
                if (res.errorid == 0)
                {
                    Clear();
                    gv_invdtls.DataBind();

                }
                else
                {
                    if (res.errormsg.Contains("FK_p_invdtls_p_inv") == true)
                    {
                        Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath);
                    }

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('" + res.errormsg + "')", true);
                    gv_invdtls.DataBind();
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo(" + res.errormsg + ")", true);
                }
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo(" + ex.Message + ")", true);
            }
        }
        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvitemsExporter, "اصناف الفاتوره", 1, Request.GetOwinContext().Request.User.Identity.Name, gv_invdtls.GetSelectedFieldValues("invdtlid").Count != 0, false, "أصناف الفاتوره رقم " + txt_pinvno.Text);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }
        List<object> GetParam_pay()
        {
            if (EmaxGlobals.NullToIntZero(Hf_payid.Value) == 0)
            {
                return new List<object> { HF_pinvid, cmb_paytype, txt_payvalue, txt_payno, txt_payref, cmb_paychartid };
            }
            else
            {
                return new List<object> { Hf_payid, HF_pinvid, cmb_paytype, txt_payvalue, txt_payno, txt_payref, cmb_paychartid };
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
        List<object> GetParam_dtl()
        {
            if (EmaxGlobals.NullToIntZero(HF_invdtlid.Value) == 0)
            {
                return new List<object> { HF_pinvid, HF_itemid, HF_unitid, HF_factor, txt_qty, txt_price, txt_value, txt_discp, txt_discvalue, txt_netvalue, txt_itemvatvalue, txt_itemnotes };
            }
            else
            {
                return new List<object> { HF_invdtlid, HF_pinvid, HF_itemid, HF_unitid, HF_factor, txt_qty, txt_price, txt_value, txt_discp, txt_discvalue, txt_netvalue, txt_itemvatvalue, txt_itemnotes };
            }
        }
        protected void btn_save_dtls_Click(object sender, EventArgs e)
        {
            if (ch_withoutinv.Checked == false)
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("pinvno", txt_pinvno.Text);
                dict.Add("docno", txt_docno.Text);
                dict.Add("itemid", HF_itemid.Value);
                dict.Add("invdtlid", HF_invdtlid.Value);
                if (EmaxGlobals.NullToIntZero(HF_invdtlid.Value) == 0)
                {
                    dict.Add("actiontype", 0);
                }
                else
                {
                    dict.Add("actiontype", 1);
                }

                var res1 = SqlCommandHelper.ExcecuteToDataTable("p_rtn_invdtls_qty_sel", dict).dataTable;

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
            var res = SaveData(EmaxGlobals.NullToIntZero(HF_invdtlid.Value) == 0 ? "p_rtn_invdtls_ins" : "p_rtn_invdtls_upd", GetParam_dtl(), null, null, true, true,
                new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue =cmb_branchid }
                ,new ParamObject() { ParamName = "pinvpayname", ParamValue = cmb_pinvpay }
                ,new ParamObject() { ParamName = "ccname", ParamValue = cmb_ccid } });
            if (res.errorid == 0)
            {
                gv_invdtls.DataBind();
                if (gv_invdtls.VisibleRowCount > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "validate_other_inv()", true);
                }
                Clear();
                var res2 = SaveData("p_rtn_inv_vat_upd", GetVatParam(), null, null, true, false, null);
            }
        }
        protected void btn_save_pay_Click(object sender, EventArgs e)
        {
            try
            {
                if (EmaxGlobals.NullToZero( txt_payvalue.Text)== 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('برجاء ادخال القيمه اولا')", true);
                    return;
                }
                var res = SaveData(EmaxGlobals.NullToIntZero(Hf_payid.Value) == 0 ? "p_rtn_invpay_ins" : "p_rtn_invpay_upd", GetParam_pay(), null, null, true, true,
                    new List<ParamObject>() { new ParamObject() { ParamName = "payname", ParamValue = cmb_paytype } });
                if (res.errorid == 0)
                {
                    gv_invpay.DataBind();
                    Clear_pay();
                    var res2 = SaveData("p_rtn_inv_vat_upd", GetVatParam(), null, null, true, false, null);
                }
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
        }
        protected void ch_withoutinv_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_withoutinv.Checked == true)
            {
                txt_docno.ClientEnabled = false;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "document.querySelector('#btn_search_inv').Disabled = true;", true);
                chk_rtnall.ClientEnabled = false;
                chk_rtnall.Checked = false;
                txt_docno.Text = string.Empty;
                HF_docid.Value = "";
                btn_attach.Enabled = true;
                btn_attach.CssClass = "enable";
            }
            else
            {
                txt_docno.ClientEnabled = true;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "document.querySelector('#btn_search_inv').Disabled = false;", true);
                chk_rtnall.ClientEnabled = true;
                btn_attach.Enabled = false;
                btn_attach.CssClass = "disable";
                btn_attach.RenderMode = Secondary;
            }
        }
        DataTable GvdetailSource()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("pinvid", HF_pinvid.Value);
            return SqlCommandHelper.ExcecuteToDataTable("p_rtn_invdtls_gv_sel", dict).dataTable;
        }
        protected void gv_invdtls_DataBinding(object sender, EventArgs e)
        {
            gv_invdtls.DataSource = GvdetailSource();
        }
        protected void gv_invdtls_DataBound(object sender, EventArgs e)
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
                txt_netbvat.Text = (Convert.ToDecimal(txt_netavat.Text) - Convert.ToDecimal(txt_vatvalue.Text)).ToString();
                if (txt_restvalue.Text == "0")
                    txt_restvalue.Text = txt_netavat.Text;
            }
            ///غير شامل الصريبه
            else if (rbl_vattype.Value.ToString() == "2")
            {
                txt_netbvat.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]).ToString();
                txt_vatvalue.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["vatvalue"]).ToString();
                txt_netavat.Text = (Convert.ToDecimal(txt_netbvat.Text) + Convert.ToDecimal(txt_vatvalue.Text)).ToString();
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
            }
            try
            {
                decimal rest = EmaxGlobals.NullToZero(gv_invpay.GetTotalSummaryValue(gv_invpay.TotalSummary["payvalue"]));
                txt_restvalue.Text = (Convert.ToDecimal(txt_netavat.Text) - rest).ToString();
            }
            catch
            {

            }
        }
        protected void gv_invdtls_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            var post = e.Parameters.Split(',');
            if (post.Length != 1)
            {
                if (EmaxGlobals.NullToEmpty(post[0]) != "")
                {
                    lbl_invpic.Text = post.ToString();
                }
                else
                {
                    lbl_invpic.Text = string.Empty;
                }
                if (EmaxGlobals.NullToBool(post[1]) == true)
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
                if (EmaxGlobals.NullToBool(post[2]) == true)
                {
                    lbl_postacc.Text = "مرحل حسابات";
                    lbl_vochrno.Text = hf_vochrno.Value;
                    disable_pay();
                    btn_postacc.Enabled = false;
                    btn_postacc.CssClass = "disable";
                    btn_postacc.RenderMode = Secondary;
                }
                else
                {
                    lbl_postacc.Text = "";
                    lbl_vochrno.Text = "";
                    enable_pay();
                    btn_postacc.Enabled = true;
                    btn_postacc.CssClass = "enable";
                }
                if (EmaxGlobals.NullToBool(post[1]) == true || EmaxGlobals.NullToBool(post[2]) == true)
                {
                    disable();
                }
                else
                {
                    Enable();
                    chk_rtnall.Enabled = false;
                }
                if (post.Length > 3)
                {
                    if (EmaxGlobals.NullToEmpty(post[3]) != "" || EmaxGlobals.NullToEmpty(post[3]) != null)
                    {
                        lbl_vochrno.Text = post[3];
                    }
                }
                if (EmaxGlobals.NullToEmpty(HF_itemid.Value) != "")
                {
                    txt_qty.Focus();
                }
            }
            gv_invdtls.DataBind();
            try
            {
                if (gv_invdtls.VisibleRowCount > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "validate_other_inv()", true);
                }
                if (cmb_pinvpay.SelectedItem.Value.ToString() == "2")
                {
                    disable_pay();
                    btn_postacc.Enabled = true;
                    btn_postacc.CssClass = "enable";
                    if (EmaxGlobals.NullToBool(post[2]) == true)
                    {
                        disable_pay();
                    }
                }
                else if (cmb_pinvpay.SelectedItem.Value.ToString() == "1" && EmaxGlobals.NullToBool(post[2]) != true)
                {
                    enable_pay();
                }
            }
            catch (Exception)
            {

            }
            gv_invpay.DataBind();
            PDetiles.Style.Add("display", "block");
            p_invpay.Style.Add("display", "block");
            cmb_branchid.ClientEnabled = false;
            rbl_vattype.ClientReadOnly = true;
            ch_withoutinv.ClientEnabled = false;
        }
        protected void gv_invpay_DataBound(object sender, EventArgs e)
        {
            ASPxGridView gridView = sender as ASPxGridView;

            if (gridView.GetTotalSummaryValue(gridView.TotalSummary["payvalue"]) == null || gridView.GetTotalSummaryValue(gridView.TotalSummary["payvalue"]).ToString() == "")
            {
                return;
            }
            decimal rest = Convert.ToDecimal(gridView.GetTotalSummaryValue(gridView.TotalSummary["payvalue"]).ToString());
            txt_restvalue.Text = (Convert.ToDecimal(txt_netavat.Text) - rest).ToString();
        }
        protected void gv_invpay_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            gv_invpay.DataBind();
            PDetiles.Style.Add("display", "block");
            p_invpay.Style.Add("display", "block");
            cmb_branchid.ClientEnabled = false;
            rbl_vattype.ClientReadOnly = true;
            ch_withoutinv.ClientEnabled = false;
            Clear_pay();
        }
        DataTable GvpaySource()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("pinvid", HF_pinvid.Value);
            return SqlCommandHelper.ExcecuteToDataTable("p_rtn_invpay_sel", dict).dataTable;
        }
        protected void gv_invpay_DataBinding(object sender, EventArgs e)
        {
            gv_invpay.DataSource = GvpaySource();
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("pinvid", HF_pinvid.Value);
            PrintPage("Purchase/Rtn_P_Inv_Page.repx", dict);
        }
    }
}