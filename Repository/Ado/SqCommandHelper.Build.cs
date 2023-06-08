using Emax.CoreCore;
using Emax.Dal.Ado;
using Repository.Ado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Emax.Dal
{
    public partial class SqlCommandHelper
    {
        public static (bool, int, string) IsHasErrorMsg(SqlCommand sqlCommand)
        {
            if (sqlCommand.Parameters.Contains("@errorid") && EmaxGlobals.NullToIntZero(sqlCommand.Parameters["@errorid"].Value) != 0)
            {
                var exres = new ExceptionAnalyse(EmaxGlobals.NullToEmpty( sqlCommand.Parameters["@errormsg"].Value));
                return (true, EmaxGlobals.NullToIntZero(sqlCommand.Parameters.Contains("@errorid")), exres.storedExecuteResulte.errormsg);
            }
            else
            {
                return (false, 0, EmaxGlobals.NullToEmpty(sqlCommand.Parameters["@errormsg"].Value));
            }
        }
        //last
        public static void BuildParam<T>(SqlCommand cmd, List<T> values, bool fireerrormsg = false) where T : class
        {
            foreach (var item in values)
            {
                PropertyInfo[] propertiesinfo = item.GetType().GetProperties();
                foreach (var prop_name in propertiesinfo)
                {
                    if (cmd.Parameters.Contains("@"+prop_name.Name))
                    {
                        cmd.Parameters["@" + prop_name.Name].Value = prop_name.GetValue(item);
                    }
                  
                }

            }
            SetDefaultParam(cmd);
            //if (fireerrormsg)
            //{
            //    //SqlParameter sqlParameter = new SqlParameter("@error_id",SqlDbType.Int);
            //    SqlParameter sqlParametererrorid = new SqlParameter("@errorid", SqlDbType.Int);
            //    sqlParametererrorid.Direction = ParameterDirection.Output;
            //    SqlParameter sqlParametererrormsg = new SqlParameter("@errormsg", SqlDbType.NVarChar, 100);
            //    sqlParametererrormsg.Direction = ParameterDirection.Output;
            //    cmd.Parameters["@errorid"] = sqlParametererrorid;
            //    cmd.Parameters["@errormsg"] = sqlParametererrormsg;
            //}
            //if (cmd.Parameters.Contains("@userid"))
            //{

            //    if (HttpContext.Current.Request.Headers.GetValues("userid") != null)
            //    {
            //        var userid = HttpContext.Current.Request.Headers.GetValues("userid")[0];
            //        cmd.Parameters["@userid"].Value = userid;


            //    }
            //    else
            //    {

            //        cmd.Parameters["@userid"].Value = GetTokenKey("userid",
            //        HttpContext.Current.Request.Cookies["Token"].Value);
            //    }
            //}
            //if (cmd.Parameters.Contains("@username"))
            //{

            //    if (HttpContext.Current.Request.Headers.GetValues("username") != null)
            //    {
            //        var username = HttpContext.Current.Request.Headers.GetValues("username")[0];
            //        cmd.Parameters["@username"].Value = username;


            //    }
            //    else
            //    {

            //        cmd.Parameters["@username"].Value = GetTokenKey("username",
            //        HttpContext.Current.Request.Cookies["Token"].Value);
            //    }
            //}

            //if (cmd.Parameters.Contains("@fyear"))
            //{

            //    if (HttpContext.Current.Request.Headers.GetValues("fyear") != null)
            //    {
            //        var userid = HttpContext.Current.Request.Headers.GetValues("fyear")[0];
            //        cmd.Parameters["@fyear"].Value = userid;


            //    }
            //    else
            //    {
            //        //cmd.Parameters["@fyear"].Value = "2021";
            //        cmd.Parameters["@fyear"].Value = GetTokenKey("fyear",
            //        HttpContext.Current.Request.Cookies["Token"].Value);
            //    }
            //}




        }

        public static void BuildParam(SqlCommand cmd,IDictionary<object, object> values,bool fireerrormsg=false)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            if (values != null)
            {
                foreach (KeyValuePair<object, object> item in values)
                {
                    string paramname = "@" + EmaxGlobals.NullToEmpty(item.Key);
                    var paramtype = cmd.Parameters[paramname].SqlDbType;
                    var paramsize = cmd.Parameters[paramname].Size;
                    var sqlparams = new SqlParameter(paramname, paramtype,paramsize);
                    if (EmaxGlobals.NullToEmpty( item.Value).Length == 0)
                    {
                        sqlparams.Value = DBNull.Value;
                        
                      
                    }
                    else
                    {
                        sqlparams.Value = item.Value;
                   
                    }
                    cmd.Parameters[paramname] = sqlparams;

                }
            }
            SetDefaultParam(cmd);
            //if (fireerrormsg)
            //{
            //    //SqlParameter sqlParameter = new SqlParameter("@error_id",SqlDbType.Int);
            //    SqlParameter sqlParametererrorid = new SqlParameter("@errorid", SqlDbType.Int);
            //    sqlParametererrorid.Direction = ParameterDirection.Output;
            //    SqlParameter sqlParametererrormsg = new SqlParameter("@errormsg", SqlDbType.NVarChar, 100);
            //    sqlParametererrormsg.Direction = ParameterDirection.Output;
            //    cmd.Parameters["@errorid"] = sqlParametererrorid;
            //    cmd.Parameters["@errormsg"] = sqlParametererrormsg;
            //}
            //if (cmd.Parameters.Contains("@userid"))
            //{
               
            //     if (HttpContext.Current.Request.Headers.GetValues("userid") != null) 
            //    {
            //        var userid = HttpContext.Current.Request.Headers.GetValues("userid")[0];
            //        cmd.Parameters["@userid"].Value = userid;


            //    }
            //    else
            //    {
                    
            //        cmd.Parameters["@userid"].Value = GetTokenKey("userid",
            //        HttpContext.Current.Request.Cookies["Token"].Value);
            //    }
            //}
            //if (cmd.Parameters.Contains("@username"))
            //{

            //    if (HttpContext.Current.Request.Headers.GetValues("username") != null)
            //    {
            //        var username = HttpContext.Current.Request.Headers.GetValues("username")[0];
            //        cmd.Parameters["@username"].Value = username;


            //    }
            //    else
            //    {

            //        cmd.Parameters["@username"].Value = GetTokenKey("username",
            //        HttpContext.Current.Request.Cookies["Token"].Value);
            //    }
            //}
            //if (cmd.Parameters.Contains("@fyear"))
            //{

            //    if (HttpContext.Current.Request.Headers.GetValues("fyear") != null)
            //    {
            //        var userid = HttpContext.Current.Request.Headers.GetValues("fyear")[0];
            //        cmd.Parameters["@fyear"].Value = userid;


            //    }
            //    else
            //    {

            //        cmd.Parameters["@fyear"].Value = GetTokenKey("fyear",
            //        HttpContext.Current.Request.Cookies["Token"].Value);
            //    }
            //}




        }

        public static string GetTokenKey(string key, string cookies)
        {
            var cockiesarray = cookies.Split('&');
            string keyvalue = string.Empty;
            foreach (var item in cockiesarray)
            {
                var cockiesarraykeywithvalue = item.Split('=');
                for (int i = 0; i < cockiesarraykeywithvalue.Length; i++)
                {
                    if (cockiesarraykeywithvalue[i].ToString().ToLower() == key.ToLower())
                    {
                        keyvalue = cockiesarraykeywithvalue[1];
                        break;
                    }
                }

            }
            return keyvalue;
        }
        //public static SqlParameter[] BuildParam(SqlCommand cmd,IDictionary<object, object> values, bool fireerrormsg = false)
        //{
        //    List<SqlParameter> sqlParameters = new List<SqlParameter>();
        //    if (values != null)
        //    {
        //        foreach (KeyValuePair<object, object> item in values)
        //        {
        //            string paramname = "@" + EmaxGlobals.NullToEmpty(item.Key);

        //            if (cmd.Parameters.Contains(paramname))
        //            {
        //                if (EmaxGlobals.NullToEmpty(item.Value).Length == 0)
        //                {
        //                    cmd.Parameters[paramname].Value= DBNull.Value;


        //                }
        //                else
        //                {
        //                    cmd.Parameters[paramname].Value= item.Value;


        //                }
        //            }
                 
                   

        //        }
        //    }
        //    SetDefaultParam(cmd);
        //    return sqlParameters.ToArray();
        //}

        public static SqlParameter[] BuildParam(SqlCommand cmd,DataView values, bool fireerrormsg = false)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            if (values != null)
            {
                foreach (DataRow item in values)
                {
                    string paramname = "@" + EmaxGlobals.NullToEmpty(item["paramname"]);
                    var paramtype = cmd.Parameters[paramname].SqlDbType;
                    var paramsize = cmd.Parameters[paramname].Size;
                    var sqlparams = new SqlParameter(paramname, paramtype);
                    if (EmaxGlobals.NullToEmpty( item["paramvalue"]).Length == 0)
                    {
                        sqlparams.Value = DBNull.Value;
                        sqlParameters.Add(sqlparams);
                    }
                    else
                    {
                        sqlparams.Value = item["paramvalue"];
                        sqlParameters.Add(sqlparams);
                    }


                }
            }
            if (fireerrormsg)
            {
                //SqlParameter sqlParameter = new SqlParameter("@error_id",SqlDbType.Int);
                SqlParameter sqlParametererrorid = new SqlParameter("@errorid", SqlDbType.Int);
                sqlParametererrorid.Direction = ParameterDirection.Output;
                SqlParameter sqlParametererrormsg = new SqlParameter("@errormsg", SqlDbType.NVarChar, 300);
                sqlParametererrormsg.Direction = ParameterDirection.Output;
                sqlParameters.AddRange(new[] { sqlParametererrorid, sqlParametererrormsg });
            }

            return sqlParameters.ToArray();
        }
        public static SqlParameter[] BuildParam(string paramname, object paramvalue, bool fireerrormsg = false)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();


            string _paramname = "@" + EmaxGlobals.NullToEmpty(paramname);
            if (EmaxGlobals.NullToEmpty(paramvalue)!="")
            {

            
            if (paramvalue == null)
            {
                sqlParameters.Add(new SqlParameter(paramname, DBNull.Value));
            }
            else
            {
                sqlParameters.Add(new SqlParameter(paramname, paramvalue));
            }

            }

            if (fireerrormsg)
            {
                //SqlParameter sqlParameter = new SqlParameter("@error_id",SqlDbType.Int);
                SqlParameter sqlParametererrorid = new SqlParameter("@errorid", SqlDbType.Int);
                sqlParametererrorid.Direction = ParameterDirection.Output;
                SqlParameter sqlParametererrormsg = new SqlParameter("@errormsg", SqlDbType.NVarChar, 300);
                sqlParametererrormsg.Direction = ParameterDirection.Output;
                sqlParameters.AddRange(new[] { sqlParametererrorid, sqlParametererrormsg });
            }
          
            return sqlParameters.ToArray();
        }
        public static SqlParameter[] BuildParam(List<object> values,
            bool fireerrormsg = false, List<ParamObject> ctltextval = null, bool defaultparam=false)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            if (values != null)
            {
                foreach (object item in values)
                {

                    string ctlid = GetDxObjectId(item);
                    string paramval = GetDxObjectValue(item);
                    string[] paramnamear = ctlid.Split('_');
                    string paramname = "@" + paramnamear[1];
                    if (EmaxGlobals.NullToEmpty(paramval).Length == 0)
                    {
                        sqlParameters.Add(new SqlParameter(paramname, DBNull.Value));
                    }
                    else
                    {
                        sqlParameters.Add(new SqlParameter(paramname, paramval));
                    }


                }
            }
            if (ctltextval != null)
            {
                foreach (ParamObject item in ctltextval)
                {

                    string ctlid = item.ParamName;
                    string paramval = GetDxObjectText(item.ParamValue);
                  
                    string paramname = "@" + ctlid;
                    if (EmaxGlobals.NullToEmpty(paramval).Length == 0)
                    {
                        sqlParameters.Add(new SqlParameter(paramname, DBNull.Value));
                    }
                    else
                    {
                        sqlParameters.Add(new SqlParameter(paramname, paramval));
                    }


                }
            }
            if (fireerrormsg)
            {
                //SqlParameter sqlParameter = new SqlParameter("@error_id",SqlDbType.Int);
                SqlParameter sqlParametererrorid = new SqlParameter("@errorid", SqlDbType.Int);
                sqlParametererrorid.Direction = ParameterDirection.Output;
                SqlParameter sqlParametererrormsg = new SqlParameter("@errormsg", SqlDbType.NVarChar, 300);
                sqlParametererrormsg.Direction = ParameterDirection.Output;
                sqlParameters.AddRange(new[] { sqlParametererrorid, sqlParametererrormsg });
            }

            if (defaultparam)
            {
                //SqlParameter sqlParameter = new SqlParameter("@error_id",SqlDbType.Int);
                SqlParameter sqlParameterbranchid = new SqlParameter("@branchid", SqlDbType.Int);
                sqlParameterbranchid.Value = 11;
                SqlParameter sqlParametfiscalyear = new SqlParameter("@fyear ", SqlDbType.NVarChar, 10);
                sqlParametfiscalyear.Value ="2021";
                sqlParameters.AddRange(new[] { sqlParameterbranchid, sqlParametfiscalyear });
            }

            return sqlParameters.ToArray();
        }
        //edit fyear ----
        public static void BuildParam(SqlCommand cmd, List<object> values,
    bool fireerrormsg = false, List<ParamObject> ctltextval = null, bool defaultparam = false, List<string> outputparam=null)
        {
    
            //List<SqlParameter> sqlParameters = new List<SqlParameter>();
            if (values != null)
            {
                foreach (object item in values)
                {
                   
                    string ctlid = GetDxObjectId(item);
                    string paramval = GetDxObjectValue(item);
                    string[] paramnamear = ctlid.Split('_');
                    string paramname = "@" + paramnamear[1];
                    if (cmd.Parameters.Contains(paramname))
                    {
                        var paramtype = cmd.Parameters[paramname].SqlDbType;
                        var paramsize = cmd.Parameters[paramname].Size;
                        var sqlparams = new SqlParameter(paramname, paramtype, paramsize);
                        if (EmaxGlobals.NullToEmpty(paramval).Length == 0)
                        {
                            sqlparams.Value = DBNull.Value;


                        }
                        else
                        {
                            sqlparams.Value = paramval;



                        }
                        cmd.Parameters[paramname] = sqlparams;
                    }
                    

                }
            }
            if (ctltextval != null)
            {
                foreach (ParamObject item in ctltextval)
                {

                    string ctlid = item.ParamName;
                    string paramval = GetDxObjectText(item.ParamValue);

                    string paramname = "@" + ctlid;
                    if (cmd.Parameters.Contains(paramname))
                    {
                        var paramtype = cmd.Parameters[paramname].SqlDbType;
                        var paramsize = cmd.Parameters[paramname].Size;
                        var sqlparams = new SqlParameter(paramname, paramtype, paramsize);
                        if (EmaxGlobals.NullToEmpty(paramval).Length == 0)
                        {
                            sqlparams.Value = DBNull.Value;
                            //sqlParameters.Add(new SqlParameter(paramname, DBNull.Value));
                        }
                        else
                        {
                            sqlparams.Value = paramval;
                            //sqlParameters.Add(new SqlParameter(paramname, paramval));
                        }
                        cmd.Parameters[paramname] = sqlparams;
                    }

                }
            }
            if (fireerrormsg)
            {
                //SqlParameter sqlParameter = new SqlParameter("@error_id",SqlDbType.Int);
                SqlParameter sqlParametererrorid = new SqlParameter("@errorid", SqlDbType.Int);
                sqlParametererrorid.Direction = ParameterDirection.Output;
                SqlParameter sqlParametererrormsg = new SqlParameter("@errormsg", SqlDbType.NVarChar, 100);
                sqlParametererrormsg.Direction = ParameterDirection.Output;
                cmd.Parameters["@errorid"] = sqlParametererrorid;
                cmd.Parameters["@errormsg"] = sqlParametererrormsg;
            }
            SetDefaultParam(cmd);
            //if (defaultparam)
            //{
            //    var paramtype = cmd.Parameters["@fyear"].SqlDbType;
            //    var paramsize = cmd.Parameters["@fyear"].Size;
            //    var sqlparams = new SqlParameter("@fyear", paramtype,paramsize);

            //    sqlparams.Value =  "2021";
            //    cmd.Parameters["@fyear"] = sqlparams;
            //}
            if (outputparam!=null)
            {
                foreach (string item in outputparam)
                {
                    if (EmaxGlobals.NullToZero(cmd.Parameters["@" + item].Value)==0)
                    {
                        var paramtype = cmd.Parameters["@" + item].SqlDbType;
                        var paramsize = cmd.Parameters["@" + item].Size;
                        var sqlparams = new SqlParameter("@" + item, paramtype, paramsize);
                        sqlparams.Direction = ParameterDirection.Output;
                        cmd.Parameters["@" + item] = sqlparams;
                    }
             
                }
                
            }
            //return sqlParameters.ToArray();
        }
       public static string GetDxObjectId(object ctl)
        {
            string h = string.Empty;
       
            PropertyInfo ctlobj = ctl.GetType().GetProperty("ID");
            return EmaxGlobals.NullToEmpty(ctlobj.GetValue(ctl));
        }
        public static string GetDxObjectValue(object ctl)
        {
            PropertyInfo ctlobj = ctl.GetType().GetProperty("Value");
            return EmaxGlobals.NullToEmpty(ctlobj.GetValue(ctl));
        }

        static string GetDxObjectText(object ctl)
        {
            PropertyInfo ctlobj = ctl.GetType().GetProperty("Text");
            return EmaxGlobals.NullToEmpty(ctlobj.GetValue(ctl));
        }
        static void SetDefaultParam(SqlCommand cmd)
        {

         if (cmd.Parameters.Contains("@errorid"))
            {
                //SqlParameter sqlParameter = new SqlParameter("@error_id",SqlDbType.Int);
                SqlParameter sqlParametererrorid = new SqlParameter("@errorid", SqlDbType.Int);
                sqlParametererrorid.Direction = ParameterDirection.Output;
        
                cmd.Parameters["@errorid"] = sqlParametererrorid;
     
            }

            if (cmd.Parameters.Contains("@errormsg"))
            {
                //SqlParameter sqlParameter = new SqlParameter("@error_id",SqlDbType.Int);
             
                SqlParameter sqlParametererrormsg = new SqlParameter("@errormsg", SqlDbType.NVarChar, 100);
                sqlParametererrormsg.Direction = ParameterDirection.Output;
           
                cmd.Parameters["@errormsg"] = sqlParametererrormsg;
            }
            if (cmd.Parameters.Contains("@userid"))
            {
                if (HttpContext.Current != null)
                {
                    if (cmd.Parameters["@userid"].Value == null)
                    {
                        if (HttpContext.Current.Request.Headers.GetValues("userid") != null)
                        {
                            var userid = HttpContext.Current.Request.Headers.GetValues("userid")[0];
                            cmd.Parameters["@userid"].Value = userid;
                        }
                        else
                        {
                            cmd.Parameters["@userid"].Value = GetTokenKey("userid",
                            HttpContext.Current.Request.Cookies["Token"].Value);
                        }
                    }
                }
            }
            if (cmd.Parameters.Contains("@username"))
            {
                
                if (HttpContext.Current != null)
                {

                    if (HttpContext.Current.Request.Headers.GetValues("username") != null)
                    {
                        var username = HttpContext.Current.Request.Headers.GetValues("username")[0];
                        cmd.Parameters["@username"].Value = username;


                    }
                    else
                    {

                        cmd.Parameters["@username"].Value = GetTokenKey("username",
                        HttpContext.Current.Request.Cookies["Token"].Value);
                    }
                }
            }

            if (cmd.Parameters.Contains("@fyear"))
            {
                if (HttpContext.Current != null)
                {

                    if (HttpContext.Current.Request.Headers.GetValues("fyear") != null)
                    {
                        var fyear = HttpContext.Current.Request.Headers.GetValues("fyear")[0];
                        cmd.Parameters["@fyear"].Value = fyear;


                    }
                    else
                    {

                        cmd.Parameters["@fyear"].Value = GetTokenKey("fyear",
                        HttpContext.Current.Request.Cookies["Token"].Value);
                    }
                }
            }
        }
        public static SqlParameter[] BuildParam(SqlCommand cmd,OrderedDictionary values, bool fireerrormsg = false)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            if (values != null)
            {
                IDictionaryEnumerator enumerator = values.GetEnumerator();
                enumerator.Reset();
                while (enumerator.MoveNext())
                {
                    
                    string paramname = "@" + EmaxGlobals.NullToEmpty(enumerator.Key.ToString());
                    if (cmd.Parameters.Contains(paramname))
                    {
                        cmd.Parameters[paramname].Value = (enumerator.Value == null ? DBNull.Value : enumerator.Value);
                    }
                    //sqlParameters.Add(new SqlParameter(paramname, enumerator.Value == null ? DBNull.Value : enumerator.Value));
                }

            }
            //if (fireerrormsg)
            //{
            //    //SqlParameter sqlParameter = new SqlParameter("@error_id",SqlDbType.Int);
            //    if (cmd.Parameters.Contains("@errorid")
            //    {

            //    }
            //    SqlParameter sqlParametererrorid = new SqlParameter("@errorid", SqlDbType.Int);
            //    sqlParametererrorid.Direction = ParameterDirection.Output;
            //    SqlParameter sqlParametererrormsg = new SqlParameter("@errormsg", SqlDbType.NVarChar, 100);
            //    sqlParametererrormsg.Direction = ParameterDirection.Output;
            //    sqlParameters.AddRange(new[] { sqlParametererrorid, sqlParametererrormsg });
            //}

            if (fireerrormsg)
            {
                //SqlParameter sqlParameter = new SqlParameter("@error_id",SqlDbType.Int);
                SqlParameter sqlParametererrorid = new SqlParameter("@errorid", SqlDbType.Int);
                sqlParametererrorid.Direction = ParameterDirection.Output;
                SqlParameter sqlParametererrormsg = new SqlParameter("@errormsg", SqlDbType.NVarChar, 100);
                sqlParametererrormsg.Direction = ParameterDirection.Output;
                cmd.Parameters["@errorid"] = sqlParametererrorid;
                cmd.Parameters["@errormsg"] = sqlParametererrormsg;
            }
            if (cmd.Parameters.Contains("@userid"))
            {

                if (HttpContext.Current.Request.Headers.GetValues("userid") != null)
                {
                    var userid = HttpContext.Current.Request.Headers.GetValues("userid")[0];
                    cmd.Parameters["@userid"].Value = userid;


                }
                else
                {

                    cmd.Parameters["@userid"].Value = GetTokenKey("userid",
                    HttpContext.Current.Request.Cookies["Token"].Value);
                }
            }
            if (cmd.Parameters.Contains("@username"))
            {

                if (HttpContext.Current.Request.Headers.GetValues("username") != null)
                {
                    var username = HttpContext.Current.Request.Headers.GetValues("username")[0];
                    cmd.Parameters["@username"].Value = username;


                }
                else
                {

                    cmd.Parameters["@username"].Value = GetTokenKey("username",
                    HttpContext.Current.Request.Cookies["Token"].Value);
                }
            }

            if (cmd.Parameters.Contains("@fyear"))
            {

                if (HttpContext.Current.Request.Headers.GetValues("fyear") != null)
                {
                    var userid = HttpContext.Current.Request.Headers.GetValues("fyear")[0];
                    cmd.Parameters["@fyear"].Value = userid;


                }
                else
                {

                    cmd.Parameters["@fyear"].Value = GetTokenKey("fyear",
                    HttpContext.Current.Request.Cookies["Token"].Value);
                }
            }

            return sqlParameters.ToArray();
        }
    }
}
