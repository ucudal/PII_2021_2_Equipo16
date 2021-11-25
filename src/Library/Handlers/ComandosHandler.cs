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
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (mensaje == null)
            {
                throw new ArgumentNullException("Message no puede ser nulo.");
            }

            if (this.CanHandle(mensaje))
            {
                Logica.HistorialDeChats[mensaje.Id].MensajesDelUser.Add(mensaje.Text); 
                StringBuilder texto = new StringBuilder("Los comandos disponibles son: ");

                texto.Append("\n[COMANDOS PARA EMPRESAS]");
                texto.Append("\n");
                texto.Append("\n/aceptarinvitacion - Use para aceptar una invitación siendo usted una empresa");
                texto.Append("\n/aceptaroferta - Use para aceptar una oferta siendo usted una empresa, luedo de concluir una negociación");
                texto.Append("\n/agregarhabilitacionempresa - Use para agregar una habilitación que posea siendo usted una empresa");
                texto.Append("\n/crearhaboferta - Use si desea agregar una habilitación a su oferta");
                texto.Append("\n/removerhaboferta - Use para remover una habilitación de una oferta");
                texto.Append("\n/crearoferta - Use si desea crear una oferta y publicarla");
                texto.Append("\n/eliminaroferta - Use si desea eliminar una oferta publicada");
                texto.Append("\n/calcularofertasvendidas - Use si desea saber cuantas ofertas se han vendido en un período de tiempo");
                texto.Append("\n/removerhabempresa - Use para remover una habilitación propia de su empresa");
                texto.Append("\n/listadehabilitacionesempresa - Para empresas que quieren ver la lista de habilitaciones que existen");
                texto.Append("\n/verinteresados - Use si desea ver a todos los interesados en sus ofertas");
                texto.Append("\n/verempresa - Use si desea ver todos los atributos de la empresa deseada");
                texto.Append("\n");
                texto.Append("\n[COMANDOS PARA EMPRENDEDORES]");
                texto.Append("\n");
                texto.Append("\n/registrarse - Use para registrarse siendo usted un emprendedor");
                texto.Append("\n/agregarhabilitacionemprendedor - Use para agregar una habilitación que posea");
                texto.Append("\n/removerhabemprendedor - Use si desea remover una de sus habilitaciones");
                texto.Append("\n/buscarmaterial - Use para buscar entre todas aquellas ofertas que tienen el material que usted especificó");
                texto.Append("\n/buscartag - Use para buscar entre todas aquellas ofertas que tienen el tag que usted especificó");
                texto.Append("\n/buscarubicacion - Use para buscar entre todas aquellas ofertas que tienen la ubicación que usted especificó");
                texto.Append("\n/calcularofertascompradas - Use para conocer en cuantas ofertas se interesaron en un determinado período de tiempo");
                texto.Append("\n/listadehabilitacionesemprendedor - Para emprendedores que quieren ver la lista de habilitaciones que existen");
                texto.Append("\n/interesado - Use para interesarse en una oferta");
                
                respuesta = texto.ToString();
                return true;    
            }

            respuesta = string.Empty;
            return false;
        }
    }
}