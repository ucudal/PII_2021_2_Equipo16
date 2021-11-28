namespace ClassLibrary
{
    /// <summary>
    /// Esta clase contiene un método para aceptar una oferta.
    /// </summary>
    public class HolaHandler : BaseHandler
    {
        /// <summary>
        /// Este método se encarga de aceptar una oferta.
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public HolaHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"Hola", "hola"};
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="respuesta"></param>
        /// <returns></returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {

            if (this.CanHandle(mensaje))
            {
                Singleton<Logica>.Instancia.HistorialDeChats.Add(mensaje.Id, new HistorialChat());
                Data.Actualizar();
                respuesta = "Hola! por favor si le invitaron, escriba /aceptarinvitacion \nSi desea registrarse como emprendedor, escriba /registrarse \nCualquier duda use /comandos";
                return true;    
            }

            respuesta = string.Empty;
            return false;
        }
    }
}