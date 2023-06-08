using DevExpress.Web;
using Emax.Core.Utility;
using Emax.Dal;
using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;

namespace VanSales.GL
{
    public partial class RepMainTrailBalance : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "70";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_levelno, "compid,table_name", "13,levelno", "citemid", "citemname");
                Session["dtrep"] = null;
            }
        }

        protected void ASPxButton1_Click(object sender, EventArgs e)
        {
            ASPxGridView1.DataBind();
        }

        protected void ASPxGridView1_DataBinding(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["dtrep"];
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("dtefrom", dtefrom.Value);
            dict.Add("dteto", dteto.Value);
            dict.Add("levelno", cmb_levelno.Value);
            dict.Add("balancestat", cmb_balance.Value);
            dt= SqlCommandHelper.ExcecuteToDataTable("trail_balance", dict).dataTable;
            ASPxGridView1.DataSource = dt;
        }

        protected void ASPxGridView1_AfterPerformCallback(object sender, DevExpress.Web.ASPxGridViewAfterPerformCallbackEventArgs e)
        {

        }

        protected void ASPxButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("dtefrom", dtefrom.Value);
                dict.Add("dteto", dteto.Value);
                dict.Add("levelno", cmb_levelno.Value);
                dict.Add("balancestat", cmb_balance.Value);
                dict.Add("levelname", cmb_levelno.Text);
                dict.Add("balancestatname", cmb_balance.Text);
                PrintPage("GL/main_trail_balance.repx", dict);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void ASPxGridView1_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            ASPxGridView1.DataBind();
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvinvExporter, "كشف حساب", 1, Request.GetOwinContext().Request.User.Identity.Name, false, false, "كشف حساب ");
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_docexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvinvExporter, "كشف حساب", 0, Request.GetOwinContext().Request.User.Identity.Name, false, false, "كشف حساب  ");
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_pdfexport_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
            
            }
        }
        decimal totalSumDebit, totalSumCredit;

        protected void ASPxGridView1_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {

        }

        protected void btn_clear_Click(object sender, EventArgs e)
        {
            cmb_levelno.SelectedIndex = -1;
            cmb_balance.SelectedIndex = -1;
            dtefrom.Value = null;
            dteto.Value = null;
            ASPxGridView1.DataBind();
            cmb_levelno.SelectedIndex = 0;
            cmb_balance.SelectedIndex = 0;
        }

        protected void ASPxGridView1_CustomSummaryCalculate(object sender, DevExpress.Data.CustomSummaryEventArgs e)
        {

        }
    }
}