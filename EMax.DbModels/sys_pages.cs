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
    
    public partial class sys_pages
    {
        public int pageid { get; set; }
        public string pagename { get; set; }
        public string pagenamer { get; set; }
        public string pageurl { get; set; }
        public Nullable<byte> pagetype { get; set; }
        public Nullable<int> hasnew { get; set; }
        public Nullable<int> hassave { get; set; }
        public Nullable<int> hasopen { get; set; }
        public Nullable<int> haspostacc { get; set; }
        public Nullable<int> haspoststock { get; set; }
        public Nullable<int> hasdelete { get; set; }
    }
}
