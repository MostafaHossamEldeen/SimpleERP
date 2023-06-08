using DevExpress.Web;
using Emax.Core.Utility;
using Emax.Dal;
using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;

namespace VanSales.Stock
{
    public partial class st_Items_data_balances_report : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "67";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox("st_group_sel", cmb_groupid, "groupid", "groupname");
                cmb_branchid.SelectedIndex = -1;
                cmb_groupid.SelectedIndex = -1;
                rbl_report.SelectedIndex = -1;
            }
        }
        DataTable GvdetailSource_balances_report()
        {
            if (EmaxGlobals.NullToIntZero(rbl_report.Value) == 1)
            {
                gv_stItemdata.Columns["col1"].Visible = false;
                gv_stItemdata.Columns["col1"].Caption = "";
                gv_stItemdata.Columns["col2"].Visible = false;
                gv_stItemdata.Columns["col2"].Caption = "";
            }
            else if (EmaxGlobals.NullToIntZero(rbl_report.Value) == 2)
            {
                gv_stItemdata.Columns["col1"].Visible = true;
                gv_stItemdata.Columns["col1"].Caption = "أقل كمية";
                gv_stItemdata.Columns["col2"].Visible = true;
                gv_stItemdata.Columns["col2"].Caption = "للوصول للحد الأدنى";
            }
            else if (EmaxGlobals.NullToIntZero(rbl_report.Value) == 3)
            {
                gv_stItemdata.Columns["col1"].Visible = true;
                gv_stItemdata.Columns["col1"].Caption = "أقصى كمية";
                gv_stItemdata.Columns["col2"].Visible = true;
                gv_stItemdata.Columns["col2"].Caption = "للوصول للحد الأقصى";
            }
            else if (EmaxGlobals.NullToIntZero(rbl_report.Value) == 4)
            {
                gv_stItemdata.Columns["col1"].Visible = true;
                gv_stItemdata.Columns["col1"].Caption = "التكلفة";
                gv_stItemdata.Columns["col2"].Visible = true;
                gv_stItemdata.Columns["col2"].Caption = "الإجمالي";
            }
            else if (EmaxGlobals.NullToIntZero(rbl_report.Value) == 5)
            {
                gv_stItemdata.Columns["col1"].Visible = true;
                gv_stItemdata.Columns["col1"].Caption = "سعر البيع";
                gv_stItemdata.Columns["col2"].Visible = true;
                gv_stItemdata.Columns["col2"].Caption = "القيمة";
            }
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("report", EmaxGlobals.NullToIntZero(rbl_report.Value));
            dict.Add("branchid", cmb_branchid.Value);
            dict.Add("groupid", cmb_groupid.Value);
            return SqlCommandHelper.ExcecuteToDataTable("st_Items_balances_report", dict, false).dataTable;
        }
        DataTable GvdetailSource_Items_data()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("report", EmaxGlobals.NullToIntZero(rbl_report.Value));
            dict.Add("branchid", cmb_branchid.Value);
            dict.Add("groupid", cmb_groupid.Value);
            return SqlCommandHelper.ExcecuteToDataTable("st_Items_data_report", dict, false).dataTable;
        }
        protected void btn_Review_Click(object sender, EventArgs e)
        {
            if (EmaxGlobals.NullToIntZero(rbl_report.SelectedItem.Value) == 6)
            {
                try
                {
                    gv_stItemdatarepo.Visible = true;
                    gv_stItemdata.Visible = false;
                    gv_stItemdatarepo.DataBind();
                    gv_stItemdatarepo.ExpandAll();
                }
                catch (Exception ex)
                {
                    string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
                }
            }
            else
            {
                try
                {
                    gv_stItemdatarepo.Visible = false;
                    gv_stItemdata.Visible = true;
                    gv_stItemdata.DataBind();
                    gv_stItemdata.ExpandAll();
                }
                catch (Exception ex)
                {
                    string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "alert('" + msg + "')", true);
                }
            }
        }
        string RepoTitle()
        {
            string RepoTitle = "";
            if (EmaxGlobals.NullToIntZero(rbl_report.Value) == 1)
            {
                RepoTitle = "أرصدة الأصناف";
            }
            else if (EmaxGlobals.NullToIntZero(rbl_report.Value) == 2)
            {
                RepoTitle = "أصناف وصلت لحد الطلب";
            }
            else if (EmaxGlobals.NullToIntZero(rbl_report.Value) == 3)
            {
                RepoTitle = "أصناف وصلت للحد الأقصى";
            }
            else if (EmaxGlobals.NullToIntZero(rbl_report.Value) == 4)
            {
                RepoTitle = "أرصدة بالتكلفة";
            }
            else if (EmaxGlobals.NullToIntZero(rbl_report.Value) == 5)
            {
                RepoTitle = "أرصدة بسعر البيع";
            }
            else if (EmaxGlobals.NullToIntZero(rbl_report.Value) == 6)
            {
                RepoTitle = "بيانات الأصناف";
            }
            return RepoTitle;
        }
        protected void btn_print_Click(object sender, EventArgs e)
        {
            if (EmaxGlobals.NullToIntZero(rbl_report.Value) == 1)
            {
                string branchname;
                int cellno = 0;

                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("cell1hide", false);
                dict.Add("cell2hide", false);
                dict.Add("cell3hide", false);
                dict.Add("cell4hide", false);
                dict.Add("cell5hide", false);
                dict.Add("cell6hide", false);
                dict.Add("cell7hide", false);
                dict.Add("cell8hide", false);
                dict.Add("cell9hide", false);
                dict.Add("cell1caption", null);
                dict.Add("cell2caption", null);
                dict.Add("cell3caption", null);
                dict.Add("cell4caption", null);
                dict.Add("cell5caption", null);
                dict.Add("cell6caption", null);
                dict.Add("cell7caption", null);
                dict.Add("cell8caption", null);
                dict.Add("cell9caption", null);
                dict.Add("cell1value", null);
                dict.Add("cell2value", null);
                dict.Add("cell3value", null);
                dict.Add("cell4value", null);
                dict.Add("cell5value", null);
                dict.Add("cell6value", null);
                dict.Add("cell7value", null);
                dict.Add("cell8value", null);
                dict.Add("cell9value", null);

                var s = gv_stItemdata.VisibleRowCount;
                DataTable reptb = new DataTable();
                foreach (GridViewDataColumn item in gv_stItemdata.VisibleColumns)
                {
                    reptb.Columns.Add(item.FieldName);
                    cellno++;
                    dict.Remove("cell" + cellno + "caption");
                    dict.Remove("cell" + cellno + "value");
                    dict.Remove("cell" + cellno + "hide");
                    dict.Add("cell" + cellno + "caption", item.Caption);
                    dict.Add("cell" + cellno + "value", "[" + item.FieldName + "]");
                    dict.Add("cell" + cellno + "hide", true);
                }
                for (int i = 0; i < s; i++)
                {
                    var ggd = gv_stItemdata.GetDataRow(i);
                    reptb.ImportRow(ggd);
                }

                if (cmb_branchid.Value == null)
                {
                    cmb_branchid.Value = 0;
                    cmb_branchid.Text = null;
                }
                if (cmb_branchid.Text == null || cmb_branchid.Text == "")
                {
                    branchname = cmb_branchid.NullText;
                }
                else
                {
                    branchname = cmb_branchid.Text;
                }

                dict.Add("branchname", branchname);
                dict.Add("groupid", cmb_groupid.Text);

                PrintPage("Stock/st_Items_data_balances_report.repx", reptb, dict);
            }
            else if (EmaxGlobals.NullToIntZero(rbl_report.Value) == 2)
            {
                string branchname;
                int cellno = 0;

                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("cell1hide", false);
                dict.Add("cell2hide", false);
                dict.Add("cell3hide", false);
                dict.Add("cell4hide", false);
                dict.Add("cell5hide", false);
                dict.Add("cell6hide", false);
                dict.Add("cell7hide", false);
                dict.Add("cell8hide", false);
                dict.Add("cell9hide", false);
                dict.Add("cell1caption", null);
                dict.Add("cell2caption", null);
                dict.Add("cell3caption", null);
                dict.Add("cell4caption", null);
                dict.Add("cell5caption", null);
                dict.Add("cell6caption", null);
                dict.Add("cell7caption", null);
                dict.Add("cell8caption", null);
                dict.Add("cell9caption", null);
                dict.Add("cell1value", null);
                dict.Add("cell2value", null);
                dict.Add("cell3value", null);
                dict.Add("cell4value", null);
                dict.Add("cell5value", null);
                dict.Add("cell6value", null);
                dict.Add("cell7value", null);
                dict.Add("cell8value", null);
                dict.Add("cell9value", null);

                var s = gv_stItemdata.VisibleRowCount;
                DataTable reptb = new DataTable();
                foreach (GridViewDataColumn item in gv_stItemdata.VisibleColumns)
                {
                    reptb.Columns.Add(item.FieldName);
                    cellno++;
                    dict.Remove("cell" + cellno + "caption");
                    dict.Remove("cell" + cellno + "value");
                    dict.Remove("cell" + cellno + "hide");
                    dict.Add("cell" + cellno + "caption", item.Caption);
                    dict.Add("cell" + cellno + "value", "[" + item.FieldName + "]");
                    dict.Add("cell" + cellno + "hide", true);
                }
                for (int i = 0; i < s; i++)
                {
                    var ggd = gv_stItemdata.GetDataRow(i);
                    reptb.ImportRow(ggd);
                }

                if (cmb_branchid.Value == null)
                {
                    cmb_branchid.Value = 0;
                    cmb_branchid.Text = null;
                }
                if (cmb_branchid.Text == null || cmb_branchid.Text == "")
                {
                    branchname = cmb_branchid.NullText;
                }
                else
                {
                    branchname = cmb_branchid.Text;
                }

                dict.Add("branchname", branchname);
                dict.Add("groupid", cmb_groupid.Text);

                PrintPage("Stock/st_Items_data_balances_report.repx", reptb, dict);
            }
           else if (EmaxGlobals.NullToIntZero(rbl_report.Value) == 3)
            {
                string branchname;
                int cellno = 0;

                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("cell1hide", false);
                dict.Add("cell2hide", false);
                dict.Add("cell3hide", false);
                dict.Add("cell4hide", false);
                dict.Add("cell5hide", false);
                dict.Add("cell6hide", false);
                dict.Add("cell7hide", false);
                dict.Add("cell8hide", false);
                dict.Add("cell9hide", false);
                dict.Add("cell1caption", null);
                dict.Add("cell2caption", null);
                dict.Add("cell3caption", null);
                dict.Add("cell4caption", null);
                dict.Add("cell5caption", null);
                dict.Add("cell6caption", null);
                dict.Add("cell7caption", null);
                dict.Add("cell8caption", null);
                dict.Add("cell9caption", null);
                dict.Add("cell1value", null);
                dict.Add("cell2value", null);
                dict.Add("cell3value", null);
                dict.Add("cell4value", null);
                dict.Add("cell5value", null);
                dict.Add("cell6value", null);
                dict.Add("cell7value", null);
                dict.Add("cell8value", null);
                dict.Add("cell9value", null);

                var s = gv_stItemdata.VisibleRowCount;
                DataTable reptb = new DataTable();
                foreach (GridViewDataColumn item in gv_stItemdata.VisibleColumns)
                {
                    reptb.Columns.Add(item.FieldName);
                    cellno++;
                    dict.Remove("cell" + cellno + "caption");
                    dict.Remove("cell" + cellno + "value");
                    dict.Remove("cell" + cellno + "hide");
                    dict.Add("cell" + cellno + "caption", item.Caption);
                    dict.Add("cell" + cellno + "value", "[" + item.FieldName + "]");
                    dict.Add("cell" + cellno + "hide", true);
                }
                for (int i = 0; i < s; i++)
                {
                    var ggd = gv_stItemdata.GetDataRow(i);
                    reptb.ImportRow(ggd);
                }

                if (cmb_branchid.Value == null)
                {
                    cmb_branchid.Value = 0;
                    cmb_branchid.Text = null;
                }
                if (cmb_branchid.Text == null || cmb_branchid.Text == "")
                {
                    branchname = cmb_branchid.NullText;
                }
                else
                {
                    branchname = cmb_branchid.Text;
                }

                dict.Add("branchname", branchname);
                dict.Add("groupid", cmb_groupid.Text);

                PrintPage("Stock/st_Items_data_balances_report.repx", reptb, dict);
            }
            else if (EmaxGlobals.NullToIntZero(rbl_report.Value) == 4)
            {
                string branchname;
                int cellno = 0;

                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("cell1hide", false);
                dict.Add("cell2hide", false);
                dict.Add("cell3hide", false);
                dict.Add("cell4hide", false);
                dict.Add("cell5hide", false);
                dict.Add("cell6hide", false);
                dict.Add("cell7hide", false);
                dict.Add("cell8hide", false);
                dict.Add("cell9hide", false);
                dict.Add("cell1caption", null);
                dict.Add("cell2caption", null);
                dict.Add("cell3caption", null);
                dict.Add("cell4caption", null);
                dict.Add("cell5caption", null);
                dict.Add("cell6caption", null);
                dict.Add("cell7caption", null);
                dict.Add("cell8caption", null);
                dict.Add("cell9caption", null);
                dict.Add("cell1value", null);
                dict.Add("cell2value", null);
                dict.Add("cell3value", null);
                dict.Add("cell4value", null);
                dict.Add("cell5value", null);
                dict.Add("cell6value", null);
                dict.Add("cell7value", null);
                dict.Add("cell8value", null);
                dict.Add("cell9value", null);

                var s = gv_stItemdata.VisibleRowCount;
                DataTable reptb = new DataTable();
                foreach (GridViewDataColumn item in gv_stItemdata.VisibleColumns)
                {
                    reptb.Columns.Add(item.FieldName);
                    cellno++;
                    dict.Remove("cell" + cellno + "caption");
                    dict.Remove("cell" + cellno + "value");
                    dict.Remove("cell" + cellno + "hide");
                    dict.Add("cell" + cellno + "caption", item.Caption);
                    dict.Add("cell" + cellno + "value", "[" + item.FieldName + "]");
                    dict.Add("cell" + cellno + "hide", true);
                }
                for (int i = 0; i < s; i++)
                {
                    var ggd = gv_stItemdata.GetDataRow(i);
                    reptb.ImportRow(ggd);
                }

                if (cmb_branchid.Value == null)
                {
                    cmb_branchid.Value = 0;
                    cmb_branchid.Text = null;
                }
                if (cmb_branchid.Text == null || cmb_branchid.Text == "")
                {
                    branchname = cmb_branchid.NullText;
                }
                else
                {
                    branchname = cmb_branchid.Text;
                }

                dict.Add("branchname", branchname);
                dict.Add("groupid", cmb_groupid.Text);

                PrintPage("Stock/st_Items_data_balances_report.repx", reptb, dict);
            }
            else if (EmaxGlobals.NullToIntZero(rbl_report.Value) == 5)
            {
                string branchname;
                int cellno = 0;

                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("cell1hide", false);
                dict.Add("cell2hide", false);
                dict.Add("cell3hide", false);
                dict.Add("cell4hide", false);
                dict.Add("cell5hide", false);
                dict.Add("cell6hide", false);
                dict.Add("cell7hide", false);
                dict.Add("cell8hide", false);
                dict.Add("cell9hide", false);
                dict.Add("cell1caption", null);
                dict.Add("cell2caption", null);
                dict.Add("cell3caption", null);
                dict.Add("cell4caption", null);
                dict.Add("cell5caption", null);
                dict.Add("cell6caption", null);
                dict.Add("cell7caption", null);
                dict.Add("cell8caption", null);
                dict.Add("cell9caption", null);
                dict.Add("cell1value", null);
                dict.Add("cell2value", null);
                dict.Add("cell3value", null);
                dict.Add("cell4value", null);
                dict.Add("cell5value", null);
                dict.Add("cell6value", null);
                dict.Add("cell7value", null);
                dict.Add("cell8value", null);
                dict.Add("cell9value", null);

                var s = gv_stItemdata.VisibleRowCount;
                DataTable reptb = new DataTable();
                foreach (GridViewDataColumn item in gv_stItemdata.VisibleColumns)
                {
                    reptb.Columns.Add(item.FieldName);
                    cellno++;
                    dict.Remove("cell" + cellno + "caption");
                    dict.Remove("cell" + cellno + "value");
                    dict.Remove("cell" + cellno + "hide");
                    dict.Add("cell" + cellno + "caption", item.Caption);
                    dict.Add("cell" + cellno + "value", "[" + item.FieldName + "]");
                    dict.Add("cell" + cellno + "hide", true);
                }
                for (int i = 0; i < s; i++)
                {
                    var ggd = gv_stItemdata.GetDataRow(i);
                    reptb.ImportRow(ggd);
                }

                if (cmb_branchid.Value == null)
                {
                    cmb_branchid.Value = 0;
                    cmb_branchid.Text = null;
                }
                if (cmb_branchid.Text == null || cmb_branchid.Text == "")
                {
                    branchname = cmb_branchid.NullText;
                }
                else
                {
                    branchname = cmb_branchid.Text;
                }

                dict.Add("branchname", branchname);
                dict.Add("groupid", cmb_groupid.Text);

                PrintPage("Stock/st_Items_data_balances_report.repx", reptb, dict);
            }
            else if (EmaxGlobals.NullToIntZero(rbl_report.Value) == 6)
            {
                if (gv_stItemdatarepo.VisibleColumns.Count > 8)
                {
                    string error_msg = "لا يمكن طباعة التقرير بأكثر من 8 أعمدة";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                    return;
                }
                else if (gv_stItemdatarepo.VisibleColumns.Count < 1)
                {
                    string error_msg = "لا توجد أي بيانات ليتم طباعة التقرير";
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                    return;
                }
                else
                {
                    string branchname;
                    int cellno = 0;

                    Dictionary<string, object> dict = new Dictionary<string, object>();
                    dict.Add("cell1hide", false);
                    dict.Add("cell2hide", false);
                    dict.Add("cell3hide", false);
                    dict.Add("cell4hide", false);
                    dict.Add("cell5hide", false);
                    dict.Add("cell6hide", false);
                    dict.Add("cell7hide", false);
                    dict.Add("cell8hide", false);
                    dict.Add("cell9hide", false);
                    dict.Add("cell1caption", null);
                    dict.Add("cell2caption", null);
                    dict.Add("cell3caption", null);
                    dict.Add("cell4caption", null);
                    dict.Add("cell5caption", null);
                    dict.Add("cell6caption", null);
                    dict.Add("cell7caption", null);
                    dict.Add("cell8caption", null);
                    dict.Add("cell9caption", null);
                    dict.Add("cell1value", null);
                    dict.Add("cell2value", null);
                    dict.Add("cell3value", null);
                    dict.Add("cell4value", null);
                    dict.Add("cell5value", null);
                    dict.Add("cell6value", null);
                    dict.Add("cell7value", null);
                    dict.Add("cell8value", null);
                    dict.Add("cell9value", null);

                    var s = gv_stItemdatarepo.VisibleRowCount;
                    DataTable reptb = new DataTable();
                    foreach (GridViewDataColumn item in gv_stItemdatarepo.VisibleColumns)
                    {
                        reptb.Columns.Add(item.FieldName);
                        cellno++;
                        dict.Remove("cell" + cellno + "caption");
                        dict.Remove("cell" + cellno + "value");
                        dict.Remove("cell" + cellno + "hide");
                        dict.Add("cell" + cellno + "caption", item.Caption);
                        dict.Add("cell" + cellno + "value", "[" + item.FieldName + "]");
                        dict.Add("cell" + cellno + "hide", true);
                    }
                    for (int i = 0; i < s; i++)
                    {
                        var ggd = gv_stItemdatarepo.GetDataRow(i);
                        reptb.ImportRow(ggd);
                    }

                    if (cmb_branchid.Value == null)
                    {
                        cmb_branchid.Value = 0;
                        cmb_branchid.Text = null;
                    }
                    if (cmb_branchid.Text == null || cmb_branchid.Text == "")
                    {
                        branchname = cmb_branchid.NullText;
                    }
                    else
                    {
                        branchname = cmb_branchid.Text;
                    }

                    dict.Add("branchname", branchname);
                    dict.Add("groupid", cmb_groupid.Text);
                    PrintPage("Stock/st_Items_data_balances_report.repx", reptb, dict);
                }
            }
        }

        

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            cmb_branchid.SelectedIndex = -1;
            cmb_groupid.SelectedIndex = -1;
            rbl_report.SelectedIndex = -1;
            gv_stItemdata.DataBind();
            gv_stItemdata.FilterExpression = "";
            gv_stItemdatarepo.DataBind();
            gv_stItemdatarepo.FilterExpression = "";
            gv_stItemdata.Visible = false;
            gv_stItemdatarepo.Visible = false;
            gv_stItemdata.DataBind();
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            if (EmaxGlobals.NullToIntZero(rbl_report.SelectedItem.Value) == 6)
            {
                try
                {
                    gvempsalaryExporter.GridViewID = "gv_stItemdatarepo";
                    ExportingDevExpressUtil.Export(gvempsalaryExporter, RepoTitle(), 1, Request.GetOwinContext().Request.User.Identity.Name, gv_stItemdatarepo.GetSelectedFieldValues("itemcode").Count != 0, false, RepoTitle());
                }
                catch (Exception ex)
                {
                    string error_msg = ex.Message;
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
                }
            }
            else
            {
                try
                {
                    gvempsalaryExporter.GridViewID = "gv_stItemdata";
                    ExportingDevExpressUtil.Export(gvempsalaryExporter, RepoTitle(), 1, Request.GetOwinContext().Request.User.Identity.Name, gv_stItemdata.GetSelectedFieldValues("itemcode").Count != 0, false, RepoTitle());
                }
                catch (Exception ex)
                {
                    string error_msg = ex.Message;
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
                }
            }
        }

        protected void btn_docexport_Click(object sender, EventArgs e)
        {
            if (EmaxGlobals.NullToIntZero(rbl_report.SelectedItem.Value) == 6)
            {
                try
                {
                    gvempsalaryExporter.GridViewID = "gv_stItemdatarepo";
                    ExportingDevExpressUtil.Export(gvempsalaryExporter, RepoTitle(), 0, Request.GetOwinContext().Request.User.Identity.Name, gv_stItemdatarepo.GetSelectedFieldValues("itemcode").Count != 0, false, RepoTitle());
                }
                catch (Exception ex)
                {
                    string error_msg = ex.Message;
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
                }
            }
            else
            {
                try
                {
                    gvempsalaryExporter.GridViewID = "gv_stItemdata";
                    ExportingDevExpressUtil.Export(gvempsalaryExporter, RepoTitle(), 0, Request.GetOwinContext().Request.User.Identity.Name, gv_stItemdata.GetSelectedFieldValues("itemcode").Count != 0, false, RepoTitle());
                }
                catch (Exception ex)
                {
                    string error_msg = ex.Message;
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
                }
            }
        }

        protected void btn_pdfexport_Click(object sender, EventArgs e)
        {
            if (EmaxGlobals.NullToIntZero(rbl_report.SelectedItem.Value) == 6)
            {
                try
                {
                    gvempsalaryExporter.GridViewID = "gv_stItemdatarepo";
                    ExportingDevExpressUtil.Export(gvempsalaryExporter, RepoTitle(), 2, Request.GetOwinContext().Request.User.Identity.Name, gv_stItemdatarepo.GetSelectedFieldValues("itemcode").Count != 0, false, RepoTitle());
                }
                catch (Exception ex)
                {
                    string error_msg = ex.Message;
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
                }
            }
            else
            {
                try
                {
                    gvempsalaryExporter.GridViewID = "gv_stItemdata";
                    ExportingDevExpressUtil.Export(gvempsalaryExporter, RepoTitle(), 2, Request.GetOwinContext().Request.User.Identity.Name, gv_stItemdata.GetSelectedFieldValues("itemcode").Count != 0, false, RepoTitle());
                }
                catch (Exception ex)
                {
                    string error_msg = ex.Message;
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
                }
            }
        }

        protected void chk_itemcode_CheckedChanged(object sender, EventArgs e)
        {
            var test = sender as ASPxCheckBox;
            string[] coulms = test.ID.Split('_');
            gv_stItemdatarepo.Columns[coulms[1]].Visible = test.Checked;
        }
        private void LoopcheckBoxes()
        {

            foreach (var item in formLayout.Items)
            {
                if (item is LayoutGroupBase)
                    (item as LayoutGroupBase).ForEach(GetNestedControls);
            }
        }
        void GetNestedControls(LayoutItemBase item)
        {
            if (item is LayoutItem)
                SetValue(item as LayoutItem);
        }
        void SetValue(LayoutItem c)
        {
            foreach (Control control in c.Controls)
            {
                ASPxCheckBox editor = control as ASPxCheckBox;
                if (editor != null)
                {
                    editor.Value = chk_all.Value;
                    if (editor.ID != "chk_all")
                    {
                        string[] coulms = editor.ID.Split('_');
                        gv_stItemdatarepo.Columns[coulms[1]].Visible = editor.Checked;
                    }
                }
            }
        }
        protected void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            LoopcheckBoxes();
        }

        protected void gv_stItemdata_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            //ASPxSummaryItem summary = e.Item as ASPxSummaryItem;
            //switch (summary.FieldName)
            //{
            //    case "netbvat":
            //        double netbvat = 0;
            //        netbvat = Convert.ToDouble(gvs_inv.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv.GroupSummary["netbvat"])) - Convert.ToDouble(gvs_inv.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv.GroupSummary["netbvat"]));
            //        e.TotalValue = netbvat;
            //        e.TotalValueReady = true;

            //        break;
            //    case "netavat":
            //        double netavat = 0;
            //        netavat = Convert.ToDouble(gvs_inv.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv.GroupSummary["netavat"])) - Convert.ToDouble(gvs_inv.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv.GroupSummary["netavat"]));
            //        e.TotalValue = netavat;
            //        e.TotalValueReady = true;

            //        break;
            //    case "vatvalue":
            //        double vatvalue = 0;
            //        vatvalue = Convert.ToDouble(gvs_inv.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv.GroupSummary["vatvalue"])) - Convert.ToDouble(gvs_inv.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv.GroupSummary["vatvalue"]));
            //        e.TotalValue = vatvalue;
            //        e.TotalValueReady = true;

            //        break;
            //}
        }

        protected void gv_stItemdata_DataBinding(object sender, EventArgs e)
        {
            gv_stItemdata.DataSource = GvdetailSource_balances_report();
        }

        protected void gv_stItemdatarepo_DataBinding(object sender, EventArgs e)
        {
            gv_stItemdatarepo.DataSource = GvdetailSource_Items_data();
        }

        protected void gv_stItemdatarepo_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {
            //ASPxSummaryItem summary = e.Item as ASPxSummaryItem;
            //switch (summary.FieldName)
            //{
            //    case "netbvat":
            //        double netbvat = 0;
            //        netbvat = Convert.ToDouble(gvs_inv.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv.GroupSummary["netbvat"])) - Convert.ToDouble(gvs_inv.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv.GroupSummary["netbvat"]));
            //        e.TotalValue = netbvat;
            //        e.TotalValueReady = true;

            //        break;
            //    case "netavat":
            //        double netavat = 0;
            //        netavat = Convert.ToDouble(gvs_inv.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv.GroupSummary["netavat"])) - Convert.ToDouble(gvs_inv.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv.GroupSummary["netavat"]));
            //        e.TotalValue = netavat;
            //        e.TotalValueReady = true;

            //        break;
            //    case "vatvalue":
            //        double vatvalue = 0;
            //        vatvalue = Convert.ToDouble(gvs_inv.GetGroupSummaryValue(0, (ASPxSummaryItem)gvs_inv.GroupSummary["vatvalue"])) - Convert.ToDouble(gvs_inv.GetGroupSummaryValue(1, (ASPxSummaryItem)gvs_inv.GroupSummary["vatvalue"]));
            //        e.TotalValue = vatvalue;
            //        e.TotalValueReady = true;

            //        break;
            //}
        }
    }
}