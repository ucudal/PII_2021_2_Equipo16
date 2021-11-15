using Telegram.Bot.Types;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class GetHabListEmprendedorHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public GetHabListEmprendedorHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"Lista de habilitaciones", "lista de habilitaciones", "Habilitaciones", "habilitaciones"};
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
                // El mensaje debe tener el formato "Agregar habilitacion de oferta,habilitacion ,nombre de la oferta" o sus keywords
                string[] mensajeProcesado = message.Text.Split();
                if (Logica.Emprendedores.ContainsKey(message.Id))
                {
                    Emprendedor value = Logica.Emprendedores[message.Id];
                    string hab = LogicaEmprendedor.GetHabilitacionList(value);

                    response = $"La lista de habilitaciones es: \n {hab}.";
                    return true;
                }

            }

            response = string.Empty;
            return false;
        }
    }
} 