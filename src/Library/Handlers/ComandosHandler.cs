using Telegram.Bot.Types;
using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase contiene un método para aceptar una oferta.
    /// </summary>
    public class ComandosHandler : BaseHandler
    {
        /// <summary>
        /// Este método se encarga de aceptar una oferta.
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public ComandosHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/comandos"};
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        protected override bool InternalHandle(IMensaje mensaje, out string response)
        {
            if (this.CanHandle(mensaje))
            {
                Console.WriteLine("Entre primeravez");
                Logica.HistorialDeChats[mensaje.Id].MensajesDelUser.Add(mensaje.Text); 
                StringBuilder texto = new StringBuilder("Los comandos son");

                texto.Append("\n/aceptarinvitacion - Para empresas invitadas");
                texto.Append("\n/registrarse - Para emprendedores");
                texto.Append("\n/aceptaroferta - Para empresas que quieren aceptar una de sus ofertas cuando haya negociado algo");
                texto.Append("\n/aceptarinvitacion - Para empresas invitadas");
                texto.Append("\n/agregarhabilitacionemprendedor - Para emprendedores que quieren agregar una habilitacion que posean");
                texto.Append("\n/agregarhabilitacionempresa- Para empresas que quieren agregar una habilitacion que posean");
                texto.Append("\n/buscarmaterial - Para buscar entre todas las ofertas aquellas que tienen el material especificado");
                texto.Append("\n/buscartag - Para buscar entre todas las ofertas aquellas que tienen el tag especificado");
                texto.Append("\n/buscarubicacion - Para buscar entre todas las ofertas aquellas que tienen la ubicacion especificada");
                texto.Append("\n/calcularofertascompradas - Para emprendedores que quieren saber cuantas en ofertas se interesaron en un periodo de tiempo");
                texto.Append("\n/calcularofertasvendidas - Para empresas que quieren saber cuantas ofertas vendieron en un periodo de tiempo");
                texto.Append("\n/crearhaboferta - Para empresas que quieren agregar una habilitacion/requerimiento a su oferta");
                texto.Append("\n/removerhaboferta - Para empresas que desean remover una habilitacion/requeriemiento de una oferta");
                texto.Append("\n/crearoferta - Para empresas que desean crear ofertas y publicarlas");
                texto.Append("\n/eliminaroferta - Para empresas que desean eliminar una oferta publicada");
                texto.Append("\n/listadehabilitacionesempresa - Para empresas que quieren ver la lista de habilitaciones que existen");
                texto.Append("\n/listadehabilitacionesemprendedor - Para emprendedores que quieren ver la lista de habilitaciones que existen");
                texto.Append("\n/interesado - Para emprendedores que quieren interesarse en una oferta");
                texto.Append("\n/removerhabemprendedor - Para emprendedores que desean remover una de sus habilitaciones");
                texto.Append("\n/removerhabempresa - Para empresas que desean remover una de sus habilitaciones");
                texto.Append("\n/verinteresados - Para empresas que desean ver quienes se interesaron en sus ofertas");
                



                response = texto.ToString();
                return true;
                

                
            }

            response= string.Empty;
            return false;
        }
    }
}