using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class RemoverHabEmprendedor : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RemoverHabEmprendedor (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/removerhabemprendedor"};
        }

        /// <summary>
        /// Procesa el mensaje "Registrarse" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
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
                    if ((mensaje.Text.StartsWith("/") == false) && Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/removerhabemprendedor") == true)
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

            if (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/removerhabemprendedor") == true)
            {
                List<string> listaConParametros = Logica.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/removerhabemprendedor");
                if (listaConParametros.Count == 0)
                {
                    respuesta = $"Ingrese el nombre de la habilitación que desea eliminar {listaConParametros.Count}.";
                    return true;
                }
                if (listaConParametros.Count == 1)
                {
                    string habilitacion = listaConParametros[0];
                    if (Logica.Emprendedores.ContainsKey(mensaje.Id))
                    {
                        Emprendedor value = Logica.Emprendedores[mensaje.Id];
                        LogicaEmprendedor.RemoveHabilitacion(value, habilitacion);
                        
                        respuesta = $"Se ha removido la habilitación {habilitacion} con éxito. {OpcionesUso.AccionesEmprendedor()} ";
                        return true;
                    }
                    else
                    {
                        respuesta = $"Usted no está registrado como Emprendedor. {OpcionesUso.AccionesEmprendedor()}";
                        return true;
                    }

                }
                else
                {
                    respuesta = $"Algo fue mal. {OpcionesUso.AccionesEmprendedor()}";
                    return true;
                } 
            }
            
            respuesta = string.Empty;
            return false;
        }
    }
}