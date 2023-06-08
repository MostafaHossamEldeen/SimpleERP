using DevExpress.Web;
using Emax.Core.Utility;
using Emax.Dal;
using Emax.SharedLib;
using Newtonsoft.Json;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.Sales
{
    public partial class s_quote_order : EmaxBasepage
    {
        public ButtonRenderMode Secondary { get; private set; }

        protected override void OnInit(EventArgs e)
        {

            pageid = "28";
            base.OnInit(e);

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
            txt_itemvatvalue.Text = "0";
            txt_itemnotes.Text = string.Empty;
            txtitem_name.Text = string.Empty;
            HF_sodtlid.Value = "";
            HF_itemid.Value = "";
            Hf_vat.Value = "";
            //hf_qty.Value = "";
            hf_disc.Value = "";



        }
        void clear_order()
        {
            clear();


            txt_sono.Text = "تلقائى";
            txt_sodocno.Text = string.Empty;
            txt_sodate.Date = DateTime.Now;
            cmb_branchid.ClientEnabled = true;
            cmb_branchid.SelectedIndex = 0;
            txt_custid.Text = string.Empty;
            txt_custname.Text = string.Empty;
            Hf_cusid.Value = "";
            // txt_custvat.Text = string.Empty;
            // txt_custadd.Text = string.Empty;
            //txt_custmobile.Text = string.Empty;
            txt_ouser.Text = Context.User.Identity.Name;
            txt_sonotes.Text = string.Empty;

            txt_netbvat.Text = "0";
            txt_vatvalue.Text = "0";
            txt_netavat.Text = "0";
            HF_soid.Value = "";
            HF_sinvc.Value = "";
            //txt_restvalue.Text = "0";
            enable();
         
            PDetiles.Style.Add("display", "none");

            gvs_orderdtls.DataBind();

        }
        void BindData(DataRow rec)
        {
            try
            {
                txt_sodocno.Text = EmaxGlobals.NullToEmpty(rec["sodocno"]);
                txt_sodate.Date = Convert.ToDateTime(rec["sodate"]);
                cmb_branchid.Value = EmaxGlobals.NullToEmpty(rec["branchid"]);
                cmb_branchid.Text = EmaxGlobals.NullToEmpty(rec["branchname"]);
                txt_custid.Text = EmaxGlobals.NullToEmpty(rec["custid"]);
                txt_custname.Text = EmaxGlobals.NullToEmpty(rec["custname"]);
                txt_ouser.Text = EmaxGlobals.NullToEmpty(rec["ouser"]);
                txt_sonotes.Text = EmaxGlobals.NullToEmpty(rec["sonotes"]);
                txt_netbvat.Text = EmaxGlobals.NullToEmpty(rec["netbvat"]);
                txt_vatvalue.Value = EmaxGlobals.NullToIntZero(rec["vatvalue"]);
                txt_netavat.Text = EmaxGlobals.NullToEmpty(rec["netavat"]);
                HF_soid.Value = EmaxGlobals.NullToEmpty(rec["soid"]);
                HF_sinvc.Value = EmaxGlobals.NullToEmpty(rec["sinvc"]);
                if (EmaxGlobals.NullToBool(HF_sinvc.Value) == true)
                {
                    //btn_Save.Enabled = false;
                    //btn_delete.Enabled = false;
                    //btn_delete_dtls.Enabled = false;
                    //btn_createinv.Enabled = false;
                    //btn_save_dtls.Enabled = false;
                    //btn_attach.Enabled = false;
                    //ASPxButton1.Enabled = false;
                    disable();

                }
                else
                {
                    //btn_Save.Enabled = true;
                    //btn_delete.Enabled = true;
                    //btn_delete_dtls.Enabled = true;
                    //btn_createinv.Enabled = true;
                    //btn_save_dtls.Enabled = true;
                    //btn_attach.Enabled = true;
                    //ASPxButton1.Enabled = true;
                    enable();
                }
            }
            catch (Exception ex)
            {

                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + msg + ")", true);
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


            btn_delete_dtls.Enabled = false;
            btn_delete_dtls.CssClass = "disable";
            btn_delete_dtls.RenderMode = Secondary;

            ASPxButton1.Enabled = false;
            ASPxButton1.CssClass = "disable";
            ASPxButton1.RenderMode = Secondary;

            btn_attach.Enabled = false;
            btn_attach.CssClass = "disable";
            btn_attach.RenderMode = Secondary;

            btn_createinv.Enabled = false;
            btn_createinv.CssClass = "disable";
            btn_createinv.RenderMode = Secondary;

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

            ASPxButton1.Enabled = true;
            ASPxButton1.CssClass = "enable";

            btn_attach.Enabled = true;
            btn_attach.CssClass = "enable";

            btn_createinv.Enabled = true;
            btn_createinv.CssClass = "enable";


        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");

                //  HF_sinvid.Value = Request.Params["sinvid"];
                //cmb_smanid.SelectedIndex = -1;

                txt_sodate.Date = DateTime.Now;
                cmb_branchid.SelectedIndex = 0;
                txt_ouser.Text = Context.User.Identity.Name;
                HF_vattype.Value = SqlCommandHelper.GetTokenKey("vattype", Request.Cookies["Token"].Value);
                try
                {
                    if (Request.QueryString["orderno"] != null && Request.QueryString["orderno"] != string.Empty)
                    {
                        txt_sono.Text = Request.QueryString["orderno"];
                        Dictionary<object, object> dict = new Dictionary<object, object>();
                        dict.Add("searchval", txt_sono.Text);

                        var res = SqlCommandHelper.ExcecuteToDataTable("s_quote_order_sel_search", dict).dataTable;

                        BindData(res.Rows[0]);
                        // gvs_orderdtls_CustomCallback( sender,ASPxGridViewCustomCallbackEventArgs e);
                        PDetiles.Style.Add("display", "block");
                        gvs_orderdtls.DataBind();
                    }
                }
                catch (Exception ex)
                {
                    clear_order();
                    string msg = HttpUtility.JavaScriptStringEncode(ex.Message);

                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + msg + ")", true);

                }
            }
        }
        List<object> GetParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_soid.Value) == 0)
            {
                return new List<object> { txt_sodocno, txt_sodate, txt_custid, txt_custname, txt_ouser, txt_sonotes, txt_netbvat, txt_vatvalue, txt_netavat, cmb_branchid };
            }
            else
            {
                return new List<object> { txt_sono, txt_sodocno, txt_sodate, txt_custid, txt_custname, txt_ouser, txt_sonotes, txt_netbvat, txt_vatvalue, txt_netavat, cmb_branchid, HF_soid };
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {

            try
            {
                var res = SaveData(EmaxGlobals.NullToIntZero(HF_soid.Value) == 0 ? "s_quote_order_ins" : "s_quote_order_upd"
        , GetParam(), null,
                EmaxGlobals.NullToIntZero(HF_soid.Value) == 0 ? new List<string>() { "sonomax", "id" } : new List<string>() { }, true, true,
                new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue = cmb_branchid } });
                if (res.errorid == 0)
                {
                    //PDetiles.Style.Add("display", "block");
                    if (EmaxGlobals.NullToIntZero(HF_soid.Value) != 0)
                    {

                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                    }
                    else
                    {
                        HF_soid.Value = res.outputparams != null && res.outputparams.Count > 0 ? EmaxGlobals.NullToEmpty(res.outputparams["id"]) : "";
                        //  txt_sinvtime.Text = res.outputparams.ContainsKey("time") ? EmaxGlobals.NullToEmpty(res.outputparams["time"].ToString()) : "";
                        txt_sono.Text = res.outputparams.ContainsKey("sonomax") ? EmaxGlobals.NullToEmpty(res.outputparams["sonomax"].ToString()) : "";

                    }
                    PDetiles.Style.Add("display", "block");
                    cmb_branchid.ClientEnabled = false;
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
            clear_order();
        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]

        public static string Deletedata(int soid)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("soid", soid);
            var res = SqlCommandHelper.ExecuteNonQuery("s_quote_order_del", dict, true);
            return JsonConvert.SerializeObject(res);
        }

        List<object> GetVatParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_soid.Value) != 0)
            {
                return new List<object> { HF_soid, txt_netbvat, txt_vatvalue, txt_netavat };
            }
            else
            {
                return null;
            }
        }
        List<object> GetParam_dtl()
        {
            if (EmaxGlobals.NullToIntZero(HF_sodtlid.Value) == 0)
            {
                return new List<object> { HF_soid, HF_itemid, HF_unitid, HF_factor, txt_qty, txt_price, txt_value, txt_discp, txt_discvalue, txt_netvalue, txt_itemvatvalue, txt_itemnotes };
            }
            else
            {

                return new List<object> { HF_sodtlid, HF_soid, HF_itemid, HF_unitid, HF_factor, txt_qty, txt_price, txt_value, txt_discp, txt_discvalue, txt_netvalue, txt_itemvatvalue, txt_itemnotes };
            }
        }
        protected void btn_save_dtls_Click(object sender, EventArgs e)
        {
            var res = SaveData(EmaxGlobals.NullToIntZero(HF_sodtlid.Value) == 0 ? "s_quote_orderdtls_ins" : "s_quote_orderdtls_upd"
, GetParam_dtl(), null,
  null, true, true,
  new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue = cmb_branchid } });
            if (res.errorid == 0)
            {

                gvs_orderdtls.DataBind();

                clear();


                var res2 = SaveData("s_ord_vat_upd", GetVatParam(), null, null, true, false, null);
            }
        }


        DataTable GvdetailSource()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("soid", HF_soid.Value);

            return SqlCommandHelper.ExcecuteToDataTable("s_quote_orderdtls_sel", dict).dataTable;

        }
        protected void gvs_orderdtls_DataBinding(object sender, EventArgs e)
        {
            gvs_orderdtls.DataSource = GvdetailSource();
        }
        protected void gvs_orderdtls_DataBound(object sender, EventArgs e)
        {
            ASPxGridView gridView = sender as ASPxGridView;
            //  gridView.JSProperties["cpSummary"] = gridView.GetTotalSummaryValue(gridView.TotalSummary["netvalue"]);
            if (gridView.GetTotalSummaryValue(gridView.TotalSummary["snet"]) == null || gridView.GetTotalSummaryValue(gridView.TotalSummary["snet"]).ToString() == "")
            {
                return;
            }
            //شامل الضريبه
            if (HF_vattype.Value == "1")
            {
                txt_netavat.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["snet"]).ToString();
                txt_vatvalue.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["vatvalue"]).ToString();
                txt_netbvat.Text = (EmaxGlobals.NullToZero(txt_netavat.Text) - EmaxGlobals.NullToZero(txt_vatvalue.Text)).ToString();

            }
            ///غير شامل الصريبه
            else if (HF_vattype.Value == "2")
            {
                txt_netbvat.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["snet"]).ToString();
                txt_vatvalue.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["vatvalue"]).ToString();
                txt_netavat.Text = (EmaxGlobals.NullToZero(txt_netbvat.Text) + EmaxGlobals.NullToZero(txt_vatvalue.Text)).ToString();

            }
            else if (HF_vattype.Value == "3")
            {
                txt_netbvat.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["snet"]).ToString();
                txt_netavat.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["snet"]).ToString();
                txt_vatvalue.Text = gridView.GetTotalSummaryValue(gridView.TotalSummary["vatvalue"]).ToString();
            }
        }

        protected void gvs_orderdtls_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            if (EmaxGlobals.NullToBool(HF_sinvc.Value) == true)
            {
                disable();
                //btn_Save.Enabled = false;
                //btn_delete.Enabled = false;
                //btn_delete_dtls.Enabled = false;
                //btn_createinv.Enabled = false;
                //btn_save_dtls.Enabled = false;
                //btn_attach.Enabled = false;
                //ASPxButton1.Enabled = false;

            }
            else
            {
                enable();
                //btn_Save.Enabled = true;
                //btn_delete.Enabled = true;
                //btn_delete_dtls.Enabled = true;
                //btn_createinv.Enabled = true;
                //btn_save_dtls.Enabled = true;
                //btn_attach.Enabled = true;
                //ASPxButton1.Enabled = true;
            }
            gvs_orderdtls.DataBind();

            PDetiles.Style.Add("display", "block");
            if (EmaxGlobals.NullToEmpty(HF_itemid.Value) != "")
            {
                txt_qty.Focus();
            }
            cmb_branchid.ClientEnabled = false;
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
                string excelPath = Server.MapPath("~/Files/Sales") + Path.GetFileName(FileUpload2.PostedFile.FileName);
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

                var res = SaveData("s_quote_order_itemexcel_ins", new List<object> { HF_soid }, null,
                null, true, true, null
                , null);
                if (res.errorid == 0)
                {
                    clear();
                    gvs_orderdtls.DataBind();

                }
                else
                {
                    if (res.errormsg.Contains("FK_s_orderdtls_s_order") == true)
                    {
                        Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath);
                    }
                    string msg = HttpUtility.JavaScriptStringEncode(res.errormsg);

                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('" + msg + "')", true);

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
                    gvs_orderdtls.DataBind();

                }
            }
            catch (Exception ex)
            {


                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                //  ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo(" + ex.Message + ")", true);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);

            }
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvitemsExporter, "اصناف عرض الأسعار", 1, Request.GetOwinContext().Request.User.Identity.Name, gvs_orderdtls.GetSelectedFieldValues("sodtlid").Count != 0, false, "أصناف عرض الأسعار رقم " + txt_sono.Text);
            }
            catch (Exception ex)
            {

                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_createinv_Click(object sender, EventArgs e)
        {
            try
            {
                var res = SaveData("s_quote_order_to_inv_ins", new List<object> { HF_soid, cmb_branchid }, null, new List<string>() { "sinvc" }, true, false, null);
                if (res.errorid == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                    disable();
                    HF_sinvc.Value = EmaxGlobals.NullToEmpty(res.outputparams.ContainsKey("sinvc"));
                }

            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + msg + ")", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("soid", HF_soid.Value);

            PrintPage("Sales/s_quote_order_page.repx", dict);
        }
    }
}