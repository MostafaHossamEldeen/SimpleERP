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
    
    public partial class s_invmeasure
    {
        public int imeasurid { get; set; }
        public int invid { get; set; }
        public int custid { get; set; }
        public string rsphd { get; set; }
        public string rclyd { get; set; }
        public string raxisd { get; set; }
        public string lsphd { get; set; }
        public string lclyd { get; set; }
        public string laxisd { get; set; }
        public string rsphr { get; set; }
        public string rclyr { get; set; }
        public string raxisr { get; set; }
        public string lsphr { get; set; }
        public string lclyr { get; set; }
        public string laxisr { get; set; }
        public string ipc { get; set; }
        public string note { get; set; }
    
        public virtual s_customers s_customers { get; set; }
        public virtual s_inv s_inv { get; set; }
    }
}
