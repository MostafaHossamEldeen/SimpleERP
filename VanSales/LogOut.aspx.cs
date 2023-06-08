using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales
{
    public partial class LogOut : System.Web.UI.Page
    {
        public void RemoveTokenToCookies()
        {
      

           var context = HttpContext.Current;
            if (context != null)
            {

                context.Response.Cookies.Remove("Token");

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var authontication = Request.GetOwinContext();
             RemoveTokenToCookies();
            authontication.Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
           
            Response.Redirect("login/login");
        }
    }
}