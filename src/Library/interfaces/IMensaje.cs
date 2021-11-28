using Telegram.Bot.Types;

namespace ClassLibrary
{  
    /// <summary>
    /// Esta interfaz contiene los datos requerido para los envios de mensajes.
    /// Mediante el uso de esta interfaz, se puede incluir el comportamiento de varias fuentes en una clase.
    /// </summary>
    public interface IMensaje
    {
        /// <summary>
        /// Esta property contiene la identificacion unica del Usuario, que interactua en la app.
        /// </summary>
        /// <value>El valor esta dado por el token asignado por Telegram.</value>
        string Id {get;}

        /// <summary>
        /// Esta property contiene el mensaje ingresado pro el Usuario.
        /// </summary>
        /// <value>El valor esta dado por una cadena de caracteres ingresador por el Usuario.</value>
        string Text {get;}
    }
}