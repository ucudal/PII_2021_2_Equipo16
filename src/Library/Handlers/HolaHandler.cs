namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class HolaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="HolaHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public HolaHandler (BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "Hola", "hola" };
        }

        /// <summary>
        /// Este método procesa el mensaje "Hola".
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
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