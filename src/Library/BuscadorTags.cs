using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Clase buscador por tag, que implementa la interfaz IBuscador.
    /// </summary>
    public class BuscadorTags : IBuscador
    {
        /// <summary>
        /// Busca ofertas en Publicaciones según los tags de la oferta.
        /// </summary>
        /// <remarks>
        /// A la hora de comparar cuando se hace la búsqueda, especificamos que no sea una búsqueda lingüística agregando a System.StringComparison.OrdinalIgnoreCase
        /// como parámetro en la comparación.
        /// Esto quiere decir que las características que son específicas del lenguaje natural se omiten cuando se toman decisiones de comparación y también
        /// el uso de mayúsculas o minúsculas.
        /// Y como resultado el código será más rápido y ganará en precisión y confiabilidad.
        /// </remarks>
        /// <param name="publicaciones">Recibe un parametro de tipo Publicaciones con el nombre de "publicaciones".</param>
        /// <param name="busqueda">Recibe un parametro de tipo string con el nombre de "busqueda".</param>
        /// <returns>Retorna las ofertas encontradas por Tag, mediante una lista de tipo Oferta.</returns>
        public List<Oferta> Buscar(Publicaciones publicaciones, string busqueda)
        {
            List<Oferta> ofertasEncontradas = new List<Oferta>();
            foreach (Oferta oferta in publicaciones.OfertasPublicados)
            {
                if (busqueda.Equals(oferta.Tags, System.StringComparison.OrdinalIgnoreCase))
                {
                    ofertasEncontradas.Add(oferta);
                    Logica.PrinterConsola.OfertaPrinter(oferta);
                }
            }

            return ofertasEncontradas;
        }
    }
}