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
                    if ((mensaje.Text.StartsWith("/") == false) && (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/crearhaboferta") == true))
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

            if (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/crearhaboferta") == true)
            {
                // El mensaje debe tener el formato "Remover habilitacion de oferta,nombre de la oferta,habilitacion"
                List<string> listaConParametros = Logica.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/crearhaboferta");

                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese el nombre de la oferta a la que desea agregar una habilitación.";
                    return true;
                }
                if (listaConParametros.Count == 1)
                {
                    respuesta = "Ingrese el nombre de la habilitación que desea agregar.";
                    return true;
                }
                if (listaConParametros.Count == 2)
                {
                    string nombreOferta = listaConParametros[1];
                    string nombreHabParaAgregar = listaConParametros[0];

                    if (Logica.Empresas.ContainsKey(mensaje.Id))
                    {
                        Empresa value = Logica.Empresas[mensaje.Id];
                        LogicaEmpresa.AddHabilitacionOferta(value, nombreHabParaAgregar, nombreOferta);
                        
                        respuesta = $"Se ha agregado la habilitacion {nombreHabParaAgregar} de la oferta {nombreOferta}.";
                        return true;
                    }
                }    
                else
                {
                    respuesta = "No se ha podido agregar la habilitación.";
                    return true;
                }         
            }
            respuesta = string.Empty;
            return false;
        }
    }
}