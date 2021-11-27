using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "hola".
    /// </summary>
    public class AddHabEmprendedorHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="next"></param>
        public AddHabEmprendedorHandler(BaseHandler next):base(next)
        {
            this.Keywords = new string[] {"/agregarhabilitacionemprendedor"};
        }

        /// <summary>
        /// Este método procesa el mensaje "Agregar habilitación" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns></returns>
        protected override bool InternalHandle(IMensaje message, out string response)
        {
            if (!this.ChequearHandler(message, "/agregarhabilitacionemprendedor"))
            {
                response = string.Empty;
                return false;
            }

            if (ContenedorPrincipal.Instancia.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("/agregarhabilitacionemprendedor") == true)
            {
                List<string> listaConParametros = ContenedorPrincipal.Instancia.HistorialDeChats[message.Id].BuscarUltimoComando("/agregarhabilitacionemprendedor");
                
                if (listaConParametros.Count == 0)
                {
                    response = $"Ingrese la habilitación que desea agregar.\n{ContenedorRubroHabilitaciones.Instancia.textoListaHabilitaciones()}";
                    return true;
                }
                if (listaConParametros.Count == 1)
                {
                    string nuevaHab = listaConParametros[0];
                    if (ContenedorPrincipal.Instancia.Emprendedores.ContainsKey(message.Id))
                    {
                        Emprendedor value = ContenedorPrincipal.Instancia.Emprendedores[message.Id];
                        try
                        {
                            LogicaEmprendedor.AddHabilitacion(value,nuevaHab);
                        }
                        catch (System.ArgumentException e)
                        {
                            
                            response = e.Message;
                            return true;
                        }
                        response = $"Se ha agregado '{nuevaHab}' a la lista de habilitaciones. {OpcionesUso.AccionesEmprendedor()}";
                        return true;
                    }
                    else
                    {
                        response = $"Usted no es un emprendedor, no puede usar este comando.";
                        return true;
                    }
                }
            }
            
            response = string.Empty;
            return false;
        }
    }
}