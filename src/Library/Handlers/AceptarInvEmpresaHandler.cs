using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
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
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respusta al mensaje procesado.</param>
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
                    if ((mensaje.Text.StartsWith("/") == false) && (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/aceptarinvitacion") == true))
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
                            respuesta = $"Gracias por unirte {nombreEmpresa}.\nSi tiene dudas con lo que puede hacer, use\n/comandos";
                            return true;
                        }
                    }
                }
                else
                {
                    respuesta = "No te has podido unir.";
                    return true;
                }
            }

            respuesta = string.Empty;
            return false;
        }
    }
}