namespace ClassLibrary
{
    /// <summary>
    /// Esta clase contiene a los buscadores.
    /// </summary>
    public static class LogicaBuscadores
    {
        /// <summary>
        /// Llama al método Buscar para realizar una búsqueda por Material.
        /// </summary>
        public static void BuscarPorMaterial(string busqueda)
        {
            Logica.BuscadorMaterial.Buscar(Logica.PublicacionesA, busqueda);
        }
        
        /// <summary>
        /// Llama al método Buscar para realizar una búsqueda por Tags.
        /// </summary>
        /// <param name="busqueda"></param>
        public static void BuscarPorTags(string busqueda)
        {
            Logica.BuscadorTags.Buscar(Logica.PublicacionesA, busqueda);
        }

        /// <summary>
        /// Llama al método Buscar para realizar una búsqueda por Ubicación.
        /// </summary>
        /// <param name="busqueda"></param>
        public static void BuscarPorUbicacion(string busqueda)
        {
            Logica.BuscadorUbicacion.Buscar(Logica.PublicacionesA, busqueda);
        }
    }
}