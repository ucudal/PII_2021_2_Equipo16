using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary

{
    /// <summary>
    /// Esta clase representa un buscador por Material, que implementa la infertaz IBuscador.
    /// </summary>
    public class BuscadorMaterial : IBuscador
    {   
        /// <summary>
        /// Busca ofertas en Publicaciones, según el material de la oferta
        /// </summary>
        /// <param name="publicaciones">Publicaciones</param>
        /// <param name="busqueda">Material a buscar</param>
        /// <returns>Retorna las ofertas encontradas por material, mediante una lista de tipo Oferta </returns>
            public List<Oferta> Buscar(Publicaciones publicaciones, string busqueda)
        {
            List<Oferta> ofertasEncontradas = new List<Oferta>();
            foreach (Oferta oferta in publicaciones.OfertasPublicados)
            {
                if (busqueda == oferta.Material)
                {
                    ofertasEncontradas.Add(oferta);
                }
            }
            return ofertasEncontradas;
        }
    }
}