using Emax.Dal;
using Emax.Vansales.Service.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Emax.Vansales.Service.Controllers.HR
{
   // [Authorize]
    public class hr_salarypaidController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/HR/salarypaid_del")]
        [HttpDelete]
        public IHttpActionResult hr_salaryprep_del([FromBody] int? spaidid)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("spaidid", spaidid);
                var res = SqlCommandHelper.ExecuteNonQuery("hr_salarypaid_del", dict, true);
                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        DataTable GetData(PopUpSearchModelEmpSalaryPaid datamodel)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("searchval", datamodel.SearchVal);
            dict.Add("monyrid", datamodel.monyrid);
            //dict.Add("userid", Request.Headers.GetValues("userid").ElementAt(0));
            DataTable dataTable = SqlCommandHelper.ExcecuteToDataTableJson(datamodel.TableName, dict).dataTable;
            return dataTable;
        }

        [HttpGet]
        [Route("VanSalesService/Hr/EmpPaid")]
        public IHttpActionResult GetEmpDataFroSalaryPrepar([FromUri] PopUpSearchModelEmpSalaryPaid datamodel)
        {
            try
            {
                DataTable tb = GetData(datamodel);
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
