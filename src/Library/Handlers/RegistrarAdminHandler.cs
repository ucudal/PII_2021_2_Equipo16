using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class RegistrarAdminHandler : BaseHandler
    {
        /// <summary>
        /// Un "handler" del patrón Chain of Responsability que implementa el comando "/registaradmin".
        /// </summary>
        /// <param name="next">Recibe por parametro el siguiente Handler.</param>
        public RegistrarAdminHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/registaradmin"};
        }

        /// <summary>
        /// Este metodo procesa el mensaje "Registrar Admin", para registrar un administrador.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/registaradmin"))
            {
                respuesta = string.Empty;
                return false;
            }
            // cambiar este canhandle por algo tipo, si en el historial, el ultimo comando es /Registrarse, entra al if.
            if (Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/registaradmin") == true)
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/registaradmin");
                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese el nombre";
                    return true;
                }
                if (listaConParametros.Count == 1)
                {
                    respuesta = "Ingrese la clave";
                    return true;
                }
                if (listaConParametros.Count == 2)
                {
                    string nombreAdmin = listaConParametros[1];
                    string claveAdmin = listaConParametros[0];
                    
                    try
                    {
                        LogicaAdministrador.RegistroAdministrador(nombreAdmin, claveAdmin, mensaje.Id);
                    }
                    catch (System.ArgumentException e)
                    {
                        respuesta = e.Message;
                        return true; 
                    }
                
                    respuesta = $"Usted se ha registrado como un Administrador con el nombre {nombreAdmin}. \nPara mayor seguridad debe cambiar su contraseña utilizando el comando /cambiarClave \nQue disfrute el bot.";
                    return true;
                }
            }

            respuesta = string.Empty;
            return false;   
        }
    }
}