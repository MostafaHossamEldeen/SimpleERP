using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emax.Vansales.Service.Models
{
    public class s_invpays
    {
        public int invpayid { get; set; }
        public Nullable<int> invid { get; set; }
        public Nullable<int> sinvid { get; set; }
        public Nullable<int> rtninvid { get; set; }
        public Nullable<int> paytypeid { get; set; }
        public Nullable<int> paytype { get; set; }
        public string payname { get; set; }
        public Nullable<int> paychartid { get; set; }
        public Nullable<decimal> payvalue { get; set; }
        public string payno { get; set; }
        public string payref { get; set; }
        public Nullable<int> branchid { get; set; }
        public Nullable<System.DateTime> invdate { get; set; }
        public Nullable<int> natureinv { get; set; }
        public Nullable<int> custid { get; set; }
        public string sinvno { get; set; }
        public string custname { get; set; }
        public string branchname { get; set; }
        public string fyear { get; set; }

        public virtual s_invs s_inv { get; set; }
        public virtual sys_paytypes sys_paytype { get; set; }
    }
}