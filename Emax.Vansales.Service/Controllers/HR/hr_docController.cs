using Emax.Dal;
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
    public class hr_docController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/HR/doc_del")]
        [HttpDelete]
        public IHttpActionResult hr_doc_del([FromBody] int? docid)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("docid", docid);
                var res = SqlCommandHelper.ExecuteNonQuery("hr_doc_del", dict, true);
                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
