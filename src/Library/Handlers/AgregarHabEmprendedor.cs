using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/agregarhabilitacionemprendedor" y se encarga
    /// de manejar el caso en que un Emprendedor agrega una habilitación.
    /// </summary>
    public class AgregarHabEmprendedorHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AgregarHabEmprendedorHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public AgregarHabEmprendedorHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/agregarhabilitacionemprendedor" };
        }

        /// <summary>
        /// Procesa el mensaje que determina si el Emprendedor agregó o no una habilitación.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/agregarhabilitacionemprendedor"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.Emprendedores.ContainsKey(mensaje.Id))
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/agregarhabilitacionemprendedor");
                
                if (listaConParametros.Count == 0)
                {
                    respuesta = $"Ingrese la habilitación que desea agregar.\n{Singleton<ContenedorPrincipal>.Instancia.ContenedorRubrosHabs.textoListaHabilitaciones()}";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    string nuevaHab = listaConParametros[0];

                    Emprendedor value = Singleton<ContenedorPrincipal>.Instancia.Emprendedores[mensaje.Id];
                    try
                    {
                        LogicaEmprendedor.AddHabilitacion(value,nuevaHab);
                    }
                    catch (System.ArgumentException e)
                    {
                        respuesta = e.Message;
                        return true;
                    }
                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                    respuesta = $"Se ha agregado '{nuevaHab}' a la lista de habilitaciones. {OpcionesUso.AccionesEmprendedor()}";
                    return true;  
                }    
            }
            else
            {
                respuesta = $"Usted no es un emprendedor, no puede usar este comando.";
                return true;
            }

            respuesta = string.Empty;
            return false;
        }
    }
}