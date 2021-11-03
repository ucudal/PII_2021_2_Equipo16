using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Clase publica Rubro, para que puedan acceder a sus atributos y metodos.
    /// </summary>
    public class Rubro
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Rubro"/>.
        /// </summary>
        public Rubro()
        {
            
        }

        /// <summary>
        /// Obtiene o establece un valor con el nombre del Rubro.
        /// </summary>
        /// <value>Retorna tipo string.</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Lista publica para que puedan acceder las demas clases, la lista contiene los objetos rubros creados.
        /// </summary>
        /// <returns>Retorna una nueva lista llamada RubrosList de tipo string.</returns>
        public static List<string> RubrosList = new List<string>()
            {"textil", "construccion", "comercio", "servicio", "forestal", "comunicaciones", "entretenimiento", "deportes", "industria"};
        
        /// <summary>
        /// Añade un rubro a la lista, devuelve un string confirmando la acción.
        /// </summary>
        /// <param name="rubro">Recibe un parametro de tipo string con el nombre de "rubro".</param>
    
        public void AddRubro(string rubro)
        {
            if (!Rubro.RubrosList.Contains(rubro))
            {
                Rubro.RubrosList.Add(rubro);
                Console.WriteLine($"Rubro '{rubro}' agregado exitosamente.");
            }
            else
            {
                Console.WriteLine($"El rubro '{rubro}' ya existe.");
            }
        }

        /// <summary>
        /// Elimina un rubro de la lista, devuelve un string confirmando la acción.
        /// </summary>
        /// <param name="rubro">Recibe un parametro de tipo string con el nombre de "rubro".</param>
        public void RemoveRubro(string rubro)
        {
            Rubro.RubrosList.Remove(rubro);
            Console.WriteLine($"Rubro '{rubro}' eliminado exitosamente.");
        }

        /// <summary>
        /// Obtiene lista de rubros.
        /// </summary>
        public void GetRubrosList()
        {
            StringBuilder getRubrosList = new StringBuilder("Habilitaciones: \n");
            foreach (string rubro in Rubro.RubrosList)
            {
                getRubrosList.Append($"- {rubro}.");
            }

            Console.WriteLine(getRubrosList.ToString());
        }
        /// <summary>
        /// Chequea si un rubro existe en la lista.
        /// </summary>
        /// <param name="rubro">rubro</param>
        /// <returns>booleano</returns>
        public static bool CheckRubro(string rubro)
        {
            if (RubrosList.Contains(rubro))
            {
                
                return true;
            }
            else
            {
                Console.WriteLine($"El rubro '{rubro}' no existe.");
                return false;
                
            }
        }
    }
}