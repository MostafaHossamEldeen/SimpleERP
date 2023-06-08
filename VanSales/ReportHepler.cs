using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Native;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;

namespace VanSales
{


        public class ReportHelper
        {
            private const float additionalCellSpace = 3;
            private static Dictionary<XRControl, float> cellColumnWidthCollection = new Dictionary<XRControl, float>();
            public DevExpress.XtraReports.UI.XtraReport CreateReportWithAutoCellWidth(DevExpress.XtraReports.UI.XtraReport report)
            {
                InitializeReport(report);
                CreateDocument(report);
                FillColumnCellWidthCollection(report);
                ApplyNewWidthToReportCells(report);
                CreateDocument(report);
                return report;
            }
            private void CreateDocument(XtraReport report)
            {
                report.CreateDocument();
            }
            private void InitializeReport(XtraReport targetReport)
            {
                targetReport.PaperKind = PaperKind.Custom;
                targetReport.ReportUnit = ReportUnit.Pixels;
                targetReport.PageWidth = 3000;
                targetReport.RollPaper = true;
            }
            private void ApplyNewWidthToReportCells(DevExpress.XtraReports.UI.XtraReport report)
            {
                IList<KeyValuePair<XRTable, List<XRTable>>> tables = FindTables(report);
                foreach (var table in tables)
                {
                    float totalWidth = 0;
                    foreach (XRTableCell dc in table.Key.Rows[0].Cells)
                    {
                        float newWidth = cellColumnWidthCollection[dc];
                        foreach (var otherTable in table.Value)
                        {
                            newWidth = Math.Max(newWidth, cellColumnWidthCollection[otherTable.Rows[0].Cells[dc.Index]]);
                        }
                        newWidth += additionalCellSpace;
                        totalWidth += newWidth;
                    }
                    table.Key.WidthF = totalWidth;
                    foreach (var otherTable in table.Value)
                    {
                        otherTable.WidthF = totalWidth;
                    }
                    table.Key.BeginInit();
                    foreach (var otherTable in table.Value)
                    {
                        otherTable.BeginInit();
                    }
                    foreach (XRTableCell dc in table.Key.Rows[0].Cells)
                    {
                        float newWidth = cellColumnWidthCollection[dc];
                        foreach (var otherTable in table.Value)
                        {
                            newWidth = Math.Max(newWidth, cellColumnWidthCollection[otherTable.Rows[0].Cells[dc.Index]]);
                        }
                        newWidth += additionalCellSpace;
                        dc.WidthF = newWidth;
                        foreach (var otherTable in table.Value)
                        {
                            otherTable.Rows[0].Cells[dc.Index].WidthF = newWidth;
                        }
                    }
                    table.Key.EndInit();
                    foreach (var otherTable in table.Value)
                    {
                        otherTable.EndInit();
                    }
                }
            }

            private IList<KeyValuePair<XRTable, List<XRTable>>> FindTables(DevExpress.XtraReports.UI.XtraReport xtraReport)
            {
                var result = new List<KeyValuePair<XRTable, List<XRTable>>>();
                IEnumerable<XRTable> allTables = xtraReport.AllControls<XRTable>().Where(t => t.Visible);
                foreach (var table in allTables)
                {
                    var subResult = new List<XRTable>();
                    XRTableCellCollection dataCells = table.Rows[0].Cells;

                    bool match = true;
                    IEnumerable<XRTable> candidates = allTables.Where(t => t.Visible && t != table);
                    foreach (var candidate in candidates)
                    {
                        if (candidate.Rows[0].Cells.Count == dataCells.Count)
                        {
                            XRTableCellCollection cells = candidate.Rows[0].Cells;
                            for (int i = 0; i < cells.Count; i++)
                            {
                                match &= FloatComparer.Compare(dataCells[i].WidthF, candidate.Rows[0].Cells[i].WidthF, 5) == 0;
                            }
                            if (match)
                            {
                                subResult.Add(candidate);
                            }
                        }
                    }
                    result.Add(new KeyValuePair<XRTable, List<XRTable>>(table, subResult));
                }
                return result;
            }

            private void FillColumnCellWidthCollection(DevExpress.XtraReports.UI.XtraReport currentReport)
            {
                foreach (PSPage page in currentReport.Pages)
                {
                    NestedBrickIterator iterator = new NestedBrickIterator(page.InnerBricks);
                    while (iterator.MoveNext())
                    {
                        if (iterator.CurrentBrick is VisualBrick && ((VisualBrick)iterator.CurrentBrick).BrickOwner is XRTableCell)
                        {
                            XRTableCell cell = ((VisualBrick)iterator.CurrentBrick).BrickOwner as XRTableCell;
                            string currentCellText = ((VisualBrick)iterator.CurrentBrick).Text;
                            float bestCellWidthForProvidedText = BestSizeEstimator.GetBoundsToFitText(currentCellText, ((VisualBrick)iterator.CurrentBrick).Style, currentReport.ReportUnit).Width;
                            if (!cellColumnWidthCollection.ContainsKey(cell))
                            {
                                cellColumnWidthCollection.Add(cell, bestCellWidthForProvidedText);
                            }
                            else
                            {
                                float value = cellColumnWidthCollection[cell];
                                if (bestCellWidthForProvidedText > value)
                                {
                                    cellColumnWidthCollection[cell] = bestCellWidthForProvidedText;
                                }
                            }
                        }
                    }
                }
            }
        }
   

}