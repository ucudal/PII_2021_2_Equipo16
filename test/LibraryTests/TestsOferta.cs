using NUnit.Framework;
using ClassLibrary;

namespace Test.Library
{
    /// <summary>
    /// Esta clase permite realizar los tests de la clase Oferta.
    /// </summary>
    [TestFixture]
    public class TestsOferta
    {
        /// <summary>
        /// Test que evalúa lo sucedido al crear una instancia de tipo Oferta.
        /// </summary>
        [Test]
        public void TestCreacionOferta()
        {
            Rubro rubro = new Rubro("entretenimiento");
            Habilitaciones habilitacion = new Habilitaciones();
            Empresa aleatoria = new Empresa("Madafakin Coke", "Tres Cruces", rubro, habilitacion);
            Oferta oferta = new Oferta("Sillas de acero", "acero", 35, "kg", "acero, sillas, tres cruces", "Tres Cruces", aleatoria);

            string expected = "Sillas de acero";
            string expected2 = "acero";
            int expected3 = 35;
            string expected4 = "kg";
            string expected5 = "acero, sillas, tres cruces";
            string expected6 = "Tres Cruces";
            string expected7 = "Madafakin Coke";

            Assert.AreEqual(expected, oferta.Nombre);
            Assert.AreEqual(expected2, oferta.Material);
            Assert.AreEqual(expected3, oferta.Precio);
            Assert.AreEqual(expected4, oferta.Unidad);
            Assert.AreEqual(expected5, oferta.Tags);
            Assert.AreEqual(expected6, oferta.Ubicacion);
            Assert.AreEqual(expected7, oferta.EmpresaCreadora.Nombre);

        }

        /// <summary>
        /// Test que sirve para chequear que el método AddHabilitación funciona correctamente.
        /// </summary>
        [Test]
        public void TestAgregarHabilitaciones()
        {
            Rubro rubro = new Rubro("textil");
            Habilitaciones habilitacion = new Habilitaciones();
            Empresa aleatoria = new Empresa("Madafreakin Pepsi", "Buceo", rubro, habilitacion);
            Oferta oferta = new Oferta("Guantes de nylon", "nylon", 20, "g", "nylon, guantes, buceo", "Buceo", aleatoria);

            int expected = 1;
            oferta.AddHabilitacion("soa");
            Assert.AreEqual(expected, oferta.habilitacionesOferta.Count);
        }

        /// <summary>
        /// Test que chequea el correcto funcionamiento del método RemoveHabilitacion.
        /// </summary>
        [Test]
        public void TestRemoverHabilitaciones()
        {
            Rubro rubro = new Rubro("textil");
            Habilitaciones habilitacion = new Habilitaciones();
            Empresa aleatoria = new Empresa("Madafreakin Pepsi", "Buceo", rubro, habilitacion);
            Oferta oferta = new Oferta("Guantes de nylon", "nylon", 20, "g", "nylon, guantes, buceo", "Buceo", aleatoria);

            oferta.AddHabilitacion("soa");
            oferta.AddHabilitacion("apa");
            oferta.RemoveHabilitacion("apa");
            int expected = 1;
            
            Assert.AreEqual(expected, oferta.habilitacionesOferta.Count);

        }
    }
}