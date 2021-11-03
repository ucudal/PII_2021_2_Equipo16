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

            LogicaEmpresa.CrearProducto(empresaConaprole, "Coca-cola", "Líquido", 2000, "Litros", "bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearProducto(empresaConaprole, "Coca-cola ZERO", "Líquido", 2000, "Litros", "bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearProducto(empresaConaprole, "Fiat 1", "El mejor de todos", 5500, "Cantidad", "coche", "Carrasco", "Constante");
            LogicaEmpresa.CrearProducto(empresaConaprole, "Coca-cola2", "Líquido", 2000, "Litros", "bebidas", "Nigeria", "Constante");
            LogicaEmpresa.CrearProducto(empresaConaprole, "Coca-cola ZERO2", "Líquido", 2000, "Litros", "bebidas", "Nigeria", "Constante");
            LogicaEmpresa.CrearProducto(empresaConaprole, "Fiat 12", "El mejor de todos", 5500, "Cantidad", "coche", "Carrasco", "Constante");

            // Quiero buscar por ubicacion, tag, material

            //LogicaBuscadores.BuscarPorUbicacion("Carrasco");
            int expectedUbi = 2;
            //LogicaBuscadores.BuscarPorTags("auto");
            int expectedTag = 2;
            //LogicaBuscadores.BuscarPorMaterial("Nix");
            int expectedMat = 4;

            Assert.AreEqual(expectedUbi, LogicaBuscadores.BuscarPorUbicacion("Nigeria").Count);
            Assert.AreEqual(expectedTag, LogicaBuscadores.BuscarPorTags("coche").Count);
            Assert.AreEqual(expectedMat, LogicaBuscadores.BuscarPorMaterial("Líquido").Count);
        }
    }
}