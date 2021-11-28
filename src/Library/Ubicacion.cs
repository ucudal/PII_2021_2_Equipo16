
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
            this.NombreCalle = nombre;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <value>Valor es un string del nombre.</value>
        public string NombreCalle { get; private set;}


    }
}