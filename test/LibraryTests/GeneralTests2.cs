namespace Test.Library
{ 
    using ClassLibrary;
    using NUnit.Framework;
    
    /// <summary>
    /// Clase de pruebas de TestGeneral.
    /// </summary>
    [TestFixture]
    public class GeneralTests2
    {
        /// <summary>
        /// Test historia de usuario2
        /// Tenemos una empresa y un emprendedor, la empresa crea productos, y se quiere comprobar
        /// si el método para calcular ofertas entregadas/consumidas segun tiempo funcionan acorde a lo estipulado.
        /// </summary>
        [Test]
        public void TestGeneral2()
        {
            Empresa empresaConaprole = new Empresa("Conaprole", "Pakistan", "textil", new Habilitaciones());
            Emprendedor emprendedor1 = new Emprendedor("Lebron James", "Korea del Norte", "textil", new Habilitaciones(), "Decorado de interiores");

            LogicaEmpresa.CrearOferta(empresaConaprole, "Coca-colaA", "Nix", 2000, "Litros", "bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearOferta(empresaConaprole, "Coca-cola ZERO", "Nix", 2000, "Litros", "bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearOferta(empresaConaprole, "Fiat 1A", "El mejor de todos", 5500, "Cantidad", "auto", "Carrasco", "Constante");
            LogicaEmpresa.CrearOferta(empresaConaprole, "Coca-cola2A", "Nix", 2000, "Litros", "bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearOferta(empresaConaprole, "Coca-cola ZERO2A", "Nix", 2000, "Litros", "bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearOferta(empresaConaprole, "Fiat 12A", "El mejor de todos", 5500, "Cantidad", "auto", "Aguas verdes", "Constante");

            // Quiero como empresa calcular las ofertas entregadas segun x tiempo.
            LogicaEmpresa.AceptarOferta(empresaConaprole, "Fiat 1A");
            LogicaEmpresa.AceptarOferta(empresaConaprole, "Coca-colaA");

            int expectedCantidadVendidasSegunTiempo = 2;

            Assert.AreEqual(expectedCantidadVendidasSegunTiempo, LogicaEmpresa.CalcularOfertasVendidas(empresaConaprole, "2020-10-15", "2028-10-15"));

            // Quiero como emprendedor calcular las ofertas que consumí segun x tiempo.
            LogicaEmprendedor.InteresadoEnOferta(emprendedor1, "Fiat 12A");
            LogicaEmprendedor.InteresadoEnOferta(emprendedor1, "Coca-cola2A");
            LogicaEmprendedor.InteresadoEnOferta(emprendedor1, "Coca-cola ZERO2A");

            int expectedCantidadConsumidaSegunTiempo = 3;

            Assert.AreEqual(expectedCantidadConsumidaSegunTiempo, LogicaEmprendedor.CalcularOfertasCompradas(emprendedor1, "2020-10-15", "2028-10-15"));            
        }
    }
}