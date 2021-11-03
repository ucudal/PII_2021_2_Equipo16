using ClassLibrary;
using NUnit.Framework;

namespace Test.Library
{
    /// <summary>
    /// Esta clase contiene un Test para verificar que Publicaciones funcione correctamente.
    /// </summary>
    [TestFixture]
    public class PublicacionesTest
    {
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void TestPublicaciones()
        {
            Empresa empresaTest = new Empresa("empresaTest", "x", new Rubro("Textil"), new Habilitaciones());
            Oferta oferta = new Oferta("Queso", "colonia", 100, "gr", "queso, colonia", "Colonia", empresaTest);
        }
    }
}