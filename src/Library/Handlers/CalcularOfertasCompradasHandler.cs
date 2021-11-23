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
        /// <param name="next">El próximo "handler."</param>
        public CalcularOfertasCompradasHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/calcularofertascompradas"};
        }
        
        /// <summary>
        /// Este método procesa el mensaje "Calculas ofertas Vendidas" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns></returns>
        protected override bool InternalHandle(IMensaje message, out string respuesta)
        {
            if (Logica.HistorialDeChats.ContainsKey(message.Id))
            {
                if (this.CanHandle(message))
                {
                    Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                }
            
                else
                {
                    if ((message.Text.StartsWith("/") == false) && (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("/calcularofertascompradas") == true))
                    {
                        Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text);
                    }
                    else
                    {
                    respuesta = string.Empty;
                    return false;
                    }
                }
            }

            if (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("/calcularofertascompradas") == true)
            {
                List<string> listaConParam = Logica.HistorialDeChats[message.Id].BuscarUltimoComando("/calcularofertascompradas");
                if (listaConParam.Count == 0)
                {
                    respuesta = "Ingrese la fecha de inicio.";
                    return true;
                }
                if (listaConParam.Count == 1)
                {
                    respuesta = "Ingrese la fecha final.";
                    return true;
                }
                if (listaConParam.Count == 2)
                {
                    string fechaInicio = listaConParam[1];
                    string fechaFinal = listaConParam[0];

                    if (Logica.Emprendedores.ContainsKey(message.Id))
                    {
                        Emprendedor value = Logica.Emprendedores[message.Id];

                        try
                        {
                            LogicaEmprendedor.CalcularOfertasCompradas(value, fechaInicio, fechaFinal);
                        }
                        catch (System.ArgumentException e)
                        {
                            respuesta = e.Message;
                            return true;    
                        }

                        respuesta = $"En este periodo se han adquirido {LogicaEmprendedor.CalcularOfertasCompradas(value, fechaInicio, fechaFinal)}. {OpcionesUso.AccionesEmprendedor()}";
                        return true;
                    }
                }
            }
            
            respuesta = string.Empty;
            return false;
        }
    }
}