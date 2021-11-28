using System;
namespace ClassLibrary
{
    /// <summary>
    /// Creada clase Usuario de forma publica para que se pueda acceder desde cualquier parte del programa.
    /// </summary>
    /// <remarks>
    /// Creamos la clase Usuario con el fin de que la misma pueda ser usada en la reutilización del código en el programa.
    /// </remarks>
    public class Usuario
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Usuario"/>.
        /// </summary>
        /// <param name="nombre">Recibe un parametro de tipo string con el valor de "nombre".</param>
        /// <param name="ubicacion">Recibe un parametro de tipo string con el valor de "ubicacion".</param>
        /// <param name="rubro">Recibe un parametro de tipo Rubro con el valor de "rubro".</param>
        public Usuario(string nombre, string ubicacion, string rubro)
        {
            this.Nombre = nombre;
            this.Ubicacion = new Ubicacion(ubicacion);
            if (!Singleton<ContenedorRubroHabilitaciones>.Instancia.ChequearRubro(rubro))
            {
                throw new ArgumentException($"{rubro} no se encuentra disponible");
            }
            else
            {
                this.Rubro = Singleton<ContenedorRubroHabilitaciones>.Instancia.GetRubro(rubro);
            }
        }

        /// <summary>
        /// Obtiene o establece un valor que indica el nombre del usuario.
        /// </summary>
        /// <value>Tipo string.</value>
        public string Nombre { get; private set; }

        /// <summary>
        /// Obtiene o establece el valor que indica la ubicación del usuario.
        /// </summary>
        /// <value>Tipo string.</value>
        public Ubicacion Ubicacion { get; private set; }

        /// <summary>
        /// Obtiene o establece el valor con el rubro del usuario.
        /// </summary>
        /// <value>Tipo Rubro.</value>
        public Rubro Rubro { get; private set; }
    }
}