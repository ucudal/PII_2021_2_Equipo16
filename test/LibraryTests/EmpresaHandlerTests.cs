
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
        Message mensaje;
        TelegramMsgAdapter test;
        ContenedorPrincipal contenedorPrincipal;
        CrearOfertaHandler crearOfertaHandlerResult;
        HistorialChat testchat = new HistorialChat();
        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void Setup()
        {
            



        }
        [Test]
        public void  CrearOfertaHandlerTest()
        {
            ContenedorPrincipal contenedorPrincipal = Singleton<ContenedorPrincipal>.Instancia;
            contenedorPrincipal.Empresas.Add("123", new Empresa("Empresa1", "ubi","textil"));

            mensaje = new Message();
            User usuario = new User();
            usuario.Id = 1234;
            mensaje.From = usuario;

            Chat chat = new Chat();
            mensaje.Chat = chat;
            mensaje.Chat.Id = 123;
            mensaje.Text = "/crearoferta";


            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(mensaje); 
            IMensaje msg = teleadapter; 

            contenedorPrincipal.HistorialDeChats.Add(msg.Id, new HistorialChat());

            IHandler crearOfertaHandlerResult = new CrearOfertaHandler(null); 

            string response;

            crearOfertaHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese el nombre de la oferta"));

            string palabraClave = "ofertaTest";
            mensaje.Text = palabraClave;
            msg = teleadapter;
            crearOfertaHandlerResult.Handle(msg, out response);
            
            Assert.That(response, Is.EqualTo("Ingrese el tipo del material:\n-Reciclado\n-Residuo"));

            string palabraClave2 = "Reciclado";
            mensaje.Text = palabraClave2;
            msg = teleadapter;

            crearOfertaHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese el precio"));

            
            string palabraClave3 = "100";
            mensaje.Text = palabraClave3;
            msg = teleadapter;

            crearOfertaHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese unidad"));

            
            string palabraClave4 = "unidades";
            mensaje.Text = palabraClave4;
            msg = teleadapter;

            crearOfertaHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese un tag o palabra clave"));

            string palabraClave5 = "tagTest";
            mensaje.Text = palabraClave5;
            msg = teleadapter;

            crearOfertaHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Ingrese una ubicación"));

            
            string palabraClave6 = "Av 8 de Oct";
            mensaje.Text = palabraClave6;
            msg = teleadapter;

            crearOfertaHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("Elija si es una oferta puntual o constante"));

            string palabraClave7 = "constante";
            mensaje.Text = palabraClave7;
            msg = teleadapter;

            crearOfertaHandlerResult.Handle(msg, out response);
            Assert.That(response, Is.EqualTo($"Se ha registrado con nombre {palabraClave}, de material {palabraClave2}, del tipo {palabraClave7}, unidades: {palabraClave4}, al precio de: {palabraClave3}, con la ubicación en {palabraClave6} y el tag {palabraClave5}. {OpcionesUso.AccionesEmpresas()}"));



        }

        /// <summary>
        /// Test que evalúa lo sucedido al crear una instancia de tipo Oferta.
        /// </summary>
        [Test]
        public void AddHabOfertaHandlerTest()
        {
            ContenedorPrincipal contiene = Singleton<ContenedorPrincipal>.Instancia;
            Empresa empresaTest1 = new Empresa("Empresa1", "ubi", "textil");
            
            contiene.Publicaciones.OfertasPublicados.Add(new Oferta("oferta1", "mat", "1000", "299", "kilo", "tag1", "ubi1", "constante", empresaTest1 ));

            
            Message message = new Message(); 

            User usuario = new User(); 
            usuario.Id = 1234;
            message.From = usuario;
            
            Chat chat1 = new Chat();  

            message.Chat = chat1; 
            message.Chat.Id = 123;
            message.Text = "/addhaboferta";

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(message); 

            IMensaje msg = teleadapter; 
            
            contiene.HistorialDeChats.Add(msg.Id, new HistorialChat()); 
            
            string response; 

            IHandler first = new AddHabOfertaHandler(null); 
            first.Handle(msg, out response); 
            
            Assert.That(response, Is.EqualTo("Ingrese el nombre de la oferta a la que desea agregar una habilitación."));

            message.Text = "Oferta1"; 

            
            msg = teleadapter; 
            first.Handle(msg, out response);
            Assert.That(response, Is.EqualTo( $"Ingrese el nombre de la habilitación que desea agregar.\n{Singleton<ContenedorPrincipal>.Instancia.ContenedorRubrosHabs.textoListaHabilitaciones()}"));

             message.Text = "apa"; 

            
            msg = teleadapter; 
            first.Handle(msg, out response);
            Assert.That(response, Is.EqualTo( $"Ingrese el nombre de la habilitación que desea agregar.\n{Singleton<ContenedorPrincipal>.Instancia.ContenedorRubrosHabs.textoListaHabilitaciones()}"));
            
            
        }
    }
}