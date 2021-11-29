using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "/verubicacion".
    /// </summary>
    public class VerUbicacionEmprendedorHandler: BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="client">Recibe por parametro el bot de origen.</param>
        /// <param name="next">Recibe por parametro el siguiente Handler.</param>
        /// <returns></returns>
        public VerUbicacionEmprendedorHandler(TelegramBotClient client, BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/verubicacion"};
            this.bot = client;
        }
        private TelegramBotClient bot;

        /// <summary>
        /// Este método procesa el mensaje "/verubicacion" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por parametro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
         protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/verubicacion"))
            {
                respuesta = string.Empty;
                return false;
            }

            if (Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/verubicacion") == true)
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/verubicacion");
                if (Singleton<ContenedorPrincipal>.Instancia.Emprendedores.ContainsKey(mensaje.Id))
                {   
                    
                    Direccion(mensaje);

                    SendProfileImage(mensaje);

                    respuesta = "";
                    return true;
                    
                }
                else
                {
                    respuesta = $"Usted no es una emprendedor, no puede usar este comando.";
                    return true;
                }
            }
            
            respuesta = string.Empty;
            return false;
        }       

        /// <summary>
        /// Este método utiliza la dirección del emprendedor para encontrar su ubicacion con la LocationApi.
        /// Las imagenes de ubicacion obtenidas las almacena en una carpeta por nombre del usuario.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public async Task Direccion(IMensaje mensaje)
        {
            Emprendedor value = Singleton<ContenedorPrincipal>.Instancia.Emprendedores[mensaje.Id];
            string direccion = value.Ubicacion.NombreCalle;
            LocationApiClient client = new LocationApiClient();

            Location direccionActual = await client.GetLocationAsync(direccion);
            await client.DownloadMapAsync(direccionActual.Latitude, direccionActual.Longitude,@$"..\UbicacionesMaps\ubicacion{value.Nombre}.png");
        }
        private async Task SendProfileImage(IMensaje mensaje)
        {
            // Can be null during testing
            Emprendedor value = Singleton<ContenedorPrincipal>.Instancia.Emprendedores[mensaje.Id];
            
            await bot.SendChatActionAsync(mensaje.Id, ChatAction.UploadPhoto);
            string filePath = @$"..\UbicacionesMaps\ubicacion{value.Nombre}.png";
            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();
            await bot.SendPhotoAsync(chatId: mensaje.Id, photo: new InputOnlineFile(fileStream, fileName),caption: $"Direccion de la Empresa");
        
        }
    }
}