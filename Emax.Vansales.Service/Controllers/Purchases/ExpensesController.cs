using Emax.Dal;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Emax.Vansales.Service.Controllers.Purchases
{
    //[Authorize]
    public class ExpensesController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/Expenses/Expenses_del")]
        [HttpDelete]
        public IHttpActionResult Expenses_del([FromBody] int? expid)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("expid", expid);
                var res = SqlCommandHelper.ExecuteNonQuery("Expenses_del", dict, true);
                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
