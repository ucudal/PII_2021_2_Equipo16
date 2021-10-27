using System;
using System.Collections.Generic;
using System.Text;


namespace ClassLibrary
{
    public class Emprendedor : Usuario, IHabilitaciones
    {
        public List<Habilitaciones> Habilitaciones = new List<Habilitaciones>();
        private string especializaciones;
        public Emprendedor(string nombre, string ubicacion, Rubro rubro, string especializaciones)
            :base(nombre, ubicacion, rubro)
        {
            
            this.Especializaciones = especializaciones;
        }
        
        public string Especializaciones {get; set;}
        private List<Producto> ofertasAceptadas = new List<Producto>();
        // Por Creator
        public void AddHabilitacion(string nombre, string certificador)
        {
            Habilitaciones habilitacion = new Habilitaciones(nombre, certificador);
            this.Habilitaciones.Add(habilitacion);
            Console.WriteLine($"Habilitación '{habilitacion.Nombre}' agregada exitosamente.");
        }
        // Por Creator
        public void RemoveHabilitacion(string nombre, string certificador)
        {
            Habilitaciones habilitacion = new Habilitaciones(nombre, certificador);
            this.Habilitaciones.Remove(habilitacion);
            Console.WriteLine( $"Habilitación '{habilitacion.Nombre}' eliminada exitosamente.");
        }
        public void GetHabilitacionList()
        {
            StringBuilder getHabilitaciones = new StringBuilder("Habilitaciones: \n");
            foreach (Habilitaciones habilitacion in Habilitaciones)
            {
                getHabilitaciones.Append($"- {habilitacion.Nombre} fue habilitado por {habilitacion.Certificador}.");   
            }
            Console.WriteLine(getHabilitaciones.ToString());
        }
        public Producto BuscarOfertaPorTag()
        {
            return modificar; 
        }

        public Producto BuscarOfertaPorZona()
        {
             return modificar;
        }

        public Producto BuscarOfertaPorCategorias()
        {
             return modificar;
        }
        
        public int CalcularMaterialesConsumidosSegunTiempo()
        {
            return 0; //modificar
        }

        

    }
}
