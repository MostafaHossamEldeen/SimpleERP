using DevExpress.Web;
using Emax.Core.Utility;
using Emax.Dal;
using Emax.SharedLib;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.Sys
{
    public partial class Expenses : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "77";
            IndexStored = "sys_expenses_Sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gvexpenses.DataBind();
        }
        void clear()
        {
            hf_expid.Value = "0";
            txt_expname.Text = null;
            hf_paychartid.Value = "0";
            txt_paychartcode.Text = null;
            txt_paychartname.Text = null;
            gvexpenses.Selection.CancelSelection();
        }
        protected void gvexpenses_DataBinding(object sender, EventArgs e)
        {
            gvexpenses.DataSource = IndexDataTable;
        }
        List<object> GetParam()
        {
            if (EmaxGlobals.NullToIntZero(hf_expid.Value) == 0)
            {
                return new List<object> { hf_paychartid, txt_expname };
            }
            else
            {
                return new List<object> { hf_expid, txt_expname };
            }
        }
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (EmaxGlobals.NullToIntZero(hf_paychartid.Value) == 0)
            {
                txt_paychartname.Text = null;
                string msg = "برجاء إختيار الحساب اولا";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetinfo('" + msg + "');", true);
                return;
            }
            StoredExecuteResulte res = new StoredExecuteResulte();
            if (EmaxGlobals.NullToIntZero(hf_expid.Value) == 0)
            {
                res = SaveData("Expenses_ins", GetParam(), null, null, true, false);
                gvexpenses.DataBind();
                clear();
            }
            else
            {
                res = SaveData("Expenses_upd", GetParam(), null, null, true, false);
                gvexpenses.DataBind();
                clear();
            }
            if (res.errorid == 0)
            {
     
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('" + res.errormsg + "');", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + res.errormsg + "')", true);
            }
        }

        //protected void gvitems_CustomCallback(object sender, ASPxGridViewCustomCallbackEventArgs e)
        //{
        //    try
        //    {
        //        List<object> KeyValues = gvexpenses.GetSelectedFieldValues("expid");
        //        if (KeyValues.Count == 0)
        //        {
        //            gvexpenses.JSProperties["cperrors"] = "برجاء إختيار صنف لحذفة";
        //            gvexpenses.JSProperties["cpicon"] = "error";
        //            return;
        //        }
        //        StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
        //        var res = new StoredExecuteResulte();

        //        int count = 0;

        //        string[] itmimgpath = { };

        //        if (e.Parameters.Length != 0)
        //        {
        //            itmimgpath = e.Parameters.Split(',');
        //        }

        //        foreach (object key in KeyValues)
        //        {
        //            Dictionary<object, object> dict = new Dictionary<object, object>();
        //            dict.Add("expid", key);
        //            res = SqlCommandHelper.ExecuteNonQuery("Expenses_del", dict, true);
        //            if (res.errorid == 0)
        //            {
        //                if (itmimgpath.Length != 0)
        //                {
        //                    try
        //                    {
        //                        if (File.Exists(Server.MapPath(itmimgpath[count])))
        //                        {
        //                            var strFile = Server.MapPath(itmimgpath[count]);
        //                            FileAttributes attributes = File.GetAttributes(strFile);

        //                            if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
        //                            {
        //                                attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly);
        //                                File.SetAttributes(strFile, attributes);
        //                                File.Delete(strFile);
        //                            }
        //                            else
        //                            {
        //                                File.Delete(strFile);
        //                            }
        //                        }
        //                        count++;
        //                    }
        //                    catch (Exception ex)
        //                    {
        //                        gvexpenses.JSProperties["cperrors"] = ex.Message;
        //                        gvexpenses.JSProperties["cpicon"] = "error";
        //                    }
        //                }
        //                gvexpenses.DataBind();
        //                gvexpenses.JSProperties["cperrors"] = "تم الحذف بنجاح";
        //                gvexpenses.JSProperties["cpicon"] = "success";
        //            }
        //            else
        //            {
        //                gvexpenses.JSProperties["cperrors"] = res.errormsg;
        //                gvexpenses.JSProperties["cpicon"] = "error";
        //            }
        //            if (res.errorid != 0)
        //            {
        //                gvexpenses.JSProperties["cperrors"] = res.errormsg;
        //                gvexpenses.JSProperties["cpicon"] = "error";
        //            }
        //            gvexpenses.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        if (ex.Message.Contains("index is out of range.") || ex.Message.Contains("الفهرس خارج النطاق. يجب ألا يكون قيمته سالبة ويجب ألا يكون أقل من حجم المجموعة."))
        //        {
        //            gvexpenses.JSProperties["cperrors"] = "برجاء إختيار صنف لحذفة";
        //            gvexpenses.JSProperties["cpicon"] = "error";
        //        }
        //        else
        //        {
        //            gvexpenses.JSProperties["cperrors"] = ex.Message;
        //            gvexpenses.JSProperties["cpicon"] = "error";
        //        }
        //    }

        //}
        //private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        //{
        //    return attributes & ~attributesToRemove;
        //}
        //protected void gvitems_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        //{

        //}

        


        protected void btn_addnew_Click(object sender, EventArgs e)
        {
            clear();
        }

        protected void btn_xlsx_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle;
                exptitle = "حسابات طرق الدفع";
                ExportingDevExpressUtil.Export(gvexpensesExporter, "حسابات طرق الدفع", 1, Request.GetOwinContext().Request.User.Identity.Name, false, false, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_word_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle;
                exptitle = "حسابات طرق الدفع";
                ExportingDevExpressUtil.Export(gvexpensesExporter, "حسابات طرق الدفع", 0, Request.GetOwinContext().Request.User.Identity.Name, false, false, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_pdf_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle;
                exptitle = "حسابات طرق الدفع";
                ExportingDevExpressUtil.Export(gvexpensesExporter, "حسابات طرق الدفع", 2, Request.GetOwinContext().Request.User.Identity.Name, false, false, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void btn_print_Click(object sender, EventArgs e)
        {
            try
            {
                string exptitle;
                exptitle = "حسابات طرق الدفع";
                ExportingDevExpressUtil.Export(gvexpensesExporter, "حسابات طرق الدفع", 2, Request.GetOwinContext().Request.User.Identity.Name, false, true, exptitle);
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }
    }
}