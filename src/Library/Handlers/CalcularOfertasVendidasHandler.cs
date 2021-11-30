using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/calcularofertasvendidas" y se encarga
    /// de manejar el caso en que se quieran calcular las ofertas vendidas en un determinado período de tiempo.
    /// </summary>
    public class CalcularOfertasVendidasHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CalcularOfertasVendidasHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public CalcularOfertasVendidasHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/calcularofertasvendidas" };
        }

        /// <summary>
        /// Procesa el mensaje que calcula las ofertas vendidas en un determinado período de tiempo.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/calcularofertasvendidas"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.Empresas.ContainsKey(mensaje.Id))
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/calcularofertasvendidas");
                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese la fecha de inicio(yyyy-MM-dd)";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    respuesta = "Ingrese la fecha final(yyyy-MM-dd)";
                    return true;
                }
                else if (listaConParametros.Count == 2)
                {
                    string fechaInicio = listaConParametros[1];
                    string fechaFinal = listaConParametros[0];

                    Empresa value = Singleton<ContenedorPrincipal>.Instancia.Empresas[mensaje.Id];
                    try
                    {
                        LogicaEmpresa.CalcularOfertasVendidas(value, fechaInicio, fechaFinal);
                    }
                    catch (System.ArgumentException e)
                    {
                        respuesta = e.Message;
                        return true;
                    }

                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                    respuesta = $"En este periodo se han adquirido {LogicaEmpresa.CalcularOfertasVendidas(value, fechaInicio, fechaFinal)}. {OpcionesUso.AccionesEmpresas()}";
                    return true;
                }
            }
            else
            {
                respuesta = $"Usted no es una empresa, no puede usar este comando.";
                return true;
            }

            respuesta = string.Empty;
            return false;
        }
    }
}