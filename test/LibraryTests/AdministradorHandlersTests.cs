namespace Test.Library
{
    using ClassLibrary;
    using NUnit.Framework;
    using Telegram.Bot.Types;
    /// <summary>
    /// Esta clase permite probar todos los handlers destinados al administrador.
    /// </summary>
    [TestFixture]
    public class AdministradorHandlersTests
    {
        /// <summary>
        /// Test que corrobora el correcto funcionamiento de los Handlers: InvitarEmpresa y CrearEmpresa.
        /// </summary>
        [Test]
        public void InvitarEmpresayCrearEmpresaHandlersTest()
        {
            ContenedorPrincipal contenedorAdmins = Singleton<ContenedorPrincipal>.Instancia;
            contenedorAdmins.Administradores.Add("1", new Administrador("Admin", "equipo_16"));

            Message message = new Message();

            User usuario = new User();
            usuario.Id = 1;
            message.From = usuario;

            Chat chat1 = new Chat();

            message.Chat = chat1;
            message.Chat.Id = 1;
            message.Text = "/crearempresa";

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(message);
            IMensaje msg = teleadapter;
            contenedorAdmins.HistorialDeChats.Add(msg.Id, new HistorialChat());

            IHandler first = new CrearEmpresaAdminHandler(null);
            string response;

            first.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese nombre de la empresa"));

            message.Text = "testingEmpresa";
            msg = teleadapter;

            first.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese la ubicacion de la empresa"));

            message.Text = "testingEmpresaLocation";
            msg = teleadapter;

            first.Handle(msg, out response);
            Assert.That(response, Is.EqualTo($"Ingrese el rubro de la empresa\n {Singleton<ContenedorPrincipal>.Instancia.ContenedorRubrosHabs.TextoListaRubros()}"));

            IHandler second = new InvitarEmpresaHandler(null);

            message.Text = "/invitarempresa";
            msg = teleadapter;

            second.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese el nombre de la empresa que desea invitar"));

            message.Text = "testingEmpresa";
            msg = teleadapter;
            string empresaNombre = "testingEmpresa";

            second.Handle(msg, out response);
            Assert.That(response, Is.EqualTo($"Se ha invitado a {empresaNombre}. {OpcionesUso.AccionesAdministradores()}"));
        }
        
        /// <summary>
        /// Test que corrobora el correcto funcionamiento del RegistrarAdminHandler.
        /// </summary>
        [Test]
        public void RegistrarAdminHandlerTest()
        {
            ContenedorPrincipal contenedorAdmins = Singleton<ContenedorPrincipal>.Instancia;

            Message message = new Message();

            User usuario = new User();
            usuario.Id = 2;
            message.From = usuario;

            Chat chat1 = new Chat();

            message.Chat = chat1;
            message.Chat.Id = 2;
            message.Text = "/registraradmin";

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(message);
            IMensaje msg = teleadapter;

            contenedorAdmins.HistorialDeChats.Add(msg.Id, new HistorialChat());

            string response;

            IHandler first = new RegistrarAdminHandler(null);
            first.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese el nombre"));

            message.Text = "TesteandoAdmin";
            msg = teleadapter;

            first.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese la clave"));

            message.Text = "equipo_16";
            msg = teleadapter;
            string nombreAdmin = "TesteandoAdmin";

            first.Handle(msg, out response);
            Assert.That(response, Is.EqualTo($"Usted se ha registrado como un Administrador con el nombre {nombreAdmin}. \nPara mayor seguridad debe cambiar su contraseña utilizando el comando /cambiarClave \nQue disfrute el bot."));
        }
    }
}