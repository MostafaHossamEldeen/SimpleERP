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
    public partial class st_Trans_ord : EmaxBasepage
    {
        public ButtonRenderMode Secondary { get; private set; }
        protected override void OnInit(EventArgs e)
        {
            pageid = "19";

            base.OnInit(e);
        }
        void clear()
        {

            txt_transno.Text = "تلقائى";
            txt_trandocno.Text = string.Empty;
            txt_trannotes.Text = string.Empty;
            txt_username.Text = Context.User.Identity.Name;
            txt_trandate.Date = DateTime.Now;
            cmb_branchid.SelectedIndex = 0;
            cmb_branchtoid.SelectedIndex = 1;
            cmb_ccid.SelectedIndex = -1;
            cmb_cctoid.SelectedIndex = -1;
            HF_transid.Value = "";
            hf_postst.Value = "";
            hf_postacc.Value = "";
            lbl_postacc.Text = string.Empty;
            lbl_postst.Text = string.Empty;
            txt_issordno.Text = string.Empty;
            txt_resev.Text = string.Empty;
            txt_vochrid.Text = string.Empty;
            //txt_issordno.Visible = false;
            // txt_resev.Visible = false;
            cmb_branchid.ClientEnabled = true;
            enable();
            btn_postacc.Enabled = true;
            btn_postacc.CssClass = "enable";
            btn_postst.Enabled = true;
            btn_postst.CssClass = "enable";
            btn_resevord.Enabled = true;
            btn_resevord.CssClass = "enable";
            PDetiles.Style.Add("display", "none");
            Clear_dtl();
            gvs_transdtls.DataBind();
            HF_receipt.Value = string.Empty;
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

           

            btn_fastinsert.Enabled = true;
            btn_fastinsert.CssClass = "enable";
            
            btn_attach.Enabled = true;
            btn_attach.CssClass = "enable";
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
        DataTable GvdetailSource()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("transid", HF_transid.Value);

            return SqlCommandHelper.ExcecuteToDataTable("st_transdtls_trans_sel", dict).dataTable;

        }
        List<object> GetParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_transid.Value) == 0)
            {
                return new List<object> { txt_trandocno, txt_trandate, cmb_branchid,cmb_branchtoid, cmb_ccid, cmb_cctoid, txt_trannotes, txt_username};
            }
            else
            {
               
              return new List<object> { txt_trandocno, txt_trandate,cmb_branchid,cmb_branchtoid,cmb_ccid,cmb_cctoid, txt_trannotes, txt_username , HF_transid };
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchtoid, "compid,table_name", "1,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_ccid, "compid,table_name", "0,sys_costcenter", "ccid", "ccname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_cctoid, "compid,table_name", "0,sys_costcenter", "ccid", "ccname");
                //string add_tranid = Request.Params["add_tranid"];
                txt_trandate.Date = DateTime.Now;
                cmb_branchtoid.SelectedIndex = 1;
                cmb_ccid.SelectedIndex = -1;
                cmb_cctoid.SelectedIndex = -1;
                txt_username.Text = Context.User.Identity.Name;
                //if (Request.QueryString["transid"] != null || Request.QueryString["transid"] != string.Empty)
                //{
                //    HF_transid.Value = Request.QueryString["transid"];
                //    Dictionary<object, object> dict = new Dictionary<object, object>();
                //    dict.Add("transid", HF_transid.Value);
                //    var f = SqlCommandHelper.ExcecuteToDataTable("st_transactions_sel", dict).dataTable;
                //    if (f.Rows.Count > 0)
                //    {
                //        //bind(f.Rows[0]);
                //    }
                //    gvs_transdtls.DataBind();
                //}
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            var res = SaveData(EmaxGlobals.NullToIntZero(HF_transid.Value) == 0 ? "st_transactions_trans_ins" : "st_transactions_trans_upd"
         , GetParam(), null,
                 EmaxGlobals.NullToIntZero(HF_transid.Value) == 0 ? new List<string>() { "id", "transferno", "transno" } : new List<string>() { "id", "vochrid" }, true, true,
                 new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue = cmb_branchid }
                ,new ParamObject() { ParamName = "branchtoname", ParamValue = cmb_branchtoid }
                ,new ParamObject() { ParamName = "ccname", ParamValue = cmb_ccid }
                ,new ParamObject() { ParamName = "cctoname", ParamValue = cmb_cctoid }});
            if (res.errorid == 0)
            {
                if (EmaxGlobals.NullToIntZero(HF_transid.Value) != 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                }
                HF_transid.Value = res.outputparams != null && res.outputparams.Count > 0 ? EmaxGlobals.NullToEmpty(res.outputparams["id"]) : "";

                
                txt_vochrid.Text = res.outputparams.ContainsKey("vochrid") ? EmaxGlobals.NullToEmpty(res.outputparams["vochrid"].ToString()) : "";
                if (res.outputparams.ContainsKey("transferno"))
                {
                    txt_transno.Text = EmaxGlobals.NullToEmpty(res.outputparams["transferno"]);
                }   
                if (res.outputparams.ContainsKey("transno"))
                {
                   // txt_issordno.Visible = true;
                    txt_issordno.Text = EmaxGlobals.NullToEmpty(res.outputparams["transno"]);
                }
                //PDetiles.Viclsible = true;

                PDetiles.Style.Add("display", "block");
               


            }
        }

        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            clear();
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
            var res = SqlCommandHelper.ExecuteNonQuery("st_transactions_trans_del", dict, true);
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
            SqlCommandHelper.ExecuteNonQuery("st_transactions_trans_del", dict, true);
            clear();
        }
        List<object> GetParams()
        {
      
            return new List<object>
           {  txt_unitname,txt_qty,cmb_branchid,txt_trandate,HF_transdtlid,HF_transid,HF_itemid,HF_unitid,HF_factor,HF_cost };
        }
        protected void btn_save_dtls_Click(object sender, EventArgs e)
        {
            var _params = GetParams();

            //var droplst = Getdll();

            
            Dictionary<object, object> dictmaster = new Dictionary<object, object>();
 

            var itemval = Math.Round(EmaxGlobals.NullToZero(HF_cost.Value) * EmaxGlobals.NullToZero(txt_qty.Value), 3);
            dictmaster.Add("value", itemval);
            var res = SaveData(EmaxGlobals.NullToIntZero(HF_transdtlid.Value) == 0 ? "st_transdtls_trans_ins" : "st_transdtls_trans_upd", _params, /*dictupd*/null,
                 null, true, true, null
                 , dictmaster);
            if (res.errorid == 0)
            {
                Clear_dtl();
                gvs_transdtls.DataBind();

            }

        }

        protected void btn_new_dtls_Click(object sender, EventArgs e)
        {
         //   Clear_dtl();
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
            var res = SqlCommandHelper.ExecuteNonQuery("st_transdtls_trans_del", dict, true);
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
            SqlCommandHelper.ExecuteNonQuery("st_transdtls_trans_del", dict, true);
            gvs_transdtls.DataBind();
            Clear_dtl();
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                
                ExportingDevExpressUtil.Export(gvitemsExporter, "تفاصيل اذون التحويل", 1, Request.GetOwinContext().Request.User.Identity.Name, gvs_transdtls.GetSelectedFieldValues("transdtlid").Count != 0, false, "تفاصيل اذن التحويل رقم " + txt_transno.Text);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }
        protected void HiddenField1_ValueChanged(object sender, EventArgs e)
        {

        }

        protected void txt_itemid_TextChanged(object sender, EventArgs e)
        {
            //Dictionary<object, object> dict = new Dictionary<object, object>();
            //dict.Add("itemcode", txt_itemid.Text);
            //dict.Add("barcode1", txt_itemid.Text);
            //var f = SqlCommandHelper.ExcecuteToDataTable("st_itemunit_sel_item_code", dict).dataTable;
            //if (f.Rows.Count > 0)
            //{
            //    bind_items(f.Rows[0]);

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
            }
            if (post.Length > 2)
            {
                if (post[2] != "" || post[2] != null)
                {
                    txt_vochrid.Text = post[2];
                    txt_vochrid.NavigateUrl = "~/GL/Vouchers.aspx" + "?vchrno=" + txt_vochrid.Text + "";
                }
            }
            if (HF_receipt.Value == "true")
            {
                btn_resevord.Enabled = false;
                btn_resevord.CssClass = "disable";
                btn_resevord.RenderMode = Secondary;
            }
            else
            {
                btn_resevord.Enabled = true;
                btn_resevord.CssClass = "enable";
            }

            //if (txt_vochrid.Text!=string.Empty&& post.Length > 3)
            //{
            //    txt_vochrid.NavigateUrl = "~/GL/Vouchers.aspx" + "?vchrno=" + txt_vochrid.Text + "";
            //}
            gvs_transdtls.DataBind();
            PDetiles.Style.Add("display", "block");
             
        }

        protected void gvs_transdtls_DataBinding(object sender, EventArgs e)
        {
            gvs_transdtls.DataSource = GvdetailSource();
        }
        List<object> GetresevParams()
        {

            return new List<object>
           {  txt_trandocno, txt_trandate, cmb_branchid,cmb_branchtoid, cmb_ccid, cmb_cctoid, txt_trannotes, txt_username,txt_transno,HF_transid };
        }
        protected void btn_resevord_Click(object sender, EventArgs e)
        {
            var res = SaveData( "st_transactions_resev_ins"
         , GetresevParams(), null,
                 new List<string>() { "transno_trans","id" } , true, true,
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
                btn_resevord.Enabled = false;
                btn_resevord.CssClass = "disable";
                btn_resevord.RenderMode = Secondary;
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

                var res = SaveData("st_transactions_trans_itemexcel_ins", new List<object> { HF_transid }, null,
                null, true, true, null
                , null);
                if (res.errorid == 0)
                {
                    Clear_dtl();
                    gvs_transdtls.DataBind();

                }
                else
                {
                    if (res.errormsg.Contains(" FK_st_transdtls_st_transactions") == true)
                    {
                        Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath);
                    }

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
            
            //Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath);
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("transid", HF_transid.Value);

            PrintPage("Stock/st_Trans_ord_page.repx", dict);
        }
    }
}