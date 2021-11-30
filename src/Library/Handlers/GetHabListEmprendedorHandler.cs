namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/listadehabilitaciones".
    /// </summary>
    public class GetHabListHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        /// <param name="next">Recibe por parametro el siguiente Handler.</param>
        public GetHabListHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/listadehabilitaciones"};
        }

        /// <summary>
        /// Procesa el mensaje "Lista de habilitaciones" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por parametro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/listadehabilitaciones"))
            {
                respuesta = string.Empty;
                return false;    
            }
            
            Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].MensajesDelUser.Add(mensaje.Text); 
            Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
            respuesta = $"La lista de habilitaciones es:\n{Singleton<ContenedorPrincipal>.Instancia.ContenedorRubrosHabs.textoListaHabilitaciones()}";
            return true;
        }
    }
} 
