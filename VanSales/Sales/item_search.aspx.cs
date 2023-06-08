using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales
{
    public partial class item_search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gv_items_HtmlRowCreated(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#bbbb';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");
        }

        protected void btnsearch_Click(object sender, ImageClickEventArgs e)
        {
            //int row = gv_items.FocusedRowIndex;
            //gv_items.Selection.UnselectRow(row);
            //Response.Redirect(HttpContext.Current.Request.Url.AbsolutePath);
        }
    }
}