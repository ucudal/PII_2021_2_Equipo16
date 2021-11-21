using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class InteresadoEnOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="next">El próximo "handler"</param>
        public InteresadoEnOfertaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/Interesado"};
        }
        /// <summary>
        /// Este método procesa el mensaje "!InteresadoEnOferta" y retorna true.
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
                    if ((mensaje.Text.StartsWith("/") == false) && (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/Interesado") == true))
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

            if (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/Interesado") == true)
            {
                List<string> listaConParametros = Logica.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/Interesado");
                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese el nombre de la oferta en la que quiera manifestar su interés";
                    return true;
                }
                if (listaConParametros.Count == 1)
                {
                    string nombreOferta = listaConParametros[0];

                    if (Logica.Emprendedores.ContainsKey(mensaje.Id))
                    {
                        Emprendedor value = Logica.Emprendedores[mensaje.Id];
                        LogicaEmprendedor.InteresadoEnOferta(value, nombreOferta);
                        respuesta = $"Se ha manifestado su interés en {nombreOferta} de manera exitosa";
                        return true;
                    }
                }
                else
                {
                    respuesta = "No ha podido manifestar su interés de manera exitosa, por favor intente nuevamente";
                    return true;
                }
            }
            
            respuesta = string.Empty;
            return false;
        }
    }
}
