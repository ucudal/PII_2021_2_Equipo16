using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa una oferta.
    /// </summary>
    public class Oferta : IHabilitaciones
    {
        /// <summary>
        /// Esta lista contiene las habilitaciones de las Ofertas.
        /// </summary>
        public List<string> habilitacionesOferta = new List<string>();

        /// <summary>
        /// Inicializa una instancia de Oferta.
        /// </summary>
        /// <param name="nombre">Nombre de la oferta.</param>
        /// <param name="material">Material del producto que se oferta.</param>
        /// <param name="precio">Precio de la oferta.</param>
        /// <param name="unidad">Unidad ed la oferta.</param>
        /// <param name="tags">Tags de la oferta.</param>
        /// <param name="ubicacion">Ubicacion de la oferta.</param>
        /// <param name="empresa">Empresa que publica la oferta.</param>
        public Oferta(string nombre, string material, int precio, string unidad, string tags, string ubicacion, Empresa empresa)
        {
            this.Nombre = nombre;
            this.Material = material;
            this.Precio = precio;
            this.Unidad = unidad;
            this.Tags = tags;
            this.Ubicacion = ubicacion;
            this.Id = Guid.NewGuid();
            this.EmpresaCreadora = empresa;
        }

        /// <summary>
        /// Nombre del interesado en la oferta.
        /// </summary>
        public string Interesado { get; set; }
        
        /// <summary>
        /// Obtiene o establece el nombre de la oferta.
        /// </summary>
        public string Nombre { get; set; }
        
        /// <summary>
        /// Obtiene o establece el Material del producto a ofertar.
        /// </summary>
        public string Material { get; set; }
        
        /// <summary>
        /// Obtiene o establece el Precio de la oferta.
        /// </summary>
        public int Precio { get; set; }
        
        /// <summary>
        /// Obtiene o establece la Cantidad de unidades a ofertar.
        /// </summary>
        public string Unidad { get; set; }
        
        /// <summary>
        /// Obtiene o establece los Tags de la oferta.
        /// </summary>
        public string Tags { get; set; }
        
        /// <summary>
        /// Obtiene o establece la ID única para cada oferta.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Obtiene o establece la Empresa que publica la oferta.
        /// </summary>
        public Empresa EmpresaCreadora { get; set; }
        
        /// <summary>
        /// Obtiene una lista de las habilitaciones que requiere el producto.
        /// </summary>
        public List<string> HabilitacionesOferta { get => habilitacionesOferta;}

        private Habilitaciones habilitacion = new Habilitaciones();
        
        /// <summary>
        /// Añade una habilitación a la oferta.
        /// </summary>
        /// <param name="habilitacionBuscada">Nombre de la habilitación a agregar.</param>
        public void AddHabilitacion(string habilitacionBuscada)
        {
            if (habilitacion.ListaHabilitaciones.Contains(habilitacionBuscada))
            {
                habilitacionesOferta.Add(habilitacionBuscada);
            }
        }
        
        /// <summary>
        /// Quita una habilitación a la oferta.
        /// </summary>
        /// <param name="habilitacion">Habilitacion a quitar.</param>
        public void RemoveHabilitacion(string habilitacion)
        {
            habilitacionesOferta.Remove(habilitacion);
        }
        
        /// <summary>
        /// Muestra todas las habilitaciones posibles para agregar.
        /// </summary>
        public void GetHabilitacionList()
        {
            habilitacion.HabilitacionesDisponibles();
        }
        
        /// <summary>
        /// Fecha en la que se publicó la oferta.
        /// </summary>
        public DateTime FechaDePublicacion 
        {
            get
            {
                return DateTime.Now; 
            }
        }
        
        /// <summary>
        /// Obtiene o establece la Ubicación de la oferta.
        /// </summary>
        public string Ubicacion { get; set; }
    }
}