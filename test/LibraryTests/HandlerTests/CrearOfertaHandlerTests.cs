namespace Test.Library
{
    using ClassLibrary;
    using NUnit.Framework;
    using Telegram.Bot.Types;
    
    /// <summary>
    /// Esta clase permite realizar los tests de la clase Emprendedor.
    /// </summary>
    [TestFixture]
    public class CrearOfertaHandlerTests
    {
        CrearOfertaHandler handler;
        Message mensaje;
        TelegramMsgAdapter telegramMsgAdapter;
        Singleton<ContenedorPrincipal> contenedorPrincipal;

        /// <summary>
        /// 
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            mensaje = new Message();
            telegramMsgAdapter = new TelegramMsgAdapter(mensaje);
            CrearOfertaHandler handler = new CrearOfertaHandler(null);
            contenedorPrincipal = Singleton<ContenedorPrincipal>.Instance;
            
        }
  
        /// <summary>
        /// 
        /// </summary>
        [Test]
        public void BuscadorTagHandlerTest()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        public void BuscadorMaterialHandlerTest()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public void BuscadorUbicacionHandlerTest()
        {
            
        }
    }




    namespace ProgramTests
{
    /// <summary>
    /// Esta clase prueba el handler Registro.
    /// </summary>
    public class RegistroHandlerTests
    {
        Registro handler;
        Message message;

        TelegramMSGadapter msj;
        Contenedor db;
        Rubro rubroTest;


        /// <summary>
        ///Crea una instancia de contenedor, el handler a probar, un rubro, el message asi como asignarle una ID. Y ademas
        /// crea una instancia de TelegramMSG adapter.
        /// </summary>
        [SetUp]
        public void Setup() //Deberiamos hacer uno por mensage o uno por proceso????
        {
            Rubro rubroTest = new Rubro("Prueba","Prueba","Prueba");
            db = Contenedor.Instancia;
            db.AddRubro(rubroTest);
            handler = new Registro(null);
            message = new Message();
            message.From = new User();
            message.From.Id = 1454175798;
            msj = new TelegramMSGadapter(message);
        }

        /// <summary>
        /// Este test prueba como se procesan los mensajes para el registro de un emprendedor (usuario con una ID
        /// no invitada).
        /// </summary>
        [Test]
        public void TestRegistroEmprendedorHandle()
        {
            message.Text = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(msj, out response);

            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Se procedera con su registro como emprendedor."+"\n"+"\n"+"Ingrese su nombre:"
                ));
            
            message.Text = "NombreEmprendedor";
            handler.Handle(msj, out response);
            string opciones = "";
            int i =0;
            foreach (Rubro rubro in db.Rubros)
            {
                opciones = opciones + i.ToString() + " - " + rubro.Nombre +"\n";
                i++;
            }
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Su nombre es: "+"NombreEmprendedor"+"\n"+"\n"+"Seleccione su rubro:\n" + opciones
                ));
            
            message.Text = "rubro"; 
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "No se ha ingresado un número, ingrese un numero válido."
                ));

            message.Text = "80";
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Usted ha ingresado un número incorrecto, por favor vuelva a intentarlo"
                ));
            
            message.Text = "0";
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Su rubro es: "+ db.Rubros[0].Nombre +"\n"+"\n"+"Ahora ingrese su ciudad:"
                ));

            message.Text = "montevideo";
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Su ciudad es: "+"montevideo"+"\n"+"\n"+"Ahora ingrese su calle:"
                ));
            
            message.Text = "calle 8";
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Su calle es: " + "calle 8" + "\n"+"\n"+"Ahora ingrese su especialización:"
                ));

            message.Text="madera";
            handler.Handle(msj, out response);
            Assert.That(result, Is.Not.Null);
            Assert.That(response, Is.EqualTo(
                "Emprendedor NombreEmprendedor del rubro Prueba ha sido registrado correctamente!"+"\n"+$"Su domicilio a sido fijado a montevideo, calle 8" + "\n" + "\n" + "Recuerda que si desea agregar una habilitacion, debera utilizar el comando /AddHabilitacion"
                ));
        }