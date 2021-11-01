using System;
using System.Collections.Generic;
using System.Text;


namespace ClassLibrary
{
    //Crear lista de ofertas por fuera de metodos
    //Crear metodo impresion de lista
    //a los metodos de busqueda, clean al principio de lista
    //llamar a metodo impresion dentro de buscadores para verlas graficamente
    //en interesadoenoferta, chequear si la lista de ofertas tiene la oferta que busco
    //concatenar con nombre de emprendedor(temporal)

    /// <summary>
    /// Esta clase representa un Emprendedor, que se encarga de buscar ofertas, y de manisfestar su interés en las que sean de su agrado
    /// </summary>
    public class Emprendedor : Usuario, IHabilitaciones
    {
        private List<Oferta> OfertasCompradas = new List<Oferta>();
        private List<Oferta> OfertasABuscar = new List<Oferta>();
        public List<Habilitaciones> Habilitaciones = new List<Habilitaciones>();
        private string especializaciones;

        /// <summary>
        /// Inicializa una instancia de Emprendedor
        /// </summary>
        /// <param name="nombre">Nombre del emprededor</param>
        /// <param name="ubicacion">Ubicación del emprendedor</param>
        /// <param name="rubro">Rubro del emprendedor</param>
        /// <param name="especializaciones">Especializaciones del emprendedor</param>
        /// <returns></returns>
        public Emprendedor(string nombre, string ubicacion, Rubro rubro, string especializaciones)
            :base(nombre, ubicacion, rubro)
        {
            
            this.Especializaciones = especializaciones;
        }
        
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
        /// <param name="nombre">Nombre de la habilitacion a agregar</param>
            public void AddHabilitacion(string nombre)
        {
            Habilitaciones habilitacion = new Habilitaciones(nombre);
            this.Habilitaciones.Add(habilitacion);
            Console.WriteLine($"Habilitación '{habilitacion.Nombre}' agregada exitosamente.");
        }

        /// <summary>
        /// Quita habilitaciones
        /// </summary>
        /// <param name="nombre">Nombre de la habilitaciones a remover</param>
        public void RemoveHabilitacion(string nombre)
        {
            Habilitaciones habilitacion = new Habilitaciones(nombre);
            this.Habilitaciones.Remove(habilitacion);
            Console.WriteLine( $"Habilitación '{habilitacion.Nombre}' eliminada exitosamente.");
        }
        
        /// <summary>
        /// Muestra todas las habilitaciones posibles para agregar
        /// </summary>
        public void GetHabilitacionList()
        {
            StringBuilder getHabilitaciones = new StringBuilder("Habilitaciones: \n");
            foreach (Habilitaciones habilitacion in Habilitaciones)
            {
                getHabilitaciones.Append($"- {habilitacion.Nombre}.");   
            }
            Console.WriteLine(getHabilitaciones.ToString());
        }
        /// <summary>
        /// Busca ofertas dentro de las publicaciones mediante tags
        /// </summary>
        /// <param name="publicaciones">Publicaciones</param>
        /// <param name="tag">Tags a buscar</param>
        /// <returns></returns>
        public List <Oferta> BuscarOfertasPorTag(Publicaciones publicaciones, string tag)
        {
            List<Oferta> resultado = new List<Oferta>();
            BuscadorTags buscador = new BuscadorTags();
            foreach(Oferta oferta in buscador.Buscar(publicaciones, tag))
            {
                resultado.Add(oferta);
            }
            return resultado;
        }

        /// <summary>
        /// Busca ofertas dentro de las publicaciones por ubicación
        /// </summary>
        /// <param name="publicaciones">Publicaciones</param>
        /// <param name="ubicacion">Ubicación a buscar</param>
        /// <returns></returns>
        public List<Oferta> BuscarOfertasPorUbicacion(Publicaciones publicaciones, string ubicacion)
        {
            List<Oferta> resultado = new List<Oferta>();
            BuscadorUbicacion buscador = new BuscadorUbicacion();
            foreach(Oferta oferta in buscador.Buscar(publicaciones, ubicacion))
            {
                resultado.Add(oferta);
            }
            return resultado;
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
            //OfertasABuscar.Clear();
            List<Oferta> resultado = new List<Oferta>();
            BuscadorMaterial buscador = new BuscadorMaterial();
            foreach(Oferta oferta in buscador.Buscar(publicaciones, material))
            {
                OfertasABuscar.Add(oferta);
                resultado.Add(oferta);
            }
            Console.WriteLine("Se han encontrado las siguientes ofertas con el material  " + material + ":" );
            ConsolePrinter.OfertaPrinter(resultado);
            return resultado;
        }
        
        
        public void InteresadoEnOferta(Oferta oferta) //
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFinal"></param>
        public void CalcularOfertasCompradas() 
        {
            int dineroGastado = 0;
            int ofertasCompradas = 0;
            foreach (Oferta oferta in OfertasCompradas)
            {
                ofertasCompradas++;
                dineroGastado = dineroGastado + (oferta.PrecioTotal);
            }
            Console.WriteLine("Se han comprado " + ofertasCompradas + " ofertas, gastando un total de " + dineroGastado + "$");
        }


    }
}
