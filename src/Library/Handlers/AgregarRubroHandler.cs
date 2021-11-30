using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "hola".
    /// </summary>
    public class AgregarRubroHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="next"></param>
        public AgregarRubroHandler(BaseHandler next):base(next)
        {
            this.Keywords = new string[] {"/agregarrubro"};
        }

        /// <summary>
        /// Este método procesa el mensaje "Agregar habilitación" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
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
                    LogicaAdministrador.AgregarRubro(value,nuevoRubro);
                    
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