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
            this.RecorreLista();
            return ofertasEncontradas;
        }
        public void RecorreLista()
        {
            StringBuilder texto = new StringBuilder("Ofertas por materiales: \n");
            foreach (Oferta oferta in ofertasEncontradas)
            {
                texto.Append($"{oferta.Nombre}");
            }
            Console.WriteLine(texto.ToString());
        }
    }
}