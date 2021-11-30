using System.Text;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de imprimir por consola los atributos de oferta.
    /// </summary>
    /// <remarks>
    /// En este caso se aplicó SRP para poder imprimir las ofertas sin tener que modificarlas a ellas y no hacerlo directamente en la clase Ofertas por ejemplo.
    /// </remarks>
    public class TelegramPrinter : IPrinter
    {
        /// <summary>
        /// Este método imprime una string con información.
        /// </summary>
        /// <param name="resultadoBusqueda">El resultado de la búsqueda.</param>
        public static string BusquedaPrinter(List<Oferta> resultadoBusqueda)
        {
            StringBuilder textoBusqueda = new StringBuilder();
            foreach (Oferta oferta in resultadoBusqueda)
            {
                textoBusqueda.Append(oferta.TextoOferta());
                textoBusqueda.Append("\n");
            }

            return textoBusqueda.ToString();
        }

        /// <summary>
        /// Este método imprime por consola los atributos de oferta.
        /// </summary>
        /// <param name="oferta">Una oferta.</param>
        public string OfertaPrinter(Oferta oferta)
        {
            string texto = $"Nombre: {oferta.Nombre}, Material: {oferta.Material.Nombre}, Precio {oferta.Material.Precio}, Unidad: {oferta.Material.Unidad}, Ubicación {oferta.Ubicacion.NombreCalle}, Fecha de Publicación {oferta.FechaDePublicacion}";
            return texto;
        }
    }
}