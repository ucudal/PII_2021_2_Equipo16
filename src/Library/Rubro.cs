using System;
using System.Collections.Generic;
using System.Text;


namespace ClassLibrary
{
    public class Rubro 
    {
        public List<string> RubrosList = new List<string>();
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