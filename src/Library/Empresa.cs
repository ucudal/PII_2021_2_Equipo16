using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa una Empresa, que se encarga de crear Ofertas, eliminarlas, aceptarlas y calcular el consumo de ofertas.
    /// Esta clase que contiene habilitaciones requiere, que se implemente la interfaz IHabilitaciones.
    /// La implementación de la interfaz es necesaria para unificar el nombre de su método con otras clases que tiene similares caracteristicas.
    /// </summary>
    /// <remarks>
    /// Para esta clase se utilizó el patron de diseño de Expert, ya que desde nuestro punto de vista,
    /// la clase Empresa tiene metodos que sean exclusivos de su clase ya que es la que se encarga de conocer 
    /// todo lo necesario para hacer posible la ejecución de sus métodos, y que no sean necesarios para el resto de clases.
    /// Además, utilizamos herencia para lograr una refactorización de código aceptable, ya que sería muy tedioso y
    /// mala práctica reutilizar el código sin esta función que nos permite el lenguaje.
    /// </remarks>

    public class Empresa : Usuario, IHabilitaciones, IJsonConvertible
    {
       /// <summary>
       /// Constructor sin parametros de la clase Empresa, ya que es esencial el atributo JsonConstructor
       /// para la serialización de datos en la clase.
       /// </summary>
       /// <returns></returns>
        [JsonConstructor]
        public Empresa() : base()        
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre">Nombre de la empresa.</param>
        /// <param name="ubicacion">Ubicación de la empresa.</param>
        /// <param name="rubro">Rubro de la empresa.</param>
        public Empresa(string nombre, string ubicacion, string rubro) : base(nombre, ubicacion, rubro)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public Dictionary<DateTime, Oferta> FechaOfertasEntregadas {get; private set;} = new Dictionary<DateTime, Oferta>();
        //private List<Habilitaciones> habilitacionesEmpresa = new List<Habilitaciones>();
        //private List<Oferta> ofertasAceptadas = new List<Oferta>();
        //private List<Oferta> interesadosEnOfertas = new List<Oferta>();
        //private List<Oferta> misOfertas = new List<Oferta>();

        /// <summary>
        /// Obtiene las Habilitaciones que tiene la Empresa.
        /// </summary>
        [JsonInclude]
        public List<Habilitaciones> HabilitacionesEmpresa { get; private set; } = new List<Habilitaciones>();

        /// <summary>
        /// Obtiene o establece los interesados en Ofertas que tiene la Empresa.
        /// </summary>
        [JsonInclude]
        public List<Oferta> InteresadosEnOfertas { get; private set; } = new List<Oferta>();

        /// <summary>
        /// Obtiene o establece Ofertas de la lista de OfertasAceptadas.
        /// </summary>
        [JsonInclude]
        public List<Oferta> OfertasAceptadas { get; private set; } = new List<Oferta>();

        /// <summary>
        /// 
        /// </summary>
        [JsonInclude]
        public List<Oferta> MisOfertas { get; private set;} = new List<Oferta>();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="publicaciones"></param>
        /// <param name="nombre"></param>
        /// <param name="nombreMaterial"></param>
        /// <param name="cantidad"></param>
        /// <param name="precio"></param>
        /// <param name="unidad"></param>
        /// <param name="tags"></param>
        /// <param name="ubicacion"></param>
        /// <param name="puntualesConstantes"></param>
        public void CrearOferta(Publicaciones publicaciones, string nombre, string nombreMaterial, string cantidad, string precio, string unidad, string tags, string ubicacion, string puntualesConstantes)
        {   
            Oferta productoCreado = new Oferta(nombre, nombreMaterial, cantidad, precio, unidad, tags, ubicacion, puntualesConstantes, this);
            publicaciones.OfertasPublicados.Add(productoCreado);
            this.MisOfertas.Add(productoCreado);
        }

        /// <summary>
        /// Elimina una oferta creada de las publicaciones.
        /// </summary>
        /// <param name="nombreOfertaParaEliminar">Oferta a eliminar.</param>
        /// <param name="publicaciones">Publicaciones.</param>
        public void EliminarOferta(string nombreOfertaParaEliminar, Publicaciones publicaciones)
        {
            Oferta ofertaParaEliminar = null;
            foreach (Oferta ofertaEnLista in publicaciones.OfertasPublicados)
            {
                if (ofertaEnLista.Nombre == nombreOfertaParaEliminar)
                {
                    ofertaParaEliminar = ofertaEnLista;   
                }
            }
            publicaciones.OfertasPublicados.Remove(ofertaParaEliminar);
            this.MisOfertas.Remove(ofertaParaEliminar);
        }

        /// <summary>
        /// Quita de las publicaciones, la oferta que fue aceptada, ser aceptada implica que se llegó a un acuerdo con un emprendedor y se quiere quitar la oferta de las publicaciones, además de agregarla a la lista de ofertasAceptadas que contiene la empresa, para realizar un control de cuantas se aceptan.
        /// </summary>
        /// <param name="nombreOfertaParaAceptar">Oferta que se quiere aceptar.</param>
        /// <param name="publicaciones">Publicaciones.</param>
        public void AceptarOferta(string nombreOfertaParaAceptar, Publicaciones publicaciones)
        {
            Oferta ofertaEncontrada = null;
            foreach (Oferta ofertaEnLista in publicaciones.OfertasPublicados)
            {
                if (ofertaEnLista.Nombre == nombreOfertaParaAceptar)
                {
                    ofertaEncontrada = ofertaEnLista;
                    this.OfertasAceptadas.Add(ofertaEnLista);
                    this.FechaOfertasEntregadas.Add(DateTime.Now, ofertaEnLista);
                }
            }

            publicaciones.OfertasPublicados.Remove(ofertaEncontrada);
        }

        /// <summary>
        /// Calcula cuantas ofertas se entregaron entre diferentes fechas.
        /// </summary>
        /// <param name="fechaInicio">Fecha inicio, se debe pasar fecha con formato AAAA-MM-DD.</param>
        /// <param name="fechaFinal">Fecha final, se debe pasar fecha con formato AAAA-MM-DD.</param>
        /// <returns>Retorna las ofertas vendidas dentro del período de tiempo especificado.</returns>
        public int CalcularOfertasVendidas(string fechaInicio, string fechaFinal)
        {
            int cantidadVendida = 0;
            DateTime fInicio;

            if (!DateTime.TryParseExact(fechaInicio, "YYYY-MM-DD", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out fInicio))
            {
                throw new ArgumentException("Error al introducir la fecha de inicio, por favor ingrese la fecha con este formato: YYYY-MM-DD");
            }
            
            DateTime fFinal;

            if (!DateTime.TryParseExact(fechaFinal, "YYYY-MM-DD", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out fFinal))
            {
                throw new ArgumentException("Error al introducir la fecha final, por favor ingrese la fecha con este formato: YYYY-MM-DD");
            }

            foreach (KeyValuePair<DateTime, Oferta> par in this.FechaOfertasEntregadas)
            {
                if (par.Key >= fInicio && par.Key <= fFinal)
                {
                   cantidadVendida += 1;
                }
            }

            string texto = $"Se vendieron {cantidadVendida} ofertas";
            ConsolePrinter.DatoPrinter(texto);
            return cantidadVendida;
        }

        // Habilitaciones que tengo yo a nivel de empresa.

        /// <summary>
        /// Agrega habilitaciones que pueda tener la empresa.
        /// </summary>
        /// <param name="habilitacionBuscada">Habilitación a buscar.</param>
        public void AddHabilitacion(string habilitacionBuscada)
        {
            if (Singleton<ContenedorRubroHabilitaciones>.Instancia.ChequearHabilitacion(habilitacionBuscada))
            {
                this.HabilitacionesEmpresa.Add(Singleton<ContenedorRubroHabilitaciones>.Instancia.GetHabilitacion(habilitacionBuscada));
            }
            else
            {
                throw new ArgumentException($"{habilitacionBuscada} no se encuentra disponible, use nuevamente /agregarhabilitacionempresa");
            }
        }

        /// <summary>
        /// Quita habilitaciones que tenga la Empresa.
        /// </summary>
        /// <param name="habilitacion">Habilitacion a eliminar.</param>
        public void RemoveHabilitacion(string habilitacion)
        {
            Habilitaciones habEliminada = new Habilitaciones(null);
            foreach (Habilitaciones hab in this.HabilitacionesEmpresa)
            {
                if (habilitacion == hab.Nombre)
                {
                    habEliminada = hab;
                }
            }
            this.HabilitacionesEmpresa.Remove(habEliminada);
        }

        /// <summary>
        /// Agregado por SRP y Expert, la responsabilidad de ver los interesados en una oferta le corresponde a la misma empresa.
        /// Este metodo muestra los interesados en una oferta.
        /// </summary>
        /// <returns></returns>
        public string VerInteresados()
        {
            StringBuilder texto = new StringBuilder("Interesados: ");
            if (this.InteresadosEnOfertas.Count > 0)
            {
                foreach (Oferta oferta in this.InteresadosEnOfertas)
                {

                    texto.Append(oferta.TextoInteresados());
                }
            }
            else
            {
                texto.Append("0 interesados");
            }
            return texto.ToString();
        }
        /// <summary>
        /// Agregado por SRP y Expert, la responsabilidad de construir el texto, le corresponde a la clase empresa.
        /// ya que conoce lo necesario.
        /// </summary>
        /// <returns></returns>
        public string TextoEmpresa()
        {
            StringBuilder text = new StringBuilder();
            text.Append($"******************************\n");
            text.Append($"Nombre: {this.Nombre} \n");
            text.Append($"Rubro: {this.Rubro.Nombre} \n");
            text.Append($"Ubicación: {this.Ubicacion.NombreCalle} \n");
            text.Append($"Habilitaciones: ");
            text.Append($"\n");
            foreach (Habilitaciones habilitaciones in this.HabilitacionesEmpresa)
            {
                text.Append($"{habilitaciones.Nombre}, ");
            }
            text.Append($"\n");
            text.Append($"******************************\n");
            return text.ToString();
        }
        /// <summary>
        /// Método que devuelve las ofertas publicadas por la empresa.
        /// </summary>
        /// <returns></returns>
        public List<Oferta> VerMisOfertas()
        {
            return MisOfertas;
        }

        /// <summary>
        /// Metodo que utiliza gracias a la interfaz IJsonConvertible para convertir a formato Json y aplicar en persistencia. 
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