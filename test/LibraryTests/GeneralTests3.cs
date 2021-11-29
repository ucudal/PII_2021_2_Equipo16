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
            Empresa empresaTest = new Empresa("Conaprole", "Pakistan", "textil");
            LogicaEmpresa.CrearOferta(empresaTest, "ArduinoUNO", "Baquelita", "1", "100", "Cantidad", "Electronicos", "Nigeria", "Constante");
            LogicaEmpresa.CrearOferta(empresaTest, "Coca-cola ZERO", "Nix", "5", "2000", "Litros", "Bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearOferta(empresaTest, "Fiat 1", "El mejor de todos", "10", "5500", "Cantidad", "moto", "Aguas verdes", "Constante");
            LogicaEmpresa.CrearOferta(empresaTest, "Hondita50", "El mejor de todos", "10", "5500", "Cantidad", "auto", "Aguas verdes", "Constante");

            // Quiero buscar por ubicacion, tag, material
            
            int expectedUbi = 1;
            
            int expectedTag = 1;
            
            int expectedMat = 2;

            Assert.AreEqual(expectedUbi, LogicaBuscadores.BuscarPorUbicacion("Nigeria").Count);
            Assert.AreEqual(expectedTag, LogicaBuscadores.BuscarPorTags("auto").Count);
            Assert.AreEqual(expectedMat, LogicaBuscadores.BuscarPorMaterial("El mejor de todos").Count);
        }
    }
}