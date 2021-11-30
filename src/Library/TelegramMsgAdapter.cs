using Telegram.Bot.Types;

namespace ClassLibrary
{
    /// <summary>
    /// La clase que encapsula el mensaje que recibe
    /// En este caso se aplicó el patrón Adapter para poder adaptar el mensaje recibido por Telegram.
    /// </summary>
    public class TelegramMsgAdapter : IMensaje
    {
        /// <summary>
        /// El mensaje recibido desde Telegram.
        /// </summary>
        public Message Mensaje;

        /// <summary>
        /// Inicializa una instancia de la clase TelegramMsgAdapter
        /// </summary>
        /// <param name="msg">Recibe un tipo Message de Telegram.</param>
        public TelegramMsgAdapter(Message msg)
        {
            this.Mensaje = msg;
        }

        /// <summary>
        /// Obtiene el ID de los mensajes del chat.
        /// </summary>
        /// <value></value>
        public string Id
        {
            get
            {
                return this.Mensaje.Chat.Id.ToString();
            }
        }

        /// <summary>
        /// Obtiene el mensaje.
        /// </summary>
        /// <value></value>
        public string Text
        {
            get
            {
                return this.Mensaje.Text;
            }
        }
    }
}