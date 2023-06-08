using Emax.Dal;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Emax.Vansales.Service.Controllers.users
{
  //  [Authorize]
    public class UsersController : ApiController
    {
        DataTable GetData(string userid)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("sys_branch_userid", userid);

            DataTable dataTable = SqlCommandHelper.ExcecuteToDataTableJson("sys_userprep_sel", dict).dataTable;
            return dataTable;
        }
        [HttpGet]
        [Route("VanSalesService/users/GetUserProperty")]
        public IHttpActionResult UserProperty([FromUri] string userid)
        {
            try
            {
                DataTable tb = GetData(userid);
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
