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
        /// Recorre la lista de rubros y ve si contiene el nombre para agregarlo o no.
        /// </summary>
        /// <param name="nombre">Nombre.</param>
        public Rubro(string nombre)
        {
            if (RubrosList.Contains(nombre))
            {
                this.Nombre = nombre;
            }
            else 
            {
                Console.WriteLine("El nombre del Rubro no existe, ¿desea agregarlo?");
                string respuesta = Console.ReadLine().ToString();
                respuesta = LimpiadorCadenas.LimpiaCadena(respuesta);
                if (respuesta == "si")
                {
                    RubrosList.Add(nombre);
                    this.Nombre = nombre;
                }
            }
        }
        
        /// <summary>
        /// Obtiene un valor con el nombre del rubro.
        /// </summary>
        /// <value>Retorna tipo string.</value>
        public string Nombre{ get; set; }
        
        /// <summary>
        /// Lista publica para que puedan acceder las demas clases, la lista contiene los objetos rubros creados.
        /// </summary>
        /// <returns>Retorna una nueva lista llamada RubrosList de tipo string.</returns>
        public List<string> RubrosList = new List<string>()
            {
                "textil", "construccion", "comercio", "servicio", "forestal", "comunicaciones", "entretenimiento", "deportes", "industria"
            };
        
        /// <summary>
        /// Añade un rubro a la lista, devuelve un string confirmando la acción.
        /// </summary>
        /// <param name="rubro">Recibe un parametro de tipo string con el nombre de "rubro".</param>
        public void AddRubro(string rubro)
        {
            if (!(RubrosList.Contains(rubro)))
            {
                RubrosList.Add(rubro);
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
            RubrosList.Remove(rubro);
            Console.WriteLine($"Rubro '{rubro}' eliminado exitosamente.");
        }

        /// <summary>
        /// Obtiene lista de rubros.
        /// </summary>
        public void GetRubrosList()
        {
            StringBuilder getRubrosList = new StringBuilder("Habilitaciones: \n");
            foreach (string rubro in RubrosList)
            {
                getRubrosList.Append($"- {rubro}.");   
            }
            
            Console.WriteLine(getRubrosList.ToString());
        }
    }
} 