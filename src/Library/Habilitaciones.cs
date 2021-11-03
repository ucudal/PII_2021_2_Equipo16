using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa las habilitaciones existentes.
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
           /* if (ListaHabilitaciones.Contains(nombre))
            {
                this.Nombre = nombre;
            }
            else
            {
                Console.WriteLine("El nombre de la habilitación no existe, ¿desea agregarlo?");
                string respuesta = Console.ReadLine().ToString();
                respuesta = LimpiadorCadenas.LimpiaCadena(respuesta);
                if (respuesta == "si")
                {
                    ListaHabilitaciones.Add(nombre);
                    Console.WriteLine($"Fue agregada la habilitación '{nombre}' de la lista.");
                    this.Nombre = nombre;
                }
            }*/
        }

        /// <summary>
        /// Obtiene o establece el nombre de la habilitación.
        /// </summary>
        /// <value>Valor es un string del nombre.</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Este método retorna un string con las habilitaciones de la lista
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
        /// Este método imprime en consola la lista de habilitaciones
        /// para realizar esto utiliza un StringBuilder y recorre la lista de Hablilitaciones.
        /// </summary>
        public void GetHabilitacionList()
        {
            StringBuilder texto = new StringBuilder("Lista de Habilitaciones: \n");
            foreach (string nombreHabilitacion in this.ListaHabilitaciones)
            {
                texto.Append($"- {nombreHabilitacion}");
            }

            Console.WriteLine(texto.ToString());
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