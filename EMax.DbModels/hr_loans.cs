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
    
    public partial class hr_loans
    {
        public int loanid { get; set; }
        public string loanno { get; set; }
        public Nullable<System.DateTime> loandate { get; set; }
        public Nullable<int> empid { get; set; }
        public string empname { get; set; }
        public Nullable<decimal> lvalue { get; set; }
        public Nullable<int> lcrditcahrtid { get; set; }
        public Nullable<bool> postacc { get; set; }
        public Nullable<int> vochrid { get; set; }
        public Nullable<int> ltype { get; set; }
        public string ltypename { get; set; }
        public Nullable<int> lnature { get; set; }
        public string lnaturename { get; set; }
        public Nullable<bool> salarydeduct { get; set; }
        public string loannotes { get; set; }
        public Nullable<int> salid { get; set; }
        public string fyear { get; set; }
    }
}
