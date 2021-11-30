namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class HolaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase. 
        /// Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">Recibe por parametro el siguiente Handler.</param>
        public HolaHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"Hola", "hola"};
        }

        /// <summary>
        /// Este método procesa el mensaje "Hola" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="mensaje">recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por parametro la respuesta al mensaje procesado. </param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (this.CanHandle(mensaje))
            {
                Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats.Add(mensaje.Id, new HistorialChat());

                respuesta = "Hola! por favor si le invitaron, escriba /aceptarinvitacion \nSi desea registrarse como emprendedor, escriba /registrarme \nCualquier duda use /comandos";
                return true;    
            }

            respuesta = string.Empty;
            return false;
        }
    }
}