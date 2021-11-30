
namespace ClassLibrary
{
    /// <summary>
    /// Esta clase utiliza el patron singleton.
    /// </summary>
    /// <typeparam name="T">Recibe por parametro una variable generica.</typeparam>
    public class Singleton<T> where T : class, new()
    {
        private static T instancia;

        private Singleton()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
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
                instancia = value;
            }
        }
    }
}