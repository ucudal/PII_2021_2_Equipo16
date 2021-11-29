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
            Empresa empresaTest = new Empresa("Conaprole", "Pakistan", "textil");
            Emprendedor emprendedorTest = new Emprendedor("Lebron James", "Korea del Norte", "textil", "Decorado de interiores");

            LogicaEmpresa.CrearOferta(empresaTest, "ArduinoUNO", "Baquelita", "1", "100", "Cantidad", "Electronicos", "UCU", "Constante");
            LogicaEmpresa.CrearOferta(empresaTest, "Coca-cola ZERO", "Nix", "5", "2000", "Litros", "Bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearOferta(empresaTest, "Fiat 1", "El mejor de todos", "10", "5500", "Cantidad", "auto", "Aguas verdes", "Constante");
            LogicaEmpresa.CrearOferta(empresaTest, "Fiat 1 Pistero", "El mejor de todos", "10", "5500", "Cantidad", "auto", "Marruecos", "Constante");
            LogicaEmpresa.CrearOferta(empresaTest, "Nissan Skyline GTR - R34", "El mejor de todos", "10", "5500", "Cantidad", "auto", "Aguas verdes", "Constante");

            // Quiero como empresa calcular la cantidad de ofertas entregadas segun x tiempo.
            LogicaEmpresa.AceptarOferta(empresaTest, "Coca-cola ZERO");
            LogicaEmpresa.AceptarOferta(empresaTest, "ArduinoUNO");

            int expectedCantidadVendidasSegunTiempo = 2;

            Assert.AreEqual(expectedCantidadVendidasSegunTiempo, LogicaEmpresa.CalcularOfertasVendidas(empresaTest, "2020-10-15", "2028-10-15"));

            // Quiero como emprendedor calcular las ofertas que consumí segun x tiempo.
            LogicaEmprendedor.InteresadoEnOferta(emprendedorTest, "Fiat 1 Pistero");
            LogicaEmprendedor.InteresadoEnOferta(emprendedorTest, "Fiat 1");
            LogicaEmprendedor.InteresadoEnOferta(emprendedorTest, "Nissan Skyline GTR - R34");

            int expectedCantidadConsumidaSegunTiempo = 3;

            Assert.AreEqual(expectedCantidadConsumidaSegunTiempo, LogicaEmprendedor.CalcularOfertasCompradas(emprendedorTest, "2020-10-15", "2028-10-15"));            
        }
    }
}