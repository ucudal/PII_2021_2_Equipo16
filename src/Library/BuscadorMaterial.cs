using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary

{

    public class BuscadorMaterial : IBuscador
    {
        List<Oferta> ofertasEncontradas = new List<Oferta>();
        public List<Oferta> Buscar(Publicaciones publicaciones, string busqueda)
        {
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