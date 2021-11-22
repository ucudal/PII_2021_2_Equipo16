using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de las Publicaciones.
    /// </summary>
    /// /// <remarks>
    /// Para esta clase se utilizó el patron de diseño de Expert, ya que desde nuestro punto de vista,
    /// la clase Publicaciones tiene metodos que sean exclusivos de su clase ya que es la que se encarga de conocer 
    /// todo lo necesario para hacer posible la ejecución de sus métodos, y que no sean necesarios para el resto de clases.
    /// </remarks>

    public class Publicaciones
    {
        private Publicaciones()
        {
        }

        private static Publicaciones instance;

        /// <summary>
        /// Obtiene una instancia de Publicaciones.
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
            foreach (Oferta oferta in this.OfertasPublicados)
            {
                getOfertasPublicados.Append($"- {oferta.Nombre}.");
            }

            ConsolePrinter.DatoPrinter(getOfertasPublicados.ToString());
        }
    }
}