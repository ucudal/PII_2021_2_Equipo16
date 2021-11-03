namespace ClassLibrary
{
    /// <summary>
    /// Esta interfaz contiene un método para imprimir.
    /// </summary>
    /// <remarks>En este caso se aplicó SRP para poder imprimir las ofertas sin tener que modificarlas a ellas.</remarks>
    public interface IPrinter
    {
        /// <summary>
        /// Este método hace un print de la oferta.
        /// </summary>
        /// <param name="oferta">Oferta.</param>
        void OfertaPrinter(Oferta oferta);
    }
}