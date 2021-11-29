using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/crearempresa".
    /// </summary>
    public class CrearEmpresaAdminHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "crear empresa".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CrearEmpresaAdminHandler(BaseHandler next): base(next)
        {
            this.Keywords = new string[] {"/crearempresa"};
        }

        /// <summary>
        /// Este método procesa el mensaje "Crear empresa" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/crearempresa"))
            {
                respuesta = string.Empty;
                return false;
            }

            if (Singleton<ContenedorPrincipal>.Instancia.Administradores.ContainsKey(mensaje.Id))
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/crearempresa");
                
                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese nombre de la empresa";
                    return true;
                }
                if (listaConParametros.Count ==1)
                {
                    respuesta = "Ingrese la ubicacion de la empresa";
                    return true;
                }
                if (listaConParametros.Count == 2)
                {
                    respuesta = "Ingrese el rubro de la empresa";
                    return true;
                }
                if (listaConParametros.Count == 3)
                {
                    string empresaNombre = listaConParametros[2];
                    string empresaUbicacion = listaConParametros[1];
                    string empresaRubro = listaConParametros[0];

                    
                    Administrador value = Singleton<ContenedorPrincipal>.Instancia.Administradores[mensaje.Id];
                    LogicaAdministrador.CrearEmpresa(value, empresaNombre, empresaUbicacion, empresaRubro);
                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                    respuesta = $"Se ha creado la empresa '{empresaNombre}' la cual esta ubicada en '{empresaUbicacion}' y su rubro es '{empresaRubro}'. {OpcionesUso.AccionesAdministradores()}";
                    return true;
                }
            }
            else
            {
                respuesta = $"Usted no es una empresa, no puede utilizar este comando.";
                return true;
            }
            
            respuesta = string.Empty;
            return false;
        }
    }
}