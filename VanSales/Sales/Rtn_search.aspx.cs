using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.Sales
{
    public partial class Rtn_search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void ASPxGridView1_HtmlRowCreated(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
        {

            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#bbbb';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");
        }
    }
}
