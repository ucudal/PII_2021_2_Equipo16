namespace Test.Library
{
    using ClassLibrary;
    using NUnit.Framework;

    /// <summary>
    /// Esta clase permite generar los test necesarios para poder comprobar la que la clase Administrador funcione correctamente.
    /// </summary>
    [TestFixture]
    public class AdministradorTests
    {
        /// <summary>
        /// Este test comprueba que se puedan inicializar instancias de la clase Administrador.
        /// </summary>
        [Test]
        public void TestAdministrador()
        {
            Administrador admin = new Administrador("Admin", "equipo_16");
            string expected = "Admin";
            Assert.AreEqual(expected, admin.Nombre);
        }

        /// <summary>
        /// Este test lo que permite es ver si el metodo InvitarEmpresa de la Clase Administrador funciona.
        /// Para poder realizar esto se instancia un administrador y una empresa luego el administrador invita a la empresa a unirse.
        /// Inicialmente la lista de empresas que tiene el administrador esta vacia, pero cuando se invita a la empresa pasa a tener 1 miembro, que es lo que evalua este test.
        /// </summary>
        [Test]
        public void TestInvitar()
        {
            Administrador admin = new Administrador("Admin", "equipo_16");
            Empresa empresa = new Empresa("royal", "calle 1", "Textil");
            admin.InvitarEmpresa(empresa);
            int expected = 1;
            Assert.AreEqual(expected, Singleton<ContenedorPrincipal>.Instancia.EmpresasInvitadas.Count);
        }

        /// <summary>
        /// Este test está diseñado para que de error, ya que se espera un nombre y no un string vacio.
        /// Esto da por defecto el nombre Jhon.
        /// </summary>
        [Test]
        public void TestAdministradorFalso()
        {
            Administrador admin = new Administrador(string.Empty, "equipo_16");
            string expected = "Jhon";
            Assert.AreEqual(expected, admin.Nombre);
        }
    }
}