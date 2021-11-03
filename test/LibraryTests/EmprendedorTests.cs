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
            Emprendedor juancho = new Emprendedor("Juan Pérez", "Barrio Sur", "textil", habilitacion, "Lavado de Autos Express");
            string expected = "Juan Pérez";
            string expected2 = "Barrio Sur";
            string expected3 = "textil";
            Habilitaciones expected4 = habilitacion;
            string expected5 = "Lavado de Autos Express";

            Assert.AreEqual(expected, juancho.Nombre);
            Assert.AreEqual(expected2, juancho.Ubicacion);
            Assert.AreEqual(expected3, juancho.Rubro);
            Assert.AreEqual(expected4, juancho.Habilitacion);
            Assert.AreEqual(expected5, juancho.Especializaciones);
        }

        /// <summary>
        /// Test que sirve para chequear el correcto funcionamiento del método AddHabilitacion.
        /// </summary>
        [Test]
        public void TestAddHabilitaciones()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            Emprendedor juancho = new Emprendedor("Juan Pérez", "Barrio Sur", "textil", habilitacion, "Lavado de Autos Express");

            int expected = 1;
            
            juancho.AddHabilitacion("soa");
            Assert.AreEqual(expected, juancho.HabilitacionesEmprendedor.Count);
        }
        
        /// <summary>
        /// Test que sirve para chequear el correcto funcionamiento del método RemoveHabilitacion.
        /// </summary>
        [Test]
        public void TestQuitarHabilitaciones()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            Emprendedor juancho = new Emprendedor("Juan Pérez", "Barrio Sur", "textil", habilitacion, "Lavado de Autos Express");

            int expected = 1;
            
            juancho.AddHabilitacion("soa");
            juancho.AddHabilitacion("soa");
            juancho.RemoveHabilitacion("soa");
            Assert.AreEqual(expected, juancho.HabilitacionesEmprendedor.Count);
        }
    }
}