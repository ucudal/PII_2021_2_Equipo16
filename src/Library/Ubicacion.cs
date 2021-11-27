
namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Ubicacion
    {

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="Ubicacion"/>.
        /// </summary>
        public Ubicacion(string nombre)
        {
            this.nombreCalle = nombre;
        }
        private string nombreCalle;

        /// <summary>
        /// .
        /// </summary>
        /// <value>Valor es un string del nombre.</value>
        public string NombreCalle { get => nombreCalle; set => nombreCalle = value; }


    }
}