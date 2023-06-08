using Emax.SharedLib;
using System.Collections.Generic;
using System.Linq;

namespace VanSales.POS
{
    public class TokenResult
    {
        public static Dictionary<string, object> dict_logindata;
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string username { get; set; }
        public long expires_in { get; set; }
        public string userid { get; set; }
        public string branchid { get; set; }
        public string branchname { get; set; }
        public string fyear { get; set; }
        public string language { get; set; }
        public string compneyname { get; set; } 
        public string compvatno { get; set; }
        public string compact { get; set; }
        public string complogo { get; set; }
        public int ?vattype { get; set; }
        public decimal? vat { get; set; }
        public int? printno { get; set; }
        public bool? sprice { get; set; }
        public bool? wpitem { get; set; }
        public int? wpitemdigit { get; set; }
        public int? advancedpaymentchartid { get; set; }
        public int? advancedpaymentchartcode { get; set; }
        public string advancedpaymentchartname { get; set; }
        public static string GetLoginData(string keyname) {
            var res = TokenResult.dict_logindata.Where(i => i.Key == keyname).SingleOrDefault().Value;
            return EmaxGlobals.NullToEmpty( res);
        }
    }
}