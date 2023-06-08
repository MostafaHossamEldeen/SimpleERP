using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;
using VanSales.Service.Models;

namespace VanSales.Service.Controllers
{
    public class ItemsController : ApiController
    {
        // GET: Items
        SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["VanSales"].ConnectionString);
        [HttpGet]

        [Route("VanSalesService/items/ItemsData", Name = "ItemsData")]
        public IHttpActionResult ItemsData(int pageNo = 1, int pageSize = 10)
        {
            try
            {

                int skip = (pageNo - 1) * pageSize;

                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                    sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("exec st_items_sel", sqlConnection);

                DataTable tb = new DataTable();
                sqlDataAdapter.Fill(tb);



                // Get total number of records
                int total = tb.Rows.Count;

                // Select the customers based on paging parameters
                var tborderd = tb.AsEnumerable().Select(i => new{ 
                    itemid=i.Field<int>("itemid"),
                   itemcode= i.Field<string>("itemcode"),
                   itemname= i.Field<string>("itemname"),
                    itemename=i.Field<string>("itemename")
                , itemdesc=i.Field<string>("itemdesc"),
                  sprice=  i.Field<decimal?>("sprice"),
               vprice= i.Field<decimal?>("vprice")
                , vat=i.Field<decimal?>("vat")
                ,stockbalance=i.Field<decimal?>("balance")
                ,imgpath= i.Field<string>("itempic")
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
    }
}