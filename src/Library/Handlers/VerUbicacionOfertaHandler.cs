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
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/ubicacionoferta" y se encarga
    /// de manejar el caso en que se quiera conocer la Ubicación de la Oferta.
    /// </summary>
    /// <remarks>
    /// Utiliza la API de Ubicación.
    /// </remarks>
    public class VerUbicacionOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="VerUbicacionOfertaHandler"/>.
        /// </summary>
        /// <param name="client">Recibe por parametro el bot de origen.</param>
        /// <param name="next">Handler siguiente.</param>
        public VerUbicacionOfertaHandler(TelegramBotClient client, BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/ubicacionoferta" };
            this.bot = client;
        }

        private TelegramBotClient bot;

        /// <summary>
        /// Procesa el mensaje para que se pueda conocer la Ubicación de la Oferta.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
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
                
                // Se le pide al emprendedor que ingrese la ubicacion de la oferta que quiere consultar.
                if (listaConParametros.Count == 0)
                {
                    respuesta = $"Ingrese la ubicacion de la oferta.";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    if (Singleton<ContenedorPrincipal>.Instancia.Emprendedores.ContainsKey(mensaje.Id))
                    {              
                        this.Direccion(mensaje, listaConParametros[0]);

                        respuesta = string.Empty;
                        return true;                
                    }
                    else
                    {
                        respuesta = $"Usted no es un emprendedor, no puede usar este comando.";
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
        /// <param name="mensaje">El mensaje.</param>
        /// <param name="nombreOferta">El nombre de la oferta.</param>
        /// <returns>Retorna una imagen con la dirección.</returns>
        public async Task Direccion(IMensaje mensaje, string nombreOferta)
        {
            Emprendedor value = Singleton<ContenedorPrincipal>.Instancia.Emprendedores[mensaje.Id];
            string direccion = value.Ubicacion.NombreCalle;
            LocationApiClient client = new LocationApiClient();

            // Utilizando los datos ingresados por parametros, se crea una variable Location con los datos.
            // Al emprendedor se le asigna una variable y a la ubicacion de la oferta otra variable del mismo tipo para poder generar la ruta de ubicacion en el mapa.
            Location direccionActual = await client.GetLocationAsync(direccion);
            Location direccionOferta = await client.GetLocationAsync(nombreOferta);

            await client.DownloadMapAsync(direccionActual.Latitude, direccionActual.Longitude, @$"..\UbicacionesMaps\ubicacion{value.Nombre}.png");
            await client.DownloadMapAsync(direccionOferta.Latitude, direccionOferta.Longitude, @$"..\UbicacionesMaps\ubicacion{value.Nombre}Oferta.png");
            await client.DownloadRouteAsync(direccionActual.Latitude, direccionActual.Longitude, direccionOferta.Latitude, direccionOferta.Longitude, @$"..\UbicacionesMaps\ubicacion{value.Nombre}Oferta.png");

            // Este método se utiliza para poder inviable el mensaje con el mapa al usuario.
            this.SendProfileImage(mensaje);        
        }

        private async Task SendProfileImage(IMensaje mensaje)
        {
            // Can be null during testing
            Emprendedor value = Singleton<ContenedorPrincipal>.Instancia.Emprendedores[mensaje.Id];
            await this.bot.SendChatActionAsync(mensaje.Id, ChatAction.UploadPhoto);
            string filePath = @$"..\UbicacionesMaps\ubicacion{value.Nombre}Oferta.png";
            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();
            await this.bot.SendPhotoAsync(chatId: mensaje.Id, photo: new InputOnlineFile(fileStream, fileName),caption: $"Ruta al objetivo. {OpcionesUso.AccionesEmprendedor()}");
        }
    }
}