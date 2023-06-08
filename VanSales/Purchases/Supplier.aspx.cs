using DevExpress.Web;
using Emax.Core.Utility;
using Emax.Dal;
using Emax.SharedLib;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.Supplier
{
    public partial class Supplier : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "25";
            IndexStored = "p_supplier_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            #region
            cmbgroup = Util.GenerateGridViewCmb(gvsuppliers, "p_suppgroup_sel", "pgrpid", "pgrpname", "", "اختر");
            cmbusuppchartid = Util.GenerateGridViewCmb(gvsuppliers, "gl_chart_sel_search", "suppchartid", "chartcode", "chartid", "اختر");

            #endregion
            gvsuppliers.DataBind();
        }
        #region combobox
        public GridViewDataComboBoxColumn cmbgroup { get; set; }
        public GridViewDataComboBoxColumn cmbusuppchartid { get; set; }
        #endregion

        protected void gvsuppliers_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            List<object> KeyValues = gvsuppliers.GetSelectedFieldValues("suppid");
            if (KeyValues.Count == 0)
            {
                gvsuppliers.JSProperties["cperrors"] = "برجاء إختيار مورد لحذفه";
                gvsuppliers.JSProperties["cpicon"] = "error";
                return;
            }
            StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
            var res = new StoredExecuteResulte();
            foreach (object key in KeyValues)
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("suppid", key);

                res = SqlCommandHelper.ExecuteNonQuery("p_supplier_del", dict, true);
                if (res.errorid == 0)
                {
                    gvsuppliers.JSProperties["cperrors"] = "تم الحذف بنجاح";
                    gvsuppliers.JSProperties["cpicon"] = "success";
                }
                else
                {
                    break;
                }
            }
            if (res.errorid != 0)
            {
                gvsuppliers.JSProperties["cperrors"] = res.errormsg;
                gvsuppliers.JSProperties["cpicon"] = "error";

            }
            gvsuppliers.DataBind();
        }

        protected void btnpdf_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvsuppliersExporter, "الموردين", 2, Request.GetOwinContext().Request.User.Identity.Name, gvsuppliers.GetSelectedFieldValues("suppid").Count != 0, false, "الموردين");
                gvsuppliersExporter.WritePdfToResponse();
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
                ExportingDevExpressUtil.Export(gvsuppliersExporter, "الموردين", 0, Request.GetOwinContext().Request.User.Identity.Name, gvsuppliers.GetSelectedFieldValues("suppid").Count != 0, false, "الموردين");
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
                ExportingDevExpressUtil.Export(gvsuppliersExporter, "الموردين", 1, Request.GetOwinContext().Request.User.Identity.Name, gvsuppliers.GetSelectedFieldValues("suppid").Count != 0, false, "الموردين");
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
                ExportingDevExpressUtil.Export(gvsuppliersExporter, "الموردين", 2, Request.GetOwinContext().Request.User.Identity.Name, gvsuppliers.GetSelectedFieldValues("suppid").Count != 0, true, "الموردين");
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception()", true);
            }
        }

        protected void gvsuppliers_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["pgrpid"] = cmbgroup.PropertiesComboBox.Items.Count != 0 ? cmbgroup.PropertiesComboBox.Items[0].Value : null;
        }

        protected void gvsuppliers_DataBinding(object sender, EventArgs e)
        {
            gvsuppliers.DataSource = IndexDataTable;
        }
        protected void gvsuppliers_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            var suppchartid = ((ASPxComboBox)gvsuppliers.FindEditRowCellTemplateControl((GridViewDataColumn)gvsuppliers.Columns["suppchartid"], "cmb_suppchartid")).Value;
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("suppchartid", suppchartid);

            var g = SqlCommandHelper.ExecuteNonQuery("p_supplier_ins", e.NewValues, dict, true);
            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvsuppliers.CancelEdit();
            }
        }

        protected void gvsuppliers_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {

            var suppchartid = ((ASPxComboBox)gvsuppliers.FindEditRowCellTemplateControl((GridViewDataColumn)gvsuppliers.Columns["suppchartid"], "cmb_suppchartid")).Value;
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("suppchartid", suppchartid);

            var g = SqlCommandHelper.ExecuteNonQuery("p_supplier_upd", e.NewValues, dict, true, e.Keys);
            if (g.errorid != 0)
            {
                throw new Exception(g.errormsg);
            }
            else
            {
                e.Cancel = true;
                gvsuppliers.CancelEdit();
            }
        }

        int ? cmbsuppchartid = 0;
        ASPxComboBox cmb_suppchartid;
        protected void cmb_suppchartid_Init(object sender, EventArgs e)
        {
            cmb_suppchartid = (ASPxComboBox)sender;
            Util.GenerateCombobox("gl_chart_sel_search", cmb_suppchartid, "", "", "chartid", "chartcode");
            cmb_suppchartid.ValueType = typeof(int);
            //cmb_suppchartid.DataBind();
            //cmbsuppchartidinit = true;
          cmb_suppchartid.SelectedItem= cmb_suppchartid.Items.FindByValue(cmbsuppchartid) ;

        }

        protected void gvsuppliers_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
            //if (cmbsuppchartidinit)
            //{
            //    cmb_suppchartid.SelectedItem = cmb_suppchartid.Items.FindByValue(gvsuppliers.GetRowValues(e.VisibleIndex, "suppchartid"));
            //    cmbsuppchartidinit = false;
            //}
        }

        protected void gvsuppliers_HtmlRowPrepared(object sender, ASPxGridViewTableRowEventArgs e)
        {

        }

        protected void gvsuppliers_EditFormLayoutCreated(object sender, ASPxGridViewEditFormLayoutEventArgs e)
        {
             cmbsuppchartid = gvsuppliers.GetRowValues(e.RowVisibleIndex, "suppchartid")==null?0:EmaxGlobals.NullToIntZero(gvsuppliers.GetRowValues(e.RowVisibleIndex, "suppchartid"));
        }
    }
}