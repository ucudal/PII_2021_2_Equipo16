
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa al Administrador, persona que invitara a las empresas a ingresar a la aplicación.
    /// Esta clase se creo por Expert, porque es la experta en hacer y conocer las Empresas inicialmente. 
    /// </summary>
    public class Administrador : IJsonConvertible
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Administrador"/>.
        /// </summary>
        /// <param name="nombre">Recibe por parametro un string de nombre.</param>
    
       [JsonConstructor]
        public Administrador(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                this.Nombre = "Jhon";
            }
            
            else 
            {
                this.Nombre = nombre;
            }
        }

        /// <summary>
        /// Obtiene o establece un valor que le da el nombre al administrador.
        /// </summary>
        /// <value>El valor del nombre es de tipo string.</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Esta lista contiene las empresas que el Administrador a invitado a unirse a la aplicación.
        /// </summary>
        /// <returns>Retorna la lista de Empresas que contiene.</returns>
        public List<Empresa> Empresas = new List<Empresa>();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="ubicacion"></param>
        /// <param name="rubro"></param>
        public void InvitarEmpresa(string nombre, string ubicacion, string rubro)
        {
            Empresa empresa = new Empresa(nombre, ubicacion, rubro);
            this.Empresas.Add(empresa);
            Logica.EmpresasInvitadas.Add(empresa);

        }
         public string ConvertToJson()
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(this, options);
         }
    }
}