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