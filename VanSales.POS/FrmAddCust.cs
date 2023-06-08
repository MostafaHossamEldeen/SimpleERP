using DevExpress.XtraEditors;
using Emax.SharedLib;
using Emax.Vansales.Service.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanSales.POS
{
    public partial class FrmAddCust : DevExpress.XtraEditors.XtraForm
    {
        public FrmAddCust()
        {
            InitializeComponent();
        }
        public string cus_code;
        public string cus_name;
        public string cus_vat;
        public string cus_mobile;
        public string chartcode;
        public string chartid;
        private void FrmAddCust_Load(object sender, EventArgs e)
        {
            RestSharp.RestRequest restRequest = new RestSharp.RestRequest(RestSharp.Method.GET);

            //  restRequest.AddParameter("user_id", TokenResult.GetLoginData("userid").ToString());

            // RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/items/itemsearch");
            RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/inv/GetCustgroupData");//شركه الاحساس
            // restRequest.AddHeader("fyear", TokenResult.GetLoginData("fyear").ToString());
            //  restRequest.AddJsonBody(ConvertToObject());
            RestSharp.IRestResponse restResponse = restClient.Execute(restRequest);
            if (restResponse.StatusCode == HttpStatusCode.OK)
            {
                var res = restResponse.Content;

                var data = JObject.Parse(res);

                var dataTable = JsonConvert.DeserializeObject<DataTable>(data["Data"].ToString());

                cmb_cusgroup.Properties.DataSource = dataTable;


            }
        }
        internal string ConvertToObject()
        {

            cust_ins cust = new cust_ins
            {
                custname = txt_custname.Text,
                custadd = txt_cusadd.Text,
                custmob = txt_cusmob.Text,
                custvat = txt_cusvat.Text,
                sgrpid = EmaxGlobals.NullToIntZero(cmb_cusgroup.EditValue)


            };
            var custjson = JObject.Parse(JsonConvert.SerializeObject(cust));

            return JsonConvert.SerializeObject(custjson);
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (txt_custname.Text == string.Empty)
            {
                XtraMessageBox.Show("برجاء ادخال اسم العميل اولا", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cmb_cusgroup.Text == string.Empty)
            {
                XtraMessageBox.Show("برجاء اختيار  المجموعه اولا", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using (var client = new HttpClient())
            {
                RestSharp.RestRequest restRequest = new RestSharp.RestRequest(RestSharp.Method.POST);
               // RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/invoice/addcust");
                RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/invoice/addcustpos");
                // restRequest.AddHeader("fyear", TokenResult.GetLoginData("fyear").ToString());
                //restRequest.AddHeader("compvatno", TokenResult.GetLoginData("compvatno").ToString());
                restRequest.AddJsonBody(ConvertToObject());
                RestSharp.IRestResponse restResponse = restClient.Execute(restRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    cus_name = txt_custname.Text;
                    cus_vat = txt_cusvat.Text;
                    cus_mobile = txt_cusmob.Text;
                    cus_code = JObject.Parse(restResponse.Content)["Data"]["outputparams"]["custcode"].ToString();
                    chartcode = JObject.Parse(restResponse.Content)["Data"]["outputparams"]["chartcode"].ToString();
                    chartid = JObject.Parse(restResponse.Content)["Data"]["outputparams"]["id"].ToString();

                }
                this.Close();
            }
        }

        private void FrmAddCust_KeyDown(object sender, KeyEventArgs e)
        {
              if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}