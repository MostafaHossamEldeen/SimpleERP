using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.Report
{
    public partial class Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int inv_id = Convert.ToInt32(Request.QueryString["sinvid"]);
            if (inv_id == 0)
            {
               Response.Redirect("inv.aspx");
            ////    // Create a report instance.
            ////    Inv_Report report = new Inv_Report();

                    ////    // Force the report creation without previously 
                    ////    // requesting the parameter value from end-users.
                    ////    report.RequestParameters = false;

                    ////    // Assign the report to a ReportPrintTool,
                    ////    // to hide the Parameters panel,
                    ////    // and show the report's print preview.
                    ////    ReportPrintTool pt = new ReportPrintTool(report);
                    ////    pt.AutoShowParametersPanel = true;
                    ////    ASPxWebDocumentViewer1.OpenReport(new CachedReportSourceWeb(report));
                    ////    ASPxWebDocumentViewer1.Visible = true;
                    }
                else
            {
                // Create a report instance.
                inv_rep report = new inv_rep();

                // Create a parameter and specify its name.
                DevExpress.XtraReports.Parameters.Parameter param1 = new DevExpress.XtraReports.Parameters.Parameter();
                param1.Name = "invid";

                // Specify other parameter properties.
                
                param1.Type = typeof(System.String);
                param1.Value = inv_id;
               // param1.Description = " Invoice #";
                param1.Visible = true;

                // Add the parameter to the report.
                report.Parameters.Add(param1);

              

                // Specify the report's filter string.
                report.FilterString = "[sinvid] = [?invid]";

                // Force the report creation without previously 
                // requesting the parameter value from end-users.
                report.RequestParameters = false;

                // Show the parameter's value on a Report Header band.
              //  XRLabel flabel = new XRLabel();
               // flabel.DataBindings.Add(new XRBinding(param1, "Text", "Invoice # {0}"));
               // flabel.Text = "From : " + inv_id;
              //  flabel.Location = new System.Drawing.Point(10, 15);
//flabel.Size = new System.Drawing.Size(150, 50);
             
               // ReportHeaderBand reportHeader = new ReportHeaderBand();
               // PageHeaderBand pageHeader = new PageHeaderBand();
               // pageHeader.Controls.Add(flabel);
             //   report.Bands.Add(pageHeader);

                // Assign the report to a ReportPrintTool,
                // to hide the Parameters panel,
                // and show the report's print preview.
                ReportPrintTool pt = new ReportPrintTool(report);
                pt.AutoShowParametersPanel = true;
                ASPxWebDocumentViewer1.OpenReport(new CachedReportSourceWeb(report));
                ASPxWebDocumentViewer1.Visible = true;
            }
        }
    }
}