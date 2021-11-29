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
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "/ubicacionoferta".
    /// </summary>
    public class VerUbicacionOfertaHandler: BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="client">Recibe por parametro el bot de origen.</param>
        /// <param name="next">Recibe por parametro el siguiente Handler.</param>
        /// <returns></returns>
        public VerUbicacionOfertaHandler(TelegramBotClient client, BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/ubicacionoferta"};
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
            if (!this.ChequearHandler(mensaje, "/ubicacionoferta"))
            {
                respuesta = string.Empty;
                return false;
            }
            
            if (Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/ubicacionoferta") == true)
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/ubicacionoferta");
                if (listaConParametros.Count == 0)
                {
                    respuesta = $"Ingrese la ubicacion de la oferta.";
                    return true;
                }
                if (listaConParametros.Count == 1)
                {
                    if (Singleton<ContenedorPrincipal>.Instancia.Emprendedores.ContainsKey(mensaje.Id))
                    {   
                        
                        Direccion(mensaje, listaConParametros[0]);

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
            }
            
            respuesta = string.Empty;
            return false;
        }       

        /// <summary>
        /// Este método utiliza la dirección del emprendedor para encontrar su ubicacion con la LocationApi.
        /// Las imagenes de ubicacion obtenidas las almacena en una carpeta por nombre del usuario.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="nombreOferta"></param>
        /// <returns></returns>
        public async Task Direccion(IMensaje mensaje, string nombreOferta)
        {
            Emprendedor value = Singleton<ContenedorPrincipal>.Instancia.Emprendedores[mensaje.Id];
            string direccion = value.Ubicacion.NombreCalle;
            LocationApiClient client = new LocationApiClient();

            Location direccionActual = await client.GetLocationAsync(direccion);
            Location direccionOferta = await client.GetLocationAsync(nombreOferta);
            
            await client.DownloadMapAsync(direccionActual.Latitude, direccionActual.Longitude,@$"..\UbicacionesMaps\ubicacion{value.Nombre}.png");
            await client.DownloadMapAsync(direccionOferta.Latitude, direccionOferta.Longitude,@$"..\UbicacionesMaps\ubicacion{value.Nombre}Oferta.png");
            await client.DownloadRouteAsync(
                direccionActual.Latitude,
                direccionActual.Longitude,
                direccionOferta.Latitude,
                direccionOferta.Longitude,
                @$"..\UbicacionesMaps\ubicacion{value.Nombre}Oferta.png");
            
        }
        
        private async Task SendProfileImage(IMensaje mensaje)
        {
            // Can be null during testing
            Emprendedor value = Singleton<ContenedorPrincipal>.Instancia.Emprendedores[mensaje.Id];
            
            await bot.SendChatActionAsync(mensaje.Id, ChatAction.UploadPhoto);
            string filePath = @$"..\UbicacionesMaps\ubicacion{value.Nombre}Oferta.png";
            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();
            await bot.SendPhotoAsync(chatId: mensaje.Id, photo: new InputOnlineFile(fileStream, fileName),caption: $"Ruta al objetivo. {OpcionesUso.AccionesEmprendedor()}");
        
        }
    }
}