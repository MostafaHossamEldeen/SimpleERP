using DevExpress.XtraEditors;
using Emax.Dal;
using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanSales.POS
{
    public partial class Login_frm : DevExpress.XtraEditors.XtraForm
    {
        public Login_frm()
        {
            InitializeComponent();
        }
        public static string localusername;
        public static Boolean localusertype;
        string constr = ConfigurationManager.ConnectionStrings["VanSales_pos"].ConnectionString;
        public void AddLoginData(TokenResult token)
        {
            TokenResult.dict_logindata= new Dictionary<string, object>();
            TokenResult.dict_logindata.Add("access_token", token.access_token);
            TokenResult.dict_logindata.Add("token_type", token.token_type);
            TokenResult.dict_logindata.Add("expires_in", token.expires_in.ToString());
            TokenResult.dict_logindata.Add("username", token.username);
            TokenResult.dict_logindata.Add("userid", token.userid);
            TokenResult.dict_logindata.Add("compneyname", token.compneyname);
            TokenResult.dict_logindata.Add("compvatno", token.compvatno);
            TokenResult.dict_logindata.Add("compact", token.compact);
            TokenResult.dict_logindata.Add("complogo", token.complogo);
            TokenResult.dict_logindata.Add("vattype", EmaxGlobals.NullToEmpty(token.vattype));
            TokenResult.dict_logindata.Add("vat", EmaxGlobals.NullToEmpty(token.vat));
            TokenResult.dict_logindata.Add("fyear", EmaxGlobals.NullToEmpty(token.fyear));
            TokenResult.dict_logindata.Add("branchid", EmaxGlobals.NullToEmpty(token.branchid));
            TokenResult.dict_logindata.Add("branchname", EmaxGlobals.NullToEmpty(token.branchname));
            TokenResult.dict_logindata.Add("printno", EmaxGlobals.NullToEmpty(token.printno));
            TokenResult.dict_logindata.Add("sprice", EmaxGlobals.NullToEmpty(token.sprice));
            TokenResult.dict_logindata.Add("wpitem", EmaxGlobals.NullToEmpty(token.wpitem));
            TokenResult.dict_logindata.Add("wpitemdigit", EmaxGlobals.NullToEmpty(token.wpitemdigit)); 
            TokenResult.dict_logindata.Add("advancedpaymentchartid", EmaxGlobals.NullToEmpty(token.advancedpaymentchartid));
            TokenResult.dict_logindata.Add("advancedpaymentchartcode", EmaxGlobals.NullToEmpty(token.advancedpaymentchartcode));
            TokenResult.dict_logindata.Add("advancedpaymentchartname", EmaxGlobals.NullToEmpty(token.advancedpaymentchartname));
        }
        public Task<TokenResult> Login(string userName, string password)
        {
       
            HttpClient client = new HttpClient();
            List<KeyValuePair<string, string>> values = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("grant_type","password"),
                new KeyValuePair<string, string>("username",userName),
                new KeyValuePair<string, string>("password",password)
            };
            HttpContent content = new FormUrlEncodedContent(values);

            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["apiroot"] + "/token");
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
            var result = client.PostAsync("Token", content).Result;
            if (result.IsSuccessStatusCode)
            {
                var token = result.Content.ReadAsAsync<TokenResult>().Result;
                if (!string.IsNullOrEmpty(token.access_token))
                {
                    return Task.FromResult (token);
                }
            }
            return Task.FromResult<TokenResult>(null);
        }
        private async void btn_login_Click(object sender, EventArgs e)
        {
            if (txt_UserName.Text == "" || txt_Password.Text == "")
            {
                XtraMessageBox.Show("برجاء إدخال إسم المستخدم أو كلمة المرور !؟", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_UserName.Focus();
                return;
            }
            try
            {
                if (ckb_onlineconn.Checked == true)
                {
                    //Online Conn
                    var tokenResult = await Login(txt_UserName.Text, txt_Password.Text);
                    if (tokenResult == null)
                    {
                        XtraMessageBox.Show("خطأ في اسم المستخدم أو كلمة مرور !؟", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    AddLoginData(tokenResult);
                }
                else
                {
                    //Ofline Conn
                    Dictionary<object, object> dict = new Dictionary<object, object>();
                    dict.Add("username", txt_UserName.Text);
                    dict.Add("password", txt_Password.Text);
                    var res = SqlCommandHelper.ExecuteNonQuery("sys_Login", dict, true , new List<string>{ "utype" } ,constr);
                    if (res.errorid != 0)
                    {
                        XtraMessageBox.Show(res.errormsg, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    localusername = txt_UserName.Text;
                    localusertype = Convert.ToBoolean(res.outputparams["utype"]);
                }
                this.Hide();
                MainFrom M = new MainFrom();
                M.Show();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}