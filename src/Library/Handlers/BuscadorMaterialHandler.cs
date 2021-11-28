using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class BuscadorMaterialHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public BuscadorMaterialHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/buscarmaterial"};
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
                throw new ArgumentNullException("Message no puede ser nulo.");
            }
            
            if (!this.ChequearHandler(mensaje, "/buscarmaterial"))
            {
                respuesta = string.Empty;
                return false;
            }
            
<<<<<<< HEAD
            if (Singleton<Logica>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/buscarmaterial") == true)
            {
                List<string> listaConParametros = Singleton<Logica>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/buscarmaterial");
=======
            if (Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/buscarmaterial") == true)
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/buscarmaterial");
>>>>>>> deV2
                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese el Material por el que desea filtrar en su búsqueda.";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    string palabraClave = listaConParametros[0];
                    
                    LogicaBuscadores.BuscarPorMaterial(palabraClave);
                    respuesta = $"{TelegramPrinter.BusquedaPrinter(LogicaBuscadores.BuscarPorMaterial(palabraClave))} {OpcionesUso.AccionesEmprendedor()}";
                    return true;
                }          
            }

            respuesta = string.Empty;
            return false;
        }
    }
}