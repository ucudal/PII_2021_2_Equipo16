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
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/vermisofertas"))
            {
                respuesta = string.Empty;
                return false;
            }

            if (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/vermisofertas") == true)
            {
                List<string> listaConParametros = Logica.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/vermisofertas");
                if (Logica.Empresas.ContainsKey(mensaje.Id))
                {
                    Empresa value = Logica.Empresas[mensaje.Id];
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