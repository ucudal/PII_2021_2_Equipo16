using System;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/comandos" y se encarga
    /// de manejar el caso en que se quieran ver los comandos que tiene el Bot.
    /// </summary>
    public class ComandosHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ComandosHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public ComandosHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/comandos" };
        }

        /// <summary>
        /// Este método procesa el mensaje para mostrar los comandos disponibles en el Bot.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            //Comandos Empresa
            StringBuilder comandosEmpresa = new StringBuilder("Los comandos disponibles son: ");
            comandosEmpresa.Append("\n[COMANDOS PARA EMPRESAS]");
            comandosEmpresa.Append("\n");
            comandosEmpresa.Append("\n/aceptarinvitacion - Use para aceptar una invitación siendo usted una empresa");
            comandosEmpresa.Append("\n/aceptaroferta - Use para aceptar una oferta siendo usted una empresa, luedo de concluir una negociación");
            comandosEmpresa.Append("\n/agregarhabilitacionempresa - Use para agregar una habilitación que posea siendo usted una empresa");
            comandosEmpresa.Append("\n/agregarhaboferta - Use si desea agregar una habilitación a su oferta");
            comandosEmpresa.Append("\n/removerhaboferta - Use para remover una habilitación de una oferta");
            comandosEmpresa.Append("\n/crearoferta - Use si desea crear una oferta y publicarla");
            comandosEmpresa.Append("\n/eliminaroferta - Use si desea eliminar una oferta publicada");
            comandosEmpresa.Append("\n/calcularofertasvendidas - Use si desea saber cuantas ofertas se han vendido en un período de tiempo");
            comandosEmpresa.Append("\n/removerhabempresa - Use para remover una habilitación propia de su empresa");
            comandosEmpresa.Append("\n/listadehabilitacionesempresa - Para empresas que quieren ver la lista de habilitaciones que existen");
            comandosEmpresa.Append("\n/verinteresados - Use si desea ver a todos los interesados en sus ofertas");
            comandosEmpresa.Append("\n/verempresa - Use si desea ver todos los atributos de la empresa deseada");

            StringBuilder comandosEmprendedor = new StringBuilder("Los comandos disponibles son: ");
            comandosEmprendedor.Append("\n[COMANDOS PARA EMPRENDEDORES]");
            comandosEmprendedor.Append("\n");
            comandosEmprendedor.Append("\n/registrarme - Use para registrarse siendo usted un emprendedor");
            comandosEmprendedor.Append("\n/agregarhabilitacionemprendedor - Use para agregar una habilitación que posea");
            comandosEmprendedor.Append("\n/removerhabemprendedor - Use si desea remover una de sus habilitaciones");
            comandosEmprendedor.Append("\n/buscarmaterial - Use para buscar entre todas aquellas ofertas que tienen el material que usted especificó");
            comandosEmprendedor.Append("\n/buscartag - Use para buscar entre todas aquellas ofertas que tienen el tag que usted especificó");
            comandosEmprendedor.Append("\n/buscarubicacion - Use para buscar entre todas aquellas ofertas que tienen la ubicación que usted especificó");
            comandosEmprendedor.Append("\n/calcularofertasconsumidas - Use para conocer en cuantas ofertas se interesaron en un determinado período de tiempo");
            comandosEmprendedor.Append("\n/listadehabilitaciones - Para emprendedores que quieren ver la lista de habilitaciones que existen");
            comandosEmprendedor.Append("\n/interesarme - Use para interesarse en una oferta");
            comandosEmprendedor.Append("\n/verubicacion - Use para conocer la ubicacion de emprendedor");
            comandosEmprendedor.Append("\n/ubicacionoferta - Use para conocer la ubicacion de emprendedor");

            if (mensaje == null)
            {
                throw new ArgumentNullException("Message no puede ser nulo.");
            }

            if (this.CanHandle(mensaje))
            {
                if (Singleton<ContenedorPrincipal>.Instancia.Empresas.ContainsKey(mensaje.Id))
                {
                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].MensajesDelUser.Add(mensaje.Text);
                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                    respuesta = comandosEmpresa.ToString();
                    return true;
                }
                else
                {
                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].MensajesDelUser.Add(mensaje.Text);
                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                    respuesta = comandosEmprendedor.ToString();
                    return true;
                }   
            }
            
            respuesta = string.Empty;
            return false;
        }
    }
}