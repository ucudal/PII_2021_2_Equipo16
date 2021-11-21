using System;
using Telegram.Bot.Types;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class InteresadoEnOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="next">El próximo "handler"</param>
        public InteresadoEnOfertaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"!Interesado"};
        }
        /// <summary>
        /// Este método procesa el mensaje "!InteresadoEnOferta" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns></returns>
        protected override bool InternalHandle(IMensaje message, out string response)
        {
             if (Logica.HistorialDeChats.ContainsKey(message.Id))
            {
                if (this.CanHandle(message))
                {
                    Console.WriteLine("EntreInterasado");
                    Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                }
                else
                {
                    if ((message.Text.StartsWith("!") == false) && (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!Interesado") == true))
                    {
                        Console.WriteLine("EntreInteresado");
                        Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                    }
                    else
                    {
                        response = string.Empty;
                        return false;
                    }
                }
            }

            if (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!Interesado") == true)
            {
                List<string> listaConParam = Logica.HistorialDeChats[message.Id].BuscarUltimoComando("!Interesado");
                if (listaConParam.Count == 0)
                {
                    response = "ingrese el nombre de la oferta en la que quiera manifestar su interés";
                    return true;
                }
                if (listaConParam.Count == 1)
                {
                    string nombreOferta = listaConParam[0];

                    if (Logica.Emprendedores.ContainsKey(message.Id))
                    {
                        Emprendedor value = Logica.Emprendedores[message.Id];
                        LogicaEmprendedor.InteresadoEnOferta(value, nombreOferta);
                        response = $"Se ha manifestado su interés en {nombreOferta} de manera exitosa";
                        return true;
                    }
                }
                else
                {
                    response = "No se ha podido manifestar el interés de manera exitosa";
                    return true;
                }
            }
            response = string.Empty;
            return false;
        }
    }
}
