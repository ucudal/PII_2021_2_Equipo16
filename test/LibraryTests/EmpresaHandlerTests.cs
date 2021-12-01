namespace Test.Library
{
    using ClassLibrary;
    using NUnit.Framework;
    using Telegram.Bot.Types;

    /// <summary>
    /// Esta clase permite probar todos los handlers destinados al emprendedor.
    /// </summary>
    [TestFixture]
    public class EmpresaHandlerTest
    {
        /// <summary>
        /// Este test se encarga de Crear una oferta pasando por cada requerimiento
        /// para ver si todo funciona correctamente.
        /// </summary>
        [Test]
        public void  CrearOfertaHandlerTest()
        {
            ContenedorPrincipal contenedorPrincipal = Singleton<ContenedorPrincipal>.Instancia;
            contenedorPrincipal.Empresas.Add("123234", new Empresa("Empresa1", "ubi","Textil"));

            Message mensaje = new Message();
            User usuario = new User();
            usuario.Id = 123234;
            mensaje.From = usuario;

            Chat chat = new Chat();
            mensaje.Chat = chat;
            mensaje.Chat.Id = 123234;
            mensaje.Text = "/crearoferta";

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(mensaje);
            IMensaje msg = teleadapter;

            contenedorPrincipal.HistorialDeChats.Add(msg.Id, new HistorialChat());

            IHandler crearOfertaHandlerResult = new CrearOfertaHandler(null);

            string response;

            crearOfertaHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese el nombre de la oferta"));

            string nombreOfertaTest = "ofertaTest";
            mensaje.Text = nombreOfertaTest;
            msg = teleadapter;
            crearOfertaHandlerResult.Handle(msg, out response);

            Assert.That(response, Is.EqualTo("Ingrese el tipo del material:\n-Reciclado\n-Residuo"));

            string nombreMaterialTest = "Reciclado";
            mensaje.Text = nombreMaterialTest;
            msg = teleadapter;

            crearOfertaHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese el precio"));

            string precioTest = "100";
            mensaje.Text = precioTest;
            msg = teleadapter;

            crearOfertaHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese unidad"));

            string unidadesTest = "unidades";
            mensaje.Text = unidadesTest;
            msg = teleadapter;

            crearOfertaHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese un tag o palabra clave"));

            string tagTest = "tagTest";
            mensaje.Text = tagTest;
            msg = teleadapter;

            crearOfertaHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese una ubicación"));
            
            string ubiTest = "Av 8 de Oct";
            mensaje.Text = ubiTest;
            msg = teleadapter;

            crearOfertaHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Elija si es una oferta puntual o constante"));

            string tipoTest = "constante";
            mensaje.Text = tipoTest;
            msg = teleadapter;

            crearOfertaHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese la cantidad"));

            string cantidadTest = "10";
            mensaje.Text = cantidadTest;
            msg = teleadapter;

            crearOfertaHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo($"Se ha registrado con nombre {nombreOfertaTest}, de material {nombreMaterialTest}, del tipo {tipoTest}, unidades: {unidadesTest}, al precio de: {precioTest}, con la ubicación en {ubiTest} y el tag {tagTest}. {OpcionesUso.AccionesEmpresas()}"));
        }

        /// <summary>
        /// Test que evalúa lo sucedido al crear una instancia de tipo Oferta.
        /// </summary>
        [Test]
        public void AddHabOfertaHandlerTest()
        {
            ContenedorPrincipal contiene = Singleton<ContenedorPrincipal>.Instancia;
            Empresa empresaTest1 = new Empresa("Empresa1", "ubi", "Textil");
            contiene.Empresas.Add("7864", empresaTest1);

            contiene.Publicaciones.OfertasPublicados.Add(new Oferta("oferta1", "mat", "1000", "299", "kilo", "tag1", "ubi1", "constante", empresaTest1 ));

            Message message = new Message();

            User usuario = new User();
            usuario.Id = 7864;
            message.From = usuario;

            Chat chat1 = new Chat();

            message.Chat = chat1;
            message.Chat.Id = 7864;
            message.Text = "/agregarhaboferta";

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(message);

            IMensaje msg = teleadapter;

            contiene.HistorialDeChats.Add(msg.Id, new HistorialChat());

            string response;

            IHandler first = new AgregarHabOfertaHandler(null);
            first.Handle(msg, out response);

            Assert.That(response, Is.EqualTo("Ingrese el nombre de la oferta a la que desea agregar una habilitación."));

            string nombreOfertaTest = "Oferta1";
            message.Text = nombreOfertaTest; 
            msg = teleadapter;

            first.Handle(msg, out response);
            Assert.That(response, Is.EqualTo( $"Ingrese el nombre de la habilitación que desea agregar.\n{Singleton<ContenedorPrincipal>.Instancia.ContenedorRubrosHabs.TextoListaHabilitaciones()}"));

            string habilitacionTest = "APA";
            message.Text = habilitacionTest; 
            msg = teleadapter;
            first.Handle(msg, out response);
            Assert.That(response, Is.EqualTo($"Se ha agregado la habilitacion {habilitacionTest} de la oferta {nombreOfertaTest}. {OpcionesUso.AccionesEmpresas()}"));
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void RemoverHabEmpresaHandlerTest()
        {
            ContenedorPrincipal contiene = Singleton<ContenedorPrincipal>.Instancia;
            Empresa empresaTest1 = new Empresa("Empresa1", "ubi", "Textil");
            contiene.Empresas.Add("9345", empresaTest1);
            empresaTest1.AddHabilitacion("APA");
            contiene.Publicaciones.OfertasPublicados.Add(new Oferta("oferta1", "mat", "1000", "299", "kilo", "tag1", "ubi1", "constante", empresaTest1 ));

            Message message = new Message(); 

            User usuario = new User();
            usuario.Id = 9345;
            message.From = usuario;

            Chat chat1 = new Chat();

            message.Chat = chat1;
            message.Chat.Id = 9345;
            message.Text = "/removerhabempresa";

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(message);

            IMensaje msg = teleadapter;

            contiene.HistorialDeChats.Add(msg.Id, new HistorialChat());

            string response;

            IHandler first = new RemoveHabEmpresaHandler(null);
            first.Handle(msg, out response);

            Assert.That(response, Is.EqualTo("Ingrese el nombre de la habilitación a eliminar."));

            string nombreHabTest = "APA";
            message.Text = nombreHabTest;
            msg = teleadapter;
            first.Handle(msg, out response);
            Assert.That(response, Is.EqualTo( $"Se ha removido la habilitación {nombreHabTest} con éxito. {OpcionesUso.AccionesEmpresas()}")); 
        }
        
        /// <summary>
        /// Test que prueba el Handler para Agregar una habilitación a una empresa.
        /// </summary>
        [Test]
         public void AgregarHabEmpresaHandlerTest()
        {
            ContenedorPrincipal contiene = Singleton<ContenedorPrincipal>.Instancia;
            Empresa empresaTest1 = new Empresa("Empresa1", "ubi", "Textil");
            contiene.Empresas.Add("7432", empresaTest1);
            contiene.Publicaciones.OfertasPublicados.Add(new Oferta("oferta1", "mat", "1000", "299", "kilo", "tag1", "ubi1", "constante", empresaTest1 ));

            Message message = new Message(); 

            User usuario = new User();
            usuario.Id = 7432;
            message.From = usuario;

            Chat chat1 = new Chat();

            message.Chat = chat1;
            message.Chat.Id = 7432;
            message.Text = "/agregarhabilitacionempresa";

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(message); 

            IMensaje msg = teleadapter;

            contiene.HistorialDeChats.Add(msg.Id, new HistorialChat());

            string response;

            IHandler first = new AgregarHabEmpresaHandler(null);
            first.Handle(msg, out response);

            Assert.That(response, Is.EqualTo($"Ingrese la habilitación que desea agregar.\n{Singleton<ContenedorPrincipal>.Instancia.ContenedorRubrosHabs.TextoListaHabilitaciones()}"));

            string nombreHabTest2 = "APA";
            message.Text = nombreHabTest2;
            msg = teleadapter;

            first.Handle(msg, out response);
            Assert.That(response, Is.EqualTo($"Se ha agregado '{nombreHabTest2}' a la lista de habilitaciones. {OpcionesUso.AccionesEmpresas()}"));
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void InteresadoenOfertaCalcularOfertasVendidasyAceptarOfertaHandlerTestBien()
        {
            ContenedorPrincipal contiene = Singleton<ContenedorPrincipal>.Instancia;
            Emprendedor emprendedorTest = new Emprendedor("nombreEmprendedor", "ubi", "Textil", "espe", "email@prueba.com");
            contiene.Emprendedores.Add("128234", emprendedorTest);
            Empresa empresaTest1 = new Empresa("Empresa1", "ubi", "Textil");
            contiene.Empresas.Add("1278", empresaTest1);

            contiene.Publicaciones.OfertasPublicados.Add(new Oferta("oferta1", "mat", "1000", "299", "kilo", "tag1", "ubi1", "constante", empresaTest1 ));

            Message message = new Message();

            User usuario = new User();
            usuario.Id = 128234;
            message.From = usuario;

            Chat chat1 = new Chat();

            message.Chat = chat1; 
            message.Chat.Id = 128234;

            Message message2 = new Message();

            User usuario2 = new User();
            usuario2.Id = 1278;
            message2.From = usuario2;
            
            Chat chat2 = new Chat(); 

            message2.Chat = chat2;
            message2.Chat.Id = 1278;

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(message);
            
            IMensaje msg = teleadapter;

            contiene.HistorialDeChats.Add(msg.Id, new HistorialChat());

            string response;
            IHandler HandlerResult = new InteresadoEnOfertaHandler(null);
            message.Text = "/interesarme";
            msg = teleadapter;
            HandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese el nombre de la oferta en la que quiera manifestar su interés"));

            message.Text = "oferta1";
            msg = teleadapter;
            HandlerResult.Handle(msg, out response);
            string nombreOferta = "oferta1";
            Assert.That(response, Is.EqualTo($"Se ha manifestado su interés en {nombreOferta} de manera exitosa."));

            TelegramMsgAdapter teleadapter2 = new TelegramMsgAdapter(message2);

            IMensaje msg2 = teleadapter2;
            contiene.HistorialDeChats.Add(msg2.Id, new HistorialChat());
            IHandler HandlerResult2 = new CalcularOfertasVendidasHandler(null);
            IHandler HandlerResult3 = new AceptarOfertaHandler(null);
            message2.Text = "/aceptaroferta";
            msg2 = teleadapter2;
            HandlerResult3.Handle(msg2, out response);
            Assert.That(response, Is.EqualTo($"Ingrese el Nombre de la oferta que desee aceptar."));

            message2.Text = "oferta1";
            msg2 = teleadapter2;
            string nombreOfertaParaAceptar = "oferta1";

            HandlerResult3.Handle(msg2, out response);
            Assert.That(response, Is.EqualTo($"Se ha aceptado la oferta {nombreOfertaParaAceptar} con éxito. {OpcionesUso.AccionesEmpresas()} "));

            message2.Text = "/calcularofertasvendidas";
            msg2 = teleadapter2;
            HandlerResult2.Handle(msg2, out response);
            Assert.That(response, Is.EqualTo("Ingrese la fecha de inicio(yyyy-MM-dd)"));

            message2.Text = "2020-05-01";
            msg2 = teleadapter2;

            HandlerResult2.Handle(msg2, out response);
            Assert.That(response, Is.EqualTo("Ingrese la fecha final(yyyy-MM-dd)"));

            message2.Text = "2024-11-21";
            msg2 = teleadapter2;

            HandlerResult2.Handle(msg2, out response);
            string fechaInicio = "2020-05-01";
            string fechaFinal = "2024-11-21";
            Assert.That(response, Is.EqualTo($"En este periodo se han adquirido {LogicaEmpresa.CalcularOfertasVendidas(empresaTest1, fechaInicio, fechaFinal)}. {OpcionesUso.AccionesEmpresas()}"));
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void AceptarInvEmpresaHandlerTest()
        {
            ContenedorPrincipal contiene = Singleton<ContenedorPrincipal>.Instancia;
            Empresa empresaTest1 = new Empresa("Empresa1", "ubi", "Textil");
            contiene.EmpresasInvitadas.Add(empresaTest1);

            Message message = new Message();

            User usuario = new User();
            usuario.Id = 4321;
            message.From = usuario;

            Chat chat1 = new Chat();

            message.Chat = chat1;
            message.Chat.Id = 4321;
            message.Text = "/aceptarinvitacion";

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(message);

            IMensaje msg = teleadapter;

            contiene.HistorialDeChats.Add(msg.Id, new HistorialChat());
            string response;

            IHandler first = new AceptarInvEmpresaHandler(null);
            first.Handle(msg, out response);

            Assert.That(response, Is.EqualTo("Ingrese la clave de su Empresa."));

            string claveEmpresaTest = "Empresa1";
            message.Text = claveEmpresaTest; 
            msg = teleadapter;

            first.Handle(msg, out response);
            Assert.That(response, Is.EqualTo($"Gracias por unirte {claveEmpresaTest}. {OpcionesUso.AccionesEmpresas()}"));
        }
        
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void RemoverHabOfertaHandlerTest()
        {
            ContenedorPrincipal contiene = Singleton<ContenedorPrincipal>.Instancia;
            Empresa empresaTest1 = new Empresa("Empresa1", "ubi", "Textil");
            contiene.Empresas.Add("8439", empresaTest1);
            LogicaEmpresa.CrearOferta(empresaTest1,"oferta23", "mat", "1000", "299", "kilo", "tag1", "ubi1", "constante");
            LogicaEmpresa.AgregarHabilitacionOferta(empresaTest1,"APA", "oferta23");

            Message message = new Message();

            User usuario = new User();
            usuario.Id = 8439;
            message.From = usuario;

            Chat chat1 = new Chat();

            message.Chat = chat1;
            message.Chat.Id = 8439;
            message.Text = "/removerhaboferta";

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(message);

            IMensaje msg = teleadapter;

            contiene.HistorialDeChats.Add(msg.Id, new HistorialChat());

            string response;

            IHandler first = new RemoverHabOfertaHandler(null);
            first.Handle(msg, out response);

            Assert.That(response, Is.EqualTo("Ingrese el nombre de la oferta a la que desea eliminar una habilitacion"));

            string nombreOfertaTest2 = "oferta23";
            message.Text = nombreOfertaTest2;
            msg = teleadapter;

            first.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("ingrese el nombre de la habilitacion que desea remover"));

            string habilitacionTest2 = "APA";
            message.Text = habilitacionTest2;
            msg = teleadapter;
            first.Handle(msg, out response);
            Assert.That(response, Is.EqualTo( $"Se ha removido la habilitacion {habilitacionTest2} de la oferta {nombreOfertaTest2}. {OpcionesUso.AccionesEmpresas()}"));
        }
    }
}