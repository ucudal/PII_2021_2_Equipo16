using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/vermisofertas" y se encarga
    /// de manejar el caso en que una Empresa quiera ver todas sus ofertas.
    /// </summary>
    public class VerMisOfertasHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="VerMisOfertasHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public VerMisOfertasHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/vermisofertas" };
        }

        /// <summary>
        /// Procesa el mensaje para que una Empresa pueda ver todas sus ofertas.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/vermisofertas"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.Empresas.ContainsKey(mensaje.Id))
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/vermisofertas");

                Empresa value = Singleton<ContenedorPrincipal>.Instancia.Empresas[mensaje.Id];
                string texto = LogicaEmpresa.VerMisOfertas(value) + OpcionesUso.AccionesEmpresas();

                Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();

                respuesta = texto;
                return true;
            }
            else
            {
                respuesta = "Usted no es una empresa, no puede usar este comando.";
                return true;
            }
        }
    }
}