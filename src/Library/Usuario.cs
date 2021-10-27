using System;
using System.Collections.Generic;

namespace   ClassLibrary
{
    public class Usuario
    {
        private string nombre;
        private string ubicacion;
        private string rubro;
        public Usuario(string nombre, string ubicacion, Rubro rubro)
        {
            this.Nombre = nombre;
            this.Ubicacion = ubicacion;
            this.Rubro = rubro;
        }
        public string Nombre {get; set;}
        public string Ubicacion {get; set;}
        
        public Rubro Rubro {get; set;}
    }
}