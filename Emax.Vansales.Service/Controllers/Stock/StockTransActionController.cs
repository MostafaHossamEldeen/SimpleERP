using Emax.Dal;
using Emax.Vansales.Service.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Emax.Vansales.Service.Controllers.Stock
{
  //  [Authorize]
    public class StockTransActionController : ApiController
    {
        // GET: StockTransAction
        [HttpGet]
        [Route("VanSalesService/Stock/AddOrderSearch")]  // poup الاذون
        public IHttpActionResult Getst_transactions([FromUri] st_transactions_sel_search datamodel)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("searchval", datamodel.SearchVal);
              
                   // dict.Add("branchid", datamodel.branchid);
                
                dict.Add("transtype", datamodel.transtype);
             
                DataTable dataTable = SqlCommandHelper.ExcecuteToDataTableJson(datamodel.TableName, dict).dataTable;
                
            var data=    JsonConvert.SerializeObject(dataTable, Formatting.None, new IsoDateTimeConverter()
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
        [Route("VanSalesService/Stock/Receipt_trans")] // poup  الاذون المحوله ولم يتم استلامها
        public IHttpActionResult Getst_transactions_trans([FromUri] st_transactions_receipt_sel_search datamodel)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();

                dict.Add("transferno", datamodel.transferno);

                DataTable dataTable = SqlCommandHelper.ExcecuteToDataTableJson("st_transactions_receipt_sel_transferno", dict).dataTable;

                var data = JsonConvert.SerializeObject(dataTable, Formatting.None, new IsoDateTimeConverter()
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


        /// delete 
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/Stock/addordDelMaster")] // حذف اذن اضافه
        [HttpDelete]
        public IHttpActionResult addordDelMaster([FromBody] int? transid)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("transid", transid);
                var res = SqlCommandHelper.ExecuteNonQuery("st_transactions_del", dict, true);


                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/Stock/gAddordDtl")] // حذف تفاصيل اذن الاضافه
        [HttpDelete]
        public IHttpActionResult gAddordDtl([FromBody] int? transdtlid)
        {
            try
            {

                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("transdtlid", transdtlid);

                var res = SqlCommandHelper.ExecuteNonQuery("st_transdtls_del", dic, true);




                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }



        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/Stock/issordDelMaster")] // حذف اذن الصرف
        [HttpDelete]
        public IHttpActionResult issordDelMaster([FromBody] int? transid)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("transid", transid);
                var res = SqlCommandHelper.ExecuteNonQuery("st_transactions_issord_del", dict, true);


                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/Stock/gIssordDtl")] // حذف تفاصيل اذن الصرف
        [HttpDelete]
        public IHttpActionResult gIssordDtl([FromBody] int? transdtlid)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("transdtlid", transdtlid);
                var res = SqlCommandHelper.ExecuteNonQuery("st_transdtls_issord_del", dict, true);


                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/Stock/TransordDelMaster")] // حذف اذن التحويل
        [HttpDelete]
        public IHttpActionResult TransordDelMaster([FromBody] int? transid)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("transid", transid);
                var res = SqlCommandHelper.ExecuteNonQuery("st_transactions_trans_del", dict, true);


                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/Stock/gTransordDtl")] // حذف تفاصيل اذن التحويل
        [HttpDelete]
        public IHttpActionResult gTransordDtl([FromBody] int? transdtlid)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("transdtlid", transdtlid);
                var res = SqlCommandHelper.ExecuteNonQuery("st_transdtls_trans_del", dict, true);


                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        //[HttpGet]
        //[Route("VanSalesService/Stock/receiptSearch")]
        //public IHttpActionResult Getst_transactions_receipt([FromUri] st_transactions_sel_searchall datamodel)
        //{
        //    try
        //    {


        //        Dictionary<object, object> dict = new Dictionary<object, object>();
        //        dict.Add("searchval", datamodel.SearchVal);

        //        // dict.Add("branchid", datamodel.branchid);

        //        dict.Add("transtype", datamodel.transtype);

        //        DataTable dataTable = SqlCommandHelper.ExcecuteToDataTableJson(datamodel.TableName, dict).dataTable;

        //        var data = JsonConvert.SerializeObject(dataTable, Formatting.None, new IsoDateTimeConverter()
        //        {
        //            DateTimeFormat = "d"
        //        });

        //        return Ok(new
        //        {
        //            Data = data,


        //        });


        //    }
        //    catch (Exception ex)
        //    {

        //        return InternalServerError(ex);
        //    }

        //}
    }
}