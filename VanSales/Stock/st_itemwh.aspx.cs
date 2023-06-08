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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace VanSales.Stock
{
    public partial class st_itemwh : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "18";
            IndexStored = "st_itemwh_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Util.GenerateCombobox("sys_branch_sel", ddl_branchid, "branchid", "branchname");
                Util.GenerateCombobox("st_group_sel", ddl_groupid, "groupid", "groupname");
                ddl_groupid.SelectedIndex = -1;
                gv_itemwh.DataBind();
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            var res = SaveData("st_itemwh_ins", new List<object>
           { ddl_branchid,ddl_groupid }, null, null 
                  , true, false,
                  null,null);
            if (res.errorid == 0)
            {
                gv_itemwh.DataBind();

            }
        }
        DataTable GvdetailSource()
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("branchid", ddl_branchid.Value);
            dict.Add("group_id", ddl_groupid.SelectedIndex==-1?null: ddl_groupid.Value);
            return SqlCommandHelper.ExcecuteToDataTable("st_itemwh_sel", dict).dataTable;

        }
        protected void gv_itemwh_DataBinding(object sender, EventArgs e)
        {
            gv_itemwh.DataSource = GvdetailSource();
        }

        protected void gv_itemwh_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            try
            {
                if (!e.Parameters.Contains("fillgrid"))
                {
                    List<object> KeyValues = gv_itemwh.GetSelectedFieldValues("itemwhid");
                    if (KeyValues.Count == 0)
                    {
                        gv_itemwh.JSProperties["cperrors"] = "برجاء إختيار صنف لحذفة";
                        gv_itemwh.JSProperties["cpicon"] = "error";
                        return;
                    }
                    StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
                    var res = new StoredExecuteResulte();
                    foreach (object key in KeyValues)
                    {
                        Dictionary<object, object> dict = new Dictionary<object, object>();
                        dict.Add("itemwhid", key);

                        res = SqlCommandHelper.ExecuteNonQuery("st_itemwh_del", dict, true);
                        if (res.errorid == 0)
                        {
                            gv_itemwh.JSProperties["cperrors"] = "تم الحذف بنجاح";
                            gv_itemwh.JSProperties["cpicon"] = "success";
                        }
                        else
                        {
                            break;
                        }
                    }
                    if (res.errorid != 0)
                    {
                        gv_itemwh.JSProperties["cperrors"] = res.errormsg;
                        gv_itemwh.JSProperties["cpicon"] = "error";

                    }
                }
                else
                {
                    gv_itemwh.DataBind();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("index-The index is out of range.") || ex.Message.Contains("الفهرس خارج النطاق. يجب ألا يكون قيمته سالبة ويجب ألا يكون أقل من حجم المجموعة."))
                {
                    gv_itemwh.JSProperties["cperrors"] = "برجاء إختيار صنف لحذفة";
                    gv_itemwh.JSProperties["cpicon"] = "error";
                }
                else
                {
                    gv_itemwh.JSProperties["cperrors"] = ex.Message;
                    gv_itemwh.JSProperties["cpicon"] = "error";
                }
            }
            gv_itemwh.DataBind();
        }

        protected void ddl_branchid_ValueChanged(object sender, EventArgs e)
        {
            gv_itemwh.DataBind();
        }

        protected void gv_itemwh_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            var updated = e.UpdateValues;

            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("branchid", ddl_branchid.Value);
            foreach (var item in updated)
            {
                var g = SqlCommandHelper.ExecuteNonQuery("st_itemwh_upd", item.NewValues, dict, true,item.Keys);

                if (g.errorid != 0)
                {
                    throw new Exception(g.errormsg);
                }
                else
                {
                    e.Handled = true;
                   gv_itemwh.DataBind();
                }

            }
        }

        protected void ddl_groupid_ValueChanged(object sender, EventArgs e)
        {
            gv_itemwh.DataBind();
        }

        protected void btn_xlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle;
                if (ddl_groupid.SelectedItem != null)
                {
                     exptitle = " أصاف فرع  " + ddl_branchid.SelectedItem.Text + " " + ddl_groupid.SelectedItem.Text;
                }
                else
                {
                     exptitle = " أصاف فرع  " + ddl_branchid.SelectedItem.Text;
                }
                ExportingDevExpressUtil.Export(gv_itemwhExporter, "أصناف الفروع", 1, Request.GetOwinContext().Request.User.Identity.Name, gv_itemwh.GetSelectedFieldValues("itemwhid").Count != 0, false, exptitle);
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
                if (ddl_groupid.SelectedItem != null)
                {
                     exptitle = " أصاف فرع  " + ddl_branchid.SelectedItem.Text + " " + ddl_groupid.SelectedItem.Text;
                }
                else
                {
                     exptitle = " أصاف فرع  " + ddl_branchid.SelectedItem.Text;
                }
                ExportingDevExpressUtil.Export(gv_itemwhExporter, "أصناف الفروع", 0, Request.GetOwinContext().Request.User.Identity.Name, gv_itemwh.GetSelectedFieldValues("itemwhid").Count != 0, false, exptitle);
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
                if (ddl_groupid.SelectedItem != null)
                {
                    exptitle = " أصاف فرع  " + ddl_branchid.SelectedItem.Text + " " + ddl_groupid.SelectedItem.Text;
                }
                else
                {
                    exptitle = " أصاف فرع  " + ddl_branchid.SelectedItem.Text;
                }
                ExportingDevExpressUtil.Export(gv_itemwhExporter, "أصناف الفروع", 2, Request.GetOwinContext().Request.User.Identity.Name, gv_itemwh.GetSelectedFieldValues("itemwhid").Count != 0, false, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_printexport_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle;
                if (ddl_groupid.SelectedItem != null)
                {
                    exptitle = " أصاف فرع  " + ddl_branchid.SelectedItem.Text + " " + ddl_groupid.SelectedItem.Text;
                }
                else
                {
                     exptitle = " أصاف فرع  " + ddl_branchid.SelectedItem.Text;
                }
                ExportingDevExpressUtil.Export(gv_itemwhExporter, "أصناف الفروع", 2, Request.GetOwinContext().Request.User.Identity.Name, gv_itemwh.GetSelectedFieldValues("itemwhid").Count != 0, true, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }
    }
}