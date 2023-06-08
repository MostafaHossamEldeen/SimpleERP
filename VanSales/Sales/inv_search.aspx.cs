using VanSales.DBClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Circals.pages
{
    public partial class inv_search : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ASPxGridView1_HtmlRowCreated(object sender, DevExpress.Web.ASPxGridViewTableRowEventArgs e)
        {

            e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#bbbb';");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='';");         

    }

        protected void ASPxGridView1_CustomCallback(object sender, DevExpress.Web.ASPxGridViewCustomCallbackEventArgs e)
        {
            // SqlDataSource1.SelectParameters["itemid"].DefaultValue=e.Parameters[0].ToString();
            // SqlDataSource1.SelectParameters[ "item"].DefaultValue = e.Parameters[0].ToString();
            //SqlDataSource1.Select(DataSourceSelectArguments.Empty);

        }
    }
}