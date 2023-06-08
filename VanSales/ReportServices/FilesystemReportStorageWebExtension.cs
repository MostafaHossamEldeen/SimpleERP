using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.XtraReports.UI;
using System.IO;

namespace VanSales.ReportServices
{
   
        public class FilesystemReportStorageWebExtension : DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension
        {
            HttpContext _context;

            public  string STORAGE_FOLDER_PATH = @"~\ReportFiles\";

            public FilesystemReportStorageWebExtension(HttpContext context,string reportstorage="")
            {
            STORAGE_FOLDER_PATH = reportstorage;
                this._context = context;
            }

            public HttpContext Context
            {
                get
                {
                    return _context;
                }
            }

            protected string GetPath(string url)
            {
                if (Path.IsPathRooted(url))
                {
                    return url;
                }

                return Context.Server.MapPath(Path.Combine(STORAGE_FOLDER_PATH, url));
            }

            public override bool CanSetData(string url)
            {
                string filePath = url.EndsWith(".repx") ? GetPath(url) : GetPath(url + ".repx"); 
                return File.Exists(filePath);
            }

            public override byte[] GetData(string url)
            {
                try
                {
                string[] map_path_array = url.Split('\\');
                string filename = map_path_array[map_path_array.Length - 1];
                string filePath = GetPath(filename);
                return File.ReadAllBytes(filePath);
                }
                catch (Exception ex)
                {

                    throw ex; // new FaultException(ex.Message);
                }
            }

            public override Dictionary<string, string> GetUrls()
            {
                string storagePath = Context.Server.MapPath(STORAGE_FOLDER_PATH);

                Dictionary<string, string> urls = new Dictionary<string, string>();
                string[] reportFiles = Directory.GetFiles(storagePath, "*.repx", SearchOption.AllDirectories);
                foreach (string filePath in reportFiles)
                {
                    urls.Add(filePath, filePath.Replace(storagePath, String.Empty));
                }
          
        
            return urls;
            }

            public override bool IsValidUrl(string url)
            {
            
                string filePath =url.EndsWith(".repx")? GetPath(url):   GetPath(url+".repx");
                if (File.Exists(filePath))
                    return true;

                try
                {
                    File.Create(filePath).Close();
                    File.Delete(filePath);
                    return true;
                }
                catch( Exception ex)
                {
                    return false;
                }
            }

            public override void SetData(XtraReport report, string url)
            {
                try
                {
                    string filePath = url.EndsWith(".repx") ? GetPath(url) : GetPath(url + ".repx");
                if (!filePath.Contains(".repx"))
                {

                
                    report.SaveLayoutToXml(filePath+ ".repx");
                }
                else
                {
                    report.SaveLayoutToXml(filePath);
                }
            }
            catch (Exception ex)
                {

                    throw ex;
                }
            }

            public override string SetNewData(XtraReport report, string defaultUrl)
            {
                try
                {
                string filePath = defaultUrl.EndsWith(".repx") ? GetPath(defaultUrl) : GetPath(defaultUrl + ".repx");
                if (!filePath.Contains(".repx"))
                {


                    report.SaveLayoutToXml(filePath + ".repx");
                }
                else
                {
                    report.SaveLayoutToXml(filePath);
                }
                //string filePath = GetPath(defaultUrl);

                //report.SaveLayoutToXml(filePath);
                return filePath;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
