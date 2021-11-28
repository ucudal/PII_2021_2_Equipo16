<<<<<<< HEAD
namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Singleton<T> where T : class, new()
    {
        private static T instancia;

        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
=======

namespace ClassLibrary
{
    public class Singleton<T> where T : class, new()
    {
        private static T instancia;

        private Singleton()
        {
        }

>>>>>>> deV2
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
<<<<<<< HEAD
=======
            set
            {
                instancia = value;
            }
>>>>>>> deV2
        }
    }
}