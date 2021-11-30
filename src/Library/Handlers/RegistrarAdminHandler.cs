using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/registaradmin" y se encarga
    /// de manejar el caso en que se quiera registrar el Administrador.
    /// </summary>
    public class RegistrarAdminHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RegistrarAdminHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public RegistrarAdminHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/registaradmin" };
        }

        /// <summary>
        /// Este metodo procesa el mensaje para registrar un administrador.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/registaradmin"))
            {
                respuesta = string.Empty;
                return false;
            }
            // cambiar este canhandle por algo tipo, si en el historial, el ultimo comando es /Registrarse, entra al if.
            else if (Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/registaradmin") == true)
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/registaradmin");
                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese el nombre";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    respuesta = "Ingrese la clave";
                    return true;
                }
                else if (listaConParametros.Count == 2)
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

                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                    respuesta = $"Usted se ha registrado como un Administrador con el nombre {nombreAdmin}. \nPara mayor seguridad debe cambiar su contraseña utilizando el comando /cambiarClave \nQue disfrute el bot.";
                    return true;
                }
            }

            respuesta = string.Empty;
            return false;
        }
    }
}