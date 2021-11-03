namespace ClassLibrary
{
    /// <summary>
    /// Esta interfaz contiene un método para imprimir.
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// Este método hace un print de la oferta.
        /// </summary>
        /// <param name="oferta">Oferta.</param>
        void OfertaPrinter (Oferta oferta);
    }
}