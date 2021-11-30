using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/crearhaboferta" y se encarga
    /// de manejar el caso en que una Empresa quiera crear una nueva habilitación de oferta.
    /// </summary>
    public class AgregarHabOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="AgregarHabOfertaHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public AgregarHabOfertaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/addhaboferta" };
        }

        /// <summary>
        /// Procesa el mensaje para que una Empresa pueda crear una nueva habilitación de oferta.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/addhaboferta"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.Empresas.ContainsKey(mensaje.Id))
            {
                // El mensaje debe tener el formato "Remover habilitacion de oferta,nombre de la oferta,habilitacion"
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/addhaboferta");

                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese el nombre de la oferta a la que desea agregar una habilitación.";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    respuesta = $"Ingrese el nombre de la habilitación que desea agregar.\n{Singleton<ContenedorPrincipal>.Instancia.ContenedorRubrosHabs.textoListaHabilitaciones()}";
                    return true;
                }
                else if (listaConParametros.Count == 2)
                {
                    string nombreOferta = listaConParametros[1];
                    string nombreHabParaAgregar = listaConParametros[0];

                    Empresa value = Singleton<ContenedorPrincipal>.Instancia.Empresas[mensaje.Id];
                    try
                    {
                        LogicaEmpresa.AgregarHabilitacionOferta(value, nombreHabParaAgregar, nombreOferta);
                    }
                    catch (System.ArgumentException e)
                    {
                        respuesta = e.Message;
                        return true;
                    }

                    Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                    respuesta = $"Se ha agregado la habilitacion {nombreHabParaAgregar} de la oferta {nombreOferta}. {OpcionesUso.AccionesEmpresas()}";
                    return true;

                }      
            }
            else
            {
                respuesta = $"Usted no es una empresa, no tiene permisos para usar este comando.";
                return true;
            }

            respuesta = string.Empty;
            return false;
        }
    }
}