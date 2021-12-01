using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/agregarhabilitacionempresa" y se encarga
    /// de manejar el caso en que una Empresa agrega una habilitación.
    /// </summary>
    public class AgregarHabEmpresaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AgregarHabEmpresaHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public AgregarHabEmpresaHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/agregarhabilitacionempresa" };
        }

        /// <summary>
        /// Procesa el mensaje que determina si la Empresa agregó o no una habilitación.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/agregarhabilitacionempresa"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.Empresas.ContainsKey(mensaje.Id))
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/agregarhabilitacionempresa");
                if (listaConParametros.Count == 0)
                {
                    respuesta = $"Ingrese la habilitación que desea agregar.\n{Singleton<ContenedorPrincipal>.Instancia.ContenedorRubrosHabs.TextoListaHabilitaciones()}";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    string nuevaHab = listaConParametros[0];
                    
                    Empresa value = Singleton<ContenedorPrincipal>.Instancia.Empresas[mensaje.Id];
                    try
                    {
                        LogicaEmpresa.AddHabilitacion(value,nuevaHab);
                    }
                    catch (System.ArgumentException e)
                    {
                        respuesta = e.Message;
                        return true;
                    }

                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                    respuesta = $"Se ha agregado '{nuevaHab}' a la lista de habilitaciones. {OpcionesUso.AccionesEmpresas()}";
                    return true;   
                }
            }
            else
            {
                respuesta = $"Usted no es una empresa, no puede utilizar este comando.";
                return true;
            }

            respuesta = string.Empty;
            return false;
        }
    }
}