using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VanSales.ReportServices;

namespace VanSales.ReportViewer
{
    public partial class Viewer : EmaxBasepage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
          
            ASPxWebDocumentViewer1.OpenReport((XtraReport)Session["report"]);
        }


      

    }
}