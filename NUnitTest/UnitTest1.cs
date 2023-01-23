using NUnit.Framework;
using System;
using System.Data;
using System.Data.SqlClient;

namespace TestProject1
{
    public class Tests
    {
        static SqlConnection ConnectToDB()
        {
            string cs = @"server=H5CG125CW45;Database=JoesPizzaDB;Trusted_Connection=True;";
            SqlConnection cn = new SqlConnection(cs);
            cn.Open();
            return cn;
        }
        public static DataRow GetRowById(int id)
        {
            string query = "SELECT * FROM orderdetails WHERE orderid = " + id;

            SqlDataAdapter da = new SqlDataAdapter(query, ConnectToDB());
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt.Rows[0];
        }

        public static DataRow GetRowByName(int id)
        {

            string query = "SELECT * FROM Products WHERE Id = " + id;

            SqlDataAdapter da = new SqlDataAdapter(query, ConnectToDB());
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt.Rows[0];
        }
        public static int  GetAllRows()
        {
            SqlConnection conn = new SqlConnection("Server=H5CG125CW45;Database=JoesPizzaDB;Integrated Security=true;");
            conn.Open();
            SqlCommand comm = new SqlCommand("SELECT COUNT(*) FROM orderdetails", conn);
            Int32 count = (Int32)comm.ExecuteScalar();
            return count;
        }

 
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int id = 9756659;
            DataRow dt = GetRowById(id);
            int expected = 200;
            Assert.AreEqual(expected, dt[2]);
        }
        [Test]
        public void Test2()
        {
            int id = 2;
            DataRow dt = GetRowByName(id);
            string expected = "margherita large";
            Assert.AreEqual(expected, dt[1]);
        }
        [Test]
        public void Test3()
        {
            
            int actual=GetAllRows();
            int expected = 15;
            Assert.AreEqual(expected, actual);
        }
    }
}