using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VanSales.Models
{
    public class TokenResult
    {

        public string access_token { get; set; }
        public string token_type { get; set; }
        public string username { get; set; }
        public long expires_in { get; set; }
        public string userid { get; set; }
       // public string branchid { get; set; }


        public string fyear { get; set; }
        public string language { get; set; }
        public string compneyname { get; set; }
        public string compvatno { get; set; }
        public string compact { get; set; }
        public string complogo { get; set; }
        public int ?vattype { get; set; }
        public decimal? vat { get; set; }
        public int? printno { get; set; }
        public bool? autoitem { get; set; }
        public bool? autoemp { get; set; }
        public bool? sprice { get; set; }
        public bool? wpitem { get; set; }
        public int? wpitemdigit { get; set; }
        public decimal? udiscperitem { get; set; }
        public string error { get; set; }
    }
}