using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emax.Vansales.Service.Models
{
    public class s_smans
    {
        public int smanid { get; set; }
        public string smanname { get; set; }
        public string smanmob { get; set; }
        public Nullable<byte> smantype { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<s_invs> s_inv { get; set; }
    }
}