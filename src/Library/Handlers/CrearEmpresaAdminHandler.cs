using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/crearempresa" y se encarga
    /// de manejar el caso en que se quiera crear una nueva Empresa.
    /// </summary>
    public class CrearEmpresaAdminHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CrearEmpresaAdminHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public CrearEmpresaAdminHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/crearempresa" };
        }

        /// <summary>
        /// Este método procesa el mensaje para crear una nueva Empresa.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/crearempresa"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.Administradores.ContainsKey(mensaje.Id))
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/crearempresa");
                
                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese nombre de la empresa";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    respuesta = "Ingrese la ubicacion de la empresa";
                    return true;
                }
                else if (listaConParametros.Count == 2)
                {
                    respuesta = $"Ingrese el rubro de la empresa\n {Singleton<ContenedorPrincipal>.Instancia.ContenedorRubrosHabs.TextoListaRubros()}";
                    return true;
                }
                else if (listaConParametros.Count == 3)
                {
                    string empresaNombre = listaConParametros[2];
                    string empresaUbicacion = listaConParametros[1];
                    string empresaRubro = listaConParametros[0];

                    Administrador value = Singleton<ContenedorPrincipal>.Instancia.Administradores[mensaje.Id];
                    LogicaAdministrador.CrearEmpresa(value, empresaNombre, empresaUbicacion, empresaRubro);
                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                    respuesta = $"Se ha creado la empresa '{empresaNombre}', ubicada en '{empresaUbicacion}' y su rubro es '{empresaRubro}'. {OpcionesUso.AccionesAdministradores()}";
                    return true;
                }
            }
            else
            {
                respuesta = $"Usted no es un administrador, no puede utilizar este comando.";
                return true;
            }
            
            respuesta = string.Empty;
            return false;
        }
    }
}