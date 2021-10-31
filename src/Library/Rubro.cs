using System;
using System.Collections.Generic;
using System.Text;


namespace ClassLibrary
{
    public class Rubro 
    {
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
                respuesta = LimpiadorCadena.LimpiaCadena(respuesta);
                if (respuesta == "si")
                {
                    RubrosList.Add(nombre);
                    this.Nombre = nombre;
                }
            }
        }
        public string Nombre{get; set;}
        public List<string> RubrosList = new List<string>()
                {"textil", "construccion", "comercio", "servicio", "forestal", "comunicaciones", "entretenimiento", "deportes", "industria"};
        public void AddRubro(string rubro)
        {
            RubrosList.Add(rubro);
            Console.WriteLine($"Rubro '{rubro}' agregado exitosamente.");
        }
        public void RemoveRubro(string rubro)
        {
            RubrosList.Remove(rubro);
            Console.WriteLine( $"Rubro '{rubro}' eliminado exitosamente.");
        }
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