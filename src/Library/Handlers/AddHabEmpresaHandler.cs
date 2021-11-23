using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "hola".
    /// </summary>
    public class AddHabEmpresaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="next"></param>
        public AddHabEmpresaHandler(BaseHandler next):base(next)
        {
            this.Keywords = new string[] {"/agregarhabilitacionempresa"};
        }

        /// <summary>
        /// Este método procesa el mensaje "Agregar habilitación" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
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
                    if ((mensaje.Text.StartsWith("/") == false) && (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/agregarhabilitacionempresa") == true))
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

            if (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/agregarhabilitacionempresa") == true)
            {
                List<string> listaConParametros = Logica.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/agregarhabilitacionempresa");
                
                if (listaConParametros.Count == 0)
                {

                    respuesta = "Ingrese la habilitación que desea agregar.";
                    return true;
                }
                if (listaConParametros.Count == 1)
                {
                    string nuevaHab = listaConParametros[0];
                    if (Logica.Empresas.ContainsKey(mensaje.Id))
                    {
                        Empresa value = Logica.Empresas[mensaje.Id];
                        LogicaEmpresa.AddHabilitacion(value,nuevaHab);
                        respuesta = $"Se ha agregado '{nuevaHab}' a la lista de habilitaciones.";
                        return true;
                    }
                    else
                    {
                        respuesta = $"Usted no es una empresa, no puede utilizar este comando.";
                        return true;
                    }
                }
            }
            
            respuesta = string.Empty;
            return false;
        }
    }
}