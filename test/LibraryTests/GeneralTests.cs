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
            Empresa empresaConaprole = new Empresa("Conaprole", "Pakistan", "textil");
            Emprendedor emprendedor1 = new Emprendedor("Lebron James", "Korea del Norte", "textil", new Habilitaciones(), "Decorado de interiores");

            string expectedEmpresa = "Conaprole";
            string expectedEmprendedor = "Lebron James";

            // Quiero como empresa publicar varias oferta.
            LogicaEmpresa.CrearOferta(empresaConaprole, "Coca-cola", "Nix", "2000", "Litros", "bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearOferta(empresaConaprole, "Coca-cola ZERO", "Nix", "2000", "Litros", "bebidas", "Guyana Francesa", "Constante");
            LogicaEmpresa.CrearOferta(empresaConaprole, "Fiat 1", "El mejor de todos", "5500", "Cantidad", "auto", "Aguas verdes", "Constante");

            int expectedPublicaciones = 3; // Esperado numero de ofertas en lista.
            Assert.AreEqual(expectedPublicaciones, Logica.Publicaciones.OfertasPublicados.Count);

            // Quiero como emprendedor buscar bebidas.
            // Al buscar por tags, deberian aparecer 2 opciones.
            LogicaBuscadores.BuscarPorTags("bebidas");

            // Se espera que se impriman las 2 ofertas.
            // Quiero adquirir la oferta con nombre Coca-Cola ZERO.
            LogicaEmprendedor.InteresadoEnOferta(emprendedor1, "Coca-cola ZERO");

            // Quiero como empresa saber si se interesaron en alguna de mis ofertas.
            int expectedInteresados = 1;

            // Quiero como empresa aceptar una oferta(Lo que se hace cuando se llega a un acuerdo con algun comprador).
            LogicaEmpresa.AceptarOferta(empresaConaprole, "Fiat 1");

            int expectedPublicaciones1 = 2;
            int expectedAceptadas = 1;
  
            Assert.AreEqual(expectedEmpresa, empresaConaprole.Nombre);
            Assert.AreEqual(expectedEmprendedor, emprendedor1.Nombre);
            Assert.AreEqual(expectedInteresados, empresaConaprole.InteresadosEnOfertas.Count);
            Assert.AreEqual(expectedPublicaciones1, Logica.Publicaciones.OfertasPublicados.Count);
            Assert.AreEqual(expectedAceptadas, empresaConaprole.OfertasAceptadas.Count);
        }    
    }
}