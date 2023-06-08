using Emax.Dal;
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

namespace Emax.Vansales.Service.Controllers.HR
{
  //  [Authorize]
    public class hr_salaryvarablesController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/HR/salaryvarables_del")]
        [HttpDelete]
        public IHttpActionResult hr_employees_del([FromBody] int? svid)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("svid", svid);
                var res = SqlCommandHelper.ExecuteNonQuery("hr_salaryvarables_del", dict, true);
                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("VanSalesService/HR/GetsalarySingalData")]
        public IHttpActionResult GetItemRow([FromUri] salary_sel_search datamodel)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("svnatuleid", datamodel.svnatuleid);
                dict.Add("empid", datamodel.empid);
                var tb = SqlCommandHelper.ExcecuteToDataTableJson("hr_salaryvarables_sel_empsalary", dict).dataTable;
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
