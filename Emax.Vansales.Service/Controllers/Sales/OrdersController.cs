using Emax.Dal;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
 

namespace Emax.Vansales.Service.Controllers.Sales
{
   // [Authorize]
    public class OrdersController : ApiController
    {
         
        // GET: Orders
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [ Route("VanSalesService/orders/orderDel")] // حذف امر البيع
        [HttpDelete]
        public IHttpActionResult orderDel([FromBody] int? soid)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("soid", soid);
                var res = SqlCommandHelper.ExecuteNonQuery("s_order_del", dict, true);




                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/orders/gorderDtl")] // حذف تفاصيل امر البيع
        [HttpDelete]
        public IHttpActionResult gorderDtl([FromBody] int? sodtlid)
        {
            try
            {

                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("sodtlid", sodtlid);

                var res = SqlCommandHelper.ExecuteNonQuery("s_orderdtls_del", dic, true, new List<string> { "netval", "vatval", "netbvat" });




                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }




        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/orders/quoteorderDel")] // حذف عروض الاسعار
        [HttpDelete]
        public IHttpActionResult quoteorderDel([FromBody] int? soid)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("soid", soid);
                var res = SqlCommandHelper.ExecuteNonQuery("s_quote_order_del", dict, true);



                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/orders/gquoteorderDtl")] // حذف تفاصيل عروض الاسعار
        [HttpDelete]
        public IHttpActionResult gquoteorderDtl([FromBody] int? sodtlid)
        {
            try
            {

                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("sodtlid", sodtlid);

                var res = SqlCommandHelper.ExecuteNonQuery("s_quote_orderdtls_del", dic, true, new List<string> { "netval", "vatval", "netbvat" });




                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
    }
}