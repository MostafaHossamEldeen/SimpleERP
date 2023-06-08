using Emax.Dal;
using Emax.Vansales.Service.Models;
using EMax.DbModels;
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

namespace Emax.Vansales.Service.Controllers.GL
{
  //  [Authorize]
    public class VouchersController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/Vouchers/vouchersDelMaster")]
        [HttpDelete]
        public IHttpActionResult vouchersDelMaster([FromBody] int? vchrid)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("vchrid", vchrid);
                var res = SqlCommandHelper.ExecuteNonQuery("GL_vouchers_del", dict, true);


                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        [HttpGet]
        [Route("VanSalesService/Vouchers/chartSearch")]
        public IHttpActionResult Getst_transactions([FromUri] gl_chart_sel_search datamodel)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("searchval", datamodel.SearchVal);

                dict.Add("legertype", datamodel.legertype);

                DataTable dataTable = SqlCommandHelper.ExcecuteToDataTableJson(datamodel.TableName, dict).dataTable;

                var data = JsonConvert.SerializeObject(dataTable, Formatting.None, new IsoDateTimeConverter()
                {
                    DateTimeFormat = "d"
                });
               // var json = JsonConvert.DeserializeObject(data);
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
        [HttpGet]
        [Route("VanSalesService/Vouchers/PayCharts")]
        public IHttpActionResult PayCharts([FromUri] gl_paycharts datamodel)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("paytypeid", datamodel.Paytypeid);

                dict.Add("branchid", datamodel.branchid);

                DataTable dataTable = SqlCommandHelper.ExcecuteToDataTableJson(datamodel.TableName, dict).dataTable;

                var data = JsonConvert.SerializeObject(dataTable, Formatting.None, new IsoDateTimeConverter()
                {
                    DateTimeFormat = "d"
                });
                // var json = JsonConvert.DeserializeObject(data);
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
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/Vouchers/gvouchersDtl")]
        [HttpDelete]
        public IHttpActionResult gvouchersDtl([FromBody] int? vchrdtlid)
        {
            try
            {

                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("vchrdtlid", vchrdtlid);

                var res = SqlCommandHelper.ExecuteNonQuery("gl_vocherdtls_del", dic, true);




                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/Vouchers/voucherscode")]
        [HttpGet]
        public IHttpActionResult getvoucherscode([FromUri] int chartcode)
        {
            try
            {

                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("chartcode", chartcode);

                var res = SqlCommandHelper.ExcecuteToDataTableJson("gl_chartcode_sel", dic).dataTable;

                var data = JsonConvert.SerializeObject(res, Formatting.None, new IsoDateTimeConverter()
                {
                    DateTimeFormat = "d"
                });


                return Ok(new { Data = data });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        [HttpPost]
        [Route("VanSalesService/Vouchers/postVouchersAcc")]  //ترحيل  حسابات
        public IHttpActionResult PostVouchersAcc(vouchers_Post vouchers_Post)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
          
                dict.Add("vchrid", vouchers_Post.vchrid);
                dict.Add("puser", vouchers_Post.puser);


                var res = SqlCommandHelper.ExcecuteToDataTableJson("GL_vouchers_post_acc", dict, true);

                //var data = JsonConvert.SerializeObject(res, Formatting.None, new IsoDateTimeConverter()
                //{
                //    DateTimeFormat = "d"
                //});

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
