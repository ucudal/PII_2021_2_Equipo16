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
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/listadehabilitacionesemprendedor"))
            {
                respuesta = string.Empty;
                return false;
            }

            if (Singleton<Logica>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/listadehabilitacionesemprendedor") == true)
            {
                List<string> listaConParametros = Singleton<Logica>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/listadehabilitacionesemprendedor");
                
                if (Singleton<Logica>.Instancia.Emprendedores.ContainsKey(mensaje.Id))
                {
                    Emprendedor value = Singleton<Logica>.Instancia.Emprendedores[mensaje.Id];
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
