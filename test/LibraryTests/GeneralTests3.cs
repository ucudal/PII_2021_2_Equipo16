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
            Empresa empresaConaprole = new Empresa("Conaprole", "Pakistan", "textil", new Habilitaciones());
            LogicaEmpresa.CrearOferta(empresaConaprole, "Coca-colaAAA", "Líquido", 2000, "Litros", "bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearOferta(empresaConaprole, "Coca-cola ZEROAAA", "Líquido", 2000, "Litros", "bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearOferta(empresaConaprole, "Fiat 1AAA", "El mejor de todos", 5500, "Cantidad", "coche", "Carrasco", "Constante");
            LogicaEmpresa.CrearOferta(empresaConaprole, "Coca-cola2AAA", "Líquido", 2000, "Litros", "bebidas", "Nigeria", "Constante");
            LogicaEmpresa.CrearOferta(empresaConaprole, "Coca-cola ZERO2AAA", "Líquido", 2000, "Litros", "bebidas", "Nigeria", "Constante");
            LogicaEmpresa.CrearOferta(empresaConaprole, "Fiat 12AAA", "El mejor de todos", 5500, "Cantidad", "coche", "Carrasco", "Constante");

            // Quiero buscar por ubicacion, tag, material
            
            int expectedUbi = 2;
            
            int expectedTag = 2;
            
            int expectedMat = 4;

            Assert.AreEqual(expectedUbi, LogicaBuscadores.BuscarPorUbicacion("Nigeria").Count);
            Assert.AreEqual(expectedTag, LogicaBuscadores.BuscarPorTags("coche").Count);
            Assert.AreEqual(expectedMat, LogicaBuscadores.BuscarPorMaterial("Líquido").Count);
        }
    }
}