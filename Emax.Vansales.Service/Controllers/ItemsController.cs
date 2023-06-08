
using EMax.Dal.Context;
using EMax.Dal.Repository;
using EMax.DbModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using Emax.VanSales.Service.Dal;
using Emax.VanSales.Service.Models;
using System.Web.Http.Cors;
using Emax.Dal;
using System.Threading.Tasks;
using Emax.Core.ADO;
using Emax.Vansales.Service.Models;
using Newtonsoft.Json.Converters;
using Emax.SharedLib;
using System.Net.Http;

namespace Emax.VanSales.Service.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
  //  [Authorize]
    public class ItemsController : ApiController
    {

   
        // GET: Items
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["VanSales"].ConnectionString);
        #region تم النقل
        /*   [HttpGet]
        
        [Route("VanSalesService/items/ItemsData", Name = "ItemsData")]
        public  IHttpActionResult ItemsData(int pageNo = 1, int pageSize = 10)
        {
            try
            {

                int skip = (pageNo - 1) * pageSize;

                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("exec st_itemunit_mobile_sel", sqlConnection);

                DataTable tb = new DataTable();
                 sqlDataAdapter.Fill(tb);


                //var res= await SqlCommandHelper.ExecuteNonQuery("st_items_sel1");

                // if (res.Success!=true)
                // {
                //     return    BadRequest(res.errormsg);
                // }
                // DataTable tb1 = new DataTable("a");
                // tb1.Columns.Add("fieldname", typeof(string));
                // tb1.Columns.Add("fieldvalue", typeof(string));
                // tb1.Columns.Add("fieldvalueen", typeof(string));
                // tb1.Rows.Add(new[] { "itmname", "اسم الصنف" ,"Item Name"});
                // tb1.Rows.Add(new[] { "itmname", "اسم الصنف", "Item Name" });
                // tb1.WriteXml(@"C:/Users/PC\source/repos/VanSales/Emax.Vansales.Service/App_Data/tb1");
                // return Ok(new { data = tb1, success = res.Success });
                // Get total number of records
                int total = tb.Rows.Count;

                // Select the customers based on paging parameters
                var tborderd = tb.AsEnumerable().Select(i => new
                {
                    itemid = i.Field<int>("itemid"),
                    itemcode = i.Field<string>("itemcode"),
                    itemname = i.Field<string>("itemname"),
                    itemename = i.Field<string>("itemename"),
                    //itemdesc = i.Field<string>("itemdesc"),
                    fprice = i.Field<decimal>("fprice"),
                    unitid=i.Field<int>("unitid"),
                    unitname=i.Field<string>("unitname"),
                    sprice = i.Field<decimal?>("sprice"),
                    vat = i.Field<decimal?>("vat"),
                    factor=i.Field<decimal?>("factor"),

                    imgpath = i.Field<string>("itempic")
                }
                )
                .OrderBy(c => c.itemid)
                .Skip(skip)
                .Take(pageSize)
                ;
                string[] selectedcolumn = { "itemid" };
                // string items = VanSalesCoreMethod.DataTableToJsonObj(tborderd, selectedcolumn);
                // Get the page links
                var linkBuilder = new PageLinkBuilder(Url, "ItemsData", null, pageNo, pageSize, total);

                // Return the list of customers
                return Ok(new
                {
                    Data = tborderd,

                    Paging = new
                    {
                        First = linkBuilder.FirstPage,
                        Previous = linkBuilder.PreviousPage,
                        Next = linkBuilder.NextPage,
                        Last = linkBuilder.LastPage
                    }
                });


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }*/
        #endregion
        #region voids
        DataTable GetData(PopUpSearchModel datamodel)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("searchval", datamodel.SearchVal);
            //dict.Add("userid", Request.Headers.GetValues("userid").ElementAt(0));
           DataTable dataTable = SqlCommandHelper.ExcecuteToDataTableJson(datamodel.TableName, dict).dataTable;
            return dataTable;
        }
        #endregion
        [HttpGet]
        [Route("VanSalesService/items/FillPopup")]
        public IHttpActionResult ItemsData([FromUri]PopUpSearchModel datamodel)
        {
            try
            {
                DataTable tb = GetData(datamodel);
                var data = JsonConvert.SerializeObject(tb, Formatting.None, new IsoDateTimeConverter()
                {
                    DateTimeFormat = "d"
                });
                return Ok(new
                {
                    Data = data,

                  
                });


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Route("VanSalesService/items/ItemsRtn")]
        public IHttpActionResult ItemsRtn([FromUri] SearchItemsRtnModel datamodel)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("invid", EmaxGlobals.NullToEmpty( datamodel.invid));
                dict.Add("searchval", datamodel.SearchVal);

                var res = SqlCommandHelper.ExcecuteToDataTableJson("s_rtn_invdtls_search_sel", dict).dataTable;

                var data = JsonConvert.SerializeObject(res, Formatting.None, new IsoDateTimeConverter()
                {
                    DateTimeFormat = "d"
                });
                return Ok(new
                {
                    Data = data,


                });


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        #region تم النقل
        /*  [HttpGet]
          [Route("VanSalesService/items/itemsearch")]
          public IHttpActionResult itemsearch([FromUri] string SearchVal)
          {
              try
              {

                  Dictionary<object, object> dict = new Dictionary<object, object>();

                  dict.Add("searchval", SearchVal);

                  var tb = SqlCommandHelper.ExcecuteToDataTableJson("st_itemunit_inv_sel_pop", dict).dataTable;
                  if (tb.Rows.Count == 0)
                      return NotFound();
                  else
                  {
                      var data = JsonConvert.SerializeObject(tb, Formatting.None, new IsoDateTimeConverter()
                      {
                          DateTimeFormat = "d"
                      });
                      var json = JsonConvert.DeserializeObject(data);
                      return Ok(new
                      {
                          Data = json,


                      });
                  }
              }
              catch (Exception ex)
              {

                  return InternalServerError(ex);
              }

          }*/
        #endregion
        [HttpPost]
        [Route("VanSalesService/testtk")]
        public IHttpActionResult settest()
        {
            var f = Request.Headers.GetValues("userid").ElementAt(0);
            return Ok(new { success = true });
        }
        [HttpGet]
        [Route("VanSalesService/items/RtnInvdtlsQty")]
        public IHttpActionResult GetItemQty([FromUri] ItemQtyModel datamodel)
        {
            try
            {       
                Dictionary<object, object> dictqty = new Dictionary<object, object>();
                dictqty.Add("rtn_sinvno", datamodel.rtn_sinvno);
                dictqty.Add("sinvno", datamodel.sinvno);
                dictqty.Add("itemid", datamodel.itemid);
                dictqty.Add("actiontype", datamodel.actiontype);
                dictqty.Add("invdtlid", datamodel.invdtlid);

                var qtyinv = SqlCommandHelper.ExcecuteToDataTableJson("s_rtn_invdtls_qty_sel", dictqty).dataTable;

                var data = JsonConvert.SerializeObject(qtyinv, Formatting.None, new IsoDateTimeConverter()
                {
                    DateTimeFormat = "d"
                });
                return Ok(new
                {
                    Data = data,


                });


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Route("VanSalesService/items/ItemQtyBalance")]
        public IHttpActionResult GetItemQty([FromUri] SearchItemModel datamodel)
        {
            try
            {


            
                //if (f.Rows.Count > 0)
                //{
                //    bind_items(f.Rows[0]);

                //}

                Dictionary<object, object> dictqty = new Dictionary<object, object>();
                dictqty.Add("itemid", datamodel.itemid);
                dictqty.Add("branchid", datamodel.branchid);

                var qtyinv = SqlCommandHelper.ExcecuteToDataTableJson("st_itemwh_qty_sel", dictqty).dataTable;

                var data = JsonConvert.SerializeObject(qtyinv, Formatting.None, new IsoDateTimeConverter()
                {
                    DateTimeFormat = "d"
                });
                return Ok(new
                {
                    Data = data,
                   

                });


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        [HttpGet]
        [Route("VanSalesService/items/GetItemSingalData")]
        public IHttpActionResult GetItemRow([FromUri] SearchItemModel datamodel)
        {
            try
            {

            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("itemcode", datamodel.itemcode);
            dict.Add("barcode1", datamodel.barcode1);
           dict.Add("barcode2", datamodel.barcode2);
                var tb = SqlCommandHelper.ExcecuteToDataTableJson("st_itemunit_sel_item_code", dict).dataTable;
            var data = JsonConvert.SerializeObject(tb, Formatting.None, new IsoDateTimeConverter()
            {
                DateTimeFormat = "d"
            });
            return Ok(new
            {
                Data = data,


            });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        [HttpGet]
        [Route("VanSalesService/items/GetItemunitData")]
        public IHttpActionResult GetItemunitRow([FromUri] codeandunitsearch datamodel)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("SearchVal", datamodel.SearchVal);
                dict.Add("unitid", datamodel.unitid);

                var tb = SqlCommandHelper.ExcecuteToDataTableJson("st_itemunit_code_unit_sel", dict).dataTable;
                var data = JsonConvert.SerializeObject(tb, Formatting.None, new IsoDateTimeConverter()
                {
                    DateTimeFormat = "d"
                });
                return Ok(new
                {
                    Data = data,


                });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }


        [HttpGet]
        [Route("VanSalesService/items/GetItemSingalData_pinv")]
        public IHttpActionResult GetItemRow_P_Inv([FromUri] SearchItemModel datamodel)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("itemcode", datamodel.itemcode);
                dict.Add("barcode1", datamodel.barcode1);
                dict.Add("barcode2", datamodel.barcode2);
                var tb = SqlCommandHelper.ExcecuteToDataTableJson("st_itemunit_sel_item_code_Pinv", dict).dataTable;
                var data = JsonConvert.SerializeObject(tb, Formatting.None, new IsoDateTimeConverter()
                {
                    DateTimeFormat = "d"
                });
                return Ok(new
                {
                    Data = data,


                });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Route("VanSalesService/items/GetItemRow_request")]
        public IHttpActionResult GetItemRow_request([FromUri] SearchItemModel datamodel)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("itemcode", datamodel.itemcode);
                dict.Add("barcode1", datamodel.barcode1);
                dict.Add("barcode2", datamodel.barcode2);
                var tb = SqlCommandHelper.ExcecuteToDataTableJson("st_itemunit_sel_item_code_Pinv", dict).dataTable;
                var data = JsonConvert.SerializeObject(tb, Formatting.None, new IsoDateTimeConverter()
                {
                    DateTimeFormat = "d"
                });
                return Ok(new
                {
                    Data = data,


                });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/Item/item_manage_del")]
        [HttpDelete]
        public IHttpActionResult st_items_del([FromBody] int? itemid)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("itemid", itemid);
                var res = SqlCommandHelper.ExecuteNonQuery("st_items_del", dict, true);
                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("VanSalesService/items/GetItemSingalData_printbarcode")]
        public IHttpActionResult GetItemRow_barcode([FromUri] SearchItemModel datamodel)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("itemcode", datamodel.itemcode);
                dict.Add("barcode1", datamodel.barcode1);
                dict.Add("barcode2", datamodel.barcode2);
                var tb = SqlCommandHelper.ExcecuteToDataTableJson("st_itemunit_sel_code_barcodeprint", dict).dataTable;
                var data = JsonConvert.SerializeObject(tb, Formatting.None, new IsoDateTimeConverter()
                {
                    DateTimeFormat = "d"
                });
                return Ok(new
                {
                    Data = data,


                });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
    }
}