namespace Test.Library
{
    using ClassLibrary;
    using NUnit.Framework;
    
    /// <summary>
    /// Esta clase permite realizar los tests de la clase Oferta.
    /// </summary>
    [TestFixture]
    public class OfertaTests
    {
        /// <summary>
        /// Test que evalúa lo sucedido al crear una instancia de tipo Oferta.
        /// </summary>
        [Test]
        public void TestCreacionOferta()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            Empresa empresaTest = new Empresa("Madafakin Coke", "Tres Cruces", "textil");
            Oferta oferta = new Oferta("ofertaTest", "elmejor", "1", "5000", "kg", "test", "UCU", "Constante", empresaTest);

            string expected = "ofertaTest";
            string expected2 = "elmejor";
            string expected3 = "1";
            string expected4 = "5000";
            string expected5 = "kg";
            string expected6 = "test";
            string expected7 = "UCU";
            string expected8 = "Constante";
            string expected9 = "Madafakin Coke";

            Assert.AreEqual(expected, oferta.Nombre);
            Assert.AreEqual(expected2, oferta.Material.Tipo);
            Assert.AreEqual(expected3, oferta.Material.Cantidad);
            Assert.AreEqual(expected4, oferta.Material.Precio);
            Assert.AreEqual(expected5, oferta.Material.Unidad);
            Assert.AreEqual(expected6, oferta.Tags);
            Assert.AreEqual(expected7, oferta.Ubicacion.NombreCalle);
            Assert.AreEqual(expected8, oferta.ConstantesPuntuales);
            Assert.AreEqual(expected9, oferta.EmpresaCreadora.Nombre);
        }

        /// <summary>
        /// Test que sirve para chequear que el método AddHabilitación funciona correctamente.
        /// </summary>
        [Test]
        public void TestAgregarHabilitaciones()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            Empresa empresaTest = new Empresa("Madafreakin Pepsi", "Buceo", "textil");
            Oferta oferta = new Oferta("ofertaTest", "elmejor", "1", "5000", "Cantidad", "test", "UCU", "Constante", empresaTest);

            //int expected = 1;
            oferta.AddHabilitacion("soa");
            //Assert.AreEqual(expected, oferta.HabilitacionesOferta.Count);
        }

        /// <summary>
        /// Test que chequea el correcto funcionamiento del método RemoveHabilitacion.
        /// </summary>
        [Test]
        public void TestRemoverHabilitaciones()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            Empresa empresaTest = new Empresa("Madafreakin Pepsi", "Buceo", "textil");
            Oferta oferta = new Oferta("ofertaTest", "elmejor", "1", "5000", "Cantidad", "test", "UCU", "Constante", empresaTest);

            oferta.AddHabilitacion("soa");
            oferta.AddHabilitacion("apa");
            oferta.RemoveHabilitacion("apa");
            //int expected = 1;
            
            //Assert.AreEqual(expected, oferta.HabilitacionesOferta.Count);
        }
        /// <summary>
        /// Test que sirve para ver el comportamiento del código al añadirle a una oferta una habilitación que no existe.
        /// </summary>
        [Test]
        public void TestAgregarHabilitacionesMal()
        {
            string respuesta = "";
            Habilitaciones habilitacion = new Habilitaciones();
            Empresa empresaTest = new Empresa("Madafreakin Pepsi", "Buceo", "textil");
            Oferta oferta = new Oferta("ofertaTest", "elmejor", "1", "5000", "Cantidad", "test", "UCU", "Constante", empresaTest);

            int expected = 1;
            string expected2 = "deuna no se encuentra disponible, use nuevamente /crearhaboferta";
            oferta.AddHabilitacion("soa");
            try
            {
                oferta.AddHabilitacion("deuna");
            }
            catch(System.ArgumentException e)
            {
                respuesta = e.Message;
            }
            Assert.AreEqual(expected, oferta.HabilitacionesOferta.Count);
            Assert.AreEqual(expected2, respuesta);
        }
        /// <summary>
        /// Test que sirve para ver el comportamiento del código al intentar eliminar una habilitación
        /// que no existe a una oferta.
        /// </summary>
        [Test]
        public void TestRemoverHabilitacionesMal()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            Empresa empresaTest = new Empresa("Madafreakin Pepsi", "Buceo", "textil");
            Oferta oferta = new Oferta("ofertaTest", "elmejor", "1", "5000", "Cantidad", "test", "UCU", "Constante", empresaTest);

            oferta.AddHabilitacion("soa");
            oferta.AddHabilitacion("apa");
            oferta.RemoveHabilitacion("deuna");
            //int expected = 2;
            
            //Assert.AreEqual(expected, oferta.HabilitacionesOferta.Count);
        }
    }
}