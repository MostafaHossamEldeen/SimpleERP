using DevExpress.Web;
using DevExpress.Web.Internal;
using Emax.Core.Utility;
using Emax.Dal;
using Emax.SharedLib;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VanSales.Dal;
using VanSales.Models;

namespace VanSales
{
    public partial class users : EmaxBasepage
    {
       

        protected override void OnInit(EventArgs e)
        {
            pageid = "2";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Util.GenerateTokenBox("sys_branch_sel", tokentbox_userbranchs, "", "", "branchid", "branchname");
            Util.GenerateTokenBox("sys_costcenter_sel", tokentbox_usercc, "", "", "ccid", "ccname");

            using (ApplicationDbContext dbContext = new ApplicationDbContext())
            {
                gvusers.DataSource = dbContext.Users.ToList();
                gvusers.DataBind();
                if (!IsPostBack)
                {

                    //-------------


                    GridViewFormatConditionHighlight formatRule = new GridViewFormatConditionHighlight();
                    formatRule.FieldName = "addnew";
                    formatRule.Expression = "[hasnew] < 0";
                    formatRule.CellStyle.BackColor = Color.LightGray;
                    formatRule.Format = GridConditionHighlightFormat.Custom;
                    gvpermissions.FormatConditions.Add(formatRule);
                    formatRule = new GridViewFormatConditionHighlight();
                    formatRule.FieldName = "savedata";
                    formatRule.Expression = "[hassave] < 0";
                    formatRule.CellStyle.BackColor = Color.LightGray;
                    formatRule.Format = GridConditionHighlightFormat.Custom;
                    gvpermissions.FormatConditions.Add(formatRule);
                    formatRule = new GridViewFormatConditionHighlight();
                    formatRule.FieldName = "postacc";
                    formatRule.Expression = "[haspostacc] < 0";
                    formatRule.CellStyle.BackColor = Color.LightGray;
                    formatRule.Format = GridConditionHighlightFormat.Custom;
                    gvpermissions.FormatConditions.Add(formatRule);
                    formatRule = new GridViewFormatConditionHighlight();
                    formatRule.FieldName = "poststock";
                    formatRule.Expression = "[haspoststock] < 0";
                    formatRule.CellStyle.BackColor = Color.LightGray;
                    formatRule.Format = GridConditionHighlightFormat.Custom;
                    gvpermissions.FormatConditions.Add(formatRule);
                    formatRule = new GridViewFormatConditionHighlight();
                    formatRule.FieldName = "deletedata";
                    formatRule.Expression = "[hasdelete] < 0";
                    formatRule.CellStyle.BackColor = Color.LightGray;
                    formatRule.Format = GridConditionHighlightFormat.Custom;
                    gvpermissions.FormatConditions.Add(formatRule);
                    formatRule = new GridViewFormatConditionHighlight();
                    formatRule.FieldName = "allow";
                    formatRule.Expression = "[hasopen] < 0";
                    formatRule.CellStyle.BackColor = Color.LightGray;
                    formatRule.Format = GridConditionHighlightFormat.Custom;
                    gvpermissions.FormatConditions.Add(formatRule);



                    //-------------
                    Util.GenerateCombobox("sys_fillcomp_sel", cmb_rlevel, "compid,table_name", "1,sys_fillcomp", "citemid", "citemname");
                    Util.GenerateCombobox("sys_years_sel", cmb_uyearid, "", "", "yearid", "fyaer");
                    cmbuserproperty_userid.DataSource = ASPxuserspermissions.DataSource = ASPxusersresetpass.DataSource = dbContext.Users.ToList();
                    ASPxuserspermissions.DataBind();
                    ASPxusersresetpass.DataBind();
                    cmbuserproperty_userid.DataBind();
                }
            }
        }

