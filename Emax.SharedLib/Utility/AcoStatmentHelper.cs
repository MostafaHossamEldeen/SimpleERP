using Emax.Dal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emax.SharedLib.Utility
{
    public class AcoStatmentHelper
    {
        public static DataTable PrepareIncomeStatment(DataTable dt)
        {
            dt.Columns.Add("TotalOfTotal");
            var totalrevnue = EmaxGlobals.NullToZero(dt.AsEnumerable().Where(i => i.Field<int>("acctype") == 41).Sum(i => i.Field<decimal?>("Total")));
            var totalcost = EmaxGlobals.NullToZero(dt.AsEnumerable().Where(i => i.Field<int>("acctype") == 42).Sum(i => i.Field<decimal?>("Total")));
            var totalprofit = totalrevnue - totalcost;
            var lastrow = dt.AsEnumerable().LastOrDefault(i => i.Field<int>("acctype") == 42);
            DataRow rec = dt.NewRow();
            rec["acctype"] = 44;
            rec["chartname"] = "مجمل الربح";
            rec["TotalOfTotal"] = totalprofit;

            dt.Rows.InsertAt(rec, dt.Rows.IndexOf(lastrow) + 1);
            var totalotherrevnue = EmaxGlobals.NullToZero(dt.AsEnumerable().Where(i => i.Field<int>("acctype") == 43).Sum(i => i.Field<decimal?>("Total")));
            var lastrowotherrev = dt.AsEnumerable().LastOrDefault(i => i.Field<int>("acctype") == 43);
            rec = dt.NewRow();
            rec["acctype"] = 45;
            rec["chartname"] = " اجمالي ايرادات اخري ";
            rec["TotalOfTotal"] = totalotherrevnue;
            dt.Rows.InsertAt(rec, dt.Rows.IndexOf(lastrowotherrev) + 1);
            var totalotherexpensess = EmaxGlobals.NullToZero(dt.AsEnumerable().Where(i => i.Field<int>("acctype") != 43
            && i.Field<int>("acctype") != 42 && i.Field<int>("acctype") != 41).Sum(i => i.Field<decimal?>("Total")));
            rec = dt.NewRow();
            rec["acctype"] = 55;
            rec["chartname"] = " اجمالي المصروفات   ";
            rec["TotalOfTotal"] = totalotherexpensess;
            dt.Rows.InsertAt(rec, dt.Rows.Count);
            rec = dt.NewRow();
            rec["acctype"] = 56;
            rec["chartname"] = "   صافي الربح  / خسارة";
            var netproft = totalprofit + totalotherrevnue - totalotherexpensess < 0 ? "(" + (totalprofit + totalotherrevnue - totalotherexpensess).ToString() + ")" : (totalprofit + totalotherrevnue - totalotherexpensess).ToString();
            rec["TotalOfTotal"] = netproft;
            dt.Rows.InsertAt(rec, dt.Rows.Count);
            return dt;
        }


       public    static DataTable PrepareBalanceSheetStatment(DataTable dt,object dtefrom,object dteto,string lvlnum)
        {
            dt.Columns.Add("recnum", typeof(int));
            dt.Columns.Add("TotalOfTotal");
            var totalfixedasset = EmaxGlobals.NullToZero(dt.AsEnumerable().Where(i => i.Field<int>("acctype") == 11).Sum(i => i.Field<decimal?>("Total")));
            var totalAssets = EmaxGlobals.NullToZero(dt.AsEnumerable().Where(i => i.Field<int>("acctype") == 12).Sum(i => i.Field<decimal?>("Total")));
            var totalassetsandfixed = totalfixedasset + totalAssets;
            var longtermcommitments = EmaxGlobals.NullToZero(dt.AsEnumerable().Where(i => i.Field<int>("acctype") == 22).Sum(i => i.Field<decimal?>("Total")));
            var shorttermcommitments = EmaxGlobals.NullToZero(dt.AsEnumerable().Where(i => i.Field<int>("acctype") == 21).Sum(i => i.Field<decimal?>("Total")));

            var totalpropertyrights = EmaxGlobals.NullToZero(dt.AsEnumerable().Where(i => i.Field<int>("acctype") == 31).Sum(i => i.Field<decimal?>("Total")));
            var totalcommitments = longtermcommitments + shorttermcommitments + totalpropertyrights;

            var assetspos = dt.AsEnumerable().LastOrDefault(i => i.Field<int>("acctype") == 12);
            DataRow rec = dt.NewRow();
            rec["acctype"] = 120;
            rec["chartname"] = "اجمالي الاصول المتداوله";
            rec["TotalOfTotal"] = totalAssets;

            dt.Rows.InsertAt(rec, dt.Rows.IndexOf(assetspos) + 1);
            var fixedassetspos = dt.AsEnumerable().LastOrDefault(i => i.Field<int>("acctype") == 11);
            rec = dt.NewRow();
            rec["acctype"] = 110;
            rec["chartname"] = "اجمالي الاصول الثابته";
            rec["TotalOfTotal"] = totalfixedasset;

            dt.Rows.InsertAt(rec, dt.Rows.IndexOf(fixedassetspos) + 1);
            var longtermcommitmentspos = dt.AsEnumerable().LastOrDefault(i => i.Field<int>("acctype") == 22);
            rec = dt.NewRow();
            rec["acctype"] = 220;
            rec["chartname"] = "اجمالي الخصوم الغير متداوله";
            rec["TotalOfTotal"] = longtermcommitments;

            dt.Rows.InsertAt(rec, dt.Rows.IndexOf(longtermcommitmentspos) + 1);

            var shorttermcommitmentspos = dt.AsEnumerable().LastOrDefault(i => i.Field<int>("acctype") == 21);
            rec = dt.NewRow();
            rec["acctype"] = 210;
            rec["chartname"] = "اجمالي الخصوم متداوله";
            rec["TotalOfTotal"] = shorttermcommitments;

            dt.Rows.InsertAt(rec, dt.Rows.IndexOf(longtermcommitmentspos) + 1);

            var totalpropertyrightsspos = dt.AsEnumerable().LastOrDefault(i => i.Field<int>("acctype") == 31);
            rec = dt.NewRow();
            rec["acctype"] = 310;
            rec["chartname"] = "اجمالي حقوق الملكيه";
            rec["TotalOfTotal"] = totalpropertyrights;

            dt.Rows.InsertAt(rec, dt.Rows.IndexOf(totalpropertyrightsspos) + 1);
            //var lastassetpos = dt.AsEnumerable().LastOrDefault(i => i.Field<int>("acctype") == 202);
            /**************************/

            var lastassetspos = dt.AsEnumerable().LastOrDefault(i => i.Field<int>("acctype") == 120);
            rec = dt.NewRow();
            rec["acctype"] = 121;
            rec["chartname"] = "اجمالي الاصول ";
            rec["TotalOfTotal"] = totalassetsandfixed;

            dt.Rows.InsertAt(rec, dt.Rows.IndexOf(lastassetspos) + 1);
            /*******************************/
            /**************************/
            Dictionary<object, object> dict = new Dictionary<object, object>();
            dict.Add("dtefrom", dtefrom);
            dict.Add("dteto", dteto);
            dict.Add("levelno", lvlnum);
            //dict.Add("ccid", cmb_ccid.Value);
            DataTable dtincome = SqlCommandHelper.ExcecuteToDataTable("Income", dict).dataTable;

            Emax.SharedLib.Utility.AcoStatmentHelper.PrepareIncomeStatment(dtincome);
            //var lastrow = dt.AsEnumerable().LastOrDefault(i => i.Field<int>("recnum") == 6000);
            rec = dt.NewRow();
            rec["acctype"] = 0;
            rec["chartname"] = "ارباح مرحله ";
            rec["TotalOfTotal"] = dtincome.Rows[dtincome.Rows.Count - 1]["TotalOfTotal"];
            rec["recnum"] = 5800;
            dt.Rows.Add(rec);
            ////////////////
            var lastcommitmentspos = dt.AsEnumerable().LastOrDefault(i => i.Field<int>("acctype") == 210);
            rec = dt.NewRow();
            rec["acctype"] = 211;
            rec["chartname"] = "اجمالي الخصوم ";
            rec["TotalOfTotal"] = totalcommitments+EmaxGlobals.NullToZero(dtincome.Rows[dtincome.Rows.Count - 1]["TotalOfTotal"]);

            dt.Rows.InsertAt(rec, dt.Rows.IndexOf(lastassetspos) + 1);
            /*********************************************/
            int assetsnumber = 500;
            int fixedassetnumber = 100;
            int propertynum = 4000;
            int longcommitmentnum = 4500;
            int shorcommitmentnum = 5500;
            int lastassetindex = 3999;

            int lastcommitmentsindex = 6000;

        
            foreach (DataRow datarow in dt.Rows)
            {
                if (datarow["acctype"].ToString() == "121")
                {

                    datarow["recnum"] = lastassetindex;
                }
                if (datarow["acctype"].ToString() == "211")
                {

                    datarow["recnum"] = lastcommitmentsindex;
                }
                if (datarow["acctype"].ToString() == "12" || datarow["acctype"].ToString() == "120")
                {
                    assetsnumber++;
                    datarow["recnum"] = assetsnumber;
                }
                else if (datarow["acctype"].ToString() == "11" || datarow["acctype"].ToString() == "110")
                {
                    fixedassetnumber++;
                    datarow["recnum"] = fixedassetnumber;
                }
                else if (datarow["acctype"].ToString() == "22" || datarow["acctype"].ToString() == "220")
                {
                    longcommitmentnum++;
                    datarow["recnum"] = longcommitmentnum;
                }
                else if (datarow["acctype"].ToString() == "21" || datarow["acctype"].ToString() == "210")
                {
                    shorcommitmentnum++;
                    datarow["recnum"] = shorcommitmentnum;
                }
                else if (datarow["acctype"].ToString() == "31" || datarow["acctype"].ToString() == "310")
                {
                    propertynum++;
                    datarow["recnum"] = propertynum;
                }
            }





            //var totalotherrevnue = EmaxGlobals.NullToZero(dt.AsEnumerable().Where(i => i.Field<int>("acctype") == 43).Sum(i => i.Field<decimal?>("Total")));
            //var lastrowotherrev = dt.AsEnumerable().LastOrDefault(i => i.Field<int>("acctype") == 43);
            //rec = dt.NewRow();
            //rec["acctype"] = 45;
            //rec["chartname"] = " اجمالي ايرادات اخري ";
            //rec["TotalOfTotal"] = totalotherrevnue;
            //dt.Rows.InsertAt(rec, dt.Rows.IndexOf(lastrowotherrev) + 1);
            //var totalotherexpensess = EmaxGlobals.NullToZero(dt.AsEnumerable().Where(i => i.Field<int>("acctype") != 43
            //&& i.Field<int>("acctype") != 42 && i.Field<int>("acctype") != 41).Sum(i => i.Field<decimal?>("Total")));
            //rec = dt.NewRow();
            //rec["acctype"] = 55;
            //rec["chartname"] = " اجمالي المصروفات   ";
            //rec["TotalOfTotal"] = totalotherexpensess;
            //dt.Rows.InsertAt(rec, dt.Rows.Count);
            //rec = dt.NewRow();
            //rec["acctype"] = 56;
            //rec["chartname"] = "   صافي الربح  / خسارة";
            //var netproft = totalprofit + totalotherrevnue - totalotherexpensess < 0 ? "(" + (totalprofit + totalotherrevnue - totalotherexpensess).ToString() + ")" : (totalprofit + totalotherrevnue - totalotherexpensess).ToString();
            //rec["TotalOfTotal"] = netproft;
            //dt.Rows.InsertAt(rec, dt.Rows.Count);
            //dt.AsDataView().Sort = "recnum";
            return dt;
        }
    }
}
