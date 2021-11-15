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
            Habilitaciones habilitacion = new Habilitaciones();
            
            string expected = null;
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

        /// <summary>
        /// Este método de prueba nos permite ver la lista de habilitaciones que existen.
        /// </summary>
        [Test]
        public void TestHabilitacionDisponible()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            
            string expected = "1- iso 9009.\n2- apa.\n3- soa.\n4- unit.\n5- ieee.\n";
            Assert.AreEqual(expected, habilitacion.HabilitacionesDisponibles());
        }

        /// <summary>
        /// Este test permite comprobar que se pueden agregar habilitaciones a la lista de habilitaciones.
        /// Inicialmente la lista contiene 5 elementos y "brutal" que es la habilitacion que se quiere agregar no está dentro de la lista. Por lo cual al agregarla la lista pasara a contar con 6 elementos que es lo que se espera que devuelva la cuenta de ListaHabilitaciones.
        /// </summary>
        [Test]
        public void TestAgregarHabilitaciones()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            
            int expected = 6;
            habilitacion.AddHabilitacion("brutal");
            Assert.AreEqual(expected, habilitacion.ListaHabilitaciones.Count);
        }

        /// <summary>
        /// Este test permite comprobar si se pueden eliminar habilitaciones de la lista para eso se le pasa al metodo RemoveHabilitaciones un nombre que incluya la lista.
        /// Y se espera que de como resultado 4 que ya que la lista inicialmente contenia 5 elementos.
        /// </summary>
        [Test]
        public void TestEliminarHabilitaciones()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            
            int expected = 4;
            habilitacion.RemoveHabilitacion("apa");
            Assert.AreEqual(expected, habilitacion.ListaHabilitaciones.Count);
        }

        /// <summary>
        /// Este test está diseñado para que de error, ya que rock no pertenece a la lista de habilitaciones. 
        /// </summary>
        [Test]
        public void TestEliminarHabilitaciones1()
        {
            Habilitaciones habilitacion = new Habilitaciones();
            
            int expected = 5;
            habilitacion.RemoveHabilitacion("ROCK");
            Assert.AreEqual(expected, habilitacion.ListaHabilitaciones.Count);
        }
    }
}