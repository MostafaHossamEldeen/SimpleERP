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
    
    public partial class s_customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public s_customers()
        {
            this.s_inv = new HashSet<s_inv>();
            this.s_order = new HashSet<s_order>();
            this.s_invmeasure = new HashSet<s_invmeasure>();
        }
    
        public int custid { get; set; }
        public string custcode { get; set; }
        public string custname { get; set; }
        public string custename { get; set; }
        public Nullable<int> sgrpid { get; set; }
        public string sgrpname { get; set; }
        public string custadd { get; set; }
        public string custtel { get; set; }
        public string custmob { get; set; }
        public string custvat { get; set; }
        public Nullable<int> custchartid { get; set; }
        public string custcardno { get; set; }
        public Nullable<int> custpoints { get; set; }
        public Nullable<int> smanid { get; set; }
        public string smanname { get; set; }
        public Nullable<decimal> discp { get; set; }
        public Nullable<decimal> custlimit { get; set; }
        public Nullable<int> custlimitd { get; set; }
        public Nullable<bool> stopcust { get; set; }
        public Nullable<bool> vatapply { get; set; }
        public Nullable<byte> custtype { get; set; }
    
        public virtual gl_chart gl_chart { get; set; }
        public virtual s_custgroup s_custgroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<s_inv> s_inv { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<s_order> s_order { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<s_invmeasure> s_invmeasure { get; set; }
    }
}
