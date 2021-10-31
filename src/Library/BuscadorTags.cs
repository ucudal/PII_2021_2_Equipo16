using System;
using System.Collections.Generic;
using System.Text;


namespace ClassLibrary
{
    /// <summary>
    /// Clase buscador por tag, que implementa la interfaz IBuscador.
    /// </summary>
    public class BuscadorTags  : IBuscador
    {
        /// <summary>
        /// Busca ofertas en Publicaciones, según los tags de la oferta.
        /// </summary>
        /// <param name="publicaciones">Recibe un parametro de tipo Publicaciones con el nombre de "publicaciones"</param>
        /// <param name="busqueda">Recibe un parametro de tipo string con el nombre de "busqueda"</param>
        /// <returns>Retorna las ofertas encontradas por tag, mediante una lista de tipo Oferta</returns>
        public List<Oferta> Buscar(Publicaciones publicaciones, string busqueda)
        {   List<Oferta> ofertasEncontradas = new List<Oferta>();
            StringBuilder busquedaTagtxt = new StringBuilder();
            foreach (Oferta oferta in publicaciones.OfertasPublicados)
            {
                if (busqueda.Equals(oferta.Tags))
                {
                    busquedaTagtxt.Append(oferta.Tags);
                    ofertasEncontradas.Add(oferta);
                }

            }
            Console.WriteLine("Ofertas encontradas por tag: \n " + busquedaTagtxt.ToString()); // provisorio 
            
            return ofertasEncontradas;

        }
    }   // Fin de la clase BuscadorTags 
    
    
}
