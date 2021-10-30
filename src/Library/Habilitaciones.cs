
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Habilitaciones : IHabilitaciones
    {


        public ArrayList ListaHabilitaciones = new ArrayList()

                    {
                    "iso 9009", "apa", "soa", "unit", "ieee"
                    };

        public Habilitaciones(string nombre)
        {
            this.Nombre = nombre;
        }

        public string Nombre { get; private set; }
        public void HabilitacionesDisponibles()
        {
            StringBuilder habDisponibles = new StringBuilder();
            foreach (string habilitacion in this.ListaHabilitaciones)
            {
                habDisponibles.Append($"- {habilitacion}.");
            }
            Console.WriteLine(habDisponibles.ToString());
        }

        void IHabilitaciones.AddHabilitacion(string nombre)
        {
            this.ListaHabilitaciones.Add(nombre);
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