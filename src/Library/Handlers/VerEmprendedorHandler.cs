using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "hola".
    /// </summary>
    public class VerEmprendedorHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="next"></param>
        public VerEmprendedorHandler(BaseHandler next):base(next)
        {
            this.Keywords = new string[] {"/veremprendedor"};
        }

        /// <summary>
        /// Este método procesa el mensaje "/VerEmprendedor" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns></returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (Logica.HistorialDeChats.ContainsKey(mensaje.Id))
            {
                if (this.CanHandle(mensaje))
                {
                    Logica.HistorialDeChats[mensaje.Id].MensajesDelUser.Add(mensaje.Text); 
                }
                else
                {
                    if ((mensaje.Text.StartsWith("/") == false) && (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/veremprendedor") == true))
                    {
                        Logica.HistorialDeChats[mensaje.Id].MensajesDelUser.Add(mensaje.Text); 
                    }
                    else
                    {
                        respuesta = string.Empty;
                        return false;
                    }
                }
            }

            if (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/veremprendedor") == true)
            {
                List<string> listaConParametros = Logica.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/veremprendedor");
                if (Logica.Emprendedores.ContainsKey(mensaje.Id))
                {
                    Emprendedor value = Logica.Emprendedores[mensaje.Id];
                    respuesta = $"La información del emprendedor es la siguiente : {LogicaEmprendedor.VerEmprendedor(value)} {OpcionesUso.AccionesEmprendedor()}";
                }
            }
            
            respuesta = string.Empty;
            return false;
        }
    }
}