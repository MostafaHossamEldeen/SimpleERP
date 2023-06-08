using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Emax.VanSales.Service.Dal
{
    public class SalesInv
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["VanSales"].ConnectionString);
        SqlCommand command = new SqlCommand();
        public (int,string) s_inv_ins(string snaturename, string sinvdocno, DateTime ?sinvdata, int ?sinvpay, string sinvpayname, int ?custid, string custname, string custvat, string custadd, string suser, string snotes, decimal ?netbvat, decimal ?vatvalue, decimal ?netavat, decimal ?restvalue, string invdoc)
        {
            
            command = new SqlCommand("s_inv_ins");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@snaturename", snaturename);
            command.Parameters.Add("sinvnomax", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;
           // command.Parameters["@sinvnomax"].Value = DBNull.Value.ToString();
            command.Parameters.AddWithValue("@sinvdocno",   sinvdocno);
            command.Parameters.AddWithValue("@sinvdata",    sinvdata);
            command.Parameters.AddWithValue("@sinvpay",     sinvpay);
            command.Parameters.AddWithValue("@sinvpayname", sinvpayname);
            command.Parameters.AddWithValue("@custid",      custid);
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
            command.Parameters.Add("Error_id", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
          int  Error_id =Convert.ToInt32(command.Parameters["Error_id"].Value);
          string sinvnonew = command.Parameters["sinvnomax"].Value.ToString();
            conn.Close();
            return (Error_id, sinvnonew);
        }
        public int s_inv_upd(int sinvid,string sinvno, string sinvdocno, DateTime sinvdata, int sinvpay, string sinvpayname, int custid, string custname, string custvat, string custadd, string suser, string snotes, decimal netbvat, decimal vatvalue, decimal netavat, decimal restvalue, string invdoc)
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
            command.Parameters.AddWithValue("@custid", custid);
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
            command.Parameters.Add("Error_id", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int Error_id = Convert.ToInt32(command.Parameters["Error_id"].Value);
          
            conn.Close();
            return Error_id;
        }
        public void s_inv_del(int sinvid)
        {
         
            command = new SqlCommand("s_inv_del");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@sinvid", sinvid);
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
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
        public int s_invdtls_ins(int sinvid, int itemid, int unitid, string unitname, decimal qty, decimal price, decimal value, decimal discp, decimal discvalue, decimal netvalue, decimal vatvalue, string itemnotes, int natureinv, int branchid, DateTime invdate, int custid, string sinvno, string custname, string branchname, string fyear)
        {
           
            command = new SqlCommand("s_invdtls_ins");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@sinvid", sinvid);
            command.Parameters.AddWithValue("@itemid", itemid);
            command.Parameters.AddWithValue("@unitid", unitid);
            command.Parameters.AddWithValue("@unitname", unitname);
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
            command.Parameters.AddWithValue("@custid", custid);
            command.Parameters.AddWithValue("@sinvno", sinvno);
            command.Parameters.AddWithValue("@custname", custname);
            command.Parameters.AddWithValue("@branchname", branchname);
            command.Parameters.AddWithValue("@fyear", fyear);
           
            command.Parameters.Add("Error_id", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int Error_id = Convert.ToInt32(command.Parameters["Error_id"].Value);
            conn.Close();
            return (Error_id);
        }

        public int s_invdtls_upd(int invdtlid, int sinvid, int itemid, int unitid, string unitname, decimal qty, decimal price, decimal value, decimal discp, decimal discvalue, decimal netvalue, decimal vatvalue, string itemnotes, int natureinv, int branchid, DateTime invdate, int custid, string sinvno, string custname, string branchname, string fyear)
        {

            command = new SqlCommand("s_invdtls_upd");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@invdtlid", invdtlid);
            command.Parameters.AddWithValue("@sinvid", sinvid);
            command.Parameters.AddWithValue("@itemid", itemid);
            command.Parameters.AddWithValue("@unitid", unitid);
            command.Parameters.AddWithValue("@unitname", unitname);
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
            command.Parameters.AddWithValue("@custid", custid);
            command.Parameters.AddWithValue("@sinvno", sinvno);
            command.Parameters.AddWithValue("@custname", custname);
            command.Parameters.AddWithValue("@branchname", branchname);
            command.Parameters.AddWithValue("@fyear", fyear);

            command.Parameters.Add("Error_id", SqlDbType.VarChar, 50).Direction = ParameterDirection.Output;

            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int Error_id = Convert.ToInt32(command.Parameters["Error_id"].Value);
            conn.Close();
            return (Error_id);
        }

        public void s_invdtls_del(int invdtlid)
        {

            command = new SqlCommand("s_invdtls_del");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@invdtlid", invdtlid);
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
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
    }
}