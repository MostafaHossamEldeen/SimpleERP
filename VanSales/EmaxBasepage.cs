using DevExpress.Web;
using DevExpress.XtraReports.UI;
using Emax.Dal;
using Emax.SharedLib;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using VanSales.DBClass;
using VanSales.Models;
using VanSales.ReportServices;

namespace VanSales
{
    public class EmaxBasepage:System.Web.UI.Page
    {
        [Browsable(true)]
        public string pageid { get; set; }
        [Browsable(true)]
        public string IndexStored { get; set; }
        [Browsable(true)]
        public DataTable IndexDataTable
        {
            get
            {
                var exres = SqlCommandHelper.ExcecuteToDataTable(IndexStored);
                return exres.dataTable;
            }
        }
        [Browsable(true)]
        public string ReportPath { get; set; }

        // void AddReportPathToCookies()
        //{
        //    HttpCookie cookie = new HttpCookie("Reports");


        //    if (HttpContext.Current != null)
        //    {
        //        if (ReportPath.Length == 0)
        //        {
        //            cookie.Values.Add("report_path", "");
        //        }
        //        else
        //        {
        //            cookie.Values.Add("report_path", ReportPath);
        //        }

        //        // cookie.Values.Add("branchid", EmaxGlobals.NullToEmpty(token.branchid));
        //        cookie.Expires = DateTime.Now.AddDays(1);
        //        HttpContext.Current.Response.Cookies.Add(cookie);

        //    }
        //}
        public void PrintPage(string reportpath, DataTable dt, Dictionary<string, object> paramval=null)
        {

            XtraReport xtraReport = new XtraReport();
            xtraReport.LoadLayout(Server.MapPath("/ReportFiles/" + reportpath));
            foreach (KeyValuePair<string, object> item in paramval)
            {
                xtraReport.Parameters[item.Key].Value = item.Value;
            }
            xtraReport.DataSource = dt;// 

            //ReportDataSet reportDataSet = new ReportDataSet();
            //reportDataSet.ReadXml(Server.MapPath("/reportsinfo.xml"));
            //var repheadercolumnlst = reportDataSet.RepHeaderColumn.Where(i => i.RepName + ".repx" == reportpath.Split('/')[1]).ToList();
            //var repheaderrowscount = reportDataSet.ReportHeaderRows.FirstOrDefault(i => i.RepName + ".repx" == reportpath.Split('/')[1]);
            //AddTablesIntoReport(xtraReport, repheadercolumnlst, repheaderrowscount.RowsCount, repheaderrowscount.ColumnCount);
            Session["report"] = xtraReport;

            DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(new FilesystemReportStorageWebExtension(this.Context, "/ReportFiles/" + reportpath.Split('/')[0]));
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "printreport", "openviewer()", true);
        }
            public void PrintPage(string reportpath,Dictionary<string,object> paramval)
        {
            ReportPath =reportpath;
            XtraReport xtraReport = new XtraReport();
           
            xtraReport.LoadLayout(Server.MapPath("/ReportFiles/" + reportpath));
            foreach (KeyValuePair<string,object> item in paramval)
            {
                xtraReport.Parameters[item.Key].Value = item.Value;
            }
     
            Session["report"] = xtraReport;
            DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(new FilesystemReportStorageWebExtension(this.Context, "/ReportFiles/" + ReportPath.Split('/')[0]));
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "printreport", "openviewer()", true);

        }
        public void PrintPageDirect(string reportpath, Dictionary<string, object> paramval,int printcount=1)
        {
            ReportPath = reportpath;
            XtraReport xtraReport = new XtraReport();
            xtraReport.LoadLayout(Server.MapPath("/ReportFiles/" + reportpath));
            foreach (KeyValuePair<string, object> item in paramval)
            {
                xtraReport.Parameters[item.Key].Value = item.Value;
            }
            for (int i = 0; i < printcount; i++)
            {
                xtraReport.Print();
            }
           
          

        }
        public bool ValidateData(List<object> nullval=null, List<object> zeroval=null)
        {
           
            if (zeroval!=null && nullval == null)
            {
                return EmaxGlobals.ValidateZeroValue(zeroval);
            }
            else if(nullval!=null && zeroval==null)
            {

                return EmaxGlobals.ValidateNullValue(nullval);
            }
            else
            {
                return (EmaxGlobals.ValidateNullValue(nullval) && EmaxGlobals.ValidateZeroValue(zeroval));
            }
         
        }
        public virtual StoredExecuteResulte UpdateData(string spname, List<object> parametersdict = null, List<object> parametersdicttext = null
            ,bool deafultparam=false, bool fireerrormsg = false)
            
        {

            return null; //SqlCommandHelper.ExecuteNonQuery(spname, parametersdict,null, deafultparam,fireerrormsg, parametersdicttext);
        }
        public virtual StoredExecuteResulte SaveData(string spname, List<object> parametersdict = null, Dictionary<object,object> parametersdictupd=null, List<string> outputparam = null, bool fireerrormsg = false, bool defaultparam = false
            , List<ParamObject> ctltext = null, Dictionary<object,object> otherparam = null)

        {

           var res= SqlCommandHelper.ExecuteNonQueryDefault( spname, parametersdict,  parametersdictupd,  outputparam,  fireerrormsg , defaultparam 
            ,ctltext,  otherparam);
            if (res.errormsg.Length != 0 && res.errorid==0)
            {
                
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
        
            }
            else if (res.errormsg.Length != 0 && res.errorid != 0)
            {
                string resultmsg = res.errormsg.Replace("'", "");

                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + resultmsg + "');", true);
        
           }  
            
            return res;
        }

        public Dictionary<string,object> BindControls { get; set; }
        protected override void OnInit(EventArgs e)
        {

            //if (pageid!=null)
            //{
             
          
            //SqlConnection sqlconnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Vansales"].ConnectionString);
            //SqlCommand sqlCommand = new SqlCommand();
            //sqlCommand.Connection = sqlconnection;
            //sqlconnection.Open();
            //sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            //sqlCommand.CommandText = "sys_urpages_sel_username";
            //sqlCommand.Parameters.AddWithValue("@pageid",EmaxGlobals.NullToIntZero( pageid));
            //sqlCommand.Parameters.AddWithValue("@UserName", Context.User.Identity.Name);
            //var haspermission = ((int)sqlCommand.ExecuteScalar() != 0);
            //if (!haspermission)
            //{
            //    Response.Redirect("~/NotAuthorize");
            //}
            //}
            base.OnInit(e); 
        }
        protected  override void OnLoad(EventArgs e)
        {
            if (!HttpContext.Current.Request.Cookies.AllKeys.Contains("Token") || EmaxGlobals.NullToEmpty(HttpContext.Current.Request.Cookies["Token"].Value) == "")
            {
                Response.Redirect("~/logout");
            }
            //AddReportPathToCookies();
            base.OnLoad(e);
         


        }
  
  


    }
}