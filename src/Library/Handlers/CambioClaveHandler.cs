using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "/cambiarclave".
    /// </summary>
    public class CambioClaveHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el administrador.
        /// </summary>
        /// <param name="next">Recibe por parametro el siguiente Handler.</param>
        public CambioClaveHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/cambiarclave"};
        }

        /// <summary>
        /// Este metodo procesa el mensaje "cambiar clave".
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por parametro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/cambiarclave"))
            {
                respuesta = string.Empty;
                return false;
            }
            // cambiar este canhandle por algo tipo, si en el historial, el ultimo comando es /cambiarClave, entra al if.
            if (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/cambiarclave") == true)
            {
                List<string> listaConParametros = Logica.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/cambiarclave");
                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese su contraseña";
                    return true;
                }
                if (listaConParametros.Count == 1)
                {
                    respuesta = "Ingrese la nueva contraseña";
                    return true;
                }
                if (listaConParametros.Count == 2)
                {
                    string claveVieja = listaConParametros[1];
                    string claveNueva = listaConParametros[0];
                    
                    if (Logica.Administradores.ContainsKey(mensaje.Id))
                    {
                        Administrador value = Logica.Administradores[mensaje.Id];
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