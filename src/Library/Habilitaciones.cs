using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa el global de las habilitaciones existentes, que implementa la interfaz IHabilitaciones.
    /// La implementación de la interfaz es necesaria para unificar el nombre de su método con otras clases que tiene similares caracteristicas.
    /// </summary>
    public class Habilitaciones
    {

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
        public string Nombre { get; private set;}


    }
}