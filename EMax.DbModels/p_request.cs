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
    
    public partial class p_request
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public p_request()
        {
            this.p_reqdtls = new HashSet<p_reqdtls>();
        }
    
        public int reqid { get; set; }
        public string reqno { get; set; }
        public string reqdocno { get; set; }
        public Nullable<System.DateTime> reqdate { get; set; }
        public Nullable<int> branchid { get; set; }
        public string branchname { get; set; }
        public string reqdesc { get; set; }
        public string userreq { get; set; }
        public Nullable<bool> reqcase { get; set; }
        public string reqaction { get; set; }
        public string fyear { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<p_reqdtls> p_reqdtls { get; set; }
        public virtual sys_branch sys_branch { get; set; }
    }
}