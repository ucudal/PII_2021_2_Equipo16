using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un Emprendedor, que se encarga de buscar ofertas, y de manifestar su interés en las que sean de su agrado.
    /// Esta clase que contiene habilitaciones requiere, que se implemente la interfaz IHabilitaciones.
    /// La implementación de la interfaz es necesaria para unificar el nombre de su método con otras clases que tiene similares caracteristicas.
    /// </summary>
    /// <remarks>
    /// Para esta clase se utilizó el patron de diseño de Expert, ya que desde nuestro punto de vista,
    /// la clase Emprendedor tiene metodos que sean exclusivos de su clase ya que es la que se encarga de conocer
    /// todo lo necesario para hacer posible la ejecución de sus métodos, y que no sean necesarios para el resto de clases.
    /// Además, utilizamos herencia para lograr una reutilización de código aceptable, ya que sería muy tedioso y
    /// mala práctica reutilizar el código sin esta función que nos permite el lenguaje.
    /// </remarks>
    public class Emprendedor : Usuario, IHabilitaciones, IJsonConvertible
    {
        /// <summary>
        /// Este diccionario contiene las ofertas compradas y la fecha correspondiente.
        /// </summary>
        [JsonInclude]
        public Dictionary<DateTime, Oferta> FechaDeOfertasCompradas { get; set; } = new Dictionary<DateTime, Oferta>();

        /// <summary>
        /// Ofertas en las que se interesa el emprendedor.
        /// </summary>
        [JsonInclude]
        public List<Oferta> OfertasInteresado { get; set; } = new List<Oferta>();

        /// <summary>
        /// Lista de habilitaciones del emprendedor.
        /// </summary>
        [JsonInclude]
        public List<Habilitaciones> HabilitacionesEmprendedor { get; set; } = new List<Habilitaciones>();

        /// <summary>
        /// Constructor sin parametros de la clase Emprendedor, ya que es esencial el atributo JsonConstructor
        /// para la serialización de datos en la clase.
        /// </summary>
        [JsonConstructor]
        public Emprendedor()
            : base()
        {
        }

        /// <summary>
        /// Inicializa una instancia de la clase Emprendedor.
        /// </summary>
        /// <param name="nombre">Nombre del emprededor.</param>
        /// <param name="ubicacion">Ubicación del emprendedor.</param>
        /// <param name="rubro">Rubro del emprendedor.</param>
        /// <param name="especializaciones">Especializaciones del emprendedor.</param>
        /// <param name="email">Email del emprendedor, para contacatrlo.</param>
        public Emprendedor(string nombre, string ubicacion, string rubro, string especializaciones, string email)
            : base(nombre, ubicacion, rubro)
        {
            this.Especializaciones = especializaciones;
            this.Email = email;
        }

        /// <summary>
        /// Obtiene o establece las Especializaciones del emprendedor.
        /// </summary>
        public string Especializaciones { get; set; }

        /// <summary>
        /// Email del emprendedor.
        /// </summary>
        /// <value></value>
        public string Email{get; set;}

        /// <summary>
        /// Agrega habilitaciones.
        /// </summary>
        /// <param name="habilitacionBuscada">Nombre de la habilitación a agregar.</param>
        public void AddHabilitacion(string habilitacionBuscada)
        {
            if (Singleton<ContenedorRubroHabilitaciones>.Instancia.ChequearHabilitacion(habilitacionBuscada))
            {
                this.HabilitacionesEmprendedor.Add(Singleton<ContenedorRubroHabilitaciones>.Instancia.GetHabilitacion(habilitacionBuscada));
            }
            else
            {
                throw new ArgumentException($"{habilitacionBuscada} no se encuentra disponible, use nuevamente /agregarhabilitacionemprendedor");
            }
        }

        /// <summary>
        /// Quita habilitaciones.
        /// </summary>
        /// <param name="habilitacion">Nombre de la habilitaciones a remover.</param>
        public void RemoveHabilitacion(string habilitacion)
        {
            Habilitaciones habEliminada = new Habilitaciones(null);
            foreach (Habilitaciones hab in this.HabilitacionesEmprendedor)
            {
                if (habilitacion == hab.Nombre)
                {
                    habEliminada = hab;
                }
            }

            this.HabilitacionesEmprendedor.Remove(habEliminada);
        }

        /// <summary>
        /// Calcula cuantas ofertas se han comprado desde diferentes fechas, y cuanto dinero se gastó en ellas.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio.</param>
        /// <param name="fechaFinal">Fecha de final.</param>
        /// <returns>Retorna las ofertas compradas dentro del período de tiempo especificado.</returns>
        public int CalcularOfertasConsumidas(string fechaInicio, string fechaFinal)
        {
            int ofertasCompradas = 0;
            DateTime fInicio;

            if (!DateTime.TryParseExact(fechaInicio, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out fInicio))
            {
                throw new ArgumentException("Error al introducir la fecha de inicio, por favor ingrese la fecha con este formato: YYYY-MM-DD");
            }

            DateTime fFinal;
            if (!DateTime.TryParseExact(fechaFinal, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out fFinal))
            {
                throw new ArgumentException("Error al introducir la fecha final, por favor ingrese la fecha con este formato: YYYY-MM-DD");
            }

            foreach (KeyValuePair<DateTime,Oferta> par in this.FechaDeOfertasCompradas)
            {
                if (par.Key >= fInicio && par.Key <= fFinal)
                {
                    ofertasCompradas++;
                }
            }

            string texto = $"Se han comprado {ofertasCompradas} ofertas en el tiempo indicado";
            ConsolePrinter.DatoPrinter(texto);
            return ofertasCompradas;
        }

        /// <summary>
        /// Agregado por SRP y Expert, la responsabilidad de construir el texto, le corresponde a la clase emprendedor.
        /// </summary>
        /// <returns>Retorna un string con los datos del Emprendedor.</returns>
        public string TextoEmprendedor()
        {
            StringBuilder text = new StringBuilder();
            text.Append($"******************************\n");
            text.Append($"Nombre: {this.Nombre} \n");
            text.Append($"Ubicación: {this.Ubicacion.NombreCalle} \n");
            text.Append($"Rubro: {this.Rubro.Nombre} \n");
            text.Append($"Especializaciones: {this.Especializaciones} \n");
            text.Append($"Email: {this.Email} \n");
            text.Append($"Habilitaciones: \n");
            foreach (Habilitaciones habilitaciones in HabilitacionesEmprendedor)
            {
                text.Append($"{habilitaciones.Nombre}, ");
            }

            text.Append($"\n");
            text.Append($"******************************\n");
            return text.ToString();
        }

        /// <summary>
        /// Metodo que utiliza gracias a la interfaz IJsonConvertible para convertir a formato Json y aplicar en persistencia.
        /// </summary>
        /// <returns>Retorna el objeto serializado.</returns>
        public string ConvertirJson()
        {
            JsonSerializerOptions opciones = new ()
            {
                WriteIndented = true,
                ReferenceHandler = MyReferenceHandler.Instance,
            };

            return JsonSerializer.Serialize(this, opciones);
        }
    }
}
