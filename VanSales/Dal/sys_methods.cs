using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Emax.SharedLib;

namespace VanSales.Dal
{
    public class sys_methods
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["VanSales"].ConnectionString);
        SqlCommand command = new SqlCommand();
        //sys_urpages_ins
        public void sys_urpages_ins(string UserName, int pageid)
        {

            command = new SqlCommand("sys_urpages_ins");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserName", UserName);
            command.Parameters.AddWithValue("@pageid", pageid);
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }
        ///sys_company
        public DataTable sys_company_sel()
        {
            DataTable dt = new DataTable();
            SqlDataReader dr;

            command = new SqlCommand("sys_company_sel");
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = conn;
            conn.Open();
            dr = command.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            return dt;
        }
        public (int,string) sys_company_upd(string compname, string compact, string compyear, string complegal, string comptel, string compmob, string compweb, string compemail, string compadd, string compmanager, string compvatno, string compnotes, string complogo)
        {

            command = new SqlCommand("sys_company_upd");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@compname", compname);
            command.Parameters.AddWithValue("@compact", compact);
            command.Parameters.AddWithValue("@compyear", compyear);
            command.Parameters.AddWithValue("@complegal", complegal);
            command.Parameters.AddWithValue("@comptel", comptel);
            command.Parameters.AddWithValue("@compmob", compmob);
            command.Parameters.AddWithValue("@compweb", compweb);
            command.Parameters.AddWithValue("@compemail", compemail);
            command.Parameters.AddWithValue("@compadd", compadd);
            command.Parameters.AddWithValue("@compmanager", compmanager);
            command.Parameters.AddWithValue("@compvatno", compvatno);
            command.Parameters.AddWithValue("@compnotes", compnotes);
            command.Parameters.AddWithValue("@complogo", complogo);
            command.Parameters.Add("Errorid", SqlDbType.Int).Direction = ParameterDirection.Output;
            command.Parameters.Add("Errormsg", SqlDbType.NVarChar, 150).Direction = ParameterDirection.Output;
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            int Errorid = EmaxGlobals.NullToIntZero(command.Parameters["Errorid"].Value);
            string Errormsg = EmaxGlobals.NullToEmpty(command.Parameters["Errormsg"].Value);
            conn.Close();
            return (Errorid, Errormsg);

        }
    }
}