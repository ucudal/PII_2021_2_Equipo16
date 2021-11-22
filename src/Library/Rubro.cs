using System;
using System.Collections.Generic;
using System.Text;

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

        public enum Rubros
        {
            Textil,
            Construccion,
            Comercio,

            Servicio,

            Forestal,
            Comunicaciones,
            Entretenimiento,
            Deportes,
            Industria,
        }


        /// <summary>
        /// Obtiene lista de rubros. Se usa SRP y Expert.
        /// </summary>
        public string GetRubros()
        {
            StringBuilder getRubrosList = new StringBuilder("Habilitaciones: \n");
            foreach (Rubros rubro in typeof(Rubros).GetEnumValues())
            {
                getRubrosList.Append($"- {rubro.ToString()}.");
            }

            ConsolePrinter.DatoPrinter(getRubrosList.ToString());
            return getRubrosList.ToString();
        }

        /// <summary>
        /// Chequea si un rubro existe en la lista. Se usa SRP y Expert.
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