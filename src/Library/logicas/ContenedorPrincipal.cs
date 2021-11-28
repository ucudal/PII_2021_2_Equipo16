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
<<<<<<< HEAD:src/Library/logicas/Logica.cs
    public class Logica 
=======
    public class ContenedorPrincipal: IJsonConvertible
>>>>>>> deV2:src/Library/logicas/ContenedorPrincipal.cs
    {
        public ContenedorPrincipal()
        {
        }
        

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
<<<<<<< HEAD:src/Library/logicas/Logica.cs
        [JsonInclude]
        public Publicaciones Publicaciones = Publicaciones.Instance;
=======
        public Publicaciones Publicaciones {get;} = Singleton<Publicaciones>.Instancia;
>>>>>>> deV2:src/Library/logicas/ContenedorPrincipal.cs

        /// <summary>
        /// Guarda una instancia de BuscadorUbicacion.
        /// </summary>
<<<<<<< HEAD:src/Library/logicas/Logica.cs
        [JsonInclude]
        public BuscadorUbicacion BuscadorUbicacion = new BuscadorUbicacion();
=======
        public BuscadorUbicacion BuscadorUbicacion {get;} = new BuscadorUbicacion(); 
>>>>>>> deV2:src/Library/logicas/ContenedorPrincipal.cs

        /// <summary>
        /// Guarda una instancia de BuscadorTags.
        /// </summary>
<<<<<<< HEAD:src/Library/logicas/Logica.cs
        [JsonInclude]
        public BuscadorTags BuscadorTags = new BuscadorTags();
=======
        public BuscadorTags BuscadorTags {get;} = new BuscadorTags();
>>>>>>> deV2:src/Library/logicas/ContenedorPrincipal.cs

        /// <summary>
        /// Guarda una instancia de BuscadorMat.
        /// </summary>
<<<<<<< HEAD:src/Library/logicas/Logica.cs
        [JsonInclude]
        public BuscadorMaterial BuscadorMaterial = new BuscadorMaterial();
=======
        public BuscadorMaterial BuscadorMaterial {get;} = new BuscadorMaterial();
>>>>>>> deV2:src/Library/logicas/ContenedorPrincipal.cs

        /// <summary>
        /// Guarda una instancia de ConsolePrinter.
        /// </summary>
<<<<<<< HEAD:src/Library/logicas/Logica.cs
        [JsonInclude]
        public ConsolePrinter PrinterConsola = new ConsolePrinter();
=======
        public ConsolePrinter PrinterConsola {get;} = new ConsolePrinter();
>>>>>>> deV2:src/Library/logicas/ContenedorPrincipal.cs

        /// <summary>
        /// Guarda strings con los nombres de oferta para que no se repitan.
        /// </summary>
        /// <returns></returns>
<<<<<<< HEAD:src/Library/logicas/Logica.cs
        [JsonInclude]
        public List<string> ListaNombreOfertas = new List<string>();

        /// <summary>
        /// Guarda una instancia de Habilitaciones.
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public Habilitaciones Habilitaciones = new Habilitaciones(); 
=======
        public List<string> ListaNombreOfertas {get;} = new List<string>();

>>>>>>> deV2:src/Library/logicas/ContenedorPrincipal.cs

        /// <summary>
        /// Guarda un conjunto Emprendedor, y su chat id.
        /// </summary>
        /// <returns></returns>
<<<<<<< HEAD:src/Library/logicas/Logica.cs
        [JsonInclude]
        public Dictionary<string, Emprendedor> Emprendedores = new Dictionary<string, Emprendedor>();
=======
        public Dictionary<string, Emprendedor> Emprendedores {get;} = new Dictionary<string, Emprendedor>();
>>>>>>> deV2:src/Library/logicas/ContenedorPrincipal.cs

        /// <summary>
        /// Guarda un conjunto Empresa, y su chat id.
        /// </summary>
        /// <returns></returns>
<<<<<<< HEAD:src/Library/logicas/Logica.cs
        [JsonInclude]
        public Dictionary<string, Empresa> Empresas = new Dictionary<string, Empresa>();
=======
        public Dictionary<string, Empresa> Empresas {get;} = new Dictionary<string, Empresa>();
>>>>>>> deV2:src/Library/logicas/ContenedorPrincipal.cs

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
<<<<<<< HEAD:src/Library/logicas/Logica.cs
        [JsonInclude]
        public Dictionary<string, HistorialChat> HistorialDeChats = new Dictionary<string, HistorialChat>();
=======
        public Dictionary<string, HistorialChat> HistorialDeChats {get;} = new Dictionary<string, HistorialChat>();
>>>>>>> deV2:src/Library/logicas/ContenedorPrincipal.cs

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
<<<<<<< HEAD:src/Library/logicas/Logica.cs
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
        /// <value></value>
        [JsonInclude]
        [JsonExtensionData]
        public Administrador this[string key]
        {
            // returns value if exists
            get { return Administradores[key]; }

            // updates if exists, adds if doesn't exist
            set { Administradores[key] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
=======
        public List<Empresa> EmpresasInvitadas {get;} = new List<Empresa>();

>>>>>>> deV2:src/Library/logicas/ContenedorPrincipal.cs
        public string ConvertToJson()
        {
            JsonSerializerOptions opciones = new()
            {
<<<<<<< HEAD:src/Library/logicas/Logica.cs
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true,
            };

            string json = JsonSerializer.Serialize(this, opciones);
            return json;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            }; 
            Logica logica = JsonSerializer.Deserialize<Logica>(json, options);
        }
=======
                WriteIndented = true,
                ReferenceHandler = MyReferenceHandler.Instance,
            };

            return JsonSerializer.Serialize(this, opciones);
        }

>>>>>>> deV2:src/Library/logicas/ContenedorPrincipal.cs
    }
}