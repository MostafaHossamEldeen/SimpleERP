using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace VanSales.Dal
{
    public class Sec
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["VanSales"].ConnectionString);
        SqlCommand command = new SqlCommand();
        public DataTable sys_urpages_sel(string username)
        {
            DataTable dt = new DataTable();
            SqlDataReader dr;

            command = new SqlCommand("sys_urpages_sel");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", username);
            command.Connection = conn;
            conn.Open();
            dr = command.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            return dt;
        }

        public void sys_urpages_del(string username, int pageid)
        {
            command = new SqlCommand("sys_urpages_del");
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@pageid", pageid);
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
        }

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
    }
}