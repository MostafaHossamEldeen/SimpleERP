using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMax.DbModels;
namespace Emax.Vansales.Service.Models
{
    public class st_item
    {
        public int itemid { get; set; }
        public string itemcode { get; set; }
        public string itemcode2 { get; set; }
        public string itemcode3 { get; set; }
        public string itembarcode { get; set; }
        public string itembarcode2 { get; set; }
        public string itemname { get; set; }
        public string itemename { get; set; }
        public string itemdesc { get; set; }
        public Nullable<int> unitid { get; set; }
        public string unitname { get; set; }
        public Nullable<int> groupid { get; set; }
        public string groupname { get; set; }
        public Nullable<int> itemtypeid { get; set; }
        public string itemtypename { get; set; }
        public Nullable<int> suppid { get; set; }
        public string suppname { get; set; }
        public Nullable<byte> itemstop { get; set; }
        public string itemstopname { get; set; }
        public Nullable<decimal> minqty { get; set; }
        public Nullable<decimal> maxqty { get; set; }
        public Nullable<decimal> pprice { get; set; }
        public Nullable<decimal> cprice { get; set; }
        public Nullable<decimal> sprice { get; set; }
        public Nullable<decimal> vat { get; set; }
        public Nullable<decimal> vprice { get; set; }
        public Nullable<decimal> fprice { get; set; }
        public Nullable<decimal> commp { get; set; }
        public Nullable<System.DateTime> oferbdate { get; set; }
        public Nullable<decimal> descp { get; set; }
        public Nullable<System.DateTime> oferedate { get; set; }
        public Nullable<bool> oferstop { get; set; }
        public string itempic { get; set; }
        public string itemfield1 { get; set; }
        public string itemfield2 { get; set; }
        public Nullable<int> itemcat1 { get; set; }
        public string itemcatname1 { get; set; }
        public Nullable<int> itemcat2 { get; set; }
        public string itemcatname2 { get; set; }
        public Nullable<decimal> balance { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<s_invdtl> s_invdtls { get; set; }
        public virtual st_group st_group { get; set; }
        public virtual st_unit st_unit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<st_itemunit> st_itemunit { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<st_itemwh> st_itemwh { get; set; }
    }
}
