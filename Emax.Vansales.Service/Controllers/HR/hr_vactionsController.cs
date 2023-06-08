using Emax.Dal;
using Emax.Vansales.Service.Models;
using Emax.VanSales.Service.Models;
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

namespace Emax.Vansales.Service.Controllers.HR
{
   // [Authorize]
    [RoutePrefix("VanSalesService/hr_vactions")]
    public class hr_vactionsController : ApiController
    {
        [Route("VactionsDelMaster")] // حذف اجازه
        [HttpDelete]
        public IHttpActionResult VactionsDelMaster([FromBody] int? vid)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("vid", vid);
                var res = SqlCommandHelper.ExecuteNonQuery("hr_vactions_del", dict, true);




                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        [HttpGet]
        [Route("GetempSingalData")] // البحث عن موظف بالكود
        public IHttpActionResult GetempRow([FromUri] emp_sel_search datamodel)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();

                dict.Add("empcode", datamodel.empcode);
                var tb = SqlCommandHelper.ExcecuteToDataTableJson("hr_employees_sel_empcode", dict).dataTable;
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

        [Route("addnewvactions")] // انشاء اجازه موبايل
        [HttpPost]
        public IHttpActionResult AddVactions(hr_vactions vactions)
        {
            try
            {
                VanSalesDbModelEntities vanSalesDbModelEntities = new VanSalesDbModelEntities();

                //sinv.withoutinv = Convert.ToBoolean( DBNull.Value);
                var res = SqlCommandHelper.ExecuteNonQuery<hr_vactions>("hr_vactions_ins", new List<hr_vactions>() { vactions }, true, new List<string> { "vnomax", "id" });
                if (res.errorid == 0)
                {

                    vactions.vno = res.outputparams["vnomax"].ToString();
                    vactions.vid = Convert.ToInt32(res.outputparams["id"]);


                    return Ok(new { success = true, vid = vactions.vid, vno = vactions.vno });
                }
                else
                {
                    return BadRequest(res.errormsg);
                }

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Route("GetEmpVactionsData", Name = "EmpVactionsData")] //اجازات الموظف
        public IHttpActionResult EmpVactionsData([FromUri] emp_sel_search datamodel, int pageNo = 1, int pageSize = 10)
        {
            try
            {
                int skip = (pageNo - 1) * pageSize;
                Dictionary<object, object> dict = new Dictionary<object, object>();

                dict.Add("empid", datamodel.empid);
                var tb = SqlCommandHelper.ExcecuteToDataTableJson("hr_vactions_sel_by_empid", dict).dataTable;
                var data = JsonConvert.SerializeObject(tb, Formatting.None, new IsoDateTimeConverter()
                {
                    DateTimeFormat = "d"
                });
                var json = JsonConvert.DeserializeObject(data);
                int total = tb.Rows.Count;
                var tborderd = tb.AsEnumerable().Select(i => new
                {
                    vid = i.Field<int>("vid"),
                    vno = i.Field<string>("vno"),
                    vdate = i.Field<DateTime>("vdate"),
                    empid = i.Field<int?>("empid"),
                    empname = i.Field<string>("empname"),
                    vdays = i.Field<int?>("vdays"),

                    vfromd = i.Field<DateTime>("vfromd"),
                    vtodate = i.Field<DateTime>("vtodate"),
                    vnotes = i.Field<string>("vnotes"),
                    vnameid = i.Field<int>("vnameid"),
                    vname = i.Field<string>("vname"),
                    vnametype = i.Field<int>("vnametype"),
                    vapp = i.Field<int>("vapp"),
                    vappname = i.Field<string>("vappname"),
                    vuser = i.Field<string>("vuser"),
                    vappuser = i.Field<string>("vappuser"),
                    vnature = i.Field<int>("vnature"),
                    vnaturenmae = i.Field<string>("vnaturenmae"),
                    fyear = i.Field<string>("fyear"),


                }
               )
.Where(i => i.empid == datamodel.empid)
               .OrderBy(c => c.vid)
               .Skip(skip)
               .Take(pageSize);
                var linkBuilder = new PageLinkBuilder(Url, "EmpVactionsData", null, pageNo, pageSize, total);
                return Ok(new
                {
                    Data = tborderd,
                    Paging = new
                    {
                        First = linkBuilder.FirstPage,
                        Previous = linkBuilder.PreviousPage,
                        Next = linkBuilder.NextPage,
                        Last = linkBuilder.LastPage
                    }
                });

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [HttpGet]
        [Route("GetAllEmpVactionsData", Name = "AllEmpVactionsData")] //اجازات الموظف
        public IHttpActionResult AllEmpVactionsData(int pageNo = 1, int pageSize = 10)
        {
            try
            {
                int skip = (pageNo - 1) * pageSize;

                var tb = SqlCommandHelper.ExcecuteToDataTableJson("hr_vactions_sel").dataTable;
                //var data = JsonConvert.SerializeObject(tb, Formatting.None, new IsoDateTimeConverter()
                //{
                //    DateTimeFormat = "d"
                //});
                //var json = JsonConvert.DeserializeObject(data);
                int total = tb.Rows.Count;
                // Select the customers based on paging parameters
                var tborderd = tb.AsEnumerable().Select(i => new
                {
                    vid = i.Field<int>("vid"),
                    vno = i.Field<string>("vno"),
                    vdate = i.Field<DateTime>("vdate"),
                    empid = i.Field<int?>("empid"),
                    empname = i.Field<string>("empname"),
                    vdays = i.Field<int?>("vdays"),

                    vfromd = i.Field<DateTime>("vfromd"),
                    vtodate = i.Field<DateTime>("vtodate"),
                    vnotes = i.Field<string>("vnotes"),
                    vnameid = i.Field<int>("vnameid"),
                    vname = i.Field<string>("vname"),
                    vnametype = i.Field<int>("vnametype"),
                    vapp = i.Field<int>("vapp"),
                    vappname = i.Field<string>("vappname"),
                    vuser = i.Field<string>("vuser"),
                    vappuser = i.Field<string>("vappuser"),
                    vnature = i.Field<int>("vnature"),
                    vnaturenmae = i.Field<string>("vnaturenmae"),
                    fyear = i.Field<string>("fyear"),


                }
                )

                .OrderBy(c => c.vid)
                .Skip(skip)
                .Take(pageSize);
                var linkBuilder = new PageLinkBuilder(Url, "AllEmpVactionsData", null, pageNo, pageSize, total);
                return Ok(new
                {
                    Data = tborderd,
                    Paging = new
                    {
                        First = linkBuilder.FirstPage,
                        Previous = linkBuilder.PreviousPage,
                        Next = linkBuilder.NextPage,
                        Last = linkBuilder.LastPage
                    }
                });

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        [Route("updatevactions")] // تعديل اجازه موبايل
        [HttpPut]
        public IHttpActionResult updateVactions(hr_vactions vactions)
        {
            try
            {
                //   VanSalesDbModelEntities vanSalesDbModelEntities = new VanSalesDbModelEntities();


                var res = SqlCommandHelper.ExecuteNonQuery<hr_vactions>("hr_vactions_upd", new List<hr_vactions>() { vactions }, true, new List<string> { });
                if (res.errorid == 0)
                {
                    return Ok(new { success = true });
                }
                else
                {
                    return BadRequest(res.errormsg);
                }

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [Route("updateVappVactions")] // موافقه او رفض اجازه موبايل
        [HttpPut]
        public IHttpActionResult updateVappVactions(hr_vactions vactions)
        {
            try
            {
                //   VanSalesDbModelEntities vanSalesDbModelEntities = new VanSalesDbModelEntities(); new List<string> { }
                Dictionary<object, object> dict = new Dictionary<object, object>();

                dict.Add("vid", vactions.vid);
                dict.Add("vapp", vactions.vapp);
                dict.Add("vappuser", vactions.vappuser);
                

                var res = SqlCommandHelper.ExecuteNonQuery("hr_vactions_vapp_upd",  dict , true, null);
                if (res.errorid == 0)
                {
                    return Ok(new { success = true });
                }
                else
                {
                    return BadRequest(res.errormsg);
                }

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
    }
}
