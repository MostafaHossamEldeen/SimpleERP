using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VanSales.Models;

namespace VanSales.ReportDesginer
{
    public partial class ReportPramaterSet : System.Web.UI.Page
    {
        ReportDataSet ds;
        protected void Page_Load(object sender, EventArgs e)
        {
           ds= new ReportDataSet(); ds.ReadXml(Server.MapPath("/ReportsInfo.xml"));
            if (!IsPostBack)
            {
                gv_reports.DataBind();
            
               // DetailsView1.DataBind();
            }
        }

        protected void gv_reports_DataBinding(object sender, EventArgs e)
        {
            gv_reports.DataSource = GetTable();
        }

        DataTable GetTable()
        {
            ReportDataSet ds = new ReportDataSet();
            ds.ReadXml(Server.MapPath("/ReportsInfo.xml"));
            return ds.ReportHeaderRows;
        }
        protected void gv_reports_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
           
        }

        protected void DetailsView1_DataBinding(object sender, EventArgs e)
        {
           
        }
        List<ReportDataSet.RepHeaderColumnRow> grdsource;

        void BindDeatailGrdi(string repname)
        {


            grdsource= ds.RepHeaderColumn.Where(i => i.RepName == repname).ToList();
         
     
        }
        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
       

               ASPxGridView1.DataSource = grdsource;
        }

        protected void ASPxGridView1_SelectionChanged(object sender, EventArgs e)
        {
           var repname= gv_reports.GetSelectedFieldValues(new string[] { "repname" }).Count!=0? gv_reports.GetSelectedFieldValues(new string[] { "RepName" })[0]:null;
            if (repname!=null)
            {
                BindDeatailGrdi(repname==null?"":repname.ToString());
                ASPxGridView1.DataBind();
            }
        }
    }
}