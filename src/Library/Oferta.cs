using System;
using System.Text;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

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
       /// Constructor sin parametros de la clase Oferta, ya que es esencial el atributo JsonConstructor
       /// para la serialización de datos en la clase.
       /// </summary>
        [JsonConstructor]
        public Oferta()
        {

        }

        /// <summary>
        /// Constructor para json.
        /// </summary>
        [JsonInclude]
        public List<Habilitaciones> HabilitacionesOferta { get; set; } = new List<Habilitaciones>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        /// <param name="nombre">Recibe por parametro el nombre de la oferta.</param>
        /// <param name="nombreMaterial">Recibe por parametro el nombre del material de la oferta.</param>
        /// <param name="cantidad">Recibe por parametro la cantidad de la oferta.</param>
        /// <param name="precio">Recibe por parametro el precio de la oferta.</param>
        /// <param name="unidad">Recibe por parametro la unidad de la oferta.</param>
        /// <param name="tags">Recibe por parametro el tags de la oferta.</param>
        /// <param name="ubicacion">Recibe por parametro la ubicacion de la oferta.</param>
        /// <param name="constantesPuntuales">Recibe por parametro que indica si es contante de la oferta.</param>
        /// <param name="empresa">Recibe por parametro la empresa que creo la oferta.</param>
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
        [JsonInclude]
        public List<string> Interesado { get; set; } = new List<string>();

        /// <summary>
        /// Obtiene o establece el nombre de la oferta.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el Material del producto a ofertar.
        /// </summary>
        [JsonInclude]
        public Material Material { get; set; }

        /// <summary>
        /// Obtiene o establece los Tags de la Oferta.
        /// </summary>
        public string Tags { get; set; }

        /// <summary>
        /// Obtiene o establece la Ubicación de la oferta.
        /// </summary>
        public Ubicacion Ubicacion { get; set; }
        
        /// <summary>
        /// Obtiene o establece la empresa creadora de la oferta.
        /// </summary>
        public Empresa EmpresaCreadora {get; set;}
       

        /// <summary>
        /// Obtiene o establece un valor que indica si la Oferta es constante o puntual.
        /// </summary>
        public string ConstantesPuntuales { get; set;}

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
        /// <returns>Retorna un string con la información de la Oferta.</returns>
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
        /// <returns>Retorna un string listando los interesados en la oferta.</returns>
        public string TextoInteresados()
        {
            StringBuilder texto = new StringBuilder($"\nLos interesados en {this.Nombre} son: ");
            foreach (string interesado in Interesado)
            {
                texto.Append("\n" + interesado);
            }
            return texto.ToString();
        }
        
        /// <summary>
        /// Metodo que utiliza gracias a la interfaz IJsonConvertible para convertir a formato Json y aplicar en persistencia. 
        /// </summary>
        /// <returns>Retorna la Serializacion.</returns>
        public string ConvertirJson()
        {
            JsonSerializerOptions opciones = new()
            {
                WriteIndented = true,
                ReferenceHandler = MyReferenceHandler.Instance,
            };

            return JsonSerializer.Serialize(this, opciones);
        }
    }
}