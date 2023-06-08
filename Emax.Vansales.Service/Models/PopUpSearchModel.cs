using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emax.Vansales.Service.Models
{

    public class PopUpSearchModelEmpSalaryPrep
    {


        public string TableName { get; set; }
        public string SearchVal { get; set; }
        public int monyrid { get; set; }
    }

    public class PopUpSearchModelEmpSalaryPaid
    {


        public string TableName { get; set; }
        public string SearchVal { get; set; }
        public int monyrid { get; set; }
    }

    public class PopUpSearchModel
    {

     
        public string TableName { get; set; }
        public string SearchVal { get; set; }
    }

    public class codeandunitsearch
    {


        public string TableName { get; set; }
        public string SearchVal { get; set; }
        public int unitid { get; set; }
    }
    public class SearchItemsRtnModel
    {


        public string TableName { get; set; }
        public string SearchVal { get; set; }
        public string invid { get; set; }
    }


    public class SearchItemModel
    {

        public string TableName { get; set; }
        public string itemid { get; set; }
        public string branchid { get; set; }
        public string itemcode { get; set; }
        public string barcode1 { get; set; } 
        public string barcode2 { get; set; }
    }
    public class ItemQtyModel
    {

        public int TableName { get; set; }
        public int rtn_sinvno { get; set; }
        public int sinvno { get; set; }
        public int itemid { get; set; }
        public int actiontype { get; set; }
        public int invdtlid { get; set; }
    }
    #region  stock
    public class st_transactions_sel_search
    {
        public string TableName { get; set; }
        public string SearchVal { get; set; }
        public int transtype { get; set; }
        public int branchid { get; set; }
    }
    //public class st_transactions_sel_searchall
    //{
    //    public string TableName { get; set; }
    //    public string SearchVal { get; set; }
    //    public int transtype { get; set; }

    //}
    public class st_transactions_receipt_sel_search
    {
        //public string TableName { get; set; }
        
        public string transferno { get; set; }
         
    }
    #endregion
    #region  Seles
    public class s_inv_sel_search
    {
        public string TableName { get; set; }
        public string SearchVal { get; set; }
         
    }

    public class s_inv_sel_search_mob
    {
        public string TableName { get; set; }
        public string SearchVal { get; set; }
        public string user_id { get; set; }

    }
    public class s_invcode_sel_search
    {
        public string TableName { get; set; }
        public string sinvno { get; set; }

    }
    public class cust_sel_search
    {
        public string TableName { get; set; }
        public string custcode { get; set; }

    }

    public class cust_ins
    {
        public string custname { get; set; }
        public string custadd { get; set; }
        public string custmob { get; set; }
        public string custvat { get; set; }
        public string custcode { get;}
        public int sgrpid { get; set; }
        

    }
    #endregion
    #region  Purchases
    public class supp_sel_search
    {
        public string TableName { get; set; }
        public string suppid { get; set; }
    }
    public class p_invcode_sel_search
    {
        public string TableName { get; set; }
        public string docno { get; set; }

    }
    public class trans
    {
        public int reqid { get; set; }
        public int frombranchid { get; set; }
    }


    public class SearchItemsPRtnModel
    {


        public string TableName { get; set; }
        public string SearchVal { get; set; }
        public string docid { get; set; }
    }
    #endregion
    #region Chart
    public class chart_sel_search
    {
        public string TableName { get; set; }
        public string chartid { get; set; }
    }
    #endregion

    #region GL
    public class gl_chart_sel_search
    {
        public string TableName { get; set; }
        public string SearchVal { get; set; }
        public int legertype { get; set; }
       
    }
    public class gl_paycharts
    {
        public string TableName { get; set; }
        public int Paytypeid { get; set; }
        public int branchid { get; set; }

    }
    public class vouchers_Post
    {

      //  public int? posttype { get; set; }

        //public bool? post { get; set; }
        public string puser { get; set; }
        public int vchrid { get; set; }
    }

    public class recdoc_sel_search_mob
    {
        //public string TableName { get; set; }
        public string SearchVal { get; set; }
        public string user_id { get; set; }

    }

    public class pos_acc_statment
    {
        public Nullable<bool> showbalance { get; set; }
        public Nullable <bool> begbalance { get; set; }
        public Nullable<int> sumtype { get; set; }
        public int chartid { get; set; }
        public Nullable<int> posted { get; set; }
        public Nullable <DateTime> dtefrom { get; set; }
        public Nullable <DateTime> dteto { get; set; }
        public Nullable <int> ccid { get; set; }

    }
    #endregion

    #region HR
    public class emp_sel_search
    {
        public string TableName { get; set; }
        public string empcode { get; set; }
        public int empid { get; set; }
    }

    public class salary_sel_search
    {
        public string TableName { get; set; }
        public string svnatuleid { get; set; }
        public int empid { get; set; }
    }

    public class salary_Prep_Post
    {
        public int sprepid { get; set; }
    }
    #endregion
    public class pos_closing_shift_sel
    {
        public string username { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }

    }
    public class Exp_sel_search
    {
        public string TableName { get; set; }
        public string expid { get; set; }
    }
}