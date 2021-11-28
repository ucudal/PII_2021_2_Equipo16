using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Ubicacion
    {
        [JsonConstructor]
        public Ubicacion()
        {

        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Ubicacion"/>.
        /// </summary>
        public Ubicacion(string nombre)
        {
            this.NombreCalle = nombre;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <value>Valor es un string del nombre.</value>
        public string NombreCalle { get; set;}

        public string ConvertirJson()
        {
            JsonSerializerOptions opciones = new()
            {
                WriteIndented = true,
                ReferenceHandler = MyReferenceHandler.Instance,
            };

            return JsonSerializer.Serialize(this, opciones);
        }


    }
}