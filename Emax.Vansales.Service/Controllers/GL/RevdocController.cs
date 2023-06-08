using Emax.Dal;
using Emax.Vansales.Service.Models;
using EMax.DbModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Emax.Vansales.Service.Controllers.GL
{
   // [Authorize]
    public class RevdocController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/rec/recdocDelMaster")]
        [HttpDelete]
        public IHttpActionResult recdocDelMaster([FromBody] int? recid)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("recid", recid);
                var res = SqlCommandHelper.ExecuteNonQuery("rec_doc_del", dict, true);


                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [Route("VanSalesService/rec/fromchartcode")]
        [HttpGet]
        public IHttpActionResult getfromchartcode([FromUri] int chartid,string recno)
        {
            try
            {

                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("chartid", chartid);
                dic.Add("recno", recno);

                var res = SqlCommandHelper.ExcecuteToDataTableJson("rec_doc_fromchart_sel_search", dic).dataTable;

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

        [Route("VanSalesService/rec/paychartcode")]
        [HttpGet]
        public IHttpActionResult getpaychartcode([FromUri] int chartid, string recno)
        {
            try
            {

                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("chartid", chartid);
                dic.Add("recno", recno);

                var res = SqlCommandHelper.ExcecuteToDataTableJson("rec_doc_paychart_sel_search", dic).dataTable;

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
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpPost]
        [Route("VanSalesService/Rec/PostRecAcc")]  //ترحيل سند قبض
        public IHttpActionResult PostRecAcc(rec_Post rec)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("chartidto", rec.chartidto);
                dict.Add("chartidfrom", rec.chartidfrom);
                dict.Add("recid", rec.recid);
                dict.Add("user_name", rec.username);


                var res = SqlCommandHelper.ExecuteNonQuery("rec_doc_post_acc", dict, true, new List<string>() { "voucher_no" });


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

        #region تم النقل
        /*  [EnableCors(origins: "*", headers: "*", methods: "*")]
          [Route("VanSalesService/rec/addnewrecdoc", Name = "recdoc")] // انشاء سند قبض موبايل
          [HttpPost]
          public IHttpActionResult Addrecdoc(rec_doc rec_doc)
          {
              try
              {
                  //sinv.withoutinv = Convert.ToBoolean( DBNull.Value);
                  var res = SqlCommandHelper.ExecuteNonQuery<rec_doc>("rec_doc_ins", new List<rec_doc>() { rec_doc }, true, new List<string> { "recno", "id" });
                  if (res.errorid == 0)
                  {


                      rec_doc.recno = res.outputparams["recno"].ToString();
                      rec_doc.recid = Convert.ToInt32(res.outputparams["id"]);
                      return Ok(new { success = true, recid = rec_doc.recid, recno = rec_doc.recno });
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

          }*/
        #endregion
        #region تم النقل
        /* [EnableCors(origins: "*", headers: "*", methods: "*")]
         [HttpGet]
         [Route("VanSalesService/rec/GetrecData")] // البحث عن سند قبض موبايل
         public IHttpActionResult GetRecRow([FromUri] string user_id,string SearchVal)
         {
             try
             {

                 Dictionary<object, object> dict = new Dictionary<object, object>();
                 dict.Add("user_id", user_id);
                 dict.Add("searchval", SearchVal);

                 var tb = SqlCommandHelper.ExcecuteToDataTableJson("rec_doc_sel_search_mobile", dict).dataTable;
                 if (tb.Rows.Count == 0)
                     return NotFound();
                 else
                 {
                     var data = JsonConvert.SerializeObject(tb, Formatting.None, new IsoDateTimeConverter()
                     {
                         DateTimeFormat = "d"
                     });
                     var json = JsonConvert.DeserializeObject(data);
                     return Ok(new
                     {
                         Data = json,


                     });
                 }
             }
             catch (Exception ex)
             {

                 return InternalServerError(ex);

             }

         }*/
        #endregion
        #region تم النقل
        /*   [HttpPost]

           [Route("VanSalesService/Rec/UploadFiles")]
           public async Task<IHttpActionResult> PostFiles()
           {
               if (Request.Content.IsMimeMultipartContent())
               {
                   string rootpath = HttpContext.Current.Server.MapPath("~/App_Data/UploadsFiles");
                   var streamProvider = new MultipartFormDataStreamProvider(Path.Combine(rootpath, "UploadsTemp"));
                   await Request.Content.ReadAsMultipartAsync(streamProvider);
                   string returnpath = string.Empty;
                   foreach (MultipartFileData fileData in streamProvider.FileData)
                   {
                       if (string.IsNullOrEmpty(fileData.Headers.ContentDisposition.FileName))
                       {
                           return StatusCode(HttpStatusCode.NotAcceptable);
                       }
                       string fileName = fileData.Headers.ContentDisposition.FileName;
                       if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                       {
                           fileName = fileName.Trim('"');
                       }
                       if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                       {
                           fileName = Path.GetFileName(fileName);
                       }
                       if (!Directory.Exists(rootpath + "/RecDoc"))
                       {
                           Directory.CreateDirectory(rootpath + "/RecDoc");
                       }
                       File.Move(fileData.LocalFileName, Path.Combine(rootpath + "/RecDoc", fileName));
                       returnpath= "~/App_Data/UploadsFiles/RecDoc/" + fileName;
                   }
                   return Ok(new { success = true, Data = returnpath });
               }
               else
               {
                   return StatusCode(HttpStatusCode.NotAcceptable);
               }
           }*/
        #endregion

    }
}
