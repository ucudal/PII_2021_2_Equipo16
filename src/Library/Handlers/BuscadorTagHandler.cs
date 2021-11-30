using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/buscartag" y se encarga
    /// de procesar el mensaje para buscar una oferta acorde con el Tag especificado.
    /// </summary>
    public class BuscadorTagHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BuscadorTagHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public BuscadorTagHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/buscartag" };
        }

        /// <summary>
        /// Procesa el mensaje para buscar una oferta según el tag.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (mensaje == null)
            {
                throw new ArgumentNullException("Message no puede ser nulo.");
            }
            else if (!this.ChequearHandler(mensaje, "/buscartag"))
            {
                respuesta = string.Empty;
                return false;
            }
            
            List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/buscartag");
            if (listaConParametros.Count == 0)
            {
                respuesta = "Ingrese el Tag por el que sea filtrar en su búsqueda.";
                return true;
            }
            else if (listaConParametros.Count == 1)
            {
                string palabraClave = listaConParametros[0];
                
                LogicaBuscadores.BuscarPorTags(palabraClave);
                Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                respuesta = $"{TelegramPrinter.BusquedaPrinter(LogicaBuscadores.BuscarPorTags(palabraClave))}";
                return true;
            }          

            respuesta = string.Empty;
            return false;
        }
    }
}