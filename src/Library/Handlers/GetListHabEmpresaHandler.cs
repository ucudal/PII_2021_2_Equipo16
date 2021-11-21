using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "hola".
    /// </summary>
    public class GetLisHabEmpresaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="next">El próximo "handler"</param>
        public GetLisHabEmpresaHandler(BaseHandler next):base(next)
        {
            this.Keywords = new string[] {"!ListaDeHabilitaciones"};
        }

        /// <summary>
        /// Este método procesa el mensaje "Lista de habilitaciones" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns></returns>
        protected override bool InternalHandle(IMensaje message, out string response)
        {
            if (Logica.HistorialDeChats.ContainsKey(message.Id))
            {
                if (this.CanHandle(message))
                {
                    Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                }
                else
                {
                    if ((message.Text.StartsWith("!") == false) && (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!ListaDeHabilitaciones") == true))
                    {
                        Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                    }
                    else
                    {
                        response = string.Empty;
                        return false;
                    }
                }
            }
            if (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!ListaDeHabilitaciones") == true)
            {
                List<string> listaConParam = Logica.HistorialDeChats[message.Id].BuscarUltimoComando("!ListaDeHabilitaciones");
                
                if (Logica.Empresas.ContainsKey(message.Id))
                {
                    Empresa value = Logica.Empresas[message.Id];
                    // Utiliza el método de la clase LogicaEmpresa para obtener la lista de habilitaciones que tiene la Empresas en cuestion.
                    string hab = LogicaEmpresa.GetHabilitacionList(value);
                    response = $"La lista de habilitaciones es \n{hab} ";
                    return true;
                }
                }
                else
                {
                    // En caso de que la Empresa no contenga habilitaciones relacionadas.
                    response = "No se ha podido obtener las habilitaciones";
                    return true;
                }
            response = string.Empty;
            return false;
        }
    }
}
