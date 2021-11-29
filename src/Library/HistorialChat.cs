using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class HistorialChat : IJsonConvertible
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonConstructor]
        public HistorialChat()
        {
        }

        /// <summary>
        /// Contiene los mensajes enviados por el Usuario.
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public List<string> MensajesDelUser {get; set;} = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public List<string> MensajesDelUserReves {get; set; } = new List<string>();

        /// <summary>
        /// Devueleve una lista que contiene los mensajes despues de el comando ingresado
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        
        public List<string> BuscarUltimoComando(string comando)
        {
            List<string> ParametrosIngresadosDelComando = new List<string>();
            foreach (string elemento in MensajesDelUser)
            {
               MensajesDelUserReves.Add(elemento); 
            }

            MensajesDelUserReves.Reverse(); 
            foreach (string mensajeParametro in MensajesDelUserReves)
            {
                if (mensajeParametro == comando)
                {
                    return ParametrosIngresadosDelComando;
                }
                
                ParametrosIngresadosDelComando.Add(mensajeParametro);
            }
            
            MensajesDelUserReves.Clear(); // Dejo en 0 esta lista para q no de errores cuando se inicialize el metodo mas de una vez
            return ParametrosIngresadosDelComando;
        }

        /// <summary>
        /// Chequeo para ver si su ultimo comando ingresado es el buscado en los handlers
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        public bool ComprobarUltimoComandoIngresado(string comando)
        {
            foreach (string elemento in MensajesDelUser)
            {
               MensajesDelUserReves.Add(elemento); 
               //ConsolePrinter.DatoPrinter("Este elemento es " + elemento);
            }
            
            MensajesDelUserReves.Reverse();

            foreach (string item in MensajesDelUserReves)
            {
                if (item.StartsWith("/"))
                {
                    if (item == comando)
                    {
                        MensajesDelUserReves.Clear();
                        return true;
                    } 
                    
                    MensajesDelUserReves.Clear();
                    return false;
                }
            }
            
            MensajesDelUserReves.Clear();
            return false;
        }

        /// <summary>
        /// Metodo que utiliza gracias a la interfaz IJsonConvertible para convertir a formato Json y aplicar en persistencia. 
        /// </summary>
        /// <returns></returns>
        public string ConvertirJson()
        {
            JsonSerializerOptions opciones = new()
            {
                WriteIndented = true,
                ReferenceHandler = MyReferenceHandler.Instance,
            };

            return JsonSerializer.Serialize(this, opciones);
        }

        public void HistorialClear()
        {
            this.MensajesDelUser.Clear();
            this.MensajesDelUserReves.Clear();
        }
    }
}