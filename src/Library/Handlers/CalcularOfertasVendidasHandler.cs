using System.Collections.Generic;

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
            this.Keywords = new string[] {"/calcularofertasvendidas"};
        }

        /// <summary>
        /// Este método procesa el mensaje "Calculas ofertas Vendidas" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns></returns>
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
                    if ((mensaje.Text.StartsWith("/") == false) && (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/calcularofertasvendidas") == true))
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

            if (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/calcularofertasvendidas") == true)
            {
                List<string> listaConParametros = Logica.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/calcularofertasvendidas");
                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese la fecha de inicio";
                    return true;
                }
                if (listaConParametros.Count == 1)
                {
                    respuesta = "Ingrese la fecha final";
                    return true;
                }
                if (listaConParametros.Count == 2)
                {
                    string fechaInicio = listaConParametros[1];
                    string fechaFinal = listaConParametros[0];

                    if (Logica.Empresas.ContainsKey(mensaje.Id))
                    {
                        Empresa value = Logica.Empresas[mensaje.Id];
                        try
                        {
                            LogicaEmpresa.CalcularOfertasVendidas(value, fechaInicio, fechaFinal);
                        }
                        catch (System.ArgumentException e)
                        {
                            respuesta = e.Message;
                            return true;
                        }

                        respuesta = $"En este periodo se han adquirido {LogicaEmpresa.CalcularOfertasVendidas(value, fechaInicio, fechaFinal)}. {OpcionesUso.AccionesEmpresas()}";
                        return true;
                    }
                }
            }

            respuesta = string.Empty;
            return false;
        }
    }
}