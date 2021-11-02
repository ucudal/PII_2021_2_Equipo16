namespace ClassLibrary
{
    /// <summary>
    /// Esta clase contiene a los buscadores.
    /// </summary>
    public class LogicaBuscadores
    {
        /// <summary>
        /// Llama al método Buscar para realizar una búsqueda por Material.
        /// </summary>
        public void BuscarPorMaterial(string busqueda)
        {
            Logica.buscadorMaterial.Buscar(Logica.PublicacionesA, busqueda);
        }
        
        /// <summary>
        /// Llama al método Buscar para realizar una búsqueda por Tags.
        /// </summary>
        /// <param name="busqueda"></param>
        public void BuscarPorTags(string busqueda)
        {
            Logica.buscadorTags.Buscar(Logica.PublicacionesA, busqueda);
        }

        /// <summary>
        /// Llama al método Buscar para realizar una búsqueda por Ubicación.
        /// </summary>
        /// <param name="busqueda"></param>
        public void BuscarPorUbicacion(string busqueda)
        {
            Logica.buscadorUbicacion.Buscar(Logica.PublicacionesA, busqueda);
        }
    }
}