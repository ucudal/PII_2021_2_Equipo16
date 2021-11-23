using System.Collections.Generic;

namespace ClassLibrary
{
     /// <summary>
     /// Interfaz IBuscador que define el metodo a implementar por las clases de busqueda.
     /// </summary>
     /// <remarks>
     /// Mediante el uso de ésta interfaz, se puede incluir el comportamiento de varias fuentes en una clase.
     /// Por ejemplo, la impletentación que realizan las clases BuscadorMaterial, BuscadorTags y BuscadorUbicacion.
     /// </remarks>
    public interface IBuscador
    {
        /// <summary>
        /// Este método se encaga de buscar dentro de Publicaciones.
        /// </summary>
        /// <param name="publicaciones">Recibe parametro del tipo Publicaciones.</param>
        /// <param name="busqueda">Recibe parametro del tipo string.</param>
        /// <returns>Retorna una oferta.</returns>
        List<Oferta> Buscar(Publicaciones publicaciones, string busqueda);
    }
}