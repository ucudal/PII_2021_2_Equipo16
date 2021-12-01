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
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/verubicacion" y se encarga
    /// de manejar el caso en que se quiera conocer la Ubicación del Emprendedor.
    /// </summary>
    /// <remarks>
    /// Utiliza la API de Ubicación.
    /// </remarks>
    public class VerUbicacionEmprendedorHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="VerUbicacionEmprendedorHandler"/>.
        /// </summary>
        /// <param name="client">Recibe por parametro el bot de origen.</param>
        /// <param name="next">Handler siguiente.</param>
        public VerUbicacionEmprendedorHandler(TelegramBotClient client, BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/verubicacion" };
            this.bot = client;
        }

        private TelegramBotClient bot;

        /// <summary>
        /// Procesa el mensaje para que se pueda conocer la Ubicación del Emprendedor.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/verubicacion"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/verubicacion") == true)
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/verubicacion");
                if (Singleton<ContenedorPrincipal>.Instancia.Emprendedores.ContainsKey(mensaje.Id))
                {    
                    this.Direccion(mensaje);

                    respuesta = string.Empty;
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
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <returns>Retorna una imagen con la dirección.</returns>
        public async Task Direccion(IMensaje mensaje)
        {
            Emprendedor value = Singleton<ContenedorPrincipal>.Instancia.Emprendedores[mensaje.Id];
            string direccion = value.Ubicacion.NombreCalle;
            LocationApiClient client = new LocationApiClient();

            Location direccionActual = await client.GetLocationAsync(direccion);
            await client.DownloadMapAsync(direccionActual.Latitude, direccionActual.Longitude,@$"..\UbicacionesMaps\ubicacion{value.Nombre}.png");

            // Este método se utiliza para poder inviable el mensaje con el mapa al usuario.
            this.SendProfileImage(mensaje);
        }

        private async Task SendProfileImage(IMensaje mensaje)
        {
            // Can be null during testing.
            Emprendedor value = Singleton<ContenedorPrincipal>.Instancia.Emprendedores[mensaje.Id];
            await this.bot.SendChatActionAsync(mensaje.Id, ChatAction.UploadPhoto);
            string filePath = @$"..\UbicacionesMaps\ubicacion{value.Nombre}.png";
            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();
            await this.bot.SendPhotoAsync(chatId: mensaje.Id, photo: new InputOnlineFile(fileStream, fileName),caption: $"Direccion de la Empresa.\n {OpcionesUso.AccionesEmprendedor()}");
        }
    }
}