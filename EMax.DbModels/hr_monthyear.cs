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
    
    public partial class hr_monthyear
    {
        public int monyrid { get; set; }
        public Nullable<int> monthsal { get; set; }
        public Nullable<int> yearsal { get; set; }
        public string monyrname { get; set; }
        public Nullable<System.DateTime> startdate { get; set; }
        public Nullable<System.DateTime> enddate { get; set; }
        public int monyrtype { get; set; }
        public string fyear { get; set; }
    }
}