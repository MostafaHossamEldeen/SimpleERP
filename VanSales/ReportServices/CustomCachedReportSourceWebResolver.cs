using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.Web;
using DevExpress.XtraReports.Web.WebDocumentViewer;

namespace VanSales.ReportServices
{
    public class CustomCachedReportSourceWebResolver : ICachedReportSourceWebResolver
    {
        IWebDocumentViewerReportResolver reportResolver;
        public CustomCachedReportSourceWebResolver(IWebDocumentViewerReportResolver reportResolver) {
            this.reportResolver = reportResolver;
        }
        public bool TryGetCachedReportSourceWeb(string reportName, out CachedReportSourceWeb cachedReportSourceWeb) {
            var report = reportResolver.Resolve(reportName);
            if (report != null) {
                cachedReportSourceWeb = new CachedReportSourceWeb(report);
                return true;
            }
            cachedReportSourceWeb = null;
            return false;
        }
    }
}