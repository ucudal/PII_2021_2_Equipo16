namespace Test.Library
{
    using System;
    using Telegram.Bot.Types;

    /// <summary>
    /// La clase que encapsula el mensaje que recibe
    /// </summary>
    public class TelegramMsgAdapter : IMensaje
    {
        private Message mensaje;

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