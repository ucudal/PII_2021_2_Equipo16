namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "hola".
    /// </summary>
    public class CalcularOfertasCompradasHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="next">El próximo "handler"</param>
        public CalcularOfertasCompradasHandler(BaseHandler next):base(next)
        {
            this.Keywords = new string[] {"Calcular ofertas", "ofertas compradas", "Calcular ofertas compradas"};
        }

        /// <summary>
        /// Este método procesa el mensaje "Calculas ofertas compradas" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns></returns>
        protected override bool InternalHandle(IMensaje message, out string response)
        {
            if (this.CanHandle(message))
            {
                // El mensaje debe tener el formato "Agregar habilitacion de oferta, habilitacion, nombre de la oferta" o sus keywords
                string[] mensajeProcesado = message.Text.Split();
                if (Logica.Empresas.ContainsKey(message.Id))
                {
                    Empresa value = Logica.Empresas[message.Id];
                    /* #########################################################
                    FALTA TERMINAR A LA ESPERA DE METODO PARA LLAMAR "RESPONSE"
                    
                    int hab = LogicaEmpresa.CalcularOfertasVendidas(value, fechaInicio, fechaFinal);

                    response = $"La lista de habilitaciones es: \n {hab}.";
                    ############################################################
                    */
                    response = "falta terminar";
                    return true;
                }
            }
            response = string.Empty;
            return false;
        }

    }
}