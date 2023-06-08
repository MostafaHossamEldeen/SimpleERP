
using DevExpress.XtraReports.UI;
using Emax.CoreCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using VanSales.Models;
using VanSales.ReportServices;
using DevExpress.XtraReports.Parameters;
using Emax.Dal;
using System.ComponentModel;
using Emax.Core;

namespace VanSales
{
    public class  EmaxBaseReport: EmaxBasepage
    {
        [Browsable(true)]
        //public string pageid { get; set; }
        protected override void OnPreInit(EventArgs e)
        {
          //  DevExpress.Web.ASPxWebControl.GlobalTheme = "Aqua";
            base.OnPreInit(e);
        }
         protected Page childpage;
        
        void SetConditionalParam(XtraReport xtraReport,IDictionary<string,object> conditionalparamval)
        {
            foreach (Parameter item in xtraReport.Parameters)
            {
                if (item.Name.Contains("_conditonalparam"))
                {
                    string noramlparamname = item.Name.Replace("_conditonalparam", "");
                    if (conditionalparamval != null && conditionalparamval.ContainsKey(noramlparamname))
                    {
                        item.Value = conditionalparamval[noramlparamname];
                    }


                }
            }
        }
        public void PrintPage(string reportpath, DataTable dt)
        {

            XtraReport xtraReport = new XtraReport();
            xtraReport.LoadLayout(Server.MapPath("/ReportFiles/" + reportpath));
      
                xtraReport.DataSource = dt;// 
           
            ReportDataSet reportDataSet = new ReportDataSet();
            reportDataSet.ReadXml(Server.MapPath("/reportsinfo.xml"));
            var repheadercolumnlst = reportDataSet.RepHeaderColumn.Where(i=>i.RepName+ ".repx"==reportpath.Split('/')[1]).ToList();
            var repheaderrowscount= reportDataSet.ReportHeaderRows.FirstOrDefault(i=>i.RepName+ ".repx" == reportpath.Split('/')[1]);
            AddTablesIntoReport(xtraReport, repheadercolumnlst, repheaderrowscount.RowsCount,repheaderrowscount.ColumnCount);
          
            Session["report"] = xtraReport;
           
            DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(new FilesystemReportStorageWebExtension(this.Context, "/ReportFiles/" + reportpath.Split('/')[0]));
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "printreport", "openviewer()", true);

        }


        public void PrintPage(string reportpath, DataTable dt,IDictionary<string,object> conditionalparamval=null, List<object> conditionalparam = null)
        {

            XtraReport xtraReport = new XtraReport();
            xtraReport.LoadLayout(Server.MapPath("/ReportFiles/" + reportpath));


        
            ReportDataSet reportDataSet = new ReportDataSet();
            reportDataSet.ReadXml(Server.MapPath("/reportsinfo.xml"));
            var repheadercolumnlst = reportDataSet.RepHeaderColumn.Where(i => i.RepName + ".repx" == reportpath.Split('/')[1]).ToList();
            var repheaderrowscount = reportDataSet.ReportHeaderRows.FirstOrDefault(i => i.RepName + ".repx" == reportpath.Split('/')[1]);
            AddTablesIntoReport(xtraReport, repheadercolumnlst, repheaderrowscount.RowsCount, repheaderrowscount.ColumnCount);
             SetConditionalParam(xtraReport, conditionalparamval);
            //xtraReport.AfterPrint += XtraReport_AfterPrint;
            new ReportHelper().CreateReportWithAutoCellWidth(xtraReport);
            Session["report"] = xtraReport;

            DevExpress.XtraReports.Web.Extensions.ReportStorageWebExtension.RegisterExtensionGlobal(new FilesystemReportStorageWebExtension(this.Context, "/ReportFiles/" + reportpath.Split('/')[0]));
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "printreport", "openviewer()", true);

        }

        ////private void XtraReport_AfterPrint(object sender, EventArgs e)
        ////{
        ////    var rep = sender as XtraReport;
        ////    foreach (XRTable item in rep.AllControls<XRTable>())
        ////    {
              
        ////        item.AdjustSize();
        ////    }
        ////}

        public  void AddTablesIntoReport(XtraReport report, List<ReportDataSet.RepHeaderColumnRow> fields,int headerrows,int colcount=4)
        {
      

            XRTable headerTable = GetHeaderTable(fields, headerrows, report.PageWidth - report.Margins.Left - report.Margins.Right,colcount);
     
            ReportHeaderBand pageHeaderBand = report.Bands.GetBandByType(typeof(ReportHeaderBand)) as ReportHeaderBand;

            pageHeaderBand.Controls.Add(headerTable);
      

            pageHeaderBand.HeightF = headerTable.HeightF;
           
        }
        public  XRTable GetHeaderTable(List<ReportDataSet.RepHeaderColumnRow> fields ,int headerrows, float tableSize, int colcount = 4)
        {
            var table = new XRTable();

            table.BeginInit();

            table.LocationF = new DevExpress.Utils.PointFloat(0F, 0F);
            table.Borders = DevExpress.XtraPrinting.BorderSide.None;

           
            float cellSize = tableSize / colcount;
         
            for (int m = 0; m < headerrows; m++)
            {
                var tableRow = new XRTableRow();
                var rowfields=fields.Where(k => k.Rowno == m + 1).ToList();
                for (int i = 0; i < rowfields.Count; i++ )
                {
                    
                    var cell = new XRTableCell()
                    {
                        Text = rowfields[i].Caption + " : " + (rowfields[i].DataType == false ? GetDxObjectValue(rowfields[i].Data) : GetDxObjectValue(rowfields[i].Data)==""?"":Convert.ToDateTime(GetDxObjectValue(rowfields[i].Data)).ToString("yyyy/MM/dd")),// fields[i],,// fields[i],
                        WidthF = cellSize,

                        TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft
                        //  BackColor = System.Drawing.Color.Gray
                    };
                    tableRow.Cells.Add(cell);
                   
                }
             
                table.Rows.Add(tableRow);
            }
          
           


           

            table.AdjustSize();

            table.EndInit();

            return table;
        }

          string GetDxObjectValue(string ctlname)
        {
            var ctl = childpage.Master.FindControl("MainContent").FindControl(ctlname);
            PropertyInfo ctlobj = ctl.GetType().GetProperty("Value");
       
                return EmaxGlobals.NullToEmpty(ctlobj.GetValue(ctl));
         
           
        }
     
    }
}