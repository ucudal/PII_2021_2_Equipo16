using ClassLibrary;
using NUnit.Framework;

namespace Test.Library
{
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
            Rubro rubro = new Rubro("entretenimiento");
            Habilitaciones habilitacion = new Habilitaciones();
            Emprendedor Juancho = new Emprendedor("Juan Pérez", "Barrio Sur", rubro, habilitacion, "Lavado de Autos Express");
            string expected = "Juan Pérez";
            string expected2 = "Barrio Sur";
            string expected3 = "entretenimiento";
            Habilitaciones expected4 = habilitacion;
            string expected5 = "Lavado de Autos Express";

            Assert.AreEqual(expected, Juancho.Nombre);
            Assert.AreEqual(expected2, Juancho.Ubicacion );
            Assert.AreEqual(expected3, Juancho.Rubro.Nombre);
            Assert.AreEqual(expected4, Juancho.Habilitacion);
            Assert.AreEqual(expected5, Juancho.Especializaciones);
        }

        /// <summary>
        /// Test que sirve para chequear el correcto funcionamiento del método AddHabilitacion.
        /// </summary>
        [Test]
        public void TestAddHabilitaciones()
        {
            Rubro rubro = new Rubro("entretenimiento");
            Habilitaciones habilitacion = new Habilitaciones();
            Emprendedor Juancho = new Emprendedor("Juan Pérez", "Barrio Sur", rubro, habilitacion, "Lavado de Autos Express");

            int expected = 1;
            
            Juancho.AddHabilitacion("soa");
            Assert.AreEqual(expected, Juancho.HabilitacionesEmprendedor.Count);
        }
        
        /// <summary>
        /// Test que sirve para chequear el correcto funcionamiento del método RemoveHabilitacion.
        /// </summary>
        [Test]
        public void TestQuitarHabilitaciones()
        {
            Rubro rubro = new Rubro("entretenimiento");
            Habilitaciones habilitacion = new Habilitaciones();
            Emprendedor Juancho = new Emprendedor("Juan Pérez", "Barrio Sur", rubro, habilitacion, "Lavado de Autos Express");

            int expected = 1;
            
            Juancho.AddHabilitacion("soa");
            Juancho.AddHabilitacion("soa");
            Juancho.RemoveHabilitacion("soa");
            Assert.AreEqual(expected, Juancho.HabilitacionesEmprendedor.Count);
        }
    }
}