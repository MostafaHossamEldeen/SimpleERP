using DevExpress.Web;
using Emax.Core.Utility;
using Emax.Dal;
using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.GL
{
    public partial class AccBranchs : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "37";
            IndexStored = "";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "1,sys_branch", "branchid", "branchname");
                cmb_branchid.SelectedIndex = -1;
            }
            var dict = new Dictionary<object, object>();
            dict.Add("legertype", "1");
           // cmbbchartid = Util.GenerateGridViewCmb(gv_accbranchs, "gl_chart_sel_pop", "bchartid", "chartname", "chartid", "اختر", dict);
            gv_accbranchs.DataBind();
        }
        public GridViewDataComboBoxColumn cmbbchartid { get; set; }

        protected void gv_accbranchs_DataBinding(object sender, EventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("branchid", cmb_branchid.Value);
            gv_accbranchs.DataSource = SqlCommandHelper.ExcecuteToDataTable("gl_accbranchs_sel", dict).dataTable;
        }

        protected void gv_accbranchs_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            var updated = e.UpdateValues;
            foreach (var item in updated)
            {
                var g = SqlCommandHelper.ExecuteNonQuery("gl_accbranchs_upd", item.NewValues, true, item.Keys);
                if (g.errorid != 0)
                {
                    throw new Exception(g.errormsg);
                }
                else
                {
                    e.Handled = true;
                    gv_accbranchs.DataBind();
                }
            }
        }

        protected void btn_xlsx_Click(object sender, EventArgs e)
        {
            try
            {
                ASPxGridView grid = gv_accbranchs as ASPxGridView;
                foreach (GridViewDataColumn column in grid.DataColumns)
                {
                    if (column.FieldName == "bchartid")
                    {
                        column.Visible = false;
                        string exptitle;
                        if (cmb_branchid.SelectedItem != null)
                        {
                            exptitle = "الحسابات الرئيسية خاصة فرع  " + cmb_branchid.SelectedItem.Text;
                        }
                        else
                        {
                            exptitle = "الحسابات الرئيسية العامة";
                        }
                        ExportingDevExpressUtil.Export(gv_accbranchsExporter, exptitle, 1, Request.GetOwinContext().Request.User.Identity.Name, gv_accbranchs.GetSelectedFieldValues("abid").Count != 0, false, exptitle);
                        column.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ASPxGridView grid = gv_accbranchs as ASPxGridView;
                foreach (GridViewDataColumn column in grid.DataColumns)
                {
                    if (column.FieldName == "bchartid")
                    {
                        column.Visible = true;
                    }
                }
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void btn_word_Click(object sender, EventArgs e)
        {
            try
            {
                ASPxGridView grid = gv_accbranchs as ASPxGridView;
                foreach (GridViewDataColumn column in grid.DataColumns)
                {
                    if (column.FieldName == "bchartid")
                    {
                        column.Visible = false;
                        string exptitle;
                        if (cmb_branchid.SelectedItem != null)
                        {
                            exptitle = "الحسابات الرئيسية خاصة فرع  " + cmb_branchid.SelectedItem.Text;
                        }
                        else
                        {
                            exptitle = "الحسابات الرئيسية العامة";
                        }
                        ExportingDevExpressUtil.Export(gv_accbranchsExporter, exptitle, 0, Request.GetOwinContext().Request.User.Identity.Name, gv_accbranchs.GetSelectedFieldValues("abid").Count != 0, false, exptitle);
                        column.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ASPxGridView grid = gv_accbranchs as ASPxGridView;
                foreach (GridViewDataColumn column in grid.DataColumns)
                {
                    if (column.FieldName == "bchartid")
                    {
                        column.Visible = true;
                    }
                }
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void btn_pdf_Click(object sender, EventArgs e)
        {
            try
            {
                ASPxGridView grid = gv_accbranchs as ASPxGridView;
                foreach (GridViewDataColumn column in grid.DataColumns)
                {
                    if (column.FieldName == "bchartid")
                    {
                        column.Visible = false;
                        string exptitle;
                        if (cmb_branchid.SelectedItem != null)
                        {
                            exptitle = "الحسابات الرئيسية خاصة فرع  " + cmb_branchid.SelectedItem.Text;
                        }
                        else
                        {
                            exptitle = "الحسابات الرئيسية العامة";
                        }
                        ExportingDevExpressUtil.Export(gv_accbranchsExporter, exptitle, 2, Request.GetOwinContext().Request.User.Identity.Name, gv_accbranchs.GetSelectedFieldValues("abid").Count != 0, false, exptitle);
                        column.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ASPxGridView grid = gv_accbranchs as ASPxGridView;
                foreach (GridViewDataColumn column in grid.DataColumns)
                {
                    if (column.FieldName == "bchartid")
                    {
                        column.Visible = true;
                    }
                }
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                ASPxGridView grid = gv_accbranchs as ASPxGridView;
                foreach (GridViewDataColumn column in grid.DataColumns)
                {
                    if (column.FieldName == "bchartid")
                    {
                        column.Visible = false;
                        string exptitle;
                        if (cmb_branchid.SelectedItem != null)
                        {
                            exptitle = "الحسابات الرئيسية خاصة فرع  " + cmb_branchid.SelectedItem.Text;
                        }
                        else
                        {
                            exptitle = "الحسابات الرئيسية العامة";
                        }
                        ExportingDevExpressUtil.Export(gv_accbranchsExporter, exptitle, 2, Request.GetOwinContext().Request.User.Identity.Name, gv_accbranchs.GetSelectedFieldValues("abid").Count != 0, true, exptitle);
                        column.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                ASPxGridView grid = gv_accbranchs as ASPxGridView;
                foreach (GridViewDataColumn column in grid.DataColumns)
                {
                    if (column.FieldName == "bchartid")
                    {
                        column.Visible = true;
                    }
                }
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }
    }
}