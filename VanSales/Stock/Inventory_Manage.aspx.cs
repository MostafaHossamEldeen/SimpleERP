using DevExpress.Web;
using Emax.Core.Utility;
using Emax.Dal;
using Emax.SharedLib;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;

namespace VanSales.Stock
{
    public partial class Inventory_Manage : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "22";
            IndexStored = "";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            CmbUnit = Util.GenerateGridViewCmb(gv_inventdlts, "st_unit_sel", "unitid", "unitname", "", "اختر");
            CmbItem = Util.GenerateGridViewCmb(gv_inventdlts, "st_items_sel", "itemid", "itemname");
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_branchid, "compid,table_name", "0,sys_branch", "branchid", "branchname");
                Util.GenerateCombobox("sys_fillcomp_sel", cmb_pqty, "compid,table_name", "33,sys_fillcomp", "citemid", "citemname");
                dt_inventdate.Date = DateTime.Now.Date;
            }
        }

        void BindData(DataRow rec)
        {
            txt_inventno.Text = EmaxGlobals.NullToEmpty(rec["inventno"]);
            txt_inventdocno.Text = EmaxGlobals.NullToEmpty(rec["inventdocno"]);
            dt_inventdate.Date = (Convert.ToDateTime(rec["inventdate"]));
            cmb_branchid.Value = EmaxGlobals.NullToEmpty(rec["branchid"]);
            cmb_branchid.Text = EmaxGlobals.NullToEmpty(rec["branchname"]);
            txt_notes.Text = EmaxGlobals.NullToEmpty(rec["notes"]);
            txt_inventuser.Text = EmaxGlobals.NullToEmpty(rec["inventuser"]);
            hf_postst.Value = EmaxGlobals.NullToEmpty(rec["postst"]);
            HF_inventid.Value = EmaxGlobals.NullToEmpty(rec["inventid"]);
            txt_inventdocno.ReadOnly = true;
            txt_inventuser.ReadOnly = true;
            dt_inventdate.ReadOnly = true;
            cmb_branchid.ClientEnabled = false;
            cmb_pqty.SelectedIndex = -1;
            cmb_pqty.ClientEnabled = false;

            if (hf_postst.Value == "True")
            {
                lbl_postst.Text = "مرحل مستودعات";
                gv_inventdlts.SettingsDataSecurity.AllowEdit = false;
                disable();
            }
            else
            {
                lbl_postst.Text = "";
                gv_inventdlts.SettingsDataSecurity.AllowEdit = true;
                enable();
            }
        }
        void disable()
        {
            btn_save.Enabled = false;
            btn_save.CssClass = "disable";
            btn_save.RenderMode = Secondary;

            btn_delete.Enabled = false;
            btn_delete.CssClass = "disable";
            btn_delete.RenderMode = Secondary;
            
            btn_poststock.Enabled = false;
            btn_poststock.CssClass = "disable";
            btn_poststock.RenderMode = Secondary;
        }
        void enable()
        {
            btn_save.Enabled = true;
            btn_save.CssClass = "enable";

            btn_delete.Enabled = true;
            btn_delete.CssClass = "enable";

            btn_poststock.Enabled = true;
            btn_poststock.CssClass = "enable";
        }

        public GridViewDataComboBoxColumn CmbUnit { get; set; }
        public GridViewDataComboBoxColumn CmbItem { get; set; }
        public ButtonRenderMode Secondary { get; private set; }

        protected void gv_inventdlts_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            var updated = e.UpdateValues;
            foreach (var item in updated)
            {
                var g = SqlCommandHelper.ExecuteNonQuery("st_inventdlts_upd", item.NewValues, true, item.Keys);
                if (g.errorid != 0)
                {
                    throw new Exception(g.errormsg);
                }
                else
                {
                    e.Handled = true;
                    gv_inventdlts.DataBind();
                }
            }
        }

        protected void gv_inventdlts_DataBinding(object sender, EventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("inventid", HF_inventid.Value);
            gv_inventdlts.DataSource = SqlCommandHelper.ExcecuteToDataTable("st_inventdlts_sel", dict).dataTable;
        }

        List<object> GetParam()
        {
            if (EmaxGlobals.NullToIntZero(HF_inventid.Value) == 0)
            {
                return new List<object> {  dt_inventdate, txt_inventdocno, cmb_branchid, txt_notes, txt_inventuser, hf_postst, cmb_pqty };
            }
            else
            {
                return new List<object> { HF_inventid, txt_notes};
            }
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            txt_inventuser.Text = Context.User.Identity.Name;
            StoredExecuteResulte res=new StoredExecuteResulte();
            if (EmaxGlobals.NullToIntZero(HF_inventid.Value) == 0)
            {
                 res = SaveData("st_inventory_ins" , GetParam(), null, new List<string>() { "inventid", "inventno" }, true, true, 
                     new List<ParamObject>() { new ParamObject() { ParamName = "branchname", ParamValue = cmb_branchid } });
            }
            else
            {
                 res = SaveData("st_inventory_upd", GetParam(), null, null, true, false,null);
            }
            if (res.errorid == 0)
            {
                if (res.outputparams.ContainsKey("inventid"))
                {
                    HF_inventid.Value = res.outputparams["inventid"].ToString();
                }
                if (res.outputparams.ContainsKey("inventno"))
                {
                    txt_inventno.Text = res.outputparams["inventno"].ToString();
                }
                txt_inventdocno.ReadOnly = true;
                txt_inventuser.ReadOnly = true;
                dt_inventdate.ReadOnly = true;
                cmb_branchid.ClientEnabled = false;
                cmb_pqty.ClientEnabled = false;
                Panel2.Style.Add("display", "block");
                gv_inventdlts.DataBind();
                if (hf_postst.Value == "True")
                {
                    lbl_postst.Text = "مرحل مستودعات";
                    gv_inventdlts.SettingsDataSecurity.AllowEdit = false;
                    disable();
                }
                else
                {
                    lbl_postst.Text = "";
                    gv_inventdlts.SettingsDataSecurity.AllowEdit = true;
                    enable();
                }
            }
        }
        protected void btn_new_Click(object sender, EventArgs e)
        {
            enable();
            gv_inventdlts.SettingsDataSecurity.AllowEdit = true;
            txt_inventdocno.ReadOnly = false;
            txt_inventuser.ReadOnly = false;
            dt_inventdate.ReadOnly = false;
            cmb_branchid.ClientEnabled = true;
            cmb_pqty.ClientEnabled = true;
            txt_inventno.Text = "تلقائي";
            txt_notes.Text = null;
            txt_inventdocno.Text=null;
            txt_inventuser.Text = null;
            dt_inventdate.Date = DateTime.Now.Date;
            cmb_branchid.SelectedIndex = 0;
            cmb_pqty.SelectedIndex = 0;
            hf_postst.Value = "False";
            lbl_postst.Text = null;
            HF_inventid.Value = "0";
            gv_inventdlts.DataBind();
            Panel2.Style.Add("display", "none");
        }
        protected void HF_inventid_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("inventid", HF_inventid.Value);
                var f = SqlCommandHelper.ExcecuteToDataTable("st_inventory_sel_inventid", dict).dataTable;
                gv_inventdlts.DataBind();
                BindData(f.Rows[0]);
                Panel2.Style.Add("display", "block");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + ex.Message + ")", true);
            }
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle;
                exptitle = "  سند جرد رقم  " + txt_inventno.Text + "  خاص فرع  " + cmb_branchid.SelectedItem.Text + "  بتاريخ  " + dt_inventdate.Text;
                ExportingDevExpressUtil.Export(gv_inventdltsExporter, "سندات الجرد", 1, Request.GetOwinContext().Request.User.Identity.Name, gv_inventdlts.GetSelectedFieldValues("invtdtlsid").Count != 0, false, exptitle);
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
                string exptitle;
                exptitle = "  سند جرد رقم  " + txt_inventno.Text + "  خاص فرع  " + cmb_branchid.SelectedItem.Text + "  بتاريخ  " + dt_inventdate.Text;
                ExportingDevExpressUtil.Export(gv_inventdltsExporter, "سندات الجرد", 0, Request.GetOwinContext().Request.User.Identity.Name, gv_inventdlts.GetSelectedFieldValues("invtdtlsid").Count != 0, false, exptitle);
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
                string exptitle;
                exptitle = "  سند جرد رقم  " + txt_inventno.Text + "  خاص فرع  " + cmb_branchid.SelectedItem.Text + "  بتاريخ  " + dt_inventdate.Text;
                ExportingDevExpressUtil.Export(gv_inventdltsExporter, "سندات الجرد", 2, Request.GetOwinContext().Request.User.Identity.Name, gv_inventdlts.GetSelectedFieldValues("invtdtlsid").Count != 0, false, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_printexport_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string exptitle;
            //    exptitle = "  سند جرد رقم  " + txt_inventno.Text + "  خاص فرع  " + cmb_branchid.SelectedItem.Text + "  بتاريخ  " + dt_inventdate.Text;
            //    ExportingDevExpressUtil.Export(gv_inventdltsExporter, "سندات الجرد", 2, Request.GetOwinContext().Request.User.Identity.Name, gv_inventdlts.GetSelectedFieldValues("invtdtlsid").Count != 0, true, exptitle);
            //}
            //catch (Exception ex)
            //{
            //    string error_msg = ex.Message;
            //    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            
                string branchname;
                int itemid = 0;
                decimal tqty = 0;
                decimal pqty = 0;
                decimal diffqty = 0;
                decimal diffcost = 0;


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
                var s = gv_inventdlts.VisibleRowCount;
                DataTable reptb = new DataTable();
                foreach (GridViewDataColumn item in gv_inventdlts.VisibleColumns)
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
                    var ggd = gv_inventdlts.GetDataRow(i);
                    reptb.ImportRow(ggd);
                    if (reptb.Columns.Contains("trandate"))
                    {
                        var newdate = Convert.ToDateTime(ggd.ItemArray.GetValue(14)).ToString("yyyy-MM-dd");
                        reptb.Rows[i]["trandate"] = newdate;
                    }
                    
                }


                itemid = Convert.ToInt32(gv_inventdlts.GetTotalSummaryValue((ASPxSummaryItem)gv_inventdlts.TotalSummary["itemid"]));
                tqty   = Convert.ToDecimal(gv_inventdlts.GetTotalSummaryValue((ASPxSummaryItem)gv_inventdlts.TotalSummary["tqty"]));
                pqty   = Convert.ToDecimal(gv_inventdlts.GetTotalSummaryValue((ASPxSummaryItem)gv_inventdlts.TotalSummary["pqty"]));
                diffqty= Convert.ToDecimal(gv_inventdlts.GetTotalSummaryValue((ASPxSummaryItem)gv_inventdlts.TotalSummary["diffqty"]));
                diffcost =   Convert.ToDecimal(gv_inventdlts.GetTotalSummaryValue((ASPxSummaryItem)gv_inventdlts.TotalSummary["diffcost"]));

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
                dict.Add("itemid", itemid);
                dict.Add("tqty", tqty);
                dict.Add("pqty", pqty);
                dict.Add("diffqty", diffqty);
                dict.Add("diffcost", diffcost);


                dict.Add("branchname", branchname);
                dict.Add("inventno", txt_inventno.Value);
                dict.Add("inventdocno", txt_inventdocno.Value);
                dict.Add("inventdate", dt_inventdate.Date);
                dict.Add("pqty", cmb_pqty.Value);
                dict.Add("notes", txt_notes.Text);
                dict.Add("inventuser", txt_inventuser.Text);

                
                PrintPage("Stock/st_transactions_report.repx", reptb, dict);
            
        }

        protected void gv_inventdlts_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            try
            {
                var rcase = e.Parameters.Split(',');
                if (rcase[0] == "true")
                {
                    lbl_postst.Text = "مرحل مستودعات";
                    gv_inventdlts.SettingsDataSecurity.AllowEdit = false;
                    disable();
                }
                else
                {
                    lbl_postst.Text = "";
                    gv_inventdlts.SettingsDataSecurity.AllowEdit = true;
                    enable();
                }
                txt_inventdocno.ReadOnly = true;
                txt_inventuser.ReadOnly = true;
                dt_inventdate.ReadOnly = true;
                cmb_branchid.ClientEnabled = false;
                cmb_pqty.ClientEnabled = false;
                Panel2.Style.Add("display", "block");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + ex.Message + ")", true);
            }
        }
    }
}