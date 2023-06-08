using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
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
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales
{
    public partial class Items : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "3";
            IndexStored = "st_items_sel";
            base.OnInit(e);
        }
        List<GridViewDataComboBoxColumn> cmblist = new List<GridViewDataComboBoxColumn>();
        protected void Page_Load(object sender, EventArgs e)
        {
            #region combobox
            var dict = new Dictionary<object, object>();
            dict.Add("compid", "5");
            dict.Add("table_name", "sys_fillcomp");
            CmbItemStop=Util.GenerateGridViewCmb(gvitems, "sys_fillcomp_sel", "itemstop", "citemname", "citemid", "اختر", dict);
            var dict1 = new Dictionary<object, object>();
            dict1.Add("compid", "4");
            dict1.Add("table_name", "sys_fillcomp");
            CmbItemType = Util.GenerateGridViewCmb(gvitems, "sys_fillcomp_sel", "itemtypeid", "citemname", "citemid", "اختر", dict1);
            CmbGroup = Util.GenerateGridViewCmb(gvitems, "st_group_sel", "groupid", "groupname", "", "اختر");
            CmbUnit = Util.GenerateGridViewCmb(gvitems, "st_unit_sel", "unitid", "unitname", "", "اختر");
            Cmbsupp = Util.GenerateGridViewCmb(gvitems, "p_supplier_sel_cmb", "suppid", "suppname", "", "اختر");
            #endregion

            gvitems.DataBind();
        }

        #region combobox
        public GridViewDataComboBoxColumn CmbUnit { get; set; }
        public GridViewDataComboBoxColumn CmbGroup { get; set; }
        public GridViewDataComboBoxColumn CmbItemType { get;set; }
        public GridViewDataComboBoxColumn CmbItemStop { get;set; }
        public GridViewDataComboBoxColumn Cmbsupp { get; set; }
        #endregion

        protected void ASPxUploadItemPic_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            try
            {
                if (e.IsValid)
                {
                    Session["fileName"] = e.UploadedFile.FileNameInStorage;
                    Session["filePath"] = "~/Img/Item/" + Session["fileName"].ToString();
                    e.UploadedFile.SaveAs(MapPath(Session["filePath"].ToString()));
                    ASPxUploadControl UploadControl = (ASPxUploadControl)gvitems.FindEditRowCellTemplateControl((GridViewDataColumn)gvitems.Columns["itempic"], "ASPxUploadItemPic");
                }
            }
            catch (Exception ex)
            {
                gvitems.JSProperties["cperrors"] = ex.Message;
                gvitems.JSProperties["cpicon"] = "error";
            }
        }

        protected void gvitems_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
            try
            {
                if (Session["filePath"] != null)
                {
                    ASPxUploadControl UploadControl = (ASPxUploadControl)gvitems.FindEditRowCellTemplateControl((GridViewDataColumn)gvitems.Columns["itempic"], "ASPxUploadItemPic");
                    e.NewValues["itempic"] = Session["filePath"].ToString();
                    Session.Remove("fileName");
                    Session.Remove("filePath");
                    var g = SqlCommandHelper.ExecuteNonQuery("st_items_ins", e.NewValues, true);

                    if (g.errorid != 0)
                    {
                        throw new Exception(g.errormsg);
                    }
                    else
                    {
                        e.Cancel = true;
                        gvitems.CancelEdit();
                    }
            
                }
                else
                {
                    e.NewValues["itempic"] = DBNull.Value;
                    var g = SqlCommandHelper.ExecuteNonQuery("st_items_ins", e.NewValues, true);

                    if (g.errorid != 0)
                    {
                        throw new Exception(g.errormsg);
                    }
                    else
                    {
                        e.Cancel = true;
                        gvitems.CancelEdit();
                    }
                }
            }
            catch (Exception ex)
            {
                gvitems.JSProperties["cperrors"] = ex.Message;
                gvitems.JSProperties["cpicon"] = "error";
            }
        }

        protected void gvitems_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                if (Session["filePath"] != null)
                {
                    ASPxUploadControl UploadControl = (ASPxUploadControl)gvitems.FindEditRowCellTemplateControl((GridViewDataColumn)gvitems.Columns["itempic"], "ASPxUploadItemPic");
                    e.NewValues["itempic"] = Session["filePath"].ToString();
                    Session.Remove("fileName");
                    Session.Remove("filePath");
                    var g = SqlCommandHelper.ExecuteNonQuery("st_items_upd", e.NewValues, true, e.Keys);
                    if (g.errorid != 0)
                    {
                        throw new Exception(g.errormsg);
                    }
                    else
                    {
                        e.Cancel = true;
                        gvitems.CancelEdit();
                    }
                }
                else
                {
                    var gg = gvitems.GetSelectedFieldValues("itempic");// e.OldValues["itempic"];
                    var g = SqlCommandHelper.ExecuteNonQuery("st_items_upd", e.NewValues, true, e.Keys);

                    if (g.errorid != 0)
                    {
                        throw new Exception(g.errormsg);
                    }
                    else
                    {
                        e.Cancel = true;
                        gvitems.CancelEdit();
                    }
                }
            }
            catch (Exception ex)
            {
                gvitems.JSProperties["cperrors"] = ex.Message;
                gvitems.JSProperties["cpicon"] = "error";
            }


        }
        protected void gvitems_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            try
            {
                List<object> KeyValues = gvitems.GetSelectedFieldValues("itemid");
                if (KeyValues.Count == 0)
                {
                    gvitems.JSProperties["cperrors"] = "برجاء إختيار صنف لحذفة";
                    gvitems.JSProperties["cpicon"] = "error";
                    return;
                }
                StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
                var res = new StoredExecuteResulte();

                int count = 0;

                string[] itmimgpath = { };

                if (e.Parameters.Length != 0)
                {
                    itmimgpath = e.Parameters.Split(',');
                }

                foreach (object key in KeyValues)
                {
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("itemid", key);
                    res = SqlCommandHelper.ExecuteNonQuery("st_items_del", dict, true);
                    if (res.errorid == 0)
                    {
                        if (itmimgpath.Length != 0)
                        {
                            try
                            {
                                if (File.Exists(Server.MapPath(itmimgpath[count])))
                                {
                                    var strFile = Server.MapPath(itmimgpath[count]);
                                    FileAttributes attributes = File.GetAttributes(strFile);

                                    if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                                    {
                                        attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly);
                                        File.SetAttributes(strFile, attributes);
                                        File.Delete(strFile);
                                    }
                                    else
                                    {
                                        File.Delete(strFile);
                                    }
                                }
                                count++;
                            }
                            catch (Exception ex)
                            {
                                gvitems.JSProperties["cperrors"] = ex.Message;
                                gvitems.JSProperties["cpicon"] = "error";
                            }
                        }
                        gvitems.DataBind();
                        gvitems.JSProperties["cperrors"] = "تم الحذف بنجاح";
                        gvitems.JSProperties["cpicon"] = "success";
                    }
                    else
                    {
                        gvitems.JSProperties["cperrors"] = res.errormsg;
                        gvitems.JSProperties["cpicon"] = "error";
                    }
                    if (res.errorid != 0)
                    {
                        gvitems.JSProperties["cperrors"] = res.errormsg;
                        gvitems.JSProperties["cpicon"] = "error";
                    }
                    gvitems.DataBind();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("index is out of range.") || ex.Message.Contains("الفهرس خارج النطاق. يجب ألا يكون قيمته سالبة ويجب ألا يكون أقل من حجم المجموعة."))
                {
                    gvitems.JSProperties["cperrors"] =  "برجاء إختيار صنف لحذفة";
                    gvitems.JSProperties["cpicon"] = "error";
                }
                else
                {
                    gvitems.JSProperties["cperrors"] = ex.Message;
                    gvitems.JSProperties["cpicon"] = "error";
                }
            }
                
        }
        private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }

        protected void btnpdf_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvitemsExporter, "الأصناف", 2, Request.GetOwinContext().Request.User.Identity.Name, gvitems.GetSelectedFieldValues("itemid").Count != 0, false, "الأصناف");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(this.GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void btndoc_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvitemsExporter, "الأصناف", 0, Request.GetOwinContext().Request.User.Identity.Name, gvitems.GetSelectedFieldValues("itemid").Count != 0, false, "الأصناف");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void btnxlsx_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvitemsExporter, "الأصناف", 1, Request.GetOwinContext().Request.User.Identity.Name, gvitems.GetSelectedFieldValues("itemid").Count != 0, false, "الأصناف");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvitemsExporter, "الأصناف", 2, Request.GetOwinContext().Request.User.Identity.Name, gvitems.GetSelectedFieldValues("itemid").Count != 0, true, "الأصناف");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }
        protected void gvitems_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            
            e.NewValues["vat"] = SqlCommandHelper.GetTokenKey("vat", Request.Cookies["Token"].Value);
            e.NewValues["unitid"] = CmbUnit.PropertiesComboBox.Items.Count!=0? CmbUnit.PropertiesComboBox.Items[0].Value:null;
            e.NewValues["groupid"] = CmbGroup.PropertiesComboBox.Items.Count != 0 ? CmbGroup.PropertiesComboBox.Items[0].Value:null;
            e.NewValues["itemtypeid"] = CmbItemType.PropertiesComboBox.Items.Count != 0 ? CmbItemType.PropertiesComboBox.Items[0].Value:null;
            e.NewValues["itemstop"] = CmbItemStop.PropertiesComboBox.Items.Count != 0 ? CmbItemStop.PropertiesComboBox.Items[0].Value:null;
            e.NewValues["suppid"] = Cmbsupp.PropertiesComboBox.Items.Count != 0 ? Cmbsupp.PropertiesComboBox.Items[0].Value : null;
            e.NewValues["balance"] = 0;
        }

        protected void gvitems_DataBinding(object sender, EventArgs e)
        {
            gvitems.DataSource = IndexDataTable;
        }

        protected void gvitems_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {

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
                string excelPath = Server.MapPath("~/Files/stock/") + Path.GetFileName(FileUpload2.PostedFile.FileName);
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
                    SqlCommandHelper.ExecuteNonQuery("st_itemsunit_excel_del", dict, true);
                    using (SqlConnection con = new SqlConnection(consString))
                    {

                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = "dbo.st_itemsunit_excel";

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

                var res = SaveData("st_itemsunit_excel_ins", null, null,null, true, false, null, null);
                if (res.errorid == 0)
                {
                   
                    gvitems.DataBind();

                }
                else
                {
                    //if (res.errormsg.Contains("FK_s_invdtls_s_inv") == true)
                    //{
                    //    Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath);
                    //}
                    string msg = HttpUtility.JavaScriptStringEncode(res.errormsg);

                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('" + msg + "')", true);

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
                    gvitems.DataBind();

                }
            }
            catch (Exception ex)
            {

                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);                
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);

            }
        }
    }
}