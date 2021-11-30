using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/verempresa" y se encarga
    /// de manejar el caso en que se quiera ver la información de una Empresa.
    /// </summary>
    public class VerEmpresaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="VerEmpresaHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public VerEmpresaHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/verempresa" };
        }

        /// <summary>
        /// Procesa el mensaje para que se pueda ver la información de una Empresa.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/verempresa"))
            {
                respuesta = string.Empty;
                return false;
            }

            List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/verempresa");
            if (listaConParametros.Count == 0)
            {
                respuesta = "Ingrese el nombre de la empresa que quiera ver";
                return true;
            }

            string nombreBuscado = listaConParametros[0];
            foreach (KeyValuePair<string, Empresa> par in Singleton<ContenedorPrincipal>.Instancia.Empresas)
            {
                if (par.Value.Nombre == nombreBuscado)
                {
                    string texto = LogicaEmpresa.VerEmpresa(par.Value);
                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                    respuesta = texto;
                    return true;
                }
            }

            respuesta = string.Empty;
            return false;
        }
    }
}