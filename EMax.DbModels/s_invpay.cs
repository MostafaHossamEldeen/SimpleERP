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
    
    public partial class s_invpay
    {
        public int invpayid { get; set; }
        public Nullable<int> invid { get; set; }
        public Nullable<int> paytypeid { get; set; }
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
    
        public virtual s_inv s_inv { get; set; }
        public virtual sys_paytype sys_paytype { get; set; }
    }
}