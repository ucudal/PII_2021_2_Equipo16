using System;
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
        /// <param name="clave">Recibe una clave de entrada.</param>
    
       [JsonConstructor]
        public Administrador(string nombre, string clave)
        {
            if (string.IsNullOrEmpty(nombre))
            {
                this.Nombre = "Jhon";
            }
            else 
            {
                this.Nombre = nombre;
            }
            this.clave = clave;
        }

        /// <summary>
        /// Obtiene o establece un valor que le da el nombre al administrador.
        /// </summary>
        /// <value>El valor del nombre es de tipo string.</value>
        public string Nombre { get; set; }

        private string clave;

        /// <summary>
        /// Este método sirve para que el administrador pueda cambiar su contraseña.
        /// </summary>
        /// <param name="password">Recibe como parametro la contraseña que se le da por defecto al administrador.</param>
        /// <param name="nuevaPassword">Recibe como parametro la nueva contraseña que el administrador desea para su cuenta.</param>
        public void CambioClave(string password, string nuevaPassword)
        {
            if (password == this.clave)
            {
                if (string.IsNullOrEmpty(nuevaPassword))
                {
                    throw new ArgumentException($"Error al introducir la clave. La clave no puede ser vacia o nula.\nIntente nuevamente /cambiarClave");
                }
                else
                {
                    this.clave = nuevaPassword;
                }   
            }
            else
            {
                throw new ArgumentException("La clave ingresaste no es correcta.");
            }
        }
        

        /// <summary>
        /// Esta lista contiene las empresas que el Administrador a invitado a unirse a la aplicación.
        /// </summary>
        /// <returns>Retorna la lista de Empresas que contiene.</returns>
        public List<Empresa> Empresas = new List<Empresa>();

        /// <summary>
        /// Invita a la empresa a unirse en el bot.
        /// </summary>
        /// <param name="nombre">Recibe el nombre de la empresa como string.</param>
        /// <param name="ubicacion">Recibe la ubicacion de la empresa como un string.</param>
        /// <param name="rubro">Recibe el rubro de la empresa como un string.</param>
        public void InvitarEmpresa(string nombre, string ubicacion, string rubro)
        {
            Empresa empresa = new Empresa(nombre, ubicacion, rubro);
            this.Empresas.Add(empresa);
            Logica.EmpresasInvitadas.Add(empresa);

        }

        /// <summary>
        /// Convierte a formato .Json.
        /// </summary>
        /// <returns>Tipo string.</returns>
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