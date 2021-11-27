using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de crear y guardar instancias de Publicaciones, BuscadorUbicacion, BuscadorTags, BuscadorMaterial y ConsolePrinter.
    /// </summary>
    /// <remarks>La creación de clases y la asignación de responsabilidades se hizo en base en un patron GRASP: Low Coupling and High Cohesion,
    /// buscando mantener un equilibrio entre cohesión y acoplamiento.
    /// </remarks>
    public static class Logica
    {
        /// <summary>
        /// Guarda una instancia de Publicaciones.
        /// </summary>
        public static Publicaciones Publicaciones = Publicaciones.Instance;

        /// <summary>
        /// Guarda una instancia de BuscadorUbicacion.
        /// </summary>
        public static BuscadorUbicacion BuscadorUbicacion = new BuscadorUbicacion();

        /// <summary>
        /// Guarda una instancia de BuscadorTags.
        /// </summary>
        public static BuscadorTags BuscadorTags = new BuscadorTags();

        /// <summary>
        /// Guarda una instancia de BuscadorMat.
        /// </summary>
        public static BuscadorMaterial BuscadorMaterial = new BuscadorMaterial();

        /// <summary>
        /// Guarda una instancia de ConsolePrinter.
        /// </summary>
        public static ConsolePrinter PrinterConsola = new ConsolePrinter();

        /// <summary>
        /// Guarda strings con los nombres de oferta para que no se repitan.
        /// </summary>
        /// <returns></returns>
        public static List<string> ListaNombreOfertas = new List<string>();

        /// <summary>
        /// Guarda una instancia de Habilitaciones.
        /// </summary>
        /// <returns></returns>
        public static Habilitaciones Habilitaciones = new Habilitaciones(); 

        /// <summary>
        /// Guarda un conjunto Emprendedor, y su chat id.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, Emprendedor> Emprendedores = new Dictionary<string, Emprendedor>();

        /// <summary>
        /// Guarda un conjunto Empresa, y su chat id.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, Empresa> Empresas = new Dictionary<string, Empresa>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, HistorialChat> HistorialDeChats = new Dictionary<string, HistorialChat>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<Empresa> EmpresasInvitadas = new List<Empresa>();

        /// <summary>
        /// Guarda un conjunto Administrador, y su chat id.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, Administrador> Administradores = new Dictionary<string, Administrador>();
    }
}