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
    
    public partial class st_transactions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public st_transactions()
        {
            this.st_transdtls = new HashSet<st_transdtls>();
        }
    
        public Nullable<System.DateTime> trandate { get; set; }
        public Nullable<int> branchid { get; set; }
        public string branchname { get; set; }
        public string transno { get; set; }
        public string trandocno { get; set; }
        public Nullable<byte> naturetran { get; set; }
        public string naturename { get; set; }
        public Nullable<byte> transtype { get; set; }
        public string transtypename { get; set; }
        public Nullable<int> ccid { get; set; }
        public string ccname { get; set; }
        public Nullable<bool> postst { get; set; }
        public Nullable<bool> postacc { get; set; }
        public Nullable<int> vochrid { get; set; }
        public string username { get; set; }
        public string trannotes { get; set; }
        public Nullable<int> branchtoid { get; set; }
        public string branchtoname { get; set; }
        public string transferno { get; set; }
        public Nullable<int> cctoid { get; set; }
        public string cctoname { get; set; }
        public int transid { get; set; }
        public string fyear { get; set; }
        public Nullable<bool> receipt { get; set; }
        public string vochrno { get; set; }
    
        public virtual sys_branch sys_branch { get; set; }
        public virtual sys_branch sys_branch1 { get; set; }
        public virtual sys_costcenter sys_costcenter { get; set; }
        public virtual sys_costcenter sys_costcenter1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<st_transdtls> st_transdtls { get; set; }
    }
}
