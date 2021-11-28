using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "hola".
    /// </summary>
    public class VerMisOfertasHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="next"></param>
        public VerMisOfertasHandler(BaseHandler next):base(next)
        {
            this.Keywords = new string[] {"/vermisofertas"};
        }

        /// <summary>
        /// Este método procesa el mensaje "!verempresa" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns></returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/vermisofertas"))
            {
                respuesta = string.Empty;
                return false;
            }

            if (Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/vermisofertas") == true)
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/vermisofertas");
                if (Singleton<ContenedorPrincipal>.Instancia.Empresas.ContainsKey(mensaje.Id))
                {
                    Empresa value = Singleton<ContenedorPrincipal>.Instancia.Empresas[mensaje.Id];
                    string texto = LogicaEmpresa.VerMisOfertas(value) + OpcionesUso.AccionesEmpresas();

                    respuesta = texto;
                    return true;
                }
            }
            respuesta = string.Empty;
            return false;
        }
    }
}