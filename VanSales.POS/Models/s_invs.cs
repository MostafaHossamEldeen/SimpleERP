using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace VanSales.POS.Models
{
    public class s_invs
    {
        public int sinvid { get; set; }
        public Nullable<int> snature { get; set; }
        public string snaturename { get; set; }
        public string sinvno { get; set; }
        public string sinvdocno { get; set; }
        public Nullable<System.DateTime> sinvdata { get; set; }
        public Nullable<System.TimeSpan> sinvtime { get; set; }
        public Nullable<int> branchid { get; set; }
        public string branchname { get; set; }
        public Nullable<int> ccid { get; set; }
        public string ccname { get; set; }
        public Nullable<int> sinvpay { get; set; }
        public string sinvpayname { get; set; }
        public Nullable<int> custid { get; set; }
        public string custname { get; set; }
        public string custvat { get; set; }
        public string custadd { get; set; }
        public Nullable<bool> custvatapply { get; set; }
        public string suser { get; set; }
        public Nullable<int> smanid { get; set; }
        public string smanname { get; set; }
        public string snotes { get; set; }
        public Nullable<bool> postst { get; set; }
        public Nullable<bool> posyacc { get; set; }
        public string poststtxt { get; set; }
        public string postacctxt { get; set; }
        public Nullable<int> vochrid { get; set; }
        public Nullable<decimal> totalinv { get; set; }
        public Nullable<decimal> discp { get; set; }
        public Nullable<decimal> discv { get; set; }
        public Nullable<decimal> netbvat { get; set; }
        public Nullable<decimal> vatvalue { get; set; }
        public Nullable<decimal> netavat { get; set; }
        public Nullable<decimal> restvalue { get; set; }
        public Nullable<int> docid { get; set; }
        public string docno { get; set; } 
        public Nullable<int> invid { get; set; }
        public string invno { get; set; }
        public string fyear { get; set; }
        public string invdoc { get; set; }
        public string custmobile { get; set; }
        public Nullable<bool> withoutinv { get; set; }
        public Nullable<Int16> invchk { get; set; }
        [NotMapped]
        public string compneyname { get; set; }
        public  List<s_invdtl> s_invdtls { get; set; }
        public List<s_invmeasures> s_invmeasures { get; set; }
        public  List<s_invpays> s_invpay { get; set; }
    }
}
