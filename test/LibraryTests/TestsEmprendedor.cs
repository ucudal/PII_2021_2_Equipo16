using NUnit.Framework;
using ClassLibrary;

namespace Test.Library
{
    /// <summary>
    /// Esta clase permite realizar los tests de la clase Emprendedor.
    /// </summary>
    [TestFixture]
    public class TestsEmprendedor
    {
        /// <summary>
        /// Test que sirve para chequear el correcto funcionamiento de una creación de una instancia de Emprendedor.
        /// </summary>
        [Test]
        public void TestRegistroEmprendedor()
        {
            Rubro rubro = new Rubro("entretenimiento");
            Habilitaciones habilitacion = new Habilitaciones("Apa");
            Emprendedor Juancho = new Emprendedor("Juan Pérez", "Barrio Sur", rubro, habilitacion, "Lavado de Autos Express");

            string expected = "Juan Pérez";
            string expected2 = "Barrio Sur";
            string expected3 = "entretenimiento";
            Habilitaciones expected4 = habilitacion;
            string expected5 = "Lavados de Autos Express";

            
            Assert.AreEqual(expected, Juancho.Nombre);
            Assert.AreEqual(expected2, Juancho.Ubicacion );
            Assert.AreEqual(expected3, Juancho.Rubro.Nombre);
            Assert.AreEqual(expected4, Juancho.Habilitacion);
            Assert.AreEqual(expected5, Juancho.Especializaciones);
        }
    }
}