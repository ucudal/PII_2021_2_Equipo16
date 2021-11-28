using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Clase buscador por tag, que implementa la interfaz IBuscador.
    /// La implementación de la interfaz es necesaria para unificar el nombre de su método con otras clases que tiene similares caracteristicas.
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
        /// Se encarga de buscar ofertas según el Tags de la misma, implementa IBuscador.
        /// En este caso se aplicó Polimorfismo ya que evitamos tener una clase que haga una búsqueda y dependiendo lo que quieras buscar se comporte de diferente forma.
        /// Lo que se hizo es que haya una interfaz IBuscador que tenga el método Buscar y que las clases que implementen la interfaz, implemente ese método pero a nivel interno funcionando de forma diferente a las otras clases que lo implementan.
        /// Se retorna lo que especifica el método en la interfaz, pero dependiendo la clase retorna la oferta que contenga lo buscado.
        /// </remarks>
        /// <param name="publicaciones">Recibe un parametro de tipo Publicaciones con el nombre de "publicaciones".</param>
        /// <param name="busqueda">Recibe un parametro de tipo string con el nombre de "busqueda".</param>
        /// <returns>Retorna las ofertas encontradas por Tag, mediante una lista de tipo Oferta.</returns>
        public List<Oferta> Buscar(Publicaciones publicaciones, string busqueda)
        {
            List<Oferta> ofertasEncontradas = new List<Oferta>();
            foreach (Oferta oferta in publicaciones.OfertasPublicados)
            {
                if (LimpiadorCadenas.LimpiaCadenaRespuesta(busqueda).Equals((LimpiadorCadenas.LimpiaCadenaRespuesta(oferta.Tags)), System.StringComparison.OrdinalIgnoreCase))
                {
                    ofertasEncontradas.Add(oferta);
<<<<<<< HEAD
                    Singleton<Logica>.Instancia.PrinterConsola.OfertaPrinter(oferta);
=======
                    Singleton<ContenedorPrincipal>.Instancia.PrinterConsola.OfertaPrinter(oferta);
>>>>>>> deV2
                }
            }

            return ofertasEncontradas;
        }
    }
}