using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa el global de las habilitaciones existentes, que implementa la interfaz IHabilitaciones.
    /// La implementación de la interfaz es necesaria para unificar el nombre de su método con otras clases que tiene similares caracteristicas.
    /// </summary>
    public class Habilitaciones
    {
        /// <summary>
        /// Constructor sin parametros de la clase Habilitaciones, ya que es esencial el atributo JsonConstructor
        /// para la serialización de datos en la clase.
        /// </summary>
        /// <returns></returns>
        [JsonConstructor]
        public Habilitaciones()
        {

        }
        
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Habilitaciones"/>.
        /// </summary>
        public Habilitaciones(string nombre)
        {
            this.Nombre = nombre;
        }

        /// <summary>
        /// Obtiene o establece el nombre de la habilitación.
        /// </summary>
        /// <value>Valor es un string del nombre.</value>
        public string Nombre { get; set;}

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
    }
}