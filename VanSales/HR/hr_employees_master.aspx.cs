using DevExpress.Web;
using Emax.Core.Utility;
using Emax.Dal;
using Emax.SharedLib;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;

namespace VanSales.HR
{
    public partial class hr_employees_master : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "42";
            IndexStored = "hr_employees_sel";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var dict = new Dictionary<object, object>();
            dict.Add("masterid", "1");
            Cmbnationid = Util.GenerateGridViewCmb(gv_hr_employees, "hr_masterfiles_sel", "nationid", "mitemname", "mitemid", "اختر", dict);
            Cmbbranchid = Util.GenerateGridViewCmb(gv_hr_employees, "sys_branch_sel", "branchid", "branchname", "", "اختر");
            var ccdict = new Dictionary<object, object>();
            ccdict.Add("compid", "0");
            ccdict.Add("table_name", "sys_costcenter");
            Cmbccid = Util.GenerateGridViewCmb(gv_hr_employees, "sys_fillcomp_sel", "ccid", "ccname", "ccid", "اختر", ccdict);
            var ssdict = new Dictionary<object, object>();
            ssdict.Add("compid", "27");
            ssdict.Add("table_name", "sys_fillcomp");
            Cmbempstatus = Util.GenerateGridViewCmb(gv_hr_employees, "sys_fillcomp_sel", "empstatus", "citemname", "citemid", "اختر", ssdict);
            var jjdict = new Dictionary<object, object>();
            jjdict.Add("masterid", "2");
            Cmbjobid = Util.GenerateGridViewCmb(gv_hr_employees, "hr_masterfiles_sel", "jobid", "mitemname", "mitemid", "اختر", jjdict);
            var ptdict = new Dictionary<object, object>();
            ptdict.Add("compid", "0");
            ptdict.Add("table_name", "sys-paytype");
            ptdict.Add("model", "7");
            Cmbpaytypeid = Util.GenerateGridViewCmb(gv_hr_employees, "sys_fillcomp_sel", "paytypeid", "paytname", "paytypeid", "اختر", ptdict);
            gv_hr_employees.DataBind();
        }

        public GridViewDataComboBoxColumn Cmbnationid { get; set; }
        public GridViewDataComboBoxColumn Cmbjobid { get; set; }
        public GridViewDataComboBoxColumn Cmbempstatus { get; set; }
        public GridViewDataComboBoxColumn Cmbpaytypeid { get; set; }
        public GridViewDataComboBoxColumn Cmbbranchid { get; set; }
        public GridViewDataComboBoxColumn Cmbccid { get; set; }

        protected void gv_hr_employees_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            try
            {
                List<object> KeyValues = gv_hr_employees.GetSelectedFieldValues("empid");
                if (KeyValues.Count == 0)
                {
                    gv_hr_employees.JSProperties["cperrors"] = "برجاء إختيار الموظف لحذفة";
                    gv_hr_employees.JSProperties["cpicon"] = "error";
                    return;
                }
                StringBuilder sb = new StringBuilder(KeyValues[0].ToString());
                var res = new StoredExecuteResulte();

                int count = 0;

                string[] itmimgpath = { };

                if (e.Parameters.Length != 0)
                {
                    itmimgpath = e.Parameters.Split(',');
                }

                foreach (object key in KeyValues)
                {
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("empid", key);
                    res = SqlCommandHelper.ExecuteNonQuery("hr_employees_del", dict, true);
                    if (res.errorid == 0)
                    {
                        if (itmimgpath.Length != 0)
                        {
                            try
                            {
                                if (File.Exists(Server.MapPath(itmimgpath[count])))
                                {
                                    var strFile = Server.MapPath(itmimgpath[count]);
                                    FileAttributes attributes = File.GetAttributes(strFile);

                                    if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                                    {
                                        attributes = RemoveAttribute(attributes, FileAttributes.ReadOnly);
                                        File.SetAttributes(strFile, attributes);
                                        File.Delete(strFile);
                                    }
                                    else
                                    {
                                        File.Delete(strFile);
                                    }
                                }
                                count++;
                            }
                            catch (Exception ex)
                            {
                                gv_hr_employees.JSProperties["cperrors"] = ex.Message;
                                gv_hr_employees.JSProperties["cpicon"] = "error";
                            }
                        }
                        gv_hr_employees.DataBind();
                        gv_hr_employees.JSProperties["cperrors"] = "تم الحذف بنجاح";
                        gv_hr_employees.JSProperties["cpicon"] = "success";
                    }
                    else
                    {
                        gv_hr_employees.JSProperties["cperrors"] = res.errormsg;
                        gv_hr_employees.JSProperties["cpicon"] = "error";
                    }
                    if (res.errorid != 0)
                    {
                        gv_hr_employees.JSProperties["cperrors"] = res.errormsg;
                        gv_hr_employees.JSProperties["cpicon"] = "error";
                    }
                    gv_hr_employees.DataBind();
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("index is out of range.") || ex.Message.Contains("الفهرس خارج النطاق. يجب ألا يكون قيمته سالبة ويجب ألا يكون أقل من حجم المجموعة."))
                {
                    gv_hr_employees.JSProperties["cperrors"] = "برجاء إختيار الموظف لحذفة";
                    gv_hr_employees.JSProperties["cpicon"] = "error";
                }
                else
                {
                    gv_hr_employees.JSProperties["cperrors"] = ex.Message;
                    gv_hr_employees.JSProperties["cpicon"] = "error";
                }
            }
        }
        private static FileAttributes RemoveAttribute(FileAttributes attributes, FileAttributes attributesToRemove)
        {
            return attributes & ~attributesToRemove;
        }

        protected void gv_hr_employees_DataBinding(object sender, EventArgs e)
        {
            gv_hr_employees.DataSource = IndexDataTable;
        }

        protected void ASPxbtnxlsxexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gv_hr_employeesExporter, "الموظفين", 1, Request.GetOwinContext().Request.User.Identity.Name, gv_hr_employees.GetSelectedFieldValues("empid").Count != 0, false, "الموظفين");
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void ASPxbtndocexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gv_hr_employeesExporter, "الموظفين", 0, Request.GetOwinContext().Request.User.Identity.Name, gv_hr_employees.GetSelectedFieldValues("empid").Count != 0, false, "الموظفين");
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void ASPxbtnpdfexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gv_hr_employeesExporter, "الموظفين", 2, Request.GetOwinContext().Request.User.Identity.Name, gv_hr_employees.GetSelectedFieldValues("empid").Count != 0, false, "الموظفين");
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }

        protected void ASPxbtnprintexport_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gv_hr_employeesExporter, "الموظفين", 2, Request.GetOwinContext().Request.User.Identity.Name, gv_hr_employees.GetSelectedFieldValues("empid").Count != 0, true, "الموظفين");
            }
            catch (Exception ex)
            {
                string error_msg = ex.Message;
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception(" + error_msg + ")", true);
            }
        }
    }
}