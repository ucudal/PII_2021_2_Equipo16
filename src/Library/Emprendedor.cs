using System;
using System.Collections.Generic;
using System.Globalization;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un Emprendedor, que se encarga de buscar ofertas, y de manisfestar su interés en las que sean de su agrado.
    /// </summary>
    public class Emprendedor : Usuario, IHabilitaciones
    {
        /// <summary>
        /// Ofertas en las que se interesa el emprendedor
        /// </summary>
        /// <returns></returns>
        public List<Oferta> OfertasInteresado = new List<Oferta>();
        /// <summary>
        /// Lista de habilitaciones del emprendedor.
        /// </summary>
        public List<string> HabilitacionesEmprendedor = new List<string>();
        
        private List<Oferta> ofertasCompradas = new List<Oferta>();
        
        private string especializaciones;

        /// <summary>
        /// Inicializa una instancia de Emprendedor.
        /// </summary>
        /// <param name="nombre">Nombre del emprededor.</param>
        /// <param name="ubicacion">Ubicación del emprendedor.</param>
        /// <param name="rubro">Rubro del emprendedor.</param>
        /// <param name="habilitacion">Habilitaciones del emprendedor.</param>
        /// <param name="especializaciones">Especializaciones del emprendedor.</param>
        /// <returns></returns>
        public Emprendedor(string nombre, string ubicacion, Rubro rubro, Habilitaciones habilitacion, string especializaciones)
            : base(nombre, ubicacion, rubro)
        {
            this.Especializaciones = especializaciones;
            this.Habilitacion = habilitacion;
        }
        
        /// <summary>
        /// Habilitaciones del emprendedor.
        /// </summary>
        /// <value></value>
        public Habilitaciones Habilitacion = new Habilitaciones();
        
        /// <summary>
        /// Obtiene una lista de las habilitaciones del emprendedor.
        /// </summary>
        /// <value></value>
        public List<string> HabilitacionesDeEmprendedor { get => this.HabilitacionesEmprendedor; }
        
        /// <summary>
        /// Obtiene o establece las Especializaciones del emprendedor.
        /// </summary>
        /// <value></value>
        public string Especializaciones { get; set; }

        /// <summary>
        /// Agrega habilitaciones.
        /// </summary>
        /// <param name="habilitacionBuscada">Nombre de la habilitacion a agregar.</param>
        public void AddHabilitacion(string habilitacionBuscada)
        {
            if (this.Habilitacion.ListaHabilitaciones.Contains(habilitacionBuscada))
            {
                this.HabilitacionesEmprendedor.Add(habilitacionBuscada);
            }
        }

        /// <summary>
        /// Quita habilitaciones.
        /// </summary>
        /// <param name="habilitacion">Nombre de la habilitaciones a remover.</param>
        public void RemoveHabilitacion(string habilitacion)
        {
            this.HabilitacionesEmprendedor.Remove(habilitacion);
        }
        
        /// <summary>
        /// Muestra todas las habilitaciones posibles para agregar.
        /// </summary>
        public void GetHabilitacionList()
        {
           this.Habilitacion.HabilitacionesDisponibles();
        }

        /// <summary>
        /// Calcula cuantas ofertas se han comprado desde diferentes fechas, y cuanto dinero se gastó en ellas.
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFinal"></param>
        public int CalcularOfertasCompradas(string fechaInicio, string fechaFinal) 
        {
            int dineroGastado = 0;
            int ofertasCompradas1 = 0;
            DateTime fInicio = DateTime.Parse(fechaInicio, CultureInfo.InvariantCulture);
            DateTime fFinal = DateTime.Parse(fechaFinal, CultureInfo.InvariantCulture);
            foreach (Oferta oferta in OfertasInteresado)
            {
                if (oferta.FechaDePublicacion >= fInicio && oferta.FechaDePublicacion <= fFinal)
                {
                ofertasCompradas1++;
                dineroGastado = dineroGastado + oferta.Precio;
                }
            }
            Console.WriteLine("Se han comprado " + ofertasCompradas1 + " ofertas, gastando un total de " + dineroGastado + "$");
            return ofertasCompradas1;
        }   
    }
}