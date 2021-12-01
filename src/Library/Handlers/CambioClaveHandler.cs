using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/cambiarclave" y se encarga
    /// de manejar el caso en que se quiera cambiar la clave.
    /// </summary>
    public class CambioClaveHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CambioClaveHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public CambioClaveHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/cambiarclave" };
        }

        /// <summary>
        /// Este metodo procesa el mensaje para cambiar la clave.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/cambiarclave"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/cambiarclave") == true)
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/cambiarclave");
                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese su contraseña";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    respuesta = "Ingrese la nueva contraseña";
                    return true;
                }
                else if (listaConParametros.Count == 2)
                {
                    string claveVieja = listaConParametros[1];
                    string claveNueva = listaConParametros[0];
                    if (Singleton<ContenedorPrincipal>.Instancia.Administradores.ContainsKey(mensaje.Id))
                    {
                        Administrador value = Singleton<ContenedorPrincipal>.Instancia.Administradores[mensaje.Id];
                        LogicaAdministrador.CambioClave(value,claveVieja, claveNueva);
                        respuesta = $"Se ha cambiado su contraseña. {OpcionesUso.AccionesAdministradores()}";
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
                    respuesta = $"No se ha podido, cambiar la contraseña. \nIntente nuevamente /cambiarclave \n";
                    return true;
                }
            }

            respuesta = string.Empty;
            return false;
        }
    }
}