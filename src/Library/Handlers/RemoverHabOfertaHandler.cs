using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class RemoverHabOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RemoverHabOfertaHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/removerhaboferta"};
        }

        /// <summary>
        /// Procesa el mensaje "Registrarse" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            
            if (!this.ChequearHandler(mensaje, "/removerhaboferta"))
            {
                respuesta = string.Empty;
                return false;
            }

            if (Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/removerhaboferta") == true)
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/removerhaboferta");

                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese el nombre de la oferta a la que desea eliminar una habilitacion";
                    return true;
                }
                if (listaConParametros.Count == 1)
                {
                    respuesta = "ingrese el nombre de la habilitacion que desea remover";
                    return true;
                }
                if (listaConParametros.Count == 2)
                {
                    string nombreOferta = listaConParametros[1];
                    string nombreHabParaEliminar = listaConParametros[0];

                    if (Singleton<ContenedorPrincipal>.Instancia.Empresas.ContainsKey(mensaje.Id))
                    {
                        Empresa value = Singleton<ContenedorPrincipal>.Instancia.Empresas[mensaje.Id];
                        LogicaEmpresa.RemoveHabilitacionOferta(value, nombreHabParaEliminar, nombreOferta);
                        
                        respuesta = $"Se ha removido la habilitacion {nombreHabParaEliminar} de la oferta {nombreOferta}. {OpcionesUso.AccionesEmpresas()}";
                        return true;
                    }
                    else
                    {
                        respuesta = $"Usted no es una empresa, no puede usar este comando.";
                        return true;
                    }
                }
            }

            respuesta = string.Empty;
            return false;
        }
    }
}
