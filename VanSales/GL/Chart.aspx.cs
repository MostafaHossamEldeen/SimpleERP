using DevExpress.Web.ASPxTreeList;
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
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;

namespace VanSales.GL
{
    public partial class Chart : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "34";
            IndexStored = "gl_chart_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_acctype, "compid,table_name", "12,sys_fillcomp", "citemid", "citemname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_levelno, "compid,table_name", "13,levelno", "citemid", "citemname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_accnature, "compid,table_name", "14,sys_fillcomp", "citemid", "citemname");
                cmb_accnature.SelectedIndex = -1;
            }
            trlchart.DataBind();
        }
        void clear()
        {
            hf_chartid.Value = "0";
            txt_chartcode.Text = null;
            txt_chartname.Text = null;
            txt_chartename.Text = null;
            hf_nodeid.Value = "0";
            txt_nodecode.Text = null;
            cmb_acctype.SelectedIndex = 0;
            cmb_accnature.SelectedIndex = -1;
            cmb_levelno.SelectedIndex = 0;
            txt_balance.Text = "0.00";
        }
        void BindData(DataRow rec)
        {
            clear();
            hf_nodeid.Value = rec["chartid"].ToString();
            txt_nodecode.Text = rec["chartnamedisplay"].ToString();
            cmb_acctype.Value = rec["acctype"].ToString();
            if (rec["accnature"].ToString() == "")
            {
                cmb_accnature.SelectedIndex = -1;
            }
            else
            {
                cmb_accnature.Value = rec["accnature"];
            }
            cmb_levelno.SelectedItem = cmb_levelno.Items.FindByValue(rec["newlevel"].ToString());
            hf_sys_chartlvl.Value = rec["sys_chartlvl"].ToString();
        }
        protected void trlchart_DataBinding(object sender, EventArgs e)
        {
            trlchart.DataSource = IndexDataTable;
        
        }
        List<object> MasterParam()
        {
            if (EmaxGlobals.NullToIntZero(hf_chartid.Value) == 0)
            {
                return new List<object> { txt_chartcode, txt_chartname, txt_chartename, hf_nodeid, cmb_acctype, cmb_accnature, cmb_levelno, txt_balance };
            }
            else
            {
                return new List<object> { hf_chartid, txt_chartcode, txt_chartname, txt_chartename, hf_nodeid, cmb_acctype, cmb_accnature, cmb_levelno, txt_balance };
        }
    }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                var res = SaveData(EmaxGlobals.NullToIntZero(hf_chartid.Value) == 0 ? "gl_chart_ins" : "gl_chart_upd", MasterParam(), null,
                EmaxGlobals.NullToIntZero(hf_chartid.Value) == 0 ? new List<string>() { "chartid" } : null, true, false,
                new List<ParamObject>() { new ParamObject() { ParamName = "acctypename", ParamValue = cmb_acctype }
                ,new ParamObject() { ParamName = "accnaturename", ParamValue = cmb_accnature }
                ,new ParamObject() { ParamName = "levelnoname", ParamValue = cmb_levelno } });
                if (res.errorid == 0)
                {
                    if (EmaxGlobals.NullToIntZero(hf_chartid.Value) != 0)
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
                    }
                    else
                    {
                        hf_chartid.Value = res.outputparams != null && res.outputparams.Count > 0 ? EmaxGlobals.NullToEmpty(res.outputparams["chartid"]) : "";
                        string msg = "تم الحفظ بنجاح";
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + msg + "')", true);
                    }
                    clear();
                    trlchart.DataBind();
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
        protected void trlchart_CustomCallback(object sender, DevExpress.Web.ASPxTreeList.TreeListCustomCallbackEventArgs e)
        {
            if (e.Argument.Length!=0)
            {
                var currentnode = trlchart.FindNodeByKeyValue(e.Argument.ToString());
                currentnode.Focus();
                currentnode.Expanded = true;
                return;
            }
           
            List<TreeListNode> KeyValues = trlchart.GetSelectedNodes();
            if (KeyValues.Count == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('برجاء إختيار حساب لحذفة')", true);
                return;
            }
            StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
            var res = new StoredExecuteResulte();
            foreach (TreeListNode nodekey in KeyValues)
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("chartid", nodekey.Key);
                res = SqlCommandHelper.ExecuteNonQuery("gl_chart_del", dict, true);
                if (res.errorid == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "')", true);
                    trlchart.DataBind();
                    clear();
                }
                else
                {
                    break;
                }
            }
            if (res.errorid != 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + res.errormsg + "')", true);
                return;
            }
            clear();
        }
        protected void btn_excel_Click(object sender, EventArgs e)
        {
            trlchart.SettingsPager.Mode = DevExpress.Web.ASPxTreeList.TreeListPagerMode.ShowAllNodes;
            trlchart.DataBind();
            trlchartExporter.Settings.AutoWidth = true;
            trlchartExporter.Settings.ShowTreeButtons = true;
            trlchartExporter.WriteXlsxToResponse();
            trlchart.SettingsPager.Mode = DevExpress.Web.ASPxTreeList.TreeListPagerMode.ShowPager;
        }

        protected void btn_pdf_Click(object sender, EventArgs e)
        {
            trlchart.SettingsPager.Mode = DevExpress.Web.ASPxTreeList.TreeListPagerMode.ShowAllNodes;
            trlchart.DataBind();
            trlchartExporter.Settings.AutoWidth = true;
            trlchartExporter.Settings.ShowTreeButtons = true;
            trlchartExporter.WritePdfToResponse();
            trlchart.SettingsPager.Mode = DevExpress.Web.ASPxTreeList.TreeListPagerMode.ShowPager;
        }

        protected void btn_word_Click(object sender, EventArgs e)
        {
            trlchart.SettingsPager.Mode = DevExpress.Web.ASPxTreeList.TreeListPagerMode.ShowAllNodes;
            trlchart.DataBind();
            trlchartExporter.Settings.AutoWidth = true;
            trlchartExporter.Settings.ShowTreeButtons = true;
            trlchartExporter.WriteRtfToResponse();
            trlchart.SettingsPager.Mode = DevExpress.Web.ASPxTreeList.TreeListPagerMode.ShowPager;
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            trlchart.SettingsPager.Mode = DevExpress.Web.ASPxTreeList.TreeListPagerMode.ShowAllNodes;
            trlchart.DataBind();
            trlchartExporter.Settings.AutoWidth = true;
            trlchartExporter.Settings.ShowTreeButtons = true;
            trlchartExporter.WritePdfToResponse(false, new PdfExportOptions() { ShowPrintDialogOnOpen = true });
            trlchart.SettingsPager.Mode = DevExpress.Web.ASPxTreeList.TreeListPagerMode.ShowPager;
        }

        protected void trlchart_HtmlRowPrepared(object sender, TreeListHtmlRowEventArgs e)
        {
            if (e.RowKind != TreeListRowKind.Data) return;
            string value = e.GetValue("leger").ToString();
            if (value == "True")
            {
                e.Row.ForeColor = ColorTranslator.FromHtml("#00ad00");
                e.Row.Font.Bold = true;
            }
        }

        protected void trlchart_HtmlDataCellPrepared(object sender, TreeListHtmlDataCellEventArgs e)
        {
            if (e.Column.FieldName == "balance")
            {
                try
                {
                    double Balance = Convert.ToDouble(e.CellValue);
                    if (Balance < 0)
                    {
                        Balance = Balance * -1;
                        e.Cell.ForeColor = Color.Red;
                        e.Cell.Text = Balance.ToString("0.000");
                        e.Cell.Font.Underline = true;
                        e.Cell.Font.Bold = true;
                    }
                    else
                    {
                        e.Cell.Text = Balance.ToString("0.000");
                        e.Cell.Font.Bold = true;
                    }
                }
                catch 
                {

                }
            }
        }
        protected void trlchartExporter_RenderBrick(object sender, ASPxTreeListExportRenderBrickEventArgs e)
        {
            if (e.RowKind == TreeListRowKind.Data && e.Column != null)
            {
                if (e.Column.FieldName == "balance")
                {
                    try
                    {
                        double balance = Convert.ToDouble(e.Text);
                        if (balance < 0)
                        {
                            balance = balance * -1;
                            e.Text = balance.ToString("0.000");
                            e.BrickStyle.ForeColor = Color.Red;
                        }
                        else
                        {
                            e.Text = balance.ToString("0.000");
                        }
                    }
                    catch 
                    {

                    }
                }
            }
        }
        protected void ASPxPopupMenu1_ItemClick(object source, DevExpress.Web.MenuItemEventArgs e)
        {
            if (e.Item.Name == "primary")
            {
                clear();
                txt_chartcode.Focus();
            }
            else if (e.Item.Name == "child")
            {
                var currentnode = trlchart.FocusedNode;
                if (EmaxGlobals.NullToEmpty(currentnode["chartcode"]) != "")
                {
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("chartid", Convert.ToInt32(currentnode["chartid"]));
                    var f = SqlCommandHelper.ExcecuteToDataTable("gl_chart_sel_nodeid_tree", dict).dataTable;
                    BindData(f.Rows[0]);
                }
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "NodeValidate()", true);
                if (Convert.ToInt32(hf_sys_chartlvl.Value) < Convert.ToInt32(cmb_levelno.SelectedItem.Value.ToString()))
                {
                    clear();
                    string msg = "لا يمكن إنشاء حساب تابع .. الحساب سيتعدى مستويات الشجرة";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + msg + ")", true);
                }
                else if (hf_sys_chartlvl.Value == cmb_levelno.Value.ToString())
                {
                    lblfinallevel.Text = "(حساب نهائي)";
                    cmb_accnature.Enabled = true;
                }
                else
                {
                    lblfinallevel.Text = "";
                    cmb_accnature.SelectedIndex = -1;
                    cmb_accnature.Enabled = false;
                }
                txt_chartcode.Focus();
            }
        }

        protected void btn_attach_Click(object sender, EventArgs e)
        {

            try
            {

                if (!Directory.Exists(Server.MapPath("~/Files/Gl/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Files/Gl/"));
                }
                //Upload and save the file
                string excelPath = Server.MapPath("~/Files/gl/") + Path.GetFileName(FileUpload2.PostedFile.FileName);
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
                    SqlCommandHelper.ExecuteNonQuery("gl_chart_excel_del", dict, true);
                    using (SqlConnection con = new SqlConnection(consString))
                    {

                        using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                        {
                            //Set the database table name
                            sqlBulkCopy.DestinationTableName = "dbo.gl_chart_excel";

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
                List<object> MasterParam()
                {
                    
                        return new List<object> {  hf_nodeid, cmb_acctype, cmb_levelno,hf_chartid };
                   
                }
                var res = SaveData( "gl_chart_excel_ins" , MasterParam(), null, null, true, false,
               new List<ParamObject>() { new ParamObject() { ParamName = "acctypename", ParamValue = cmb_acctype }
                //,new ParamObject() { ParamName = "accnaturename", ParamValue = cmb_accnature }
                ,new ParamObject() { ParamName = "levelnoname", ParamValue = cmb_levelno } });
                //var res = SaveData("gl_chart_excel_ins", null, null, null, true, false, null, null);
                if (res.errorid == 0)
                {

                    trlchart.DataBind();

                }
                else
                {

                    string msg = HttpUtility.JavaScriptStringEncode(res.errormsg);

                    //ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('" + msg + "')", true);

                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
                    trlchart.DataBind();

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