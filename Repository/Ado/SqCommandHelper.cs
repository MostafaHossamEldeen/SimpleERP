using Emax.Core.ADO;
using Emax.CoreCore;
using Emax.Dal.Ado;
using Repository.Ado;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;

namespace Emax.Dal
{
    public partial class SqlCommandHelper
    {
         static string connectionstr = ConfigurationManager.ConnectionStrings["VanSales"].ConnectionString;
         

     //  static const string connectionstr = ConfigurationManager.ConnectionStrings["VanSales"].ConnectionString;
       // static string connectionstr_pos = ConfigurationManager.ConnectionStrings["VanSales_pos"].ConnectionString;
        //public async static Task<StoredExecuteResulte> ExecuteNonQuery(string spname, Dictionary<object, object> parametersdict = null, bool fireerrormsg = false)
        //{
        //    try
        //    {
        //        using (SqlConnection con = new SqlConnection(connectionstr))
        //        {
        //            using (SqlCommand cmd = new SqlCommand(spname, con))
        //            {
        //                cmd.CommandType = CommandType.StoredProcedure;
        //                SqlParameter[] parameters = BuildParam(parametersdict, true);
        //                if (parameters != null && parameters.Count() != 0)
        //                {
        //                    cmd.Parameters.AddRange(parameters);
        //                }
        //                con.Open();
        //                await cmd.ExecuteNonQueryAsync();
        //                con.Close();
        //                var res = IsHasErrorMsg(cmd);
        //                return new StoredExecuteResulte() { Success = true};
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var exres =new ExceptionAnalyse(ex, spname);
        //        return new StoredExecuteResulte() { errormsg = ""/* exres.storedExecuteResulte.errormsg*/, Success = false };
        //    }


