using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/agregarhabilitacion" y se encarga
    /// de manejar el caso en que el Administrador agrega una habilitación.
    /// </summary>
    public class AgregarHabilitacionHandler: BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AgregarHabilitacionHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public AgregarHabilitacionHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/agregarhabilitacion" };
        }

        /// <summary>
        /// Procesa el mensaje que determina si el Administrador agregó o no una habilitación.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/agregarhabilitacion"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.Administradores.ContainsKey(mensaje.Id))
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/agregarhabilitacion");

                if (listaConParametros.Count == 0)
                {
                    respuesta = $"Ingrese la habilitación que desea agregar.";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    string nuevaHab = listaConParametros[0];

                    Administrador value = Singleton<ContenedorPrincipal>.Instancia.Administradores[mensaje.Id];
                    LogicaAdministrador.AgregarHabilitacion(value,nuevaHab);

                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                    respuesta = $"Se ha agregado '{nuevaHab}'.";
                    return true;   
                }
            }
            else
            {
                respuesta = $"Usted no es un administrador, no puede utilizar este comando.";
                return true;
            }

            respuesta = string.Empty;
            return false;
        }
    }
}