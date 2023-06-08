using Emax.Dal;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Emax.Vansales.Service.Controllers.HR
{
  //  [Authorize]
    public class Hr_employeesController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/HR/employees_del")]
        [HttpDelete]
        public IHttpActionResult hr_employees_del([FromBody] int? empid)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("empid", empid);
                var res = SqlCommandHelper.ExecuteNonQuery("hr_employees_del", dict, true);
                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
