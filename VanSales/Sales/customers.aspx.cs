using DevExpress.Export;
using DevExpress.Web;
using DevExpress.XtraPrinting;
using Emax.Core.Utility;
using Emax.Dal;
using Emax.SharedLib;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales
{
    public partial class customers : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "1";
            IndexStored = "s_customers_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            #region
            cmbubranch = Util.GenerateGridViewCmb(gvcustomers, "s_custgroup_sel", "sgrpid", "sgrpname","", "اختر");
            cmbusman = Util.GenerateGridViewCmb(gvcustomers, "s_sman_sel_main", "smanid", "smanname", "", "اختر");
            cmbucustchartid = Util.GenerateGridViewCmb(gvcustomers, "gl_chart_sel_search", "custchartid", "chartcode", "chartid","اختر");
            #endregion
            gvcustomers.DataBind();
        }

        #region combobox
        public GridViewDataComboBoxColumn cmbubranch { get; set; }
        public GridViewDataComboBoxColumn cmbusman { get; set; }
        public GridViewDataComboBoxColumn cmbucustchartid { get; set; }
        #endregion

        protected void gvcustomers_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            List<object> KeyValues = gvcustomers.GetSelectedFieldValues("custid");
            if (KeyValues.Count == 0)
            {
                gvcustomers.JSProperties["cperrors"] = "برجاء إختيار عميل لحذفه";
                gvcustomers.JSProperties["cpicon"] = "error";
                return;
            }
            StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
            var res = new StoredExecuteResulte();
            foreach (object key in KeyValues)
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("custid", key);

                res = SqlCommandHelper.ExecuteNonQuery("s_customers_del", dict, true);
                if (res.errorid == 0)
                {
                    gvcustomers.JSProperties["cperrors"] = "تم الحذف بنجاح";
                    gvcustomers.JSProperties["cpicon"] = "success";
                }
                else
                {
                    break;
                }
            }
                if (res.errorid != 0)
                {
                    gvcustomers.JSProperties["cperrors"] = res.errormsg;
                    gvcustomers.JSProperties["cpicon"] = "error";

                }
                gvcustomers.DataBind();
        }

        protected void btnpdf_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvcustomersExporter, "العملاء", 2, Request.GetOwinContext().Request.User.Identity.Name, gvcustomers.GetSelectedFieldValues("custid").Count != 0, false, "العملاء");
                gvcustomersExporter.WritePdfToResponse();
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void btndoc_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvcustomersExporter, "العملاء", 0, Request.GetOwinContext().Request.User.Identity.Name, gvcustomers.GetSelectedFieldValues("custid").Count != 0, false, "العملاء");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void btnxlsx_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvcustomersExporter, "العملاء", 1, Request.GetOwinContext().Request.User.Identity.Name, gvcustomers.GetSelectedFieldValues("custid").Count != 0, false, "العملاء");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvcustomersExporter, "العملاء", 2, Request.GetOwinContext().Request.User.Identity.Name, gvcustomers.GetSelectedFieldValues("custid").Count != 0, true, "العملاء");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void gvcustomers_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["sgrpid"] = cmbubranch.PropertiesComboBox.Items.Count != 0 ? cmbubranch.PropertiesComboBox.Items[0].Value : null;
        }

        protected void gvcustomers_DataBinding(object sender, EventArgs e)
        {
            gvcustomers.DataSource = IndexDataTable;
        }
        protected void gvcustomers_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
          
            var custcharid = ((ASPxComboBox)gvcustomers.FindEditRowCellTemplateControl((GridViewDataColumn)gvcustomers.Columns["custchartid"], "cmb_custchartid")).Value;
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("custchartid", custcharid);
      
            var g = SqlCommandHelper.ExecuteNonQuery("s_customers_ins", e.NewValues, dict, true);
            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvcustomers.CancelEdit();
            }
        }

        protected void gvcustomers_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            var custcharid = ((ASPxComboBox)gvcustomers.FindEditRowCellTemplateControl((GridViewDataColumn)gvcustomers.Columns["custchartid"], "cmb_custchartid")).Value;
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("custchartid", custcharid);

            var g = SqlCommandHelper.ExecuteNonQuery("s_customers_upd", e.NewValues, dict, true, e.Keys);
            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvcustomers.CancelEdit();
            }
        }

        bool cmbcustchartidinit = false;
        ASPxComboBox cmb_custchartid;
        protected void cmb_custchartid_Init(object sender, EventArgs e)
        {
            cmb_custchartid = (ASPxComboBox)sender;
            Util.GenerateCombobox("gl_chart_sel_search", cmb_custchartid, "", "", "chartid", "chartcode");
            cmb_custchartid.ValueType = typeof(int);
            cmb_custchartid.DataBind();
            cmbcustchartidinit = true;
        }

        protected void gvcustomers_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            if (cmbcustchartidinit)
            {
                cmb_custchartid.SelectedItem = cmb_custchartid.Items.FindByValue( gvcustomers.GetRowValues(e.VisibleIndex, "custchartid"));
                cmbcustchartidinit = false;
            }
        }
    }
}