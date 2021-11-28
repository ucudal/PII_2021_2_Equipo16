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
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            
            if (!this.ChequearHandler(mensaje, "/calcularofertasvendidas"))
            {
                respuesta = string.Empty;
                return false;
            }

<<<<<<< HEAD
            if (Singleton<Logica>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/calcularofertasvendidas") == true)
            {
                List<string> listaConParametros = Singleton<Logica>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/calcularofertasvendidas");
=======
            if (Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/calcularofertasvendidas") == true)
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/calcularofertasvendidas");
>>>>>>> deV2
                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese la fecha de inicio(yyyy-MM-dd)";
                    return true;
                }
                if (listaConParametros.Count == 1)
                {
                    respuesta = "Ingrese la fecha final(yyyy-MM-dd)";
                    return true;
                }
                if (listaConParametros.Count == 2)
                {
                    string fechaInicio = listaConParametros[1];
                    string fechaFinal = listaConParametros[0];

<<<<<<< HEAD
                    if (Singleton<Logica>.Instancia.Empresas.ContainsKey(mensaje.Id))
                    {
                        Empresa value = Singleton<Logica>.Instancia.Empresas[mensaje.Id];
=======
                    if (Singleton<ContenedorPrincipal>.Instancia.Empresas.ContainsKey(mensaje.Id))
                    {
                        Empresa value = Singleton<ContenedorPrincipal>.Instancia.Empresas[mensaje.Id];
>>>>>>> deV2
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
                    else
                    {
                        respuesta = $"Usted no es una empresa, no puede usar este comando.";
                        return true;
                    }
                }
            }

            respuesta = string.Empty;
            return false;
        }
    }
}