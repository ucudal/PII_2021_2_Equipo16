using System.Collections.Generic;
using System;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class GetHabListHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public GetHabListHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/listadehabilitaciones"};
        }

        /// <summary>
        /// Procesa el mensaje "Lista de habilitaciones" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
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
            respuesta = $"La lista de habilitaciones es:\n{Singleton<ContenedorRubroHabilitaciones>.Instancia.textoListaHabilitaciones()}";
            return true;
            
            
            
        }
    }
} 
