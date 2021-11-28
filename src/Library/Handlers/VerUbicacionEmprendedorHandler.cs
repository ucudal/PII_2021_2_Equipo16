using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InputFiles;

namespace ClassLibrary
{
    public class VerUbicacionEmprendedorHandler: BaseHandler
    {
        public VerUbicacionEmprendedorHandler(TelegramBotClient client, BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/verubicacion"};
            this.bot = client;
        }
        private TelegramBotClient bot;

         protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/verubicacion"))
            {
                respuesta = string.Empty;
                return false;
            }

            if (Singleton<Logica>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/verubicacion") == true)
            {
                List<string> listaConParametros = Singleton<Logica>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/verubicacion");
                if (Singleton<Logica>.Instancia.Emprendedores.ContainsKey(mensaje.Id))
                {
                    Emprendedor value = Singleton<Logica>.Instancia.Emprendedores[mensaje.Id];
                    string filePath = @$"ubicacion{value.Nombre}.png";
                    using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    
                    var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();

                    Direccion(mensaje);

                    SendProfileImage(mensaje);

                    respuesta = "";
                    return true;
                    

                    //string texto = LogicaEmprendedor.VerInteresados(value)+OpcionesUso.AccionesEmpresas();
                    //respuesta = texto;
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

        public async Task Direccion(IMensaje mensaje)
        {
            
            Emprendedor value = Singleton<Logica>.Instancia.Emprendedores[mensaje.Id];
            string direccion = value.Ubicacion;
            LocationApiClient client = new LocationApiClient();

            Location direccionActual = await client.GetLocationAsync(direccion);
            await client.DownloadMapAsync(direccionActual.Latitude, direccionActual.Longitude,@$"ubicacion{value.Nombre}.png");
        }
        private async Task SendProfileImage(IMensaje mensaje)
        {
            // Can be null during testing
            Emprendedor value = Singleton<Logica>.Instancia.Emprendedores[mensaje.Id];
            
            await bot.SendChatActionAsync(mensaje.Id, ChatAction.UploadPhoto);
            string filePath = @$"ubicacion{value.Nombre}.png";
            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var fileName = filePath.Split(Path.DirectorySeparatorChar).Last();
            await bot.SendPhotoAsync(chatId: mensaje.Id, photo: new InputOnlineFile(fileStream, fileName),caption: $"Direccion de la Empresa");
        
        }
    }
}