using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/buscarmaterial" y se encarga
    /// de procesar el mensaje para buscar una oferta acorde con el Material especificado.
    /// </summary>
    public class BuscadorMaterialHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BuscadorMaterialHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public BuscadorMaterialHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/buscarmaterial" };
        }

        /// <summary>
        /// Procesa el mensaje para buscar una oferta según el material.
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
            else if (!this.ChequearHandler(mensaje, "/buscarmaterial"))
            {
                respuesta = string.Empty;
                return false;
            }
            else
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/buscarmaterial");
                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese el tipo del material por el que desea filtrar en su búsqueda.\n-Reciclado\n-Residuo";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    string palabraClave = listaConParametros[0];
                
                    LogicaBuscadores.BuscarPorMaterial(palabraClave);
                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                    respuesta = $"{PlataformaPrinter.BusquedaPrinter(LogicaBuscadores.BuscarPorMaterial(palabraClave))}";
                    return true;
                }          

                respuesta = string.Empty;
                return false;
            }
        }
    }
}