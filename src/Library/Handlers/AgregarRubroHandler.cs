using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/agregarrubro" y se encarga
    /// de manejar el caso en que el Administrador agrega un Rubro.
    /// </summary>
    public class AgregarRubroHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AgregarRubroHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public AgregarRubroHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/agregarrubro" };
        }

        /// <summary>
        /// Procesa el mensaje que determina si el Administrador agregó o no un Rubro.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/agregarrubro"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.Administradores.ContainsKey(mensaje.Id))
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/agregarrubro");
                if (listaConParametros.Count == 0)
                {
                    respuesta = $"Ingrese el rubro que desea agregar.";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    string nuevoRubro = listaConParametros[0];
                    Administrador value = Singleton<ContenedorPrincipal>.Instancia.Administradores[mensaje.Id];
                    LogicaAdministrador.AgregarRubro(value, nuevoRubro);
                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                    respuesta = $"Se ha agregado '{nuevoRubro}'.";
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