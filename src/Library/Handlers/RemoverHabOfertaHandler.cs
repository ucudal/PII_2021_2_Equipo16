using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/removerhaboferta" y se encarga
    /// de manejar el caso en que una Empresa quiera remover una habilitación.
    /// </summary>
    public class RemoverHabOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RemoverHabOfertaHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public RemoverHabOfertaHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/removerhaboferta" };
        }

        /// <summary>
        /// Procesa el mensaje para que una Empresa pueda remover una habilitación para una oferta.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/removerhaboferta"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.Empresas.ContainsKey(mensaje.Id))
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/removerhaboferta");

                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese el nombre de la oferta a la que desea eliminar una habilitacion";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    respuesta = "ingrese el nombre de la habilitacion que desea remover";
                    return true;
                }
                else if (listaConParametros.Count == 2)
                {
                    string nombreOferta = listaConParametros[1];
                    string nombreHabParaEliminar = listaConParametros[0];
                    
                    Empresa value = Singleton<ContenedorPrincipal>.Instancia.Empresas[mensaje.Id];
                    LogicaEmpresa.RemoveHabilitacionOferta(value, nombreHabParaEliminar, nombreOferta);
                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                    
                    respuesta = $"Se ha removido la habilitacion {nombreHabParaEliminar} de la oferta {nombreOferta}. {OpcionesUso.AccionesEmpresas()}";
                    return true;
                }
            }
            else
            {
                respuesta = $"Usted no es una empresa, no puede usar este comando.";
                return true;
            }

            respuesta = string.Empty;
            return false;
        }
    }
}
