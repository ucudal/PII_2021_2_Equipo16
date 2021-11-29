using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class BuscadorUbicacionHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public BuscadorUbicacionHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/buscarubicacion"};
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
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
                respuesta = $"{TelegramPrinter.BusquedaPrinter(LogicaBuscadores.BuscarPorUbicacion(palabraClave))}";
                return true;
            }          
            respuesta = string.Empty;
            return false;
        }
    }
}