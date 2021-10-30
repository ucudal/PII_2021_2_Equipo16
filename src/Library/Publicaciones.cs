using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{ 
    public class Publicaciones 
    {
        public List<Oferta> OfertasPublicados = new List<Oferta>();
        // Por Creator 
        public void GetOfertasPublicados()
        {
            StringBuilder getOfertasPublicados = new StringBuilder("Ofertas: \n");
            foreach (Oferta oferta in OfertasPublicados)
            {
                getOfertasPublicados.Append($"- {oferta.Nombre}.");   
            }
            Console.WriteLine(getOfertasPublicados.ToString());
        }        
    }
}
