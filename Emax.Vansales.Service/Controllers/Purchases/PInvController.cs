using Emax.Dal;
using Emax.SharedLib;
using Emax.Vansales.Service.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Emax.Vansales.Service.Controllers.Purchases
{
 //   [Authorize]
    public class PInvController : ApiController
    {

        [HttpPost]
        [Route("VanSalesService/P_inv/postInvStock")]  // ترحيل فواتير الشراءمستودعات
        public IHttpActionResult PostInvStock(s_inv_Post s_inv_post)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                //dict.Add("branchid", st_transactions.branchid);
                // dict.Add("post", st_transactions.post);
                //  dict.Add("posttype", st_transactions.posttype);
                dict.Add("pinvid", s_inv_post.sinvid);


                var res = SqlCommandHelper.ExcecuteToDataTableJson("p_inv_post_stock", dict, true);

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
        [Route("VanSalesService/P_inv/postInvacc")]  //ترحيل فواتير  الشراء حسابات
        public IHttpActionResult PostInvAcc(s_inv_Post s_inv_post)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                //dict.Add("branchid", st_transactions.branchid);
                // dict.Add("post", st_transactions.post);
                //  dict.Add("posttype", st_transactions.posttype);
                dict.Add("pinvid", s_inv_post.sinvid);
                dict.Add("user_name", s_inv_post.username);


                var res = SqlCommandHelper.ExecuteNonQuery("p_inv_post_acc", dict, true,new List<string>() { "voucher_no" });

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
        [Route("VanSalesService/P_inv/postrtnInvStock")]  //ترحيل فواتير مرتجع الشراء مستودعات
        public IHttpActionResult PostrtnInvStock(s_inv_Post s_inv_post)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                //dict.Add("branchid", st_transactions.branchid);
                // dict.Add("post", st_transactions.post);
                //  dict.Add("posttype", st_transactions.posttype);
                dict.Add("pinvid", s_inv_post.sinvid);


                var res = SqlCommandHelper.ExcecuteToDataTableJson("p_rtn_inv_post_stock", dict, true);

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
        [Route("VanSalesService/P_inv/postrtnInvacc")]  //ترحيل فواتير مرتجع الشراء حسابات
        public IHttpActionResult PostrtnInvAcc(s_inv_Post s_inv_post)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                //dict.Add("branchid", st_transactions.branchid);
                // dict.Add("post", st_transactions.post);
                //  dict.Add("posttype", st_transactions.posttype);
                dict.Add("pinvid", s_inv_post.sinvid);
                dict.Add("user_name", s_inv_post.username);


                var res = SqlCommandHelper.ExecuteNonQuery("p_rtninv_post_acc", dict, true, new List<string>() { "voucher_no" });

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

        [HttpGet]
        [Route("VanSalesService/P_inv/GetSuppSingalData")]
        public IHttpActionResult GetItemRow([FromUri] supp_sel_search datamodel)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("suppid", datamodel.suppid);
                var tb = SqlCommandHelper.ExcecuteToDataTableJson("p_supplier_sel_suppid", dict).dataTable;
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
        [Route("VanSalesService/P_inv/DelPinv")]
        [HttpDelete]
        public IHttpActionResult DelPinv([FromBody] int? pinvid)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("pinvid", pinvid);
                var res = SqlCommandHelper.ExecuteNonQuery("p_inv_del", dict, true);
                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/P_inv/DelDtl")]
        [HttpDelete]
        public IHttpActionResult DelDtl([FromBody] int? invdtlid)
        {
            try
            {
                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("invdtlid", invdtlid);
                var res = SqlCommandHelper.ExecuteNonQuery("p_invdtls_del", dic, true);
                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/P_inv/DelPay")]
        [HttpDelete]
        public IHttpActionResult DelPay([FromBody] int? invpayid)
        {
            try
            {
                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("invpayid", invpayid);
                var res = SqlCommandHelper.ExecuteNonQuery("P_invpay_del", dic, true, new List<string> { "payvalue" });
                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/P_inv/DelExp")]
        [HttpDelete]
        public IHttpActionResult DelExp([FromBody] int? invexpid)
        {
            try
            {
                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("invexpid", invexpid);
                var res = SqlCommandHelper.ExecuteNonQuery("p_invexp_del", dic, true);
                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/P_inv/RtnInvDelMaster")]
        [HttpDelete]
        public IHttpActionResult RtnInvDelMaster([FromBody] int? pinvid)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("pinvid", pinvid);
                var res = SqlCommandHelper.ExecuteNonQuery("p_rtninv_del", dict, true);



                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/P_inv/gRtnInvDtl")]
        [HttpDelete]
        public IHttpActionResult gRtnInvDtl([FromBody] int invdtlid)
        {
            try
            {

                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("invdtlid", invdtlid);

                var res = SqlCommandHelper.ExecuteNonQuery("p_rtn_invdtls_del", dic, true, new List<string> { "netval", "vatval", "netbvat", "payvalue" });




                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/P_inv/gRtnInvPay")]
        [HttpDelete]
        public IHttpActionResult gRInvPay([FromBody] int invpayid)
        {
            try
            {

                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("invpayid", invpayid);

                var res = SqlCommandHelper.ExecuteNonQuery("p_rtn_invpay_del", dic, true, new List<string> { "payvalue" });




                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        [HttpGet]
        [Route("VanSalesService/P_inv/GetRtninvCodeSingalData")]
        public IHttpActionResult GetrtnCodeinv([FromUri] p_invcode_sel_search datamodel)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("docno", datamodel.docno);
                var tb = SqlCommandHelper.ExcecuteToDataTableJson("p_rtn_inv_sel_invcode", dict).dataTable;
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
        [Route("VanSalesService/P_inv/ItemsPRtn")]
        public IHttpActionResult ItemspRtn([FromUri] SearchItemsPRtnModel datamodel)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("docid", EmaxGlobals.NullToEmpty(datamodel.docid));
                dict.Add("searchval", datamodel.SearchVal);

                var res = SqlCommandHelper.ExcecuteToDataTableJson("p_rtn_invdtls_search_sel", dict).dataTable;

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
    }
}
