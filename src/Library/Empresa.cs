using System;
using System.Collections.Generic;
using System.Globalization;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa una Empresa, que se encarga de crear Ofertas, eliminarlas, aceptarlas y calcular el consumo de ofertas.
    /// </summary>
    public class Empresa: Usuario, IHabilitaciones
    {
        /// <summary>
        /// Inicializa una instancia de Empresa.
        /// </summary>
        /// <param name="nombre">Nombre de la empresa.</param>
        /// <param name="ubicacion">Ubicación de la empresa.</param>
        /// <param name="rubro">Rubro de la empresa.</param>
        /// <param name="habilitacion">Habilitaciones de la empresa.</param>
        /// <returns></returns>
        public Empresa(String nombre, String ubicacion, Rubro rubro, Habilitaciones habilitacion) 
        : base(nombre, ubicacion, rubro)
        {
            this.Habilitacion = habilitacion;
        }

        private List<string> habilitacionesEmpresa = new List<string>();
        private List<Oferta> ofertasAceptadas = new List<Oferta>();
        private List<Oferta> interesadosEnOfertas = new List<Oferta>();
        
        /// <summary>
        /// Habilitaciones de la empresa.
        /// </summary>
        public Habilitaciones Habilitacion = new Habilitaciones();

        /// <summary>
        /// Obtiene una lista que indica las habiltiaciones que tiene la Empresa.
        /// </summary>
        /// <value></value>
        public List<string> HabilitacionesEmpresa { get => habilitacionesEmpresa; }

        /// <summary>
        /// Obtiene una lista que indica los interesados en oferas que tiene la Empresa.
        /// </summary>
        /// <value></value>
        public List<Oferta> InteresadosEnOfertas { get => interesadosEnOfertas; set => interesadosEnOfertas = value; }
        
        /// <summary>
        /// Obtiene o establece Ofertas de la lista de OfertasAceptadas.
        /// </summary>
        public List<Oferta> OfertasAceptadas { get => ofertasAceptadas; set => ofertasAceptadas = value; }

        /// <summary>
        /// Crea un producto, se usa Creator, agrega objetos de Oferta, además de guardar instancias de Oferta en las listas ofertasAceptadas, interesadosEnOfertas.
        /// </summary>
        /// <param name="publicaciones">Publicaciones.</param>
        /// <param name="nombre">Nombre de la oferta.</param>
        /// <param name="material">Material de la oferta.</param>
        /// <param name="precio">Precio de la oferta.</param>
        /// <param name="unidad">Unidad de la oferta.</param>
        /// <param name="tags">Tags de la oferta (palabras claves).</param>
        /// <param name="ubicacion">Ubicación donde se en cuentra el producto que se ofrece.</param>
        public void CrearProducto(Publicaciones publicaciones, string nombre, string material, int precio, string unidad, string tags, string ubicacion)
        {
            bool habilitacionesAgregadas = false;
            Oferta productoCreado = new Oferta(nombre, material, precio, unidad, tags, ubicacion, this);
            publicaciones.OfertasPublicados.Add(productoCreado);
            while (habilitacionesAgregadas)
            {
                // Todo lo que es console.writeline y ReadLine, es para tenerlo claro en consola, 
                // Cuando conozcamos sobre Telegram se debería modificar.
                Console.WriteLine("Desea agregar mas habilitaciones");
                if (Console.ReadLine() == "Si")
                {
                    Console.WriteLine("Escriba cual quiere agregar");
                    string habilitacionParaAgregar = Console.ReadLine();
                    productoCreado.AddHabilitacion(habilitacionParaAgregar);
                }
                else
                {
                    habilitacionesAgregadas = true;
                }
            }
        }

        /// <summary>
        /// Elimina una oferta creada de las publicaciones.
        /// </summary>
        /// <param name="oferta">Oferta a eliminar.</param>
        /// <param name="publicaciones">Publicaciones.</param>
        public void EliminarProducto(Oferta oferta, Publicaciones publicaciones)
        {
            publicaciones.OfertasPublicados.Remove(oferta);
        }

        /// <summary>
        /// Quita de las publicaciones, la oferta que fue aceptada, ser aceptada implica que se llegó a un acuerdo
        /// con un emprendedor y se quiere quitar la oferta de las publicaciones, además de agregarla a la lista
        /// de ofertasAceptadas que contiene la empresa, para realizar un control de cuantas se aceptan.
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
                    ofertasAceptadas.Add(ofertaEnLista);
                }
            }
            publicaciones.OfertasPublicados.Remove(ofertaEncontrada);
        }

        /// <summary>
        /// Calcula cuantas ofertas se entregaron entre diferentes fechas.
        /// </summary>
        /// <param name="fechaInicio">Fecha inicio, se debe pasar fecha con formato AAAA-MM-DD.</param>
        /// <param name="fechaFinal">Fecha final, se debe pasar fecha con formato AAAA-MM-DD.</param>
        public void CalcularOfertasVendidasSegunTiempo(string fechaInicio, string fechaFinal)
        {
            int cantidadVendida = 0;
            DateTime fInicio = DateTime.Parse(fechaInicio, CultureInfo.InvariantCulture);
            DateTime fFinal = DateTime.Parse(fechaFinal, CultureInfo.InvariantCulture);
            foreach (Oferta oferta in ofertasAceptadas)
            {
                if (oferta.FechaDePublicacion >= fInicio && oferta.FechaDePublicacion <= fFinal)
                {
                   cantidadVendida += 1; 
                }
            }
            Console.WriteLine($"Se vendieron {cantidadVendida} ofertas");
        }
        //Habilitaciones que tengo yo a nivel de empresa

        /// <summary>
        /// Agerga habilitaciones que pueda tener la empresa.
        /// </summary>
        /// <param name="habilitacionBuscada">Habilitación a buscar.</param>
        public void AddHabilitacion(string habilitacionBuscada)
        {
            if (Habilitacion.ListaHabilitaciones.Contains(habilitacionBuscada))
            {
                habilitacionesEmpresa.Add(habilitacionBuscada);
            }
        }
        
        /// <summary>
        /// Quita habilitaciones que tenga la Empresa.
        /// </summary>
        /// <param name="habilitacion">Habilitacion a eliminar.</param>
        public void RemoveHabilitacion(string habilitacion)
        {
            habilitacionesEmpresa.Remove(habilitacion);
        }

        /// <summary>
        /// Muestra todas las habilitaicones posibles para agregar.
        /// </summary>
        public void GetHabilitacionList()
        {
            Habilitacion.HabilitacionesDisponibles();
        }
    }
}