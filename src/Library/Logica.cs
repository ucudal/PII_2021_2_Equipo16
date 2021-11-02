using System;
using System.Text;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Logica
    {
        /// <summary>
        /// 
        /// </summary>   
        public List<Oferta> BuscarOfertasPorTag(Publicaciones publicaciones, string tag)
        {
            OfertasABuscar.Clear();
            BuscadorTags buscador = new BuscadorTags(); 
            foreach(Oferta oferta in buscador.Buscar(publicaciones, tag))
            {
                OfertasABuscar.Add(oferta);
            }
            Console.WriteLine("Se han encontrado las siguientes ofertas con el tag " + tag + ":" );
            foreach(Oferta oferta in OfertasABuscar)
            {
            ConsolePrinter.ofertaPrinter(oferta);
            } 
            
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
            foreach(Oferta oferta in OfertasABuscar)
            {
                ConsolePrinter.ofertaPrinter(oferta);
            }
            return OfertasABuscar;
        }

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
            foreach(Oferta oferta in OfertasABuscar)
            {
                ConsolePrinter.ofertaPrinter(oferta);
            }
            return OfertasABuscar;
        }
    
}