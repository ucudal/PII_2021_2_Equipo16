using System;
using System.Collections.Generic;
using System.Text;


namespace ClassLibrary
{
   public class BuscadorUbicacion: IBuscador
    {
        
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