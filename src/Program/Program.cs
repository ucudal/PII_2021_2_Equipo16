//--------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using ClassLibrary;
using System.Threading;
using System.Text.Json;
using System.Threading.Tasks;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ConsoleApplication
{
    /// <summary>
    /// 
    /// </summary>
    public static class Program
    {
        // La instancia del bot.
        private static TelegramBotClient Bot;

        // El token provisto por Telegram al crear el bot.
        //
        // *Importante*:
        // Para probar este ejemplo, crea un bot nuevo y eeemplaza este token por el de tu bot.
        private static string Token = "2100835603:AAHgL1rK6jaRjti3_9Ria8UUlCV8xj0Go7E";

        private static IHandler firstHandler;

        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            Administrador admin = new Administrador("Admin", "Equipo16");
            Empresa empresaTest = new Empresa("conaprole", "pakistan", "textil");
            admin.InvitarEmpresa(empresaTest);
            
            Bot = new TelegramBotClient(Token);

            JsonSerializerOptions opciones = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };  

            if (System.IO.File.Exists(@"..\Library\Persistencia\Contenedor.json"))
            {
                string contenedorToJson = System.IO.File.ReadAllText(@"..\Library\Persistencia\Contenedor.json");
                Singleton<ContenedorPrincipal>.Instancia = JsonSerializer.Deserialize<ContenedorPrincipal>(contenedorToJson, opciones);  
            }

<<<<<<< HEAD
            firstHandler = new HolaHandler(
                new RegistroEmprendedorHandler(
                    new RemoverHabEmprendedor(
                        new AceptarInvEmpresaHandler(
                            new AceptarOfertaHandler(
                                new AgregarHabEmpresaHandler(
                                    new BuscadorMaterialHandler(
                                        new BuscadorTagHandler(
                                            new BuscadorUbicacionHandler(
                                                new CalcularOfertasCompradasHandler(
                                                    new CalcularOfertasVendidasHandler(
                                                        new AddHabOfertaHandler(
                                                            new CrearOfertaHandler(
                                                                new RemoverOfertaHandler(
                                                                    new GetHabListHandler(
                                                                        new InteresadoEnOfertaHandler(
                                                                            new RemoveHabEmpresaHandler(
                                                                                new RemoverHabOfertaHandler(
                                                                                    new AgregarHabEmprendedorHandler(
                                                                                        new ComandosHandler(new VerInteresados(
                                                                                            new VerEmpresaHandler(
                                                                                                new VerEmprendedorHandler(
                                                                                                    new CrearEmpresaAdminHandler(
                                                                                                        new InvitarEmpresaHandler(
                                                                                                            new CambioClaveHandler(
                                                                                                                new RegistrarAdminHandler(
                                                                                                                    new VerUbicacionEmprendedorHandler(
                                                                                                                        Bot, new VerMisOfertasHandler(
                    null)))))))))))))))))))))))))))));
=======
            firstHandler = new HolaHandler(new RegistroEmprendedorHandler(new RemoverHabEmprendedor(new AceptarInvEmpresaHandler(new AceptarOfertaHandler(new AddHabEmpresaHandler(new BuscadorMaterialHandler(new BuscadorTagHandler(new BuscadorUbicacionHandler(new CalcularOfertasCompradasHandler(new CalcularOfertasVendidasHandler(new AddHabOfertaHandler(new CrearOfertaHandler(new EliminarOfertaHandler(new GetHabListHandler(new InteresadoEnOfertaHandler(new RemoveHabEmpresaHandler(new RemoverHabOfertaHandler(new AddHabEmprendedorHandler(new ComandosHandler(new VerInteresados(new VerEmpresaHandler(new VerEmprendedorHandler(new CrearEmpresaAdminHandler(new InvitarEmpresaHandler(new CambioClaveHandler(new RegistrarAdminHandler(new VerUbicacionEmprendedorHandler(Bot, new VerMisOfertasHandler(null)))))))))))))))))))))))))))));
>>>>>>> 2fd0325c9d3fa143c4fc8ad9ece45580849bd0f0
           
            Message message = new Message();
            
            //string response;
            //IHandler result = firstHandler.Handle(new TelegramMsgAdapter(message), out response);

            Console.WriteLine("Escribí un comando o 'salir':");
            Console.Write("> ");

            var cts = new CancellationTokenSource();

            // Comenzamos a escuchar mensajes. Esto se hace en otro hilo (en background). El primer método
            // HandleUpdateAsync es invocado por el bot cuando se recibe un mensaje. El segundo método HandleErrorAsync
            // es invocado cuando ocurre un error.
            Bot.StartReceiving(
                new DefaultUpdateHandler(HandleUpdateAsync, HandleErrorAsync),
                cts.Token
            );

            Console.WriteLine($"Bot is up!");

            // Esperamos a que el usuario aprete Enter en la consola para terminar el bot.
            Console.ReadLine();

            Console.WriteLine("[BOT DETENIDO]");
            string contenedorToJson1 = Singleton<ContenedorPrincipal>.Instancia.ConvertirJson();
            System.IO.File.WriteAllText(@"..\Library\Persistencia\Contenedor.json", contenedorToJson1); 

            // Terminamos el bot.
            cts.Cancel();
        }
        
        /// <summary>
        /// Maneja las actualizaciones del bot (todo lo que llega), incluyendo mensajes, ediciones de mensajes,
        /// respuestas a botones, etc. En este ejemplo sólo manejamos mensajes de texto.
        /// </summary>
        public static async Task HandleUpdateAsync(Update update, CancellationToken cancellationToken)
        {
            try
            {
                // Sólo respondemos a mensajes de texto
                if (update.Type == UpdateType.Message)
                {
                    await HandleMessageReceived(update.Message);
                }
            }
            catch(Exception e)
            {
                await HandleErrorAsync(e, cancellationToken);
            }
        }

        /// <summary>
        /// Maneja los mensajes que se envían al bot.
        /// Lo único que hacemos por ahora es escuchar 3 tipos de mensajes:
        /// - "hola": responde con texto
        /// - "chau": responde con texto
        /// - "foto": responde con una foto
        /// </summary>
        /// <param name="message">El mensaje recibido</param>
        /// <returns></returns>
        private static async Task HandleMessageReceived(Message message)
        {
            Console.WriteLine($"Received a message from {message.From.Id} saying: {message.Text}");

            string response = string.Empty;

            firstHandler.Handle(new TelegramMsgAdapter(message), out response);

            if (!string.IsNullOrEmpty(response))
            {
                await Bot.SendTextMessageAsync(message.Chat.Id, response);
            }
        }

        /// <summary>
        /// Manejo de excepciones. Por ahora simplemente la imprimimos en la consola.
        /// </summary>
        public static Task HandleErrorAsync(Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.Message);
            return Task.CompletedTask;
        }
    }
}