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
    
    public partial class s_order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public s_order()
        {
            this.s_orderdtls = new HashSet<s_orderdtls>();
        }
    
        public int soid { get; set; }
        public string sono { get; set; }
        public string sodocno { get; set; }
        public Nullable<System.DateTime> sodate { get; set; }
        public Nullable<int> branchid { get; set; }
        public string branchname { get; set; }
        public Nullable<int> custid { get; set; }
        public string custname { get; set; }
        public Nullable<decimal> total { get; set; }
        public Nullable<decimal> descp { get; set; }
        public Nullable<decimal> descv { get; set; }
        public Nullable<decimal> netbvat { get; set; }
        public Nullable<decimal> vatvalue { get; set; }
        public Nullable<decimal> netavat { get; set; }
        public string sonotes { get; set; }
        public string ouser { get; set; }
        public Nullable<int> otype { get; set; }
        public string otypename { get; set; }
        public string fyear { get; set; }
        public Nullable<bool> sinvc { get; set; }
    
        public virtual s_customers s_customers { get; set; }
        public virtual sys_branch sys_branch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<s_orderdtls> s_orderdtls { get; set; }
    }
}