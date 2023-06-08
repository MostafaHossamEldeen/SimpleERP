using DevExpress.Web;
using Emax.Dal;
using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace VanSales
{
    public partial class SiteMaster : MasterPage
    {
        string[] btnnames = { "btn_addnew", "btn_save", "btn_postst", "btn_postacc", "btn_delete" };
        protected void Page_Load(object sender, EventArgs e)
        {
            lblname.Text = Request.GetOwinContext().Request.User.Identity.Name;
            lblcount.Text = Application["TotalOnlineUsers"].ToString(); ;
            lbldte.Text = DateTime.Now.ToShortDateString();
            if (!HttpContext.Current.Request.Cookies.AllKeys.Contains("Token") || EmaxGlobals.NullToEmpty(HttpContext.Current.Request.Cookies["Token"].Value) == "")
            {
                Response.Redirect("~/logout");
            }
            else
            {
                lblcompenyname.Text = SqlCommandHelper.GetTokenKey("compneyname", HttpContext.Current.Request.Cookies["Token"].Value);
                lblcompney_job.Text = SqlCommandHelper.GetTokenKey("compact", HttpContext.Current.Request.Cookies["Token"].Value);
                lblfyear.Text = SqlCommandHelper.GetTokenKey("fyear", HttpContext.Current.Request.Cookies["Token"].Value);

            }
            GenerateGrantee();
            //var nn = Controls;mainfrm.FindControl

        }
        void GenerateGrantee() {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("username", Request.GetOwinContext().Request.User.Identity.Name);
         
            if (Page.GetType().BaseType.BaseType == typeof(EmaxBasepage)  || Page.GetType().BaseType == typeof(EmaxBasepage))
            {
                if (((EmaxBasepage)(Page)).pageid != "5000000")
                {


                    dict.Add("pageid", ((EmaxBasepage)(Page)).pageid);


                    var tb = SqlCommandHelper.ExcecuteToDataTable("sys_urpages_sel_single", dict).dataTable;
                    if (tb.Rows.Count != 0)
                    {
                        bool haspermission = EmaxGlobals.NullToBool(tb.Rows[0]["allow"]);
                        if (!haspermission)
                        {
                            Response.Redirect("~/NotAuthorize");
                        }
                        else
                        {
                            if (MainContent.FindControl("btn_addnew") != null) { ((ASPxButton)MainContent.FindControl("btn_addnew")).Visible = EmaxGlobals.NullToBool(tb.Rows[0]["addnew"]); }
                            if (MainContent.FindControl("btn_save") != null) { ((ASPxButton)MainContent.FindControl("btn_save")).Visible = EmaxGlobals.NullToBool(tb.Rows[0]["savedata"]); }
                            if (MainContent.FindControl("btn_delete") != null) { ((ASPxButton)MainContent.FindControl("btn_delete")).Visible = EmaxGlobals.NullToBool(tb.Rows[0]["deletedata"]); }
                            if (MainContent.FindControl("btn_postst") != null) { ((ASPxButton)MainContent.FindControl("btn_postst")).Visible = EmaxGlobals.NullToBool(tb.Rows[0]["poststock"]); };
                            if (MainContent.FindControl("btn_postacc") != null) { ((ASPxButton)MainContent.FindControl("btn_postacc")).Visible = EmaxGlobals.NullToBool(tb.Rows[0]["postacc"]); };
                        }
                    }
                    else
                    {
                        Response.Redirect("~/NotAuthorize");
                    }
                }
            }
           
        
        }
    }
}