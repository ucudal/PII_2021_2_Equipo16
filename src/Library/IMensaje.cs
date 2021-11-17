namespace ClassLibrary
{
    using Telegram.Bot.Types;
    
    /// <summary>
    /// Esta interfaz contiene los datos requerido para los envios de mensajes.
    /// Mediante el uso de esta interfaz, se puede incluir el comportamiento de varias fuentes en una clase.
    /// </summary>
    public interface IMensaje
    {
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        string Id {get;}

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        string Text {get;}
    }
}