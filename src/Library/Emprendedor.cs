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
        private List<Oferta> OfertasCompradas = new List<Oferta>();
        /// <summary>
        /// Lista de habilitaciones del emprendedor.
        /// </summary>
        public List<string> habilitacionesEmprendedor = new List<string>();
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
            :base(nombre, ubicacion, rubro)
        {
            this.Especializaciones = especializaciones;
            this.Habilitacion = habilitacion;
        }
        
        private Habilitaciones Habilitacion{get; set;}
        /// <summary>
        /// Obtiene una lista de las habilitaciones del emprendedor.
        /// </summary>
        /// <value></value>
        public List<string> HabilitacionesEmprendedor { get => habilitacionesEmprendedor;}
        
        /// <summary>
        /// Especializaciones del emprendedor.
        /// </summary>
        /// <value></value>
        public string Especializaciones {get; set;}
        private List<Oferta> ofertasAceptadas = new List<Oferta>();
        // Por Creator.

        /// <summary>
        /// Agrega habilitaciones.
        /// </summary>
        /// <param name="habilitacionBuscada">Nombre de la habilitacion a agregar.</param>
        public void AddHabilitacion(string habilitacionBuscada)
        {
            if (Habilitacion.ListaHabilitaciones.Contains(habilitacionBuscada))
            {
                habilitacionesEmprendedor.Add(habilitacionBuscada);
            }
        }

        /// <summary>
        /// Quita habilitaciones.
        /// </summary>
        /// <param name="habilitacion">Nombre de la habilitaciones a remover.</param>
        public void RemoveHabilitacion(string habilitacion)
        {
            habilitacionesEmprendedor.Remove(habilitacion);
        }
        
        /// <summary>
        /// Muestra todas las habilitaciones posibles para agregar.
        /// </summary>
        public void GetHabilitacionList()
        {
           Habilitacion.HabilitacionesDisponibles();
        }

        /// <summary>
        /// Calcula cuantas ofertas se han comprado desde diferentes fechas, y cuanto dinero se gastó en ellas.
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFinal"></param>
        public void CalcularOfertasCompradas(string fechaInicio, string fechaFinal) 
        {
            int dineroGastado = 0;
            int ofertasCompradas = 0;
            DateTime fInicio = DateTime.Parse(fechaInicio, CultureInfo.InvariantCulture);
            DateTime fFinal = DateTime.Parse(fechaFinal, CultureInfo.InvariantCulture);
            foreach (Oferta oferta in OfertasCompradas)
            {
                if(oferta.FechaDePublicacion >= fInicio && oferta.FechaDePublicacion <= fFinal)
                {
                ofertasCompradas++;
                dineroGastado = dineroGastado + (oferta.Precio);
                }
            Console.WriteLine("Se han comprado " + ofertasCompradas + " ofertas, gastando un total de " + dineroGastado + "$");
            }
        }   
    }
}
