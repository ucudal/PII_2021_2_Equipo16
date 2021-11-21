using System;
using System.Collections.Generic;
using Telegram.Bot.Types;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase contiene un método para remover habilitaciones de empresas.
    /// </summary>
    public class RemoveHabEmpresaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public RemoveHabEmpresaHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"!RemoverHab"};
        }
        
        /// <summary>
        /// Se encarga de procesar el mensaje para determinar si se removerá una habilitación.
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respusta al mensaje procesado.</param>
        /// <returns></returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (Logica.HistorialDeChats.ContainsKey(mensaje.Id))
            {
                if (this.CanHandle(mensaje))
                {
                    Console.WriteLine("EntreRemoveHabEmpresa");
                    Logica.HistorialDeChats[mensaje.Id].MensajesDelUser.Add(mensaje.Text); 
                }
                else
                {
                    if ((mensaje.Text.StartsWith("!") == false) && Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("!RemoverHab") == true)
                    {
                        Console.WriteLine("EntreRemoveHabEmpresa");
                        Logica.HistorialDeChats[mensaje.Id].MensajesDelUser.Add(mensaje.Text); 
                    }
                    else
                    {
                        respuesta = string.Empty;
                        return false;
                    }
                }
            }
            
            if (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("!RemoverHab") == true)
            {
                // El mensaje debe tener el formato "Remover habilitacion, Nombre de habilitación".
                List<string> listaComandos = Logica.HistorialDeChats[mensaje.Id].BuscarUltimoComando("!RemoverHab");
                if (listaComandos.Count == 0)
                {
                    respuesta = $"Ingrese el nombre de la habilitación a eliminar {listaComandos.Count}.";
                    return true;
                }
                
                if (listaComandos.Count == 1)
                {
                    string habilitacion = listaComandos[0];
                    if (Logica.Empresas.ContainsKey(mensaje.Id))
                    {
                        Empresa value = Logica.Empresas[mensaje.Id];
                        LogicaEmpresa.RemoveHabilitacion(value, habilitacion);
                        
                        respuesta = $"Se ha removido la habilitación {habilitacion} con éxito.";
                    }
                    else
                    {
                        respuesta = "No se ha podido remover la habilitación, usted no está registrado como Empresa.";
                    }
                    return true;
                }
                else
                {
                    foreach (string item in listaComandos)
                    {
                        Console.WriteLine(item);
                    }
                    respuesta = $"Listaconparam es {listaComandos.Count}";
                    return true;
                }
            }
            
            respuesta = string.Empty;
            return false;
        }
    }
}