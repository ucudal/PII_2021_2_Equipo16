
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa las habilitaciones existentes
    /// </summary>
    public class Habilitaciones : IHabilitaciones
    {
        /// <summary>
        /// Esta lista contiene un conjunto de habilitaciones predeterminadas
        /// </summary>
        /// <returns></returns>
        public List<string> ListaHabilitaciones = new List<string>
                    {
                    "iso 9009", "apa", "soa", "unit", "ieee"
                    };

        /// <summary>
        /// Inicializa una instancia de habilitaciones
        /// </summary>
        public Habilitaciones(string nombre)
        {
            if (ListaHabilitaciones.Contains(nombre))
            {
                this.Nombre = nombre;
            }
            else 
            {
                Console.WriteLine("El nombre de la habilitación no existe, ¿desea agregarlo?");
                string respuesta = Console.ReadKey().ToString();
                respuesta = LimpiadorCadena.LimpiaCadena(respuesta);
                if (respuesta == "si")
                {
                    ListaHabilitaciones.Add(nombre);
                    this.Nombre = nombre;
                }
            }
        }

        /// <summary>
        /// Este valor indica el nombre de la habilitación
        /// </summary>
        /// <value>Valor es un string del nombre</value>
        public string Nombre {get; set;}

        /// <summary>
        /// Este método permite ver graficamente cuales son las habilitaciones disponibles
        /// Para poder ver cuales son las habilitaciones utiliza un StringBuilder para poder obtener un string al final
        /// </summary>
        public void HabilitacionesDisponibles()
        {
            StringBuilder habDisponibles = new StringBuilder();
            int contador = 1;
            foreach (string habilitacion in this.ListaHabilitaciones)
            {
                habDisponibles.Append($"{contador}- {habilitacion}.\n");
                contador ++;
            }
            Console.WriteLine(habDisponibles.ToString());
        }

        /// <summary>
        /// Este método permite agregar habilitaciones a la lista de habilitaciones
        /// </summary>
        /// <param name="nombre"> Recibe un parametro de tipo string del nombre de la habilitación deseada</param>
        public void AddHabilitacion(string nombre)
        {
            this.ListaHabilitaciones.Add(nombre);
        }

        /// <summary>
        /// Este método imprime en consola la lista de habilitaciones
        /// para realizar esto utiliza un StringBuilder y recorre la lista de Hablilitaciones
        /// </summary>
        public void GetHabilitacionList()
        {
            StringBuilder texto = new StringBuilder("Lista de Habilitaciones: \n");
            foreach (string nombreHabilitacion in ListaHabilitaciones)
            {
                texto.Append($"- {nombreHabilitacion}");
            }
            Console.WriteLine(texto.ToString());
        }

        /// <summary>
        /// Este método sirve para eliminar habilitaciones que estan en la lista de Habilitaciones
        /// </summary>
        /// <param name="nombre">Recibe por parametro un string del nombre de la habilitación deseada</param>
        public void RemoveHabilitacion(string nombre)
        {
            this.ListaHabilitaciones.Remove(nombre);
        }
    }
}