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
            Empresa empresaTest = new Empresa("empresaTest", "La Blanqueada", "textil", habilitacion);

            string expected = "empresaTest";
            string expected2 = "La Blanqueada";
            string expected3 = "textil";
            Habilitaciones expected4 = habilitacion;
 
            Assert.AreEqual(expected, empresaTest.Nombre);
            Assert.AreEqual(expected2, empresaTest.Ubicacion);
            Assert.AreEqual(expected3, empresaTest.Rubro);
            Assert.AreEqual(expected4, empresaTest.Habilitacion);
        }

        /// <summary>
        /// Test que sirve para chequear el correcto funcionamiento del método AddHabilitacion.
        /// </summary>
        [Test]
        public void TestAddHabilitaciones()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            Empresa empresaTest = new Empresa("empresaTest", "La Blanqueada", "textil", habilitacion);

            int expected = 1;
            
            empresaTest.AddHabilitacion("apa");
            Assert.AreEqual(expected, empresaTest.HabilitacionesEmpresa.Count);
        }
        
        /// <summary>
        /// Test que sirve para chequear el correcto funcionamiento del método RemoveHabilitacion.
        /// </summary>
        [Test]
        public void TestQuitarHabilitaciones()
        {   
            Habilitaciones habilitacion = new Habilitaciones();
            Empresa empresaTest = new Empresa("empresaTest", "La Blanqueada", "textil", habilitacion);
    
            int expected = 1;
            
            empresaTest.AddHabilitacion("apa");
            empresaTest.AddHabilitacion("soa");
            empresaTest.RemoveHabilitacion("apa");
            Assert.AreEqual(expected, empresaTest.HabilitacionesEmpresa.Count);
        }
    }
}