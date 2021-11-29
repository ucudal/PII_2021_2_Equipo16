using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "hola".
    /// </summary>
    public class VerEmprendedorHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="next"></param>
        public VerEmprendedorHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/veremprendedor"};
        }

        /// <summary>
        /// Este método procesa el mensaje "/VerEmprendedor" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
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
                    string texto = LogicaEmprendedor.VerEmprendedor(par.Value) + OpcionesUso.AccionesEmpresas();
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