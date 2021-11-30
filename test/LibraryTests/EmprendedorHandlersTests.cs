namespace Test.Library
{
    using ClassLibrary;
    using NUnit.Framework;
    using Telegram.Bot.Types;
    /// <summary>
    /// Esta clase permite probar todos los handlers destinados al emprendedor.
    /// </summary>
    [TestFixture]
    public class EmprendedorHandlerTest
    {
        /// <summary>
        /// En este test, se crea una emprendedor, el cual ejecuta a través de telegram una búsqueda por tag con el tag "tagtest".
        /// Luego, una empresa creada anteriormente crea una oferta con ese mismo tag.
        /// Al ejecutar la búsqueda, se puede comprobar el correcto funcionamiento del BuscadorTagHandler, por como efectivamente
        /// aparece la oferta.
        /// </summary>
        [Test]
        public void BuscadorTagHandlerTest()
        {
            ContenedorPrincipal contenedorPrincipal = Singleton<ContenedorPrincipal>.Instancia;
            contenedorPrincipal.Emprendedores.Add("123", new Emprendedor("Emprendedor", "ubi", "textil", "espe"));
            Empresa empresaTest1 = new Empresa("Empresa1", "ubi", "textil");

            contenedorPrincipal.Publicaciones.OfertasPublicados.Add(new Oferta("Oferta1", "lol", "1000", "299", "kilo", "tagtest", "ubi", "constante", empresaTest1));

            Message mensaje = new Message();
            User usuario = new User();
            usuario.Id = 123;
            mensaje.From = usuario;

            Chat chat = new Chat();
            mensaje.Chat = chat;
            mensaje.Chat.Id = 123;
            mensaje.Text = "/buscartag";

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(mensaje); 
            IMensaje msg = teleadapter; 

            contenedorPrincipal.HistorialDeChats.Add(msg.Id, new HistorialChat());

            IHandler buscadorTagHandlerResult = new BuscadorTagHandler(null); 

            string response;
            buscadorTagHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese el Tag por el que sea filtrar en su búsqueda."));

            string palabraClave = "tagtest";
            mensaje.Text = palabraClave;

            buscadorTagHandlerResult.Handle(msg, out response);
            
            Assert.That(response, Is.EqualTo("******************************\nNombre: Oferta1 \nMaterial: lol \nPrecio: $299 \nUnidad: kilo \nCantidad: 1000 \nTag: tagtest \nUbicación: ubi \nEs una oferta constante \nRequerimientos: \n\n******************************\n"));
        }
        /// <summary>
        /// En este test, se crea una emprendedor, el cual ejecuta a través de telegram una búsqueda por material con el material "esteesunmaterial".
        /// Luego, una empresa creada anteriormente crea una oferta con ese mismo material.
        /// Al ejecutar la búsqueda, se puede comprobar el correcto funcionamiento del BuscadorMaterialHandler, por como efectivamente
        /// aparece la oferta.
        /// </summary>
        [Test]
        public void BuscadorMaterialHandlerTest()
        {
            ContenedorPrincipal container = Singleton<ContenedorPrincipal>.Instancia;
            container.Emprendedores.Add("124", new Emprendedor("nombreEmprendedor", "ubi", "textil", "espe"));
            Empresa empresaTest1 = new Empresa("Empresa1", "ubi", "textil");
            
            container.Publicaciones.OfertasPublicados.Add(new Oferta("oferta2", "esteesunmaterial", "1000", "299", "kilo", "tag1", "ubi1", "constante", empresaTest1 ));
            
            Message message = new Message(); 

            User usuario = new User(); 
            usuario.Id = 124;
            message.From = usuario;
            
            Chat chat1 = new Chat();  

            message.Chat = chat1; 
            message.Chat.Id = 124;
            message.Text = "/buscarmaterial"; 

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(message); 

            IMensaje msg = teleadapter; 
            
            container.HistorialDeChats.Add(msg.Id, new HistorialChat()); 
            
            string response; 

            IHandler first = new BuscadorMaterialHandler(null); 
            first.Handle(msg, out response); 
            
            Assert.That(response, Is.EqualTo("Ingrese el tipo del material por el que desea filtrar en su búsqueda.\n-Reciclado\n-Residuo"));

            message.Text = "esteesunmaterial"; 
            
            msg = teleadapter; 
            first.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("******************************\nNombre: oferta2 \nMaterial: esteesunmaterial \nPrecio: $299 \nUnidad: kilo \nCantidad: 1000 \nTag: tag1 \nUbicación: ubi1 \nEs una oferta constante \nRequerimientos: \n\n******************************\n"));
            
        }
        /// <summary>
        /// En este test, se crea una emprendedor, el cual ejecuta a través de telegram una búsqueda por ubicación con la ubicación "test".
        /// Luego, una empresa creada anteriormente crea una oferta con esa misma ubicación.
        /// Al ejecutar la búsqueda, se puede comprobar el correcto funcionamiento del BuscadorUbicacionHandler, por como efectivamente
        /// aparece la oferta.
        /// </summary>
        [Test]
        public void BuscadorUbicacionHandlerTest()
        {
            ContenedorPrincipal container = Singleton<ContenedorPrincipal>.Instancia;
            container.Emprendedores.Add("125", new Emprendedor("nombreEmprendedor", "ubi", "textil", "espe"));
            Emprendedor emprendedorTest = new Emprendedor("test", "test", "textil", "test");
            Empresa empresaTest1 = new Empresa("Empresa1", "ubi", "textil");
            container.Publicaciones.OfertasPublicados.Add(new Oferta("oferta5", "materialaleatorio", "1000", "299", "kilo", "tag1", "test", "constante", empresaTest1 ));
            Message message = new Message(); 

            User usuario = new User(); 
            usuario.Id = 125;
            message.From = usuario;
            
            Chat chat1 = new Chat();  

            message.Chat = chat1; 
            message.Chat.Id = 125;
            message.Text = "/buscarubicacion"; 

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(message); 

            IMensaje msg = teleadapter; 
            
            container.HistorialDeChats.Add(msg.Id, new HistorialChat()); 
            
            string response; 

            IHandler first = new BuscadorUbicacionHandler(null); 
            first.Handle(msg, out response); 
            
            Assert.That(response, Is.EqualTo("Ingrese la Ubicación por la que sea filtrar en su búsqueda."));

            message.Text = "test"; 

            msg = teleadapter; 
            first.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("******************************\nNombre: oferta5 \nMaterial: materialaleatorio \nPrecio: $299 \nUnidad: kilo \nCantidad: 1000 \nTag: tag1 \nUbicación: test \nEs una oferta constante \nRequerimientos: \n\n******************************\n "));
        }
        /// <summary>
        /// En este test, se crea un emprendedor, el cual ejecuta a través de telegram quiere agregarse habilitaciones.
        /// Para eso, ejecuta el comando "/agregarhabilitacionemprendedor", y luego se agrega la habilitación "soa".
        /// Con esto, se demuestra el correcto funcionamiento del AgregarHabEmprendedorHandler.
        /// </summary>
        [Test]
         public void AgregarHabEmprendedorHandlerTestBien()
        {
            ContenedorPrincipal container = Singleton<ContenedorPrincipal>.Instancia;
            container.Emprendedores.Add("126", new Emprendedor("nombreEmprendedor", "ubi", "textil", "espe"));
            Empresa empresaTest1 = new Empresa("Empresa1", "ubi", "textil");
            
            container.Publicaciones.OfertasPublicados.Add(new Oferta("oferta1", "mat", "1000", "299", "kilo", "tag1", "ubi1", "constante", empresaTest1 ));
            
            Message message = new Message(); 

            User usuario = new User(); 
            usuario.Id = 126;
            message.From = usuario;
            
            Chat chat1 = new Chat();  

            message.Chat = chat1; 
            message.Chat.Id = 126;
            message.Text = "/agregarhabilitacionemprendedor"; 

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(message); 

            IMensaje msg = teleadapter; 
            
            container.HistorialDeChats.Add(msg.Id, new HistorialChat()); 

            IHandler agregarHabEmprendedorHandlerResult = new AgregarHabEmprendedorHandler(null);
            string response; 
            agregarHabEmprendedorHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo($"Ingrese la habilitación que desea agregar.\n{Singleton<ContenedorPrincipal>.Instancia.ContenedorRubrosHabs.textoListaHabilitaciones()}"));

            message.Text = "soa";
            msg = teleadapter;
            string nuevaHab = message.Text;
            agregarHabEmprendedorHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo($"Se ha agregado '{nuevaHab}' a la lista de habilitaciones. {OpcionesUso.AccionesEmprendedor()}"));
        }
        /// <summary>
        /// En este test, se crea un emprendedor, el cual ejecuta a través de telegram quiere removerse habilitaciones.
        /// Para eso, ejecuta el comando "removerhabemprendedor", y luego se remueve la habilitación "soa".
        /// Con esto, se demuestra el correcto funcionamiento del RemoverHabEmprendedorHandler.
        /// </summary>
        [Test]
         public void RemoverHabEmprendedorHandlerTestBien()
        {
            ContenedorPrincipal container = Singleton<ContenedorPrincipal>.Instancia;
            Emprendedor emprendedorTest = new Emprendedor("nombreEmprendedor", "ubi", "textil", "espe");
            container.Emprendedores.Add("127", emprendedorTest);
            Empresa empresaTest1 = new Empresa("Empresa1", "ubi", "textil");
            
            container.Publicaciones.OfertasPublicados.Add(new Oferta("oferta1", "mat", "1000", "299", "kilo", "tag1", "ubi1", "constante", empresaTest1 ));
            
            Message message = new Message(); 

            User usuario = new User(); 
            usuario.Id = 127;
            message.From = usuario;
            
            Chat chat1 = new Chat();  

            message.Chat = chat1; 
            message.Chat.Id = 127;
            message.Text = "/removerhabemprendedor"; 

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(message); 

            IMensaje msg = teleadapter; 
            emprendedorTest.AddHabilitacion("soa");
            container.HistorialDeChats.Add(msg.Id, new HistorialChat()); 

            IHandler removerHabEmprendedorHandlerResult = new RemoverHabEmprendedor(null);
            string response; 
            removerHabEmprendedorHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo($"Ingrese el nombre de la habilitación que desea eliminar."));

            message.Text = "soa";
            msg = teleadapter;
            string habilitacion = message.Text;
            removerHabEmprendedorHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo($"Se ha removido la habilitación {habilitacion} con éxito. {OpcionesUso.AccionesEmprendedor()} "));
        }
        /// <summary>
        /// En este test, se demuestra el correcto funcionamiento de CalcularOfertasCompradasHandler y InteresadoEnOfertaHandler.
        /// Para eso, se crean una empresa y un emprendedor
        /// El primero, publica una oferta. El segundo, por su parte, busca interesarse en esa oferta con "/interesarme", 
        /// para luego fijarse si realmente funcionó su manifestación de interés, con "/calcularofertascompradas".
        /// </summary>
        [Test]
        public void InteresadoenOfertayCalcularOfertasCompradasHandlerTestBien()
        {
            ContenedorPrincipal container = Singleton<ContenedorPrincipal>.Instancia;
            Emprendedor emprendedorTest = new Emprendedor("nombreEmprendedor", "ubi", "textil", "espe");
            container.Emprendedores.Add("128", emprendedorTest);
            Empresa empresaTest1 = new Empresa("Empresa1", "ubi", "textil");
            
            container.Publicaciones.OfertasPublicados.Add(new Oferta("oferta1", "mat", "1000", "299", "kilo", "tag1", "ubi1", "constante", empresaTest1 ));
            
            Message message = new Message(); 

            User usuario = new User(); 
            usuario.Id = 128;
            message.From = usuario;
            
            Chat chat1 = new Chat();  

            message.Chat = chat1; 
            message.Chat.Id = 128;

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(message); 

            IMensaje msg = teleadapter;

            container.HistorialDeChats.Add(msg.Id, new HistorialChat()); 

            string response; 
            IHandler interesadoEnOferta = new InteresadoEnOfertaHandler(null);
            message.Text = "/interesarme";
            msg = teleadapter;
            interesadoEnOferta.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese el nombre de la oferta en la que quiera manifestar su interés"));

            message.Text = "oferta1";
            msg = teleadapter;
            interesadoEnOferta.Handle(msg, out response);
            string nombreOferta = "oferta1";
            Assert.That(response, Is.EqualTo($"Se ha manifestado su interés en {nombreOferta} de manera exitosa."));
            
            message.Text = "/calcularofertascompradas"; 
            msg = teleadapter;
            IHandler calcularOfertasCompradasHandlerResult = new CalcularOfertasCompradasHandler(null);
            calcularOfertasCompradasHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese la fecha de inicio (YYYY-MM-DD)."));

            message.Text = "2020-05-01";
            msg = teleadapter;

            calcularOfertasCompradasHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese la fecha final (YYYY-MM-DD)."));

            message.Text = "2024-11-21";
            msg = teleadapter;

            calcularOfertasCompradasHandlerResult.Handle(msg, out response);
            string fechaInicio = "2020-05-01";
            string fechaFinal = "2024-11-21";
            Assert.That(response, Is.EqualTo($"En este periodo se han adquirido {LogicaEmprendedor.CalcularOfertasCompradas(emprendedorTest, fechaInicio, fechaFinal)}. {OpcionesUso.AccionesEmprendedor()}"));
        }
        /// <summary>
        /// En este test, se busca demostrar el correcto funcionamiento del GetHabListHandler.
        /// Con ese objetivo, un emprendedor, que ya cuenta con su habilitación "soa", busca corroborar si efectivamente la tiene.
        /// Para eso, utiliza "/listadehabilitaciones".
        /// Al final, se puede observar, como el Handler funciona correctamente.
        /// </summary>
        [Test]
         public void ListadeHabilitacionesHandlerTestBien()
        {
            ContenedorPrincipal container = Singleton<ContenedorPrincipal>.Instancia;
            Emprendedor emprendedorTest = new Emprendedor("nombreEmprendedor", "ubi", "textil", "espe");
            container.Emprendedores.Add("129", emprendedorTest);
            Empresa empresaTest1 = new Empresa("Empresa1", "ubi", "textil");
            container.Publicaciones.OfertasPublicados.Add(new Oferta("oferta9", "mat", "1000", "299", "kilo", "tag1", "ubi1", "constante", empresaTest1 ));
            
            Message message = new Message(); 

            User usuario = new User(); 
            usuario.Id = 129;
            message.From = usuario;
            
            Chat chat1 = new Chat();  

            message.Chat = chat1; 
            message.Chat.Id = 129;
            message.Text = "/listadehabilitaciones"; 

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(message); 

            IMensaje msg = teleadapter; 
            emprendedorTest.AddHabilitacion("soa"); 
            container.HistorialDeChats.Add(msg.Id, new HistorialChat()); 

            IHandler getHabListHandlerResult = new GetHabListHandler(null);
            string response; 
            getHabListHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo($"La lista de habilitaciones es:\n{Singleton<ContenedorPrincipal>.Instancia.ContenedorRubrosHabs.textoListaHabilitaciones()}"));
        }
        /// <summary>
        /// En este test, un usuario busca registrarse como emprendedor.
        /// Con ese objetivo en mente, utiliza "registrarme" y va llenando los campos que corresponden a medida
        /// que le vayan surgiendo.
        /// Con esto, queda demostrado el correcto funcionamiento del RegistroEmprendedorHandler.
        /// </summary>
        [Test]
         public void RegistroEmprendedorHandlerTestBien()
        {
            ContenedorPrincipal container = Singleton<ContenedorPrincipal>.Instancia;

            Message message = new Message(); 

            User usuario = new User(); 
            usuario.Id = 130;
            message.From = usuario;
            
            Chat chat1 = new Chat();  

            message.Chat = chat1; 
            message.Chat.Id = 130;
            message.Text = "/registrarme"; 

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(message); 

            IMensaje msg = teleadapter; 
            container.HistorialDeChats.Add(msg.Id, new HistorialChat()); 

            IHandler registroEmprendedorHandlerResult = new RegistroEmprendedorHandler(null);
            string response; 
            registroEmprendedorHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese el nombre"));

            message.Text = "TestName";
            msg = teleadapter;
            registroEmprendedorHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese la ubicacion"));

            message.Text = "TestUbi";
            msg = teleadapter;
            registroEmprendedorHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo($"Ingrese rubro\n {Singleton<ContenedorPrincipal>.Instancia.ContenedorRubrosHabs.textoListaRubros()}"));

            message.Text = "textil";
            msg = teleadapter;
            registroEmprendedorHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese especializaciones"));

            message.Text = "TestEspe";
            msg = teleadapter;
            registroEmprendedorHandlerResult.Handle(msg, out response);
            string nombreEmprendedor = "TestName";
            string ubicacionEmprendedor = "TestUbi";
            string rubroEmprendedor = "textil";
            string especializacionesEmprendedor = "TestEspe";
            Assert.That(response, Is.EqualTo($"Usted se ha registrado como un Emprendedor con el nombre {nombreEmprendedor}, ubicado en {ubicacionEmprendedor}, con el rubro {rubroEmprendedor}, y la especializacion {especializacionesEmprendedor}. {OpcionesUso.AccionesEmprendedor()}"));
        }
    }
}