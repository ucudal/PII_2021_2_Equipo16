using Telegram.Bot.Types;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class EliminarProductoHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public EliminarProductoHandler (BaseHandler next) : base(next)
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

            if (Logica.HistorialDeChats.ContainsKey(message.Id))
            {
                Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text);
            }
            else
            {
                Logica.HistorialDeChats.Add(message.Id, new HistorialChat());
                Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text);
            }


            if (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!Eliminar producto") == true)
            {
                List<string> listaConParam = Logica.HistorialDeChats[message.Id].BuscarUltimoComando("!Eliminar producto");

                // El mensaje debe tener el formato "Eliminar producto,nombre de la oferta,habilitacion"
                string[] mensajeProcesado = message.Text.Split();

                if (listaConParam.Count == 0)
                {
                    response = "Ingrese el nombre de la oferta que desea eliminar";
                    return true;
                }

                if (listaConParam.Count == 1)
                {
                    string nombreOfertaParaEliminar = listaConParam[0];

                    if (Logica.Empresas.ContainsKey(message.Id))
                    {
                        Empresa value = Logica.Empresas[message.Id];
                        LogicaEmpresa.EliminarProducto(value, nombreOfertaParaEliminar);
                        
                        response = $"Se ha eliminado la oferta {nombreOfertaParaEliminar}.";
                        return true;
                    }
                    else
                    {
                        response = "Usted no está registrado como empresa";
                        return true;
                    }
  
                }

                
                
            }

            response = string.Empty;
            return false;
        }
    }
}