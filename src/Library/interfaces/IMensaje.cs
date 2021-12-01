namespace ClassLibrary
{
    /// <summary>
    /// Esta interfaz contiene los datos requerido para los envios de mensajes.
    /// Mediante el uso de esta interfaz, se puede incluir el comportamiento de varias fuentes en una clase.
    /// </summary>
    public interface IMensaje
    {
        /// <summary>
        /// Obtiene la identificacion unica del Usuario, que interactua en la App.
        /// </summary>
        /// <value>El valor esta dado por el token asignado por Telegram.</value>
        string Id { get; }

        /// <summary>
        /// Obtiene el mensaje ingresado pro el Usuario.
        /// </summary>
        /// <value>El valor esta dado por una string que ingresa el Usuario.</value>
        string Text { get; }
    }
}