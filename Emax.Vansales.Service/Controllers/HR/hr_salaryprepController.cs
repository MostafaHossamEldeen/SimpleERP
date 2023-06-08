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
    public class hr_salaryprepController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/HR/salaryprep_del")]
        [HttpDelete]
        public IHttpActionResult hr_salaryprep_del([FromBody] int? sprepid)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("sprepid", sprepid);
                var res = SqlCommandHelper.ExecuteNonQuery("hr_salaryprep_del", dict, true);
                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        DataTable GetData(PopUpSearchModelEmpSalaryPrep datamodel)
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("searchval", datamodel.SearchVal);
            dict.Add("monyrid", datamodel.monyrid);
            //dict.Add("userid", Request.Headers.GetValues("userid").ElementAt(0));
            DataTable dataTable = SqlCommandHelper.ExcecuteToDataTableJson(datamodel.TableName, dict).dataTable;
            return dataTable;
        }

        [HttpGet]
        [Route("VanSalesService/Hr/EmpPrep")]
        public IHttpActionResult GetEmpDataFroSalaryPrepar([FromUri] PopUpSearchModelEmpSalaryPrep datamodel)
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

        [HttpPost]
        [Route("VanSalesService/Hr/postSalaryPrepAcc")]  //ترحيل حسابات
        public IHttpActionResult postSalaryPrepAcc(salary_Prep_Post sprepid)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("sprepid", sprepid.sprepid);
                var res = SqlCommandHelper.ExecuteNonQuery("post_acc_hr_salaryprep", dict);
                return Ok(new
                {
                    Data = res


                });


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
    }
}
