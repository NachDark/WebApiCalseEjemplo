using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PruebasSQL
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {


            SqlConnection connec = new SqlConnection();
            //connec.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;User ID=TEST;Initial Catalog=Reservas;Data Source=NACHOPC";
            //connec.ConnectionString = "Integrated Security=SSPI;Persist Security Info=False;User ID=sqltest;Initial Catalog=testdb;Data Source=NACHOPC";
            //Integrated Security = SSPI usa authenticacion de windows
            //connec.ConnectionString = "Persist Security Info=False;Initial Catalog=testdb;User ID=sqltest;Password=sqltest;Data Source=NACHOPC";
            connec.ConnectionString = "Persist Security Info=False;Initial Catalog=testdb;User ID=CEStest;Password=CEStest;Data Source=NACHOPC";
            connec.Open();
            DataSet dt = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand("select * from testtable", connec);
            //adapter.SelectCommand.CommandType = CommandType.;
            adapter.Fill(dt);
            Assert.AreEqual(dt.Tables[0].Rows.Count, 1);
            //return dt;


        }


      
    }
}
