
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
        Message mensaje;
        TelegramMsgAdapter test;
        ContenedorPrincipal contenedorPrincipal;
        BuscadorTagHandler buscadorTagHandlerResult;
        HistorialChat testchat = new HistorialChat();
        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void Setup()
        {
            



        }
        [Test]
        public void BuscadorTagHandlerTestBien()
        {
            ContenedorPrincipal contenedorPrincipal = Singleton<ContenedorPrincipal>.Instancia;
            contenedorPrincipal.Emprendedores.Add("123", new Emprendedor("Emprendedor", "ubi", "textil", "espe"));
            Empresa empresaTest1 = new Empresa("Empresa1", "ubi", "textil");

            contenedorPrincipal.Publicaciones.OfertasPublicados.Add(new Oferta("Oferta1", "mat", "1000", "299", "kilo", "tagtest", "ubi", "constante", empresaTest1));

            mensaje = new Message();
            User usuario = new User();
            usuario.Id = 1234;
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
            
            Assert.That(response, Is.EqualTo("******************************\nNombre: Oferta1 \nMaterial: mat \nPrecio: 299 \nUnidad: kilo \nTag: tagtest \nUbicación: ubi \nEs una oferta constante \nRequerimientos: \n******************************\n\n  \nOpciones:\n- /agregarhabilitacionemprendedor \n- /buscarmaterial\n- /buscartag\n- /buscarubicacion\n- /calcularofertascompradas\n- /listadehabilitacionesemprendedor"));
        }

        /// <summary>
        /// Test que evalúa lo sucedido al crear una instancia de tipo Oferta.
        /// </summary>
        [Test]
        public void Test()
        {
            
            ContenedorPrincipal container = Singleton<ContenedorPrincipal>.Instancia;
            container.Emprendedores.Add("123", new Emprendedor("nombreEmprendedor", "ubi", "textil", "espe"));
            Empresa empresaTest1 = new Empresa("Empresa1", "ubi", "textil");
            
            container.Publicaciones.OfertasPublicados.Add(new Oferta("oferta1", "mat", "1000", "299", "kilo", "tag1", "ubi1", "constante", empresaTest1 ));

            
            Message message = new Message(); 

            User usuario = new User(); 
            usuario.Id = 1234;
            message.From = usuario;
            
            Chat chat1 = new Chat();  

            message.Chat = chat1; 
            message.Chat.Id = 123;
            message.Text = "/buscarmaterial"; 

            TelegramMsgAdapter teleadapter = new TelegramMsgAdapter(message); 

            IMensaje msg = teleadapter; 
            
            container.HistorialDeChats.Add(msg.Id, new HistorialChat()); 
            
            string response; 

            IHandler first = new BuscadorMaterialHandler(null); 
            first.Handle(msg, out response); 
            
            Assert.That(response, Is.EqualTo("Ingrese el tipo del material por el que desea filtrar en su búsqueda.\n-Reciclado\n-Residuo"));

            message.Text = "mat"; 

            
            msg = teleadapter; 
            first.Handle(msg, out response);
            Assert.That(response, Is.EqualTo("******************************\nNombre: oferta1 \nMaterial: mat \nPrecio: $299 \nUnidad: kilo \nCantidad: 1000 \nTag: tag1 \nUbicación: ubi1 \nEs una oferta constante \nRequerimientos: \n\n******************************\n"));
            
        }
    }
}