using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Emax.VanSales.Service.Models;
using EMax.Dal.Context;
using EMax.Dal.Repository;
using EMax.DbModels;

namespace VanSales.Service.Controllers.Lookup
{
   // [Authorize]
    public class LookupController : ApiController
    {
        VanSalesDbModelEntities van = new VanSalesDbModelEntities();
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["VanSales"].ConnectionString);
        #region تم النقل
        /*  [HttpGet]

        [Route("VanSalesService/Customers/CustomerDataData", Name = "CustomerDataData")]

        public IHttpActionResult CustomerDataData([FromUri] string custname="")
        {
            try
            {
                
                UnitOfWork unitOfWork = new UnitOfWork();
             

                Entities<s_customers> entities = new Entities<s_customers>(unitOfWork);
                var custlist = entities.FindAll(i => i.custname.Contains(custname)).Select(i=>new { i.custid,i.custname,i.custvat,i.custadd,i.custmob }).ToList();
               
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
        }*/
        #endregion
    }

}

