using System.Collections.Generic;
using System;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "hola".
    /// </summary>
    public class CalcularOfertasVendidasHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="next">El próximo "handler"</param>
        public CalcularOfertasVendidasHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"!CalcularOfertasVendidas"};
        }

        /// <summary>
        /// Este método procesa el mensaje "Calculas ofertas Vendidas" y retorna true.
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
                    Console.WriteLine("EntreCalcularOfertasV");
                    Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                }
                else
                {
                    if ((message.Text.StartsWith("!") == false) && (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!CalcularOfertasVendidas") == true))
                    {
                        Console.WriteLine("EntreCalcualrOfertasV");
                        Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                    }
                    else
                    {
                        response = string.Empty;
                        return false;
                    }
                }
            }

            if (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!CalcularOfertasVendidas") == true)
            {
                List<string> listaConParam = Logica.HistorialDeChats[message.Id].BuscarUltimoComando("!CalcularOfertasVendidas");
                if (listaConParam.Count == 0)
                {
                    response = "Ingrese la fecha de inicio";
                    return true;
                }
                if (listaConParam.Count == 1)
                {
                    response = "Ingrese la fecha final";
                    return true;
                }
                if (listaConParam.Count == 2)
                {
                    string fechaInicio = listaConParam[1];
                    string fechaFinal = listaConParam[0];

                    if (Logica.Empresas.ContainsKey(message.Id))
                    {
                        Empresa value = Logica.Empresas[message.Id];
                        LogicaEmpresa.CalcularOfertasVendidas(value, fechaInicio, fechaFinal);

                        response = $"En este periodo se han adquirido {LogicaEmpresa.CalcularOfertasVendidas(value, fechaInicio, fechaFinal)}.";
                        return true;
                    }
                }
            }

            response = string.Empty;
            return false;
        }
    }
}