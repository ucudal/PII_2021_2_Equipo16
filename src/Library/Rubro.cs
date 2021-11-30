using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Clase publica Rubro, para que puedan acceder a sus atributos y metodos.
    /// </summary>
    /// <remarks>
    /// Para esta clase se utilizó el patron de diseño de Expert, ya que desde nuestro punto de vista,
    /// la clase Rubro tiene metodos que sean exclusivos de su clase ya que es la que se encarga de conocer 
    /// todo lo necesario para hacer posible la ejecución de sus métodos, y que no sean necesarios para el resto de clases.
    /// </remarks>

    public class Rubro
    {
<<<<<<< HEAD
        /// <summary>
        /// Constructor sin parametros de la clase Rubro, ya que es esencial el atributo JsonConstructor
        /// para la serialización de datos en la clase.
        /// </summary>
        /// <returns></returns>

=======
       /// <summary>
       /// Constructor sin parametros de la clase Rubro, ya que es esencial el atributo JsonConstructor
       /// para la serialización de datos en la clase.
       /// </summary>
>>>>>>> deV2
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
<<<<<<< HEAD
        ///
        /// </summary>
        /// <value></value>
        public string Nombre { get; set; }
=======
        /// Esta propiedad contiene el nombre del rubro.
        /// </summary>
        /// <value>El nombre del Rubro</value>
        public string Nombre { get; set;}
>>>>>>> deV2

        /// <summary>
        /// Metodo que utiliza gracias a la interfaz IJsonConvertible para convertir a formato Json y aplicar en persistencia. 
        /// </summary>
        /// <returns>Retorna la Serializacion.</returns>
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