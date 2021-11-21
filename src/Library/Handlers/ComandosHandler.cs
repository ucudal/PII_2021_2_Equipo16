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
            this.Keywords = new string[] {"!Comandos", "!comandos", "!Ayuda", "!ayuda"};
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

                texto.Append("\n!AceptarInvitacion - Para empresas invitadas");
                texto.Append("\n!Registrarse - Para emprendedores");
                texto.Append("\n!AceptarOferta - Para empresas que quieren aceptar una de sus ofertas cuando haya negociado algo");
                texto.Append("\n!AceptarInvitacion - Para empresas invitadas");
                texto.Append("\n!AgregarHabilitacionEmprendedor - Para emprendedores que quieren agregar una habilitacion que posean");
                texto.Append("\n!AgregarHabilitacionEmpresa- Para empresas que quieren agregar una habilitacion que posean");
                texto.Append("\n!BuscarMaterial - Para buscar entre todas las ofertas aquellas que tienen el material especificado");
                texto.Append("\n!BuscarTag - Para buscar entre todas las ofertas aquellas que tienen el tag especificado");
                texto.Append("\n!BuscarUbicacion - Para buscar entre todas las ofertas aquellas que tienen la ubicacion especificada");
                texto.Append("\n!CalcularOfertasCompradas - Para emprendedores que quieren saber cuantas en ofertas se interesaron en un periodo de tiempo");
                texto.Append("\n!CalcularOfertasVendidas - Para empresas que quieren saber cuantas ofertas vendieron en un periodo de tiempo");
                texto.Append("\n!CrearHabOferta - Para empresas que quieren agregar una habilitacion/requerimiento a su oferta");
                texto.Append("\n!RemoverHabOferta - Para empresas que desean remover una habilitacion/requeriemiento de una oferta");
                texto.Append("\n!CrearOferta - Para empresas que desean crear ofertas y publicarlas");
                texto.Append("\n!EliminarOferta - Para empresas que desean eliminar una oferta publicada");
                texto.Append("\n!ListaDeHabilitacionesEmpresa - Para empresas que quieren ver la lista de habilitaciones que existen");
                texto.Append("\n!ListaDeHabilitacionesEmprendedor - Para emprendedores que quieren ver la lista de habilitaciones que existen");
                texto.Append("\n!Interesado - Para emprendedores que quieren interesarse en una oferta");
                texto.Append("\n!RemoverHabEmprendedor - Para emprendedores que desean remover una de sus habilitaciones");
                texto.Append("\n!RemoverHabEmpresa - Para empresas que desean remover una de sus habilitaciones");
                



                response = texto.ToString();
                return true;
                

                
            }

            response= string.Empty;
            return false;
        }
    }
}