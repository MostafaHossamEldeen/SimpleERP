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
    
    public partial class st_itemunit
    {
        public int itemunitid { get; set; }
        public Nullable<int> itemid { get; set; }
        public Nullable<int> unitid { get; set; }
        public string unitname { get; set; }
        public Nullable<decimal> factor { get; set; }
        public string barcode1 { get; set; }
        public string barcode2 { get; set; }
        public Nullable<decimal> pprice { get; set; }
        public Nullable<decimal> cprice { get; set; }
        public Nullable<decimal> sprice { get; set; }
        public Nullable<decimal> vat { get; set; }
        public Nullable<decimal> vprice { get; set; }
        public Nullable<decimal> fprice { get; set; }
        public string itemcode { get; set; }
        public string itemcode2 { get; set; }
        public string itemcode3 { get; set; }
        public string itemname { get; set; }
        public string itemename { get; set; }
        public string itemdesc { get; set; }
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
        public string itempic { get; set; }
        public string itemfield1 { get; set; }
        public string itemfield2 { get; set; }
        public Nullable<int> itemcat1 { get; set; }
        public string itemcatname1 { get; set; }
        public Nullable<int> itemcat2 { get; set; }
        public string itemcatname2 { get; set; }
        public Nullable<bool> isbasic { get; set; }
    
        public virtual p_supplier p_supplier { get; set; }
        public virtual st_items st_items { get; set; }
        public virtual st_unit st_unit { get; set; }
        public virtual st_itemunit st_itemunit1 { get; set; }
        public virtual st_itemunit st_itemunit2 { get; set; }
        public virtual st_itemunit st_itemunit11 { get; set; }
        public virtual st_itemunit st_itemunit3 { get; set; }
    }
}
