using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa una oferta.
    /// </summary>
    public class Oferta : IHabilitaciones
    {
        private List<string> habilitacionesOferta = new List<string>();

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
        /// Booleano, false si no hay interesado en la oferta, true si lo hay.
        /// </summary>
        // Se hizo en equipo.
        public bool HayInteresado
        {
            get
            {
                if (true)
                {
                    EmpresaCreadora.InteresadosEnOfertas.Add(this);
                    return true;
                }
            }
            set
            {
            }    
        }
        
        /// <summary>
        /// Nombre del interesado en la oferta.
        /// </summary>
        public string interesado;
        
        private Habilitaciones habilitacion{get;set;}
        
        /// <summary>
        /// Nombre de la oferta.
        /// </summary>
        /// <value></value>
        public string Nombre {get; set;}
        
        /// <summary>
        /// Material del producto a ofertar.
        /// </summary>
        /// <value></value>
        public string Material {get; set;}
        
        /// <summary>
        /// Precio de la oferta.
        /// </summary>
        /// <value></value>
        public int Precio {get; set;}
        
        /// <summary>
        /// Cantidad de unidades a ofertar.
        /// </summary>
        /// <value></value>
        public string Unidad {get; set;}
        
        /// <summary>
        /// Tags de la oferta.
        /// </summary>
        /// <value></value>
        public string Tags {get; set;}
        
        /// <summary>
        ///ID única para cada oferta.
        /// </summary>
        /// <returns></returns>
        public Guid Id {get; private set;}

        /// <summary>
        /// Empresa que publica la oferta.
        /// </summary>
        /// <value></value>
        
        public Empresa EmpresaCreadora {get; set;}
        
        /// <summary>
        /// Obtiene una lista de las habilitaciones que requiere el producto.
        /// </summary>
        /// <value></value>
        public List<string> HabilitacionesOferta {get => habilitacionesOferta;}
        
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
        /// <value></value>
        public DateTime FechaDePublicacion 
        {
            get
            {
                return DateTime.Now; 
            }
        }
        
        /// <summary>
        /// Ubicación de la oferta.
        /// </summary>
        /// <value></value>
        
        public string Ubicacion {get; set;}
    }
}
