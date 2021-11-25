using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/aceptarinvitacion".
    /// </summary>
    public class AceptarInvEmpresaHandler : BaseHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public AceptarInvEmpresaHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/aceptarinvitacion"};
        }

        /// <summary>
        /// Procesa el mensaje y determina si la Empresa aceptó la invitación.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por parametro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        { 
            if (!this.ChequearHandler(mensaje, "/aceptarinvitacion"))
            {
                respuesta = string.Empty;
                return false;
            }
            
            if (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/aceptarinvitacion") == true)
            {
                List<string> listaConParametros = Logica.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/aceptarinvitacion");
                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese el Nombre de su Empresa.";
                    return true;
                }
                if (listaConParametros.Count == 1)
                {
                    string nombreEmpresa = listaConParametros[0];
                    foreach (Empresa empresa in Logica.EmpresasInvitadas)
                    {
                        if (empresa.Nombre == nombreEmpresa)
                        {
                            Logica.Empresas.Add(mensaje.Id, empresa);
                            respuesta = $"Gracias por unirte {nombreEmpresa}. {OpcionesUso.AccionesEmpresas()}";
                            return true;
                        }
                    }
                }
                else
                {
                    respuesta = $"No te has podido unir. {OpcionesUso.AccionesEmpresas()}";
                    return true;
                }
            }

            respuesta = string.Empty;
            return false;
        }
    }
}