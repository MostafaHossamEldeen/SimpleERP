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

namespace VanSales.Stock
{
    public partial class st_edit_issord : EmaxBasepage
    {
        public ButtonRenderMode Secondary { get; private set; }
        protected override void OnInit(EventArgs e)
        {
            pageid = "17";

            base.OnInit(e);
        }
        void bind(DataRow rec)
        {
            txt_transno.Text = EmaxGlobals.NullToEmpty(rec["transno"]);
            txt_trandocno.Text = EmaxGlobals.NullToEmpty(rec["trandocno"]);
            txt_trandate.Value = Convert.ToDateTime(EmaxGlobals.NullToEmpty(rec["trandate"]));
            ddl_branchid.Value = EmaxGlobals.NullToEmpty(rec["branchid"]);
            ddl_branchid.Text = EmaxGlobals.NullToEmpty(rec["branchname"]).ToString();
            ddl_ccid.Value = EmaxGlobals.NullToEmpty(rec["ccid"]);
            ddl_ccid.Text = EmaxGlobals.NullToEmpty(rec["ccname"]).ToString();
            ddl_naturetran.Value = EmaxGlobals.NullToEmpty(rec["naturetran"]);
            ddl_naturetran.Text = EmaxGlobals.NullToEmpty(rec["naturename"]).ToString();
            txt_trannotes.Text = EmaxGlobals.NullToEmpty(rec["trannotes"]);
            txt_username.Text = EmaxGlobals.NullToEmpty(rec["username"]);
            PDetiles.Visible = true;
        }
        //private void bind_items(DataRow dataRow)
        //{
        //    HF_itemid.Value = EmaxGlobals.NullToEmpty(dataRow["itemid"]);
        //    txt_item_name.Text = EmaxGlobals.NullToEmpty(dataRow["itemname"]);
        //    txt_unitname.Text = EmaxGlobals.NullToEmpty(dataRow["unitname"]);
        //    HF_unitid.Value = EmaxGlobals.NullToEmpty(dataRow["unitid"]);
        //    HF_factor.Value = EmaxGlobals.NullToEmpty(dataRow["factor"]);
        //    HF_cost.Value = EmaxGlobals.NullToEmpty(dataRow["cprice"]);

        //}
        //private void bind_qty(DataRow Rows)
        //{
        //    lbl_qtyinf.Text = "الرصيد بالمخزن:" + EmaxGlobals.NullToEmpty(Rows["qty"] + "حبه");
        //}
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
            //btn_postst.Enabled = false;
            //btn_postst.CssClass = "disable";
            //btn_postst.RenderMode = Secondary;

            btn_delete_dtls.Enabled = false;
            btn_delete_dtls.CssClass = "disable";
            btn_delete_dtls.RenderMode = Secondary;

            btn_fastinsert.Enabled = false;
            btn_fastinsert.CssClass = "disable";
            btn_fastinsert.RenderMode = Secondary;
            btn_attach.Enabled = false;
            btn_attach.CssClass = "disable";
            btn_attach.RenderMode = Secondary;
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

            //btn_postst.Enabled = true;
            //btn_postst.CssClass = "enable";

            btn_fastinsert.Enabled = true;
            btn_fastinsert.CssClass = "enable";

