using System;
using System.Collections.Generic;
using System.Text;


namespace ClassLibrary
{
    /// <summary>
    /// Se encarga de buscar ofertas segun la ubicación de la misma, implementa IBuscador.
    /// </summary>
   public class BuscadorUbicacion: IBuscador
    {
        /// <summary>
        /// Busca ofertas en las publicaciones, según la ubicación de la oferta.
        /// </summary>
        /// <param name="publicaciones">Publicaciones</param>
        /// <param name="busqueda">Lo que se va a buscar</param>
        /// <returns></returns>
        public List<Oferta> Buscar(Publicaciones publicaciones, string busqueda)
        {
            List<Oferta> ofertasEncontradas = new List<Oferta>();
            
            foreach (Oferta oferta in publicaciones.OfertasPublicados)
            {
                if (busqueda == oferta.Ubicacion)
                {
                    ofertasEncontradas.Add(oferta);
                }
            }
            return ofertasEncontradas;
           
        }
        
       
        
    }

}