        protected void ASPxbtnxlsxexportgvusers_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvusersExporter, "المستخدمين", 1, Request.GetOwinContext().Request.User.Identity.Name, gvusers.GetSelectedFieldValues("UserName").Count != 0, false);
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception('" + hferror.Value + "')", true);
            }
        }

        protected void ASPxbtndocexportgvusers_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvusersExporter, "المستخدمين", 0, Request.GetOwinContext().Request.User.Identity.Name, gvusers.GetSelectedFieldValues("UserName").Count != 0, false);
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception('" + hferror.Value + "')", true);
            }
        }

        protected void ASPxbtnpdfexportgvusers_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvusersExporter, "المستخدمين", 2, Request.GetOwinContext().Request.User.Identity.Name, gvusers.GetSelectedFieldValues("UserName").Count != 0, false);
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception('" + hferror.Value + "')", true);
            }
        }

        protected void ASPxbtnprintexportgvusers_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvusersExporter, "المستخدمين", 2, Request.GetOwinContext().Request.User.Identity.Name, gvusers.GetSelectedFieldValues("UserName").Count != 0, true);
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception('" + hferror.Value + "')", true);
            }
        }

        protected void ASPxbtnexpandcollapsegvusers_Click(object sender, EventArgs e)
        {
            if (ASPxbtnexpandcollapsegvusers.ImageUrl == "Img/Icon/collapse.png")
            {
                ASPxbtnexpandcollapsegvusers.ImageUrl = "Img/Icon/expand.png";
                ASPxbtnexpandcollapsegvusers.ToolTip = "إظهار التفاصيل";
                gvusers.CollapseAll();
            }
            else if (ASPxbtnexpandcollapsegvusers.ImageUrl == "Img/Icon/expand.png")
            {
                ASPxbtnexpandcollapsegvusers.ImageUrl = "Img/Icon/collapse.png";
                ASPxbtnexpandcollapsegvusers.ToolTip = "إخفاء التفاصيل";
                gvusers.ExpandAll();
            }
        }
        protected void ASPxbtnxlsxexportgvpermissions_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvpermissionsExporter, "صلاحيات المستخدمين", 1, Request.GetOwinContext().Request.User.Identity.Name, gvpermissions.GetSelectedFieldValues("pageid").Count != 0, false);
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception('" + hferror.Value + "')", true);
            }
        }

        protected void ASPxbtndocexportgvpermissions_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvpermissionsExporter, "صلاحيات المستخدمين", 0, Request.GetOwinContext().Request.User.Identity.Name, gvpermissions.GetSelectedFieldValues("pageid").Count != 0, false);
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception('" + hferror.Value + "')", true);
            }
        }

        protected void ASPxbtnpdfexportgvpermissions_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvpermissionsExporter, "صلاحيات المستخدمين", 2, Request.GetOwinContext().Request.User.Identity.Name, gvpermissions.GetSelectedFieldValues("pageid").Count != 0, false);
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception('" + hferror.Value + "')", true);
            }
        }

        protected void ASPxbtnprintexportgvpermissions_Click(object sender, EventArgs e)
        {
            try
            {
                ExportingDevExpressUtil.Export(gvpermissionsExporter, "صلاحيات المستخدمين", 2, Request.GetOwinContext().Request.User.Identity.Name, gvpermissions.GetSelectedFieldValues("pageid").Count != 0, true);
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ClientScript.RegisterStartupScript(GetType(), "Alertwarning", "sweetexception('" + hferror.Value + "')", true);
            }
        }

        protected void ASPxbtnexpandcollapsegvpermissions_Click(object sender, EventArgs e)
        {
            if (ASPxbtnexpandcollapsegvpermissions.ImageUrl == "Img/Icon/collapse.png")
            {
                ASPxbtnexpandcollapsegvpermissions.ImageUrl = "Img/Icon/expand.png";
                ASPxbtnexpandcollapsegvpermissions.ToolTip = "إظهار التفاصيل";
                gvpermissions.CollapseAll();
            }
            else if (ASPxbtnexpandcollapsegvpermissions.ImageUrl == "Img/Icon/expand.png")
            {
                ASPxbtnexpandcollapsegvpermissions.ImageUrl = "Img/Icon/collapse.png";
                ASPxbtnexpandcollapsegvpermissions.ToolTip = "إخفاء التفاصيل";
                gvpermissions.ExpandAll();
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = txtusername.Text, Email = txtmail.Text, PhoneNumber = txtphone.Text, lockaccount = false, createdate = DateTime.Now, lastlogin = null };
            IdentityResult result = manager.Create(user, txtpassword.Text);
            if (result.Succeeded)
            {
                hferror.Value = "تم حفظ المستخدم بنجاح";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "sweetsuccess('" + hferror.Value + "')", true);
                txtusername.Text = null;
                txtpassword.Text = null;
                txtconfirmpassword.Text = null;
                txtmail.Text = null;
                txtphone.Text = null;
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    gvusers.DataSource = dbContext.Users.ToList();
                    gvusers.DataBind();
                    
                        Util.GenerateCombobox("sys_fillcomp_sel", cmb_rlevel, "compid,table_name", "1,sys_fillcomp", "citemid", "citemname");
                        Util.GenerateCombobox("sys_years_sel", cmb_uyearid, "", "", "yearid", "fyaer");
                        cmbuserproperty_userid.DataSource = ASPxuserspermissions.DataSource = ASPxusersresetpass.DataSource = dbContext.Users.ToList();
                        ASPxuserspermissions.DataBind();
                        ASPxusersresetpass.DataBind();
                        cmbuserproperty_userid.DataBind();
                }
            }
            else
            {
                hferror.Value = result.Errors.FirstOrDefault();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "sweetexception('" + hferror.Value + "')", true);
            }
        }

        protected void ASPxbtnlockgvusers_Click(object sender, EventArgs e)
        {
            try
            {
                List<Object> selectusers = gvusers.GetSelectedFieldValues("UserName");
                if (selectusers.Count == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "sweetnonselect()", true);
                    return;
                }
                foreach (object selectUsername in selectusers)
                {
                    using (ApplicationDbContext applicationDbContext = new ApplicationDbContext())
                    {
                        var currentuser = applicationDbContext.Users.Where(i => i.UserName == selectUsername.ToString()).SingleOrDefault();
                        currentuser.lockaccount = true;
                        applicationDbContext.Entry(currentuser).State = System.Data.Entity.EntityState.Modified;
                        applicationDbContext.SaveChanges();
                    }
                    lblmsg.Text = null;
                    using (ApplicationDbContext dbContext = new ApplicationDbContext())
                    {
                        gvusers.DataSource = dbContext.Users.ToList();
                        gvusers.DataBind();
                        gvusers.Selection.CancelSelection();
                    }
                }
                hferror.Value = "تم حفظ التغيرات بنجاح";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "sweetsuccess('" + hferror.Value + "')", true);
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "sweetexception('" + hferror.Value + "')", true);
            }
        }

        protected void ASPxbtnunlockgvusers_Click(object sender, EventArgs e)
        {
            try
            {
                List<Object> selectusers = gvusers.GetSelectedFieldValues("UserName");
                if (selectusers.Count == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "sweetnonselect()", true);
                    return;
                }
                foreach (object selectUsername in selectusers)
                {
                    using (ApplicationDbContext applicationDbContext = new ApplicationDbContext())
                    {
                        var currentuser = applicationDbContext.Users.Where(i => i.UserName == selectUsername.ToString()).SingleOrDefault();
                        currentuser.lockaccount = false;
                        applicationDbContext.Entry(currentuser).State = System.Data.Entity.EntityState.Modified;
                        applicationDbContext.SaveChanges();
                    }
                    lblmsg.Text = null;
                    using (ApplicationDbContext dbContext = new ApplicationDbContext())
                    {
                        gvusers.DataSource = dbContext.Users.ToList();
                        gvusers.DataBind();
                        gvusers.Selection.CancelSelection();
                    }
                }
                hferror.Value = "تم حفظ التغيرات بنجاح";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "sweetsuccess('" + hferror.Value + "')", true);
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "sweetexception('" + hferror.Value + "')", true);
            }
        }

        protected void gvpermissions_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            //try
            //{
                //Sec s = new Sec();
                var updated = e.UpdateValues;
                var inserted = e.InsertValues;
                var res=new StoredExecuteResulte();
                foreach (var item in updated)
                {
                  
                        Dictionary<object, object> dict = new Dictionary<object, object>();
                    
                        dict.Add("pageid", item.Keys["pageid"]);
                        dict.Add("allow", item.NewValues["allow"]);
                        dict.Add("addnew", item.NewValues["addnew"]);
                        dict.Add("savedata", item.NewValues["savedata"]);
                        dict.Add("deletedata", item.NewValues["deletedata"]);
                        dict.Add("poststock", item.NewValues["poststock"]);
                        dict.Add("postacc", item.NewValues["postacc"]);
                        dict.Add("pageUserName", ASPxuserspermissions.SelectedItem.Value);

                        res=SqlCommandHelper.ExecuteNonQuery("sys_urpages_ins", dict);
                       // s.sys_urpages_ins(ASPxuserspermissions.SelectedItem.Value.ToString(), Convert.ToInt32(k));
                
                    //else
                    //{
                    //    var k = item.Keys["pageid"];
                    //    s.sys_urpages_del(ASPxuserspermissions.SelectedItem.Value.ToString(), Convert.ToInt32(k));
                    //}
                }
                //----------
                foreach (var item in inserted)
                {

                    Dictionary<object, object> dict = new Dictionary<object, object>();

                    dict.Add("pageid", item.NewValues["pageid"]);
                    dict.Add("allow", item.NewValues["allow"]);
                    dict.Add("addnew", item.NewValues["addnew"]);
                    dict.Add("savedata", item.NewValues["savedata"]);
                    dict.Add("deletedata", item.NewValues["deletedata"]);
                    dict.Add("poststock", item.NewValues["poststock"]);
                    dict.Add("postacc", item.NewValues["postacc"]);
                    dict.Add("pageUserName", ASPxuserspermissions.SelectedItem.Value);


                    res = SqlCommandHelper.ExecuteNonQuery("sys_urpages_ins", dict);
                   // s.sys_urpages_ins(ASPxuserspermissions.SelectedItem.Value.ToString(), Convert.ToInt32(k));

                    //else
                    //{
                    //    var k = item.Keys["pageid"];
                    //    s.sys_urpages_del(ASPxuserspermissions.SelectedItem.Value.ToString(), Convert.ToInt32(k));
                    //}
                }
            e.Handled = true;
           // gvpermissions.DataBind();

            //SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["VanSales"].ConnectionString);
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("exec sys_urpages_sel " + ASPxuserspermissions.SelectedItem.Value, sqlConnection);
            //DataTable dt = new DataTable();
            //sqlDataAdapter.Fill(dt);
            //gvpermissions.DataSource = dt;
            //if (res.errorid==0)
            //{
            //   // gvpermissions.DataBind();
            //    //e.Handled = true;
            //    gvpermissions.JSProperties["cperrors"] = "تم حفظ التغيرات بنجاح";
            //    gvpermissions.JSProperties["cpicon"] = "success";
            //}

            //}
            //catch (Exception ex)
            //{
            //    gvpermissions.JSProperties["cperrors"] = ex.Message;
            //    gvpermissions.JSProperties["cpicon"] = "error";
            //}
        }

        protected void ASPxuserspermissions_ValueChanged(object sender, EventArgs e)
        {
            
            gvpermissions.DataBind();
        }
        void GetTable()
        {
            DataTable dt = new DataTable();
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("pageusername", (ASPxuserspermissions.SelectedItem == null ? DBNull.Value.ToString() : EmaxGlobals.NullToEmpty(ASPxuserspermissions.SelectedItem.Value)));
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["VanSales"].ConnectionString);
            dt = SqlCommandHelper.ExcecuteToDataTable("sys_urpages_sel", dict).dataTable;
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("exec sys_urpages_sel @username " +  (ASPxuserspermissions.SelectedItem==null?DBNull.Value.ToString():EmaxGlobals.NullToEmpty( ASPxuserspermissions.SelectedItem.Value)), sqlConnection);
            //sqlDataAdapter.Fill(dt);
            gvpermissions.DataSource= dt;
           
        }
        protected void btnresetpass_Click(object sender, EventArgs e)
        {
            try
            {

                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var userid = ASPxusersresetpass.SelectedItem.Value;
                var usertoken = manager.GeneratePasswordResetToken(userid.ToString());
                manager.ResetPassword(userid.ToString(), usertoken, txtresetpassword.Text);
                hferror.Value = "تم تغيير كلمة المرور بنجاح";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "sweetsuccess('" + hferror.Value + "')", true);
            }
            catch (Exception ex)
            {
                hferror.Value = ex.ToString();
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "sweetexception('" + hferror.Value + "')", true);
            }
        }

        protected void gvpermissions_DataBinding(object sender, EventArgs e)
        {
             GetTable();
        }

        protected void btnsave_userproperty_Click(object sender, EventArgs e)
        {
            if (txt_empid.Text == "")
            {
                hf_empid.Value = string.Empty;
            }

            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("userbranchs", tokentbox_userbranchs.Value);
            dict.Add("usercc", tokentbox_usercc.Value);
            dict.Add("udiscperitem", EmaxGlobals.NullToIntZero(txt_udiscperitem.Text));
            dict.Add("uyearid", cmb_uyearid.Value);
            dict.Add("uyear", cmb_uyearid.Text);
            dict.Add("empid", EmaxGlobals.NullToNullInt(hf_empid.Value));
            dict.Add("user_id", cmbuserproperty_userid.Value);
            var res = SqlCommandHelper.ExecuteNonQuery("sys_userpre_ins", dict, true);
            if (res.errorid == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "sweetsuccess('" + res.errormsg + "')", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "sweetexception('" + res.errormsg + "')", true);
            }
        }

        protected void btnuser_prep_ins_all_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("pageusername", ASPxuserspermissions.SelectedItem.Value);
                var res = SqlCommandHelper.ExecuteNonQuery("sys_urpages_ins_all", dict, true);
                if (res.errorid == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "sweetsuccess('تم حفظ صلاحيات المستخدم')", true);
                    gvpermissions.DataBind();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "sweetexception('" + res.errormsg + "')", true);
                    gvpermissions.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "sweetexception('" + ex.Message + "')", true);
            }
        }

        protected void btnsave_cmb_rlevel_Click(object sender, EventArgs e)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("pageusername", cmbuserproperty_userid.SelectedItem.Text);
                dict.Add("rlevel", cmb_rlevel.Value);
                var res = SqlCommandHelper.ExecuteNonQuery("sys_urpages_ins_model", dict, true);
                if (res.errorid == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "sweetsuccess('تم حفظ مستوى صلاحيات المستخدم')", true);
                    gvpermissions.DataBind();
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "sweetexception('" + res.errormsg + "')", true);
                    gvpermissions.DataBind();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "alert", "sweetexception('" + ex.Message + "')", true);
            }
        }
    }
}