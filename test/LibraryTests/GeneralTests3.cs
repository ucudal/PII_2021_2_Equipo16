using ClassLibrary;
using NUnit.Framework;

namespace Test.Library
{ 
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
            Empresa  empresaConaprole = new Empresa("Conaprole", "Pakistan", new Rubro("textil"), new Habilitaciones());

            LogicaEmpresa.CrearProducto(empresaConaprole, "Coca-cola", "Nix", 2000, "Litros", "bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearProducto(empresaConaprole, "Coca-cola ZERO", "Nix", 2000, "Litros", "bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearProducto(empresaConaprole, "Fiat 1", "El mejor de todos", 5500, "Cantidad", "auto", "Carrasco", "Constante");
            LogicaEmpresa.CrearProducto(empresaConaprole, "Coca-cola2", "Nix", 2000, "Litros", "bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearProducto(empresaConaprole, "Coca-cola ZERO2", "Nix", 2000, "Litros", "bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearProducto(empresaConaprole, "Fiat 12", "El mejor de todos", 5500, "Cantidad", "auto", "Carrasco", "Constante");

            // Quiero buscar por ubicacion, tag, material

            //LogicaBuscadores.BuscarPorUbicacion("Carrasco");
            int expectedUbi = 2;
            //LogicaBuscadores.BuscarPorTags("auto");
            int expectedTag = 2;
            //LogicaBuscadores.BuscarPorMaterial("Nix");
            int expectedMat = 4;

            Assert.AreEqual(expectedUbi, LogicaBuscadores.BuscarPorUbicacion("Carrasco").Count);
            Assert.AreEqual(expectedTag, LogicaBuscadores.BuscarPorTags("auto").Count);
            Assert.AreEqual(expectedMat, LogicaBuscadores.BuscarPorMaterial("Nix").Count);
        }
    }
}