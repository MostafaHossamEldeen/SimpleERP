using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emax.Vansales.Service.Models
{
    public class sys_paytypes
    {
        public int paytypeid { get; set; }
        public string paytname { get; set; }
        public string paytename { get; set; }
        public string modids { get; set; }
        public Nullable<decimal> feeds { get; set; }
        public Nullable<bool> paybasic { get; set; }
        public Nullable<byte> paychk { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<s_invpays> s_invpay { get; set; }
    }
}
