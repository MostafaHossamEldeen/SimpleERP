using DevExpress.Web;
using DevExpress.XtraPrinting;
using System;

namespace Emax.SharedLib.Utility
{
    public class ExportingDevExpressUtil
    {
        public ExportingDevExpressUtil()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        
        public static void Export(ASPxGridViewExporter GridViewExporter, string FileName, int ExportToType,string username,bool Exporteselectedonly=false,bool printing=false)
        {

            if (Exporteselectedonly==true)
            {
                GridViewExporter.ExportSelectedRowsOnly = true;
            }
           
            PreparingGridColumnsForExport(GridViewExporter);
            //if (ExportToType == 0)
            //{
                // All Center
                //            GridViewExporter.ReportHeader = @"{\rtf1\fbidis\ansi\ansicpg1256\deff0\deflang1025{\fonttbl{\f0\fnil\fcharset0 Times New Roman;}{\f1\fnil\fcharset178{\*\fname Times New Roman;}Times New Roman (Arabic);}}
                //        \viewkind4\uc1\pard\ltrpar\qc\lang1033\f0\fs20 " + GetImage(System.Web.HttpContext.Current.Server.MapPath(@"~\image\logo2.png"), 1200, 1200) + @"\lang3073\f1\rtlch\par
                //        \b\fs24\'c7\'e1\'e3\'e3\'e1\'df\'c9 \'c7\'e1\'da\'d1\'c8\'ed\'c9 \'c7\'e1\'d3\'da\'e6\'cf\'ed\'c9\par
                //        \'e6\'d2\'c7\'d1\'c9 \'c7\'e1\'cf\'c7\'ce\'e1\'ed\'c9\par
                //        \'de\'e6\'c7\'ca \'c3\'e3\'e4 \'c7\'e1\'e3\'e4\'d4\'c3\'ca\par
                //        \'c7\'cf\'c7\'d1\'c9 \'c7\'e1\'ca\'d3\'cc\'ed\'e1 \'e6\'c7\'e1\'de\'c8\'e6\'e1\par
                //        \lang1025\f0\ltrch\par}";
                // End

                // Header Text Rigth And Left ,, Image Center
            //    GridViewExporter.ReportHeader = @"{\rtf1\fbidis\ansi\ansicpg1256\deff0\deflang1025{\fonttbl{\f0\fnil\fcharset0 Times New Roman;}}
            //\viewkind4\uc1\pard\ltrpar\qc\lang1033\f0\fs20 " + GetImage(System.Web.HttpContext.Current.Server.MapPath(@"~\image\logo2.png"), 1200, 1200) + @"\lang1025\par}";
                //GridViewExporter.PageHeader.Right = "المملكة العربية السعودية" + Environment.NewLine + "وزارة الداخلية";
                //GridViewExporter.PageHeader.Left = "قوات أمن المنشأت" + Environment.NewLine + "ادارة القبول";
                GridViewExporter.PageHeader.Font.Size = 14;
                GridViewExporter.PageHeader.Font.Bold = true;
                // End

                GridViewExporter.PageFooter.Right = "[Date Printed]-[Time Printed]";
                GridViewExporter.PageFooter.Left = "User Name:"+username;
            //GridViewExporter.PageFooter.Right = "[Time Printed]";
           
            //}
             GridViewExporter.RightToLeft = DevExpress.Utils.DefaultBoolean.True;
           
            if (ExportToType == 0) GridViewExporter.WriteRtfToResponse(FileName);
            else if (ExportToType == 1)
            {
                GridViewExporter.WriteXlsToResponse(FileName);
            }
            else if (ExportToType == 2)
                if (printing == true) { GridViewExporter.WritePdfToResponse(false,new PdfExportOptions() { ShowPrintDialogOnOpen = true }); }
                else
                {
                    GridViewExporter.WritePdfToResponse(FileName);
                }
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
            int PortraitMaxPoints = 754, LandscapeMaxPoints = 1086,
            // End Constant Parameters (You Musn't Change Their Values)

            // Inputs Parameters
            PageLeftMargin = 0, PageRightMargin = 0, PageTopMargin = 30, PageBottomMargin = 30, PortraitMaxColumnsCount = 9;
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
                gvexporter.Landscape = true;
                gvexporter.MaxColumnWidth = (LandscapeMaxPoints - (PageLeftMargin + PageRightMargin)) / gvexporter.GridView.VisibleColumns.Count;
            }
            else gvexporter.MaxColumnWidth = (PortraitMaxPoints - (PageLeftMargin + PageRightMargin)) / gvexporter.GridView.VisibleColumns.Count;
            // End Prepare The Columns Width

            // Resort The Shown Column (Right To Left For Arabic Vision)
            int CurrentShownColumnVisibleIndex = 0;
            for (int i = gvexporter.GridView.Columns.Count - 1; i >= 0; i--)
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
