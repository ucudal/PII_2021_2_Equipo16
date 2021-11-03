namespace ClassLibrary
{
    /// <summary>
    /// Esta interface sirve para interactuar con la Aplicación de Telegram.
    /// </summary>
    public interface ITelegram 
    {
        /// <summary>
        /// Este método permite enviar mensajes.
        /// </summary>
        void SendMessage();
        
        /// <summary>
        /// Este método permite recibir mensajes.
        /// </summary>
        void RecibeMessage();
    }
}
