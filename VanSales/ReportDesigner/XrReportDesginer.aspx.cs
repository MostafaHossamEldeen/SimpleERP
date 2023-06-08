using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VanSales.ReportServices;

namespace VanSales.ReportDesginer
{
    public partial class XrReportDesginer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["storagepath"]!=null)
            {
                DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(new FilesystemReportStorageWebExtension(this.Context, Session["storagepath"].ToString()));

                ASPxReportDesigner1.OpenReport(new DevExpress.XtraReports.UI.XtraReport());
            }
          
          
        }
    }
}