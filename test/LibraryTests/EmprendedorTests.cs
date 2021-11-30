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
            Emprendedor emprendedorTest = new Emprendedor("EmprendedorTest", "pakistan", "textil", "EspecializacionesTest","email@prueba.com");
            string expected = "EmprendedorTest";
            string expected2 = "pakistan";
            string expected3 = "textil";
            string expected5 = "EspecializacionesTest";

            Assert.AreEqual(expected, emprendedorTest.Nombre);
            Assert.AreEqual(expected2, emprendedorTest.Ubicacion.NombreCalle);
            Assert.AreEqual(expected3, emprendedorTest.Rubro.Nombre);
            Assert.AreEqual(expected5, emprendedorTest.Especializaciones);
            Assert.That("email@prueba.com", Is.EqualTo(emprendedorTest.Email));
        }
        /// <summary>
        /// Test que sirve para chequear el correcto funcionamiento del método AddHabilitacion.
        /// </summary>
        [Test]
        public void TestAddHabilitaciones()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            Emprendedor emprendedorTest = new Emprendedor("EmprendedorTest", "UbicacionTest", "textil", "EspecializacionesTest","email@prueba.com");

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
            Emprendedor juancho = new Emprendedor("EmprendedorTest", "UbicacionTest", "textil", "EspecializacionesTest","email@prueba.com");

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
            Emprendedor juancho = new Emprendedor("EmprendedorTest", "UbicacionTest", "textil", "EspecializacionesTest","email@prueba.com");

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
            string respuesta = "";
            Habilitaciones habilitacion = new Habilitaciones();
            Emprendedor juancho = new Emprendedor("EmprendedorTest", "UbicacionTest", "textil", "EspecializacionesTest","email@prueba.com");

            int expected = 2;
            
            juancho.AddHabilitacion("soa");
            juancho.AddHabilitacion("soa");
            try
            {
                juancho.AddHabilitacion("hola");
            } 
            catch (System.ArgumentException e)
            {
                respuesta = e.Message;
            }
            string expected2 = "hola no se encuentra disponible, use nuevamente /agregarhabilitacionemprendedor";
            Assert.AreEqual(expected, juancho.HabilitacionesEmprendedor.Count);
            Assert.AreEqual(expected2, respuesta);
        }
    }
}