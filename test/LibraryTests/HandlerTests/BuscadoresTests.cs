namespace Test.Library
{
    using ClassLibrary;
    using NUnit.Framework;
    using Telegram.Bot.Types;
    
    /// <summary>
    /// Esta clase permite realizar los tests de la clase Emprendedor.
    /// </summary>
    [TestFixture]
    public class BuscadorTagHandlerTests
    {
        Message mensaje;
        BuscadorTagHandler buscadorTagHandler;
        BuscadorMaterialHandler buscadorMaterialHandler;
        BuscadorUbicacionHandler buscadorUbicacionHandler;
        TelegramMsgAdapter telegramMsgAdapter;

        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            mensaje = new Message();
            
            ContenedorPrincipal contenedorPrincipal = Singleton<ContenedorPrincipal>.Instancia;

            buscadorTagHandler = new BuscadorTagHandler(null);
            buscadorMaterialHandler = new BuscadorMaterialHandler(null);
            buscadorUbicacionHandler = new BuscadorUbicacionHandler(null);
            
            telegramMsgAdapter = new TelegramMsgAdapter(mensaje);
            
            mensaje.From = new User();
            mensaje.From.Id = 1231231321;
        }
  
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void BuscadorTagHandlerTest()
        {
            string respuesta;
            IHandler buscadorTagHandlerResult = buscadorTagHandler.Handle(telegramMsgAdapter, out respuesta);
            mensaje.Text = buscadorTagHandler.Keywords[0];
            Assert.That(respuesta, Is.EqualTo("Ingrese el Tag por el que sea filtrar en su búsqueda."));

            buscadorTagHandlerResult.Handle(telegramMsgAdapter, out respuesta);
            mensaje.Text = buscadorTagHandler.Keywords[1];
            Assert.That(respuesta, Is.EqualTo($"{TelegramPrinter.BusquedaPrinter(LogicaBuscadores.BuscarPorTags(palabraClave))} {OpcionesUso.AccionesEmprendedor()}"));
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void BuscadorMaterialHandlerTest()
        {
            string respuesta;
            mensaje.Text = buscadorMaterialHandler.Keywords[0];

            IHandler buscadorMaterialHandlerResult = buscadorMaterialHandler.Handle(telegramMsgAdapter, out respuesta);
        }

        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void BuscadorUbicacionHandlerTest()
        {
            string respuesta;
            mensaje.Text = buscadorUbicacionHandler.Keywords[0];

            IHandler buscadorUbicacionHandlerResult = buscadorUbicacionHandler.Handle(telegramMsgAdapter, out respuesta);
        }
    }
}