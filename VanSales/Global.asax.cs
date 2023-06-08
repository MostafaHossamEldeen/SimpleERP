using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Http;
using DevExpress.Web;
using DevExpress.Security.Resources;
using DevExpress.XtraReports.Web.WebDocumentViewer;
using VanSales.ReportServices;

namespace VanSales
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Application["TotalOnlineUsers"] = 0;
            ASPxWebControl.BackwardCompatibility.DataControlAllowReadUnlistedFieldsFromClientApiDefaultValue = true;

            DevExpress.XtraReports.Web.ReportDesigner.DefaultReportDesignerContainer.RegisterDataSourceWizardConfigFileConnectionStringsProvider();
            DevExpress.XtraReports.Web.WebDocumentViewer.DefaultWebDocumentViewerContainer.Register<IWebDocumentViewerExceptionHandler, CustomWebDocumentViewerExceptionHandler>();
            DefaultWebDocumentViewerContainer.UseCachedReportSourceBuilder();
            DevExpress.XtraReports.Web.ASPxReportDesigner.StaticInitialize();
            string path = Server.MapPath("Img");
            AccessSettings.StaticResources.TrySetRules(DirectoryAccessRule.Allow(path));
            DevExpress.XtraReports.Web.ASPxWebDocumentViewer.StaticInitialize();

            //DevExpress.Web.ASPxWebControl.CallbackError += Callback_Error;
        }
        //protected void Callback_Error(object sender, EventArgs e)
        //{
        //    var exception = HttpContext.Current.Server.GetLastError();
        //    //Check exception type and specify error text for your exception
           
        //        DevExpress.Web.ASPxWebControl.SetCallbackErrorMessage(exception.Message);
            
        //}
            void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown  

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs  

        }
        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started  
            Application.Lock();
            Application["TotalOnlineUsers"] = (int)Application["TotalOnlineUsers"] + 1;
            Application.UnLock();
        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends.   
            // Note: The Session_End event is raised only when the sessionstate mode  
            // is set to InProc in the Web.config file. If session mode is set to StateServer   
            // or SQLServer, the event is not raised.  
            Application.Lock();
            Application["TotalOnlineUsers"] = (int)Application["TotalOnlineUsers"] - 1;
            Application.UnLock();
        }
    }
}