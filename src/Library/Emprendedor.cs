using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un Emprendedor, que se encarga de buscar ofertas, y de manisfestar su interés en las que sean de su agrado
    /// </summary>
    public class Emprendedor : Usuario, IHabilitaciones
    {
        private List<Oferta> OfertasCompradas = new List<Oferta>();
        private List<Oferta> OfertasABuscar = new List<Oferta>();
        public List<string> habilitacionesEmprendedor = new List<string>();
        private string especializaciones;

        /// <summary>
        /// Inicializa una instancia de Emprendedor
        /// </summary>
        /// <param name="nombre">Nombre del emprededor</param>
        /// <param name="ubicacion">Ubicación del emprendedor</param>
        /// <param name="rubro">Rubro del emprendedor</param>
        /// <param name="habilitacion">Habilitaciones del emprendedor</param>
        /// <param name="especializaciones">Especializaciones del emprendedor</param>
        /// <returns></returns>
        public Emprendedor(string nombre, string ubicacion, Rubro rubro, Habilitaciones habilitacion, string especializaciones)
            :base(nombre, ubicacion, rubro)
        {
            
            this.Especializaciones = especializaciones;
            this.Habilitacion = habilitacion;
        }
        
        private Habilitaciones Habilitacion{get; set;}
        /// <summary>
        /// Obtiene una lista de las habilitaciones del emprendedor
        /// </summary>
        /// <value></value>
        public List<string> HabilitacionesEmprendedor { get => habilitacionesEmprendedor;}
        
        /// <summary>
        /// Especializaciones del emprendedor
        /// </summary>
        /// <value></value>
        public string Especializaciones {get; set;}
        private List<Oferta> ofertasAceptadas = new List<Oferta>();
        // Por Creator

        /// <summary>
        /// Agrega habilitaciones
        /// </summary>
        /// <param name="habilitacionBuscada">Nombre de la habilitacion a agregar</param>
        public void AddHabilitacion(string habilitacionBuscada)
        {
            if (Habilitacion.ListaHabilitaciones.Contains(habilitacionBuscada))
            {
                habilitacionesEmprendedor.Add(habilitacionBuscada);
            }
        }

        /// <summary>
        /// Quita habilitaciones
        /// </summary>
        /// <param name="habilitacion">Nombre de la habilitaciones a remover</param>
        public void RemoveHabilitacion(string habilitacion)
        {
            habilitacionesEmprendedor.Remove(habilitacion)
        }
        
        /// <summary>
        /// Muestra todas las habilitaciones posibles para agregar
        /// </summary>
        public void GetHabilitacionList()
        {
           Habilitacion.HabilitacionesDisponibles();
        }
        /// <summary>
        /// Busca ofertas dentro de las publicaciones mediante tags
        /// </summary>
        /// <param name="publicaciones">Publicaciones</param>
        /// <param name="tag">Tags a buscar</param>
        /// <returns></returns>
        public List <Oferta> BuscarOfertasPorTag(Publicaciones publicaciones, string tag)
        {
            OfertasABuscar.Clear();
            BuscadorTags buscador = new BuscadorTags(); 
            foreach(Oferta oferta in buscador.Buscar(publicaciones, tag))
            {
                OfertasABuscar.Add(oferta);
            }
            Console.WriteLine("Se han encontrado las siguientes ofertas con el tag " + tag + ":" );
            ConsolePrinter.OfertaPrinter(OfertasABuscar);
            return OfertasABuscar;
        }
        /// <summary>
        /// Busca ofertas dentro de las publicaciones por ubicación
        /// </summary>
        /// <param name="publicaciones">Publicaciones</param>
        /// <param name="ubicacion">Ubicación a buscar</param>
        /// <returns></returns>
        public List<Oferta> BuscarOfertasPorUbicacion(Publicaciones publicaciones, string ubicacion)
        {
            OfertasABuscar.Clear();
            BuscadorUbicacion buscador = new BuscadorUbicacion(); 
            foreach(Oferta oferta in buscador.Buscar(publicaciones, ubicacion))
            {
                OfertasABuscar.Add(oferta);
            }
            Console.WriteLine("Se han encontrado las siguientes ofertas en la ubicación  " + ubicacion + ":" );
            ConsolePrinter.OfertaPrinter(OfertasABuscar);
            return OfertasABuscar;
        }

        //buscar justificar (patron)
        /// <summary>
        /// Busca ofertas dentro de las publicaciones por Materiales y las imprime en pantalla
        /// </summary>
        /// <param name="publicaciones">Publicaciones</param>
        /// <param name="material">Material a buscar</param>
        /// <returns>Retorna la lista de ofertas con ese material</returns>
        public List<Oferta> BuscarOfertasPorMaterial(Publicaciones publicaciones, string material)
        {
            OfertasABuscar.Clear();
            BuscadorMaterial buscador = new BuscadorMaterial(); //CLASE
            foreach(Oferta oferta in buscador.Buscar(publicaciones, material))
            {
                OfertasABuscar.Add(oferta);
            }
            Console.WriteLine("Se han encontrado las siguientes ofertas con el material  " + material + ":" );
            ConsolePrinter.OfertaPrinter(OfertasABuscar);
            return OfertasABuscar;
        }
        
        
        //Dos formas: -mandar un mensaje
        //            -Bool Interesado , ¿Como empresa lo chequea constantemente?
        //              ¿Suscripcion?

        public void InteresadoEnOferta(Oferta oferta)
        {

            
        }
        /// <summary>
        /// Calcula cuantas ofertas se han comprado desde diferentes fechas, y cuanto dinero se gastó en ellas
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
