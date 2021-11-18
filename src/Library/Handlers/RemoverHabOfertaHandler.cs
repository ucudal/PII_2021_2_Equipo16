using System.Collections.Generic;
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
            
            if (Logica.HistorialDeChats.ContainsKey(message.Id))
            {
                Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text);
            }
            else
            {
                Logica.HistorialDeChats.Add(message.Id, new HistorialChat());
                Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text);
            }

            if (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!RemoverHabOferta") == true)
            {
                // El mensaje debe tener el formato "Remover habilitacion de oferta,nombre de la oferta,habilitacion"
                List<string> listaConParam = Logica.HistorialDeChats[message.Id].BuscarUltimoComando("!RemoverHabOferta");

                if (listaConParam.Count == 0)
                {
                    response = "ingrese el nombre de la oferta a la que desea eliminar una habilitacion";
                    return true;
                    //Console.WriteLine("Entro aca");
                }
                if (listaConParam.Count == 1)
                {
                    response = "ingrese el nombre de la habilitacion que desea remover";
                    return true;
                }
                if (listaConParam.Count == 2)
                {
                    string nombreOferta = listaConParam[1];
                    string nombreHabParaEliminar = listaConParam[0];

                    if (Logica.Empresas.ContainsKey(message.Id))
                    {
                        Empresa value = Logica.Empresas[message.Id];
                        LogicaEmpresa.RemoveHabilitacionOferta(value, nombreOferta, nombreHabParaEliminar);
                        
                        response = $"Se ha removido la habilitacion {nombreHabParaEliminar} de la oferta {nombreOferta}.";
                        return true;
                    }
                }

                
                
            }

            response = string.Empty;
            return false;
        }
    }
}