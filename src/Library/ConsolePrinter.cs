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
        /// <param name="oferta"></param>
        public void ofertaPrinter(Oferta oferta)
        {
            Console.WriteLine($"Material: {oferta.Material}, Precio {oferta.Precio}, Unidad: {oferta.Unidad}, Ubicación {oferta.Ubicacion}, Fecha de Publicación {oferta.FechaDePublicacion}");
        }
    }
}