using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class BuscadorTagHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public BuscadorTagHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/buscartag"};
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje message, out string response)
        {
            if (message == null)
            {
                throw new ArgumentNullException("Message no puede ser nulo.");
            }

            if (Logica.HistorialDeChats.ContainsKey(message.Id))
            {
                if (this.CanHandle(message))
                {
                    Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                }
                else
                {
                    if ((message.Text.StartsWith("/") == false) && (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("/buscartag") == true))
                    {
                        Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                    }
                    else
                    {
                        response = string.Empty;
                        return false;
                    }
                }
            }
            
            if (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("/buscartag") == true)
            {
                List<string> listaComandos = Logica.HistorialDeChats[message.Id].BuscarUltimoComando("/buscartag");
                if (listaComandos.Count == 0)
                {
                    response = "Ingrese el Tag por el que sea filtrar en su búsqueda.";
                    return true;
                }
                if (listaComandos.Count == 1)
                {
                    string palabraClave = listaComandos[0];
                    
                    LogicaBuscadores.BuscarPorTags(palabraClave);
                    response = TelegramPrinter.BusquedaPrinter(LogicaBuscadores.BuscarPorTags(palabraClave));
                    return true;
                }          
            }

            response = string.Empty;
            return false;
        }
    }
}