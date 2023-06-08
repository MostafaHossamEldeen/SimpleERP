
using EMax.Dal.Context;
using EMax.Dal.Repository;
using EMax.DbModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Emax.VanSales.Service.Dal;
using Emax.VanSales.Service.Models;
using System.Web.Script.Serialization;
using Emax.Vansales.Service.Models;
using Emax.Dal;
using System.Threading.Tasks;
using System.Net;
using Repository.Ado;
using Newtonsoft.Json.Converters;
using Emax.SharedLib;

namespace Emax.VanSales.Service.Controllers
{
   // [Authorize]
    public class InvController : ApiController
    {
        // GET: inv
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["VanSales"].ConnectionString);
        #region  تم النقل
        //[HttpGet]

        //[Route("VanSalesService/inv/InvData", Name = "InvData")]
        //public IHttpActionResult InvData(int pageNo = 1, int pageSize = 10)
        //{
        //    try
        //    {

        //        int skip = (pageNo - 1) * pageSize;

        //        if (sqlConnection.State == System.Data.ConnectionState.Closed)
        //            sqlConnection.Open();
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("exec s_inv_sel", sqlConnection);

        //        DataTable tb = new DataTable();
        //        sqlDataAdapter.Fill(tb);




        //        // Get total number of records
        //        int total = tb.Rows.Count;

        //        // Select the customers based on paging parameters
        //        var tborderd = tb.AsEnumerable().Select(i => new
        //        {
        //            sinvid = i.Field<int>("sinvid"),
        //            sinvno = i.Field<string>("sinvno"),
        //            // snature = i.Field<int>("snature"),
        //            sinvdocno = i.Field<string>("sinvdocno"),
        //            sinvdata = i.Field<DateTime>("sinvdata"),
        //            //sinvtime    =i.Field<DateTime>("sinvtime"),
        //            sinvpay = i.Field<int?>("sinvpay"),
        //            sinvpayname = i.Field<string>("sinvpayname"),
        //            custcode = i.Field<int?>("custid"),
        //            custname = i.Field<string>("custname"),
        //            // totalinv    = i.Field<Double>("totalinv"),
        //            netbvat = i.Field<decimal?>("netbvat"),
        //            vatvalue = i.Field<decimal?>("vatvalue"),
        //            netavat = i.Field<decimal?>("netavat"),
        //            restvalue = i.Field<decimal?>("restvalue"),

        //        }
        //        )
        //        //  .Where(i=>i.snature==1)
        //        .OrderByDescending(c => c.sinvid)
        //        .Skip(skip)
        //        .Take(pageSize)
        //        ;
        //        string[] selectedcolumn = { "sinvid" };
        //        // string items = VanSalesCoreMethod.DataTableToJsonObj(tborderd, selectedcolumn);
        //        // Get the page links
        //        var linkBuilder = new PageLinkBuilder(Url, "invData", null, pageNo, pageSize, total);

        //        // Return the list of customers
        //        return Ok(new
        //        {
        //            Data = tborderd,

        //            Paging = new
        //            {
        //                First = linkBuilder.FirstPage,
        //                Previous = linkBuilder.PreviousPage,
        //                Next = linkBuilder.NextPage,
        //                Last = linkBuilder.LastPage
        //            }
        //        });


        //    }
        //    catch (Exception ex)
        //    {

        //        return InternalServerError(ex);
        //    }

