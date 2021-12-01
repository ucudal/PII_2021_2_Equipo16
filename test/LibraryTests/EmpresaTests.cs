namespace Test.Library
{
    using ClassLibrary;
    using NUnit.Framework;

    /// <summary>
    /// Esta clase permite realizar los tests de la clase Empresa.
    /// </summary>
    [TestFixture]
    public class EmpresaTests
    {
        /// <summary>
        /// Test que sirve para chequear el correcto funcionamiento de una creación de una instancia de Empresa.
        /// </summary>
        [Test]
        public void EmpresaTest()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            Empresa empresaTest = new Empresa("empresaTest", "La Blanqueada", "Textil");

            string expected = "empresaTest";
            string expected2 = "La Blanqueada";
            string expected3 = "Textil";

            Assert.AreEqual(expected, empresaTest.Nombre);
            Assert.AreEqual(expected2, empresaTest.Ubicacion.NombreCalle);
            Assert.AreEqual(expected3, empresaTest.Rubro.Nombre);
        }

        /// <summary>
        /// Test que sirve para chequear el correcto funcionamiento del método AddHabilitacion.
        /// </summary>
        [Test]
        public void TestAddHabilitaciones()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            Empresa empresaTest = new Empresa("empresaTest", "La Blanqueada", "Textil");
            int expected = 1;

            empresaTest.AddHabilitacion("APA");
            Assert.AreEqual(expected, empresaTest.HabilitacionesEmpresa.Count);
        }

        /// <summary>
        /// Test que sirve para chequear el correcto funcionamiento del método RemoveHabilitacion.
        /// </summary>
        [Test]
        public void TestQuitarHabilitaciones()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            Empresa empresaTest = new Empresa("empresaTest", "La Blanqueada", "Textil");

            int expected = 1;

            empresaTest.AddHabilitacion("APA");
            empresaTest.AddHabilitacion("SOA");
            empresaTest.RemoveHabilitacion("APA");
            Assert.AreEqual(expected, empresaTest.HabilitacionesEmpresa.Count);
        }

        /// <summary>
        /// Test que chequea que sucede si se agrega una habilitación que no existe a una empresa.
        /// </summary>
        [Test]
        public void TestAddHabilitacionesMal()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            Empresa empresaTest = new Empresa("empresaTest", "La Blanqueada", "Textil");

            int expected = 1;
            string respuesta = "";

            empresaTest.AddHabilitacion("APA");
            try
            {
                empresaTest.AddHabilitacion("DEUNA");
            }
            catch (System.ArgumentException e)
            {
                respuesta = e.Message;
            }

            string expected2 = "DEUNA no se encuentra disponible, use nuevamente /agregarhabilitacionempresa";
            Assert.AreEqual(expected, empresaTest.HabilitacionesEmpresa.Count);
            Assert.AreEqual(expected2, respuesta);
        }
        
        /// <summary>
        /// Test que chequea que sucede si se intenta remover una habilitación que no está en la lista
        /// a una empresa.
        /// </summary>
        [Test]
        public void TestQuitarHabilitacionesMal()
        {   
            Habilitaciones habilitacion = new Habilitaciones();
            Empresa empresaTest = new Empresa("empresaTest", "La Blanqueada", "Textil");

            int expected = 2;

            empresaTest.AddHabilitacion("SOA");
            empresaTest.AddHabilitacion("SOA");

            empresaTest.RemoveHabilitacion("APA");

            Assert.AreEqual(expected, empresaTest.HabilitacionesEmpresa.Count);
        }
    }
}