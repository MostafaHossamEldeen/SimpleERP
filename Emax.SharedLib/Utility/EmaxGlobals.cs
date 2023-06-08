
using Emax.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Emax.SharedLib
{
    public class DateFormatTax
    {
        public string year;
        public string month;
        public string day;
        public string timearray;
        public string hour;
        public string minuts;
    }
    public class EmaxGlobals
    {
        public static ArrayList SecurityFields = new ArrayList();
        public static ArrayList SecurityTables = new ArrayList();


        public static ArrayList SecurityFieldsDB = new ArrayList();
        public static ArrayList SecurityTablesDB = new ArrayList();
        public enum Fraction_Type { Fraction, Fraction_Curr, Fraction_Qty, None }
       public static string GetQrCodeDateData(string comenyname ,string taxnum ,string dateTime,string timeSpan,
           double netval,double vatval)
        {
           
            TlvFormat t = new TlvFormat(comenyname,taxnum, DateToTaxDate(dateTime,timeSpan) , netval ,vatval);
            return t.ToBase64();
        }
        
        public static string DateToTaxDate(string date, string time)
        {
            string dte = null;
            var res = new DateFormatTax();
            if (date!=null)
            {
                var dtee = Convert.ToDateTime(date);
                string[] datearray = null;
                if (date.Contains("-"))
                {
                     datearray = date.Split('-');
                }
                else
                {
                  datearray = date.Split('/');
                }

                res.year = dtee.Year.ToString();// datearray[2].Split(' ')[0];//.Year.ToString() ;
                res.month = dtee.Month.ToString();// datearray[1];//.Month.ToString();
                res.day = dtee.Day.ToString();// datearray[0];//.Day.ToString();
           var timearray = time.Split(':');
                res.hour = timearray[0];//.ToString();
                res.minuts = timearray[1];//.Minutes.ToString();

             dte= new DateTime(Convert.ToInt32(res.year), Convert.ToInt32(res.month), Convert.ToInt32(res.day),
                  Convert.ToInt32(res.hour), Convert.ToInt32(res.minuts), 0, 0).ToString("yyyy-MM-ddTHH:mmssZ");
            }
            return dte;
        }
    


    public static decimal NullToZero(object Value)
        {


            decimal res = 0;
            if (NullToEmpty(Value) == "")
                res = 0;
            else
                try
                {
                    if (Value.ToString().Contains("(")){
                        Value =Value.ToString().Replace("(","");
                    }
                    if (Value.ToString().Contains(")"))
                    {
                        Value = Value.ToString().Replace(")", "");
                    }
                    {

                    }
                    res = Convert.ToDecimal(Value);
                }
                catch (Exception ex)
                {
                    res = 0;
                }
            if (res.ToString() == "ليس برقم" || res.ToString() == "NAN")
                res = 0;

            return res;
        }

        public static double NullToZeroDouble(object Value)
        {


            double res = 0;
            if (NullToEmpty(Value) == "")
                res = 0;
            else
                try
                {
                    res = Convert.ToDouble(Value);
                }
                catch (Exception ex)
                {
                    res = 0;
                }
            if (res.ToString() == "ليس برقم" || res.ToString() == "NAN")
                res = 0;

            return res;
        }

        public static bool ValidateNullValue(List<object> Value)
        {
            bool res = true;
            foreach (var item in Value)
            {
              
                if (NullToEmpty(Value) == "")
                    res = false;
                else
                    try
                    {
                        res = true;
                    }
                    catch (Exception ex)
                    {
                        res = false;
                    }
               
            }
           

            return res;
        }

        public static bool ValidateZeroValue(List<object> Value)
        {
            bool res = true;
            foreach (var item in Value)
            {

                if (NullToEmpty(Value) == "0")
                    res = false;
                else
                    try
                    {
                        res = true;
                    }
                    catch (Exception ex)
                    {
                        res = false;
                    }

            }


            return res;
        }
        //public static void SetSubReportsParameters(ReportDocument RepC, Dictionary<string, object> parVals)
        //{
        //    if (RepC.Subreports.Count > 0)
        //    {
        //        foreach (CrystalDecisions.CrystalReports.Engine.ReportDocument SupRep in RepC.Subreports)
        //        {
        //            foreach (string key in parVals.Keys)
        //            {
        //                try
        //                {
        //                    RepC.SetParameterValue(key, parVals[key], SupRep.Name);
        //                }
        //                catch (Exception ex)
        //                {
        //                    //if (!ex.Message.Contains("Index was outside the bounds of the array"))
        //                     //   MessageBox.Show(ex.Message);
        //                }
        //            }

        //            ////if (RepC.ParameterFields["ShowColores"] != null)
        //            ////{
        //            //    try
        //            //    {
        //            //        RepC.SetParameterValue("ShowColores", ShowColors, SupRep.Name);
        //            //    }
        //            //    catch (Exception ex)
        //            //    {
        //            //        if (!ex.Message.Contains("Index was outside the bounds of the array"))
        //            //            MessageBox.Show(ex.Message);
        //            //    }
        //            ////}

        //            ////if (RepC.ParameterFields["Multi"] != null)
        //            ////{
        //            //    try
        //            //    {
        //            //        RepC.SetParameterValue("Multi", Multi, SupRep.Name);
        //            //    }
        //            //    catch (Exception ex)
        //            //    {
        //            //        if (!ex.Message.Contains("Index was outside the bounds of the array"))
        //            //            MessageBox.Show(ex.Message);
        //            //    }
        //            ////}

        //            ////if (RepC.ParameterFields["Multi_m"] != null)
        //            ////{
        //            //    try
        //            //    {
        //            //        RepC.SetParameterValue("Multi_m", Multi_m, SupRep.Name);
        //            //    }
        //            //    catch (Exception ex)
        //            //    {
        //            //        if (!ex.Message.Contains("Index was outside the bounds of the array"))
        //            //            MessageBox.Show(ex.Message);
        //            //    }
        //            ////}
        //            ////if (RepC.ParameterFields["SecondName"] != null)
        //            ////{
        //            //    try
        //            //    {
        //            //        RepC.SetParameterValue("SecondName", UseNameSubRefinedItems, SupRep.Name);
        //            //    }
        //            //    catch (Exception ex)
        //            //    {
        //            //        if (!ex.Message.Contains("Index was outside the bounds of the array"))
        //            //            MessageBox.Show(ex.Message);
        //            //    }
        //            ////}
        //        }
        //    }
        //}

        //public static void SetSubReportParameter(ReportClass RepC, string SupRep, string Param, object Val)
        //{
        //    if (RepC.Subreports.Count > 0)
        //    {
        //        if (RepC.Subreports[SupRep] != null)
        //        {
        //            try
        //            {
        //                RepC.SetParameterValue(Param, Val, SupRep);
        //            }
        //            catch (Exception ex)
        //            {
        //                //if (!ex.Message.Contains("Index was outside the bounds of the array")) 
        //                   // MessageBox.Show(ex.Message);
        //            }
        //        }
        //    }
        //}
        public static int NullToIntZero(object Value)
        {
            int res = 0;
            if (NullToEmpty(Value) == "")
                res = 0;
            else
                try
                {
                    res = Convert.ToInt32(Value);
                }
                catch (Exception ex)
                {
                    res = 0;
                }
            if (res.ToString() == "ليس برقم" || res.ToString() == "NAN")
                res = 0;

            return res;
        }
        public static int? NullToNullInt(object Value)
        {
            int ?res = null;
            if (NullToEmpty(Value) == "")
                res = null;
            else
                try
                {
                    res = Convert.ToInt32(Value);
                }
                catch (Exception ex)
                {
                    res = null;
                }
            if (res.ToString() == "ليس برقم" || res.ToString() == "NAN")
                res = null;

            return res;
        }
        //public static decimal NullToZero(object Value)
        //{
        //    decimal res = 0;
        //    if (NullToEmpty(Value) == "")
        //        res = 0;
        //    else
        //        try
        //        {
        //            res = Convert.ToDecimal(Value);
        //        }
        //        catch (Exception ex)
        //        {
        //            res = 0;
        //        }
        //    if (res.ToString() == "ليس برقم" || res.ToString() == "NAN")
        //        res = 0;

        //    return res;
        //}


        public static string NullToEmpty(object Value)
        {
            if (Value == null || Value == DBNull.Value)
                return "";
            else
                return Value.ToString();
        }

        public static string NullToNullString(object Value)
        {
            if (Value == null || Value == DBNull.Value)
            {
                return " IS NULL";
            }
            else if (Value.ToString().Trim() == "")
            {
                return " IS NULL";
            }
            else
            {
                return " = " + Value.ToString();
            }
        }
        public static object NullToNullDbnull(object Value)
        {
            if (Value == null || Value == DBNull.Value)
            {
                return DBNull.Value;
            }
            else if (Value.ToString().Trim() == "")
            {
                return DBNull.Value;
            }
            else
            {
                return Value.ToString();
            }
        }

        public static bool NullToBool(object Value)
        {
            if (Value == null || Value == DBNull.Value || Value.ToString() == "0")
                return false;
            else
            {
                if (Value.GetType().Name == "Boolean")
                    return Convert.ToBoolean(Value);
                else if (Value.GetType().Name == "String")
                    return (Value.ToString().ToLower() == "true");
                else
                    return false;
            }
        }
        public static DataTable ToTable(string CommandText,string constr)
        {
            if (CommandText.ToLower().Contains("false"))
                CommandText = CommandText.ToLower().Replace("false", "0");
            if (CommandText.ToLower().Contains("true"))
                CommandText = CommandText.ToLower().Replace("true", "1");
            SqlConnection Connection = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter(CommandText, Connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
      

        //internal static bool IsCodeTable(string TableName) 
        //{
        //    TableName = TableName.Replace("'", "");

        //    db_AutoAccountDbContext db = new db_AutoAccountDbContext();

        //    db.Database.CommandTimeout = 1000;
        //    BaseRepository<TableName_ID_View> tb = new BaseRepository<TableName_ID_View>(db);
        //    //using (db_AutoAccountEntities db = new db_AutoAccountEntities())
        //    //{
        //    //Repository.BaseRepository<T> baseRepository = new Repository.BaseRepository<T>(MSLinks.db);
        //    object oTableCode = tb.GetWithRawSql("select * from TableName_ID_View where TableName='" + TableName + "'").AsQueryable().FirstOrDefault();
        //    // object oTableCode = MSGlobal.ExecuteScalar("select TableName from TableName_ID_View where TableName='" + TableName.Replace("'", "") + "'");

        //    // object oTableCode = dbmecEntities.TableName_ID_View.Where(i => i.TableName == TableName).SingleOrDefault();
        //    if (oTableCode != null && oTableCode != DBNull.Value)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }

        //    //}

        //}

        //internal static bool IsFieldExists(string FieldName)


        //{

        //    var isfieldintable = Utl.GetEntityByname(MSLinks.tablename).GetProperties().Where(i => i.Name.ToLower() == FieldName.ToLower()).SingleOrDefault(); ;

        //    //for (int i = 0; i < dataColumns.Length; i++)
        //    //{
        //    //    if (dataColumns[i].ColumnName.ToLower() == FieldName.ToLower())
        //    //    {
        //    //        return true;
        //    //    }
        //    //}
        //    return (isfieldintable != null);
        //}

  
        internal static bool IsFieldExists(DataColumnCollection dataColumnsCollection, string FieldName)
        {
            //    foreach (DataColumn dataColumns in dataColumnsCollection)
            //    {
            for (int i = 0; i < dataColumnsCollection.Count; i++)
            {
                if (dataColumnsCollection[i].ColumnName.ToLower() == FieldName.ToLower())
                {
                    return true;
                }
            }
            //}
            return false;
        }

        //internal static bool NonSecuirty(string TableName, string FieldName)
        //{
        //    //return false;
        //    if (FieldName == null)
        //        return false;
        //    //using (db_AutoAccountEntities db = new db_AutoAccountEntities())
        //    //{
        //    db_AutoAccountDbContext db = new db_AutoAccountDbContext();

        //    db.Database.CommandTimeout = 1000;
        //    BaseRepository<C__SU_Non> tb = new BaseRepository<C__SU_Non>(db);
        //    object oNonSecuirty = tb.GetWithRawSql("select top 1 * from _@SU_Non where TableName='" + TableName.Replace("'", "") + "' and FieldName='" + FieldName + "'").SingleOrDefault();

        //    if (oNonSecuirty != null && oNonSecuirty != DBNull.Value)
        //        return true;
        //    else return false;
        //    //}
        //}

        //internal static bool NonSecuirtyDB(string TableName, string FieldName)
        //{
        //    if (FieldName == null)
        //        return false;
        //    using (db_AutoAccountDbContext db = new db_AutoAccountDbContext())
        //    {
        //        object oNonSecuirtyDB = db.C__SU_NonDB.SingleOrDefault(i => i.TableName == TableName.Replace("'", "") && i.FieldName == FieldName);

        //        if (oNonSecuirtyDB != null && oNonSecuirtyDB != DBNull.Value)
        //            return true;
        //        else return false;
        //    }
        //}


    }
}
