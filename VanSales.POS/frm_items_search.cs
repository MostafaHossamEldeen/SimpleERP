using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Emax.CoreCore;
using Emax.Dal;
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
    public partial class frm_items_search : DevExpress.XtraEditors.XtraForm
    {
        public frm_items_search()
        {
            InitializeComponent();
        }
        Inv_pos inv_Pos = new Inv_pos();
        void GetItems()
        {

            RestSharp.RestRequest restRequest = new RestSharp.RestRequest(RestSharp.Method.GET);
            restRequest.AddParameter("searchval", txt_search.Text);
            //  restRequest.AddParameter("user_id", TokenResult.GetLoginData("userid").ToString());

           // RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/items/itemsearch");
            RestSharp.RestClient restClient = new RestSharp.RestClient(ConfigurationManager.AppSettings["apiroot"].ToString() + "/VanSalesService/items/itemgroupsearch");//شركه الاحساس
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
        }
        private void frm_items_search_Load(object sender, EventArgs e)
        {
            //var dt = new DsPos.s_invdtls_selDataTable();
            //inv_Pos.gridControl1.DataSource = dt;
            txt_search.Focus();
            //Dictionary<object, object> dict = new Dictionary<object, object>();
            //dict.Add("searchval", txt_search.Text);
            //var res = SqlCommandHelper.ExcecuteToDataTable("st_itemunit_inv_sel_pop", dict, true);
            //gridControlsearch.DataSource = res.dataTable;
            GetItems();
            gridControlsearch.Refresh();
            this.KeyPreview = true;
        }
       
        private void txt_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Dictionary<object, object> dict = new Dictionary<object, object>();
                //dict.Add("searchval", txt_search.Text);
                //var res = SqlCommandHelper.ExcecuteToDataTable("st_itemunit_inv_sel_pop", dict, true);
                //gridControlsearch.DataSource = res.dataTable;
                GetItems();
                gridControlsearch.Refresh();
                gridControlsearch.Focus();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
        public static DataRow rec;
        private void gridControlsearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               
                var grd = sender as DevExpress.XtraGrid.GridControl;
                 rec = ((GridView)grd.Views[0]).GetFocusedDataRow();
               
               
                this.Close();
              
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frm_items_search_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down|| e.KeyCode == Keys.Up)
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
            rec = ((GridView)grd.Views[0]).GetFocusedDataRow();

            //var grd = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            //rec["itemcode"] = grd.GetFocusedRowCellValue("itemcode");
            //rec["itemname"] = grd.GetFocusedRowCellValue("itemname").ToString();
            //rec["unitname"] = grd.GetFocusedRowCellValue("unitname").ToString();
            //rec["fprice"] = grd.GetFocusedRowCellValue("fprice").ToString();
            //rec["vat"] = grd.GetFocusedRowCellValue("vat").ToString();
            this.Close();
        }
    }
}