using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "hola".
    /// </summary>
    public class VerInteresados : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="next"></param>
        public VerInteresados(BaseHandler next):base(next)
        {
            this.Keywords = new string[] {"/verinteresados"};
        }

        /// <summary>
        /// Este método procesa el mensaje "!VerInteresados" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/verinteresados"))
            {
                respuesta = string.Empty;
                return false;
            }

            if (Singleton<Logica>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/verinteresados") == true)
            {
                List<string> listaConParametros = Singleton<Logica>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/verinteresados");
                if (Singleton<Logica>.Instancia.Empresas.ContainsKey(mensaje.Id))
                {
                    Empresa value = Singleton<Logica>.Instancia.Empresas[mensaje.Id];
                    string texto = LogicaEmpresa.VerInteresados(value)+OpcionesUso.AccionesEmpresas();
                    respuesta = texto;
                    return true;
                }
                else
                {
                    respuesta = $"Usted no es una empresa, no puede usar este comando.";
                    return true;
                }
            }
            
            respuesta = string.Empty;
            return false;
        }
    }
}