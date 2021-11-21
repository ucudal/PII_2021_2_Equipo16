using System;
using System.Text;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa una oferta.
    /// Esta clase que contiene habilitaciones requiere, que se implemente la interfaz IHabilitaciones.
    /// La implementación de la interfaz es necesaria para unificar el nombre de su método con otras clases que tiene similares caracteristicas.
    /// </summary>
    public class Oferta : IHabilitaciones
    {
        /// <summary>
        /// Esta lista contiene las habilitaciones de las Ofertas.
        /// </summary>
        public List<string> HabilitacionesOferta = new List<string>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Oferta"/>.
        /// </summary>
        /// <param name="nombre">Nombre de la oferta.</param>
        /// <param name="material">Material del producto que se oferta.</param>
        /// <param name="precio">Precio de la oferta.</param>
        /// <param name="unidad">Unidad ed la oferta.</param>
        /// <param name="tags">Tags de la oferta.</param>
        /// <param name="ubicacion">Ubicacion de la oferta.</param>
        /// <param name="empresa">Empresa que publica la oferta.</param>
        /// <param name="constantesPuntuales">Si la oferta es constante o puntual.</param>
        public Oferta(string nombre, string material, string precio, string unidad, string tags, string ubicacion, string constantesPuntuales, Empresa empresa)
        {
            this.Nombre = nombre;
            this.Material = material;
            this.Precio = precio;
            this.Unidad = unidad;
            this.Tags = tags;
            this.Ubicacion = ubicacion;
            this.Id = Guid.NewGuid();
            this.EmpresaCreadora = empresa;
            this.ConstantesPuntuales = constantesPuntuales;
        }

        /// <summary>
        /// Nombre del interesado en la oferta.
        /// </summary>
        public List<string> Interesado = new List<string>();

        private Habilitaciones habilitacion = new Habilitaciones();

        /// <summary>
        /// Obtiene o establece el nombre de la oferta.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el Material del producto a ofertar.
        /// </summary>
        public string Material { get; set; }

        /// <summary>
        /// Obtiene o establece el Precio de la Oferta.
        /// </summary>
        public string Precio { get; set; }

        /// <summary>
        /// Obtiene o establece la Cantidad de unidades a ofertar.
        /// </summary>
        public string Unidad { get; set; }

        /// <summary>
        /// Obtiene o establece los Tags de la Oferta.
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Obtiene la ID única para cada Oferta.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Obtiene o establece la Empresa que publica la Oferta.
        /// </summary>
        public Empresa EmpresaCreadora { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica si la Oferta es constante o puntual.
        /// </summary>
        public string ConstantesPuntuales { get; set; }

        /// <summary>
        /// Obtiene una lista de Habilitaciones de la Oferta.
        /// </summary>
        /// <value>habilitacionesOferta.</value>
        public List<string> HabilitacionesDeOferta { get => this.HabilitacionesOferta; }

        /// <summary>
        /// Añade una habilitación a la oferta.
        /// </summary>
        /// <param name="habilitacionBuscada">Nombre de la habilitación a agregar.</param>
        public void AddHabilitacion(string habilitacionBuscada)
        {
            if (this.habilitacion.ListaHabilitaciones.Contains(habilitacionBuscada))
            {
                this.HabilitacionesOferta.Add(habilitacionBuscada);
            }
        }

        /// <summary>
        /// Quita una habilitación a la oferta.
        /// </summary>
        /// <param name="habilitacion">Habilitacion a quitar.</param>
        public void RemoveHabilitacion(string habilitacion)
        {
            this.HabilitacionesOferta.Remove(habilitacion);
        }

        /// <summary>
        /// Muestra todas las habilitaciones posibles para agregar.
        /// </summary>
        public string GetHabilitacionList()
        {
           return this.habilitacion.HabilitacionesDisponibles();
        }

        /// <summary>
        /// Obtiene la Fecha en la que se publicó la oferta.
        /// </summary>
        public static DateTime FechaDePublicacion
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

        public string TextoOferta()
        {
            StringBuilder text = new StringBuilder("********************");
            text.Append($"Nombre: {this.Nombre} \n");
            text.Append($"Material: {this.Material} \n");
            text.Append($"Precio: {this.Precio} \n");
            text.Append($"Unidad: {this.Unidad} \n");
            text.Append($"Tag: {this.Tags} \n");
            text.Append($"Ubicación: {this.Ubicacion} \n");
            text.Append($"Es una oferta {this.Nombre} \n");
            text.Append($"Requerimientos: ");
            foreach (string habilitaciones in HabilitacionesDeOferta)
            {
                text.Append(habilitaciones);
            }

            return text.ToString();

        }
    }
}