using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Clase publica Rubro, para que puedan acceder a sus atributos y metodos.
    /// </summary>
    /// <remarks>
    /// Para esta clase se utilizó el patron de diseño de Expert, ya que desde nuestro punto de vista,
    /// la clase Rubro tiene metodos que son exclusivos de su clase ya que es la que se encarga de conocer 
    /// todo lo necesario para hacer posible su correcto funcionamiento.
    /// </remarks>

    public class Rubro
    {
       /// <summary>
       /// Inicializa un constructor sin parametros de la clase Rubro, ya que es esencial el atributo JsonConstructor
       /// para la serialización de datos en la clase.
       /// </summary>
        [JsonConstructor]
        public Rubro()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Rubro"/>.
        /// </summary>
        /// <param name="nombre">Recibe por parametro el nombre del rubro.</param>
        public Rubro(string nombre)
        {
            this.Nombre = nombre;
        }

        /// <summary>
        /// Obtiene o establece el nombre del rubro.
        /// </summary>
        /// <value>El nombre del Rubro.</value>
        public string Nombre { get; set; }

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