        //}
        #endregion
        #region تم النقل
        /*  [HttpGet]

          [Route("VanSalesService/inv/RtnInvData", Name = "RtnInvData")]
          public IHttpActionResult RtnInvData(int pageNo = 1, int pageSize = 10)
          {
              try
              {

                  int skip = (pageNo - 1) * pageSize;

                  if (sqlConnection.State == System.Data.ConnectionState.Closed)
                      sqlConnection.Open();
                  SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("exec s_rtn_inv_sel", sqlConnection);

                  DataTable tb = new DataTable();
                  sqlDataAdapter.Fill(tb);




                  // Get total number of records
                  int total = tb.Rows.Count;

                  // Select the customers based on paging parameters
                  var tborderd = tb.AsEnumerable().Select(i => new
                  {
                      sinvid = i.Field<int>("sinvid"),
                      sinvno = i.Field<string>("sinvno"),
                      // snature = i.Field<int>("snature"),
                      sinvdocno = i.Field<string>("sinvdocno"),
                      sinvdata = i.Field<DateTime>("sinvdata"),
                      //sinvtime    =i.Field<DateTime>("sinvtime"),
                      sinvpay = i.Field<int?>("sinvpay"),
                      sinvpayname = i.Field<string>("sinvpayname"),
                      custcode = i.Field<int?>("custid"),
                      custname = i.Field<string>("custname"),
                      // totalinv    = i.Field<Double>("totalinv"),
                      netbvat = i.Field<decimal?>("netbvat"),
                      vatvalue = i.Field<decimal?>("vatvalue"),
                      netavat = i.Field<decimal?>("netavat"),
                      restvalue = i.Field<decimal?>("restvalue"),

                  }
                  )
                  //  .Where(i=>i.snature==1)
                  .OrderByDescending(c => c.sinvid)

                  .Skip(skip)
                  .Take(pageSize)
                  ;
                  string[] selectedcolumn = { "sinvid" };
                  // string items = VanSalesCoreMethod.DataTableToJsonObj(tborderd, selectedcolumn);
                  // Get the page links
                  var linkBuilder = new PageLinkBuilder(Url, "RtninvData", null, pageNo, pageSize, total);

                  // Return the list of customers
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

          }*/
        #endregion
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/invoice/insertinv", Name = "invoices")] // انشاء فاتوره موبايل
        [HttpPost]
        public IHttpActionResult AddInv(s_invs sinv)
        {
            try
            {
                //sinv.withoutinv = Convert.ToBoolean( DBNull.Value)1;
                var res = SqlCommandHelper.ExecuteNonQuery<s_invs>("s_inv_ins", new List<s_invs>() { sinv }, true, new List<string> { "sinvnomax", "time", "id" });

                if (res.errorid == 0)
                {
                    //EmaxGlobals.DateToTaxDate()

                    var resdtl = new StoredExecuteResulte();
                    var respay = new StoredExecuteResulte();
                    var resmeasures = new StoredExecuteResulte();
                    var resitemh2 = new StoredExecuteResulte();
                    sinv.sinvno = res.outputparams["sinvnomax"].ToString();
                    sinv.sinvid = Convert.ToInt32(res.outputparams["id"]);
                    sinv.sinvtime = Convert.ToDateTime(res.outputparams["time"]).TimeOfDay;

                    foreach (var sitmh2 in sinv.s_ItemHs2s)
                    {

                        sitmh2.sinvid = Convert.ToInt32(res.outputparams["id"]);
                        sitmh2.sinvno = res.outputparams["sinvnomax"].ToString();
                        sitmh2.fyear = sinv.fyear;
                        //sitmh2.invdtlid2 = sinv;

                        resitemh2 = SqlCommandHelper.ExecuteNonQuery<Vansales.Service.Models.s_ItemHs2>("s_itemHs2_ins", new List<Vansales.Service.Models.s_ItemHs2>() { sitmh2 }, true, new List<string> { "invdtlid2" });
                        foreach (var sinvdtls in sinv.s_invdtls)
                        {
                            if (sinvdtls.invdtlid2 == sitmh2.invdtlid2)
                            {
                                sinvdtls.sinvid = Convert.ToInt32(res.outputparams["id"]);
                                sinvdtls.sinvno = res.outputparams["sinvnomax"].ToString();
                                sinvdtls.fyear = sinv.fyear;
                                sinvdtls.invdtlid2 = EmaxGlobals.NullToIntZero(resitemh2.outputparams["invdtlid2"]);

                                resdtl = SqlCommandHelper.ExecuteNonQuery<s_invdtl>("s_invdtls_ins", new List<s_invdtl>() { sinvdtls }, true);
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                

                    if (resdtl.errorid == 0)
                    {
                        if (sinv.s_invmeasures != null)
                        {

                            foreach (var sinvmeasure in sinv.s_invmeasures)
                            {

                                sinvmeasure.invid = Convert.ToInt32(res.outputparams["id"]);


                                resmeasures = SqlCommandHelper.ExecuteNonQuery<s_invmeasures>("s_invmeasure_ins", new List<s_invmeasures>() { sinvmeasure }, true);

                            }
                            if (resmeasures.errorid != 0)
                            {
                                return BadRequest(resmeasures.errormsg);
                            }

                        }


                        if (sinv.sinvpay == 1)
                        {
                            foreach (var sinvpay in sinv.s_invpay)
                            {
                                sinvpay.sinvid = Convert.ToInt32(res.outputparams["id"]);
                                //  item.sinvno = res.outputparams["sinvnomax"].ToString();
                                sinvpay.fyear = sinv.fyear;
                                //   item.branchid = sinv.branchid;
                                respay = SqlCommandHelper.ExecuteNonQuery<s_invpays>("s_invpay_ins", new List<s_invpays>() { sinvpay }, true);
                            }

                            if (respay.errorid == 0)
                            {
                                var qrdata = EmaxGlobals.GetQrCodeDateData(sinv.compneyname,
                               HttpContext.Current.Request.Headers.GetValues("compvatno").FirstOrDefault(), sinv.sinvdata.ToString(), sinv.sinvtime.ToString(), Convert.ToDouble(sinv.netavat),
                               Convert.ToDouble(sinv.vatvalue));
                                return Ok(new { success = true, sinvid = sinv.sinvid, sinvno = sinv.sinvno, qrdata = qrdata });

                            }
                            else
                            { return BadRequest(respay.errormsg); }
                        }
                        else
                        {

                            var qrdata = EmaxGlobals.GetQrCodeDateData(sinv.compneyname,
                                HttpContext.Current.Request.Headers.GetValues("compvatno").FirstOrDefault(), sinv.sinvdata.ToString(), sinv.sinvtime.ToString(), Convert.ToDouble(sinv.netavat),
                                Convert.ToDouble(sinv.vatvalue));
                            return Ok(new { success = true, sinvid = sinv.sinvid, sinvno = sinv.sinvno, qrdata = qrdata });
                        }
                    }
                    else

                        return BadRequest(resdtl.errormsg);
                }

                //  UnitOfWork unitOfWork = new UnitOfWork();


                //  Entities<s_inv> entities = new Entities<s_inv>(unitOfWork);
                //for (int i = 0; i < sinv.s_invdtls.Count; i++)
                //{
                //   sinv.s_invdtls.ElementAt(i).
                //}
                // entities.Add(sinv);
                // unitOfWork.SaveChanges();
                else
                {
                    return BadRequest(res.errormsg);
                }
                //return Ok(new { success = true , sinvid = sinv.sinvid, sinvno = sinv.sinvno } );
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        [HttpGet]

        [Route("VanSalesService/inv/InvdtlData", Name = "InvdtlData")]
        public IHttpActionResult InvdtlData(int sinvid/*, int pageNo = 1, int pageSize = 10*/)
        {
            try
            {
                
                //int skip = (pageNo - 1) * pageSize;

                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("exec s_invdtls_sel " + sinvid + "", sqlConnection);

                DataTable tb = new DataTable();
                sqlDataAdapter.Fill(tb);
                int total = tb.Rows.Count;



                //var linkBuilder = new PageLinkBuilder(Url, "invData", null, pageNo, pageSize, total);
                
                return Ok(new
                {
                    Data = tb     
                });
                //    Paging = new
                //    {
                //        First = linkBuilder.FirstPage,
                //        Previous = linkBuilder.PreviousPage,
                //        Next = linkBuilder.NextPage,
                //        Last = linkBuilder.LastPage
                //    }
                //});


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        #region تم النقل
      /*  [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/invoice/addnewinv", Name = "invoice")] // انشاء فاتوره موبايل
        [HttpPost]
        public IHttpActionResult AddInv(s_invs sinv)
        {
            try
            {
                //sinv.withoutinv = Convert.ToBoolean( DBNull.Value);
                var res = SqlCommandHelper.ExecuteNonQuery<s_invs>("s_inv_ins", new List<s_invs>() { sinv }, true, new List<string> { "sinvnomax", "time", "id" });
                if (res.errorid == 0)
                {

                    var resdtl = new StoredExecuteResulte();
                    var respay = new StoredExecuteResulte();
                    sinv.sinvno = res.outputparams["sinvnomax"].ToString();
                    sinv.sinvid = Convert.ToInt32(res.outputparams["id"]);
                    //s_invdtls invdtls = new s_invdtls();
                    // invdtls.sinvid= Convert.ToInt32(res.outputparams["id"]);
                    // invdtls.sinvno= res.outputparams["sinvnomax"].ToString();
                    //  return Json(new { sinvid = invdtls.sinvid.Value, sinvno= invdtls.sinvno });
                    foreach (var sinvdtls in sinv.s_invdtls)
                    {

                        sinvdtls.sinvid = Convert.ToInt32(res.outputparams["id"]);
                        sinvdtls.sinvno = res.outputparams["sinvnomax"].ToString();
                        sinvdtls.fyear = sinv.fyear;

                        resdtl = SqlCommandHelper.ExecuteNonQuery<s_invdtl>("s_invdtls_ins", new List<s_invdtl>() { sinvdtls }, true);

                    }

                    if (resdtl.errorid == 0)
                    {
                        if (sinv.sinvpay == 1)
                        {
                            foreach (var sinvpay in sinv.s_invpay)
                            {
                                sinvpay.sinvid = Convert.ToInt32(res.outputparams["id"]);
                                //  item.sinvno = res.outputparams["sinvnomax"].ToString();
                                sinvpay.fyear = sinv.fyear;
                                //   item.branchid = sinv.branchid;
                                respay = SqlCommandHelper.ExecuteNonQuery<s_invpays>("s_invpay_ins", new List<s_invpays>() { sinvpay }, true);
                            }

                            if (respay.errorid == 0)
                                return Ok(new { success = true, sinvid = sinv.sinvid, sinvno = sinv.sinvno });
                            else
                                return BadRequest(respay.errormsg);
                        }
                        else
                        {
                            return Ok(new { success = true, sinvid = sinv.sinvid, sinvno = sinv.sinvno });
                        }
                    }
                    else

                        return BadRequest(resdtl.errormsg);
                }

                //  UnitOfWork unitOfWork = new UnitOfWork();


                //  Entities<s_inv> entities = new Entities<s_inv>(unitOfWork);
                //for (int i = 0; i < sinv.s_invdtls.Count; i++)
                //{
                //   sinv.s_invdtls.ElementAt(i).
                //}
                // entities.Add(sinv);
                // unitOfWork.SaveChanges();
                else
                {
                    return BadRequest(res.errormsg);
                }
                //return Ok(new { success = true , sinvid = sinv.sinvid, sinvno = sinv.sinvno } );
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }*/
        #endregion

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/invoice/updateInv", Name = "invoice_update")]
        [HttpPut]
        public IHttpActionResult UpdateInv(s_inv sinv)
        {
            try
            {


                UnitOfWork unitOfWork = new UnitOfWork();


                Entities<s_inv> entities = new Entities<s_inv>(unitOfWork);

                entities.Update(sinv);
                unitOfWork.SaveChanges();

                return Ok(new { success = true });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/invoice/DeleteInv", Name = "invoice_Delete")]
        [HttpDelete]
        public IHttpActionResult DeleteInv(s_inv sinv)
        {
            try
            {


                UnitOfWork unitOfWork = new UnitOfWork();


                Entities<s_inv> entities = new Entities<s_inv>(unitOfWork);
                var invdelete = entities.Find(i => i.sinvid == sinv.sinvid);
                if (invdelete == null)
                {
                    return NotFound();
                }
                entities.Delete(invdelete);
                unitOfWork.SaveChanges();

                return Ok(new { success = true });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/invoice/InvDelMaster")] // حذف الفاتوره
        [HttpDelete]
        public IHttpActionResult InvDelMaster([FromBody] int? sinvid)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("sinvid", sinvid);
                var res = SqlCommandHelper.ExecuteNonQuery("s_inv_del", dict, true);




                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }


        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/invoice/RtnInvDelMaster")] // حذف المرتجع
        [HttpDelete]
        public IHttpActionResult RtnInvDelMaster([FromBody] int? rtninvid)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("rtninvid", rtninvid);
                var res = SqlCommandHelper.ExecuteNonQuery("s_rtninv_del", dict, true);



                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        //[Route("VanSalesService/invoice/DeleteInvdtl", Name = "Invdtl_Delete")]
        //[HttpDelete]
        //public IHttpActionResult DeleteInvDtl(s_invdtls s_invdtls)
        //{
        //    try
        //    {


        //        UnitOfWork unitOfWork = new UnitOfWork();


        //        Entities<s_invdtls> entities = new Entities<s_invdtls>(unitOfWork);
        //        var invdet=entities.Find(i => i.invdtlid == s_invdtls.invdtlid);
        //        if (invdet==null)
        //        {
        //            return NotFound();
        //        }
        //        entities.Delete(invdet);


        //        return Ok(new { success = true });
        //    }
        //    catch (Exception ex)
        //    {

        //        return InternalServerError(ex);
        //    }

        //}

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/invoice/DelinvDetail")] // حذف تفاصيل الفاتوره
        [HttpDelete]
        public IHttpActionResult DelinvDetail([FromBody] int? invdtlid)
        {
            try
            {

                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("invdtlid", invdtlid);

                var res = SqlCommandHelper.ExecuteNonQuery("s_invdtls_del", dic, true, new List<string> { "netval", "vatval", "netbvat", "payvalue" });




                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }



        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/invoice/gInvPay")] // حذف طرق الدفع فاتوره بيع
        [HttpDelete]
        public IHttpActionResult gInvPay([FromBody] int invpayid)
        {
            try
            {

                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("invpayid", invpayid);

                var res = SqlCommandHelper.ExecuteNonQuery("s_invpay_del", dic, true, new List<string> { "payvalue" });




                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        [HttpPost]
        [Route("VanSalesService/invoice/GetInvMasterQrData")]
        public IHttpActionResult GetInvMasterQrData(string invno,string compenyname,string vatnumber)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("sinvno", invno);
                var dt = SqlCommandHelper.ExcecuteToDataTable("[s_inv_sel_code]", dict).dataTable;
                //string f = HttpContext.Current.Request.Headers.GetValues("compneyname").FirstOrDefault();
                var qrdata = EmaxGlobals.GetQrCodeDateData(compenyname,
                             vatnumber, dt.Rows[0]["sinvdata"].ToString()
                             , dt.Rows[0]["sinvtime"].ToString(), Convert.ToDouble(dt.Rows[0]["netavat"]),
                             Convert.ToDouble(dt.Rows[0]["vatvalue"]));
                return Ok(new { qrdata = qrdata });
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/invoice/gRtnInvPay")] // حذف طرق الدفع مرتجع
        [HttpDelete]
        public IHttpActionResult gRInvPay([FromBody] int invpayid)
        {
            try
            {

                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("invpayid", invpayid);

                var res = SqlCommandHelper.ExecuteNonQuery("s_rtn_invpay_del", dic, true, new List<string> { "payvalue" });




                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/invoice/gRtnInvDtl")] // حذف تفاصيل المرتجع
        [HttpDelete]
        public IHttpActionResult gRtnInvDtl([FromBody] int? invdtlid)
        {
            try
            {

                Dictionary<object, object> dic = new Dictionary<object, object>();
                dic.Add("invdtlid", invdtlid);

                var res = SqlCommandHelper.ExecuteNonQuery("s_rtn_invdtls_del", dic, true, new List<string> { "netval", "vatval", "netbvat", "payvalue" });




                return Ok(new { Data = res });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        //public IHttpActionResult AddInv(s_inv sinv)
        //{
        //    try
        //    {

        //        //VanSalesDbContext dbcontext = new VanSalesDbContext(ConfigurationManager.ConnectionStrings["VanSalesDbModelEntities"].ConnectionString);
        //        UnitOfWork unitOfWork = new UnitOfWork();

        //        SalesInv salesInv = new SalesInv();
        //        Entities<s_inv> entities = new Entities<s_inv>(unitOfWork);
        //        entities.Add(sinv);
        //        unitOfWork.SaveChanges();
        //        //unitOfWork.Save();
        //        //bool isexcist = salesInv.s_inv_sel_search(sinv.sinvid).Rows.Count == 0;
        //        //if (isexcist)
        //        //{
        //        //    var _sinv = sinv;
        //        //    salesInv.s_inv_ins("فاتورة", _sinv.sinvdocno, _sinv.sinvdata, _sinv.sinvpay, _sinv.sinvpayname
        //        //        , _sinv.custid, _sinv.custname, _sinv.custvat, _sinv.custadd, _sinv.suser, _sinv.snotes, _sinv.netbvat, _sinv.vatvalue, _sinv.netavat
        //        //        , _sinv.restvalue, _sinv.invdoc);
        //        //}

        //        //foreach (s_invdtls item in sinv.s_invdtls)
        //        //{
        //        //    //salesInv.s_invdtls_ins(sinv.sinvid,item.itemid,item.unitid,it)
        //        //}

        //        // DataTable dataTable = JsonConvert.DeserializeObject<DataTable>(strComplex.ComplexData);
        //        return Ok(new { success = true });
        //    }
        //    catch (Exception ex)
        //    {

        //        return InternalServerError(ex);
        //    }

        //}
        #region invdet
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        private InvdetViewModel ParseDepartmentdata(string HR_Op_d_Data)
        {

            InvdetViewModel HR_Op_details = (InvdetViewModel)(new JavaScriptSerializer().Deserialize<InvdetViewModel>(HR_Op_d_Data));



            return HR_Op_details;

        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/invoice/addnewinvdet", Name = "invoicedet")]
        [HttpPost]
        public IHttpActionResult AddInv_det(s_invdtls sinvdet)
        {
            try
            {

                var res = SqlCommandHelper.ExecuteNonQuery<s_invdtls>(sinvdet.invdtlid != null && sinvdet.invdtlid != 0 ? "s_invdtls_upd" : "s_invdtls_ins", new List<s_invdtls>() { sinvdet }, true, new List<string>() { "invdtlid" });

                UnitOfWork unitOfWork = new UnitOfWork();
                //    Dictionary<object, object> dicitm = new Dictionary<object, object>();

                ////InvdetViewModel inv = ParseDepartmentdata(sinv);
                //dicitm.Add("itemid", sinvdet.itemcode);
                //var f=SqlCommandHelper.ExcecuteToDataTable("st_items_sel_scalare", dicitm);
                int invdetid = 0;

                //sinvdet.itemid = Convert.ToInt32(f.dataTable.Rows[0]["itemid"]);
                //sinvdet.vatvalue = (Convert.ToDecimal(f.dataTable.Rows[0]["vat"]) / 100) * sinvdet.netvalue;

                //if (sinvdet.price != null && sinvdet.qty != null && sinvdet.value != null && sinvdet.netvalue != null && sinvdet.unitid != null)
                //{


                //    Entities<s_invdtls> entities = new Entities<s_invdtls>(unitOfWork);
                //    var isin = entities.Find(i => i.invdtlid == sinvdet.invdtlid && i.sinvno == sinvdet.sinvid.ToString());

                //    if (isin == null)
                //    {
                //        s_invdtls d = new s_invdtls();
                //        d.sinvid = sinvdet.sinvid;
                //        d.sinvno = sinvdet.sinvno;
                //        d.itemid = sinvdet.itemid;
                //        d.qty = sinvdet.qty;
                //        d.price = sinvdet.price;
                //       // d.vatvalue = inv.vatvalue;
                //        d.value = sinvdet.value;
                //        d.discp = sinvdet.discp;
                //        d.discvalue = sinvdet.discvalue;

                //        entities.Add(d);
                //        invdetid = d.invdtlid;
                //    }
                //    else
                //    {



                //        isin.itemid = sinvdet.itemid;
                //        isin.qty = sinvdet.qty;
                //        isin.price = sinvdet.price;
                //       // isin.vatvalue = inv.vatvalue;
                //        isin.value = sinvdet.value;
                //        isin.discp = sinvdet.discp;
                //        isin.discvalue = sinvdet.discvalue;
                //        isin.netvalue = sinvdet.netvalue;
                //        isin.unitid = sinvdet.unitid;
                //        isin.unitname = sinvdet.unitname;
                //        entities.Update(isin);
                //        invdetid = isin.invdtlid;
                //    }
                //    //unitOfWork.SaveChanges();



                //}
                if (res.errorid == 0)
                {
                    return Ok(new { Data = res });
                }
                else
                {
                    return Ok(new { Data = res });
                }
                //entities.Add(sinv);



            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/items/GetSingleItem")]
        [HttpGet]
        public IHttpActionResult GetSingleItem(string itemcode)
        {
            try
            {



                Dictionary<object, object> dicitm = new Dictionary<object, object>();


                dicitm.Add("itemid", itemcode);
                var f = SqlCommandHelper.ExcecuteToDataTable("st_items_sel_scalare", dicitm);


                return Ok(new { success = true, data = f.dataTable });
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        //[EnableCors(origins: "*", headers: "*", methods: "*")]
        //[Route("VanSalesService/invoice/Delinvdetail", Name = "invoicedet_del")]
        //[HttpPost]
        //public IHttpActionResult DelInv_det(string key)
        //{
        //    try
        //    {


        //        UnitOfWork unitOfWork = new UnitOfWork();

        //        Entities<s_invdtls> entities = new Entities<s_invdtls>(unitOfWork);
        //        int invid = Convert.ToInt32(key);
        //        var isin = entities.Find(i => i.invdtlid == invid);
        //        if (isin != null)
        //        {
        //            entities.Delete(isin);
        //        }

        //        //entities.Add(sinv);
        //        unitOfWork.SaveChanges();

        //        return Ok(new { success = true });
        //    }
        //    catch (Exception ex)
        //    {

        //        return InternalServerError(ex);
        //    }

        //}

        [EnableCors(origins: "*", headers: "*", methods: "get")]
        [Route("VanSalesService/invoice/Getinvdetbyid")]
        [HttpGet]
        public IHttpActionResult InvdetaillDataByInvid(int sinvid)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("sinvid", sinvid);
                StoredExecuteResulte res = SqlCommandHelper.ExcecuteAsyncToDataTable("s_invdtls_sel", dict);
                //if (res.dataTable.Rows.Count==0)
                //{
                //    return NotFound();
                //}
                if (res.dataTable.Rows.Count == 0)
                {
                    return new CutomeReturnHttpAction(HttpStatusCode.NotFound, ConvertDataTabletoString(res.dataTable));
                }
                else
                {
                    return Ok(

                        res.dataTable
                    );
                }


            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }

        public string ConvertDataTabletoString(DataTable dt)
        {


            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            //List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            //Dictionary<string, object> row;
            //row = new Dictionary<string, object>();


            List<string> cols = new List<string>();
            foreach (DataColumn col in dt.Columns)
            {
                cols.Add(col.ColumnName);
            }
            return serializer.Serialize(cols);


            //    return serializer.Serialize(rows);


        }



        #endregion
        #region test
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/items/getitm")]
        [HttpGet]
        public IHttpActionResult GetItem()
        {
            try
            {


                Dictionary<object, object> dicitm = new Dictionary<object, object>();


                dicitm.Add("@itmname", DBNull.Value);

                var f = SqlCommandHelper.ExcecuteToDataTable("st_items_sel", dicitm, true);

                if (f.Success == true)
                {

                    return Ok(new { success = true, data = f });
                }
                else
                {
                    return new CutomeReturnHttpAction(HttpStatusCode.InternalServerError, f.errormsg);
                }

            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        #endregion
        #region تم النقل
        /* [HttpGet]
         [Route("VanSalesService/inv/GetinvSingalData")] // البحث عن فاتوره موبايل
         public IHttpActionResult GetInvRow([FromUri] s_inv_sel_search_mob datamodel)
         {
             try
             {

                 Dictionary<object, object> dict = new Dictionary<object, object>();
                 dict.Add("user_id", datamodel.user_id);
                 dict.Add("searchval", datamodel.SearchVal);
                 // dict.Add("barcode2", datamodel.barcode2);
                 var tb = SqlCommandHelper.ExcecuteToDataTableJson("s_inv_sel_search_mobile", dict).dataTable;
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

         }
         [HttpGet]
         [Route("VanSalesService/inv/GetrtninvSingalData")] // البحث عن مرتجع موبايل
         public IHttpActionResult Getrtninv([FromUri] s_inv_sel_search_mob datamodel)
         {
             try
             {
                 Dictionary<object, object> dict = new Dictionary<object, object>();
                 dict.Add("user_id", datamodel.user_id);
                 dict.Add("searchval", datamodel.SearchVal);

                 var tb = SqlCommandHelper.ExcecuteToDataTableJson("s_rtn_inv_sel_search_mobile", dict).dataTable;

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
        [HttpGet]
        [Route("VanSalesService/inv/GetRtninvCodeSingalData")] // البحث عن مرتجع
        public IHttpActionResult GetrtnCodeinv([FromUri] s_invcode_sel_search datamodel)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("sinvno", datamodel.sinvno);

                var tb = SqlCommandHelper.ExcecuteToDataTableJson("s_rtn_inv_sel_invcode", dict).dataTable;
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
        #region تم النقل
        /*  [HttpGet]
        [Route("VanSalesService/inv/Getrtnallitmsinv")] // ارجاع كل الاصناف من الفاتروه الى مرتجع
        public IHttpActionResult Getrtnallitmsinv([FromUri] int? invid)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("invid", invid);

                var tb = SqlCommandHelper.ExcecuteToDataTableJson("s_rtn_all_invdtls_sel", dict).dataTable;
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
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }*/
        #endregion
        #region تم النقل
        /*  [EnableCors(origins: "*", headers: "*", methods: "*")]
          [Route("VanSalesService/invoice/addnewrtninv", Name = "rtninv")] // انشاء مرتجع موبايل
          [HttpPost]
          public IHttpActionResult AddRtnInv(s_invs sinv)
          {
              try
              {

                  var res = SqlCommandHelper.ExecuteNonQuery<s_invs>("s_rtn_inv_ins", new List<s_invs>() { sinv }, true, new List<string> { "sinvnomax", "time", "id" });
                  if (res.errorid == 0)
                  {
                      var resdtl = new StoredExecuteResulte();
                      var respay = new StoredExecuteResulte();
                      sinv.sinvno = res.outputparams["sinvnomax"].ToString();
                      sinv.sinvid = Convert.ToInt32(res.outputparams["id"]);

                      //s_invdtls invdtls = new s_invdtls();
                      // invdtls.sinvid= Convert.ToInt32(res.outputparams["id"]);
                      // invdtls.sinvno= res.outputparams["sinvnomax"].ToString();
                      //  return Json(new { sinvid = invdtls.sinvid.Value, sinvno= invdtls.sinvno });
                      foreach (var sinvdtls in sinv.s_invdtls)
                      {

                          sinvdtls.rtninvid = Convert.ToInt32(res.outputparams["id"]);
                          //var docno=    sinv.invno;

                          sinvdtls.sinvno = res.outputparams["sinvnomax"].ToString();
                          sinvdtls.fyear = sinv.fyear;
                          if (sinv.withoutinv.Value == false)
                          {
                              Dictionary<object, object> dict = new Dictionary<object, object>();
                              dict.Add("rtn_sinvno", sinvdtls.sinvno);
                              dict.Add("sinvno", sinv.invno);
                              dict.Add("itemid", sinvdtls.itemid);
                              dict.Add("unitid", sinvdtls.unitid);
                              dict.Add("actiontype", 0);
                              dict.Add("invdtlid", sinvdtls.invdtlid);
                              var resqty = SqlCommandHelper.ExcecuteToDataTable("s_rtn_invdtls_qty_sel", dict, false);

                              if (sinvdtls.qty.Value > Convert.ToDecimal(resqty.dataTable.Rows[0]["qty"].ToString()))


                              {
                                  return BadRequest("كميه المرتجع اكبر من كميه الفاتوره");

                              }
                              resdtl = SqlCommandHelper.ExecuteNonQuery<s_invdtl>("s_rtn_invdtls_ins", new List<s_invdtl>() { sinvdtls }, true);
                          }
                          else
                          {

                              resdtl = SqlCommandHelper.ExecuteNonQuery<s_invdtl>("s_rtn_invdtls_ins", new List<s_invdtl>() { sinvdtls }, true);
                          }
                      }

                      if (resdtl.errorid == 0)
                      {
                          if (sinv.sinvpay == 1)
                          {
                              foreach (var sinvpay in sinv.s_invpay)
                              {
                                  sinvpay.rtninvid = Convert.ToInt32(res.outputparams["id"]);
                                  //  item.sinvno = res.outputparams["sinvnomax"].ToString();
                                  sinvpay.fyear = sinv.fyear;
                                  //   item.branchid = sinv.branchid;
                                  respay = SqlCommandHelper.ExecuteNonQuery<s_invpays>("s_rtn_invpay_ins", new List<s_invpays>() { sinvpay }, true);
                              }
                              //return Ok(new { success = true, sinvid = sinv.sinvid, sinvno = sinv.sinvno });
                              if (respay.errorid == 0)
                                  return Ok(new { success = true, sinvid = sinv.sinvid, sinvno = sinv.sinvno });
                              else
                                  return BadRequest(respay.errormsg);
                          }
                          else
                          {
                              return Ok(new { success = true, sinvid = sinv.sinvid, sinvno = sinv.sinvno });
                          }
                      }

                      else

                          return BadRequest(resdtl.errormsg);
                  }

                  //  UnitOfWork unitOfWork = new UnitOfWork();


                  //  Entities<s_inv> entities = new Entities<s_inv>(unitOfWork);
                  //for (int i = 0; i < sinv.s_invdtls.Count; i++)
                  //{
                  //   sinv.s_invdtls.ElementAt(i).
                  //}
                  // entities.Add(sinv);
                  // unitOfWork.SaveChanges();
                  else
                  {
                      return BadRequest(res.errormsg);
                  }
                  //return Ok(new { success = true , sinvid = sinv.sinvid, sinvno = sinv.sinvno } );
              }
              catch (Exception ex)
              {

                  return InternalServerError(ex);
              }

          }*/
        #endregion
        [HttpGet]
        [Route("VanSalesService/inv/GetcustSingalData")] // البحث عن عميل بالكود
        public IHttpActionResult GetItemRow([FromUri] cust_sel_search datamodel)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();

                dict.Add("custcode", datamodel.custcode);
                var tb = SqlCommandHelper.ExcecuteToDataTableJson("s_customers_sel_custcode", dict).dataTable;
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

        [HttpGet]
        [Route("VanSalesService/inv/GetCustgroupData")] // البحث عن عميل بالكود
        public IHttpActionResult GetCustgroup()
        {
            try
            {

                var tb = SqlCommandHelper.ExcecuteToDataTableJson("s_custgroup_sel").dataTable;
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

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/invoice/addcust")] //اضافه عميل جديد
        [HttpPost]
        public IHttpActionResult addcust(cust_ins cust)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("custname", cust.custname);
                dict.Add("custadd", cust.custadd);
                dict.Add("custmob", cust.custmob);
                dict.Add("custvat", cust.custvat);
                dict.Add("sgrpid", cust.sgrpid);


                var res = SqlCommandHelper.ExecuteNonQuery("s_customers_fast_ins", dict, true, new List<string>() { "custcode" });

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
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/invoice/addcustpos")] //اضافه عميل جديد فى pos
        [HttpPost]
        public IHttpActionResult addcustpos(cust_ins cust)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("custname", cust.custname);
                dict.Add("custadd", cust.custadd);
                dict.Add("custmob", cust.custmob);
                dict.Add("custvat", cust.custvat);
                dict.Add("sgrpid", cust.sgrpid);


                var res = SqlCommandHelper.ExecuteNonQuery("s_customers_fast_pos_ins", dict, true, new List<string>() { "custcode", "chartcode","id" });

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
        [HttpPost]
        [Route("VanSalesService/invoice/postInvStock")]  //ترحيل الفواتير
        public IHttpActionResult PostInvStock(s_inv_Post s_inv_post)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                //dict.Add("branchid", st_transactions.branchid);
                // dict.Add("post", st_transactions.post);
                //  dict.Add("posttype", st_transactions.posttype);
                dict.Add("sinvid", s_inv_post.sinvid);


                var res = SqlCommandHelper.ExcecuteToDataTableJson("s_inv_post_stock", dict, true);

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

        [HttpPost]
        [Route("VanSalesService/invoice/postInvAcc")]  //ترحيل الفواتير حسابات
        public IHttpActionResult PostInvAcc(s_inv_Post s_inv_post)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                //dict.Add("branchid", st_transactions.branchid);
                // dict.Add("post", st_transactions.post);
                //  dict.Add("posttype", st_transactions.posttype);
                dict.Add("sinvid", s_inv_post.sinvid);
                dict.Add("user_name", s_inv_post.username);


                var res = SqlCommandHelper.ExecuteNonQuery("s_inv_post_acc", dict, true, new List<string>() { "voucher_no" });

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

        [HttpPost]
        [Route("VanSalesService/invoice/postRtnInvStock")]  //ترحيل المرتجع
        public IHttpActionResult PostRtnInvstock(s_inv_Post s_inv_post)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                //dict.Add("branchid", st_transactions.branchid);
                // dict.Add("post", st_transactions.post);
                //  dict.Add("posttype", st_transactions.posttype);
                dict.Add("sinvid", s_inv_post.sinvid);


                var res = SqlCommandHelper.ExcecuteToDataTableJson("s_Rtn_inv_post_stock", dict, true);

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

        [HttpPost]
        [Route("VanSalesService/invoice/postrtnInvAcc")]  //ترحيل مرتجع الفواتير حسابات
        public IHttpActionResult PostrtnInvAcc(s_inv_Post s_inv_post)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                //dict.Add("branchid", st_transactions.branchid);
                // dict.Add("post", st_transactions.post);
                //  dict.Add("posttype", st_transactions.posttype);
                dict.Add("rtninvid", s_inv_post.sinvid);
                dict.Add("user_name", s_inv_post.username);


                var res = SqlCommandHelper.ExecuteNonQuery("s_rtninv_post_acc", dict, true, new List<string>() { "voucher_no" });

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