using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Clase publica Material, para que puedan acceder a sus atributos y metodos.
    /// </summary>
    /// <remarks>
    /// Para esta clase se utilizó el patron de diseño de Expert, ya que desde nuestro punto de vista,
    /// la clase Rubro tiene metodos que sean exclusivos de su clase ya que es la que se encarga de conocer 
    /// todo lo necesario para hacer posible la ejecución de sus métodos, y que no sean necesarios para el resto de clases.
    /// </remarks>
    public class Material
    {
       /// <summary>
       /// Constructor sin parametros de la clase Material, ya que es esencial el atributo JsonConstructor
       /// para la serialización de datos en la clase.
       /// </summary>
        [JsonConstructor]
        public Material()
        {
        }

       /// <summary>
       /// Inicializa una nueva instancia de la clase.
       /// </summary>
       /// <param name="nombre">Recibe por parametro el nombre del matrial.</param>
       /// <param name="cantidad">Recibe por parametro la cantidad del matrial.</param>
       /// <param name="precio">Recibe por parametro el precio del matrial.</param>
       /// <param name="unidad">Recibe por parametro la unidad del matrial.</param>
        public Material(string nombre, string cantidad, string precio, string unidad)
        {
            this.Nombre = nombre;
            this.Unidad = unidad;
            if (!Int32.TryParse(cantidad, out _))
            {
                throw new ArgumentException("Debe ingresar la cantiad en formalto numerico");
            }
            else
            {
               this.Cantidad = cantidad; 
            }

            if (!Int32.TryParse(precio, out _))
            {
                throw new ArgumentException("Debe ingresar el precio en formalto numerico");
            }
            else
            {
                this.Precio = precio;
            }
        }

        /// <summary>
        /// Obtiene o establece el nombre del material.
        /// </summary>
        /// <value>string</value>
        public string Nombre { get; set;}
        
        /// <summary>
        /// obtiene o establece la cantidad del material.
        /// </summary>
        /// <value>string</value>
        public string Cantidad { get; set;}
        
        /// <summary>
        /// obtiene o establece el precio del material.
        /// </summary>
        /// <value>string</value>
        public string Precio { get; set;}
        
        /// <summary>
        /// obtiene o establece la unidad del material.
        /// </summary>
        /// <value>string</value>
        public string Unidad { get; set;}
        
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