using Telegram.Bot.Types;
using System;

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
        /// <param name="message"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        protected override bool InternalHandle(IMensaje message, out string response)
        {
            if (this.CanHandle(message))
            {
                Console.WriteLine("Entre primeravez");
                Logica.HistorialDeChats.Add(message.Id, new HistorialChat());

                response = "Hola! por favor si le invitaron, escriba /aceptarinvitacion \nSi desea registrarse como emprendedor, escirba /registrarse \nCualquier duda use /comandos";
                return true;    
            }

            response= string.Empty;
            return false;
        }
    }
}