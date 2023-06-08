using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Emax.Dal;
using Emax.SharedLib;
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
    public partial class Frm_CustChart : DevExpress.XtraEditors.XtraForm
    {
        public Frm_CustChart()
        {
            InitializeComponent();
        }
        public string chart_code;
        public string chart_name;
        public int chart_id;
        private void Frm_CustChart_Load(object sender, EventArgs e)
        {
            txt_search.Focus();
            RestSharp.RestRequest restRequest = new RestSharp.RestRequest(RestSharp.Method.GET);
            restRequest.AddParameter("searchval", txt_search.Text);
            restRequest.AddParameter("legertype", 1);
            restRequest.AddParameter("TableName", "gl_chart_sel_pop");
            RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/Vouchers/chartSearch");
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
            //dict.Add("legertype", 1);
            //var res = SqlCommandHelper.ExcecuteToDataTable("gl_chart_sel_pop", dict, true);
            //gridControlsearch.DataSource = res.dataTable;
            //gridControlsearch.Refresh();
            this.KeyPreview = true;
        }

        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RestSharp.RestRequest restRequest = new RestSharp.RestRequest(RestSharp.Method.GET);
                restRequest.AddParameter("searchval", txt_search.Text);
                restRequest.AddParameter("legertype", 1);
                restRequest.AddParameter("TableName", "gl_chart_sel_pop");
                RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/Vouchers/chartSearch");
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
                //dict.Add("legertype", 1);
                //var res = SqlCommandHelper.ExcecuteToDataTable("gl_chart_sel_pop", dict, true);
                //gridControlsearch.DataSource = res.dataTable;

                //gridControlsearch.Refresh();
                //gridControlsearch.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
 

        private void gridControlsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                var grd = sender as DevExpress.XtraGrid.GridControl;
                var currentselected = ((GridView)grd.Views[0]).GetFocusedDataRow();
               chart_code = currentselected.ItemArray[1].ToString();
                chart_name = currentselected.ItemArray[2].ToString();
                chart_id = EmaxGlobals.NullToIntZero( currentselected.ItemArray[0]);
                
                this.Close();

            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Frm_CustChart_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up)
            {
                if (gv_search.RowCount > 0)
                {
                    gv_search.Focus();
                }
            }
        }

        private void gridControlsearch_DoubleClick(object sender, EventArgs e)
        {
            var grd = sender as DevExpress.XtraGrid.GridControl;
            var currentselected = ((GridView)grd.Views[0]).GetFocusedDataRow();
            chart_code = currentselected.ItemArray[1].ToString();
            chart_name = currentselected.ItemArray[2].ToString();
            chart_id = EmaxGlobals.NullToIntZero(currentselected.ItemArray[0]);

            this.Close();
        }
    }
}