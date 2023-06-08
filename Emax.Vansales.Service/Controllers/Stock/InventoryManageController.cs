using Emax.Dal;
using Emax.Vansales.Service.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Emax.Vansales.Service.Controllers.Stock
{
    // [Authorize]
    public class InventoryManageController : ApiController
    {
        [HttpPost]
        [Route("VanSalesService/Stock/PostInventory")] // ترحيل سندات الجرد
        public IHttpActionResult PostAddOrdertransactions(st_tInventory_Post st_tInventory)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("inventid", st_tInventory.inventid);
                var res = SqlCommandHelper.ExcecuteToDataTableJson("st_inventory_post", dict, true);
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

        /// delete 
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/Stock/DeleteInventory")] // حذف سند الجرد
        [HttpDelete]
        public IHttpActionResult addordDelMaster([FromBody] int? inventid)
        {
            try
            {
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("inventid", inventid);
                var res = SqlCommandHelper.ExecuteNonQuery("st_inventory_del", dict, true);
                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
