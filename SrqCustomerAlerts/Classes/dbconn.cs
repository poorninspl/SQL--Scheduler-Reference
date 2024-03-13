using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SrqCustomerAlerts.Classes
{
    class dbconn
    {
        private SqlConnection OpenConn()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["AuthConn"].ToString());
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }

        public void CloseConn()
        {
            SqlConnection conn = OpenConn();
            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public int ExecuteNonQuerySQL(string query)
        {
            int result = 0;
            using (SqlConnection conn = OpenConn())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle exception or log it
                    Console.WriteLine("Error executing non-query SQL: " + ex.Message);
                }
            }
            return result;
        }

        public string GetExecuteScalar(string query)
        {
            string value = "";
            using (SqlConnection conn = OpenConn())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        value = result.ToString();
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception or log it
                    Console.WriteLine("Error executing scalar SQL: " + ex.Message);
                }
            }
            return value;
        }

        public SqlDataReader GetDataReader(string query)
        {
            SqlConnection conn = OpenConn();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }

        public DataTable GetDataTable(string query)
        {
            using (SqlConnection conn = OpenConn())
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(dt);
                return dt;
            }
        }

        public DataSet GetDataSet(string query, string table)
        {
            using (SqlConnection conn = OpenConn())
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(ds, table);
                return ds;
            }
        }
    }
}
