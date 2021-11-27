using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase contiene un método para aceptar una oferta.
    /// </summary>
    public class AceptarOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Este método se encarga de aceptar una oferta.
        /// </summary>
        /// <param name="next"></param>
        public AceptarOfertaHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/aceptaroferta"};
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respusta al mensaje procesado.</param>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (mensaje == null)
            {
                throw new ArgumentNullException("Mensaje no puede ser nulo.");
            }
            
            if (!this.ChequearHandler(mensaje, "/aceptaroferta"))
            {
                respuesta = string.Empty;
                return false;
            }
            
            if (ContenedorPrincipal.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/aceptaroferta") == true)
            {
                List<string> listaComandos = ContenedorPrincipal.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/aceptaroferta");
                if (listaComandos.Count == 0)
                {
                    respuesta = $"Ingrese el Nombre de la oferta que desee aceptar {listaComandos.Count}.";
                    return true;
                }
                
                if (listaComandos.Count == 1)
                {
                    string nombreOfertaParaAceptar = listaComandos[0];

                    if (ContenedorPrincipal.Instancia.Empresas.ContainsKey(mensaje.Id))
                    {
                        Empresa value = ContenedorPrincipal.Instancia.Empresas[mensaje.Id];
                        LogicaEmpresa.AceptarOferta(value, nombreOfertaParaAceptar);
                        
                        respuesta = $"Se ha aceptado la oferta {nombreOfertaParaAceptar} con éxito. {OpcionesUso.AccionesEmpresas()} ";
                    }
                    
                    else
                    {
                        respuesta = $"No se ha podido aceptar la oferta, usted no está registrado como Empresa. {OpcionesUso.AccionesEmpresas()} ";
                    }
                    
                    return true;
                }
                
                else
                {
                    respuesta = $"Algo fue mal.";
                    return true;
                }
            }
            
            respuesta = string.Empty;
            return false;
        }
    }
}
