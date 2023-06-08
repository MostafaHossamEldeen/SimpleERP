using System;
using VanSales.Report;

namespace VanSales
{
    public partial class ReportDesigner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            inv_rep report = new inv_rep();
            ASPxReportDesigner.OpenReport(report);
        }
    }
}