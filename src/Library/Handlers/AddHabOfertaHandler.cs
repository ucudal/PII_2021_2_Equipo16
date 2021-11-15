using Telegram.Bot.Types;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class AddHabOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public AddHabOfertaHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"Agregar habilitacion de oferta", "agregar habilitacion de oferta", "Crear habilitacion de oferta", "crear habilitacion de oferta"};
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
                if (Logica.Empresas.ContainsKey(message.Id))
                {
                    Empresa value = Logica.Empresas[message.Id];
                    LogicaEmpresa.AddHabilitacionOferta(value, mensajeProcesado[1], mensajeProcesado[2]);

                    response = $"Se ha agregado la habilitacion {mensajeProcesado[1]} de la oferta {mensajeProcesado[2]}.";
                    return true;
                }

            }

            response = string.Empty;
            return false;
        }
    }
} 