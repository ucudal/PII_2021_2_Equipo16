using Telegram.Bot.Types;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class RemoverHabOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RemoverHabOfertaHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"Remover habilitacion de oferta", "remover habilitacion de oferta"};
        }

        /// <summary>
        /// Procesa el mensaje "Registrarse" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje message, out string response)
        {
            if (this.CanHandle(message))
            {
                // El mensaje debe tener el formato "Remover habilitacion de oferta,nombre de la oferta,habilitacion"
                string[] mensajeProcesado = message.Text.Split();
                if (Logica.Empresas.ContainsKey(message.Id))
                {
                    Empresa value = Logica.Empresas[message.Id];
                    LogicaEmpresa.RemoveHabilitacionOferta(value, mensajeProcesado[1], mensajeProcesado[2]);
                    
                    response = $"Se ha removido la habilitacion {mensajeProcesado[2]} de la oferta {mensajeProcesado[1]}.";
                    return true;
                }
                
            }

            response = string.Empty;
            return false;
        }
    }
}