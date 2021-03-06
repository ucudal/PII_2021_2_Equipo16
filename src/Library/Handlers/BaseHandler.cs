using System;
using System.Linq;

namespace ClassLibrary
{
    /// <summary>
    /// Clase base para implementar el patrón Chain of Responsibility. En ese patrón se pasa un mensaje a través de una
    /// cadena de "handlers" que pueden procesar o no el mensaje. Cada "handler" decide si procesa el mensaje, o si se lo
    /// pasa al siguiente. Esta clase base implmementa la responsabilidad de recibir el mensaje y pasarlo al siguiente
    /// "handler" en caso que el mensaje no sea procesado. La responsabilidad de decidir si el mensaje se procesa o no, y
    /// de procesarlo, se delega a las clases sucesoras de esta clase base.
    /// </summary>
    public abstract class BaseHandler : IHandler
    {
        /// <summary>
        /// Obtiene o establece el próximo "handler".
        /// </summary>
        /// <value>El "handler" que será invocado si este "handler" no procesa el mensaje.</value>
        public IHandler Next { get; set; }

        /// <summary>
        /// Obtiene o asigna el conjunto de palabras clave que este "handler" puede procesar.
        /// </summary>
        /// <value>Un array de palabras clave.</value>
        public string[] Keywords { get; set; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/>.
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public BaseHandler(IHandler next)
        {
            this.Next = next;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BaseHandler"/> con una lista de comandos.
        /// </summary>
        /// <param name="keywords">La lista de comandos.</param>
        /// <param name="next">El próximo "handler".</param>
        public BaseHandler(string[] keywords, IHandler next)
        {
            this.Keywords = keywords;
            this.Next = next;
        }

        /// <summary>
        /// Este método debe ser sobreescrito por las clases sucesores. La clase sucesora procesa el mensaje y retorna
        /// true o no lo procesa y retorna false.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario</returns>
        protected virtual bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            throw new InvalidOperationException("Este método debe ser sobrescrito.");
        }

        /// <summary>
        /// Este método puede ser sobreescrito en las clases sucesores que procesan varios mensajes cambiando de estado
        /// entre mensajes deben sobreescribir este método para volver al estado inicial. En la clase base no hace nada.
        /// </summary>
        protected virtual void InternalCancel()
        {
            // Intencionalmente en blanco.
        }

        /// <summary>
        /// Determina si este "handler" puede procesar el mensaje. En la clase base se utiliza el array
        /// <see cref="BaseHandler.Keywords"/> para buscar el texto en el mensaje ignorando mayúsculas y minúsculas. Las
        /// clases sucesores pueden sobreescribir este método para proveer otro mecanismo para determina si procesan o no
        /// un mensaje.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <returns>true si el mensaje puede ser pocesado; false en caso contrario.</returns>
        protected virtual bool CanHandle(IMensaje message)
        {
            // Cuando no hay palabras clave este método debe ser sobreescrito por las clases sucesoras y por lo tanto
            // este método no debería haberse invocado.
            if (this.Keywords == null || this.Keywords.Length == 0)
            {
                throw new InvalidOperationException("No hay palabras clave que puedan ser procesadas");
            }

            return this.Keywords.Any(s => message.Text.Equals(s, StringComparison.InvariantCultureIgnoreCase));
        }

        /// <summary>
        /// Procesa el mensaje o la pasa al siguiente "handler" si existe.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>El "handler" que procesó el mensaje si el mensaje fue procesado; null en caso contrario.</returns>
        public IHandler Handle(IMensaje mensaje, out string respuesta)
        {
            if (this.InternalHandle(mensaje, out respuesta))
            {
                return this;
            }
            else if (this.Next != null)
            {
                return this.Next.Handle(mensaje, out respuesta);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Retorna este "handler" al estado inicial. En los "handler" sin estado no hace nada. Los "handlers" que
        /// procesan varios mensajes cambiando de estado entre mensajes deben sobreescribir este método para volver al
        /// estado inicial.
        /// </summary>
        public virtual void Cancel()
        {
            this.InternalCancel();
            if (this.Next != null)
            {
                this.Next.Cancel();
            }
        }

        /// <summary>
        /// Se encarga de verificar si se ingresa un comando que corresponda al handler, o si ingresa un mensaje/parametro que corresponda al handler.
        /// Al hacer este método, se puede reutilizar bastante código.
        /// Si el HistorialDeChats, no contiene el mensaje.Id, retorna true de todas formas ya que en los handlers, siempre se trabaja con mensaje.Id,
        /// y si no existe, siempre el handler retornará false y un out string response string.Empty, ya que los handlers son los responsables de encargarse.
        /// </summary>
        /// <param name="mensaje">Mensaje.</param>
        /// <param name="comando">Comando.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        public virtual bool ChequearHandler(IMensaje mensaje, string comando)
        {
            if (mensaje == null)
            {
                throw new ArgumentNullException("Message no puede ser nulo.");
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats.ContainsKey(mensaje.Id))
            {
                if (this.CanHandle(mensaje))
                {
                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].MensajesDelUser.Add(mensaje.Text); 
                }
                else
                {
                    if (!mensaje.Text.StartsWith("/") && Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado(comando))
                    {
                        Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].MensajesDelUser.Add(mensaje.Text); 
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}