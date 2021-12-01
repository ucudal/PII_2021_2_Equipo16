namespace ClassLibrary
{
    /// <summary>
    /// Esta clase utiliza el patron singleton, para lograr que instancias se puedan usar a lo largo del programa sin necesidad de crear una nueva
    /// cada vez, o definirlas como estáticas.
    /// </summary>
    /// <typeparam name="T">Recibe por parametro una variable generica.</typeparam>
    public class Singleton<T> where T : class, new()
    {
        private static T instancia;

        private Singleton()
        {
        }

        /// <summary>
        /// Obtiene o establece la Instancia del Singleton.
        /// </summary>
        public static T Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new T();
                }
                
                return instancia;
            }
            set
            {
                instancia = value; // Agregado para poder Deserializar.
            }
        }
    }
}