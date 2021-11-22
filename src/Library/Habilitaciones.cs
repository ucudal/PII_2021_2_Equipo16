using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa el global de las habilitaciones existentes, que implementa la interfaz IHabilitaciones.
    /// La implementación de la interfaz es necesaria para unificar el nombre de su método con otras clases que tiene similares caracteristicas.
    /// </summary>
    public class Habilitaciones : IHabilitaciones
    {
        /// <summary>
        /// Esta lista contiene un conjunto de habilitaciones predeterminadas.
        /// </summary>
        public List<string> ListaHabilitaciones = new List<string>
            { "iso 9009", "apa", "soa", "unit", "ieee" };

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Habilitaciones"/>.
        /// </summary>
        public Habilitaciones()
        {
        }

        /// <summary>
        /// Obtiene o establece el nombre de la habilitación.
        /// </summary>
        /// <value>Valor es un string del nombre.</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Este método retorna un string con las habilitaciones de la lista.
        /// Para poder ver cuales son las habilitaciones utiliza un StringBuilder para poder obtener un string al final.
        /// </summary>
        /// <returns>Retorna las habilitaciones disponibles.</returns>
        public string HabilitacionesDisponibles()
        {
            StringBuilder habDisponibles = new StringBuilder();
            int contador = 1;
            foreach (string habilitacion in this.ListaHabilitaciones)
            {
                habDisponibles.Append($"{contador}- {habilitacion}.\n");
                contador++;
            }

            string habDis = habDisponibles.ToString();
            return habDisponibles.ToString();
        }

        /// <summary>
        /// Este método permite agregar habilitaciones a la lista de habilitaciones.
        /// </summary>
        /// <param name="habilitacionBuscada"> Recibe un parametro de tipo string del nombre de la habilitación deseada.</param>
        public void AddHabilitacion(string habilitacionBuscada)
        {
            this.ListaHabilitaciones.Add(habilitacionBuscada);
            Console.WriteLine($"Fue agregada la habilitación '{habilitacionBuscada}' de la lista.");
        }

        /// <summary>
        /// Este método imprime en consola la lista de habilitaciones para realizar esto utiliza un StringBuilder y recorre la lista de Habilitaciones.
        /// </summary>
        public string GetListaHabilitaciones()
        {
            StringBuilder texto = new StringBuilder("Lista de Habilitaciones: \n");
            foreach (string nombreHabilitacion in this.ListaHabilitaciones)
            {
                texto.Append($"- {nombreHabilitacion}");
            }

           return texto.ToString();
        }

        /// <summary>
        /// Este método sirve para eliminar habilitaciones que estan en la lista de Habilitaciones.
        /// </summary>
        /// <param name="habilitacion">Recibe por parametro un string del nombre de la habilitación deseada.</param>
        public void RemoveHabilitacion(string habilitacion)
        {
            this.ListaHabilitaciones.Remove(habilitacion);
            Console.WriteLine($"Fue removida la habilitación '{habilitacion}' de la lista.");
        }
    }
}