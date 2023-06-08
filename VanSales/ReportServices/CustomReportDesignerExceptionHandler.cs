using System;
using System.IO;
//using System.ServiceModel;
using DevExpress.XtraReports.Web.ReportDesigner.Services;

namespace VanSales.ReportServices
{
    public class CustomReportDesignerExceptionHandler : ReportDesignerExceptionHandler {
        public override string GetUnknownExceptionMessage(Exception ex) {
            if (ex is FileNotFoundException) {
#if DEBUG
                return "Debug mode. " + ex.Message + ".";
#else
                return "File is not found.";
#endif
            }

            return ex.GetType().Name + " occurred. See the log file for more details.";
        }

        //public override string GetFaultExceptionMessage(FaultException ex) {
        //    return "FaultException occurred: " + ex.Message + ".";
        //}
    }
}