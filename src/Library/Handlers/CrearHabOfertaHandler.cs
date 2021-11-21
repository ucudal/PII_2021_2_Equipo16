using System.Collections.Generic;
using Telegram.Bot.Types;
using System;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class AddHabOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public AddHabOfertaHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"!CrearHabOferta"};
        }

        /// <summary>
        /// Procesa el mensaje "Registrarse" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje message, out string response)
        {
            if (Logica.HistorialDeChats.ContainsKey(message.Id))
            {
                if (this.CanHandle(message))
                {
                    Console.WriteLine("EntreCrearHabOferta");
                    Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                }
                else
                {
                    if ((message.Text.StartsWith("!") == false) && (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!CrearHabOferta") == true))
                    {
                        Console.WriteLine("EntreCrearHabOferta");
                        Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                    }
                    else
                    {
                        response = string.Empty;
                        return false;
                    }
                }
            }

            if (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!CrearHabOferta") == true)
            {
                // El mensaje debe tener el formato "Remover habilitacion de oferta,nombre de la oferta,habilitacion"
                List<string> listaConParam = Logica.HistorialDeChats[message.Id].BuscarUltimoComando("!CrearHabOferta");

                if (listaConParam.Count == 0)
                {
                    response = "ingrese el nombre de la oferta a la que desea agregar una habilitacion";
                    return true;
                }
                if (listaConParam.Count == 1)
                {
                    response = "ingrese el nombre de la habilitacion que desea agregar";
                    return true;
                }
                if (listaConParam.Count == 2)
                {
                    string nombreOferta = listaConParam[1];
                    string nombreHabParaAgregar = listaConParam[0];

                    if (Logica.Empresas.ContainsKey(message.Id))
                    {
                        Empresa value = Logica.Empresas[message.Id];
                        LogicaEmpresa.AddHabilitacionOferta(value, nombreHabParaAgregar, nombreOferta);
                        
                        response = $"Se ha agregado la habilitacion {nombreHabParaAgregar} de la oferta {nombreOferta}.";
                        return true;
                    }
                }    
                else
                {
                    response = "No se ha podido agregar la habilitación";
                    return true;
                }         
            }
            response = string.Empty;
            return false;
        }
    }
}