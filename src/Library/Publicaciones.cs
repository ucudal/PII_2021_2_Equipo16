using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{ 
    /// <summary>
    /// Esta clase se encarga de las Publicaciones.
    /// </summary>
    public class Publicaciones 
    {
        private Publicaciones()
        {
        }
        private static Publicaciones instance;
        
        /// <summary>
        /// Establece una instancia de Publicaciones.
        /// </summary>
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
        
        /// <summary>
        /// Una lista que contiene las ofertas.
        /// </summary>
        public List<Oferta> OfertasPublicados = new List<Oferta>();
        
        /// <summary>
        /// Este método imprime las ofertas contenidas en OfertasPublicados.
        /// </summary>
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
