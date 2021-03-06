using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa al Administrador, persona que invitara a las empresas a ingresar a la aplicación.
    /// Esta clase se creo por Expert, porque es la experta en hacer y conocer las Empresas inicialmente y la
    /// responsable de llamar al método de agregar rubros y habilitaciones.
    /// </summary>
    public class Administrador : IJsonConvertible
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Administrador"/>.
        /// </summary>
        [JsonConstructor]
        public Administrador()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Administrador"/>.
        /// </summary>
        /// <param name="nombre">Recibe por parametro un string de nombre.</param>
        /// <param name="clave">Recibe una clave de entrada.</param>
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
        [JsonInclude]
        public List<Empresa> Empresas { get; set; } = new List<Empresa>();

        /// <summary>
        /// Invita a la empresa a unirse en el bot.
        /// </summary>
        /// <param name="empresa">Recibe por parametro la empresa que va a invitar.</param>
        public void InvitarEmpresa(Empresa empresa)
        {
            Singleton<ContenedorPrincipal>.Instancia.EmpresasInvitadas.Add(empresa);
        }

        /// <summary>
        /// Este metodo crea la empresa que el administrador conoce.
        /// </summary>
        /// <param name="nombre">Recibe el nombre de la empresa como string.</param>
        /// <param name="ubicacion">Recibe la ubicacion de la empresa como un string.</param>
        /// <param name="rubro">Recibe el rubro de la empresa como un string.</param>
        public void CrearEmpresa(string nombre, string ubicacion, string rubro)
        {
            Empresa empresa = new Empresa(nombre, ubicacion, rubro);
            this.Empresas.Add(empresa);
            Singleton<ContenedorPrincipal>.Instancia.EmpresasInvitadas.Add(empresa);
        }

        /// <summary>
        /// Este método sive para agregar nuevos rubros.
        /// </summary>
        /// <param name="nombreRubro">Nombre del Rubro.</param>
        public void AgregarRubro(string nombreRubro)
        {
            Singleton<ContenedorPrincipal>.Instancia.ContenedorRubrosHabs.CrearRubro(nombreRubro);
        }

        /// <summary>
        /// Este método sirve para agregar habilitaciones.
        /// </summary>
        /// <param name="nombreHab">Nombre de la habilitación.</param>
        public void AgregarHabilitacion(string nombreHab)
        {
            Singleton<ContenedorPrincipal>.Instancia.ContenedorRubrosHabs.CrearHabilitacion(nombreHab);
        }

        /// <summary>
        /// Metodo que utiliza gracias a la interfaz IJsonConvertible para convertir a formato Json y aplicar en persistencia.
        /// </summary>
        /// <returns>Tipo string.</returns>
        public string ConvertirJson()
        {
            JsonSerializerOptions opciones = new ()
            {
                WriteIndented = true,
                ReferenceHandler = MyReferenceHandler.Instance,
            };

            return JsonSerializer.Serialize(this, opciones);
        }
    }
}