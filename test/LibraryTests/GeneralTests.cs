namespace Test.Library
{ 
    using ClassLibrary;
    using NUnit.Framework;
    
    /// <summary>
    /// Clase de pruebas de TestGeneral.
    /// </summary>
    [TestFixture]
    public class GeneralTests
    {
        /// <summary>
        /// Test de historia de usuario.
        /// Se crean 1 empresa y 1 emprendedor, la empresa publica 3 ofertas, se hace una busqueda por tags en esas publicaciones el emprendedor se interesa en una oferta y por último la empresa acepta una oferta.
        /// </summary>
        [Test]
        public void TestGeneral1()
        {
            Empresa empresaTest = new Empresa("Conaprole", "Pakistan", "textil");
            Emprendedor emprendedorTest = new Emprendedor("Lebron James", "Korea del Norte", "textil", "Decorado de interiores", "email@prueba.com");

            string expectedEmpresa = "Conaprole";
            string expectedEmprendedor = "Lebron James";

            // Quiero como empresa publicar varias oferta.
            LogicaEmpresa.CrearOferta(empresaTest, "ArduinoUNO", "Baquelita", "1", "100", "Cantidad", "Electronicos", "UCU", "Constante");
            LogicaEmpresa.CrearOferta(empresaTest, "Coca-cola ZERO", "Nix", "5", "2000", "Litros", "Bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearOferta(empresaTest, "Fiat 1", "El mejor de todos", "10", "5500", "Cantidad", "auto", "Aguas verdes", "Constante");

            int expectedPublicaciones = 3; // Esperado numero de ofertas en lista.
            Assert.AreEqual(expectedPublicaciones, Singleton<ContenedorPrincipal>.Instancia.Publicaciones.OfertasPublicados.Count);

            // Quiero como emprendedor buscar bebidas.
            // Al buscar por tags, deberian aparecer 2 opciones.
            LogicaBuscadores.BuscarPorTags("bebidas");

            // Se espera que se impriman las 2 ofertas.
            // Quiero adquirir la oferta con nombre Coca-Cola ZERO.
            LogicaEmprendedor.InteresadoEnOferta(emprendedorTest, "Coca-cola ZERO");

            // Quiero como empresa saber si se interesaron en alguna de mis ofertas.
            int expectedInteresados = 1;

            // Quiero como empresa aceptar una oferta(Lo que se hace cuando se llega a un acuerdo con algun comprador).
            LogicaEmpresa.AceptarOferta(empresaTest, "Fiat 1");

            int expectedPublicaciones1 = 2;
            int expectedAceptadas = 1;
  
            Assert.AreEqual(expectedEmpresa, empresaTest.Nombre);
            Assert.AreEqual(expectedEmprendedor, emprendedorTest.Nombre);
            Assert.AreEqual(expectedInteresados, empresaTest.InteresadosEnOfertas.Count);
            Assert.AreEqual(expectedPublicaciones1, Singleton<ContenedorPrincipal>.Instancia.Publicaciones.OfertasPublicados.Count);
            Assert.AreEqual(expectedAceptadas, empresaTest.OfertasAceptadas.Count);
        }    
    }
}