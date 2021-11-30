namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/listadehabilitaciones" y se encarga
    /// de manejar el caso en que se quieran ver las habilitaciones.
    /// </summary>
    public class GetHabListHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="GetHabListHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public GetHabListHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/listadehabilitaciones" };
        }

        /// <summary>
        /// Procesa el mensaje para que se muetre una lista con las habilitaciones.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/listadehabilitaciones"))
            {
                respuesta = string.Empty;
                return false;    
            }
            
            Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].MensajesDelUser.Add(mensaje.Text); 
            Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
            respuesta = $"La lista de habilitaciones es:\n{Singleton<ContenedorPrincipal>.Instancia.ContenedorRubrosHabs.TextoListaHabilitaciones()}";
            return true;
        }
    }
} 
