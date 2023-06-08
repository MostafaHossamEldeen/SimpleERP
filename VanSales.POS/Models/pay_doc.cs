using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VanSales.POS.Models
{
  public  class pay_doc
    {
        public int pdid { get; set; }
        public string pdno { get; set; }
        public string pddocno { get; set; }
        public Nullable<int> pdbranchid { get; set; }
        public string branchname { get; set; }
        public Nullable<System.DateTime> pddate { get; set; }
        public string pdman { get; set; }
        public string paidto { get; set; }
        public string pdnotes { get; set; }
        public string pduser { get; set; }
        public Nullable<bool> postacc { get; set; }
        public Nullable<int> vchrid { get; set; }
        public Nullable<int> ccid { get; set; }
        public string ccname { get; set; }
        public Nullable<int> paytypeid { get; set; }
        public string paytypename { get; set; }
        public Nullable<int> paychartid { get; set; }
        public string payref { get; set; }
        public string paynotes { get; set; }
        public Nullable<int> paidchartid { get; set; }
        public Nullable<int> paidtype { get; set; }
        public string paidtypename { get; set; }
        public Nullable<int> vattype { get; set; }
        public string vattypename { get; set; }
        public Nullable<decimal> vatvalue { get; set; }
        public Nullable<decimal> pdbvat { get; set; }
        public Nullable<decimal> pdavat { get; set; }
        public string pddocimg { get; set; }
        public string fyear { get; set; }
    }
}
