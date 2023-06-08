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

namespace Emax.Vansales.Service.Controllers.GL
{
    //[Authorize]
    public class ChartController : ApiController
    {
        [HttpGet]
        [Route("VanSalesService/Chart/GetChartSingalData")]
        public IHttpActionResult GetItemRow([FromUri] chart_sel_search datamodel)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("chartid", datamodel.chartid);
                var tb = SqlCommandHelper.ExcecuteToDataTableJson("gl_chart_sel_chartid", dict).dataTable;
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
