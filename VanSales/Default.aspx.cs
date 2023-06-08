using Emax.CoreCore;
using Emax.Dal;
using System;
using System.Web;
using System.Web.UI;

namespace VanSales
{
    public partial class _Default : EmaxBasepage
    {

        protected override void OnInit(EventArgs e)
        {
            pageid = "5000000";

            base.OnInit(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            imglogo.Src = SqlCommandHelper.GetTokenKey("complogo", HttpContext.Current.Request.Cookies["Token"].Value);
            dvshortmenu.DataBind();
            //Sales_Card 
            var st_Invtotalvalue= SqlCommandHelper.ExcecuteToDataTable("CrdTotalInv").dataTable;
            lbl_NoOfDailySinv.Value = EmaxGlobals.NullToIntZero(st_Invtotalvalue.Rows[0]["NoOfDailySinv"]);
            lbl_TotalOfDailySinv.Value = EmaxGlobals.NullToIntZero(st_Invtotalvalue.Rows[0]["TotalOfDailySinv"]);

            var st_InvRtntotalvalue = SqlCommandHelper.ExcecuteToDataTable("TotalRtnSinvCard").dataTable;
            lbl_NoOfDailyRtnSinv.Value = EmaxGlobals.NullToIntZero(st_InvRtntotalvalue.Rows[0]["NoOfDailyRtnSinv"]);
            lbl_TotalOfDailyRtnSinv.Value = EmaxGlobals.NullToIntZero(st_InvRtntotalvalue.Rows[0]["TotalOfDailyRtnSinv"]);

            //Pay_And_Rec_Card
            var st_Pay = SqlCommandHelper.ExcecuteToDataTable("Dailly_Pay_Card").dataTable;
            lbl_NoOfDailyPay.Value = EmaxGlobals.NullToIntZero(st_Pay.Rows[0]["NoOfDailyPay"]);
            lbl_TotalOfDailyPay.Value = EmaxGlobals.NullToIntZero(st_Pay.Rows[0]["TotalOfDailyPay"]);

            var st_Rec = SqlCommandHelper.ExcecuteToDataTable("Dailly_Rec_Card").dataTable;
            lbl_NoOfDailyRec.Value = EmaxGlobals.NullToIntZero(st_Rec.Rows[0]["NoOfDailyRec"]);
            lbl_TotalOfDailyRec.Value = EmaxGlobals.NullToIntZero(st_Rec.Rows[0]["TotalOfDailyRec"]);

            var st_Pur = SqlCommandHelper.ExcecuteToDataTable("Daily_Pur_Card").dataTable;
            lbl_NoOfDailyPur.Value = EmaxGlobals.NullToIntZero(st_Pur.Rows[0]["NoOfDailyPur"]);
            lbl_TotalOfDailyPur.Value = EmaxGlobals.NullToIntZero(st_Pur.Rows[0]["TotalOfDailyPur"]);

            var st_Rtn_Pur = SqlCommandHelper.ExcecuteToDataTable("Daily_Rtn_Pur_Card").dataTable;
            lbl_NoOfDailyRtnPur.Value = EmaxGlobals.NullToIntZero(st_Rtn_Pur.Rows[0]["NoOfDailyRtnPur"]);
            lbl_TotalOfDailyRtnPur.Value = EmaxGlobals.NullToIntZero(st_Rtn_Pur.Rows[0]["TotalOfDailyRtnPur"]);
            //اصناف وصلت لحد الطلب 
            var st_MIN_Item = SqlCommandHelper.ExcecuteToDataTable("CRD_ITEM_MINQTY").dataTable;
            lbl_NoOfItemMINQTY.Value = EmaxGlobals.NullToIntZero(st_MIN_Item.Rows[0]["NoOfItemMINQTY"]);
            //اصناف وصلت لاقصي كميه 
            var st_Max_Item = SqlCommandHelper.ExcecuteToDataTable("CRD_ITEM_MAXQTY").dataTable;
            lbl_NoOfItemMaxQTY.Value = EmaxGlobals.NullToIntZero(st_Max_Item.Rows[0]["NoOfItemMaxQTY"]);


        }

        protected void dvshortmenu_DataBinding(object sender, EventArgs e)
        {
            dvshortmenu.DataSource = SqlCommandHelper.ExcecuteToDataTable("sys_user_short_menu_sel").dataTable;
        }

    }
}