using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Se encarga de buscar ofertas segun la ubicación de la misma, implementa IBuscador.
    /// La implementación de la interfaz es necesaria para unificar el nombre de su método con otras clases que tiene similares caracteristicas.
    /// En este caso se aplicó Polimorfismo al implementar IBuscador ya que evitamos tener una clase que haga una busqueda y dependiendo lo que quieras buscar se comporte de diferente forma.
    /// Lo que se hizo es que haya una interfaz IBuscador que tenga el método Buscar y que las clases que implementen la interfaz, implemente ese método pero a nivel interno funcionando de forma diferente a las otras clases que lo implementan.
    /// Se retorna lo que especifica el método en la interfaz, pero dependiendo la clase retorna la oferta que contenga lo buscado.
    /// </summary>
    public class BuscadorUbicacion : IBuscador
    {
        /// <summary>
        /// Busca ofertas en las publicaciones, según la ubicación de la oferta.
        /// </summary>
        /// <param name="publicaciones">Publicaciones.</param>
        /// <param name="busqueda">Lo que se va a buscar.</param>
        /// <returns>Retorna las ofertas encontradas por Ubicación, mediante una lista de tipo Oferta.</returns>
        public List<Oferta> Buscar(Publicaciones publicaciones, string busqueda)
        {
            List<Oferta> ofertasEncontradas = new List<Oferta>();
            foreach (Oferta oferta in publicaciones.OfertasPublicados)
            {
                if (LimpiadorCadenas.LimpiaCadenaRespuesta(busqueda) == LimpiadorCadenas.LimpiaCadenaRespuesta(oferta.Ubicacion.NombreCalle))
                {
                    ofertasEncontradas.Add(oferta);
                    Singleton<ContenedorPrincipal>.Instancia.PrinterConsola.OfertaPrinter(oferta);
                }
            }

            return ofertasEncontradas;
        }
    }
}