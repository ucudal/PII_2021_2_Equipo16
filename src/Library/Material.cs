
using System;
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

    public class Material
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Rubro"/>.
        /// </summary>
        public Material(string nombre, string cantidad, string precio, string unidad)
        {
            this.nombre = nombre;
            this.unidad = unidad;
            if (!Int32.TryParse(cantidad, out _))
            {
                throw new ArgumentException("Debe ingresar la cantiad en formalto numerico");
            }
            else
            {
               this.cantidad = cantidad; 
            }

            if (!Int32.TryParse(precio, out _))
            {
                throw new ArgumentException("Debe ingresar el precio en formalto numerico");
            }
            else
            {
                this.precio = precio;
            }
        }

        private string nombre;
        private string cantidad;
        private string precio;
        private string unidad;

        public string Nombre { get => nombre;}
        public string Cantidad { get => cantidad;}
        public string Precio { get => precio;}
        public string Unidad { get => unidad;}
    }
}