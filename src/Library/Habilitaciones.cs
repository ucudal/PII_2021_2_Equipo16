
using System;

namespace ClassLibrary
{
    public class Habilitaciones
    {
        public Habilitaciones(string nombre, string certificador)
        {
            this.Nombre = nombre;
            this.Certificador = certificador;
        }

        public string Nombre { get; private set; }
        public string Certificador { get; private set; }
    }
}