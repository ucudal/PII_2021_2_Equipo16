using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa una oferta
    /// </summary>
    public class Oferta : IHabilitaciones
    {
        private List<Habilitaciones> habilitaciones = new List<Habilitaciones>();

        /// <summary>
        /// Inicializa una instancia de Oferta
        /// </summary>
        /// <param name="nombre">Nombre de la oferta</param>
        /// <param name="material">Material del producto que se oferta</param>
        /// <param name="precio">Precio de la oferta</param>
        /// <param name="unidad">Cuantas unidades se ofertan</param>
        /// <param name="tags">Tags de la oferta</param>
        /// <param name="ubicacion">Ubicacion de la oferta</param>
        public Oferta(string nombre, string material, int precio, string unidad, string tags, string ubicacion)
        {
            
            this.Nombre = nombre;
            this.Material = material;
            this.PrecioUnitario = precio;
            this.Unidad = unidad;
            this.Tags = tags;
            this.Ubicacion = ubicacion;
            this.Id = Guid.NewGuid();

        }
        /// <summary>
        /// Nombre de la oferta
        /// </summary>
        /// <value></value>
        public string Nombre {get; set;}
        /// <summary>
        /// Material del producto a ofertar
        /// </summary>
        /// <value></value>
        public string Material {get; set;}
        /// <summary>
        /// Precio de cada unidad de la oferta
        /// </summary>
        /// <value></value>
        public int PrecioUnitario {get; set;}
        /// <summary>
        /// Precio total de la oferta
        /// </summary>
        public int PrecioTotal;
        /// <summary>
        /// Cantidad de unidades a ofertar
        /// </summary>
        /// <value></value>
        public int Unidad {get; set;}
        /// <summary>
        /// Tags de la oferta
        /// </summary>
        /// <value></value>
        public string Tags {get; set;}
        
        /// <summary>
        ///ID única para cada oferta
        /// </summary>
        /// <returns></returns>
        public Guid Id {get; private set;}

        /// <summary>
        /// Añade una habilitación a la oferta
        /// </summary>
        /// <param name="nombre">Nombre de la habilitación a agregar</param>
        public void AddHabilitacion(string nombre)
        {
            Habilitaciones habilitacion = new Habilitaciones(nombre);
            this.habilitaciones.Add(habilitacion);
            Console.WriteLine($"Habilitación '{habilitacion.Nombre}' agregada exitosamente.");
        }
        /// <summary>
        /// Quita una habilitación a la oferta
        /// </summary>
        /// <param name="nombre">Habilitacion a quitar</param>
        public void RemoveHabilitacion(string nombre)
        {
            Habilitaciones habilitacion = new Habilitaciones(nombre);
            this.habilitaciones.Remove(habilitacion);
            Console.WriteLine( $"Habilitación '{habilitacion.Nombre}' eliminada exitosamente.");
        }
        /// <summary>
        /// Muestra todas las habilitaciones posibles para agregar
        /// </summary>
        public void GetHabilitacionList()
        {
            StringBuilder getHabilitaciones = new StringBuilder("Habilitaciones: \n");
            foreach (Habilitaciones habilitacion in habilitaciones)
            {
                getHabilitaciones.Append($"- {habilitacion.Nombre}.");   
            }
            Console.WriteLine(getHabilitaciones.ToString());
        }
        /// <summary>
        /// Fecha en la que se publicó la oferta
        /// </summary>
        /// <value></value>
        public DateTime FechaDePublicacion 
        {
            get
            {
                return DateTime.Now;
            }
        }
        /// <summary>
        /// Ubicación de la oferta
        /// </summary>
        /// <value></value>
        public string Ubicacion {get; set;}
        
    }
    
   
}