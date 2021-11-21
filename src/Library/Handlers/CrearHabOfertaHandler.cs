using System.Collections.Generic;
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
            this.Keywords = new string[] {"/crearhaboferta"};
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
                    Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                }
                else
                {
                    if ((message.Text.StartsWith("/") == false) && (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("/crearhaboferta") == true))
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

            if (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("/crearhaboferta") == true)
            {
                // El mensaje debe tener el formato "Remover habilitacion de oferta,nombre de la oferta,habilitacion"
                List<string> listaConParam = Logica.HistorialDeChats[message.Id].BuscarUltimoComando("/crearhaboferta");

                if (listaConParam.Count == 0)
                {
                    response = "Ingrese el nombre de la oferta a la que desea agregar una habilitación.";
                    return true;
                }
                if (listaConParam.Count == 1)
                {
                    response = "Ingrese el nombre de la habilitación que desea agregar.";
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
                    response = "No se ha podido agregar la habilitación.";
                    return true;
                }         
            }
            response = string.Empty;
            return false;
        }
    }
}