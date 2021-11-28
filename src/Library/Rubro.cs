using System;
using System.Text;
using System.Xml.Serialization;

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
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Rubro"/>.
        /// </summary>
        public Rubro()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        
        public enum Rubros
        {
            /// <value>Nombre de un rubro.</value>
            Textil,
            /// <value>Nombre de un rubro.</value>
            Construccion,
            /// <value>Nombre de un rubro.</value>
            Comercio,
            /// <value>Nombre de un rubro.</value>
            Servicio,
            /// <value>Nombre de un rubro.</value>
            Forestal,
            /// <value>Nombre de un rubro.</value>
            Comunicaciones,
            /// <value>Nombre de un rubro.</value>
            Entretenimiento,
            /// <value>Nombre de un rubro.</value>
            Deportes,
            /// <value>Nombre de un rubro.</value>
            Industria,
        }


        /// <summary>
        /// Obtiene lista de rubros. Se usa SRP y Expert ya que conoce todo lo necesario para llevar a cabo esta responsabilidad.
        /// </summary>
        public static string GetRubros()
        {
            StringBuilder getRubrosList = new StringBuilder("Rubros disponibles: \n");
            foreach (Rubros rubro in typeof(Rubros).GetEnumValues())
            {
                getRubrosList.Append($"- {rubro.ToString()}.\n");
            }

            ConsolePrinter.DatoPrinter(getRubrosList.ToString());
            return getRubrosList.ToString();
        }

        /// <summary>
        /// Chequea si un rubro existe en la lista. Se usa SRP y Expert ya que conoce todo lo necesario para llevar a cabo esta responsabilidad.
        /// </summary>
        /// <param name="rubro">Rubro.</param>
        /// <returns><c>True</c> si existe el rubro en la lista, <c>False</c> si no existe.</returns>
        

        public static bool CheckRubro(string rubro)
        {
            Rubros rubroE;
            return Enum.TryParse<Rubros>(rubro, true, out rubroE) ? true : throw new ArgumentException("Por favor ingrese un rubro que exista");
        }
    }
}