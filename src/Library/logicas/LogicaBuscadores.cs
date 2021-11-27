using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase contiene a los buscadores.
    /// </summary>
    /// <remarks>La creción de clases y la asignación de responsabilidades se hizo en base en un patron GRASP: Low Coupling and High Cohesion,
    /// buscando mantener un equilibrio entre cohesión y acoplamiento.
    /// </remarks>
    public static class LogicaBuscadores
    {
        /// <summary>
        /// Llama al método Buscar para realizar una búsqueda por Material.
        /// </summary>
        /// <param name="busqueda">Palabra clave para buscar.</param>
        /// <returns>Retorna las publicaciones que coinciden con el Material especificado.</returns>
        public static List<Oferta> BuscarPorMaterial(string busqueda)
        {
            return ContenedorPrincipal.Instancia.BuscadorMaterial.Buscar(ContenedorPrincipal.Instancia.Publicaciones, busqueda);
        }

        /// <summary>
        /// Llama al método Buscar para realizar una búsqueda por Tags.
        /// </summary>
        /// <param name="busqueda">Palabra clave para buscar.</param>
        /// <returns>Retorna las ofertas encontradas.</returns>
        /// <returns>Retorna las publicaciones que coinciden con el Tag especificado.</returns>
        public static List<Oferta> BuscarPorTags(string busqueda)
        {
            return ContenedorPrincipal.Instancia.BuscadorTags.Buscar(ContenedorPrincipal.Instancia.Publicaciones, busqueda);
        }

        /// <summary>
        /// Llama al método Buscar para realizar una búsqueda por Ubicación.
        /// </summary>
        /// <param name="busqueda">Palabra clave para buscar.</param>
        /// <returns>Retorna las publicaciones que coinciden con la Ubicación especificada.</returns>
        public static List<Oferta> BuscarPorUbicacion(string busqueda)
        {
            return ContenedorPrincipal.Instancia.BuscadorUbicacion.Buscar(ContenedorPrincipal.Instancia.Publicaciones, busqueda);
        }
    }
}