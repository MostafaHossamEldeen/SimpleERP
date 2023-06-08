using Emax.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Emax.Vansales.Service.Controllers.HR
{
   // [Authorize]
    [RoutePrefix("VanSalesService/hr_loans")]
    public class hr_loansController : ApiController
    {
        [Route("LoansDelMaster")] // حذف اجازه
        [HttpDelete]
        public IHttpActionResult LoansDelMaster([FromBody] int? loanid)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("loanid", loanid);
                var res = SqlCommandHelper.ExecuteNonQuery("hr_loans_del", dict, true);




                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
    }
}
