namespace Test.Library
{
    using ClassLibrary;
    using NUnit.Framework;

    /// <summary>
    /// Clase de pruebas de TestGeneral.
    /// </summary>
    [TestFixture]
    public class GeneralTests3
    {
        /// <summary>
        /// Tenemos una empresa que crea sus ofertas para poder despues realizar una busqueda por ubicación, tag, material.
        /// </summary>
        [Test]
        public void TestGeneral3()
        {
            Empresa empresaTest3 = new Empresa("Conaprole4", "Pakistan", "Textil");
            Singleton<ContenedorPrincipal>.Instancia.Publicaciones.OfertasPublicados.Clear();
            LogicaEmpresa.CrearOferta(empresaTest3, "ArduinoUNO2", "Baquelita", "1", "100", "Cantidad", "Electronicos", "Nigeria", "Constante");
            LogicaEmpresa.CrearOferta(empresaTest3, "Coca-cola ZERO2", "Nix", "5", "2000", "Litros", "Bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearOferta(empresaTest3, "Fiat 12", "El mejor de todos", "10", "5500", "Cantidad", "moto", "Aguas verdes", "Constante");
            LogicaEmpresa.CrearOferta(empresaTest3, "Hondita502", "El mejor de todos", "10", "5500", "Cantidad", "auto", "Aguas verdes", "Constante");

            int expectedUbi = 1;

            int expectedTag = 1;

            int expectedMat = 2;

            Assert.AreEqual(expectedUbi, LogicaBuscadores.BuscarPorUbicacion("Nigeria").Count);
            Assert.AreEqual(expectedTag, LogicaBuscadores.BuscarPorTags("auto").Count);
            Assert.AreEqual(expectedMat, LogicaBuscadores.BuscarPorMaterial("El mejor de todos").Count);
        }
    }
}