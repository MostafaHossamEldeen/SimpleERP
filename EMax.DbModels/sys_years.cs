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
    
    public partial class sys_years
    {
        public int yearid { get; set; }
        public string fyaer { get; set; }
        public Nullable<System.DateTime> yfrom { get; set; }
        public Nullable<System.DateTime> yclosed { get; set; }
        public Nullable<System.DateTime> yto { get; set; }
        public string ynotes { get; set; }
        public Nullable<bool> yisclosed { get; set; }
    }
}
