using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/removerhabemprendedor" y se encarga
    /// de manejar el caso en que un Emprendedor quiera remover una habilitación.
    /// </summary>
    public class RemoverHabEmprendedor : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RemoverHabEmprendedor"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public RemoverHabEmprendedor(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/removerhabemprendedor" };
        }

        /// <summary>
        /// Procesa el mensaje para que un Emprendedor pueda remover una habilitación.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/removerhabemprendedor"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.Emprendedores.ContainsKey(mensaje.Id))
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/removerhabemprendedor");
                if (listaConParametros.Count == 0)
                {
                    respuesta = $"Ingrese el nombre de la habilitación que desea eliminar.";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    string habilitacion = listaConParametros[0];

                    Emprendedor value = Singleton<ContenedorPrincipal>.Instancia.Emprendedores[mensaje.Id];
                    LogicaEmprendedor.RemoveHabilitacion(value, habilitacion);
                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();

                    respuesta = $"Se ha removido la habilitación {habilitacion} con éxito. {OpcionesUso.AccionesEmprendedor()} ";
                    return true; 
                }
                else
                {
                    respuesta = $"Algo fue mal. {OpcionesUso.AccionesEmprendedor()}";
                    return true;
                } 
            }
            else
            {
                respuesta = $"Usted no está registrado como Emprendedor. {OpcionesUso.AccionesEmprendedor()}";
                return true;
            }
        }
    }
}