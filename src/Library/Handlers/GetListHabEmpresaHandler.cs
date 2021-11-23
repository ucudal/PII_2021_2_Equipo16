using System.Collections.Generic;
using System;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "hola".
    /// </summary>
    public class GetLisHabEmpresaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="next">El próximo "handler"</param>
        public GetLisHabEmpresaHandler(BaseHandler next):base(next)
        {
            this.Keywords = new string[] {"/listadehabilitacionesempresa"};
        }

        /// <summary>
        /// Este método procesa el mensaje "Lista de habilitaciones" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns></returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (mensaje == null)
            {
                throw new ArgumentNullException("Message no puede ser nulo.");
            }
            else
            {    
                if (Logica.HistorialDeChats.ContainsKey(mensaje.Id))
                {
                    if (this.CanHandle(mensaje))
                    {
                        Logica.HistorialDeChats[mensaje.Id].MensajesDelUser.Add(mensaje.Text); 
                    }
                    else
                    {
                        if ((mensaje.Text.StartsWith("/") == false) && (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/listadehabilitacionesempresa") == true))
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
                if (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/listadehabilitacionesempresa") == true)
                {
                    List<string> listaConParametros = Logica.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/listadehabilitacionesempresa");
                    
                    if (Logica.Empresas.ContainsKey(mensaje.Id))
                    {
                        Empresa value = Logica.Empresas[mensaje.Id];
                        // Utiliza el método de la clase LogicaEmpresa para obtener la lista de habilitaciones que tiene la Empresas en cuestion.
                        string hab = LogicaEmpresa.GetListaHabilitaciones(value);
                        respuesta = $"La lista de habilitaciones es \n{hab}";
                        return true;
                    }
                    else
                    {
                        // En caso de que la Empresa no contenga habilitaciones relacionadas.
                        respuesta = "No se han podido obtener las habilitaciones."+OpcionesUso.AccionesEmpresas();
                        return true;
                    }
                }
                
                respuesta = string.Empty;
                return false;
            }
        }
    }
}
