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
    
    public partial class hr_salaryprep
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hr_salaryprep()
        {
            this.hr_salarydtls = new HashSet<hr_salarydtls>();
        }
    
        public int sprepid { get; set; }
        public Nullable<int> sprepno { get; set; }
        public Nullable<System.DateTime> sprepdate { get; set; }
        public Nullable<int> monyrid { get; set; }
        public string monyrname { get; set; }
        public string userprep { get; set; }
        public Nullable<bool> postacc { get; set; }
        public Nullable<int> vochrid { get; set; }
        public string sprepnotes { get; set; }
        public Nullable<int> branchid { get; set; }
        public string branchname { get; set; }
        public string fyear { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hr_salarydtls> hr_salarydtls { get; set; }
    }
}
