using DatabaseConnectionCustom.Data;
using DBCon;
using DBCon.PostgreDataStruct;

namespace TestDB
{
    [TestClass]
    public class PostgreTest
    {

        [TestMethod]
        public void TestConecxionDB()
        {

            PostgreeCon  Con =  new PostgreeCon();
            Con.IniciarCon();
            Assert.AreEqual("test", Con.ConsultaTest<UsuarioPostGre>(" select  * from usuario where email like '%llara%'"));


        }


    }
}