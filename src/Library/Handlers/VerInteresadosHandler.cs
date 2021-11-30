using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/verinteresados" y se encarga
    /// de manejar el caso en que se quieran ver los interesados en una Oferta específica.
    /// </summary>
    public class VerInteresados : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="VerInteresados"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public VerInteresados(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/verinteresados" };
        }

        /// <summary>
        /// Procesa el mensaje para que se puedan ver los interesados en una Oferta específica.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/verinteresados"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.Empresas.ContainsKey(mensaje.Id))
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/verinteresados");
                    
                Empresa value = Singleton<ContenedorPrincipal>.Instancia.Empresas[mensaje.Id];
                string texto = LogicaEmpresa.VerInteresados(value) + OpcionesUso.AccionesEmpresas();
                Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                respuesta = texto;
                return true;             
            }
            else
            {
                respuesta = $"Usted no es una empresa, no puede usar este comando.";
                return true;
            }
        }
    }
}