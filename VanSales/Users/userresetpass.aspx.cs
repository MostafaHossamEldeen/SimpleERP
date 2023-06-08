using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VanSales.Models;

namespace VanSales
{
    public partial class userresetpass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void btnresetpass_Click(object sender, EventArgs e)
        {
            try
            {
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                using (ApplicationDbContext s = new ApplicationDbContext())
                {
                    var username = Request.GetOwinContext().Request.User.Identity.Name;
                    var currentuser = s.Users.Where(i => i.UserName == username).SingleOrDefault();
                    Boolean res = manager.CheckPassword(currentuser, txtcurrentpassword.Text);
                    if (res == true)
                    {
                        var userid = Request.GetOwinContext().Request.User.Identity.GetUserId();
                        manager.ChangePassword(userid.ToString(), txtcurrentpassword.Text, txtnewpassword.Text);
                        lblmsg.ForeColor = System.Drawing.Color.Green;
                        lblmsg.Text = "تم تغيير كلمة المرور بنجاح";
                        
                        Response.Redirect("~/LogOut.aspx");
                    }
                    else
                    {
                        hferror.Value = "كلمة المرور الحالية غير صحيحة";
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alertmsg1", "sweetexception('"+ hferror.Value + "')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                hferror.Value = ex.Message;
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alertmsg1", "sweetexception('" + hferror.Value + "')", true);
            }
        }
    }
}