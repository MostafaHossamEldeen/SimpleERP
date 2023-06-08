using Emax.Dal;
using Emax.SharedLib;
using Emax.Vansales.Service.Models;
using Emax.VanSales.Service.Models;
using EMax.Dal.Context;
using EMax.Dal.Repository;
using EMax.DbModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Emax.Vansales.Service.Controllers.Mobile
{
    //  [Authorize]
    public class MobileController : ApiController
    {
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["VanSales"].ConnectionString);
        [HttpGet]

        [Route("VanSalesService/inv/InvData", Name = "InvData")]
        public IHttpActionResult InvData(int pageNo = 1, int pageSize = 10)
        {
            try
            {

                int skip = (pageNo - 1) * pageSize;

                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("exec s_inv_sel", sqlConnection);

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
                var linkBuilder = new PageLinkBuilder(Url, "invData", null, pageNo, pageSize, total);

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

        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
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
                    //EmaxGlobals.DateToTaxDate()
         
                    var resdtl = new StoredExecuteResulte();
                    var respay = new StoredExecuteResulte();
                    var resmeasures = new StoredExecuteResulte();
                    sinv.sinvno = res.outputparams["sinvnomax"].ToString();
                    sinv.sinvid = Convert.ToInt32(res.outputparams["id"]);
                    sinv.sinvtime = Convert.ToDateTime(res.outputparams["time"]).TimeOfDay;
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
                        if (sinv.s_invmeasures != null)
                        {

                            foreach (var sinvmeasure in sinv.s_invmeasures)
                            {
                               
                                sinvmeasure.invid = Convert.ToInt32(res.outputparams["id"]);


                                resmeasures = SqlCommandHelper.ExecuteNonQuery<s_invmeasures>("s_invmeasure_ins", new List<s_invmeasures>() { sinvmeasure }, true);

                            }
                            if(resmeasures.errorid!=0)
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
                            {
                                return BadRequest(respay.errormsg);
                            }
                        }
                        else
                        {
                            
                            var qrdata = EmaxGlobals.GetQrCodeDateData(sinv.compneyname,
                                HttpContext.Current.Request.Headers.GetValues("compvatno").FirstOrDefault(), sinv.sinvdata.ToString(), sinv.sinvtime.ToString(), Convert.ToDouble(sinv.netavat),
                                Convert.ToDouble(sinv.vatvalue));
                            return Ok(new { success = true, sinvid = sinv.sinvid, sinvno = sinv.sinvno,qrdata= qrdata });
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
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("VanSalesService/invoice/Updateinvoice", Name = "invoiceupdate")] // تعديل فاتوره Pos
        [HttpPut]
        public IHttpActionResult updateInv(s_invs sinv)
        {
            try
            {
                //sinv.withoutinv = Convert.ToBoolean( DBNull.Value);
                var res = SqlCommandHelper.ExecuteNonQuery<s_invs>("s_inv_upd", new List<s_invs>() { sinv }, true);

                if (res.errorid == 0)
                {
                    var resdtl = new StoredExecuteResulte();
                    var respay = new StoredExecuteResulte();
                    var resmeasures = new StoredExecuteResulte();
 
                    foreach (var sinvdtls in sinv.s_invdtls)
                    {

                        sinvdtls.sinvid = sinv.sinvid;
                  

                        resdtl = SqlCommandHelper.ExecuteNonQuery<s_invdtl>("s_invdtls_upd", new List<s_invdtl>() { sinvdtls }, true, new List<string> { "invdtlid" });

                    }

                    if (resdtl.errorid == 0)
                    {
                        if (sinv.s_invmeasures != null)
                        {

                            foreach (var sinvmeasure in sinv.s_invmeasures)
                            {

                                sinvmeasure.invid = sinv.sinvid; //Convert.ToInt32(res.outputparams["id"]);


                                resmeasures = SqlCommandHelper.ExecuteNonQuery<s_invmeasures>("s_invmeasure_upd", new List<s_invmeasures>() { sinvmeasure }, true);

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
                                sinvpay.sinvid = sinv.sinvid; //Convert.ToInt32(res.outputparams["id"]);
                                //  item.sinvno = res.outputparams["sinvnomax"].ToString();
                                //sinvpay.fyear = sinv.fyear;
                                //   item.branchid = sinv.branchid;
                                respay = SqlCommandHelper.ExecuteNonQuery<s_invpays>("s_invpay_upd", new List<s_invpays>() { sinvpay }, true);
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

        [Route("VanSalesService/inv/RtnInvData", Name = "RtnInvData")]  //list  المرتجعات
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

        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
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
                    sinv.sinvtime = Convert.ToDateTime(res.outputparams["time"]).TimeOfDay;
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
                            {
                                var qrdata = EmaxGlobals.GetQrCodeDateData(sinv.compneyname,
                               HttpContext.Current.Request.Headers.GetValues("compvatno").FirstOrDefault(), sinv.sinvdata.ToString(), sinv.sinvtime.ToString(), Convert.ToDouble(sinv.netavat),
                               Convert.ToDouble(sinv.vatvalue));
                                return Ok(new { success = true, sinvid = sinv.sinvid, sinvno = sinv.sinvno, qrdata = qrdata });
                            }
                            else
                            {
                                return BadRequest(respay.errormsg);
                            }
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

        }
        [HttpGet]
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

        }
        [HttpGet]

        [Route("VanSalesService/items/ItemsData", Name = "ItemsData")]
        public IHttpActionResult ItemsData([FromUri] int branchid,int pageNo = 1, int pageSize = 10)
        {
            try
            {
                int skip = (pageNo - 1) * pageSize;


                Dictionary<object, object> dict = new Dictionary<object, object>();

                dict.Add("branchid", branchid);

                var tb = SqlCommandHelper.ExcecuteToDataTableJson("st_itemunit_mobile_sel", dict).dataTable;

                //if (sqlConnection.State == System.Data.ConnectionState.Closed)
                //    sqlConnection.Open();
                //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("exec st_itemunit_mobile_sel", sqlConnection);

                //DataTable tb = new DataTable();
                //sqlDataAdapter.Fill(tb);

                int total = tb.Rows.Count;

                // Select the customers based on paging parameters
                var tborderd = tb.AsEnumerable().Select(i => new
                {
                    itemid = i.Field<int>("itemid"),
                    itemcode = i.Field<string>("itemcode"),
                    itemname = i.Field<string>("itemname"),
                    itemename = i.Field<string>("itemename"),
                    descp = i.Field<decimal>("descp"),
                    fprice = i.Field<decimal>("fprice"),
                    unitid = i.Field<int>("unitid"),
                    unitname = i.Field<string>("unitname"),
                    sprice = i.Field<decimal?>("sprice"),
                    vat = i.Field<decimal?>("vat"),
                    balance = i.Field<decimal?>("balance"),
                    factor = i.Field<decimal?>("factor"),
                    imgpath = ConfigurationManager.AppSettings["approot"] + i.Field<string>("itemimg").Replace("~", string.Empty)
                }
                )
                .OrderBy(c => c.itemid)
                .Skip(skip)
                .Take(pageSize)
                ;
                string[] selectedcolumn = { "itemid" };
                // string items = VanSalesCoreMethod.DataTableToJsonObj(tborderd, selectedcolumn);
                // Get the page links
                var linkBuilder = new PageLinkBuilder(Url, "ItemsData", null, pageNo, pageSize, total);

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

        }
        [HttpGet]
        [Route("VanSalesService/items/itemsearch")]
        public IHttpActionResult itemsearch([FromUri] string SearchVal)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();

                dict.Add("searchval", SearchVal);

                var tb = SqlCommandHelper.ExcecuteToDataTableJson("st_itemunit_inv_sel_pop", dict).dataTable;
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
        [Route("VanSalesService/items/itemgroupsearch")]
        public IHttpActionResult itemgroupsearch([FromUri] string SearchVal)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();

                dict.Add("searchval", SearchVal);

                var tb = SqlCommandHelper.ExcecuteToDataTableJson("st_itemunit_inv_sel_pop_group", dict).dataTable;
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

        [Route("VanSalesService/Customers/CustomerallData", Name = "CustomerallData")]

        public IHttpActionResult CustomerallData(int pageNo = 1, int pageSize = 10)
        {
            try
            {

                int skip = (pageNo - 1) * pageSize;

                if (sqlConnection.State == ConnectionState.Closed)
                    sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("exec s_customers_sel", sqlConnection);

                DataTable tb = new DataTable();
                sqlDataAdapter.Fill(tb);



                int total = tb.Rows.Count;

                // Select the customers based on paging parameters
                var tborderd = tb.AsEnumerable().Select(i => new
                {
                    custid = i.Field<int>("custid"),
                    custcode = i.Field<string>("custcode"),
                    custname = i.Field<string>("custname"),
                    custename = i.Field<string>("custename"),
                    custchartid = i.Field<Nullable<int>>("custchartid"),

                    custadd = i.Field<string>("custadd"),
                    custmob = i.Field<string>("custmob"),
                    custvat = i.Field<string>("custvat"),
                    stopcust = i.Field<bool?>("stopcust")

                }
                )
                .OrderBy(c => c.custid)
                .Skip(skip)
                .Take(pageSize)
                ;
                string[] selectedcolumn = { "itemid" };
                // string items = VanSalesCoreMethod.DataTableToJsonObj(tborderd, selectedcolumn);
                // Get the page links
                var linkBuilder = new PageLinkBuilder(Url, "ItemsData", null, pageNo, pageSize, total);

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
        }
        [HttpGet]

        [Route("VanSalesService/Customers/CustomerDataData", Name = "CustomerDataData")]

        public IHttpActionResult CustomerDataData([FromUri] string custname = "")
        {
            try
            {

                UnitOfWork unitOfWork = new UnitOfWork();


                Entities<s_customers> entities = new Entities<s_customers>(unitOfWork);
                var custlist = entities.FindAll(i => i.custname.Contains(custname)).Select(i => new { i.custid, i.custname, i.custchartid, i.custvat, i.custadd, i.custmob }).ToList();

                if (custlist.Count == 0)
                {
                    return NotFound();
                }
                return Ok(new { Customers = custlist, success = true });

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);

            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        [Route("VanSalesService/rec/GetrecData")] // البحث عن سند قبض موبايل
        public IHttpActionResult GetRecRow([FromUri] string user_id, string SearchVal)
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

        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
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

        }
        [HttpPost]

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
                    returnpath = "~/App_Data/UploadsFiles/RecDoc/" + fileName;
                }
                return Ok(new { success = true, Data = returnpath });
            }
            else
            {
                return StatusCode(HttpStatusCode.NotAcceptable);
            }
        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
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

        }
        [EnableCors(origins: "*", headers: "*", methods: "*")]
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



        }
        [HttpPost]

        [Route("VanSalesService/Pay/UploadFiles")]
        public async Task<IHttpActionResult> PostpayFiles()
        {
            try
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
                        if (!Directory.Exists(rootpath + "/PayDoc"))
                        {
                            Directory.CreateDirectory(rootpath + "/PayDoc");
                        }

                        File.Move(fileData.LocalFileName, Path.Combine(rootpath + "/PayDoc", fileName));
                        returnpath = "~/App_Data/UploadsFiles/PayDoc/" + fileName;
                    }
                    return Ok(new { success = true, Data = returnpath });
                }
                else
                {
                    return StatusCode(HttpStatusCode.NotAcceptable);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
               
            }
         
        }
        [HttpGet]

        [Route("VanSalesService/Rec/RecData", Name = "RecData")]
        public IHttpActionResult RecData(int pageNo = 1, int pageSize = 10)
        {
            try
            {

                int skip = (pageNo - 1) * pageSize;

                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("exec rec_doc_sel", sqlConnection);

                DataTable tb = new DataTable();
                sqlDataAdapter.Fill(tb);




                // Get total number of records
                int total = tb.Rows.Count;

                // Select the customers based on paging parameters
                var tborderd = tb.AsEnumerable().Select(i => new
                {
                    recid = i.Field<int>("recid"),
                    recno = i.Field<string>("recno"),
                    recdocno = i.Field<string>("recdocno"),
                    // recbranchid = i.Field<int>("recbranchid"),
                    recdate = i.Field<DateTime>("recdate"),
                    //sinvtime    =i.Field<DateTime>("sinvtime"),
                    rectype = i.Field<int?>("rectype"),
                    rectypename = i.Field<string>("rectypename"),
                    recdocimg = i.Field<string>("recdocimg"),
                    recnotes = i.Field<string>("recnotes"),
                    // totalinv    = i.Field<Double>("totalinv"),
                    recPayTypeName = i.Field<string>("paytypename"),
                    recvalue = i.Field<decimal?>("recvalue"),
                    fromchartno = i.Field<Int64?>("fromchartno"),
                    fromchartname = i.Field<string>("fromchartname")
                   // restvalue = i.Field<decimal?>("restvalue"),

                }
                )
                //  .Where(i=>i.snature==1)
                .OrderByDescending(c => c.recid)
                .Skip(skip)
                .Take(pageSize)
                ;
                string[] selectedcolumn = { "recid" };
                // string items = VanSalesCoreMethod.DataTableToJsonObj(tborderd, selectedcolumn);
                // Get the page links
                var linkBuilder = new PageLinkBuilder(Url, "RecData", null, pageNo, pageSize, total);

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

        }
        [HttpGet]
        [Route("VanSalesService/Pay/PayData", Name = "PayData")]
        public IHttpActionResult PayData(int pageNo = 1, int pageSize = 10)
        {
            try
            {

                int skip = (pageNo - 1) * pageSize;

                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("exec pay_doc_sel", sqlConnection);

                DataTable tb = new DataTable();
                sqlDataAdapter.Fill(tb);




                // Get total number of records
                int total = tb.Rows.Count;

                // Select the customers based on paging parameters
                var tborderd = tb.AsEnumerable().Select(i => new
                {
                    pdid = i.Field<int>("pdid"),
                    pdno = i.Field<string>("pdno"),
                    pddocno = i.Field<string>("pddocno"),
                    // recbranchid = i.Field<int>("recbranchid"),
                    pddate = i.Field<DateTime>("pddate"),
                    //sinvtime    =i.Field<DateTime>("sinvtime"),
                    paidtype = i.Field<int?>("paidtype"),
                    paidtypename = i.Field<string>("paidtypename"),
                    pddocimg = i.Field<string>("pddocimg"),
                    pdnotes = i.Field<string>("pdnotes"),
                    // totalinv    = i.Field<Double>("totalinv"),
                    paidPayTypeName = i.Field<string>("paytypename"),
                    vatvalue = i.Field<decimal?>("vatvalue"),
                    pdbvat = i.Field<decimal?>("pdbvat"),
                    pdavat = i.Field<decimal?>("pdavat"),
                    vattype = i.Field<int?>("vattype"),
                    vattypename = i.Field<string>("vattypename"),
                    paidchartno = i.Field<Int64?>("paidchartno"),
                    paidchartname = i.Field<string>("paidchartname")

                }
                )
                //  .Where(i=>i.snature==1)
                .OrderByDescending(c => c.pdid)
                .Skip(skip)
                .Take(pageSize)
                ;
                string[] selectedcolumn = { "pdid" };
                // string items = VanSalesCoreMethod.DataTableToJsonObj(tborderd, selectedcolumn);
                // Get the page links
                var linkBuilder = new PageLinkBuilder(Url, "PayData", null, pageNo, pageSize, total);

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

        }
        [HttpGet]
        [Route("VanSalesService/payment/paytype")]
        public IHttpActionResult paymenttype([FromUri] string model)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();

                dict.Add("model", model);
                dict.Add("table_name", "sys-paytype");

                var tb = SqlCommandHelper.ExcecuteToDataTableJson("sys_fillcomp_sel", dict).dataTable;
                if (tb.Rows.Count == 0)
                    return NotFound();
                else
                {
                    var data = JsonConvert.SerializeObject(tb, Formatting.None, new IsoDateTimeConverter()
                    {
                        DateTimeFormat = "d"
                    });
                  //  var json = JsonConvert.DeserializeObject(data);
                    return Ok(new
                    {
                        Data = data,


                    });
                }
            }
            catch (Exception ex)
            {

                return InternalServerError(ex);
            }

        }
        //[HttpGet]
        //[Route("VanSalesService/Vouchers/chartSearch")]
        //public IHttpActionResult Getst_transactions([FromUri] gl_chart_sel_search datamodel)
        //{
        //    try
        //    {


        //        Dictionary<object, object> dict = new Dictionary<object, object>();
        //        dict.Add("searchval", datamodel.SearchVal);

        //        dict.Add("legertype", datamodel.legertype);

        //        DataTable dataTable = SqlCommandHelper.ExcecuteToDataTableJson(datamodel.TableName, dict).dataTable;

        //        var data = JsonConvert.SerializeObject(dataTable, Formatting.None, new IsoDateTimeConverter()
        //        {
        //            DateTimeFormat = "d"
        //        });
        //        // var json = JsonConvert.DeserializeObject(data);
        //        return Ok(new
        //        {
        //            Data = data,


        //        });


        //    }
        //    catch (Exception ex)
        //    {

        //        return InternalServerError(ex);
        //    }

        //}
        [HttpGet]
        [Route("VanSalesService/MobileController/closingshift")]
        public IHttpActionResult Closing_Shift([FromUri] pos_closing_shift_sel datamodel)
        {
            try
            {


                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("username", datamodel.username);

                dict.Add("from", datamodel.from);

                dict.Add("to", datamodel.to);

                DataTable dataTable = SqlCommandHelper.ExcecuteToDataTableJson("pos_closing_shift_sel", dict).dataTable;

                var data = JsonConvert.SerializeObject(dataTable, Formatting.None, new IsoDateTimeConverter()
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
        [Route("VanSalesService/Rec/GetCustRecBalanceData")] //مدفوعات العميل ف سند القبض مع الفواتير
        public IHttpActionResult GetRecRow([FromUri] int custid)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("custid", custid);
                

                var tb = SqlCommandHelper.ExcecuteToDataTableJson("cust_rec_balance_bycustid", dict).dataTable;
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

        [HttpPost]
        [Route("VanSalesService/MobileController/Acc_Statment")]
        public IHttpActionResult Acc_Statment([FromBody] pos_acc_statment datamodel)
        {
            try
            {

                Dictionary<object, object> dict = new Dictionary<object, object>();
                dict.Add("showbalance", datamodel.showbalance);
                dict.Add("begbalance", datamodel.begbalance);
                dict.Add("sumtype", datamodel.sumtype);
                dict.Add("chartid", datamodel.chartid);
                dict.Add("posted", datamodel.posted);
                dict.Add("dtefrom", datamodel.dtefrom);
                dict.Add("dteto", datamodel.dteto);
                dict.Add("ccid", datamodel.ccid);

                DataTable dataTable = SqlCommandHelper.ExcecuteToDataTableJson("Acc_statment", dict).dataTable;

                var data = JsonConvert.SerializeObject(dataTable, Formatting.None, new IsoDateTimeConverter()
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