            btn_attach.Enabled = true;
            btn_attach.CssClass = "enable";
        }
        void clear()
        {

            txt_transno.Text = "تلقائى";
            txt_trandocno.Text = string.Empty;
            txt_trannotes.Text = string.Empty;
            ddl_naturetran.SelectedIndex = 0;
            txt_trandate.Date = DateTime.Now;
            ddl_branchid.SelectedIndex = 0;
            ddl_ccid.SelectedIndex = -1;
            HF_transid.Value = "";
            hf_postst.Value = "";
            hf_postacc.Value = "";
            txt_username.Text = Context.User.Identity.Name;
            lbl_postacc.Text = string.Empty;
            lbl_postst.Text = string.Empty;
            ddl_branchid.ClientEnabled = true;
            txt_vochrid.Text = string.Empty;
            enable();
            btn_postst.Enabled = true;
            btn_postst.CssClass = "enable";
            btn_postacc.Enabled = true;
            btn_postacc.CssClass = "enable";
            PDetiles.Style.Add("display", "none");
            Clear_dtl();
            gvs_transdtls.DataBind();
        }
        void Clear_dtl()
        {
            txt_itemid.Text = string.Empty;
            txt_item_name.Text = string.Empty;
            txt_qty.Text = "1";
            txt_unitname.Text = string.Empty;
            HF_transdtlid.Value = "";
            HF_unitid.Value = "";
            HF_itemid.Value = "";
            HF_cost.Value = "";
            HF_factor.Value = "";
            lbl_qtyinf.Text = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", ddl_branchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox("sys_fillcomp_sel", ddl_ccid, "compid,table_name", "0,sys_costcenter", "ccid", "ccname");
                Util.GenerateCombobox("sys_fillcomp_sel", ddl_naturetran, "compid,table_name", "8,sys_fillcomp", "citemid", "citemname");
                //string add_tranid = Request.Params["add_tranid"];
                txt_trandate.Date = DateTime.Now;
                ddl_ccid.SelectedIndex = -1;
                txt_username.Text = Context.User.Identity.Name;
                //if (Request.QueryString["transid"] != null || Request.QueryString["transid"] != string.Empty)
                //{
                //    HF_transid.Value = Request.QueryString["transid"];
                //    Dictionary<object, object> dict = new Dictionary<object, object>();
                //    dict.Add("transid", HF_transid.Value);
                //    var f = SqlCommandHelper.ExcecuteToDataTable("st_transactions_sel", dict).dataTable;
                //    if (f.Rows.Count > 0)
                //    {
                //        bind(f.Rows[0]);
                //    }
                //    gvs_transdtls.DataBind();
                //}


                //if (EmaxGlobals.NullToEmpty(HF_transid.Value) != "")
                //{


                //    Lbl_Tittle.Text = "تحديث بيانات إذن الصرف";
                //}
                //else
                //{
                //    Page.Title = "تسجيل إذن الصرف جديد";
                //    Lbl_Tittle.Text = "تسجيل إذن الصرف جديد";
                //}
            }

        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {

            var res = SaveData(EmaxGlobals.NullToIntZero(HF_transid.Value) == 0 ? "st_transactions_issord_ins" : "st_transactions_issord_upd", new List<object>
           { txt_trandocno,ddl_branchid, txt_trannotes, ddl_naturetran, txt_username,ddl_ccid,txt_trandate ,HF_transid}, null,
               EmaxGlobals.NullToIntZero(HF_transid.Value) == 0 ? new List<string>() { "id", "transno" } : new List<string>() { "id", "vochrid" }, true, true,
               new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue = ddl_branchid }
                ,new ParamObject() { ParamName = "naturename", ParamValue = ddl_naturetran }
                ,new ParamObject() { ParamName = "ccname", ParamValue = ddl_ccid } });
            if (res.errorid == 0)
            {
                if (EmaxGlobals.NullToIntZero(HF_transid.Value) != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                }
                HF_transid.Value = res.outputparams != null && res.outputparams.Count > 0 ? EmaxGlobals.NullToEmpty(res.outputparams["id"]) : "";

                ddl_branchid.ClientEnabled = false;
                txt_vochrid.Text = res.outputparams.ContainsKey("vochrid") ? EmaxGlobals.NullToEmpty(res.outputparams["vochrid"].ToString()) : "";
                if (res.outputparams.ContainsKey("transno"))
                {
                    txt_transno.Text = EmaxGlobals.NullToEmpty(res.outputparams["transno"]);
                }
                //PDetiles.Viclsible = true;

                PDetiles.Style.Add("display", "block");



            }

        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static string Deletedata(int transid)
        {
            //if (EmaxGlobals.NullToIntZero(transid) == 0)
            //{
            //ScriptManager.RegisterClientScriptBlock(Page, GetType(), "mykey", "sweetinfo('لايوجد أذن للحذف')", true);
            //return;
            //  }
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("transid", transid);
            var res = SqlCommandHelper.ExecuteNonQuery("st_transactions_issord_del", dict, true);
            return JsonConvert.SerializeObject(res);
        }
        protected void btn_delete_Click(object sender, EventArgs e)
        {
            if (EmaxGlobals.NullToIntZero(HF_transid.Value) == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('لايوجد أذن للحذف')", true);
                return;
            }
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("transid", HF_transid.Value);
            SqlCommandHelper.ExecuteNonQuery("st_transactions_issord_del", dict, true);
            clear();
        }
        List<ParamObject> Getdll()
        {
            return new List<ParamObject>() {
                new ParamObject() { ParamName = "naturename", ParamValue = ddl_naturetran }
        };

        }
        List<object> GetParams()
        {
            //dictupd.Add("transdtlid", HF_transdtlid.Value);
            //Dictionary<object, object> dictmaster = new Dictionary<object, object>();
            //dictmaster.Add("transid", HF_transid.Value);
            //dictmaster.Add("itemid", HF_itemid.Value);
            //dictmaster.Add("unitid", HF_itemunitid.Value);
            //dictmaster.Add("factor", HF_factor.Value);
            //dictmaster.Add("cost", HF_cost.Value);
            return new List<object>
           {  txt_unitname,txt_qty,ddl_branchid, ddl_naturetran,txt_trandate,HF_transdtlid,HF_transid,HF_itemid,HF_unitid,HF_factor,HF_cost };
        }
        protected void btn_save_dtls_Click(object sender, EventArgs e)
        {
            var _params = GetParams();

            var droplst = Getdll();

            //Dictionary<object, object> dictupd = new Dictionary<object, object>();
            //dictupd.Add("transdtlid", HF_transdtlid.Value);
            Dictionary<object, object> dictmaster = new Dictionary<object, object>();
            //dictmaster.Add("transid", HF_transid.Value);
            //dictmaster.Add("itemid", HF_itemid.Value);
            //dictmaster.Add("unitid", HF_itemunitid.Value);
            //dictmaster.Add("factor", HF_factor.Value);
            //dictmaster.Add("cost", HF_cost.Value);

            var itemval = Math.Round(EmaxGlobals.NullToZero(HF_cost.Value) * EmaxGlobals.NullToZero(txt_qty.Value), 3);
            dictmaster.Add("value", itemval);
            var res = SaveData(EmaxGlobals.NullToIntZero(HF_transdtlid.Value) == 0 ? "st_transdtls_issord_ins" : "st_transdtls_issord_upd", _params, /*dictupd*/null,
                 null, true, true, null
                 , dictmaster);
            if (res.errorid == 0)
            {
                Clear_dtl();
                gvs_transdtls.DataBind();

            }

        }
        [WebMethod(EnableSession = true)]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public static string Deletedatadtl(int transdtlid)
        {
            //if (EmaxGlobals.NullToIntZero(transid) == 0)
            //{
            //ScriptManager.RegisterClientScriptBlock(Page, GetType(), "mykey", "sweetinfo('لايوجد أذن للحذف')", true);
            //return;
            //  }
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("transdtlid", transdtlid);
            var res = SqlCommandHelper.ExecuteNonQuery("st_transdtls_issord_del", dict, true);
            return JsonConvert.SerializeObject(res);
        }
        protected void btn_delete_dtls_Click(object sender, EventArgs e)
        {

            if (EmaxGlobals.NullToIntZero(HF_transdtlid.Value) == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('برجاء اختيار المراد حذفه')", true);
                return;
            }
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("transdtlid", HF_transdtlid.Value);
            SqlCommandHelper.ExecuteNonQuery("st_transdtls_issord_del", dict, true);
            gvs_transdtls.DataBind();
            Clear_dtl();

        }

        DataTable GvdetailSource()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("transid", HF_transid.Value);

            return SqlCommandHelper.ExcecuteToDataTable("st_transdtls_issord_sel", dict).dataTable;

        }

        protected void gvs_transdtls_DataBinding(object sender, EventArgs e)
        {
            gvs_transdtls.DataSource = GvdetailSource();
        }

        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            clear();
            // PDetiles.Visible = false;
        }

        protected void btn_new_dtls_Click(object sender, EventArgs e)
        {
            //Clear_dtl();
            //HF_transdtlid.Value = "";
        }

        protected void txt_itemid_TextChanged(object sender, EventArgs e)
        {
            //Dictionary<object, object> dict = new Dictionary<object, object>();
            //dict.Add("itemcode", txt_itemid.Text);
            //var f = SqlCommandHelper.ExcecuteToDataTable("st_itemunit_sel_item_code", dict).dataTable;
            //if (f.Rows.Count > 0)
            //{
            //    bind_items(f.Rows[0]);
            //}

            //Dictionary<object, object> dict = new Dictionary<object, object>();
            //dict.Add("itemcode", txt_itemid.Text);
            //dict.Add("barcode1", txt_itemid.Text);
            //var f = SqlCommandHelper.ExcecuteToDataTable("st_itemunit_sel_item_code", dict).dataTable;
            //if (f.Rows.Count > 0)
            //{
            //    bind_items(f.Rows[0]);

            //}

            //Dictionary<object, object> dictqty = new Dictionary<object, object>();
            //dictqty.Add("itemid", HF_itemid.Value);
            //dictqty.Add("branchid", ddl_branchid.Value);

            //var qtyinv = SqlCommandHelper.ExcecuteToDataTable("st_itemwh_qty_sel", dictqty).dataTable;
            //if (qtyinv.Rows.Count > 0)
            //{
            //    bind_qty(qtyinv.Rows[0]);

            //}
            //else
            //{
            //    lbl_qtyinf.Text = "الرصيد بالمخزن 0 حبه";
            //}
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
                    btn_postst.Enabled = false;
                    btn_postst.CssClass = "disable";
                    btn_postst.RenderMode = Secondary;
                }
                else
                {
                    lbl_postst.Text = "";
                    enable();
                    btn_postst.Enabled = true;
                    btn_postst.CssClass = "enable";

                    //if (post.Length == 1 && post[0] == "")
                    //{
                    //    gvs_transdtls.DataBind();
                    //    // PDetiles.Style.Add("display", "block");
                    //    //ddl_branchid.ClientEnabled = false;
                    //    return;
                    //}
                }
                if (EmaxGlobals.NullToBool(post[1]) == true)
                {
                    lbl_postacc.Text = "مرحل حسابات";
                    disable();
                    btn_postacc.Enabled = false;
                    btn_postacc.CssClass = "disable";
                    btn_postacc.RenderMode = Secondary;
                }
                else
                {
                    lbl_postacc.Text = "";
                    if (EmaxGlobals.NullToBool(post[0]) != true)
                    {
                        enable();
                    }
                   
                    btn_postacc.Enabled = true;
                    btn_postacc.CssClass = "enable";
                }

                if (post.Length > 2)
                {
                    if (post[2] != "" || post[2] != null)
                    {
                        txt_vochrid.Text = post[2];
                        txt_vochrid.NavigateUrl = "~/GL/Vouchers.aspx" + "?vchrno=" + txt_vochrid.Text + "";
                    }
                }
            }
            gvs_transdtls.DataBind();
            PDetiles.Style.Add("display", "block");
            ddl_branchid.ClientEnabled = false;

        }
        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvitemsExporter, "تفاصيل اذون الصرف", 1, Request.GetOwinContext().Request.User.Identity.Name, gvs_transdtls.GetSelectedFieldValues("transdtlid").Count != 0, false, "تفاصيل اذن الصرف رقم " + txt_transno.Text);
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
                if (!Directory.Exists(Server.MapPath("~/Files/stock/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Files/stock/"));
                }

                //Upload and save the file
                string excelPath = Server.MapPath("~/Files/stock") + Path.GetFileName(FileUpload1.PostedFile.FileName);
                //var  f=Request.Files[0];
                FileUpload1.SaveAs(excelPath);

                string conString = string.Empty;
                string extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
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

                var res = SaveData("st_trans_issord_itemexcel_ins", new List<object> { HF_transid }, null,
                null, true, true, null
                , null);
                if (res.errorid == 0)
                {
                    Clear_dtl();
                    gvs_transdtls.DataBind();

                }
                else
                {




                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('" + res.errormsg + "')", true);
                    gvs_transdtls.DataBind();
                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo(" + res.errormsg + ")", true);
                }
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
                //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo(" + ex.Message + ")", true);
            }
            //gvs_transdtls.DataBind();
            //Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath);
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("transid", HF_transid.Value);

            PrintPage("Stock/st_transactions_issord_page.repx", dict);
        }
    }
}