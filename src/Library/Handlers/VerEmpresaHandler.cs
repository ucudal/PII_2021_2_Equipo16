using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "hola".
    /// </summary>
    public class VerEmpresaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="next"></param>
        public VerEmpresaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/verempresa"};
        }

        /// <summary>
        /// Este método procesa el mensaje "!verempresa" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
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