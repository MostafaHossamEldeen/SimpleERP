using Emax.SharedLib;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using VanSales.Models;

namespace VanSales.login
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserName.Focus();
        }
        public  async  Task<TokenResult> Login(string userName, string password)
        {
            HttpClient client=new HttpClient();
        List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type","password"),
                new KeyValuePair<string, string>("username",userName),
              
                new KeyValuePair<string, string>("password",password)
            };
            HttpContent content = new FormUrlEncodedContent(values);

            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiroot"]+"/token");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));


            var result =  client.PostAsync("Token", content).Result;
            if (result.IsSuccessStatusCode)
            {
                var token =  result.Content.ReadAsAsync<TokenResult>().Result;
            
                    return token;
                

            }
            else
            {
                TokenResult token = new TokenResult() { error =await result.Content.ReadAsStringAsync() };
                return token;
            }

           
        }
        private HttpContext context;
        public void AddTokenToCookies(TokenResult token)
        {
            HttpCookie cookie = new HttpCookie("Token");

            context =  HttpContext.Current;
            if (context != null)
            {
                cookie.Values.Add("access_token", token.access_token);
                cookie.Values.Add("token_type", token.token_type);
                cookie.Values.Add("expires_in", token.expires_in.ToString());
                cookie.Values.Add("userName", token.username);
                cookie.Values.Add("userId", token.userid);
                cookie.Values.Add("compneyname", token.compneyname);
                cookie.Values.Add("compvatno", token.compvatno);
                cookie.Values.Add("compact", token.compact);
                cookie.Values.Add("complogo", token.complogo);
                cookie.Values.Add("vattype", EmaxGlobals.NullToEmpty(token.vattype));
                cookie.Values.Add("vat",EmaxGlobals.NullToEmpty(token.vat));
                cookie.Values.Add("autoitem",EmaxGlobals.NullToEmpty(token.autoitem));
                cookie.Values.Add("autoemp", EmaxGlobals.NullToEmpty(token.autoemp));
                cookie.Values.Add("fyear", EmaxGlobals.NullToEmpty(token.fyear));
                cookie.Values.Add("printno", EmaxGlobals.NullToEmpty(token.printno));
                cookie.Values.Add("sprice", EmaxGlobals.NullToEmpty(token.sprice));
                cookie.Values.Add("wpitem", EmaxGlobals.NullToEmpty(token.wpitem));
                cookie.Values.Add("wpitemdigit", EmaxGlobals.NullToEmpty(token.wpitemdigit));
                cookie.Values.Add("udiscperitem", EmaxGlobals.NullToEmpty(token.udiscperitem));
                // cookie.Values.Add("branchid", EmaxGlobals.NullToEmpty(token.branchid));
                cookie.Expires = DateTime.Now.AddDays(1);
                context.Response.Cookies.Add(cookie);
            }
        }
        protected  void Btnlogin_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            try
            {
                using (ApplicationDbContext dbContext = new ApplicationDbContext())
                {
                    var loggeduser = dbContext.Users.SingleOrDefault(i => i.UserName == UserName.Text);
                    if (loggeduser != null && loggeduser.lockaccount == true)
                    {
                        StatusText.Text = "المستخدم الخاص بك مغلق !؟";
                        return;
                    }
                    else
                    {
                        var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();
                        var result = signinManager.PasswordSignIn(UserName.Text, Password.Text, ckbremmber.Checked, shouldLockout: false);
                        switch (result)
                        {
                            case SignInStatus.Success:
                                using (ApplicationDbContext applicationDbContext = new ApplicationDbContext())
                                {
                                    var currentuser = applicationDbContext.Users.Where(i => i.UserName == UserName.Text).SingleOrDefault();
                                    currentuser.lastlogin = DateTime.Now;
                                    applicationDbContext.Entry(currentuser).State = System.Data.Entity.EntityState.Modified;
                                    applicationDbContext.SaveChanges();
                                }
                                var tokenResult = Login(UserName.Text, Password.Text).Result;
                                if (tokenResult.error!=null)
                                {
                                    StatusText.Text = tokenResult.error;
                                    return;
                                }
                                AddTokenToCookies(tokenResult);
                                Response.Write(tokenResult);
                                IdentityHelper.RedirectToReturnUrl("~/", Response);


                                break;
                            case SignInStatus.LockedOut:
                                Response.Redirect("/Account/Lockout");
                                break;
                            case SignInStatus.RequiresVerification:
                                Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", Request.QueryString["ReturnUrl"], false), true);
                                break;
                            case SignInStatus.Failure:
                                StatusText.Text = "خطأ في اسم المستخدم أو كلمة مرور !؟";
                                break;
                            default:
                                StatusText.Text = "محاولة تسجيل الدخول غير صحيحة";
                                break;
                        }
                    }
                }
            }

            catch (ThreadAbortException ex)
            {
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                // IGNORE: this is normal behavior for Redirect method
            }
            catch (Exception ex)
            {
                StatusText.Text = ex.ToString();
            }
        }
    }
}