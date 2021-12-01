namespace Test.Library
{
    using ClassLibrary;
    using NUnit.Framework;

    /// <summary>
    /// Esta clase permite realizar los test de la clase Habilitaciones.
    /// Los métodos de la clase Habilitaciones son testeados uno por uno.
    /// </summary>
    [TestFixture]
    public class HabilitacionesTests
    {
        /// <summary>
        /// Este método permite evaluar lo que sucede cuando se crea una habilitación con nombre.
        /// </summary>
        [Test]
        public void TestHabilitacion()
        {
            Habilitaciones habilitacion = new Habilitaciones("test");

            string expected = "test";
            Assert.AreEqual(expected, habilitacion.Nombre);
        }
    }
}