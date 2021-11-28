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
    public class Logica 
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonConstructor]
        public Logica()
        {

        }
        
        /// <summary>
        /// Guarda una instancia de Publicaciones.
        /// </summary>
        [JsonInclude]
        public Publicaciones Publicaciones = Singleton<Publicaciones>.Instancia;

        /// <summary>
        /// Guarda una instancia de BuscadorUbicacion.
        /// </summary>
        [JsonInclude]
        public BuscadorUbicacion BuscadorUbicacion = new BuscadorUbicacion();

        /// <summary>
        /// Guarda una instancia de BuscadorTags.
        /// </summary>
        [JsonInclude]
        public BuscadorTags BuscadorTags = new BuscadorTags();

        /// <summary>
        /// Guarda una instancia de BuscadorMat.
        /// </summary>
        [JsonInclude]
        public BuscadorMaterial BuscadorMaterial = new BuscadorMaterial();

        /// <summary>
        /// Guarda una instancia de ConsolePrinter.
        /// </summary>
        [JsonInclude]
        public ConsolePrinter PrinterConsola = new ConsolePrinter();

        /// <summary>
        /// Guarda strings con los nombres de oferta para que no se repitan.
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public List<string> ListaNombreOfertas = new List<string>();

        /// <summary>
        /// Guarda una instancia de Habilitaciones.
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public Habilitaciones Habilitaciones = new Habilitaciones(); 

        /// <summary>
        /// Guarda un conjunto Emprendedor, y su chat id.
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public Dictionary<string, Emprendedor> Emprendedores = new Dictionary<string, Emprendedor>();

        /// <summary>
        /// Guarda un conjunto Empresa, y su chat id.
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public Dictionary<string, Empresa> Empresas = new Dictionary<string, Empresa>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public Dictionary<string, HistorialChat> HistorialDeChats = new Dictionary<string, HistorialChat>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public List<Empresa> EmpresasInvitadas = new List<Empresa>();

        /// <summary>
        /// Guarda un conjunto Administrador, y su chat id.
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public Dictionary<string, Administrador> Administradores = new Dictionary<string, Administrador>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            JsonSerializerOptions opciones = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true,
            };

            string json = JsonSerializer.Serialize(this, opciones);
            return json;
        }

        /*
        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            this.Initialize();
            this. = JsonSerializer.Deserialize<Logica>(json);
            JsonSerializerOptions options = new()
            {
                 ReferenceHandler = MyReferenceHandler.Instance,
                 WriteIndented = true
            };

            this. = JsonSerializer.Deserialize<Logica>(json, options);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public List<string> jsondelortomastevalequefunciones = new List<string>();
        */
    }
}