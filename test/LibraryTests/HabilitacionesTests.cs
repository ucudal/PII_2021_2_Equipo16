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
        /// Este método permite evaluar lo que sucede cuando se ingresa un nombre de habilitacion que esta en la lista de habilitaciones.
        /// </summary>
        [Test]
        public void TestHabilitacion()
        {
            Habilitaciones habilitacion = new Habilitaciones("test");
            
            string expected = "test";
            Assert.AreEqual(expected, habilitacion.Nombre);
        }

        /// <summary>
        /// Este metodo permite evaluar lo que sucede cuando el nombre de la habilitacion no esta en la lista de habilitaciones.
        /// </summary>
        [Test]
        public void TestHabilitacion2()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            
            string expected = null;
            Assert.AreEqual(expected, habilitacion.Nombre);
        }
    }
}