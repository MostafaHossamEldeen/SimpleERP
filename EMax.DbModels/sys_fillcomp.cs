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
    
    public partial class sys_fillcomp
    {
        public int compfillid { get; set; }
        public Nullable<int> compid { get; set; }
        public string compname { get; set; }
        public string compename { get; set; }
        public Nullable<byte> comptype { get; set; }
        public Nullable<int> citemid { get; set; }
        public string citemname { get; set; }
        public string citemename { get; set; }
        public Nullable<int> citemtype { get; set; }
        public Nullable<bool> citembasic { get; set; }
    }
}
