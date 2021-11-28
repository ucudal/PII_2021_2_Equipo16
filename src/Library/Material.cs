
using System;
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
        /// Inicializa una nueva instancia de la clase <see cref="Rubro"/>.
        /// </summary>
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
        /// String del nombre del material.
        /// </summary>
        /// <value></value>        
        public string Nombre { get; private set;}

        /// <summary>
        /// String de la cantidad del material.
        /// </summary>
        /// <value></value>
        public string Cantidad { get; private set;}

        /// <summary>
        /// String del precio del material.
        /// </summary>
        /// <value></value>
        public string Precio { get; private set;}

        /// <summary>
        /// String de la unidad del material.
        /// </summary>
        /// <value></value>
        public string Unidad { get; private set;}
    }
}