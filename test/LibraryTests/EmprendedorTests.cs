namespace Test.Library
{
    using ClassLibrary;
    using NUnit.Framework;
    
    /// <summary>
    /// Esta clase permite realizar los tests de la clase Emprendedor.
    /// </summary>
    [TestFixture]
    public class EmprendedorTests
    {
        /// <summary>
        /// Test que sirve para chequear el correcto funcionamiento de una creación de una instancia de Emprendedor.
        /// </summary>
        [Test]
        public void TestRegistroEmprendedor()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            Emprendedor emprendedorTest = new Emprendedor("EmprendedorTest", "UbicacionTest", "RubroTest", "EspecializacionesTest");
            string expected = "EmprendedorTest";
            string expected2 = "UbicacionTest";
            string expected3 = "RubroTest";
            Habilitaciones expected4 = habilitacion;
            string expected5 = "EspecializacionesTest";


            Assert.AreEqual(expected, emprendedorTest.Nombre);
            Assert.AreEqual(expected2, emprendedorTest.Ubicacion);
            Assert.AreEqual(expected3, emprendedorTest.Rubro);
            Assert.AreEqual(expected4, emprendedorTest.HabilitacionesEmprendedor);
            Assert.AreEqual(expected5, emprendedorTest.Especializaciones);
        }

        /// <summary>
        /// Test que sirve para chequear el correcto funcionamiento del método AddHabilitacion.
        /// </summary>
        [Test]
        public void TestAddHabilitaciones()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            Emprendedor emprendedorTest = new Emprendedor("EmprendedorTest", "UbicacionTest", "RubroTest", "EspecializacionesTest");

            int expected = 1;
            
            emprendedorTest.AddHabilitacion("soa");
            Assert.AreEqual(expected, emprendedorTest.HabilitacionesEmprendedor.Count);
        }
        
        /// <summary>
        /// Test que sirve para chequear el correcto funcionamiento del método RemoveHabilitacion.
        /// </summary>
        [Test]
        public void TestQuitarHabilitaciones()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            Emprendedor juancho = new Emprendedor("EmprendedorTest", "UbicacionTest", "RubroTest", "EspecializacionesTest");

            int expected = 1;
            
            juancho.AddHabilitacion("soa");
            juancho.AddHabilitacion("soa");
            juancho.RemoveHabilitacion("soa");
            Assert.AreEqual(expected, juancho.HabilitacionesEmprendedor.Count);
        }
        /// <summary>
        /// Test que sirve para ver que sucede al intentar eliminar una habilitación que no existe.
        /// </summary>
        [Test]
        public void TestQuitarHabilitacionesMal()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            Emprendedor juancho = new Emprendedor("EmprendedorTest", "UbicacionTest", "RubroTest", "EspecializacionesTest");

            int expected = 2;
            
            juancho.AddHabilitacion("soa");
            juancho.AddHabilitacion("soa");
            juancho.RemoveHabilitacion("apa");
            Assert.AreEqual(expected, juancho.HabilitacionesEmprendedor.Count);
        }
        /// <summary>
        /// Test que sirve para ver el comportamiento del código al añadirle al emprendedor una habilitacion que no existe.
        /// </summary>
         [Test]
        public void TestAddHabilitacionesMal()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            Emprendedor juancho = new Emprendedor("EmprendedorTest", "UbicacionTest", "RubroTest", "EspecializacionesTest");

            int expected = 2;
            
            juancho.AddHabilitacion("soa");
            juancho.AddHabilitacion("soa");
            juancho.AddHabilitacion("hola");
            Assert.AreEqual(expected, juancho.HabilitacionesEmprendedor.Count);
        }
    }
}