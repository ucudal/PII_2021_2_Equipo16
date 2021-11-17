using Telegram.Bot.Types;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase contiene un método para remover habilitaciones de empresas.
    /// </summary>
    public class RemoveHabEmpresaHandler : BaseHandler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public RemoveHabEmpresaHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"Remover habilitacion", "remover habilitacion"};
        }
        
        /// <summary>
        /// Se encarga de procesar el mensaje para determinar si se removerá una habilitación.
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
                    LogicaEmpresa.RemoveHabilitacion(value, mensajeProcesado[1]);
                    
                    respuesta = $"Se ha removido la habilitacion con exito {mensajeProcesado[1]}.";
                    return true;
                }
            }

            respuesta = string.Empty;
            return false;
        }
    }
}   