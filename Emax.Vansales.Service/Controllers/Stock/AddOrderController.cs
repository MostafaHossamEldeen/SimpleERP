using Emax.Dal;
using Emax.Vansales.Service.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Emax.Vansales.Service.Controllers.Stock
{
   // [Authorize]
    public class AddOrderController : ApiController
    {

        [HttpPost]
        [Route("VanSalesService/Stock/PostAddOrderStock")]  //ترحيل اذن اضافه
        public IHttpActionResult PostAddOrdertransactions( st_transactions_Post st_transactions)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                //dict.Add("branchid", st_transactions.branchid);
               // dict.Add("post", st_transactions.post);
              //  dict.Add("posttype", st_transactions.posttype);
                dict.Add("transid", st_transactions.transid);
             

                var res = SqlCommandHelper.ExcecuteToDataTableJson("st_transactions_st_edit_add_ord_post_stock", dict,true);

                //var data = JsonConvert.SerializeObject(res, Formatting.None, new IsoDateTimeConverter()
                //{
                //    DateTimeFormat = "d"
                //});

                return Ok(new
                {
                    Data = res

                 
                });


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        [HttpPost]
        [Route("VanSalesService/Stock/PostAddTransOrderAcc")] // ترحيل اذن اضافه حسابات
        public IHttpActionResult PostTransOrdertransactionsAcc(st_transactions_Post st_transactions)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("chartidto", st_transactions.chartidto);
                dict.Add("chartidfrom", st_transactions.chartidfrom);
                dict.Add("transid", st_transactions.transid);
                dict.Add("user_name", st_transactions.username);


                var res = SqlCommandHelper.ExecuteNonQuery("st_transaction_add_post_acc", dict, true, new List<string>() { "voucher_no" });

                //var data = JsonConvert.SerializeObject(res, Formatting.None, new IsoDateTimeConverter()
                //{
                //    DateTimeFormat = "d"
                //});

                return Ok(new
                {
                    Data = res


                });


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
    
        [HttpPost]
        [Route("VanSalesService/Stock/PostIssOrderStock")] //ترحيل أذن صرف
        public IHttpActionResult PostIssOrdertransactions(st_transactions_Post st_transactions)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                //dict.Add("branchid", st_transactions.branchid);
              //  dict.Add("post", st_transactions.post);
                //  dict.Add("posttype", st_transactions.posttype);
                dict.Add("transid", st_transactions.transid);


                var res = SqlCommandHelper.ExcecuteToDataTableJson("st_transactions_st_edit_issord_post_stock", dict, true);

                //var data = JsonConvert.SerializeObject(res, Formatting.None, new IsoDateTimeConverter()
                //{
                //    DateTimeFormat = "d"
                //});

                return Ok(new
                {
                    Data = res


                });


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        [HttpPost]
        [Route("VanSalesService/Stock/PostIssOrderAcc")] // ترحيل اذن صرف حسابات
        public IHttpActionResult PostIssOrdertransactionsAcc(st_transactions_Post st_transactions)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("chartidto", st_transactions.chartidto);
                dict.Add("chartidfrom", st_transactions.chartidfrom);
                dict.Add("transid", st_transactions.transid);
                dict.Add("user_name", st_transactions.username);


                var res = SqlCommandHelper.ExecuteNonQuery("st_transaction_issord_post_acc", dict, true, new List<string>() { "voucher_no" });

                //var data = JsonConvert.SerializeObject(res, Formatting.None, new IsoDateTimeConverter()
                //{
                //    DateTimeFormat = "d"
                //});

                return Ok(new
                {
                    Data = res


                });


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        [HttpPost]
        [Route("VanSalesService/Stock/PostTransOrderStock")] //ترحيل اذن تحويل
        public IHttpActionResult PostTransOrdertransactions(st_transactions_Post st_transactions)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                //dict.Add("branchid", st_transactions.branchid);
              
                //  dict.Add("posttype", st_transactions.posttype);
                dict.Add("transid", st_transactions.transid);


                var res = SqlCommandHelper.ExcecuteToDataTableJson("st_transactions_st_Trans_ord_post_stock", dict, true);

                //var data = JsonConvert.SerializeObject(res, Formatting.None, new IsoDateTimeConverter()
                //{
                //    DateTimeFormat = "d"
                //});

                return Ok(new
                {
                    Data = res


                });


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [HttpPost]
        [Route("VanSalesService/Stock/PostTransOrderAcc")] // ترحيل اذن تحويل حسابات
        public IHttpActionResult PostOrdertransactionsAcc(st_transactions_Post st_transactions)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                //dict.Add("branchid", st_transactions.branchid);

                //  dict.Add("posttype", st_transactions.posttype);
                dict.Add("transid", st_transactions.transid);
                dict.Add("user_name", st_transactions.username);


                var res = SqlCommandHelper.ExecuteNonQuery("st_transaction_trans_post_acc", dict, true, new List<string>() { "voucher_no" });

                //var data = JsonConvert.SerializeObject(res, Formatting.None, new IsoDateTimeConverter()
                //{
                //    DateTimeFormat = "d"
                //});

                return Ok(new
                {
                    Data = res


                });


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        [HttpPost]
        [Route("VanSalesService/Stock/PostReceiptOrderStock")] //ترحيل اذن استلام
        public IHttpActionResult PostReceiptOrdertransactions(st_transactions_Post st_transactions)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                //dict.Add("branchid", st_transactions.branchid);
               // dict.Add("post", st_transactions.post);
                //  dict.Add("posttype", st_transactions.posttype);
                dict.Add("transid", st_transactions.transid);


                var res = SqlCommandHelper.ExcecuteToDataTableJson("st_transactions_st_Receipt_transfer_post_stock", dict, true);

                //var data = JsonConvert.SerializeObject(res, Formatting.None, new IsoDateTimeConverter()
                //{
                //    DateTimeFormat = "d"
                //});

                return Ok(new
                {
                    Data = res


                });


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
    }
}
