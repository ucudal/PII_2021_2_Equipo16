using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/eliminaroferta" y se encarga
    /// de manejar el caso en que una Empresa quiera remover una oferta.
    /// </summary>
    public class RemoverOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RemoverOfertaHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public RemoverOfertaHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/eliminaroferta" };
        }

        /// <summary>
        /// Procesa el mensaje para que una Empresa pueda eliminar una oferta.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/eliminaroferta"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.Empresas.ContainsKey(mensaje.Id))
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/eliminaroferta");

                string[] mensajeProcesado = mensaje.Text.Split();

                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese el nombre de la oferta que desea eliminar";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    string nombreOfertaParaEliminar = listaConParametros[0];
                    Empresa value = Singleton<ContenedorPrincipal>.Instancia.Empresas[mensaje.Id];
                    LogicaEmpresa.EliminarOferta(value, nombreOfertaParaEliminar);
                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                    
                    respuesta = $"Se ha eliminado la oferta {nombreOfertaParaEliminar}. {OpcionesUso.AccionesEmpresas()}";
                    return true;   
                }
            }
            else
            {
                respuesta = "Usted no está registrado como empresa" + OpcionesUso.AccionesEmpresas();
                return true;
            }

            respuesta = string.Empty;
            return false;
        }
    }
}