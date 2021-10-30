
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Habilitaciones : IHabilitaciones
    {

        public ArrayList listaHabilitaciones = new ArrayList()
                    {
                    "ISO 9009", "APA", "SOA", "UNIT", "IEEE"
                    };

        public Habilitaciones(string nombre)
        {
            this.Nombre = nombre;
        }

        public string Nombre { get; private set; }
        public void HabilitacionesDisponibles()
        {
            StringBuilder habDisponibles = new StringBuilder();
            foreach (string habilitacion in this.listaHabilitaciones)
            {
                habDisponibles.Append($"- {habilitacion}.");
            }
            Console.WriteLine(habDisponibles.ToString());
        }

        void IHabilitaciones.AddHabilitacion(string nombre)
        {
            this.listaHabilitaciones.Add(nombre);
        }

        void IHabilitaciones.GetHabilitacionList()
        {
            throw new NotImplementedException();
        }

        void IHabilitaciones.RemoveHabilitacion(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}