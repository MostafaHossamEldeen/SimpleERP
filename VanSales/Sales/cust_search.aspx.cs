using System;

namespace VanSales
{
    public partial class cust_search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ////
        }
        protected void ASPxGridView1_HtmlRowCreated(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
        {
            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#bbbb';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");
        }
    }
}