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
    public partial class Orders : EmaxBasepage
    {
        public ButtonRenderMode Secondary { get; private set; }

        protected override void OnInit(EventArgs e)
        {
            pageid = "32";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                    Util.GenerateRadioButtonList("sys_fillcomp_sel", rbl_vattype, "compid,table_name", "3,sys_fillcomp", "citemid", "citemname");
                    txt_podate.Date = DateTime.Now;
                    txt_ouser.Text = Context.User.Identity.Name;
                    gv_orderdtls.DataBind();
                    if (Request.QueryString["poid"] != null && Request.QueryString["poid"] != string.Empty)
                    {
                        HF_poid.Value = Request.QueryString["poid"];
                        Dictionary<object, object> dict = new Dictionary<object, object>();
                        dict.Add("poid", HF_poid.Value);
                        var f = SqlCommandHelper.ExcecuteToDataTable("p_order_sel_poid", dict).dataTable;
                        gv_orderdtls.DataBind();
                        BindData(f.Rows[0]);
                        if (hf_pinvc.Value == "True")
                        {
                            disable();
                        }
                        else
                        {
                            enable();
                        }
                        PDetiles.Style.Add("display", "block");
                        HF_podtlid.Value = "0";
                        gv_orderdtls.DataBind();
                        gv_orderdtls.FocusedRowIndex = -1;
                        cleardtls();
                        var res2 = SaveData("P_order_vat_upd", GetVatParam(), null, null, true, false, null);
                    }
                    else if (EmaxGlobals.NullToIntZero(HF_poid.Value) != 0)
                    {
                        Dictionary<object, object> dict = new Dictionary<object, object>();
                        dict.Add("poid", HF_poid.Value);
                        var f = SqlCommandHelper.ExcecuteToDataTable("p_order_sel_poid", dict).dataTable;
                        gv_orderdtls.DataBind();
                        BindData(f.Rows[0]);
                        if (hf_pinvc.Value == "1")
                        {
                            disable();
                        }
                        else
                        {
                            enable();
                        }
                        PDetiles.Style.Add("display", "block");
                        HF_podtlid.Value = "0";
                        gv_orderdtls.DataBind();
                        gv_orderdtls.FocusedRowIndex = -1;
                        cleardtls();
                        var res2 = SaveData("P_order_vat_upd", GetVatParam(), null, null, true, false, null);
                    }
                }
                catch (Exception)
                {

                }
            }
        }
        void BindData(DataRow rec)
        {
            txt_pono.Text= EmaxGlobals.NullToEmpty(rec["pono"]);
            txt_podocno.Text = EmaxGlobals.NullToEmpty(rec["podocno"]);
            txt_podate.Text = EmaxGlobals.NullToEmpty(rec["podate"]);
            cmb_branchid.Value = EmaxGlobals.NullToIntZero(rec["branchid"]);
            cmb_branchid.Text = EmaxGlobals.NullToEmpty(rec["branchname"]);
            txt_suppid.Text= EmaxGlobals.NullToEmpty(rec["suppid"]);
            txt_suppname.Text = EmaxGlobals.NullToEmpty(rec["suppname"]);
            txt_ouser.Text = EmaxGlobals.NullToEmpty(rec["ouser"]);
            txt_ponotes.Text = EmaxGlobals.NullToEmpty(rec["ponotes"]); 
            txt_netbvat.Text = EmaxGlobals.NullToEmpty(rec["netbvat"]); 
            txt_vatvalue.Text = EmaxGlobals.NullToEmpty(rec["vatvalue"]); 
            txt_netavat.Text = EmaxGlobals.NullToEmpty(rec["netavat"]); 
            txt_reqnos.Text = EmaxGlobals.NullToEmpty(rec["reqnos"]); 
            rbl_vattype.Value = EmaxGlobals.NullToEmpty(rec["vattype"]);
            hf_pinvc.Value = EmaxGlobals.NullToEmpty(rec["pinvc"]);
        }
        void clear()
        {
            txt_pono.Text = "تلقائى";
            txt_ouser.Text = Context.User.Identity.Name;
            txt_podate.Date = DateTime.Now;
            HF_poid.Value = null;
            txt_podocno.Text = null;
            cmb_branchid.SelectedIndex = 0;
            txt_suppid.Text = null;
            txt_suppname.Text = null;
            txt_ponotes.Text = null;
            rbl_vattype.SelectedIndex = 0;
            txt_netbvat.Text = "0";
            txt_vatvalue.Text = "0";
            txt_netavat.Text = "0";
            txt_podocno.Text = null;
            txt_reqnos.Text = null;
            cmb_branchid.ClientReadOnly = false;
            rbl_vattype.ClientReadOnly = false;
            txt_vatvalue.ClientReadOnly = false;
            txt_pono.ClientReadOnly = false;
            txt_ouser.ClientReadOnly = false;
            txt_podate.ClientReadOnly = false;
            txt_podocno.ClientReadOnly = false;
            txt_suppid.ClientReadOnly = false;
            txt_suppname.ClientReadOnly = false;
            txt_ponotes.ClientReadOnly = false;
            txt_netbvat.ClientReadOnly = false;
            txt_netavat.ClientReadOnly = false;
            enable();

            PDetiles.Style.Add("display", "none");
            cleardtls();
            gv_orderdtls.DataBind();
        }
        void cleardtls()
        {
            HF_podtlid.Value = "0";
            HF_itemid.Value = null;
            txt_itemcode.Text = null;
            txt_itemname.Text = null;
            HF_unitid.Value = null;
            hf_factor.Value = null;
            txt_unitname.Text = null;
            txt_qty.Text = "1";
            txt_pprice.Text = "0";
            txt_pvalue.Text = "0";
            txt_descp.Text = "0";
            txt_descv.Text = "0";
            txt_pnet.Text = "0";
            txt_itemnotes.Text = null;
            Hf_vat.Value = null;
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
            btn_save_dtls.Enabled = false;
            btn_save_dtls.CssClass = "disable";
            btn_save_dtls.RenderMode = Secondary;
            btn_new_dtls.Enabled = false;
            btn_new_dtls.CssClass = "disable";
            btn_new_dtls.RenderMode = Secondary;
            btn_attach.Enabled = false;
            btn_attach.CssClass = "disable";
            btn_attach.RenderMode = Secondary;
            btn_pay.Enabled = false;
            btn_pay.CssClass = "disable";
            btn_pay.RenderMode = Secondary;

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
            btn_save_dtls.Enabled = true;
            btn_save_dtls.CssClass = "enable";
            btn_new_dtls.Enabled = true;
            btn_new_dtls.CssClass = "enable";
            btn_attach.Enabled = true;
            btn_attach.CssClass = "enable";
            btn_pay.Enabled = true;
            btn_pay.CssClass = "enable";
        }
        List<object> MasterParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_poid.Value) == 0)
            {
                return new List<object> { txt_podocno, txt_podate, cmb_branchid, txt_suppid, txt_suppname, txt_reqnos, txt_ponotes, txt_ouser, rbl_vattype, txt_netbvat, txt_vatvalue, txt_netavat };
            }
            else
            {
                return new List<object> { HF_poid, txt_pono, txt_podocno, txt_podate, cmb_branchid, txt_suppid, txt_suppname, txt_reqnos, txt_ponotes, txt_ouser, rbl_vattype, txt_netbvat, txt_vatvalue, txt_netavat };
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<object, object> dictvattypename = new Dictionary<object, object>();
                dictvattypename.Add("vattypename", rbl_vattype.SelectedItem.Text);
                var res = SaveData(EmaxGlobals.NullToIntZero(HF_poid.Value) == 0 ? "p_order_ins" : "p_order_upd", MasterParam(), null,
                EmaxGlobals.NullToIntZero(HF_poid.Value) == 0 ? new List<string>() { "poid", "pono" } : new List<string>() { }, true, true,
                new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue = cmb_branchid } }, dictvattypename);
                if (res.errorid == 0)
                {
                    cmb_branchid.ClientReadOnly = true;
                    rbl_vattype.ClientReadOnly = true;
                    PDetiles.Style.Add("display", "block");
                    if (EmaxGlobals.NullToIntZero(HF_poid.Value) != 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                    }
                    else
                    {
                        HF_poid.Value = res.outputparams != null && res.outputparams.Count > 0 ? EmaxGlobals.NullToEmpty(res.outputparams["poid"]) : "";
                        txt_pono.Text = res.outputparams.ContainsKey("pono") ? EmaxGlobals.NullToEmpty(res.outputparams["pono"].ToString()) : "";
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
            clear();
        }
        List<object> dtlsParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_podtlid.Value) == 0)
            {
                return new List<object> { HF_poid, HF_itemid, HF_unitid, txt_unitname, txt_qty, hf_factor, txt_pprice, txt_pvalue, txt_descp, txt_descv, txt_pnet, txt_itemnotes, txt_itemvatvalue };
            }
            else
            {
                return new List<object> { HF_podtlid, txt_qty, txt_pprice, txt_pvalue, txt_descp, txt_descv, txt_pnet, txt_itemnotes, txt_itemvatvalue };
            }
        }
        List<object> GetVatParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_poid.Value) != 0)
            {
                return new List<object> { HF_poid, txt_netbvat, txt_vatvalue, txt_netavat };
            }
            else
            {
                return null;
            }
        }
        protected void btn_save_dtls_Click(object sender, EventArgs e)
        {
            var res = SaveData(EmaxGlobals.NullToIntZero(HF_podtlid.Value) == 0 ? "p_orderdtls_ins" : "p_orderdtls_upd", dtlsParam(), null, null, true);
            if (res.errorid == 0)
            {
                gv_orderdtls.DataBind();
                cleardtls();
                var res2 = SaveData("P_order_vat_upd", GetVatParam(), null, null, true, false, null);
            }
        }
        protected void gv_orderdtls_DataBinding(object sender, EventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("poid", HF_poid.Value);
            gv_orderdtls.DataSource = SqlCommandHelper.ExcecuteToDataTable("p_orderdtls_sel", dict).dataTable;
        }
        protected void gv_orderdtls_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            var rcase = e.Parameters.Split(',');
            if (rcase.Length != 3)
            {
                if (rcase[0] == "null")
                {
                    txt_podocno.Text = null;
                }
                else
                {
                    txt_podocno.Text = rcase[0];
                }
                try
                {
                    if (rcase[1] == "true")
                    {
                        disable();
                    }
                    else
                    {
                        enable();
                    }
                }
                catch
                { 
                
                }
            }
            PDetiles.Style.Add("display", "block");
            HF_podtlid.Value = "0";
            gv_orderdtls.DataBind();
            gv_orderdtls.FocusedRowIndex = -1;
            cleardtls();
            var res2 = SaveData("P_order_vat_upd", GetVatParam(), null, null, true, false, null);
        }
        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle;
                exptitle = "أصناف أمر الشراء رقم " + txt_pono.Text;
                ExportingDevExpressUtil.Export(gvitemsExporter, "اصناف أمر الشراء", 1, Request.GetOwinContext().Request.User.Identity.Name, gv_orderdtls.GetSelectedFieldValues("podtlid").Count != 0, false, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }
        protected void gv_orderdtls_DataBound(object sender, EventArgs e)
        {
            ASPxGridView gridView = sender as ASPxGridView;
            if (gridView.GetTotalSummaryValue(gridView.TotalSummary["pnet"]) == null || gridView.GetTotalSummaryValue(gridView.TotalSummary["pnet"]).ToString() == "")
            {
                return;
            }
            //شامل الضريبه
            if (rbl_vattype.Value.ToString() == "1")
            {
                txt_netavat.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["pnet"]).ToString();
                txt_vatvalue.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["vatvalue"]).ToString();
                txt_netbvat.Text = (EmaxGlobals.NullToZero(txt_netavat.Text) - EmaxGlobals.NullToZero(txt_vatvalue.Text)).ToString();
            }
            ///غير شامل الصريبه
            else if (rbl_vattype.Value.ToString() == "2")
            {
                txt_netbvat.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["pnet"]).ToString();
                txt_vatvalue.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["vatvalue"]).ToString();
                txt_netavat.Text = (EmaxGlobals.NullToZero(txt_netbvat.Text) + EmaxGlobals.NullToZero(txt_vatvalue.Text)).ToString();
            }
            else if (rbl_vattype.Value.ToString() == "3")
            {
                txt_netbvat.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["pnet"]).ToString();
                txt_netavat.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["pnet"]).ToString();
                txt_vatvalue.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["vatvalue"]).ToString();
            }
            if (EmaxGlobals.NullToIntZero(HF_poid.Value).ToString() != "0")
            {
                cmb_branchid.ClientReadOnly = true;
                rbl_vattype.ClientReadOnly = true;
            }
        }
        protected void txt_vatvalue_TextChanged(object sender, EventArgs e)
        {
            //شامل الضريبه
            if (rbl_vattype.Value.ToString() == "1")
            {
                txt_netbvat.Text = (EmaxGlobals.NullToZero(txt_netavat.Text) - EmaxGlobals.NullToZero(txt_vatvalue.Text)).ToString();
            }
            ///غير شامل الصريبه
            else if (rbl_vattype.Value.ToString() == "2")
            {
                txt_netavat.Text = (EmaxGlobals.NullToZero(txt_netbvat.Text) + EmaxGlobals.NullToZero(txt_vatvalue.Text)).ToString();
            }
            if (EmaxGlobals.NullToIntZero(HF_poid.Value).ToString() != "0")
            {
                cmb_branchid.ClientReadOnly = true;
                rbl_vattype.ClientReadOnly = true;
            }
        }

        protected void btn_pay_Click(object sender, EventArgs e)
        {
            try
            {
                var res = SaveData("p_inv_ins_ord", new List<object> { HF_poid, cmb_branchid }, null, new List<string>() { "pinvno" }, true, false, null);
                if (res.errorid == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                    disable();
                }
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + msg + ")", true);
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

                    

                    using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                    {
                         
                        oda.Fill(dtExcelData);


                    }

                    excel_con.Close();

                    string consString = ConfigurationManager.ConnectionStrings["VanSales"].ConnectionString;
                    SqlCommandHelper.ExecuteNonQuery("items_excel_del", dict, true);
                    using (SqlConnection con = new SqlConnection(consString))
                    {

                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            sqlBulkCopy.DestinationTableName = "dbo.items_excel";

                            con.Open();
                            sqlBulkCopy.WriteToServer(dtExcelData);
                            con.Close();
                        }
                    }
                }

                var res = SaveData("p_order_itemexcel_ins", new List<object> { HF_poid, rbl_vattype }, null,
                null, true, true, null
                , null);
                if (res.errorid == 0)
                {
                    cleardtls();
                    gv_orderdtls.DataBind();

                }
                else
                {
                    if (res.errormsg.Contains(" FK_p_orderdtls_p_order") == true)
                    {
                        Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath);
                    }

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('" + res.errormsg + "')", true);
                    gv_orderdtls.DataBind();
                }
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("poid", HF_poid.Value);
            PrintPage("Purchase/P_order_Page.repx", dict);
        }
    }
}