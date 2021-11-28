
namespace ClassLibrary
{
    public class Singleton<T> where T : class, new()
    {
        private static T instancia;

        private Singleton()
        {
        }

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
        }
    }
}