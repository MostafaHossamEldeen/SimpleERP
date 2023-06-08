using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.ReportViewer
{
    public partial class ViewRep : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var repname = Request.QueryString["p"];
            PdfViewer.PdfData = (byte[])Session["pdf" + repname];
        }
    }
}