using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/aceptarinvitacion" y se encarga
    /// de manejar el caso en que la Empresa acepta la invitación.
    /// </summary>
    public class AceptarInvEmpresaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AceptarInvEmpresaHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public AceptarInvEmpresaHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/aceptarinvitacion" };
        }

        /// <summary>
        /// Procesa el mensaje que determina si la Empresa aceptó o no la invitación.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        { 
            if (!this.ChequearHandler(mensaje, "/aceptarinvitacion"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/aceptarinvitacion") == true)
            {
                if (Singleton<ContenedorPrincipal>.Instancia.Empresas.ContainsKey(mensaje.Id))
                {
                    respuesta = "Usted ya se ha registrado previamente.";
                    return true;
                }
                else if (Singleton<ContenedorPrincipal>.Instancia.Emprendedores.ContainsKey(mensaje.Id))
                {
                    respuesta = "Error: Usted ya se ha registrado como emprendedor previamente.";
                    return true;
                }
                else
                {
                    List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/aceptarinvitacion");
                    if (listaConParametros.Count == 0)
                    {
                        respuesta = "Ingrese la clave de su Empresa.";  // La clave en este caso se le invita, la clave es el nombre de la empresa.
                        return true;
                    }
                    else if (listaConParametros.Count == 1)
                    {
                        string nombreEmpresa = listaConParametros[0];
                        foreach (Empresa empresa in Singleton<ContenedorPrincipal>.Instancia.EmpresasInvitadas)
                        {
                            if (empresa.Nombre == nombreEmpresa)
                            {
                                Singleton<ContenedorPrincipal>.Instancia.Empresas.Add(mensaje.Id, empresa);
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
            }

            respuesta = string.Empty;
            return false;
        }
    }
}