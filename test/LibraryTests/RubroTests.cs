namespace Test.Library
{ 
    using ClassLibrary;
    using NUnit.Framework;
    
    /// <summary>
    /// Clase de pruebas de RubroTest.
    /// </summary>
    [TestFixture]
    public class RubroTests
    {
        /// <summary>
        /// En este test vamos a verificar la correcta creación de un Rubro con nombre
        /// </summary>
        [Test]
        public void TestCrearRubro()
        {

            Rubro rubro = new Rubro("Efectivamente");
            Assert.That(rubro.Nombre, Is.EqualTo("Efectivamente"));

            Rubro rubro = new Rubro("metalurgia");
            string expected = "metalurgia"; // Esta variable string sirve para evaluar el comportamiento.
            //rubro.AddRubro("Cocina");
            //Assert.AreEqual(expected, Rubro.RubrosList.Count);
        }
        
        /// <summary>
        /// Test para comprobar que no se agregue a la lista un  rubro repetido.
        /// </summary>
        [Test]
        public void TestAgregarRubroRepetido()
        {
            Rubro rubro = new Rubro();
            //int expected = 11; // ya que 10 es el largo de la actual y es un rubro existente.
            //rubro.AddRubro("Deportes");
            //rubro.AddRubro("Deportes");
            //Assert.AreEqual(expected, Rubro.RubrosList.Count);
        }
        
        /// <summary>
        /// Test para comprobar si efectivamente el metodo elimina un Rubro.
        /// </summary>
        [Test]
        public void TestEliminarRubro()
        {
            Rubro rubro = new Rubro();
            //int expected = 10; // ya que 11 es el largo de la actual y queremos eliminar un rubro.
            //rubro.RemoveRubro("Deportes");
            //Assert.AreEqual(expected, Rubro.RubrosList.Count);

        }
        /// <summary>
        /// En este test vamos a verificar la correcta creación de un Rubro sin nombre
        /// </summary>
        [Test]
        public void TestCrearRubro2()
        {
            Rubro rubro = new Rubro();
            Assert.That(rubro.Nombre, Is.EqualTo(null));
        }
    }
}