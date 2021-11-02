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
        /// Se inicializa una instancia de la clase Usuario.
        /// </summary>
        /// <param name="nombre">Recibe un parametro de tipo string con el valor de "nombre".</param>
        /// <param name="ubicacion">Recibe un parametro de tipo string con el valor de "ubicacion".</param>
        /// <param name="rubro">Recibe un parametro de tipo Rubro con el valor de "rubro".</param>
        public Usuario(string nombre, string ubicacion, Rubro rubro)
        {   
            this.Nombre = nombre;
            this.Ubicacion = ubicacion;
            this.Rubro = rubro;

        }
        
        /// <summary>
        /// Obtiene un valor que indica el nombre del usuario.
        /// </summary>
        /// <value>Tipo string.</value>
        public string Nombre {get; set;}
        
        /// <summary>
        /// Obtiene un valor que indica la ubicacion del usuario.
        /// </summary>
        /// <value>Tipo string.</value>
        public string Ubicacion {get; set;}
        
        /// <summary>
        /// Obtiene un valor con el rubro del usuario.
        /// </summary>
        /// <value>Tipo Rubro.</value>
        public Rubro Rubro {get; set;}
    }
}