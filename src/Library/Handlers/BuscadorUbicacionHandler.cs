using System;
using Telegram.Bot.Types;
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
            this.Keywords = new string[] {"!BuscarUbicacion"};
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (Logica.HistorialDeChats.ContainsKey(mensaje.Id))
            {
                if (this.CanHandle(mensaje))
                {
                    Logica.HistorialDeChats[mensaje.Id].MensajesDelUser.Add(mensaje.Text); 
                }
                else
                {
                    if ((mensaje.Text.StartsWith("!") == false) && (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("!BuscarUbicacion") == true))
                    {
                        Logica.HistorialDeChats[mensaje.Id].MensajesDelUser.Add(mensaje.Text); 
                    }
                    else
                    {
                        respuesta = string.Empty;
                        return false;
                    }
                }
            }
            
            if (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("!BuscarUbicacion") == true)
            {
                List<string> listaComandos = Logica.HistorialDeChats[mensaje.Id].BuscarUltimoComando("!BuscarUbicacion");
                if (listaComandos.Count == 0)
                {
                    respuesta = "Ingrese la Ubicación por la que sea filtrar en su búsqueda.";
                    return true;
                }
                if (listaComandos.Count == 1)
                {
                    string palabraClave = listaComandos[0];
                    
                    LogicaBuscadores.BuscarPorUbicacion(palabraClave);
                    respuesta = TelegramPrinter.BusquedaPrinter(LogicaBuscadores.BuscarPorUbicacion(palabraClave));
                    return true;
                }          
            }

            respuesta = string.Empty;
            return false;
        }
    }
}