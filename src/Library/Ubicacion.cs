using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de contener la Ubicacion.
    /// </summary>
    public class Ubicacion
    {
        /// <summary>
        /// Constructor sin parametros de la clase Ubicacion, ya que es esencial el atributo JsonConstructor
        /// para la serialización de datos en la clase.
        /// </summary>
        [JsonConstructor]
        public Ubicacion()
        {
        }

        /// <summary>
        /// /// Inicializa una nueva instancia de la clase <see cref="Ubicacion"/>.
        /// </summary>
        /// <param name="nombre">Nombre.</param>
        public Ubicacion(string nombre)
        {
            this.NombreCalle = nombre;
        }

        /// <summary>
        /// Esta propiedad contiene el nombre de la calle.
        /// </summary>
        /// <value>Valor es un string del nombre.</value>
        public string NombreCalle { get; set; }

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
    }
}