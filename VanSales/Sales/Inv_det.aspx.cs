using DevExpress.Web;
using Emax.Dal;
using Emax.SharedLib;
using Newtonsoft.Json;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.Sales
{
    public partial class Inv_det : System.Web.UI.Page
    {
        protected void None_Init(object sender, EventArgs e)
        {
            ASPxHyperLink link = sender as ASPxHyperLink;
            GridViewDataItemTemplateContainer cont = link.NamingContainer as GridViewDataItemTemplateContainer;
           
                link.ClientSideEvents.Click = String.Format("function(s,e){{showpopup(s,e,{0});}}", cont.VisibleIndex);
        }

        protected  void Page_Load(object sender, EventArgs e)
        {

            
            //GridViewDataComboBoxColumn comboitemcode = gvs_invdtlsquick.Columns["itemcode"] as GridViewDataComboBoxColumn;
            //comboitemcode.PropertiesComboBox.ValueType = typeof(int);
            //comboitemcode.PropertiesComboBox.IncrementalFilteringMode = IncrementalFilteringMode.Contains;
            //comboitemcode.PropertiesComboBox.Columns.Add("itemcode", "كود الصنف", Unit.Pixel(50));
            //comboitemcode.PropertiesComboBox.Columns.Add("itemname", "اسم الصنف الصنف", Unit.Pixel(150));
            //comboitemcode.PropertiesComboBox.Columns.Add("unitid", "اسم الصنف الصنف",0);
            //comboitemcode.PropertiesComboBox.Columns.Add("unitname","",0);
            //comboitemcode.PropertiesComboBox.Columns.Add("fprice", "",0);
            //comboitemcode.PropertiesComboBox.Columns.Add("vat", "", 0);
            //comboitemcode.PropertiesComboBox.DataSource = await SqlCommandHelper.ExcecuteAsyncToDataTable("st_items_sel_search");
            //comboitemcode.PropertiesComboBox.TextField = "itemname";
            //comboitemcode.PropertiesComboBox.ValueField = "itemid";
            //comboitemcode.PropertiesComboBox.CallbackPageSize = 5;
            //comboitemcode.PropertiesComboBox.DropDownRows = 5;
            //comboitemcode.PropertiesComboBox.TextFormatString = "{0}";

            //comboitemcode.PropertiesComboBox.ClearButton.DisplayMode = ClearButtonDisplayMode.OnHover;
            //comboitemcode.PropertiesComboBox.EnableCallbackMode = true;


            //unitid
            //GridViewDataComboBoxColumn combounit = gvs_invdtlsquick.Columns["unitid"] as GridViewDataComboBoxColumn;
            //combo.PropertiesComboBox.ValueType = typeof(int);
            //combo.PropertiesComboBox.IncrementalFilteringMode = IncrementalFilteringMode.Contains;
            //combo.PropertiesComboBox.DataSource = await SqlCommandHelper.ExcecuteToDataTable("st_unit_sel");
            //combo.PropertiesComboBox.TextField = "unitid";
            //combo.PropertiesComboBox.ValueField = "unitname";
            //combo.PropertiesComboBox.CallbackPageSize = 5;
            //combo.PropertiesComboBox.DropDownRows = 5;
            //
            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://192.168.1.254:35/");
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //    invnum.Value = Request.QueryString["invid"] != null && Request.QueryString["invid"].Length != 0 ? Request.QueryString["invid"] : null;
            //    DataTable dt = new DataTable();
            //    if (invnum.Value != null)
            //    {


            //        HttpResponseMessage response = await client.GetAsync("/VanSalesService/invoice/Getinvdetbyid?sinvid=" + Request.QueryString["invid"]);
            //        var f = await response.Content.ReadAsStringAsync();
            //        if (response.IsSuccessStatusCode)
            //        {
            //            var g = await response.Content.ReadAsStreamAsync();

            //            dt = (DataTable)JsonConvert.DeserializeObject(f, typeof(DataTable)); //(DataTable)new JavaScriptSerializer().Deserialize<DataTable> (f);


            //        }
            //        else if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            //        {
            //            dt = convertStringToDataTable(f);
            //        }

            //    }
            var sinvid = Request.QueryString["invid"] != null && Request.QueryString["invid"].Length != 0 ? Request.QueryString["invid"] : null;
            invnum.Value = Request.QueryString["invno"] != null && Request.QueryString["invno"].Length != 0 ? Request.QueryString["invno"] : null;
            var res =  FillGrid(sinvid);

            gvs_invdtlsquick.DataSource = res.dataTable;
            invid.Value = EmaxGlobals.NullToEmpty(sinvid);
             gvs_invdtlsquick.DataBind();


            //}
         
        }
         StoredExecuteResulte FillGrid(string sinvid)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("sinvid", sinvid);
            return  SqlCommandHelper.ExcecuteToDataTable("s_invdtls_sel", dict); 
            
        }
        //public static DataTable convertStringToDataTable(string data)
        //{
        //    DataTable dataTable = new DataTable();
        //    bool columnsAdded = false;
        //    foreach (string row in data.Split('\n'))
        //    {
        //        DataRow dataRow = dataTable.NewRow();
        //        string[] cell = row.Split(',');
        //        for (int i = 0; i < cell.Length; i++)
        //        {
        //            string[] keyValue = cell[i].Split('"');
        //            if (!columnsAdded)
        //            {
        //                DataColumn dataColumn = new DataColumn();
        //                dataTable.Columns.Add(dataColumn);
        //            }
        //            dataRow[i] = keyValue[1];
        //        }
        //        columnsAdded = true;
        //        dataTable.Rows.Add(dataRow);
        //    }
        //    return dataTable;
        //}
        public static DataTable convertStringToDataTable(string data)
        {
            DataTable dataTable = new DataTable();
            bool columnsAdded = false;
            foreach (string row in data.Split('\n'))
            {
                DataRow dataRow = dataTable.NewRow();
                var cel = row.Replace(@"\", "");
                cel = cel.Replace("[", "");
                cel = cel.Replace("]", "");
                cel = cel.Replace('"', '"');
                string[] cell = cel.Split(',');
                for (int i = 0; i < cell.Length; i++)
                {
                    string keyValue = cell[i].Replace("\"", "");
                    //keyValue = cell[i].Replace("/", "");
                    if (!columnsAdded)
                    {
                        DataColumn dataColumn = new DataColumn();
                        dataColumn.ColumnName = keyValue;
                        dataTable.Columns.Add(dataColumn);
                    }
                    //dataRow[i] = keyValue[1];
                }
                columnsAdded = true;
                //dataTable.Rows.Add(dataRow);
            }
            return dataTable;
        }
        protected  void gvs_invdtlsquick_RowUpdated(object sender, DevExpress.Web.Data.ASPxDataUpdatedEventArgs e)
        {

            //if (e.NewValues["itemcode"]!=null && e.NewValues["itemcode"].ToString().Length!=0)
            //{
            //    Dictionary<string, object> dict = new Dictionary<string, object>();
            //    dict.Add("@itemid", e.NewValues["itemcode"]);
            //    var dt = await SqlCommandHelper.ExcecuteAsyncToDataTable("st_items_sel_search");
            //    if (dt.Rows.Count!=0)
            //    {
            //        e.NewValues["vatvalue"]=Convert.ToDecimal(e.NewValues["netvalue"])* (dt.Rows[0]["vat"]==null?0:Math.Round(Convert.ToDecimal(dt.Rows[0]["vat"])/100,3));
            //    }
            //}
           
        }
        
        protected  void gvs_invdtlsquick_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
        


        }

        protected  void gvs_invdtlsquick_RowUpdating(object sender, DevExpress.Web.Data.ASPxDataUpdatingEventArgs e)
        {
         
            e.Cancel = true;
        }

        protected void gvs_invdtlsquick_CellEditorInitialize(object sender, ASPxGridViewEditorEventArgs e)
        {
           
        }

        protected  void chckedit_ValueChanged(object sender, EventArgs e)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("@itemid",((TextBox)sender).Text);
             StoredExecuteResulte res =  SqlCommandHelper.ExcecuteAsyncToDataTable("st_items_sel_search");
            if (res.dataTable.Rows.Count != 0)
            {
               vatval.Value = (Convert.ToDecimal(netval.Value) * (res.dataTable.Rows[0]["vat"] == null ? 0 : Math.Round(Convert.ToDecimal(res.dataTable.Rows[0]["vat"]) / 100, 3))).ToString();
            }
        }

        protected  void gvs_invdtlsquick_CustomJSProperties(object sender, ASPxGridViewClientJSPropertiesEventArgs e)
        {
            //var d = sender as ASPxGridView;
            //var code=d.GetRowValues(d.FocusedRowIndex, "itemcode");
            //if (code!= null)
            //{
            //    Dictionary<string, object> dict = new Dictionary<string, object>();
            //    dict.Add("@itemid", code);
            //    var dt = SqlCommandHelper.ExcecuteToDataTable("st_items_sel_scalare", dict);
            //    if (dt.Rows.Count != 0)
            //    {
            //        e.Properties["cpitmvat"] = (dt.Rows[0]["vat"] == null ? 0 : Math.Round(Convert.ToDecimal(dt.Rows[0]["vat"]) / 100, 3));
            //    }
            //}

        }

        protected void gvs_invdtlsquick_RowInserting(object sender, DevExpress.Web.Data.ASPxDataInsertingEventArgs e)
        {
           e.Cancel = true;
        }

        protected void gvs_invdtlsquick_RowDeleting(object sender, DevExpress.Web.Data.ASPxDataDeletingEventArgs e)
        {
            e.Cancel = true;
        }

        protected  void gvs_invdtlsquick_DataBinding(object sender, EventArgs e)
        {
           
           
        }

        protected void gvs_invdtlsquick_RowInserted(object sender, DevExpress.Web.Data.ASPxDataInsertedEventArgs e)
        {
            e.NewValues["invdtlid"] = 0;
        }

        protected void gvs_invdtlsquick_InitNewRow(object sender, DevExpress.Web.Data.ASPxDataInitNewRowEventArgs e)
        {
            e.NewValues["invdtlid"] = 0;
            e.NewValues["qty"] = 1;
        }
    }
}