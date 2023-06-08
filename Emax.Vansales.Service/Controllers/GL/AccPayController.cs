using Emax.Dal;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Emax.Vansales.Service.Controllers.GL
{
    //[Authorize]
    public class AccPayController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/AccPay/gl_accpay_del")]
        [HttpDelete]
        public IHttpActionResult gl_accpay_del([FromBody] int? accpayid)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("accpayid", accpayid);
                var res = SqlCommandHelper.ExecuteNonQuery("gl_accpay_del", dict, true);
                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
