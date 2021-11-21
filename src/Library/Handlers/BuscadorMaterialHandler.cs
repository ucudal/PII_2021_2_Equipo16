using System;
using Telegram.Bot.Types;
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
            this.Keywords = new string[] {"!BuscarMaterial"};
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
                    if ((mensaje.Text.StartsWith("!") == false) && (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("!BuscarMaterial") == true))
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
            
            if (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("!BuscarMaterial") == true)
            {
                List<string> listaConParam = Logica.HistorialDeChats[mensaje.Id].BuscarUltimoComando("!BuscarMaterial");
                if (listaConParam.Count == 0)
                {
                    respuesta = "Ingrese el Material por el que sea filtrar en su búsqueda.";
                    return true;
                }
                if (listaConParam.Count == 1)
                {
                    string palabraClave = listaConParam[0];
                    
                    LogicaBuscadores.BuscarPorMaterial(palabraClave);
                    respuesta = TelegramPrinter.BusquedaPrinter(LogicaBuscadores.BuscarPorMaterial(palabraClave));
                    return true;
                }          
            }

            respuesta = string.Empty;
            return false;
        }
    }
}