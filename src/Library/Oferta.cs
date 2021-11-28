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
        public List<Habilitaciones> HabilitacionesOferta { get; } = new List<Habilitaciones>();

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
        public Oferta(string nombre, string nombreMaterial, string cantidad, string precio, string unidad, string tags, string ubicacion, string constantesPuntuales, Empresa empresa)
        {
            this.Nombre = nombre;
            this.Material = new Material(nombreMaterial, cantidad, precio, unidad);
            this.Tags = tags;
            this.Ubicacion = new Ubicacion(ubicacion);
            this.EmpresaCreadora = empresa;
            this.ConstantesPuntuales = constantesPuntuales;
        }

        /// <summary>
        /// Nombre del interesado en la oferta.
        /// </summary>
        public List<string> Interesado { get; } = new List<string>();

        /// <summary>
        /// Obtiene o establece el nombre de la oferta.
        /// </summary>
        public string Nombre { get; private set; }

        /// <summary>
        /// Obtiene o establece el Material del producto a ofertar.
        /// </summary>
        public Material Material { get; private set; }

        /// <summary>
        /// Obtiene o establece los Tags de la Oferta.
        /// </summary>
        public string Tags { get; private set; }

        /// <summary>
        /// Obtiene o establece la Ubicación de la oferta.
        /// </summary>
        public Ubicacion Ubicacion { get; private set; }


        /// <summary>
        /// Obtiene o establece la Empresa que publica la Oferta.
        /// </summary>
        public Empresa EmpresaCreadora { get; private set; }

        /// <summary>
        /// Obtiene o establece un valor que indica si la Oferta es constante o puntual.
        /// </summary>
        public string ConstantesPuntuales { get; private set;}


        /// <summary>
        /// Añade una habilitación a la oferta.
        /// </summary>
        /// <param name="habilitacionBuscada">Nombre de la habilitación a agregar.</param>
        public void AddHabilitacion(string habilitacionBuscada)
        {
            if (Singleton<ContenedorRubroHabilitaciones>.Instancia.ChequearHabilitacion(habilitacionBuscada))
            {
                this.HabilitacionesOferta.Add(Singleton<ContenedorRubroHabilitaciones>.Instancia.GetHabilitacion(habilitacionBuscada));
            }
            else
            {
                throw new ArgumentException($"{habilitacionBuscada} no se encuentra disponible, use nuevamente /crearhaboferta");
            }
        }

        /// <summary>
        /// Quita una habilitación a la oferta.
        /// </summary>
        /// <param name="habilitacion">Habilitacion a quitar.</param>
        public void RemoveHabilitacion(string habilitacion)
        {
            Habilitaciones habEliminada = new Habilitaciones(null);
            foreach (Habilitaciones hab in this.HabilitacionesOferta)
            {
                if (habilitacion == hab.Nombre)
                {
                    habEliminada = hab;
                }
            }
            this.HabilitacionesOferta.Remove(habEliminada);
        }


        /// <summary>
        /// Obtiene la Fecha en la que se publicó la oferta.
        /// </summary>
        public DateTime FechaDePublicacion
        {
            get
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// Agregado por SRP y Expert, la responsabilidad de construir el texto, le corresponde a la clase oferta.
        /// ya que conoce lo necesario.
        /// </summary>
        /// <returns></returns>
        public string TextoOferta()
        {
            StringBuilder text = new StringBuilder();
            text.Append($"******************************\n");
            text.Append($"Nombre: {this.Nombre} \n");
            text.Append($"Material: {this.Material.Nombre} \n");
            text.Append($"Precio: {this.Material.Precio} \n");
            text.Append($"Unidad: {this.Material.Unidad} \n");
            text.Append($"Tag: {this.Tags} \n");
            text.Append($"Ubicación: {this.Ubicacion.NombreCalle} \n");
            text.Append($"Es una oferta {this.ConstantesPuntuales} \n");
            text.Append($"Requerimientos: \n");
            text.Append($"******************************\n");
            foreach (Habilitaciones habilitaciones in HabilitacionesOferta)
            {
                text.Append($"{habilitaciones.Nombre}, ");
            }

            return text.ToString();
        }

        /// <summary>
        /// Agregado por SRP y Expert, la responsabilidad de construir el texto, le corresponde a la clase oferta.
        /// ya que conoce lo necesario.
        /// </summary>
        /// <returns></returns>

        public string TextoInteresados()
        {
            StringBuilder texto = new StringBuilder($"\nLos interesados en {this.Nombre} son: ");
            foreach (string interesado in Interesado)
            {
                texto.Append("\n" + interesado);
            }
            return texto.ToString();
        }
    }
}