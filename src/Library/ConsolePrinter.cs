using System;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de imprimir por consola los atributos de oferta.
    /// </summary>
    public class ConsolePrinter : IPrinter
    {
        /// <summary>
        /// Este método imprime por consola los atributos de oferta.
        /// </summary>
        /// <param name="oferta">Una oferta.</param>
        public void OfertaPrinter(Oferta oferta)
        {
            Console.WriteLine($"Nombre: {oferta.Nombre}, ID: {oferta.Id}, Material: {oferta.Material}, Precio {oferta.Precio}, Unidad: {oferta.Unidad}, Ubicación {oferta.Ubicacion}, Fecha de Publicación {oferta.FechaDePublicacion}");
        }
    }
}