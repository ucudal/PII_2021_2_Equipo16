using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/veremprendedor" y se encarga
    /// de manejar el caso en que se quiera ver la información de un Emprendedor.
    /// </summary>
    public class VerEmprendedorHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="VerEmprendedorHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public VerEmprendedorHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/veremprendedor" };
        }

        /// <summary>
        /// Procesa el mensaje para que se pueda ver la información de un Emprendedor.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/veremprendedor"))
            {
                respuesta = string.Empty;
                return false;
            }
            List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/veremprendedor");
            if (listaConParametros.Count == 0)
            {
                respuesta = "Ingrese el nombre del emprenedor que quiera ver";
                return true;
            }

            string nombreBuscado = listaConParametros[0];
            foreach (KeyValuePair<string, Emprendedor> par in Singleton<ContenedorPrincipal>.Instancia.Emprendedores)
            {
                if (par.Value.Nombre == nombreBuscado)
                {
                    string texto = LogicaEmprendedor.VerEmprendedor(par.Value);
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