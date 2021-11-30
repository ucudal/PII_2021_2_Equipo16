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
            Empresa empresaTest23 = new Empresa("Conaprole2", "Pakistan", "Textil");
            Emprendedor emprendedorTest24 = new Emprendedor("Lebron James2", "Korea del Norte", "Textil", "Decorado de interiores", "email@prueba.com");
            Singleton<ContenedorPrincipal>.Instancia.Publicaciones.OfertasPublicados.Clear();
            LogicaEmpresa.CrearOferta(empresaTest23, "ArduinoUNO1", "Baquelita", "1", "100", "Cantidad", "Electronicos", "UCU", "Constante");
            LogicaEmpresa.CrearOferta(empresaTest23, "Coca-cola ZERO1", "Nix", "5", "2000", "Litros", "Bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearOferta(empresaTest23, "Fiat 11", "El mejor de todos", "10", "5500", "Cantidad", "auto", "Aguas verdes", "Constante");
            LogicaEmpresa.CrearOferta(empresaTest23, "Fiat 11 Pistero", "El mejor de todos", "10", "5500", "Cantidad", "auto", "Marruecos", "Constante");
            LogicaEmpresa.CrearOferta(empresaTest23, "Nissan1 Skyline GTR - R34", "El mejor de todos", "10", "5500", "Cantidad", "auto", "Aguas verdes", "Constante");

            // Quiero como empresa calcular la cantidad de ofertas entregadas segun x tiempo.
            LogicaEmpresa.AceptarOferta(empresaTest23, "Coca-cola ZERO1");
            LogicaEmpresa.AceptarOferta(empresaTest23, "ArduinoUNO1");

            int expectedCantidadVendidasSegunTiempo = 2;

            Assert.AreEqual(expectedCantidadVendidasSegunTiempo, LogicaEmpresa.CalcularOfertasVendidas(empresaTest23, "2020-10-15", "2028-10-15"));

            // Quiero como emprendedor calcular las ofertas que consumí segun x tiempo.
            LogicaEmprendedor.InteresadoEnOferta(emprendedorTest24, "Fiat 11 Pistero");
            LogicaEmprendedor.InteresadoEnOferta(emprendedorTest24, "Fiat 11");
            LogicaEmprendedor.InteresadoEnOferta(emprendedorTest24, "Nissan1 Skyline GTR - R34");

            int expectedCantidadConsumidaSegunTiempo = 3;

            Assert.AreEqual(expectedCantidadConsumidaSegunTiempo, LogicaEmprendedor.CalcularOfertasCompradas(emprendedorTest24, "2020-10-15", "2028-10-15"));            
        }
    }
}