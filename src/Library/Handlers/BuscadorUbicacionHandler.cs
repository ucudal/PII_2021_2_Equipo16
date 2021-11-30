using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/buscarubicacion" y se encarga
    /// de procesar el mensaje para buscar una oferta acorde con la Ubicacion especificada.
    /// </summary>
    public class BuscadorUbicacionHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BuscadorUbicacionHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public BuscadorUbicacionHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/buscarubicacion" };
        }

        /// <summary>
        /// Procesa el mensaje para buscar una oferta según la ubicación.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (mensaje == null)
            {
                throw new ArgumentNullException("Mensaje no puede ser nulo.");
            }
            else if (!this.ChequearHandler(mensaje, "/buscarubicacion"))
            {
                respuesta = string.Empty;
                return false;
            }
            
            List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/buscarubicacion");
            if (listaConParametros.Count == 0)
            {
                respuesta = "Ingrese la Ubicación por la que sea filtrar en su búsqueda.";
                return true;
            }
            else if (listaConParametros.Count == 1)
            {
                string palabraClave = listaConParametros[0];
                
                LogicaBuscadores.BuscarPorUbicacion(palabraClave);
                Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                respuesta = $"{TelegramPrinter.BusquedaPrinter(LogicaBuscadores.BuscarPorUbicacion(palabraClave))} ";
                return true;
            }          
            respuesta = string.Empty;
            return false;
        }
    }
}