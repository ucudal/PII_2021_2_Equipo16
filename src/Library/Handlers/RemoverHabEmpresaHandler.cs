using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/removerhabempresa" y se encarga
    /// de manejar el caso en que una Empresa quiera remover una habilitación.
    /// </summary>
    public class RemoveHabEmpresaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RemoveHabEmpresaHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public RemoveHabEmpresaHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/removerhabempresa" };
        }
        
        /// <summary>
        /// Procesa el mensaje para que una Empresa pueda remover una habilitación.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/removerhabempresa"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.Empresas.ContainsKey(mensaje.Id))
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/removerhabempresa");
                if (listaConParametros.Count == 0)
                {
                    respuesta = $"Ingrese el nombre de la habilitación a eliminar.";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    string habilitacion = listaConParametros[0];
                    if (Singleton<ContenedorPrincipal>.Instancia.Empresas.ContainsKey(mensaje.Id))
                    {
                        Empresa value = Singleton<ContenedorPrincipal>.Instancia.Empresas[mensaje.Id];
                        LogicaEmpresa.RemoveHabilitacion(value, habilitacion);
                        Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                        
                        respuesta = $"Se ha removido la habilitación {habilitacion} con éxito. {OpcionesUso.AccionesEmpresas()}";
                        return true;
                    }
                }
            }
            else
            {
                respuesta = "No se ha podido remover la habilitación, usted no está registrado como Empresa." + OpcionesUso.AccionesEmpresas();
                return true;
            }

            respuesta = string.Empty;
            return false;
        }
    }
}