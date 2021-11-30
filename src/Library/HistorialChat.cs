using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se formó usando Expert y SRP, surgió de la necesidad de que el usuario que se comunique con el bot,
    /// y tenga un historial relacionado.
    /// </summary>
    public class HistorialChat : IJsonConvertible
    {
        /// <summary>
        /// Constructor sin parametros de la clase HistorialChat, ya que es esencial el atributo JsonConstructor
        /// para la serialización de datos en la clase.
        /// </summary>
        [JsonConstructor]
        public HistorialChat()
        {
        }

        /// <summary>
        /// Contiene los mensajes enviados por el Usuario.
        /// </summary>
        [JsonInclude]
        public List<string> MensajesDelUser { get; set; } = new List<string>();

        /// <summary>
        /// Esta lista contiene los mensajes del usuarios listados en forma inversa.
        /// </summary>
        [JsonInclude]
        public List<string> MensajesDelUserReves { get; set; } = new List<string>();

        /// <summary>
        /// Devueleve una lista que contiene los mensajes despues de el comando ingresado.
        /// </summary>
        /// <param name="comando">Recibe por parametro un string con el comando ingresado.</param>
        /// <returns></returns>
        public List<string> BuscarUltimoComando(string comando)
        {
            List<string> parametrosIngresadosDelComando = new List<string>();
            foreach (string elemento in this.MensajesDelUser)
            {
               this.MensajesDelUserReves.Add(elemento);
            }

            this.MensajesDelUserReves.Reverse();
            foreach (string mensajeParametro in this.MensajesDelUserReves)
            {
                if (mensajeParametro == comando)
                {
                    return parametrosIngresadosDelComando;
                }

                parametrosIngresadosDelComando.Add(mensajeParametro);
            }

            this.MensajesDelUserReves.Clear();
            return parametrosIngresadosDelComando;
        }

        /// <summary>
        /// Chequeo para ver si su ultimo comando ingresado es el buscado en los handlers.
        /// </summary>
        /// <param name="comando">Recibe por parametro un string con el comando ingresado.</param>
        /// <returns>Retorna true si el comando ingresado esta correctamente, o false en caso contrio.</returns>
        public bool ComprobarUltimoComandoIngresado(string comando)
        {
            foreach (string elemento in this.MensajesDelUser)
            {
               this.MensajesDelUserReves.Add(elemento);
            }

            this.MensajesDelUserReves.Reverse();

            foreach (string item in this.MensajesDelUserReves)
            {
                if (item.StartsWith("/"))
                {
                    if (item == comando)
                    {
                        this.MensajesDelUserReves.Clear();
                        return true;
                    }

                    this.MensajesDelUserReves.Clear();
                    return false;
                }
            }

            this.MensajesDelUserReves.Clear();
            return false;
        }

        /// <summary>
        /// Metodo que utiliza gracias a la interfaz IJsonConvertible para convertir a formato Json y aplicar en persistencia.
        /// </summary>
        /// <returns>Retorna el objeto serializado.</returns>
        public string ConvertirJson()
        {
            JsonSerializerOptions opciones = new ()
            {
                WriteIndented = true,
                ReferenceHandler = MyReferenceHandler.Instance,
            };
            return JsonSerializer.Serialize(this, opciones);
        }

        /// <summary>
        /// Metodo con el fin de poder limpiar el historial del chat para no consumir tanta memoria.
        /// </summary>
        public void HistorialClear()
        {
            this.MensajesDelUser.Clear();
            this.MensajesDelUserReves.Clear();
        }
    }
}