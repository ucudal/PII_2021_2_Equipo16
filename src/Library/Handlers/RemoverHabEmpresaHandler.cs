using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "/removerhabempresa".
    /// </summary>
    public class RemoveHabEmpresaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        /// <param name="next">Recibe por parametro el siguiente Handler.</param>
        /// <returns></returns>
        public RemoveHabEmpresaHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/removerhabempresa"};
        }
        
        /// <summary>
        /// Se encarga de procesar el mensaje para determinar si se removerá una habilitación.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
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