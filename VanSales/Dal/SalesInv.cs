using Emax.SharedLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VanSales.DBClass
{
    public class SalesInv
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["VanSales"].ConnectionString);
        SqlCommand command = new SqlCommand();
        public (int,string,string,string) s_inv_ins(string snaturename, string sinvdocno, DateTime sinvdata, int sinvpay, string sinvpayname, int custid, string custname, string custvat, string custadd, string suser, string snotes, decimal netbvat, decimal vatvalue, decimal netavat, decimal restvalue, string invdoc,int smanid, string smanname,int branchid,string branchname)
        {
            //-
            command = new SqlCommand("s_inv_ins");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@snaturename", snaturename);
            command.Parameters.Add("sinvnomax", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
           // command.Parameters["@sinvnomax"].Value = DBNull.Value.ToString();
            command.Parameters.AddWithValue("@sinvdocno",   sinvdocno);
            command.Parameters.AddWithValue("@sinvdata",    sinvdata);
            command.Parameters.AddWithValue("@sinvpay",     sinvpay);
            command.Parameters.AddWithValue("@sinvpayname", sinvpayname); 
            command.Parameters.AddWithValue("@branchid", branchid);
            command.Parameters.AddWithValue("@branchname", branchname);
            if (custid == 0)
            {
                command.Parameters.AddWithValue("@custid", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@custid", custid);
            }
            
            command.Parameters.AddWithValue("@custname",    custname);
            command.Parameters.AddWithValue("@custvat",     custvat);
            command.Parameters.AddWithValue("@custadd",     custadd);
            command.Parameters.AddWithValue("@suser",       suser);
            command.Parameters.AddWithValue("@snotes",      snotes);
            //command.Parameters.AddWithValue("@totalinv",    totalinv);
            command.Parameters.AddWithValue("@netbvat",     netbvat);
            command.Parameters.AddWithValue("@vatvalue",    vatvalue);
            command.Parameters.AddWithValue("@netavat", netavat);
            command.Parameters.AddWithValue("@restvalue", restvalue);
            command.Parameters.AddWithValue("@invdoc", invdoc);
            if (smanid == 0 )
            {
                command.Parameters.AddWithValue("@smanid", DBNull.Value);
                command.Parameters.AddWithValue("@smanname", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@smanid", smanid);
                command.Parameters.AddWithValue("@smanname", smanname);
            }
            command.Parameters.Add("Errorid", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
            command.Parameters.Add("time", SqlDbType.VarChar, 5).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
             int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
  
            string Errormsg =EmaxGlobals.NullToEmpty( command.Parameters["Errormsg"].Value);
            string sinvnonew = command.Parameters["sinvnomax"].Value.ToString();
            string time=command.Parameters["time"].Value.ToString();
            conn.Close();
            return (Errorid, sinvnonew, time, Errormsg);
        }
        public (int,string) s_inv_upd(int sinvid,string sinvno, string sinvdocno, DateTime sinvdata, int sinvpay, string sinvpayname, int custid, string custname, string custvat, string custadd, string suser, string snotes, decimal netbvat, decimal vatvalue, decimal netavat, decimal restvalue, string invdoc,int smanid, string smanname)
        {
           
            command = new SqlCommand("s_inv_upd");
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@snaturename", snaturename);
            command.Parameters.AddWithValue("@sinvid", sinvid);
            command.Parameters.AddWithValue("@sinvno", sinvno);
            command.Parameters.AddWithValue("@sinvdocno", sinvdocno);
            command.Parameters.AddWithValue("@sinvdata", sinvdata);
            command.Parameters.AddWithValue("@sinvpay", sinvpay);
            command.Parameters.AddWithValue("@sinvpayname", sinvpayname);
            if (custid == 0)
            {
                command.Parameters.AddWithValue("@custid", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@custid", custid);
            }
            command.Parameters.AddWithValue("@custname", custname);
            command.Parameters.AddWithValue("@custvat", custvat);
            command.Parameters.AddWithValue("@custadd", custadd);
            command.Parameters.AddWithValue("@suser", suser);
            command.Parameters.AddWithValue("@snotes", snotes);
            //command.Parameters.AddWithValue("@totalinv",    totalinv);
            command.Parameters.AddWithValue("@netbvat", netbvat);
            command.Parameters.AddWithValue("@vatvalue", vatvalue);
            command.Parameters.AddWithValue("@netavat", netavat);
            command.Parameters.AddWithValue("@restvalue", restvalue);
            command.Parameters.AddWithValue("@invdoc", invdoc);
            if (smanid == 0)
            {
                command.Parameters.AddWithValue("@smanid", DBNull.Value);
                command.Parameters.AddWithValue("@smanname", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@smanid", smanid);
                command.Parameters.AddWithValue("@smanname", smanname);
            }
            command.Parameters.Add("Errorid", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;

            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
             string Errormsg =EmaxGlobals.NullToEmpty( command.Parameters["Errormsg"].Value);
            conn.Close();
            return (Errorid,Errormsg);
        }
        public (int,string) s_inv_del(int sinvid)
        {
         
            command = new SqlCommand("s_inv_del");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@sinvid", sinvid);
            command.Parameters.Add("Errorid", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
             string Errormsg =EmaxGlobals.NullToEmpty( command.Parameters["Errormsg"].Value);
            conn.Close();
            return (Errorid, Errormsg);
        }
        public DataTable s_inv_sel_search(int sinvid)
        {
            DataTable dt = new DataTable();
            SqlDataReader dr;
        
            command = new SqlCommand("s_inv_sel_search");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@sinvid", sinvid);
            //command.Parameters.AddWithValue("@sinvdocno", sinvdocno);
            command.Connection = conn;
            conn.Open();
            dr = command.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            return dt;
        }
        public DataTable s_inv_sel_id(int sinvid)
        {
            DataTable dt = new DataTable();
            SqlDataReader dr;
          
            command = new SqlCommand("s_inv_sel_id");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@sinvid", sinvid);
            //command.Parameters.AddWithValue("@sinvdocno", sinvdocno);
            command.Connection = conn;
            conn.Open();
            dr = command.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            return dt;
        }
        public DataTable s_inv_sel_sinvid(string sinvno)
        {
            DataTable dt = new DataTable();
            SqlDataReader dr;

            command = new SqlCommand("s_inv_sel_sinvid");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@sinvno", sinvno);
            //command.Parameters.AddWithValue("@sinvdocno", sinvdocno);
            command.Connection = conn;
            conn.Open();
            dr = command.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            return dt;
        }
        public (int,string) s_invdtls_ins(int sinvid, int itemid, int unitid, decimal qty, decimal price, decimal value, decimal discp, decimal discvalue, decimal netvalue, decimal vatvalue, string itemnotes, int natureinv, int branchid, DateTime invdate, int custid, string sinvno, string fyear)
        {
            //, string unitname
            command = new SqlCommand("s_invdtls_ins");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@sinvid", sinvid);
            command.Parameters.AddWithValue("@itemid", itemid);
            command.Parameters.AddWithValue("@unitid", unitid);
           // command.Parameters.AddWithValue("@unitname", unitname);
            command.Parameters.AddWithValue("@qty", qty);
            command.Parameters.AddWithValue("@price", price);
            //command.Parameters.AddWithValue("@icost", icost);
            command.Parameters.AddWithValue("@value", value);
            command.Parameters.AddWithValue("@discp", discp);
            command.Parameters.AddWithValue("@discvalue", discvalue);
            command.Parameters.AddWithValue("@netvalue", netvalue);
            //command.Parameters.AddWithValue("@totalinv",    totalinv);
            command.Parameters.AddWithValue("@vatvalue", vatvalue);
            command.Parameters.AddWithValue("@itemnotes", itemnotes);
            command.Parameters.AddWithValue("@natureinv", natureinv);
            command.Parameters.AddWithValue("@branchid", branchid);
            command.Parameters.AddWithValue("@invdate", invdate);
            if (custid == 0)
            {
                command.Parameters.AddWithValue("@custid", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@custid", custid);
            }
            command.Parameters.AddWithValue("@sinvno", sinvno);
            //command.Parameters.AddWithValue("@custname", custname);
            //command.Parameters.AddWithValue("@branchname", branchname);
            command.Parameters.AddWithValue("@fyear", fyear);
           
            command.Parameters.Add("Errorid", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
             string Errormsg =EmaxGlobals.NullToEmpty( command.Parameters["Errormsg"].Value);
            conn.Close();
            return (Errorid, Errormsg);
        }
     
        public (int,string) s_invdtls_upd(int invdtlid, int sinvid, int itemid, int unitid, decimal qty, decimal price, decimal value, decimal discp, decimal discvalue, decimal netvalue, decimal vatvalue, string itemnotes, int natureinv, int branchid, DateTime invdate, int custid, string sinvno, string fyear,int action)
        {

            command = new SqlCommand("s_invdtls_upd");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@invdtlid", invdtlid);
            command.Parameters.AddWithValue("@sinvid", sinvid);
            command.Parameters.AddWithValue("@itemid", itemid);
            command.Parameters.AddWithValue("@unitid", unitid);
           // command.Parameters.AddWithValue("@unitname", unitname);
            command.Parameters.AddWithValue("@qty", qty);
            command.Parameters.AddWithValue("@price", price);
            //command.Parameters.AddWithValue("@icost", icost);
            command.Parameters.AddWithValue("@value", value);
            command.Parameters.AddWithValue("@discp", discp);
            command.Parameters.AddWithValue("@discvalue", discvalue);
            command.Parameters.AddWithValue("@netvalue", netvalue);
            //command.Parameters.AddWithValue("@totalinv",    totalinv);
            command.Parameters.AddWithValue("@vatvalue", vatvalue);
            command.Parameters.AddWithValue("@itemnotes", itemnotes);
            command.Parameters.AddWithValue("@natureinv", natureinv);
            command.Parameters.AddWithValue("@branchid", branchid);
            command.Parameters.AddWithValue("@invdate", invdate);
            if (custid == 0)
            {
                command.Parameters.AddWithValue("@custid", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@custid", custid);
            }
            command.Parameters.AddWithValue("@sinvno", sinvno);
           // command.Parameters.AddWithValue("@custname", custname);
           // command.Parameters.AddWithValue("@branchname", branchname);
            command.Parameters.AddWithValue("@fyear", fyear);
            command.Parameters.AddWithValue("@action", action);

            command.Parameters.Add("Errorid", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
             string Errormsg =EmaxGlobals.NullToEmpty( command.Parameters["Errormsg"].Value);
            conn.Close();
            return (Errorid, Errormsg);
        }

        public (int,string) s_invdtls_del(int invdtlid)
        {

            command = new SqlCommand("s_invdtls_del");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@invdtlid", invdtlid);
            command.Parameters.Add("Errorid", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
             string Errormsg =EmaxGlobals.NullToEmpty( command.Parameters["Errormsg"].Value);
            conn.Close();
            return (Errorid, Errormsg);
        }
        public DataTable st_items_sel_item_code(string itemcode)
        {
            DataTable dt = new DataTable();
            SqlDataReader dr;
 
            command = new SqlCommand("st_items_sel_item_code");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@itemcode", itemcode);
            command.Connection = conn;
            conn.Open();
            dr = command.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            return dt;
        }
        public DataTable st_items_sel_itemid(string itemid)
        {
            DataTable dt = new DataTable();
            SqlDataReader dr;

            command = new SqlCommand("st_items_sel_itemid");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@itemid", itemid);
            command.Connection = conn;
            conn.Open();
            dr = command.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            return dt;
        }
        public DataTable s_customers_sel_custid(int custid)
        {
            DataTable dt = new DataTable();
            SqlDataReader dr;

            command = new SqlCommand("s_customers_sel_custid");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@custid", custid);
            command.Connection = conn;
            conn.Open();
            dr = command.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            return dt;
        }
        public DataTable s_customers_sel_custcode(string custcode)
        {
            DataTable dt = new DataTable();
            SqlDataReader dr;

            command = new SqlCommand("s_customers_sel_custcode");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@custcode", custcode);
            command.Connection = conn;
            conn.Open();
            dr = command.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            return dt;
        }
        public (int,string) s_invpay_ins(int invid, int paytypeid, double payvalue,  string payno,string payref, DateTime invdate, int custid, string sinvno, string fyear)
        {

            command = new SqlCommand("s_invpay_ins");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@invid", invid);
            command.Parameters.AddWithValue("@paytypeid", paytypeid);
            command.Parameters.AddWithValue("@payvalue", payvalue);
            command.Parameters.AddWithValue("@payno", payno);
            command.Parameters.AddWithValue("@payref", payref);
           // command.Parameters.AddWithValue("@natureinv", natureinv);
            //command.Parameters.AddWithValue("@branchid", branchid);
            command.Parameters.AddWithValue("@invdate", invdate);
            if (custid == 0)
            {
                command.Parameters.AddWithValue("@custid", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@custid", custid);
            }
            command.Parameters.AddWithValue("@sinvno", sinvno);
            //command.Parameters.AddWithValue("@custname", custname);
            //command.Parameters.AddWithValue("@branchname", branchname);
            command.Parameters.AddWithValue("@fyear", fyear);

            command.Parameters.Add("Errorid", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.NVarChar,100).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
             string Errormsg =EmaxGlobals.NullToEmpty( command.Parameters["Errormsg"].Value);
            conn.Close();
            return (Errorid, Errormsg);
        }
        public (int,string) s_invpay_upd(int invpayid, int invid, int paytypeid, double payvalue, string payno, string payref, DateTime invdate, int custid, string sinvno, string fyear, int action)
        {

            command = new SqlCommand("s_invpay_upd");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@invpayid", invpayid);
            command.Parameters.AddWithValue("@invid", invid);
            command.Parameters.AddWithValue("@paytypeid", paytypeid);
            command.Parameters.AddWithValue("@payvalue", payvalue);
            command.Parameters.AddWithValue("@payno", payno);
            command.Parameters.AddWithValue("@payref", payref);
           // command.Parameters.AddWithValue("@natureinv", natureinv);
            //command.Parameters.AddWithValue("@branchid", branchid);
            command.Parameters.AddWithValue("@invdate", invdate);
           
            if (custid == 0)
            {
                command.Parameters.AddWithValue("@custid", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@custid", custid);
            }
            command.Parameters.AddWithValue("@sinvno", sinvno);
            //command.Parameters.AddWithValue("@custname", custname);
            //command.Parameters.AddWithValue("@branchname", branchname);
            command.Parameters.AddWithValue("@fyear", fyear);
            command.Parameters.AddWithValue("@action", action);
            command.Parameters.Add("Errorid", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
             string Errormsg =EmaxGlobals.NullToEmpty( command.Parameters["Errormsg"].Value);
            conn.Close();
            return (Errorid, Errormsg);
        }
        public (int,string) s_invpay_del(int invpayid)
        {

            command = new SqlCommand("s_invpay_del");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@invpayid", invpayid);
            command.Parameters.Add("Errorid", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
             string Errormsg =EmaxGlobals.NullToEmpty( command.Parameters["Errormsg"].Value);
            conn.Close();
            return (Errorid, Errormsg);
        }


        /// //////////////
        ///////// Ret inv
        public DataTable s_rtn_inv_sel_invcode(string @sinvno)
        {
            DataTable dt = new DataTable();
            SqlDataReader dr;

            command = new SqlCommand("s_rtn_inv_sel_invcode");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@sinvno", sinvno);
            //command.Parameters.AddWithValue("@sinvdocno", sinvdocno);
            command.Connection = conn;
            conn.Open();
            dr = command.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            return dt;
        }
        public (int,string, string, string) s_rtninv_ins(string snaturename, string sinvdocno, DateTime sinvdata, int sinvpay, string sinvpayname, int custid, string custname, string custvat, string custadd, string suser, string snotes, decimal netbvat, decimal vatvalue, decimal netavat, decimal restvalue, string invdoc,int docid,string docno,bool withoutinv, int smanid, string smanname)
        {

            command = new SqlCommand("s_rtn_inv_ins");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@snaturename", snaturename);
            command.Parameters.Add("sinvnomax", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            // command.Parameters["@sinvnomax"].Value = DBNull.Value.ToString();
            command.Parameters.AddWithValue("@sinvdocno", sinvdocno);
            command.Parameters.AddWithValue("@sinvdata", sinvdata);
            command.Parameters.AddWithValue("@sinvpay", sinvpay);
            command.Parameters.AddWithValue("@sinvpayname", sinvpayname);
            if (custid == 0)
            {
                command.Parameters.AddWithValue("@custid", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@custid", custid);
            }
            command.Parameters.AddWithValue("@custname", custname);
            command.Parameters.AddWithValue("@custvat", custvat);
            command.Parameters.AddWithValue("@custadd", custadd);
            command.Parameters.AddWithValue("@suser", suser);
            command.Parameters.AddWithValue("@snotes", snotes);
            //command.Parameters.AddWithValue("@totalinv",    totalinv);
            command.Parameters.AddWithValue("@netbvat", netbvat);
            command.Parameters.AddWithValue("@vatvalue", vatvalue);
            command.Parameters.AddWithValue("@netavat", netavat);
            command.Parameters.AddWithValue("@restvalue", restvalue);
            command.Parameters.AddWithValue("@invdoc", invdoc);
            command.Parameters.AddWithValue("@docid", docid);
            command.Parameters.AddWithValue("@docno", docno);
            command.Parameters.AddWithValue("@withoutinv", withoutinv);
            if (smanid == 0)
            {
                command.Parameters.AddWithValue("@smanid", DBNull.Value);
                command.Parameters.AddWithValue("@smanname", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@smanid", smanid);
                command.Parameters.AddWithValue("@smanname", smanname);
            }

            command.Parameters.Add("Errorid", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.VarChar, 150).Direction = ParameterDirection.Output;
            command.Parameters.Add("time", SqlDbType.VarChar, 5).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
            string Errormsg = EmaxGlobals.NullToEmpty(command.Parameters["Errormsg"].Value);
            string sinvnonew = command.Parameters["sinvnomax"].Value.ToString();
            string time = command.Parameters["time"].Value.ToString();
            conn.Close();
            return (Errorid, Errormsg, sinvnonew, time);
        }
        public (int,string) s_rtninv_upd(int sinvid, string sinvno, string sinvdocno, DateTime sinvdata, int sinvpay, string sinvpayname, int custid, string custname, string custvat, string custadd, string suser, string snotes, decimal netbvat, decimal vatvalue, decimal netavat, decimal restvalue, string invdoc, int docid, string docno,bool withoutinv, int smanid, string smanname)
        {

            command = new SqlCommand("s_rtninv_upd");
            command.CommandType = CommandType.StoredProcedure;
            //command.Parameters.AddWithValue("@snaturename", snaturename);
            command.Parameters.AddWithValue("@sinvid", sinvid);
            command.Parameters.AddWithValue("@sinvno", sinvno);
            command.Parameters.AddWithValue("@sinvdocno", sinvdocno);
            command.Parameters.AddWithValue("@sinvdata", sinvdata);
            command.Parameters.AddWithValue("@sinvpay", sinvpay);
            command.Parameters.AddWithValue("@sinvpayname", sinvpayname);
            if (custid == 0)
            {
                command.Parameters.AddWithValue("@custid", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@custid", custid);
            }
            command.Parameters.AddWithValue("@custname", custname);
            command.Parameters.AddWithValue("@custvat", custvat);
            command.Parameters.AddWithValue("@custadd", custadd);
            command.Parameters.AddWithValue("@suser", suser);
            command.Parameters.AddWithValue("@snotes", snotes);
            //command.Parameters.AddWithValue("@totalinv",    totalinv);
            command.Parameters.AddWithValue("@netbvat", netbvat);
            command.Parameters.AddWithValue("@vatvalue", vatvalue);
            command.Parameters.AddWithValue("@netavat", netavat);
            command.Parameters.AddWithValue("@restvalue", restvalue);
            command.Parameters.AddWithValue("@invdoc", invdoc);
            if (docid ==-1)
            {
                command.Parameters.AddWithValue("@docid", DBNull.Value);
                command.Parameters.AddWithValue("@docno", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@docid", docid);
                command.Parameters.AddWithValue("@docno", docno);
            }
            command.Parameters.AddWithValue("@withoutinv", withoutinv);
            if (smanid == 0)
            {
                command.Parameters.AddWithValue("@smanid", DBNull.Value);
                command.Parameters.AddWithValue("@smanname", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@smanid", smanid);
                command.Parameters.AddWithValue("@smanname", smanname);
            }
            command.Parameters.Add("Errorid", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.VarChar, 150).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
             string Errormsg =EmaxGlobals.NullToEmpty( command.Parameters["Errormsg"].Value);
            conn.Close();
            return (Errorid,Errormsg);
        }
        public (int,string) s_rtninv_del(int sinvid)
        {

            command = new SqlCommand("s_rtninv_del");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@sinvid", sinvid);
            command.Parameters.Add("Errorid", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
             string Errormsg =EmaxGlobals.NullToEmpty( command.Parameters["Errormsg"].Value);
            conn.Close();
            return (Errorid, Errormsg);
        }
        public (int,string) s_rtn_invdtls_ins(int rtn_sinvid, int itemid, int unitid, decimal qty, decimal price, decimal value, decimal discp, decimal discvalue, decimal netvalue, decimal vatvalue, string itemnotes, int natureinv, int branchid, DateTime invdate, int custid, string sinvno, string fyear)
        {
            //, string unitname
            command = new SqlCommand("s_rtn_invdtls_ins");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@rtn_sinvid", rtn_sinvid);
            command.Parameters.AddWithValue("@itemid", itemid);
            command.Parameters.AddWithValue("@unitid", unitid);
            // command.Parameters.AddWithValue("@unitname", unitname);
            command.Parameters.AddWithValue("@qty", qty);
            command.Parameters.AddWithValue("@price", price);
            //command.Parameters.AddWithValue("@icost", icost);
            command.Parameters.AddWithValue("@value", value);
            command.Parameters.AddWithValue("@discp", discp);
            command.Parameters.AddWithValue("@discvalue", discvalue);
            command.Parameters.AddWithValue("@netvalue", netvalue);
            //command.Parameters.AddWithValue("@totalinv",    totalinv);
            command.Parameters.AddWithValue("@vatvalue", vatvalue);
            command.Parameters.AddWithValue("@itemnotes", itemnotes);
            command.Parameters.AddWithValue("@natureinv", natureinv);
            command.Parameters.AddWithValue("@branchid", branchid);
            command.Parameters.AddWithValue("@invdate", invdate);
            if (custid == 0)
            {
                command.Parameters.AddWithValue("@custid", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@custid", custid);
            }
            command.Parameters.AddWithValue("@sinvno", sinvno);
            //command.Parameters.AddWithValue("@custname", custname);
            //command.Parameters.AddWithValue("@branchname", branchname);
            command.Parameters.AddWithValue("@fyear", fyear);

            command.Parameters.Add("Errorid", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
             string Errormsg =EmaxGlobals.NullToEmpty( command.Parameters["Errormsg"].Value);
            conn.Close();
            return (Errorid, Errormsg);
        }
        public (int,string) s_rtn_allinvdtls_ins(int rtn_sinvid, string sinvno, int sinvid)
        {
            //, string unitname
            command = new SqlCommand("s_rtn_all_invdtls_ins");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@rtn_sinvid", rtn_sinvid);
            command.Parameters.AddWithValue("@sinvid", sinvid);
        
            command.Parameters.AddWithValue("@sinvno", sinvno);
          
            command.Parameters.Add("Errorid", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
             string Errormsg =EmaxGlobals.NullToEmpty( command.Parameters["Errormsg"].Value);
            conn.Close();
           return (Errorid, Errormsg);
        }

        public (int,string) s_rtn_invdtls_upd(int invdtlid, int sinvid, int itemid, int unitid, decimal qty, decimal price, decimal value, decimal discp, decimal discvalue, decimal netvalue, decimal vatvalue, string itemnotes, int natureinv, int branchid, DateTime invdate, int custid, string sinvno, string fyear, int action)
        {

            command = new SqlCommand("s_rtn_invdtls_upd");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@invdtlid", invdtlid);
            command.Parameters.AddWithValue("@sinvid", sinvid);
            command.Parameters.AddWithValue("@itemid", itemid);
            command.Parameters.AddWithValue("@unitid", unitid);
            // command.Parameters.AddWithValue("@unitname", unitname);
            command.Parameters.AddWithValue("@qty", qty);
            command.Parameters.AddWithValue("@price", price);
            //command.Parameters.AddWithValue("@icost", icost);
            command.Parameters.AddWithValue("@value", value);
            command.Parameters.AddWithValue("@discp", discp);
            command.Parameters.AddWithValue("@discvalue", discvalue);
            command.Parameters.AddWithValue("@netvalue", netvalue);
            //command.Parameters.AddWithValue("@totalinv",    totalinv);
            command.Parameters.AddWithValue("@vatvalue", vatvalue);
            command.Parameters.AddWithValue("@itemnotes", itemnotes);
            command.Parameters.AddWithValue("@natureinv", natureinv);
            command.Parameters.AddWithValue("@branchid", branchid);
            command.Parameters.AddWithValue("@invdate", invdate);
            if (custid == 0)
            {
                command.Parameters.AddWithValue("@custid", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@custid", custid);
            }
            command.Parameters.AddWithValue("@sinvno", sinvno);
            // command.Parameters.AddWithValue("@custname", custname);
            // command.Parameters.AddWithValue("@branchname", branchname);
            command.Parameters.AddWithValue("@fyear", fyear);
            command.Parameters.AddWithValue("@action", action);

            command.Parameters.Add("Errorid", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
             string Errormsg =EmaxGlobals.NullToEmpty( command.Parameters["Errormsg"].Value);
            conn.Close();
            return (Errorid, Errormsg);
        }
        public (int,string) s_rtn_invdtls_del(int invdtlid)
        {

            command = new SqlCommand("s_rtn_invdtls_del");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@invdtlid", invdtlid);
            command.Parameters.Add("Errorid", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
             string Errormsg =EmaxGlobals.NullToEmpty( command.Parameters["Errormsg"].Value);
            conn.Close();
            return (Errorid, Errormsg);
        }
        public DataTable s_rtn_invdtls_sel(int sinvid)
        {
            DataTable dt = new DataTable();
            SqlDataReader dr;

            command = new SqlCommand("s_rtn_invdtls_sel");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@sinvid", sinvid);
          
            command.Connection = conn;
            conn.Open();
            dr = command.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            return dt;
        }
        public DataTable s_rtn_invdtls_qty_sel(int rtn_sinvno,int sinvno,int itemid,int actiontype,int invdtlid)
        {
            DataTable dt = new DataTable();
            SqlDataReader dr;

            command = new SqlCommand("s_rtn_invdtls_qty_sel");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@rtn_sinvno", rtn_sinvno);
            command.Parameters.AddWithValue("@sinvno", sinvno);
            command.Parameters.AddWithValue("@itemid", itemid);
            command.Parameters.AddWithValue("@actiontype", actiontype);
            command.Parameters.AddWithValue("@invdtlid", invdtlid);
          //  command.Parameters.Add("Errorid", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            dr = command.ExecuteReader();
          //  int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
            dt.Load(dr);
            conn.Close();
            return (dt);
        }
        public (int, string) s_rtn_invpay_ins(int invid, int paytypeid, double payvalue, string payno, string payref, DateTime invdate, int custid, string sinvno, string fyear)
        {

            command = new SqlCommand("s_rtn_invpay_ins");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@invid", invid);
            command.Parameters.AddWithValue("@paytypeid", paytypeid);
            command.Parameters.AddWithValue("@payvalue", payvalue);
            command.Parameters.AddWithValue("@payno", payno);
            command.Parameters.AddWithValue("@payref", payref);
            // command.Parameters.AddWithValue("@natureinv", natureinv);
            //command.Parameters.AddWithValue("@branchid", branchid);
            command.Parameters.AddWithValue("@invdate", invdate);
            if (custid == 0)
            {
                command.Parameters.AddWithValue("@custid", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@custid", custid);
            }
            command.Parameters.AddWithValue("@sinvno", sinvno);
            //command.Parameters.AddWithValue("@custname", custname);
            //command.Parameters.AddWithValue("@branchname", branchname);
            command.Parameters.AddWithValue("@fyear", fyear);

            command.Parameters.Add("Errorid", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
             string Errormsg =EmaxGlobals.NullToEmpty( command.Parameters["Errormsg"].Value);
            conn.Close();
            return (Errorid, Errormsg);
        }
        public (int, string) s_rtn_invpay_upd(int invpayid, int invid, int paytypeid, double payvalue, string payno, string payref, DateTime invdate, int custid, string sinvno, string fyear, int action)
        {

            command = new SqlCommand("s_rtn_invpay_upd");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@invpayid", invpayid);
            command.Parameters.AddWithValue("@invid", invid);
            command.Parameters.AddWithValue("@paytypeid", paytypeid);
            command.Parameters.AddWithValue("@payvalue", payvalue);
            command.Parameters.AddWithValue("@payno", payno);
            command.Parameters.AddWithValue("@payref", payref);
            // command.Parameters.AddWithValue("@natureinv", natureinv);
            //command.Parameters.AddWithValue("@branchid", branchid);
            command.Parameters.AddWithValue("@invdate", invdate);
            if (custid == 0)
            {
                command.Parameters.AddWithValue("@custid", DBNull.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@custid", custid);
            }
            command.Parameters.AddWithValue("@sinvno", sinvno);
            //command.Parameters.AddWithValue("@custname", custname);
            //command.Parameters.AddWithValue("@branchname", branchname);
            command.Parameters.AddWithValue("@fyear", fyear);
            command.Parameters.AddWithValue("@action", action);
            command.Parameters.Add("Errorid", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.NVarChar, 100).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
             string Errormsg =EmaxGlobals.NullToEmpty( command.Parameters["Errormsg"].Value);
            conn.Close();
            return (Errorid, Errormsg);
        }

        public (int,string) s_rtn_invpay_del(int invdtlid)
        {

            command = new SqlCommand("s_rtn_invpay_del");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@invdtlid", invdtlid);
            command.Parameters.Add("Errorid", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int  Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
             string Errormsg =EmaxGlobals.NullToEmpty( command.Parameters["Errormsg"].Value);
            conn.Close();
            return (Errorid, Errormsg);
        }
        
       
    }
}