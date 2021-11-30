using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/interesarme" y se encarga
    /// de manejar el caso en que haya un interesado en una oferta.
    /// </summary>
    public class InteresadoEnOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="InteresadoEnOfertaHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public InteresadoEnOfertaHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/interesarme" };
        }
        
        /// <summary>
        /// Procesa el mensaje para que un emprendedor se pueda interesar en una oferta.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/interesarme"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.Emprendedores.ContainsKey(mensaje.Id))
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/interesarme");
                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese el nombre de la oferta en la que quiera manifestar su interés";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    string nombreOferta = listaConParametros[0];

                    Emprendedor value = Singleton<ContenedorPrincipal>.Instancia.Emprendedores[mensaje.Id];
                    LogicaEmprendedor.InteresadoEnOferta(value, nombreOferta);
                    respuesta = $"Se ha manifestado su interés en {nombreOferta} de manera exitosa.";
                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                    return true;
                }
                else
                {
                    respuesta = $"No ha podido manifestar su interés de manera exitosa, por favor intente nuevamente. {OpcionesUso.AccionesEmprendedor()}";
                    return true;
                }
            }
            else
            {
                respuesta = $"Usted no es un emprendedor, no puede usar este comando.";
                return true;
            }
        }
    }
}