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
            //Requisitos de la actividad:
            //Realizar la consulta con parametros de entrada en formato clase(InventarioSQL),
            //tener como resultado la lista de los inventarios que coincidan con los filtros definidos en el test
            SQLconn t = new DBCon.SQLconn();
            t.connect(true);
            Assert.AreEqual("Orbea", t.ConsultaTest<InventarioSQL>("inventario", new InventarioSQL() { codigo = "1234" }));

        }
    }
}