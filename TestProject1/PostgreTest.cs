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

            PostgreeCon Con = new PostgreeCon();
            Con.IniciarCon();
            Assert.AreEqual("este no es llarados fit", Con.ConsultaTest<UsuarioPostGre>(" select  * from usuario where email like '%emaile%'")[0].imagenusuario.cabezera);


        }
        [TestMethod]
        public void TestInsertDB()
        {

            PostgreeCon Con = new PostgreeCon();
            Con.IniciarCon();
             Con.InsertTest<UsuarioPostGre>("usuario",new UsuarioPostGre() { email = "emaile", imagenusuario = new imagen() { cabezera = "este no es llarados fit" } });


        }


    }
}