using System;
using System.Data;
using System.IO;
using System.Web;
using System.Web.UI;
using VanSales.Dal;


namespace VanSales.Sys
{
    public partial class sys_company : EmaxBasepage
    {
        sys_methods ms = new sys_methods();
        void bind()
        {
            DataTable dt = ms.sys_company_sel();
            txt_compname.Text = dt.Rows[0]["compname"].ToString();
            txt_compact.Text= dt.Rows[0]["compact"].ToString();
            txt_compyear.Text= dt.Rows[0]["compyear"].ToString();
            txt_complegal.Text= dt.Rows[0]["complegal"].ToString();
            txt_comptel.Text= dt.Rows[0]["comptel"].ToString();
            txt_compmob.Text= dt.Rows[0]["compmob"].ToString();
            txt_compadd.Text = dt.Rows[0]["compadd"].ToString();
            txt_compweb.Text= dt.Rows[0]["compweb"].ToString();
            txt_compemail.Text= dt.Rows[0]["compemail"].ToString();
            Image1.ImageUrl  = dt.Rows[0]["complogo"].ToString();
            txt_compmanager.Text= dt.Rows[0]["compmanager"].ToString();
            txt_compvatno.Text= dt.Rows[0]["compvatno"].ToString();
            txt_compnotes.Text= dt.Rows[0]["compnotes"].ToString();
        }
        protected override void OnInit(EventArgs e)
        {
            pageid = "11";
            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                bind();
            }
        }
        protected void upd_complogo_FileUploadComplete(object sender, DevExpress.Web.FileUploadCompleteEventArgs e)
        {
            if (e.IsValid)
            {
                Session["fileName"] = e.UploadedFile.FileNameInStorage;
                Session["filePath"] = "~/Img/Icon/" + Session["fileName"].ToString();
                e.UploadedFile.SaveAs(MapPath(Session["filePath"].ToString()));
            }
        }
        private HttpContext context;
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                string compimg = null;
                if (!Directory.Exists(Server.MapPath("~/Img/Icon/")))
                {
                    Directory.CreateDirectory(Server.MapPath("~/Img/Icon/"));
                }
                if (txt_compname.Text == ""|| txt_compname.Text == null)
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", " sweetinfo('برجاء ادخال اسم الشركه')", true);
                }
                if (Session["filePath"] != null)
                {
                    compimg = Session["filePath"].ToString();
                    Session.Remove("fileName");
                    Session.Remove("filePath");
                }
                if ((compimg == null || compimg == "") && (Image1.ImageUrl != null || Image1.ImageUrl != ""))
                {
                    compimg = Image1.ImageUrl.ToString();
                }
                (int erro_id, string error_msg) =ms.sys_company_upd(txt_compname.Text, txt_compact.Text, txt_compyear.Text, txt_complegal.Text, txt_comptel.Text, txt_compmob.Text, txt_compweb.Text, txt_compemail.Text, txt_compadd.Text, txt_compmanager.Text, txt_compvatno.Text, txt_compnotes.Text, compimg);
                Image1.ImageUrl = compimg;
                if (erro_id == 0)
                {
                    HttpCookie cookie = HttpContext.Current.Request.Cookies["Token"];

                    context = HttpContext.Current;
                    if (context != null)
                    {
                        cookie.Values.Set("compneyname", txt_compname.Text);
                        cookie.Values.Set("compact", txt_compact.Text);
                        cookie.Values.Set("complogo", compimg);
                        cookie.Values.Set("compvatno", txt_compvatno.Text);
                        context.Response.Cookies.Set(cookie);
                    }
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetsuccess('تم تحديث البيانات')", true);
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "redirectJS", "setTimeout(function() { window.location.replace('sys_company.aspx') }, 2000);", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + error_msg + "')", true);
                    return;
                }
            }
            catch (Exception ex)
            {
                string msg = HttpUtility.JavaScriptStringEncode(ex.Message);
                if (msg == "Input string was not in a correct format.")
                    msg = "برجاء التأكد من البيانات المدخله";
                ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "mykey", "sweetexception('" + msg + "')", true);
            }
        }
        protected void btn_cancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}