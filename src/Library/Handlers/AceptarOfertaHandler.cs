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
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
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
            
            if (Singleton<ContenedorPrincipal>.Instancia.Empresas.ContainsKey(mensaje.Id))
            {
                List<string> listaComandos = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/aceptaroferta");
                if (listaComandos.Count == 0)
                {
                    respuesta = $"Ingrese el Nombre de la oferta que desee aceptar {listaComandos.Count}.";
                    return true;
                }
                
                if (listaComandos.Count == 1)
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
