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
    public class PaydocController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/pay/paydocDelMaster")]
        [HttpDelete]
        public IHttpActionResult paydocDelMaster([FromBody] int? recid)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("pdid", recid);
                var res = SqlCommandHelper.ExecuteNonQuery("pay_doc_del", dict, true);


                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [Route("VanSalesService/pay/paidchartcode")]
        [HttpGet]
        public IHttpActionResult getpaidchartcode([FromUri] int chartid, string recno)
        {
            try
            {

                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("chartid", chartid);
                dic.Add("pdno", recno);

                var res = SqlCommandHelper.ExcecuteToDataTableJson("pay_doc_paidchart_sel_search", dic).dataTable;

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

        [Route("VanSalesService/pay/paydocchartcode")]
        [HttpGet]
        public IHttpActionResult getpaydocchartcode([FromUri] int chartid, string recno)
        {
            try
            {

                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("chartid", chartid);
                dic.Add("pdno", recno);

                var res = SqlCommandHelper.ExcecuteToDataTableJson("pay_doc_paychart_sel_search", dic).dataTable;

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
        [Route("VanSalesService/Pay/PostPayAcc")]  //ترحيل سند صرف
        public IHttpActionResult PostPayAcc(pay_Post pay)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("chartidto", pay.chartidto);
                dict.Add("chartidfrom", pay.chartidfrom);
                dict.Add("pdid", pay.pdid);
                dict.Add("user_name", pay.username);


                var res = SqlCommandHelper.ExecuteNonQuery("pay_doc_post_acc", dict, true, new List<string>() { "voucher_no" });


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
          [Route("VanSalesService/pay/addnewpaydoc", Name = "paydoc")] // انشاء سند صرف موبايل
          [HttpPost]
          public IHttpActionResult Addpaydoc(pay_doc pay_doc)
          {
              try
              {
               //var x= Post();
                  //sinv.withoutinv = Convert.ToBoolean( DBNull.Value);
                  var res = SqlCommandHelper.ExecuteNonQuery<pay_doc>("pay_doc_ins", new List<pay_doc>() { pay_doc }, true, new List<string> { "pdno", "id" });
                  if (res.errorid == 0)
                  {


                      pay_doc.pdno = res.outputparams["pdno"].ToString();
                      pay_doc.pdid = Convert.ToInt32(res.outputparams["id"]);
                      return Ok(new { success = true, pdid = pay_doc.pdid, pdno = pay_doc.pdno });
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
         [Route("VanSalesService/pay/GetpayData")] // البحث عن سند صرف موبايل
         public IHttpActionResult GetPayRow([FromUri] string user_id, string SearchVal)
         {
             try
             {

                 Dictionary<object, object> dict = new Dictionary<object, object>();
                 dict.Add("user_id", user_id);
                 dict.Add("searchval", SearchVal);

                 var tb = SqlCommandHelper.ExcecuteToDataTableJson("pay_doc_sel_search_mobile", dict).dataTable;
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
        /*[HttpPost]
 
        [Route("VanSalesService/Pay/UploadFiles")]
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
                    string fileName =  fileData.Headers.ContentDisposition.FileName;
                    if (fileName.StartsWith("\"") && fileName.EndsWith("\""))
                    {
                        fileName = fileName.Trim('"');
                    }
                    if (fileName.Contains(@"/") || fileName.Contains(@"\"))
                    {
                        fileName = Path.GetFileName(fileName);
                    }
                    if (!Directory.Exists(rootpath + "/PayDoc"))
                    {
                        Directory.CreateDirectory(rootpath + "/PayDoc");
                    }

                    File.Move(fileData.LocalFileName, Path.Combine(rootpath+ "/PayDoc", fileName));
                    returnpath = "~/App_Data/UploadsFiles/PayDoc/" + fileName;
                }
                return Ok(new { success = true, Data = returnpath});
            }
            else
            {
                return StatusCode(HttpStatusCode.NotAcceptable);
            }
        }*/
        #endregion
        //public HttpResponseMessage Post()
        //{
        //    HttpResponseMessage result = null;
        //    var httpRequest = HttpContext.Current.Request;
        //    if (httpRequest.Files.Count > 0)
        //    {
        //        var docfiles = new List<string>();
        //        foreach (string file in httpRequest.Files)
        //        {
        //            var postedFile = httpRequest.Files[file];
        //            var filePath = HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);
        //            postedFile.SaveAs(filePath);
        //            docfiles.Add(filePath);
        //        }
        //        result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
        //    }
        //    else
        //    {
        //        result = Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //    return result;
        //}
    }
}
