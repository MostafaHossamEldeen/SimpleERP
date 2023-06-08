using DevExpress.Web;
using Emax.Dal;
using Emax.SharedLib;
using Newtonsoft.Json;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;

namespace VanSales
{
    public partial class WebForm2 :EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "16";
            IndexStored = "";
            base.OnInit(e);
        }
        #region combobox
        public GridViewDataComboBoxColumn CmbUnit { get; set; }
        public GridViewDataComboBoxColumn CmbGroup { get; set; }
        public GridViewDataComboBoxColumn CmbItemType { get; set; }
        public GridViewDataComboBoxColumn CmbItemStop { get; set; }
        public GridViewDataComboBoxColumn Cmbsupp { get; set; }
        public GridViewDataComboBoxColumn CmbBranchid { get; set; }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            CmbUnit = Util.GenerateGridViewCmb(gvitemunit, "st_unit_sel", "unitid", "unitname", "", "اختر");
            CmbBranchid = Util.GenerateGridViewCmb(gv_itemwh, "sys_branch_sel", "branchid", "branchname", "", "اختر");
            if (!IsPostBack)
            {
                try
                {
                    Util.GenerateTokenBox("sys_branch_sel_itemmanage", tkb_branchid, "itemid", hf_itemid.Value, "branchid", "branchname");
                    Util.GenerateCombobox("st_unit_sel", cmb_unitid, "unitid", "unitname");
                    Util.GenerateCombobox("st_group_sel", cmb_groupid, "groupid", "groupname");
                    Util.GenerateCombobox("sys_fillcomp_sel", cmb_itemtypeid, "compid,table_name", "4,sys_fillcomp", "citemid", "citemname");
                    Util.GenerateCombobox("p_supplier_sel_cmb", cmb_suppid, "suppid", "suppname");
                    cmb_suppid.SelectedIndex = -1;
                    Util.GenerateCombobox("sys_fillcomp_sel", cmb_itemstop, "compid,table_name", "5,sys_fillcomp", "citemid", "citemname");
                    Util.GenerateCombobox("st_fillcomp_sel", cmb_itemcat1, "compid", "1", "citemid", "citemname");
                    cmb_itemcat1.SelectedIndex = -1;
                    Util.GenerateCombobox("st_fillcomp_sel", cmb_itemcat2, "compid", "2", "citemid", "citemname");
                    cmb_itemcat2.SelectedIndex = -1;
                    if (Request.QueryString["itemid"] != null && Request.QueryString["itemid"] != string.Empty)
                    {
                        hf_itemid.Value = Request.QueryString["itemid"];
                        Dictionary<object, object> dict = new Dictionary<object, object>();
                        dict.Add("itemid", hf_itemid.Value);
                        var f = SqlCommandHelper.ExcecuteToDataTable("st_items_sel_itemid", dict).dataTable;
                        gvitemunit.DataBind();
                        BindData(f.Rows[0]);
                    }
                    else if (hf_itemid.Value != "0")
                    {
                        Dictionary<object, object> dict = new Dictionary<object, object>();
                        dict.Add("itemid", hf_itemid.Value);
                        var f = SqlCommandHelper.ExcecuteToDataTable("st_items_sel_itemid", dict).dataTable;
                        gvitemunit.DataBind();
                        BindData(f.Rows[0]);
                    }

                    txt_vat.Text = SqlCommandHelper.GetTokenKey("vat", Request.Cookies["Token"].Value);
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("There is no row at position 0") || ex.Message.Contains("لا يوجد صف في الموضع 0"))
                    {
                        Response.Redirect("~/Stock/Item_Manage.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('عذراً حدث خطأ غير متوقع')", true);
                    }
                }
                gv_itemwh.DataBind();
            }
        }
        void BindData(DataRow rec)
        {
            txt_itemcode.Text = EmaxGlobals.NullToEmpty(rec["itemcode"]);
            txt_itemcode2.Text = EmaxGlobals.NullToEmpty(rec["itemcode2"]);
            txt_itemcode3.Text = EmaxGlobals.NullToEmpty(rec["itemcode3"]);
            txt_itembarcode.Text = EmaxGlobals.NullToEmpty(rec["itembarcode"]);
            txt_itembarcode2.Text = EmaxGlobals.NullToEmpty(rec["itembarcode2"]);
            txt_itemname.Text = EmaxGlobals.NullToEmpty(rec["itemname"]);
            txt_itemename.Text = EmaxGlobals.NullToEmpty(rec["itemename"]);
            txt_itemdesc.Text = EmaxGlobals.NullToEmpty(rec["itemdesc"]);
            cmb_unitid.Value = EmaxGlobals.NullToIntZero(rec["unitid"]);
            cmb_unitid.Text = EmaxGlobals.NullToEmpty(rec["unitname"]);
            cmb_groupid.Value = EmaxGlobals.NullToEmpty(rec["groupid"]);
            cmb_groupid.Text = EmaxGlobals.NullToEmpty(rec["groupname"]);
            cmb_itemtypeid.Value = EmaxGlobals.NullToEmpty(rec["itemtypeid"]);
            cmb_itemtypeid.Text = EmaxGlobals.NullToEmpty(rec["itemtypename"]);
            cmb_suppid.Value = EmaxGlobals.NullToEmpty(rec["suppid"]);
            cmb_suppid.Text = EmaxGlobals.NullToEmpty(rec["suppname"]);
            cmb_itemstop.Value = EmaxGlobals.NullToEmpty(rec["itemstop"]);
            cmb_itemstop.Text = EmaxGlobals.NullToEmpty(rec["itemstopname"]);
            txt_minqty.Text = EmaxGlobals.NullToEmpty(rec["minqty"]);
            txt_maxqty.Text = EmaxGlobals.NullToEmpty(rec["maxqty"]);
            txt_pprice.Text = EmaxGlobals.NullToEmpty(rec["pprice"]);
            txt_cprice.Text = rec["cprice"].ToString();
            txt_sprice.Text = EmaxGlobals.NullToEmpty(rec["sprice"]);
            txt_vat.Text = EmaxGlobals.NullToEmpty(rec["vat"]);
            txt_vprice.Text = EmaxGlobals.NullToEmpty(rec["vprice"]);
            txt_fprice.Text = EmaxGlobals.NullToEmpty(rec["fprice"]);
            img_itempic.ImageUrl = EmaxGlobals.NullToEmpty(rec["itempic"]);
            cmb_itemcat1.Value = EmaxGlobals.NullToEmpty(rec["itemcat1"]);
            cmb_itemcat1.Text = EmaxGlobals.NullToEmpty(rec["itemcatname1"]);
            cmb_itemcat2.Value = EmaxGlobals.NullToEmpty(rec["itemcat2"]);
            cmb_itemcat2.Text = EmaxGlobals.NullToEmpty(rec["itemcatname2"]);
            txt_itemfield1.Text = EmaxGlobals.NullToEmpty(rec["itemfield1"]);
            txt_itemfield2.Text = EmaxGlobals.NullToEmpty(rec["itemfield2"]);
        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            Dictionary<object, object> dictother = new Dictionary<object, object>();
            dictother.Add("itempic", Session["filePath"]);
            var ff = cmb_itemtypeid.Value;
            var res = SaveData(EmaxGlobals.NullToIntZero(hf_itemid.Value) == 0 ? "st_items_ins" : "st_items_upd", new List<object>
           { txt_itemcode,txt_itemcode2,txt_itemcode3,txt_itembarcode,txt_itembarcode2,txt_itemname,txt_itemename,txt_itemdesc,hf_itemid,cmb_unitid,cmb_groupid,cmb_itemtypeid,
                cmb_suppid,cmb_itemstop,txt_minqty,txt_maxqty,txt_pprice,txt_cprice,txt_sprice,txt_vat,txt_vprice,txt_fprice,txt_itemfield1,txt_itemfield2,cmb_itemcat1,cmb_itemcat2,img_itempic}, null,
                  EmaxGlobals.NullToIntZero(hf_itemid.Value) == 0 ? new List<string>() { "id", "itemcode" } : null,
                  true, false,
                  new List<ParamObject>() { new ParamObject() { ParamName = "itemcatname1", ParamValue = cmb_itemcat1 }, new ParamObject() { ParamName = "itemcatname2", ParamValue = cmb_itemcat2 } },
                  dictother);
            if (res.errorid == 0)
            {
                if (res.outputparams != null && res.outputparams.Count > 0)
                {
                    hf_itemid.Value = EmaxGlobals.NullToEmpty(res.outputparams["id"]);
                    txt_itemcode.Value = EmaxGlobals.NullToEmpty(res.outputparams["itemcode"]);
                    Session.Remove("fileName");
                    Session.Remove("filePath");
                }
                else
                {
                    Session.Remove("fileName");
                    Session.Remove("filePath");
                }
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("itemid", hf_itemid.Value);
                var f = SqlCommandHelper.ExcecuteToDataTable("st_items_sel_itemid", dict).dataTable;
                gvitemunit.DataBind();
                BindData(f.Rows[0]);
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('تم الحفظ بنجاح');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + res.errormsg + ")", true);
            }
        }

        protected void upd_itempic_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (e.IsValid)
            {
                Session["fileName"] = e.UploadedFile.FileNameInStorage;
                Session["filePath"] = "~/Img/Item/" + Session["fileName"].ToString();
                e.UploadedFile.SaveAs(MapPath(Session["filePath"].ToString()));
            }
        }

        protected void gvitemunit_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {

            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("itemid", hf_itemid.Value);
            var g = SqlCommandHelper.ExecuteNonQuery("st_itemunit_ins", e.NewValues, dict, true);
            if (g.errorid != 0)
            {
                if (g.errormsg.Contains("duplicate"))
                {
                    g.errormsg = "لا يمكن تكرار باركود الصنف او الوحدة لنفس الصنف";
                    throw new Exception(g.errormsg);
                }
                else
                {
                    throw new Exception(g.errormsg);
                }
            }
            else
            {
                e.Cancel = true;
                gvitemunit.CancelEdit();

            }
        }

        protected void gvitemunit_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("itemunitid", e.Keys[0]);
                var res = SqlCommandHelper.ExecuteNonQuery("st_itemunit_del", dict);
                if (res.errorid == 0)
                {
                    e.Cancel = true;
                    gvitemunit.DataBind();
                }
            }
            catch (Exception ex)
            {
                gvitemunit.JSProperties["cperrors"] = ex.Message;
                gvitemunit.JSProperties["cpicon"] = "error";
            }
        }

        protected void gvitemunit_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
            try
            {
                var g = SqlCommandHelper.ExecuteNonQuery("st_itemunit_upd", e.NewValues, true, e.Keys);
                if (g.errorid != 0)
                {
                    throw new Exception(g.errormsg);
                }
                else
                {
                    e.Cancel = true;
                    gvitemunit.CancelEdit();
                    ClientScript.RegisterStartupScript(GetType(), "refresh", "refreshpage()", true);
                }
            }
            catch (Exception ex)
            {
                gvitemunit.JSProperties["cperrors"] = ex.Message;
                gvitemunit.JSProperties["cpicon"] = "error";
            }
        }

        protected void gvitemunit_DataBinding(object sender, EventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("itemid", hf_itemid.Value);
            gvitemunit.DataSource = SqlCommandHelper.ExcecuteToDataTable("st_itemunit_sel", dict).dataTable;
        }

        protected void gvitemunit_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["vat"] = SqlCommandHelper.GetTokenKey("vat", Request.Cookies["Token"].Value); ;
            e.NewValues["sprice"] = txt_sprice.Text;
        }

        protected void hf_itemid_ValueChanged(object sender, EventArgs e)
        {
            gvitemunit.DataBind();
        }
        protected void gv_itemwh_DataBinding(object sender, EventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("itemid", hf_itemid.Value);
            gv_itemwh.DataSource = SqlCommandHelper.ExcecuteToDataTable("st_itemwh_item_manage_sel", dict).dataTable;
        }

        protected void btn_addbranch_Click(object sender, EventArgs e)
        {
            string[] branchid = EmaxGlobals.NullToEmpty(tkb_branchid.Value).Split(',');
            foreach (string item in branchid)
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("itemid", hf_itemid.Value);
                dict.Add("branchid", item);
                var res = SqlCommandHelper.ExecuteNonQuery("st_itemwh_item_manage_ins", dict, true);
            }
            gv_itemwh.DataBind();
            tkb_branchid.Text = string.Empty;
            Util.GenerateTokenBox("sys_branch_sel_itemmanage", tkb_branchid, "itemid", hf_itemid.Value, "branchid", "branchname");
        }

        protected void gvitemunit_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            gvitemunit.DataBind();
        }

        protected void gv_itemwh_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        {
            gv_itemwh.DataBind();
        }

        protected void tkb_branchid_Callback(object sender, CallbackEventArgsBase e)
        {
            Util.GenerateTokenBox("sys_branch_sel_itemmanage", tkb_branchid, "itemid", hf_itemid.Value, "branchid", "branchname");
        }

        protected void btn_delete_Click(object sender, EventArgs e)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("itemid", hf_itemid);
            SqlCommandHelper.ExecuteNonQuery("st_items_del", dict, true);
        }

    }
}