        //}
        public  static StoredExecuteResulte ExecuteNonQuery(string spname, Dictionary<object, object> parametersdict = null, bool fireerrormsg = false,List<string> outparam=null , string constring = "")
        {
            try
            {
                using (SqlConnection con = new SqlConnection())
                {
                    if (constring.Length != 0)
                    {
                        con.ConnectionString = constring;
                    }
                    else
                    {
                        con.ConnectionString = connectionstr;
                    }
                    using (SqlCommand cmd = new SqlCommand(spname, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        SqlCommandBuilder.DeriveParameters(cmd);
                        //SqlParameter[] parameters = BuildParam(cmd,parametersdict, fireerrormsg);
                        BuildParam(cmd, parametersdict, fireerrormsg);
                        //if (parameters != null && parameters.Count() != 0)
                        //{
                        //    cmd.Parameters.AddRange(parameters);
                        //}

                        cmd.ExecuteNonQuery();
                        con.Close();
                        var res = IsHasErrorMsg(cmd);
                        if (res.Item1 == true)
                        {
                            return new StoredExecuteResulte() { errorid = res.Item2, errormsg = res.Item3, Success = false };
                        }
                        else
                        {
                            return new StoredExecuteResulte() { errorid = res.Item2, errormsg = res.Item3, Success = true, outputparams = GetOutPutParamVal(cmd, outparam) };
                        }


                    }

                }
            }
            catch (Exception ex)
            {
                var exres = new ExceptionAnalyse(ex, spname);
                return new StoredExecuteResulte() { errormsg = ex.Message,errorid=1/* exres.storedExecuteResulte.errormsg*/, Success = false };
            }


        }

     
        public static StoredExecuteResulte ExecuteNonQuery<T>(string spname, List<T> parametersdict = null, bool fireerrormsg = false, List<string> outparam = null) where T:class
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstr))
                {
                    using (SqlCommand cmd = new SqlCommand(spname, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = spname;
                        con.Open();
                        SqlCommandBuilder.DeriveParameters(cmd);
                        //SqlParameter[] parameters = BuildParam(cmd,parametersdict, fireerrormsg);
                        BuildParam(cmd, parametersdict, fireerrormsg);
                        //if (parameters != null && parameters.Count() != 0)
                        //{
                        //    cmd.Parameters.AddRange(parameters);
                        //}

                        cmd.ExecuteNonQuery();
                        con.Close();
                        var res = IsHasErrorMsg(cmd);
                        if (res.Item1 == true)
                        {
                            return new StoredExecuteResulte() { errorid = res.Item2, errormsg = res.Item3, Success = false };
                        }
                        else
                        {
                            return new StoredExecuteResulte() { errorid = res.Item2, errormsg = res.Item3, Success = true, outputparams = GetOutPutParamVal(cmd, outparam) };
                        }


                    }

                }
            }
            catch (Exception ex)
            {
                var exres = new ExceptionAnalyse(ex, spname);
                return new StoredExecuteResulte() { errormsg = ex.Message, errorid = 1/* exres.storedExecuteResulte.errormsg*/, Success = false };
            }


        }

        public static StoredExecuteResulte ExecuteNonQuery(string spname,OrderedDictionary  parametersdict = null,  bool fireerrormsg = false, OrderedDictionary parametersdictupd = null)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstr))
                {
                    using (SqlCommand cmd = new SqlCommand(spname, con))
                    {
                        //edit
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = spname;
                        if (con.State == ConnectionState.Closed) con.Open();
                        SqlCommandBuilder.DeriveParameters(cmd);
                      
                        SqlParameter[] parameters = BuildParam(cmd,parametersdict, fireerrormsg);
                        //if (parameters != null && parameters.Count() != 0)
                        //{
                        //    cmd.Parameters.AddRange(parameters);
                        //}
                     
                        if (parametersdictupd!=null)
                        {
                            SqlParameter[]  parametersupd = BuildParam(cmd,parametersdictupd);
                            //if (parametersupd != null && parametersupd.Count() != 0)
                            //{
                            //    cmd.Parameters.AddRange(parametersupd);
                            //}
                        }
                        
                    
                     
                        cmd.ExecuteNonQuery();
                       
                        var res = IsHasErrorMsg(cmd);
                        if (res.Item1==true)
                        {
                            return new StoredExecuteResulte() {errorid=res.Item2,errormsg=res.Item3, Success = false };
                        }
                        return new StoredExecuteResulte() { Success = true };
                    }

                }
            }
            catch (Exception ex)
            {
                var exres = new ExceptionAnalyse(ex, spname);
                return new StoredExecuteResulte() { errormsg = exres.storedExecuteResulte.errormsg,errorid=exres.storedExecuteResulte.errorid/* exres.storedExecuteResulte.errormsg*/, Success = false };
            }


        }

        
            public static StoredExecuteResulte ExecuteNonQuery(string spname, OrderedDictionary parametersdict = null, Dictionary<object, object> otherparams = null, bool fireerrormsg = false, OrderedDictionary parametersdictupd = null)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstr))
                {
                    using (SqlCommand cmd = new SqlCommand(spname, con))
                    {
                       
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = spname;
                        if (con.State == ConnectionState.Closed) con.Open();
                        SqlCommandBuilder.DeriveParameters(cmd);
                        SqlParameter[] parameters = BuildParam(cmd,parametersdict, fireerrormsg);
                        if (parameters != null && parameters.Count() != 0)
                        {
                            cmd.Parameters.AddRange(parameters);
                        }
                        if (otherparams!=null && otherparams.Count!=0)
                        {
                           BuildParam(cmd,otherparams); ;
                        }
                        if (parametersdictupd != null)
                        {
                            SqlParameter[] parametersupd = BuildParam(cmd,parametersdictupd);
                            //if (parametersupd != null && parametersupd.Count() != 0)
                            //{
                            //    cmd.Parameters.AddRange(parametersupd);
                            //}
                        }

                    

                        cmd.ExecuteNonQuery();

                        var res = IsHasErrorMsg(cmd);
                        if (res.Item1 == true)
                        {
                            return new StoredExecuteResulte() { errorid = res.Item2, errormsg = res.Item3, Success = false };
                        }
                        return new StoredExecuteResulte() { Success = true };
                    }

                }
            }
            catch (Exception ex)
            {
                var exres = new ExceptionAnalyse(ex, spname);
                return new StoredExecuteResulte() { errormsg = exres.storedExecuteResulte.errormsg, errorid = exres.storedExecuteResulte.errorid/* exres.storedExecuteResulte.errormsg*/, Success = false };
            }


        }
        #region Revised


        public static StoredExecuteResulte ExecuteNonQueryDefault(string spname, List<object> parametersdict = null,
     Dictionary<object, object> parametersdictupd = null, List<string> outputparam = null, bool fireerrormsg = false, bool defaultparam = false
     , List<ParamObject> ctltext = null, Dictionary<object, object> otherparam = null)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionstr))
                {
                    using (SqlCommand cmd = new SqlCommand(spname, con))
                    {
                      
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = spname;
                        if (con.State == ConnectionState.Closed) con.Open();
                        //SqlCommand cmdparam = new SqlCommand(spname, con);
                        //cmdparam.CommandType = CommandType.StoredProcedure;
                        SqlCommandBuilder.DeriveParameters(cmd);
                        BuildParam(cmd, parametersdict, fireerrormsg, ctltext, defaultparam, outputparam);

                        if (otherparam != null && otherparam.Count != 0)
                        {
                            BuildParam(cmd, otherparam);
                            //cmd.Parameters.AddRange(otherparams);

                        }
                        //if (parametersdictupd != null)
                        //{
                        //    parameters = BuildParam(parametersdictupd);
                        //}
                        //if (parametersdictupd != null && parametersdictupd.Count!=0 && EmaxGlobals.NullToIntZero( parametersdictupd.FirstOrDefault().Value)!=0)
                        //{
                        //    SqlParameter[] parametersupd = BuildParam(cmdparam, parametersdictupd,fireerrormsg);
                        //    if (parametersupd != null && parametersupd.Count() != 0)
                        //    {
                        //        //cmd.Parameters.AddRange(parametersupd);
                        //    }
                        //}

                        //if (parameters != null && parameters.Count() != 0)
                        //{
                        //    cmd.Parameters.AddRange(parameters);
                        //}
                        //foreach (SqlParameter item in cmdparam.Parameters)
                        //{
                        //    if (!item.ParameterName.ToLower().Contains("return"))
                        //    {
                        //        SqlParameter sqlParameter = new SqlParameter();
                        //        sqlParameter.Value = item.Value;
                        //        sqlParameter.Size = item.Size;
                        //        sqlParameter.ParameterName = item.ParameterName;
                        //        sqlParameter.SqlDbType = item.SqlDbType;
                        //        sqlParameter.Direction = item.Direction;
                        //        cmd.Parameters.Add(sqlParameter);
                        //    }

                        //}

                        cmd.ExecuteNonQuery();
                        var res = IsHasErrorMsg(cmd);

                        if (res.Item1 == true)
                        {

                            return new StoredExecuteResulte() { errorid = res.Item2, errormsg = res.Item3, Success = false };
                        }
                        else
                        {
                            return new StoredExecuteResulte() { errorid = 0, outputparams = GetOutPutParamVal(cmd, outputparam), errormsg =res.Item3, Success = true };
                        }


                        //if (cmd.Parameters.Contains("@id"))
                        //{
                        //    return new StoredExecuteResulte() { errorid = 0, key = GetOutPutParamVal(cmd,outputparam), errormsg = "", Success = true };
                        //}
                        //else
                        //{ return new StoredExecuteResulte() { errorid = 0, errormsg = "", Success = true }; }


                    }
                }
            }
            catch (Exception ex)
            {
                var exres = new ExceptionAnalyse(ex, spname);
                return new StoredExecuteResulte() { errorid = 1, errormsg = exres.storedExecuteResulte.errormsg/* exres.storedExecuteResulte.errormsg*/, Success = false };
            }


        }
        #endregion
        //revised



        static Dictionary<string,object> GetOutPutParamVal(SqlCommand sqlCommand, List<string> outputparam)
        {
           // var outputparam=sqlCommand.Parameters.
            Dictionary<string,object> lst = new Dictionary<string, object>();
            if (outputparam != null)
            {


                for (int i = 0; i < outputparam.Count; i++)
                {
                    if (sqlCommand.Parameters.Contains("@" + outputparam[i]) && (sqlCommand.Parameters["@" + outputparam[i]].Direction==ParameterDirection.InputOutput || sqlCommand.Parameters["@" + outputparam[i]].Direction == ParameterDirection.Output))
                    {
                        lst.Add(outputparam[i], EmaxGlobals.NullToEmpty(sqlCommand.Parameters["@" + outputparam[i]].Value));
                    }
                   
                }
            }
            return lst;
        }





    

        public static  SqlDataReader ExecuteReader(string spname, Dictionary<object, object> parametersdict = null, bool fireerrormsg = false)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionstr].ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(spname, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        SqlCommandBuilder.DeriveParameters(cmd);
                       BuildParam(cmd,parametersdict, fireerrormsg);
                        //if (parameters != null && parameters.Count() != 0)
                        //{
                        //    cmd.Parameters.AddRange(parameters);
                        //}

                        //if (parameters != null)
                        //{
                        //    foreach (KeyValuePair<string, object> kvp in parameters)
                        //        cmd.Parameters.Add(new SqlParameter(kvp.Key, kvp.Value));
                        //}
                        con.Open();
                        var sqlreader =  cmd.ExecuteReader();
                        con.Close();
                        return sqlreader;
                    }

                }
            }
            catch (Exception ex)
            {

                return null;
            }


        }


     
        public static StoredExecuteResulte ExcecuteAsyncToDataTable(string spname, Dictionary<object, object> parametersdict = null, bool fireerrormsg = false)
        {


            try
            {
                using (SqlConnection con = new SqlConnection(connectionstr))
                {
                    using (SqlCommand cmd = new SqlCommand(spname, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        SqlCommandBuilder.DeriveParameters(cmd);
                      BuildParam(cmd,parametersdict, fireerrormsg);
                        //if (parameters != null && parameters.Count() != 0)
                        //{
                        //    cmd.Parameters.AddRange(parameters);
                        //}

                        using (SqlDataAdapter sqldataadp = new SqlDataAdapter(cmd))
                        {
                          
                            DataSet ds = new DataSet();
                          
                                sqldataadp.Fill(ds);
                            
                            if (fireerrormsg)
                            {


                                var res = IsHasErrorMsg(cmd);
                                if (res.Item1)
                                {
                                    return new StoredExecuteResulte() { errormsg = res.Item3, errorid = res.Item2, Success = !res.Item1 };
                                }
                                else
                                {
                                    return new StoredExecuteResulte() { errormsg = res.Item3, errorid = res.Item2, Success = !res.Item1, dataTables = ds.Tables };
                                }
                            }
                            else
                            {
                                return new StoredExecuteResulte() { errormsg = "", Success = true, dataTables = ds.Tables };
                            }


                        }
                    }

                }
            }
            catch (Exception ex)
            {
                var exres = new ExceptionAnalyse(ex, spname);
                return new StoredExecuteResulte() { errormsg = exres.storedExecuteResulte.errormsg, Success = false };
            }





        }

        public static StoredExecuteResulte ExcecuteToDataTable(string spname, Dictionary<object, object> parametersdict = null, bool fireerrormsg = false, string constring = "")
        {
            try
            {
               
                using (SqlConnection con = new SqlConnection())
                {
                    if (constring.Length != 0)
                    {
                       con.ConnectionString = constring;
                    }
                    else
                    {
                        con.ConnectionString = connectionstr;
                    }
                    using (SqlCommand cmd = new SqlCommand(spname, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        SqlCommandBuilder.DeriveParameters(cmd);
                       BuildParam(cmd, parametersdict, fireerrormsg);
                        //if (parameters != null && parameters.Count() != 0)
                        //{
                        //    {
                        //        cmd.Parameters.AddRange(parameters);
                        //    }
                        //}

                        using (SqlDataAdapter sqldataadp = new SqlDataAdapter(spname, con))
                        {
                            sqldataadp.SelectCommand = cmd;
                            DataTable tb = new DataTable();
                            //sqldataadp.FillSchema(tb,SchemaType.Source);
                            sqldataadp.Fill(tb);
                         
                            //  var res = CheckErrorMsg(cmd);
                            return new StoredExecuteResulte(){ dataTable = tb } ;
                            //return new StoredExecuteResulte() { errormsg = res.Item2, Success = res.Item1 };
                        }
                    }

                }
            }
            catch (Exception ex)
            {
               // var exres = new ExceptionAnalyse(ex, spname);
                return new StoredExecuteResulte() { errormsg = ex.Message, errorid = 1 };
            }

        }
        public static StoredExecuteResulte ExcecuteToDataTableJson(string spname, Dictionary<object, object> parametersdict = null, bool fireerrormsg = false)
        {


            try
            {
                using (SqlConnection con = new SqlConnection(connectionstr))
                {
                    using (SqlCommand cmd = new SqlCommand(spname, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        SqlCommandBuilder.DeriveParameters(cmd);
                        BuildParam(cmd, parametersdict, fireerrormsg);
                        //if (parameters != null && parameters.Count() != 0)
                        //{
                        //    {
                        //        cmd.Parameters.AddRange(parameters);
                        //    }
                        //}

                        using (SqlDataAdapter sqldataadp = new SqlDataAdapter(spname, con))
                        {
                            sqldataadp.SelectCommand = cmd;
                            DataTable tb = new DataTable();
                            //sqldataadp.FillSchema(tb, SchemaType.Source);
                            sqldataadp.Fill(tb);
                            FormateDate(tb);
                            //StoredExecuteResulte res=new StoredExecuteResulte();
                            if (fireerrormsg)
                            {
                                var res = IsHasErrorMsg(cmd);
                                return new StoredExecuteResulte() { errormsg = res.Item3, errorid = res.Item2, Success = res.Item1, dataTable = tb };
                            }
                            else
                            {
                                return new StoredExecuteResulte() {  dataTable = tb };
                            }
                               
                           
                            //return new StoredExecuteResulte() { errormsg = res.Item2, Success = res.Item1 };
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                // var exres = new ExceptionAnalyse(ex, spname);
                return new StoredExecuteResulte() { errormsg = ex.Message, errorid = 1 };
            }

        }
        static DataTable FormateDate(DataTable dt)
        {
           
                foreach (DataColumn itemcol in dt.Columns)
                {
                    if (itemcol.DataType.Name== "DateTime")
                    {
                    foreach (DataRow item in dt.Rows)
                    {

                        if (EmaxGlobals.NullToEmpty(item[itemcol.ColumnName]) != "")
                        {
                            string dte = DateTime.Parse(item[itemcol.ColumnName].ToString()).ToShortDateString();

                            item[itemcol.ColumnName] = dte;
                        }
                            
                            
                        
                    }
                    }
       
                }
            
            return dt;
        }
        public static StoredExecuteResulte ExcecuteToDataTable(string spname, string paramname,object paramvalue, bool fireerrormsg = false, string constring = "")
        {
            try
            {

                using (SqlConnection con = new SqlConnection())
                {
                    if (constring.Length != 0)
                    {
                        con.ConnectionString = constring;
                    }
                    else
                    {
                        con.ConnectionString = connectionstr;
                    }
                    using (SqlCommand cmd = new SqlCommand(spname, con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] parameters = BuildParam(paramname,paramvalue, fireerrormsg);
                        if (parameters != null && parameters.Count() != 0)
                        {
                            {
                                cmd.Parameters.AddRange(parameters);
                            }
                        }
                        /*check userid param*/
                        if (cmd.Parameters.Contains("@userid"))
                        {
                            var userid = GetTokenKey("userid", HttpContext.Current.Request.Cookies["Token"].Value);
                            cmd.Parameters["@userid"].Value = userid;
                        }
                        using (SqlDataAdapter sqldataadp = new SqlDataAdapter(spname, con))
                        {
                            sqldataadp.SelectCommand = cmd;
                            DataTable tb = new DataTable();
                            sqldataadp.Fill(tb);
                            //  var res = CheckErrorMsg(cmd);
                            return new StoredExecuteResulte() { dataTable = tb };
                            //return new StoredExecuteResulte() { errormsg = res.Item2, Success = res.Item1 };
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                // var exres = new ExceptionAnalyse(ex, spname);
                return new StoredExecuteResulte() { errormsg = ex.Message, errorid = 1 };
            }

        }


    }

        
    
}