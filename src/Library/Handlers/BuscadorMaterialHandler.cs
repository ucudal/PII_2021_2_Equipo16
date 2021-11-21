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
                    Console.WriteLine("EntreBuscadorMat");
                    Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                }
                else
                {
                    if ((message.Text.StartsWith("!") == false) && (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!BuscarMaterial") == true))
                    {
                        Console.WriteLine("EntreBuscadorMat");
                        Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                    }
                    else
                    {
                        response = string.Empty;
                        return false;
                    }
                }
            }
            
            if (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!BuscarMaterial") == true)
            {
                List<string> listaComandos = Logica.HistorialDeChats[message.Id].BuscarUltimoComando("!BuscarMaterial");
                if (listaComandos.Count == 0)
                {
                    response = "Ingrese el Material por el que desea filtrar en su búsqueda.";
                    return true;
                }
                else if (listaComandos.Count == 1)
                {
                    string palabraClave = listaComandos[0];
                    
                    LogicaBuscadores.BuscarPorMaterial(palabraClave);
                    response = TelegramPrinter.BusquedaPrinter(LogicaBuscadores.BuscarPorMaterial(palabraClave));
                    return true;
                }          
            }

            response = string.Empty;
            return false;
        }
    }
}