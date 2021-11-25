using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class RegistrarAdminHandler : BaseHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public RegistrarAdminHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/registar_admin"};
        }

        /// <summary>
        /// Este metodo procesa el mensaje "Registrar Admin", para registrar un administrador.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/registar_admin"))
            {
                respuesta = string.Empty;
                return false;
            }
            // cambiar este canhandle por algo tipo, si en el historial, el ultimo comando es /Registrarse, entra al if.
            if (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/registar_admin") == true)
            {
                List<string> listaConParametros = Logica.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/registar_admin");
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
                        return true; // Tengo entendido que esto podria ser false ya que en realidad falla. consultar con profe
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