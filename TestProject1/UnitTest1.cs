using DatabaseConnectionCustom.Data;
using DBCon;
using DBCon.PostgreDataStruct;

namespace TestDB
{
    [TestClass]
    public class TestDataBase
    {

        [TestMethod]
        public void TestConecxionDB()
        {

            SQLconn t = new DBCon.SQLconn();
            t.connect();
            t.TestDB();
            
            
            Assert.AreEqual(1, t.TestDB().Tables[0].Rows.Count);
            System.Diagnostics.Trace.WriteLine( SQLconn.connec.ConnectionString);

        }


        [TestMethod]
        public void TestConecxionDBAPP()
        {

            SQLconn t = new DBCon.SQLconn();
            t.connect(true);
            t.TestDB();
            Assert.AreEqual(1, t.TestDB().Tables[0].Rows.Count);

        }
        [TestMethod]
        public void TestDBSelectFunction()
        {

            SQLconn t = new DBCon.SQLconn();
            t.connect(true);
            Assert.AreEqual(1, t.ConsultaTest<Inventario>("inventario", new Inventario() { codigo = "1234" }));

        }
    }
}