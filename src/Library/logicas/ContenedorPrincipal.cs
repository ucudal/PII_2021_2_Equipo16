using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de crear y guardar instancias de Publicaciones, BuscadorUbicacion, BuscadorTags, BuscadorMaterial y ConsolePrinter.
    /// </summary>
    /// <remarks>La creación de clases y la asignación de responsabilidades se hizo en base en un patron GRASP: Low Coupling and High Cohesion,
    /// buscando mantener un equilibrio entre cohesión y acoplamiento.
    /// </remarks>
    public class ContenedorPrincipal
    {
        private ContenedorPrincipal()
        {
        }
        private static ContenedorPrincipal instancia;

        public static ContenedorPrincipal Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ContenedorPrincipal();
                }

                return instancia;
            }
        }

        /// <summary>
        /// Guarda una instancia de Publicaciones.
        /// </summary>
        public Publicaciones Publicaciones {get;} = Publicaciones.Instance;

        /// <summary>
        /// Guarda una instancia de BuscadorUbicacion.
        /// </summary>
        public BuscadorUbicacion BuscadorUbicacion {get;} = new BuscadorUbicacion(); 

        /// <summary>
        /// Guarda una instancia de BuscadorTags.
        /// </summary>
        public BuscadorTags BuscadorTags {get;} = new BuscadorTags();

        /// <summary>
        /// Guarda una instancia de BuscadorMat.
        /// </summary>
        public BuscadorMaterial BuscadorMaterial {get;} = new BuscadorMaterial();

        /// <summary>
        /// Guarda una instancia de ConsolePrinter.
        /// </summary>
        public ConsolePrinter PrinterConsola {get;} = new ConsolePrinter();

        /// <summary>
        /// Guarda strings con los nombres de oferta para que no se repitan.
        /// </summary>
        /// <returns></returns>
        public List<string> ListaNombreOfertas {get;} = new List<string>();


        /// <summary>
        /// Guarda un conjunto Emprendedor, y su chat id.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Emprendedor> Emprendedores {get;} = new Dictionary<string, Emprendedor>();

        /// <summary>
        /// Guarda un conjunto Empresa, y su chat id.
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, Empresa> Empresas {get;} = new Dictionary<string, Empresa>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, HistorialChat> HistorialDeChats {get;} = new Dictionary<string, HistorialChat>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Empresa> EmpresasInvitadas {get;} = new List<Empresa>();

    }
}