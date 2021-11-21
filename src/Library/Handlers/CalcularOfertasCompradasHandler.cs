using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "hola".
    /// </summary>
    public class CalcularOfertasCompradasHandler : BaseHandler 
    {
         /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="next">El próximo "handler"</param>
        public CalcularOfertasCompradasHandler(BaseHandler next):base(next)
        {
            this.Keywords = new string[] {"!CalcularOfertasCompradas"};
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
                    Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                }
            
                else
                {
                    if ((message.Text.StartsWith("!") == false) && (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!CalcularOfertasCompradas") == true))
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

            if (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!CalcularOfertasCompradas") == true)
            {
                List<string> listaConParam = Logica.HistorialDeChats[message.Id].BuscarUltimoComando("!CalcularOfertasCompradas");
                if (listaConParam.Count == 0)
                {
                    response = "ingrese la fecha de inicio";
                    return true;
                }
                if (listaConParam.Count == 1)
                {
                    response = "ingrese la fecha final";
                    return true;
                }
                if (listaConParam.Count == 2)
                {
                    string fechaInicio = listaConParam[1];
                    string fechaFinal = listaConParam[0];

                    if (Logica.Emprendedores.ContainsKey(message.Id))
                    {
                        Emprendedor value = Logica.Emprendedores[message.Id];
                        LogicaEmprendedor.CalcularOfertasCompradas(value, fechaInicio, fechaFinal);
                        response = $"En este periodo se han adquirido {LogicaEmprendedor.CalcularOfertasCompradas(value, fechaInicio, fechaFinal)}.";
                        return true;
                    }
                }
            }
            response = string.Empty;
            return false;
        }
    }
}