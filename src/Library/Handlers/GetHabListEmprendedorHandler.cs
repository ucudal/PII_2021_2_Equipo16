using System.Collections.Generic;

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
            this.Keywords = new string[] {"!ListaDeHabilitaciones"};
        }

        /// <summary>
        /// Procesa el mensaje "Lista de habilitaciones" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje message, out string response)
        {
             if (Logica.HistorialDeChats.ContainsKey(message.Id))
            {
                if (this.CanHandle(message))
                {
                    //Console.WriteLine("Entre");
                    Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                }
                else
                {
                    if ((message.Text.StartsWith("!") == false) && (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!ListaDeHabilitaciones") == true))
                    {
                        //Console.WriteLine("Entre22");
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
                    Emprendedor value = Logica.Emprendedores[message.Id];
                    string hab = LogicaEmprendedor.GetHabilitacionList(value);
                    response = $"La lista de habilitaciones es \n{hab} ";
                    return true;
                }
                }
                else
                {
                    response = "No se ha podido obtener las habilitaciones";
                    return true;
                }
            response = string.Empty;
            return false;
            }
        }
            
    } 
