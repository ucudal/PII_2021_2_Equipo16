namespace ClassLibrary
{
    /// <summary>
    /// Esta interface sirve para interactuar con la Aplicación de Telegram.
    /// </summary>
    /// /// <remarks>
    /// Mediante el uso de esta interfaz, se puede incluir el comportamiento de varias fuentes en una clase.
    /// </remarks>
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