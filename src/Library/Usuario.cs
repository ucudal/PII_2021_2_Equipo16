namespace ClassLibrary
{
    /// <summary>
    /// Creada clase Usuario de forma publica para que se pueda acceder desde cualquier parte del programa.
    /// </summary>
    public class Usuario
    {
        private string nombre;
        private string ubicacion;
        private string rubro;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Usuario"/>.
        /// </summary>
        /// <param name="nombre">Recibe un parametro de tipo string con el valor de "nombre".</param>
        /// <param name="ubicacion">Recibe un parametro de tipo string con el valor de "ubicacion".</param>
        /// <param name="rubro">Recibe un parametro de tipo Rubro con el valor de "rubro".</param>
        public Usuario(string nombre, string ubicacion, string rubro)
        {
            this.Nombre = nombre;
            this.Ubicacion = ubicacion;
            this.Rubro = rubro;
        }

        /// <summary>
        /// Obtiene o establece un valor que indica el nombre del usuario.
        /// </summary>
        /// <value>Tipo string.</value>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el valor que indica la ubicación del usuario.
        /// </summary>
        /// <value>Tipo string.</value>
        public string Ubicacion { get; set; }

        /// <summary>
        /// Obtiene o establece el valor con el rubro del usuario.
        /// </summary>
        /// <value>Tipo Rubro.</value>
        public string Rubro { get; set; }
    }
}