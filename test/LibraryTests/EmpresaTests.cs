using ClassLibrary;
using NUnit.Framework;


namespace Test.Library
{
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
            Rubro rubro = new Rubro("entretenimiento");
            Habilitaciones habilitacion = new Habilitaciones();
            Empresa empresaTest = new Empresa("empresaTest", "La Blanqueada", rubro, habilitacion);

            string expected = "empresaTest";
            string expected2 = "La Blanqueada";
            string expected3 = "entretenimiento";
            Habilitaciones expected4 = habilitacion;
 
            Assert.AreEqual(expected, empresaTest.Nombre);
            Assert.AreEqual(expected2, empresaTest.Ubicacion );
            Assert.AreEqual(expected3, empresaTest.Rubro.Nombre);
            Assert.AreEqual(expected4, empresaTest.Habilitacion);
        }

        /// <summary>
        /// Test que sirve para chequear el correcto funcionamiento del método AddHabilitacion.
        /// </summary>
        [Test]
        public void TestAddHabilitaciones()
        {
            Rubro rubro = new Rubro("entretenimiento");
            Habilitaciones habilitacion = new Habilitaciones();
            Empresa empresaTest = new Empresa("empresaTest", "La Blanqueada", rubro, habilitacion);

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
            Rubro rubro = new Rubro("entretenimiento");
            Habilitaciones habilitacion = new Habilitaciones();
            Empresa empresaTest = new Empresa("empresaTest", "La Blanqueada", rubro, habilitacion);
    
            int expected = 1;
            
            empresaTest.AddHabilitacion("apa");
            empresaTest.AddHabilitacion("soa");
            empresaTest.RemoveHabilitacion("apa");
            Assert.AreEqual(expected, empresaTest.HabilitacionesEmpresa.Count);
        }
    }
}