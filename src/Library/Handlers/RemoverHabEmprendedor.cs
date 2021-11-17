namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class RemoverHabEmprendedor : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RemoverHabEmprendedor (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"Remover habilitacion", "remover habilitacion"};
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
                // El mensaje debe tener el formato "Remover habilitacion, x"
                string[] mensajeProcesado = message.Text.Split();
                if (Logica.Emprendedores.ContainsKey(message.Id))
                {
                    Emprendedor value = Logica.Emprendedores[message.Id];
                    LogicaEmprendedor.RemoveHabilitacion(value, mensajeProcesado[1]);
                    
                    response = $"Se ha removido la habilitacion {mensajeProcesado[1]}.";
                    return true;
                }
                
            }

            response = string.Empty;
            return false;
        }
    }
}