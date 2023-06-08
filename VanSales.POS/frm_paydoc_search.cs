using DevExpress.XtraEditors;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VanSales.POS
{
    public partial class frm_paydoc_search : DevExpress.XtraEditors.XtraForm
    {
        public frm_paydoc_search()
        {
            InitializeComponent();
        }

        private void frm_paydoc_search_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            txt_search.Focus();
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RestSharp.RestRequest restRequest = new RestSharp.RestRequest(RestSharp.Method.GET);
                restRequest.AddParameter("searchval", txt_search.Text);
                restRequest.AddParameter("user_id", TokenResult.GetLoginData("userid").ToString());

                RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/pay/GetpayData");
                // restRequest.AddHeader("fyear", TokenResult.GetLoginData("fyear").ToString());
                //  restRequest.AddJsonBody(ConvertToObject());
                RestSharp.IRestResponse restResponse = restClient.Execute(restRequest);
                if (restResponse.StatusCode == HttpStatusCode.OK)
                {
                    var res = restResponse.Content;

                    var data = JObject.Parse(res);

                    var dataTable = JsonConvert.DeserializeObject<DataTable>(data["Data"].ToString());

                    gridControlsearch.DataSource = dataTable;

                }
                //Dictionary<object, object> dict = new Dictionary<object, object>();
                //dict.Add("searchval", txt_search.Text);
                //dict.Add("user_id", TokenResult.GetLoginData("userid").ToString());
                //var res = SqlCommandHelper.ExcecuteToDataTable("rec_doc_sel_search_mobile", dict, true);
                //gridControlsearch.DataSource = res.dataTable;

                //gridControlsearch.Refresh();
                //gridControlsearch.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frm_paydoc_search_KeyDown(object sender, KeyEventArgs e)
        {
            txt_search.Focus();
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                if (gridView1.RowCount > 0)
                {
                    gridView1.Focus();
                }
            }
        }
        public static DataRow rec_search;
        private void gridControlsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                var grd = sender as DevExpress.XtraGrid.GridControl;
                rec_search = ((DevExpress.XtraGrid.Views.Grid.GridView)grd.Views[0]).GetFocusedDataRow();


                this.Close();

            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void gridControlsearch_DoubleClick(object sender, EventArgs e)
        {
            var grd = sender as DevExpress.XtraGrid.GridControl;
            rec_search = ((DevExpress.XtraGrid.Views.Grid.GridView)grd.Views[0]).GetFocusedDataRow();


            this.Close();
        }
    }
}