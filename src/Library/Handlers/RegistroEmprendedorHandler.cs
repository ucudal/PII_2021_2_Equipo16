using System;
using Telegram.Bot.Types;
using System.Collections.Generic;


namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class RegistroEmprendedorHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RegistroEmprendedorHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"!Registrarse"};
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
                    Console.WriteLine("Entre");
                    Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                }
                else
                {
                    if ((message.Text.StartsWith("!") == false) && (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!Registrarse") == true))
                    {
                        Console.WriteLine("Entre22");
                        Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                    }
                    else
                    {
                        response = string.Empty;
                        return false;
                    }
                }
            }
            
            
            
            
            // cambiar este canhandle por algo tipo, si en el historial, el ultimo comando es /Registrarse, entra al if.
            if (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!Registrarse") == true)
            {
                List<string> listaConParam = Logica.HistorialDeChats[message.Id].BuscarUltimoComando("!Registrarse");
                if (listaConParam.Count == 0)
                {
                    response = "ingrese el nombre";
                    return true;
                    //Console.WriteLine("Entro aca");
                }
                if (listaConParam.Count == 1)
                {
                    response = "ingrese la ubicacion";
                    return true;
                }
                if (listaConParam.Count == 2)
                {
                    response = "ingrese rubro";
                    return true;
                }
                if (listaConParam.Count == 3)
                {
                    response = "ingrese especializaciones";
                    return true;
                }
                if (listaConParam.Count == 4)
                {
                    string nombreEmprendedor = listaConParam[3];
                    string ubicacionEmprendedor = listaConParam[2];
                    string rubroEmprendedor = listaConParam[1];
                    string especializacionesEmprendedor = listaConParam[0];
                    LogicaEmprendedor.RegistroEmprendedor(nombreEmprendedor, ubicacionEmprendedor, rubroEmprendedor, especializacionesEmprendedor, message.Id);
                    response = $"Se ha registrado con nombre {nombreEmprendedor}, ubicacion {ubicacionEmprendedor}, rubro {rubroEmprendedor}, especializacion {especializacionesEmprendedor}. ";
                    return true;
                }
                

            }

            response = string.Empty;
            return false;
            
            
            
        }
    }
}