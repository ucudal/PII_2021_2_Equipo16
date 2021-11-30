using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class AddHabOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">Recibe por parametro el siguiente Handler.</param>
        public AddHabOfertaHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/addhaboferta"};
        }

        /// <summary>
        /// Procesa el mensaje "Registrarse" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
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
                        LogicaEmpresa.AddHabilitacionOferta(value, nombreHabParaAgregar, nombreOferta);
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