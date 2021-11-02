using NUnit.Framework;
using ClassLibrary;

    /// <summary>
    /// Creación de la clase UsuarioTest, esta misma clase nos permite probar los métodos de la clase Usuario para corroborar que todo funcione de forma esperada.
    /// </summary>
    [TestFixture]
    public class UsuarioTest
    {       
        
        /// <summary>
        /// Testea el Nombre del Usuario para corroborar que la instancia fue creada correctamente.
        /// </summary>
        [Test]
        public void TestearUsuarioNombre()
        {
            Usuario usuario = new Usuario("Joaquin", "Montevideo", new Rubro("Textil"));

            Assert.AreEqual("Joaquin", usuario.Nombre);

          
        }
         
         /// <summary>
         /// Test para verificar que el usuario se haya creado de la forma correcta.
         /// </summary>
         [Test]
        public void TestearUsuarioUbicacion()
        {
            Usuario usuario = new Usuario("Joaquin", "Montevideo", new Rubro("Textil"));

            Assert.AreEqual("Montevideo", usuario.Ubicacion);

        }
        /// <summary>
        ///  Testea el rubro del usuario para saber si la creación del mismo fue adecuada.
        /// </summary>
        [Test]
        public void TestearUsuarioRubro()
        {
            Usuario usuario = new Usuario("Joaquin", "Montevideo", new Rubro("Textil"));

            Assert.AreEqual("Textil", usuario.Rubro.Nombre);

        }
    }

            