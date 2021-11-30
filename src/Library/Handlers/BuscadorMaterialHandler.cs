using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/buscarmaterial".
    /// </summary>
    public class BuscadorMaterialHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "/buscarmaterial".
        /// </summary>
        /// <param name="next">Recibe por parametro el siguiente Handler.</param>
        public BuscadorMaterialHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/buscarmaterial"};
        }

        /// <summary>
        /// Este método procesa el mensaje "Buscar por material" y retorna true.
        /// En caso contrario retorna false.
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
                    respuesta = $"{TelegramPrinter.BusquedaPrinter(LogicaBuscadores.BuscarPorMaterial(palabraClave))}";
                    return true;
                }          

                respuesta = string.Empty;
                return false;
            }
        }
    }
}