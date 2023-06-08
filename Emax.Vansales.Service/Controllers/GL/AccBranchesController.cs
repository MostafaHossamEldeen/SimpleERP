using Emax.Dal;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web;
using System.IO;


using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace Emax.Vansales.Service.Controllers.GL
{
    //[Authorize]
    public class AccBranchesController : ApiController
    {

 
    
    //public Task<HttpResponseMessage> PostFile()
    //{
    //    HttpRequestMessage request = this.Request;
    //    if (!request.Content.IsMimeMultipartContent())
    //    {
    //        throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
    //    }

    //    string root = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/uploads");
    //    var provider = new MultipartFormDataStreamProvider(root);

    //    var task = request.Content.ReadAsMultipartAsync(provider).
    //        ContinueWith<HttpResponseMessage>(o =>
    //        {

    //            string file1 = provider.BodyPartFileNames.First().Value;
    //    // this is the file name on the server where the file was saved 

    //    return new HttpResponseMessage()
    //            {
    //                Content = new StringContent("File uploaded.")
    //            };
    //        }
    //    );
    //    return task;
    //}
    [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/AccBranches/Fill")]
        [HttpDelete]
        public IHttpActionResult gl_accpay_del([FromBody] int? accpayid)
        {
            try
            {
             
                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("accpayid", accpayid);
                var res = SqlCommandHelper.ExecuteNonQuery("gl_accpay_del", dict, true);
                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
