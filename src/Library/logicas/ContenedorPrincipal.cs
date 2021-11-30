using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de crear y guardar instancias de Publicaciones, BuscadorUbicacion, BuscadorTags, BuscadorMaterial y ConsolePrinter.
    /// </summary>
    /// <remarks>La creación de clases y la asignación de responsabilidades se hizo en base en un patron GRASP: Low Coupling and High Cohesion,
    /// buscando mantener un equilibrio entre cohesión y acoplamiento.
    /// </remarks>
    public class ContenedorPrincipal: IJsonConvertible
    {
       /// <summary>
       /// Constructor sin parametros de la clase Empresa, ya que es esencial el atributo JsonConstructor
       /// para la serialización de datos en la clase.
       /// </summary>       
        [JsonConstructor]
        public ContenedorPrincipal()
        {
        }

        /// <summary>
        /// Guarda un conjunto de Chats que ingresa el usuario.
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public Dictionary<string, HistorialChat> HistorialDeChats {get; private set;} = new Dictionary<string, HistorialChat>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public List<Empresa> EmpresasInvitadas {get; private set;} = new List<Empresa>();

        /// <summary>
        /// Guarda un conjunto Emprendedor, y su chat id.
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public Dictionary<string, Emprendedor> Emprendedores {get; private set;} = new Dictionary<string, Emprendedor>();

        /// <summary>
        /// Guarda un conjunto Empresa, y su chat id.
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public Dictionary<string, Empresa> Empresas {get; private set;} = new Dictionary<string, Empresa>();
        
        /// <summary>
        /// Guarda una instancia de Publicaciones.
        /// </summary>
        [JsonInclude]
        public Publicaciones Publicaciones {get; set;} = Singleton<Publicaciones>.Instancia;

        /// <summary>
        /// Guarda una instancia de BuscadorUbicacion.
        /// </summary>
        [JsonInclude]
        public BuscadorUbicacion BuscadorUbicacion {get; private set;} = new BuscadorUbicacion(); 

        /// <summary>
        /// Guarda una instancia de BuscadorTags.
        /// </summary>
        [JsonInclude]
        public BuscadorTags BuscadorTags {get; private set;} = new BuscadorTags();

        /// <summary>
        /// Guarda una instancia de BuscadorMat.
        /// </summary>
        [JsonInclude]
        public BuscadorMaterial BuscadorMaterial {get; private set;} = new BuscadorMaterial();

        /// <summary>
        /// Guarda una instancia de ConsolePrinter.
        /// </summary>
        [JsonInclude]
        public ConsolePrinter PrinterConsola {get; private set;} = new ConsolePrinter();

        /// <summary>
        /// Guarda strings con los nombres de oferta para que no se repitan.
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public List<string> ListaNombreOfertas {get; private set;} = new List<string>();

        /// <summary>
        /// Guarda un conjunto de administradores.
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public Dictionary<string, Administrador> Administradores = new Dictionary<string, Administrador>();

        /// <summary>
        /// Metodo que utiliza gracias a la interfaz IJsonConvertible para convertir a formato Json y aplicar en persistencia. 
        /// </summary>
        /// <returns></returns>
        public string ConvertirJson()
        {
            JsonSerializerOptions opciones = new()
            {
                WriteIndented = true,
                ReferenceHandler = MyReferenceHandler.Instance,
            };

            return JsonSerializer.Serialize(this, opciones);
        }
    }
}