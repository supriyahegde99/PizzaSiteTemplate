using System;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLogicLayer
{
    public class SqlHelper
    {
        static SqlConnection ConnectToDB()
        {
            string cs = @"server=H5CG125CX8J;Database=JoesPizzaDB;Trusted_Connection=True;";
            SqlConnection cn = new SqlConnection(cs);
            cn.Open();
            return cn;
        }
        public static DataTable GetAllEmployees(string tablename)
        {
            string query = "SELECT * FROM orders ";

            SqlDataAdapter da = new SqlDataAdapter(query, ConnectToDB());
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public static DataRow GetRowById(string tablename, int id)
        {
            string query = "SELECT * FROM employees WHERE employeeNumber = " + id;

            SqlDataAdapter da = new SqlDataAdapter(query, ConnectToDB());
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0];
        }
        public static int ExecuteNonQuery(string query)
        { 
            SqlCommand cmd = new SqlCommand(query, ConnectToDB());
            return cmd.ExecuteNonQuery();
        }

    }
}
