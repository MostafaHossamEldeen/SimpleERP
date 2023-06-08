﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emax.Vansales.Service.Models
{
    public class InvdetViewModel
    {
      
            public int invdtlid { get; set; }
            public Nullable<int> sinvid { get; set; }
            public Nullable<int> itemid { get; set; }
        public string itemname { get; set; }
        public string itemcode { get; set; }
            public Nullable<int> unitid { get; set; }
            public string unitname { get; set; }
            public Nullable<decimal> qty { get; set; }
            //public Nullable<decimal> factor { get; set; }
            public Nullable<decimal> price { get; set; }
            //public Nullable<decimal> icost { get; set; }
            public Nullable<decimal> value { get; set; }
            public Nullable<decimal> discp { get; set; }
            public Nullable<decimal> discvalue { get; set; }
            public Nullable<decimal> netvalue { get; set; }
            public Nullable<decimal> vatvalue { get; set; }
            //public string itemnotes { get; set; }
            //public Nullable<bool> bonus { get; set; }
            //public Nullable<int> natureinv { get; set; }
            //public Nullable<int> branchid { get; set; }
            //public Nullable<System.DateTime> invdate { get; set; }
            //public Nullable<int> custid { get; set; }
            public string sinvno { get; set; }
            //public string custname { get; set; }
            //public string branchname { get; set; }
            //public string fyear { get; set; }

          
        
    }
}