using Emax.Dal;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Emax.Vansales.Service.Controllers.Purchases
{
    //[Authorize]
    public class POrdersController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/P_Orders/P_DelOrder")]
        [HttpDelete]
        public IHttpActionResult P_DelOrder([FromBody] int? poid)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("poid", poid);
                var res = SqlCommandHelper.ExecuteNonQuery("p_order_del", dict, true);
                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/P_Orders/P_DelorderDtl")]
        [HttpDelete]
        public IHttpActionResult P_DelorderDtl([FromBody] int? podtlid)
        {
            try
            {
                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("podtlid", podtlid);
                var res = SqlCommandHelper.ExecuteNonQuery("p_orderdtls_del", dic, true);
                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
