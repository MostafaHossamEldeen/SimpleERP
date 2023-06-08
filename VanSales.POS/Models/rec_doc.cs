using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanSales.POS.Models
{
  public  class rec_doc
    {
        public int recid { get; set; }
        public string recno { get; set; }
        public string recdocno { get; set; }
        public Nullable<int> recbranchid { get; set; }
        public string branchname { get; set; }
        public Nullable<System.DateTime> recdate { get; set; }
        public string recman { get; set; }
        public Nullable<decimal> recvalue { get; set; }
        public string recnotes { get; set; }
        public string recuser { get; set; }
        public Nullable<bool> postacc { get; set; }
        public Nullable<int> vchrid { get; set; }
        public Nullable<int> ccid { get; set; }
        public string ccname { get; set; }
        public Nullable<int> paytypeid { get; set; }
        public string paytypename { get; set; }
        public Nullable<int> paychartid { get; set; }
        public string payref { get; set; }
        public string paynotes { get; set; }
        public Nullable<int> fromchartid { get; set; }
        public Nullable<int> rectype { get; set; }
        public string rectypename { get; set; }
        public string recdocimg { get; set; }
        public string fyear { get; set; }
        public Nullable<int> custid { get; set; }
        public string custname { get; set; }
         
    }
}
