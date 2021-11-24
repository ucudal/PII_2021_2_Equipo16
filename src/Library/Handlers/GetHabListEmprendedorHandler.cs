using System.Collections.Generic;
using System;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class GetHabListEmprendedorHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public GetHabListEmprendedorHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/listadehabilitacionesemprendedor"};
        }

        /// <summary>
        /// Procesa el mensaje "Lista de habilitaciones" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/listadehabilitacionesemprendedor"))
            {
                respuesta = string.Empty;
                return false;
            }

            if (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/listadehabilitacionesemprendedor") == true)
            {
                List<string> listaConParametros = Logica.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/listadehabilitacionesemprendedor");
                
                if (Logica.Emprendedores.ContainsKey(mensaje.Id))
                {
                    Emprendedor value = Logica.Emprendedores[mensaje.Id];
                    // Utiliza el metodo de la clase LogicaEmprendedor para obtener la lista de habilitaciones que tiene el Emprendedor en cuestion.
                    string hab = LogicaEmprendedor.GetHabilitacionList(value);
                    respuesta = $"La lista de habilitaciones es \n{hab}";
                    return true;
                }
                else
                {
                    // En caso de que el Emprendedor no contenga habilitaciones relacionadas.
                    respuesta = "No se ha podido obtener las habilitaciones"+OpcionesUso.AccionesEmprendedor();
                    return true;
                }
            }
            
            respuesta = string.Empty;
            return false;
        }
    }
} 
