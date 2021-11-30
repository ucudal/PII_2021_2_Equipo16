using Telegram.Bot.Types;

namespace ClassLibrary
{
    /// <summary>
    /// La clase que encapsula el mensaje que recibe
    /// </summary>
    public class TelegramMsgAdapter : IMensaje
    {
        /// <summary>
<<<<<<< HEAD
        ///
=======
        /// El mensaje recibido desde Telegram.
>>>>>>> deV2
        /// </summary>
        public Message mensaje;

        /// <summary>
        /// Inicializa una instancia de la clase TelegramMsgAdapter
        /// </summary>
        /// <param name="msg">Recibe un tipo Message de Telegram</param>
        public TelegramMsgAdapter(Message msg)
        {
            this.mensaje = msg;
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Id
        {
            get
            {
                return this.mensaje.Chat.Id.ToString();
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <value></value>
        public string Text
        {
            get
            {
                return this.mensaje.Text;
            }
        }
    }
}