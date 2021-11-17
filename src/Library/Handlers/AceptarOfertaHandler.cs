using Telegram.Bot.Types;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase contiene un método para aceptar una oferta.
    /// </summary>
    public class AceptarOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Este método se encarga de aceptar una oferta.
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public AceptarOfertaHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"Aceptar oferta", "aceptar oferta"};
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="respuesta"></param>
        /// <returns></returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (this.CanHandle(mensaje))
            {
                string[] mensajeProcesado = mensaje.Text.Split();
                if (Logica.Empresas.ContainsKey(mensaje.Id))
                {
                    Empresa value = Logica.Empresas[mensaje.Id];
                    LogicaEmpresa.AceptarOferta(value, mensajeProcesado[1]);
                    
                    respuesta = $"Oferta aceptada con exito {mensajeProcesado[1]}.";
                    return true;
                }
            }

            respuesta = string.Empty;
            return false;
        }
    }
}
