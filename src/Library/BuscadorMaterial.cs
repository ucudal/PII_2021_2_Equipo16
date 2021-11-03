using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    ///Esta clase representa un buscador por Material, que implementa la infertaz IBuscador.
    /// </summary>
    /// <remarks>
    /// En este caso se aplicó Polimorfismo ya que evitamos tener una clase que haga una busqueda
    /// y dependiendo lo que quieras buscar se comporte de diferente forma.
    /// Lo que se hizo es que haya una interfaz IBuscador que tenga el método Buscar
    /// y que las clases que implementen la interfaz, implemente ese método pero a nivel interno 
    /// funcionando de forma diferente a las otras clases que lo implementan.
    /// Se retorna lo que especifica el método en la interfaz, pero dependiendo la clase retorna 
    /// la oferta que contenga lo buscado.
    /// </remarks>
    public class BuscadorMaterial : IBuscador
    {     
        List<Oferta> ofertasEncontradas = new List<Oferta>();
        /// <summary>
        /// Busca ofertas en Publicaciones, según el material de la oferta.
        /// </summary>
        /// <param name="publicaciones">Publicaciones</param>
        /// <param name="busqueda">Material a buscar</param>
        /// <returns>Retorna las ofertas encontradas por material, mediante una lista de tipo Oferta.</returns>
        public List<Oferta> Buscar(Publicaciones publicaciones, string busqueda)
        {
            foreach (Oferta oferta in publicaciones.OfertasPublicados)
            {
                if (busqueda == oferta.Material)
                {
                    ofertasEncontradas.Add(oferta);
                    Logica.PrinterConsola.OfertaPrinter(oferta);
                }
            }
            return ofertasEncontradas;
        } 
    }
}