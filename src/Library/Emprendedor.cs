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
    public class Emprendedor : Usuario, IHabilitaciones, IJsonConvertible
    {
        /// <summary>
        /// Este diccionario contiene las ofertas compradas y la fecha correspondiente.
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public Dictionary<DateTime, Oferta> FechaDeOfertasCompradas {get; set;} = new Dictionary<DateTime, Oferta>();

        /// <summary>
        /// Ofertas en las que se interesa el emprendedor.
        /// </summary>
        [JsonInclude]
        public List<Oferta> OfertasInteresado {get; set;} = new List<Oferta>();

        /// <summary>
        /// Lista de habilitaciones del emprendedor.
        /// </summary>
        [JsonInclude]
        public List<Habilitaciones> HabilitacionesEmprendedor {get; set;} = new List<Habilitaciones>();

        //private List<Oferta> ofertasCompradas = new List<Oferta>();

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Emprendedor"/>.
        /// Como la clase hereda de la clase Usuario, recibe por parametros los propios de Usuario y los particulares de Emprendedor.
        /// </summary>
        /// <param name="nombre">Nombre del emprededor.</param>
        /// <param name="ubicacion">Ubicación del emprendedor.</param>
        /// <param name="rubro">Rubro del emprendedor.</param>
        /// <param name="especializaciones">Especializaciones del emprendedor.</param>
        [JsonConstructor]
        public Emprendedor() : base()
        {

        }
        
        public Emprendedor(string nombre, string ubicacion, string rubro, string especializaciones) : base(nombre, ubicacion, rubro)
        {
            this.Especializaciones = especializaciones;
        }

        /// <summary>
        /// Obtiene o establece las Especializaciones del emprendedor.
        /// </summary>
        public string Especializaciones { get; set;}

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
            foreach (Habilitaciones hab in HabilitacionesEmprendedor)
            {
                if (habilitacion == hab.Nombre)
                {
                    habEliminada = hab;
                }
            }
            this.HabilitacionesEmprendedor.Remove(habEliminada);
        }

        /// <summary>
        /// Muestra todas las habilitaciones posibles para agregar.
        /// </summary>

        /// <summary>
        /// Calcula cuantas ofertas se han comprado desde diferentes fechas, y cuanto dinero se gastó en ellas.
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio.</param>
        /// <param name="fechaFinal">Fecha de final.</param>
        /// <returns>Retorna las ofertas compradas dentro del período de tiempo especificado.</returns>
        public int CalcularOfertasCompradas(string fechaInicio, string fechaFinal)
        {
            int ofertasCompradas = 0;
            DateTime fInicio;

            if (!DateTime.TryParseExact(fechaInicio, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out fInicio))
            {
                throw new ArgumentException("Error al introducir la fecha de inicio, por favor ingrese la fecha con este formato: yyyy-MM-dd");
            }
            
            DateTime fFinal;

            if (!DateTime.TryParseExact(fechaFinal, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out fFinal))
            {
                throw new ArgumentException("Error al introducir la fecha final, por favor ingrese la fecha con este formato: yyyy-MM-dd");
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
        /// <returns></returns>
        public string TextoEmprendedor()
        {
            StringBuilder text = new StringBuilder();
            text.Append($"******************************\n");
            text.Append($"Nombre: {this.Nombre} \n");
            text.Append($"Ubicación: {this.Ubicacion.NombreCalle} \n");
            text.Append($"Rubro: {this.Rubro.Nombre} \n");
            text.Append($"Especializaciones: {this.Especializaciones} \n");
            text.Append($"Requerimientos: \n");
            text.Append($"******************************\n");
            foreach (Habilitaciones habilitaciones in HabilitacionesEmprendedor)
            {
                text.Append($"{habilitaciones.Nombre}, ");
            }

            return text.ToString();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
