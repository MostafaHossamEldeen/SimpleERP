using Emax.Dal;
using Emax.Vansales.Service.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Emax.Vansales.Service.Controllers.Purchases
{
   // [Authorize]
    public class PRequestController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/P_Request/P_DelRequest")]
        [HttpDelete]
        public IHttpActionResult P_Request([FromBody] int? reqid)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("reqid", reqid);
                var res = SqlCommandHelper.ExecuteNonQuery("p_request_del", dict, true);
                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/P_Request/P_DelRequestdtl")]
        [HttpDelete]
        public IHttpActionResult P_Requestdtl([FromBody] int? reqdtlis)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("reqdtlis", reqdtlis);
                var res = SqlCommandHelper.ExecuteNonQuery("p_reqdtls_del", dict, true);
                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("VanSalesService/Pinv/Getbranchtransferfrom")]
        public IHttpActionResult GetCustgroup()
        {
            try
            {

                var tb = SqlCommandHelper.ExcecuteToDataTableJson("sys_branch_sel").dataTable;
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
        [Route("VanSalesService/Pinv/req_trans")]
        [HttpPost]
        public IHttpActionResult addcust(trans trans)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("reqid", trans.reqid);
                dict.Add("frombranchid", trans.frombranchid);
                var res = SqlCommandHelper.ExecuteNonQuery("p_req_trans_ins", dict, true, new List<string>() { "reqaction" });
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