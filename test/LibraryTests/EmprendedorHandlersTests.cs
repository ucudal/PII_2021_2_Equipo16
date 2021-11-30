
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
        /// 
        /// </summary>

        [Test]
        public void BuscadorTagHandlerTestBien()
        {

            Message mensaje = new Message();
            mensaje.From = new User();
            mensaje.From.Id = 2;
            
            ContenedorPrincipal contenedorPrincipal = Singleton<ContenedorPrincipal>.Instancia;
            
            
            BuscadorTagHandler buscadorTagHandler = new BuscadorTagHandler(null);
            BuscadorMaterialHandler buscadorMaterialHandler = new BuscadorMaterialHandler(null);
            BuscadorUbicacionHandler buscadorUbicacionHandler = new BuscadorUbicacionHandler(null);
            
            IMensaje mensaje2 = new TelegramMsgAdapter(mensaje);
            string respuesta;
            IHandler buscadorTagHandlerResult = new BuscadorTagHandler(null);
            buscadorTagHandlerResult.Handle(mensaje2, out respuesta);
            mensaje.Text = buscadorTagHandler.Keywords[0];
            Assert.That(respuesta, Is.EqualTo("Ingrese el Tag por el que sea filtrar en su búsqueda."));

            buscadorTagHandlerResult.Handle(mensaje2, out respuesta);
            string palabraClave = "quirurgico";
            mensaje.Text = palabraClave;
            Assert.That(respuesta, Is.EqualTo($"{TelegramPrinter.BusquedaPrinter(LogicaBuscadores.BuscarPorTags(palabraClave))} {OpcionesUso.AccionesEmprendedor()}"));
        }
    }
}