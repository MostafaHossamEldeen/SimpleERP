using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales
{
    public partial class import_excel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_upload_Click(object sender, EventArgs e)
        {
            //Upload and save the file
            string excelPath = Server.MapPath("~/Files/") + Path.GetFileName(FileUpload1.PostedFile.FileName);
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
                    oda.Fill(dtExcelData);
                }
                excel_con.Close();

                string consString = ConfigurationManager.ConnectionStrings["VanSales"].ConnectionString;
                using (SqlConnection con = new SqlConnection(consString))
                {
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name
                        sqlBulkCopy.DestinationTableName = "dbo.sys_branch";
                        
                        //[OPTIONAL]: Map the Excel columns with that of the database table
                        sqlBulkCopy.ColumnMappings.Add("Name", "branchname");
                        sqlBulkCopy.ColumnMappings.Add("Phone", "branchtel");
                        //  sqlBulkCopy.ColumnMappings.Add("Salary", "Salary");
                      
                        con.Open();
                        sqlBulkCopy.WriteToServer(dtExcelData);
                        con.Close();
                    }
                }
            }
            Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath);
        }
    }
}