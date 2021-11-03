namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de crear y guardar instancias de Publicaciones, BuscadorUbicacion, BuscadorTags, BuscadorMaterial y ConsolePrinter.
    /// </summary>
    public class Logica
    {
        /// <summary>
        /// Guarda una instancia de Publicaciones.
        /// </summary>
        public static Publicaciones PublicacionesA = Publicaciones.Instance;

        /// <summary>
        /// Guarda una instancia de BuscadorUbicacion.
        /// </summary>
        /// <returns></returns>
        public static BuscadorUbicacion BuscadorUbicacion = new BuscadorUbicacion();

        /// <summary>
        /// Guarda una instancia de BuscadorTags.
        /// </summary>
        /// <returns></returns>
        public static BuscadorTags BuscadorTags = new BuscadorTags();

        /// <summary>
        /// Guarda una instancia de BuscadorMat.
        /// </summary>
        /// <returns></returns>
        public static BuscadorMaterial BuscadorMaterial = new BuscadorMaterial();

        /// <summary>
        /// Guarda una instancia de ConsolePrinter.
        /// </summary>
        /// <returns></returns>
        public static ConsolePrinter PrinterConsola = new ConsolePrinter();
    } 
}