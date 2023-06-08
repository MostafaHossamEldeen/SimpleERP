using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Emax.Vansales.Service.Models
{
    public class st_transactions_Post
    {

        public int? posttype { get; set; }
public int branchid { get; set; }
public bool? post { get; set; }
public string username { get; set; }
public int transid { get; set; }
public int chartidfrom { get; set; }
public int chartidto { get; set; }

    }

    public class s_inv_Post
    {

        public int? posttype { get; set; }
         
        public bool? post { get; set; }
        public string username { get; set; }
        public int sinvid { get; set; }
    }
    public class rec_Post
    {
        public int chartidfrom { get; set; }
        public int chartidto { get; set; }
        public int branchid { get; set; }
        public bool? post { get; set; }
        public string username { get; set; }
        public int recid { get; set; }
    }
    public class pay_Post
    {
        public int chartidfrom { get; set; }
        public int chartidto { get; set; }
        public int branchid { get; set; }
        public bool? post { get; set; }
        public string username { get; set; }
        public int pdid { get; set; }
    }
}