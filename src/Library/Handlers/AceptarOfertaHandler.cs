using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/aceptaroferta" y se encarga
    /// de manejar el caso en que la Empresa acepta una oferta.
    /// </summary>
    public class AceptarOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AceptarOfertaHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public AceptarOfertaHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/aceptaroferta" };
        }

        /// <summary>
        /// Procesa el mensaje que determina si la Empresa aceptó o no la oferta.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (mensaje == null)
            {
                throw new ArgumentNullException("Mensaje no puede ser nulo.");
            }
            else if (!this.ChequearHandler(mensaje, "/aceptaroferta"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.Empresas.ContainsKey(mensaje.Id))
            {
                List<string> listaComandos = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/aceptaroferta");
                if (listaComandos.Count == 0)
                {
                    respuesta = $"Ingrese el Nombre de la oferta que desee aceptar.";
                    return true;
                }
                else if (listaComandos.Count == 1)
                {
                    string nombreOfertaParaAceptar = listaComandos[0];

                    Empresa value = Singleton<ContenedorPrincipal>.Instancia.Empresas[mensaje.Id];
                    LogicaEmpresa.AceptarOferta(value, nombreOfertaParaAceptar);
                    
                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                    respuesta = $"Se ha aceptado la oferta {nombreOfertaParaAceptar} con éxito. {OpcionesUso.AccionesEmpresas()} ";
                    return true;
                }
                else
                {
                    respuesta = $"Algo fue mal.";
                    return true;
                }
            }
            else
            {
                respuesta = $"No se ha podido aceptar la oferta, usted no está registrado como Empresa. {OpcionesUso.AccionesEmpresas()} ";
                return true;
            }
        }
    }
}
