using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;


namespace ClassLibrary
{
    
    public class Oferta : IHabilitaciones
    {
        private List<Habilitaciones> habilitaciones = new List<Habilitaciones>();
        public Oferta(string nombre, string material, int precio, string unidad, string tags, string ubicacion)
        {
            this.Nombre = nombre;
            this.Material = material;
            this.PrecioUnitario = precio;
            this.Unidad = unidad;
            this.Tags = tags;
            this.Ubicacion = ubicacion;
        }
        public string Nombre {get; set;}
        public string Material {get; set;}
        public int PrecioUnitario {get; set;}
        public int PrecioTotal;
        public string Unidad {get; set;}
        
        public string Tags {get; set;}

        public void AddHabilitacion(string nombre, string certificador)
        {
            Habilitaciones habilitacion = new Habilitaciones(nombre, certificador);
            this.habilitaciones.Add(habilitacion);
            Console.WriteLine($"Habilitación '{habilitacion.Nombre}' agregada exitosamente.");
        }
        public void RemoveHabilitacion(string nombre, string certificador)
        {
            Habilitaciones habilitacion = new Habilitaciones(nombre, certificador);
            this.habilitaciones.Remove(habilitacion);
            Console.WriteLine( $"Habilitación '{habilitacion.Nombre}' eliminada exitosamente.");
        }
        
        public void GetHabilitacionList()
        {
            StringBuilder getHabilitaciones = new StringBuilder("Habilitaciones: \n");
            foreach (Habilitaciones habilitacion in habilitaciones)
            {
                getHabilitaciones.Append($"- {habilitacion.Nombre} fue habilitado por {habilitacion.Certificador}.");   
            }
            Console.WriteLine(getHabilitaciones.ToString());
        }
        public DateTime FechaDePublicacion 
        {
            get
            {
                return DateTime.Now;
            } 
        }
        public string Ubicacion {get; set;}

        public string GenerarIdOferta()
        {
            return ""; //modificar
        }
        
    }
    
}