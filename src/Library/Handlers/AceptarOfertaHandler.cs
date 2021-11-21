using System;
using System.Collections.Generic;
using Telegram.Bot.Types;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase contiene un método para aceptar una oferta.
    /// </summary>
    public class AceptarOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Este método se encarga de aceptar una oferta.
        /// </summary>
        /// <param name="next"></param>
        public AceptarOfertaHandler (BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"!AceptarOferta"};
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensaje">El mensaje a procesar.</param>
        /// <param name="respuesta">La respusta al mensaje procesado.</param>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (Logica.HistorialDeChats.ContainsKey(mensaje.Id))
            {
                if (this.CanHandle(mensaje))
                {
                    Console.WriteLine("EntreAceptarOferta");
                    Logica.HistorialDeChats[mensaje.Id].MensajesDelUser.Add(mensaje.Text); 
                }
                else
                {
                    if ((mensaje.Text.StartsWith("!") == false) && Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("!AceptarOferta") == true)
                    {
                        Console.WriteLine("EntreAceptarOferta");
                        Logica.HistorialDeChats[mensaje.Id].MensajesDelUser.Add(mensaje.Text); 
                    }
                    else
                    {
                        respuesta = string.Empty;
                        return false;
                    }
                }
            }
            
            if (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("!AceptarOferta") == true)
            {
                List<string> listaComandos = Logica.HistorialDeChats[mensaje.Id].BuscarUltimoComando("!AceptarOferta");
                if (listaComandos.Count == 0)
                {
                    respuesta = $"Ingrese el Nombre de la oferta que desee aceptar {listaComandos.Count}.";
                    return true;
                }
                
                if (listaComandos.Count == 1)
                {
                    string nombreOfertaParaAceptar = listaComandos[0];

                    if (Logica.Empresas.ContainsKey(mensaje.Id))
                    {
                        Empresa value = Logica.Empresas[mensaje.Id];
                        LogicaEmpresa.AceptarOferta(value, nombreOfertaParaAceptar);
                        
                        respuesta = $"Se ha aceptado la oferta {nombreOfertaParaAceptar} con éxito.";
                    }
                    else
                    {
                        respuesta = "No se ha podido aceptar la oferta, usted no está registrado como Empresa.";
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
