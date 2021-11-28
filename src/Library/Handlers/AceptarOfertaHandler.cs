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
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
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
            
            if (Singleton<Logica>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/aceptaroferta") == true)
            {
                List<string> listaComandos = Singleton<Logica>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/aceptaroferta");
                if (listaComandos.Count == 0)
                {
                    respuesta = $"Ingrese el Nombre de la oferta que desee aceptar {listaComandos.Count}.";
                    return true;
                }
                
                if (listaComandos.Count == 1)
                {
                    string nombreOfertaParaAceptar = listaComandos[0];

                    if (Singleton<Logica>.Instancia.Empresas.ContainsKey(mensaje.Id))
                    {
                        Empresa value = Singleton<Logica>.Instancia.Empresas[mensaje.Id];
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
