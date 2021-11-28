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
        /// <param name="next">Recibe por parametro el siguiente Handler.</param>
        public AddHabEmprendedorHandler(BaseHandler next):base(next)
        {
            this.Keywords = new string[] {"/agregarhabilitacionemprendedor"};
        }

        /// <summary>
        /// Este método procesa el mensaje "Agregar habilitación" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por parametro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/agregarhabilitacionemprendedor"))
            {
                respuesta = string.Empty;
                return false;
            }

            if (Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/agregarhabilitacionemprendedor") == true)
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/agregarhabilitacionemprendedor");
                
                if (listaConParametros.Count == 0)
                {
                    respuesta = $"Ingrese la habilitación que desea agregar.\n{Singleton<ContenedorRubroHabilitaciones>.Instancia.textoListaHabilitaciones()}";
                    return true;
                }
                if (listaConParametros.Count == 1)
                {
                    string nuevaHab = listaConParametros[0];
                    if (Singleton<ContenedorPrincipal>.Instancia.Emprendedores.ContainsKey(mensaje.Id))
                    {
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
                        respuesta = $"Se ha agregado '{nuevaHab}' a la lista de habilitaciones. {OpcionesUso.AccionesEmprendedor()}";
                        return true;
                    }
                    else
                    {
                        respuesta = $"Usted no es un emprendedor, no puede usar este comando.";
                        return true;
                    }
                }
            }
            
            respuesta = string.Empty;
            return false;
        }
    }
}