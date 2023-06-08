using DevExpress.Export;
using DevExpress.Printing.ExportHelpers;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Localization;
using System;

namespace Emax.Core.Utility
{
    public class ExportingDevExpressUtil
    {
        public ExportingDevExpressUtil()
        {
           
        }
                
        public static void Export(ASPxGridViewExporter GridViewExporter, string FileName, int ExportToType,string username,bool Exporteselectedonly=false,bool printing=false,string Headr="",string title="")
        {
            if (Exporteselectedonly==true)
            {
                GridViewExporter.ExportSelectedRowsOnly = true;               
            }
           
            PreparingGridColumnsForExport(GridViewExporter);
          
            GridViewExporter.PageHeader.Left = "إسم الشركة" + Environment.NewLine + "نشاط الشركة" + Environment.NewLine;
            GridViewExporter.PageHeader.Font.Size = 14;
            GridViewExporter.PageHeader.Font.Bold = true;
            HeaderTitle = Headr + Environment.NewLine + title;

            GridViewExporter.PageHeader.Center = Headr + Environment.NewLine + title;
            HeaderTitle = Headr + '\n' + title;
            GridViewExporter.PageHeader.Center = Headr;
            XlsExportOptionsEx xlsxExportOptions = new XlsExportOptionsEx();
           
            xlsxExportOptions.CustomizeSheetHeader += XlsxExportOptions_CustomizeSheetHeader;
            //xlsxExportOptions
            // End

            GridViewExporter.PageFooter.Right = "[Date Printed]-[Time Printed]";
                GridViewExporter.PageFooter.Left = "User Name:"+ username;
            PreviewLocalizer loc = new PreviewLocalizer();
            
            string pages = loc.GetLocalizedString(PreviewStringId.PageInfo_PageNumber);
            //char[] arsplit= { 'م', 'ن' };
            //var f=pages.Split(arsplit)[1];
            GridViewExporter.PageFooter.Center = pages;
            //GridViewExporter.PageFooter.Right = "[Time Printed]";

            //}
            GridViewExporter.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
           
            if (ExportToType == 0) GridViewExporter.WriteRtfToResponse(FileName);
            else if (ExportToType == 1)
            {
                GridViewExporter.WriteXlsToResponse(FileName, true,xlsxExportOptions);
            }
            else if (ExportToType == 2)
                if (printing == true) { GridViewExporter.WritePdfToResponse(false,new PdfExportOptions() { ShowPrintDialogOnOpen = true }); }
                else
                {
                    GridViewExporter.WritePdfToResponse(FileName);
                }
        }
         static string HeaderTitle { get; set; }
        private static void XlsxExportOptions_CustomizeSheetHeader(DevExpress.Export.ContextEventArgs e)
        {
            // Create a new row.
            CellObject row = new CellObject();
            // Specify row values.
            row.Value = HeaderTitle;
            // Specify row formatting.
            XlFormattingObject rowFormatting = new XlFormattingObject();
            rowFormatting.Font = new XlCellFont { Bold = true, Size = 14 };
            rowFormatting.Alignment = new DevExpress.Export.Xl.XlCellAlignment { HorizontalAlignment = DevExpress.Export.Xl.XlHorizontalAlignment.Center, VerticalAlignment = DevExpress.Export.Xl.XlVerticalAlignment.Top };
            row.Formatting = rowFormatting;
            // Add the created row to the output document.
            e.ExportContext.AddRow(new[] { row });
            // Add an empty row to the output document.
            e.ExportContext.AddRow();
            // Merge cells of two new rows. 
            e.ExportContext.MergeCells(new DevExpress.Export.Xl.XlCellRange(new DevExpress.Export.Xl.XlCellPosition(0, 0), new DevExpress.Export.Xl.XlCellPosition(5, 1)));
          
        }

        private static string GetImage(string path, int width, int height)
        {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            string newPath = System.IO.Path.Combine(Environment.CurrentDirectory, path);
            System.Drawing.Image img = System.Drawing.Image.FromFile(newPath);
            img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            byte[] bytes = stream.ToArray();
            string str = BitConverter.ToString(bytes, 0).Replace("-", string.Empty);
            string mpic = @"{\pict\pngblip\picw" +
            img.Width.ToString() + @"\pich" + img.Height.ToString() +
            @"\picwgoal" + width.ToString() + @"\pichgoal" + height.ToString() +
            @"\bin " + str + "}";
            return mpic;
        }

        private static void PreparingGridColumnsForExport(DevExpress.Web.ASPxGridViewExporter gvexporter)
        {
            // Hide The Non Viewd In Export Columns
            for (int i = 0; i <= gvexporter.GridView.Columns.Count - 1; i++)
            {
                if (gvexporter.GridView.Columns[i].Visible)
                {
                    if (gvexporter.GridView.Columns[i].Caption == " ")
                    {
                        gvexporter.GridView.Columns[i].Visible = false;
                    }
                    else
                    {
                        System.Web.UI.WebControls.CheckBox chk = (System.Web.UI.WebControls.CheckBox)gvexporter.GridView.FindHeaderTemplateControl(gvexporter.GridView.Columns[i], "chk1");
                        if (chk != null && !chk.Checked)
                        {
                            gvexporter.GridView.Columns[i].Visible = false;
                        }
                    }
                }
            }
            // End Hide The Non Viewd In Export Columns

            // Prepare The Columns Width
            // Constant Parameters (You Musn't Change Their Values)
            int PortraitMaxPoints = 842, LandscapeMaxPoints = 1086,PageLeftMargin = 50, PageRightMargin = 50, PageTopMargin = 50, PageBottomMargin = 50, PortraitMaxColumnsCount = 9;
            // End Inputs Parameters

            gvexporter.Styles.Cell.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
            gvexporter.Styles.Footer.HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center;
            gvexporter.Styles.Title.Font.Size = 16;
            gvexporter.Styles.Header.Font.Size = 12;
            gvexporter.Styles.Footer.Font.Size = 12;
            gvexporter.PaperKind = System.Drawing.Printing.PaperKind.A4;
            gvexporter.TopMargin = PageTopMargin;
            gvexporter.BottomMargin = PageBottomMargin;
            gvexporter.LeftMargin = PageLeftMargin;
            gvexporter.RightMargin = PageRightMargin;

            if (gvexporter.GridView.VisibleColumns.Count > PortraitMaxColumnsCount)
            {
                //gvexporter.Landscape = true;
                gvexporter.MaxColumnWidth = ((LandscapeMaxPoints - (PageLeftMargin + PageRightMargin)) / gvexporter.GridView.VisibleColumns.Count) + 2;
            }
            else
            {
                //PortraitMaxPoints = 1000;
                //PageRightMargin = 350;
                gvexporter.MaxColumnWidth = (PortraitMaxPoints - (PageLeftMargin + PageRightMargin)) / gvexporter.GridView.VisibleColumns.Count + 15; 
            }
            // End Prepare The Columns Width

            // Resort The Shown Column (Right To Left For Arabic Vision)
            int CurrentShownColumnVisibleIndex = 0;
            for (int i = 0; i <= gvexporter.GridView.Columns.Count - 1; i++)
            {
                if (gvexporter.GridView.Columns[i].Visible)
                {
                    gvexporter.GridView.Columns[i].VisibleIndex = CurrentShownColumnVisibleIndex;
                    gvexporter.GridView.Columns[i].ExportWidth = gvexporter.MaxColumnWidth;
                    CurrentShownColumnVisibleIndex++;
                }
            }
            // End Resort The Shown Column (Right To Left For Arabic Vision)
        }
    }
}
