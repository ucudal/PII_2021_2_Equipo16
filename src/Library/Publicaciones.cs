using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{ 
    public class Publicaciones 
    {
        private Publicaciones()
        {

        }
        private static Publicaciones instance;
        public static Publicaciones Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Publicaciones();
                }
                return instance;
            }
        }
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
