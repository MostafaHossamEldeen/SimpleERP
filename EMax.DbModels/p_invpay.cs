//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EMax.DbModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class p_invpay
    {
        public int invpayid { get; set; }
        public Nullable<int> paytypeid { get; set; }
        public string payname { get; set; }
        public Nullable<int> paychartid { get; set; }
        public Nullable<decimal> payvalue { get; set; }
        public string payno { get; set; }
        public string payref { get; set; }
        public Nullable<int> branchid { get; set; }
        public Nullable<System.DateTime> invdate { get; set; }
        public Nullable<int> natureinv { get; set; }
        public Nullable<int> suppid { get; set; }
        public string pinvno { get; set; }
        public string suppname { get; set; }
        public string branchname { get; set; }
        public string fyear { get; set; }
        public Nullable<int> pinvid { get; set; }
    
        public virtual p_inv p_inv { get; set; }
    }
}
