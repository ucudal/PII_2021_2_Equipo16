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
        }
    }
}