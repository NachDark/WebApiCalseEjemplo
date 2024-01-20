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
        public void TestConecxionDB2()
        {

            PostgreeCon Con = new PostgreeCon();
            Con.IniciarCon();
            Assert.AreEqual("este no es llarados fit", Con.ConsultaTest<UsuarioPostGre>("usuario", new UsuarioPostGre() { email = "emaile" })[0].imagenusuario.cabezera);


        }
        [TestMethod]
        public void TestConecxionDBEjercicioClase()
        {
            PostgreeCon Con = new PostgreeCon();
            Con.IniciarCon();
            Assert.AreEqual("Orbea", Con.ConsultaTest<Inventario>("inventario", new Inventario() { codigo = "1234" })[0].proveedor.nombreprov);

        }
        [TestMethod]
        public void TestInsertDB()
        {

            PostgreeCon Con = new PostgreeCon();
            Con.IniciarCon();
            Con.InsertTest<UsuarioPostGre>("usuario", new UsuarioPostGre() { email = "emaile", imagenusuario = new imagen() { cabezera = "este no es llarados fit" } });


        }
    


    }
}