using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;

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

    public class Empresa : Usuario, IHabilitaciones
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Empresa"/>.
        /// Como la clase hereda de la clase Usuario, recibe por parametros los propios de Usuario y los particulares de Empresa.
        /// </summary>
        /// <param name="nombre">Nombre de la empresa.</param>
        /// <param name="ubicacion">Ubicación de la empresa.</param>
        /// <param name="rubro">Rubro de la empresa.</param>
        public Empresa(String nombre, String ubicacion, string rubro) : base(nombre, ubicacion, rubro)
        {
            this.Habilitacion = new Habilitaciones();
        }

        /// <summary>
        /// Acepta una invitación.
        /// </summary>
        /// <param name="nombreEmpresa">Nombre de la empresa.</param>
        public void AceptarInvitacion(string nombreEmpresa)
        {
            if (nombreEmpresa == this.Nombre)
            {
                ConsolePrinter.DatoPrinter("Invitación aceptada");
                
                // Cuando conozcamos mas sobre telegram, le agregamos el poder vincular el usuario que nos manda el mensaje con la empresa.
            }
            else
            {
                ConsolePrinter.DatoPrinter("Invitación inválida, intente otra vez");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<DateTime, Oferta> FechaOfertasEntregadas = new Dictionary<DateTime, Oferta>();
        private List<string> habilitacionesEmpresa = new List<string>();
        private List<Oferta> ofertasAceptadas = new List<Oferta>();
        private List<Oferta> interesadosEnOfertas = new List<Oferta>();
        private List<Oferta> misOfertas = new List<Oferta>();

        /// <summary>
        /// Habilitaciones de la empresa.
        /// </summary>
        public Habilitaciones Habilitacion = new Habilitaciones();

        /// <summary>
        /// Obtiene las Habilitaciones que tiene la Empresa.
        /// </summary>
        public List<string> HabilitacionesEmpresa { get => this.habilitacionesEmpresa; }

        /// <summary>
        /// Obtiene o establece los interesados en Ofertas que tiene la Empresa.
        /// </summary>
        public List<Oferta> InteresadosEnOfertas { get => this.interesadosEnOfertas; set => this.interesadosEnOfertas = value; }

        /// <summary>
        /// Obtiene o establece Ofertas de la lista de OfertasAceptadas.
        /// </summary>
        public List<Oferta> OfertasAceptadas { get => this.ofertasAceptadas; set => this.ofertasAceptadas = value; }

        /// <summary>
        /// 
        /// </summary>
        public List<Oferta> MisOfertas { get => this.misOfertas; set => this.misOfertas = value; }
        /// <summary>
        /// Crea una Oferta, agrega objetos de Oferta, además de guardar instancias de Oferta en las listas ofertasAceptadas, interesadosEnOfertas.
        /// </summary>
        /// <param name="publicaciones">Publicaciones.</param>
        /// <param name="nombre">Nombre de la oferta.</param>
        /// <param name="material">Material de la oferta.</param>
        /// <param name="precio">Precio de la oferta.</param>
        /// <param name="unidad">Unidad de la oferta.</param>
        /// <param name="tags">Tags de la oferta (palabras claves).</param>
        /// <param name="ubicacion">Ubicación donde se en cuentra el producto que se ofrece.</param>
        /// <param name="puntualesConstantes">Si la oferta es constante o puntual.</param>
        /// <remarks>
        /// Se usa Creator.
        /// </remarks>
        public void CrearOferta(Publicaciones publicaciones, string nombre, string material, string precio, string unidad, string tags, string ubicacion, string puntualesConstantes)
        {   
            Oferta productoCreado = new Oferta(nombre, material, precio, unidad, tags, ubicacion, puntualesConstantes, this);
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
                    this.ofertasAceptadas.Add(ofertaEnLista);
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

            if (!DateTime.TryParseExact(fechaInicio, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out fInicio))
            {
                throw new ArgumentException("Error al introducir la fecha de inicio, por favor ingrese la fecha con este formato: yyyy-MM-dd");
            }
            
            DateTime fFinal;

            if (!DateTime.TryParseExact(fechaFinal, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out fFinal))
            {
                throw new ArgumentException("Error al introducir la fecha final, por favor ingrese la fecha con este formato: yyyy-MM-dd");
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
            if (this.Habilitacion.ListaHabilitaciones.Contains(habilitacionBuscada))
            {
                this.habilitacionesEmpresa.Add(habilitacionBuscada);
            }
        }

        /// <summary>
        /// Quita habilitaciones que tenga la Empresa.
        /// </summary>
        /// <param name="habilitacion">Habilitacion a eliminar.</param>
        public void RemoveHabilitacion(string habilitacion)
        {
            this.habilitacionesEmpresa.Remove(habilitacion);
        }

        /// <summary>
        /// Muestra todas las habilitaciones posibles para agregar.
        /// </summary>
        public string GetListaHabilitaciones()
        {
           return this.Habilitacion.HabilitacionesDisponibles();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string VerInteresados()
        {
            StringBuilder texto = new StringBuilder("Interesados: ");
            if (InteresadosEnOfertas.Count > 0)
            {
                foreach (Oferta oferta in InteresadosEnOfertas)
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
            text.Append($"Rubro: {this.Rubro} \n");
            text.Append($"Ubicación: {this.Ubicacion} \n");
            text.Append($"Habilitaciones: ");
            foreach (string habilitaciones in HabilitacionesEmpresa)
            {
                text.Append($"{habilitaciones}, ");
            }
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
    }
}