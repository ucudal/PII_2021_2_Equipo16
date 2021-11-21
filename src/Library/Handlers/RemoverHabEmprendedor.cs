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
            this.Keywords = new string[] {"!RemoverHabEmprendedor"};
        }

        /// <summary>
        /// Procesa el mensaje "Registrarse" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje message, out string response)
        {
            if (Logica.HistorialDeChats.ContainsKey(message.Id))
            {
                if (this.CanHandle(message))
                {
                    Console.WriteLine("EntreRemoveHabEmprendedor");
                    Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                }
                else
                {
                    if ((message.Text.StartsWith("!") == false) && Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!RemoverHabEmprendedor") == true)
                    {
                        Console.WriteLine("EntreRemoveHabEMprendedor");
                        Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                    }
                    else
                    {
                        response = string.Empty;
                        return false;
                    }
                }
            }
            
            
            
            

            if (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!RemoverHabEmprendedor") == true)
            {
                Console.WriteLine("XDXD");
                // El mensaje debe tener el formato "Remover habilitacion, x"
                List<string> listaConParam = Logica.HistorialDeChats[message.Id].BuscarUltimoComando("!RemoverHabEmprendedor");
                if (listaConParam.Count == 0)
                {
                    response = $"ingrese el nombre de la habilitacion a eliminar {listaConParam.Count}";
                    return true;
                    //prueba = $"params in lista {listaConParam.Count}";
                    //Console.WriteLine(prueba);
                }
                if (listaConParam.Count == 1)
                {
                    Console.WriteLine("Entro aca0");
                    string habilitacion = listaConParam[0];
                    if (Logica.Emprendedores.ContainsKey(message.Id))
                    {
                        //Console.WriteLine("Entro aca111");
                        Emprendedor value = Logica.Emprendedores[message.Id];
                        LogicaEmprendedor.RemoveHabilitacion(value, habilitacion);
                        
                        response = $"Se ha removido la habilitacion {habilitacion}.";
                        return true;
                    }
                    else
                    {
                        response = "Usted no está registrado como Emprendedor";
                        return true;
                    }

                }
                else
                {
                    foreach (string item in listaConParam)
                    {
                        Console.WriteLine(item);
                    }
                    response = $"Listaconparam es {listaConParam.Count}";
                    return true;
                }

                
                
            }
            response = string.Empty;
            return false;
        }
    }
}