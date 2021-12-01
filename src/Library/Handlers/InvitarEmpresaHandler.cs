using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/invitarempresa" y se encarga
    /// de manejar el caso en que haya un interesado en una oferta.
    /// </summary>
    public class InvitarEmpresaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InvitarEmpresaHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public InvitarEmpresaHandler(BaseHandler next)
            : base(next)
        {
        this.Keywords = new string[] { "/invitarempresa" };
        }

        /// <summary>
        /// Este método procesa el mensaje con el fin de integrar a una nueva Empresa en el Bot.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/invitarempresa"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/invitarempresa") == true)
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/invitarempresa");
                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese el nombre de la empresa que desea invitar";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    string empresaNombre = listaConParametros[0];

                    if (Singleton<ContenedorPrincipal>.Instancia.Administradores.ContainsKey(mensaje.Id))
                    {
                        Administrador value = Singleton<ContenedorPrincipal>.Instancia.Administradores[mensaje.Id];
                        LogicaAdministrador.InvitarEmpresa(value, empresaNombre);
                        respuesta = $"Se ha invitado a {empresaNombre}. {OpcionesUso.AccionesAdministradores()}";
                        return true;
                    }
                    else
                    {
                        respuesta = "Usted no es un administrador, no tiene permiso para realizar dicha operación.";
                        return true;
                    }
                }
                else
                {
                    respuesta = $"No se ha podido, invitar a la empresa. \nIntente nuevamente /invitarempresa \n";
                    return true;
                }         
            }

            respuesta = string.Empty;
            return false;
        }
    }
}