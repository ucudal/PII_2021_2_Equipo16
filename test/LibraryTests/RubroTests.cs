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
        /// En este test vamos a comprobar si se agrega correctamente un Rubro a la lista.
        /// Para esto vamos a  crear un rubro nuevo  y verificar mediante el largo de la lista si se agrego correctamente.
        /// Al ser nuevo se agregara a la lista , si ya está en la misma el mismo no se agregará.
        /// </summary>
        [Test]
        public void TestAgregarRubro()
        {
            Rubro rubro = new Rubro();
            int expected = 10; // ya que 9 es el largo de la actual y es un rubro nuevo.
            rubro.AddRubro("Cocina");
            Assert.AreEqual(expected, Rubro.RubrosList.Count);
        }
        
        /// <summary>
        /// Test para comprobar que no se agregue a la lista un  rubro repetido.
        /// </summary>
        [Test]
        public void TestAgregarRubroRepetido()
        {
            Rubro rubro = new Rubro();
            int expected = 11; // ya que 10 es el largo de la actual y es un rubro existente.
            rubro.AddRubro("Deportes");
            rubro.AddRubro("Deportes");
            Assert.AreEqual(expected, Rubro.RubrosList.Count);
        }
        
        /// <summary>
        /// Test para comprobar si efectivamente el metodo elimina un Rubro.
        /// </summary>
        [Test]
        public void TestEliminarRubro()
        {
            Rubro rubro = new Rubro();
            int expected = 10; // ya que 11 es el largo de la actual y queremos eliminar un rubro.
            rubro.RemoveRubro("Deportes");
            Assert.AreEqual(expected, Rubro.RubrosList.Count);
        }
    }
}