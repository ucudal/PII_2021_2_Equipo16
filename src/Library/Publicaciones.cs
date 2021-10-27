using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public static class Publicaciones 
    {
        
        public static List<Oferta> OfertasPublicados = new List<Oferta>();
        // Por Creator 
        public static void AddOferta(string nombre, string material, int precio, string unidad, int cantidad, string tags, string ubicacion)
        {
            Oferta oferta = new Oferta(nombre, material, precio, unidad, cantidad, tags, ubicacion);
            OfertasPublicados.Add(Oferta);
        }
        // Por Creator
        public static void RemoveOferta(string nombre, string material, int precio, string unidad, int cantidad, string tags, string ubicacion)
        {
            Oferta oferta = new Oferta(nombre, material, precio, unidad, cantidad, tags, ubicacion);
            OfertasPublicados.Remove(oferta);
        }
        public static void GetOfertasPublicados()
        {
            StringBuilder getOfertasPublicados = new StringBuilder("Ofertas: \n");
            foreach (Oferta oferta in OfertasPublicados)
            {
                getOfertasPublicados.Append($"- {oferta.Nombre}.");   
            }
            Console.WriteLine(getOfertasPublicados.ToString());
        }
        public static Oferta GetOferta(Oferta oferta)
        {
            OfertasPublicados.Remove(oferta);
            return oferta;
        }


        
    }
}
