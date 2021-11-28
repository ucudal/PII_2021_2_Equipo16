using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "/invitarempresa".
    /// </summary>
    public class InvitarEmpresaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa los mensajes ingresador por el usuario, con el fin de invitar a una empresa a integrar el bot.
        /// </summary>
        /// <param name="next">Recibe por parametro el siguiente Handler.</param>
        public InvitarEmpresaHandler(BaseHandler next) : base(next)
        {
        this.Keywords = new string[] {"/invitarempresa"};
        }  

        /// <summary>
        /// Este método procesa el mensaje "Invitar Empresa" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
         protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/invitarempresa"))
            {
                respuesta = string.Empty;
                return false;
            }
            // cambiar este canhandle por algo tipo, si en el historial, el ultimo comando es /cambiarClave, entra al if.
            if (Singleton<Logica>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/invitarempresa") == true)
            {
                List<string> listaConParametros = Singleton<Logica>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/invitarempresa");
                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese el nombre de la empresa que desea invitar";
                    return true;
                }
                if (listaConParametros.Count == 1)
                {
                    string empresaNombre = listaConParametros[0];
                    
                    if (Singleton<Logica>.Instancia.Administradores.ContainsKey(mensaje.Id))
                    {
                        Administrador value = Singleton<Logica>.Instancia.Administradores[mensaje.Id];
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