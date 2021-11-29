using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Creada clase Usuario de forma publica para que se pueda acceder desde cualquier parte del programa.
    /// </summary>
    /// <remarks>
    /// Creamos la clase Usuario con el fin de que la misma pueda ser usada en la reutilización del código en el programa.
    /// </remarks>
    public class Usuario
    {
        /// <summary>
       /// Constructor sin parametros de la clase Usuario, ya que es esencial el atributo JsonConstructor
       /// para la serialización de datos en la clase.
       /// </summary>
       /// <returns></returns>
        [JsonConstructor]
        public Usuario()
        {

        }
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Usuario"/>.
        /// </summary>
        /// <param name="nombre">Recibe un parametro de tipo string con el valor de "nombre".</param>
        /// <param name="ubicacion">Recibe un parametro de tipo string con el valor de "ubicacion".</param>
        /// <param name="rubro">Recibe un parametro de tipo Rubro con el valor de "rubro".</param>
        public Usuario(string nombre, string ubicacion, string rubro)
        {
            Console.WriteLine($"rubro es {rubro}");
            Console.WriteLine($"nombre es {nombre}");
            Console.WriteLine($"ubi es {ubicacion}");
            this.Nombre = nombre;
            this.Ubicacion = new Ubicacion(ubicacion);
            if (!Singleton<ContenedorRubroHabilitaciones>.Instancia.ChequearRubro(rubro))
            {
                throw new ArgumentException($"{rubro} no se encuentra disponible");
            }
            else
            {
                this.Rubro = Singleton<ContenedorRubroHabilitaciones>.Instancia.GetRubro(rubro);
            }
        }

        /// <summary>
        /// Obtiene o establece un valor que indica el nombre del usuario.
        /// </summary>
        /// <value>Tipo string.</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el valor que indica la ubicación del usuario.
        /// </summary>
        /// <value>Tipo string.</value>
        
        public Ubicacion Ubicacion { get; set; }

        /// <summary>
        /// Obtiene o establece el valor con el rubro del usuario.
        /// </summary>
        /// <value>Tipo Rubro.</value>
        public Rubro Rubro { get; set; }
        
        /// <summary>
        /// Metodo que utiliza gracias a la interfaz IJsonConvertible para convertir a formato Json y aplicar en persistencia. 
        /// </summary>
        /// <returns></returns>

        /// <summary>
        /// 
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