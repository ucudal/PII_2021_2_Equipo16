using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/calcularofertascompradas" y se encarga
    /// de manejar el caso en que se quieran calcular las ofertas cnsumidas en un determinado período de tiempo.
    /// </summary>
    public class CalcularOfertasConsumidasHandler : BaseHandler 
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CalcularOfertasConsumidasHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public CalcularOfertasConsumidasHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/calcularofertascompradas" };
        }
        
        /// <summary>
        /// Procesa el mensaje que calcula las ofertas compradas en un determinado período de tiempo.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/calcularofertascompradas"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.Emprendedores.ContainsKey(mensaje.Id))
            {
                List<string> listaConParam = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/calcularofertascompradas");
                if (listaConParam.Count == 0)
                {
                    respuesta = "Ingrese la fecha de inicio (YYYY-MM-DD).";
                    return true;
                }
                else if (listaConParam.Count == 1)
                {
                    respuesta = "Ingrese la fecha final (YYYY-MM-DD).";
                    return true;
                }
                else if (listaConParam.Count == 2)
                {
                    string fechaInicio = listaConParam[1];
                    string fechaFinal = listaConParam[0];

                    Emprendedor value = Singleton<ContenedorPrincipal>.Instancia.Emprendedores[mensaje.Id];

                    try
                    {
                        LogicaEmprendedor.CalcularOfertasConsumidas(value, fechaInicio, fechaFinal);
                    }
                    catch (System.ArgumentException e)
                    {
                        respuesta = e.Message;
                        return true;    
                    }

                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                    respuesta = $"En este periodo se han adquirido {LogicaEmprendedor.CalcularOfertasConsumidas(value, fechaInicio, fechaFinal)}. {OpcionesUso.AccionesEmprendedor()}";
                    return true;
                }
            }
            else
            {
                respuesta = $"Usted no es un emprendedor, no puede usar este comando.";
                return true;
            }
            respuesta = string.Empty;
            return false;
        }
    }
}