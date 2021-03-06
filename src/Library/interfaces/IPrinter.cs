namespace ClassLibrary
{
    /// <summary>
    /// Esta interfaz contiene un método para imprimir.
    /// </summary>
    /// <remarks>
    /// En este caso se aplicó SRP para poder imprimir las ofertas sin tener que modificarlas a ellas.
    /// Mediante el uso de esta interfaz, se puede incluir el comportamiento de varias fuentes en una clase.
    /// </remarks>
    public interface IPrinter
    {
        /// <summary>
        /// Este método hace un print de la oferta.
        /// </summary>
        /// <param name="oferta">Oferta.</param>
        /// <returns>Retorna una oferta para imprimir.</returns>
        string OfertaPrinter(Oferta oferta);   
    }
}