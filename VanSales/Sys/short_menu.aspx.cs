using Emax.CoreCore;
using Emax.Dal;
using Repository.Ado;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VanSales.Sys
{
    public partial class short_menu : EmaxBasepage
    {
        protected override void OnInit(EventArgs e)
        {
            pageid = "39";
            base.OnInit(e);
        }
        string userid;
        protected void Page_Load(object sender, EventArgs e)
        {
            userid = SqlCommandHelper.GetTokenKey("userid", Request.Cookies["Token"].Value);
            if (!IsPostBack)
            {
                
                gvshortmenu.DataBind();
            }
        }
        DataTable GvSource()
       
        {
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("userid", userid);
            return SqlCommandHelper.ExcecuteToDataTable("sys_userpages_shortmenu_sel",dict).dataTable;
        }
        protected void gvshortmenu_DataBinding(object sender, EventArgs e)
        {
            gvshortmenu.DataSource = GvSource();
        }

        protected void gvshortmenu_BatchUpdate(object sender, DevExpress.Web.Data.ASPxDataBatchUpdateEventArgs e)
        {
            try
            {
                
                var updated = e.UpdateValues;
                int marriedEmployees = 0;
                foreach (var check in updated)
                {
                    if (EmaxGlobals.NullToBool( check.NewValues[1]) == true)
                    {
                        marriedEmployees++;
                    }
                   else if (EmaxGlobals.NullToBool(check.NewValues[1]) == false)
                    {
                        marriedEmployees--;
                    }
                }
                
                for (int i = 0; i < gvshortmenu.VisibleRowCount; i++)
                {

                    DataRow row = gvshortmenu.GetDataRow(i);

                    bool isMarried = EmaxGlobals.NullToBool( row.ItemArray[6]);
                        //(CheckBox)row.Field("shortmenu");
                   if (isMarried==true) 
                        marriedEmployees++;
                }
                  
                if (marriedEmployees > 9)
                {
                    e.Handled = true;
                    gvshortmenu.JSProperties["cperrors"] = "لايمكن اختيار اكتر من 9 ";
                        gvshortmenu.JSProperties["cpicon"] = "error";
                       return;
                }
                foreach (var item in updated)
                {
                    
                    if ((bool)item.NewValues["shortmenu"] == true)
                    {
                       
                        int pageid =EmaxGlobals.NullToIntZero( item.Keys["pageid"]);
                        string dbname =EmaxGlobals.NullToEmpty( item.NewValues["pagenamer"]);
                        Dictionary<object, object> dict = new Dictionary<object, object>();
                        dict.Add("userid", userid);
                        var res = SqlCommandHelper.ExecuteNonQuery("sys_userdbord_ins", item.NewValues, dict, true,item.Keys);
                        gvshortmenu.DataBind();
                        // var res = SaveData("sys_userdbord_ins", new List<object> {userid, pageid, dbname }, null,null, true,false,null, null );
                    }
                    else
                    {
                        Dictionary<object, object> dict = new Dictionary<object, object>();
                        dict.Add("userid", userid);
                        var resdel = SqlCommandHelper.ExecuteNonQuery("sys_userdbord_del", null, dict, true, item.Keys);
                    }
                }
                e.Handled = true;
                gvshortmenu.JSProperties["cperrors"] = "تم حفظ التغيرات بنجاح";
                gvshortmenu.JSProperties["cpicon"] = "success";
            }
            catch (Exception ex)
            {
                gvshortmenu.JSProperties["cperrors"] = ex.Message;
                gvshortmenu.JSProperties["cpicon"] = "error";
            }
        }
    }
}
 
