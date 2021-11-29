using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class RemoverOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RemoverOfertaHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/eliminaroferta"};
        }

        /// <summary>
        /// Procesa el mensaje "!Eliminar oferta" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
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
                respuesta = "Usted no está registrado como empresa"+OpcionesUso.AccionesEmpresas();
                return true;
            }

            respuesta = string.Empty;
            return false;
        }
    }
}