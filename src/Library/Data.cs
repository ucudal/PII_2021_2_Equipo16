using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class Data
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        
        public Data()
        {
            
        }

        /// <summary>
        /// Procesa el mensaje "!Eliminar oferta" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
        public static void Actualizar()
        {
            
            ConsolePrinter.DatoPrinter("entro aca");
            JsonSerializerOptions opciones = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };      
            
            if (!System.IO.File.Exists(@"..\Library\Persistencia\logica.json"))
            {
                ConsolePrinter.DatoPrinter("entro aca primer if");
                //Logica logica = Singleton<Logica>.Instancia;
                string logicaToJson = Singleton<Logica>.Instancia.ConvertToJson();
                System.IO.File.WriteAllText(@"..\Library\Persistencia\logica.json", logicaToJson);
            }
            else
            {
                ConsolePrinter.DatoPrinter("entro aca else");
                
                string logicaToJson = System.IO.File.ReadAllText(@"..\Library\Persistencia\logica.json");
                Singleton<Logica>.Instancia = JsonSerializer.Deserialize<Logica>(logicaToJson, opciones);
            }
        }
    }
}