using System.Collections.Generic;
using Telegram.Bot.Types;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class CrearOfertaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CrearOfertaHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"!CrearOferta"};
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        protected override bool InternalHandle(IMensaje message, out string response)
        {
            if (Logica.HistorialDeChats.ContainsKey(message.Id))
            {
                if (this.CanHandle(message))
                {
                    //Console.WriteLine("Entre");
                    Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                }
                else
                {
                    if ((message.Text.StartsWith("!") == false) && (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!CrearOferta") == true))
                    {
                        //Console.WriteLine("Entre22");
                        Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                    }
                    else
                    {
                        response = string.Empty;
                        return false;
                    }
                }
            }

            if (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("!CrearOferta") == true)
            {
                List<string> listaConParam = Logica.HistorialDeChats[message.Id].BuscarUltimoComando("!CrearOferta");
                if (listaConParam.Count == 0)
                {
                    response = "ingrese el nombre de la oferta";
                    return true;
                }
                if (listaConParam.Count == 1)
                {
                    response = "ingrese el material";
                    return true;
                }
                if (listaConParam.Count == 2)
                {
                    response = "ingrese el precio";
                    return true;
                }
                if (listaConParam.Count == 3)
                {
                    response = "ingrese unidad";
                    return true;
                }
                 if (listaConParam.Count == 4)
                {
                    response = "ingrese tag";
                    return true;
                }
                 if (listaConParam.Count == 5)
                {
                    response = "ingrese ubicación";
                    return true;
                }
                 if (listaConParam.Count == 6)
                {
                    response = "ingrese si es puntual o constante";
                    return true;
                }
                if (listaConParam.Count == 7)
                {
                    string puntualConstante = listaConParam[6];
                    string ubicacionOferta = listaConParam[5];
                    string tagOferta = listaConParam[4];
                    string unidadesOferta = listaConParam[3];
                    string precioOferta = listaConParam[2];
                    string materialOferta = listaConParam[1];
                    string nombreOferta = listaConParam[0];
                    if (Logica.Empresas.ContainsKey(message.Id))
                {
                    Empresa value = Logica.Empresas[message.Id];
                    LogicaEmpresa.CrearOferta(value, nombreOferta,materialOferta, precioOferta, unidadesOferta, tagOferta, ubicacionOferta, puntualConstante);
                    response = $"Se ha registrado con nombre {nombreOferta}, de material {materialOferta},del tipo {puntualConstante}, unidades: {unidadesOferta}, al precio de : {precioOferta}, con la ubicación en {ubicacionOferta} y los tags {tagOferta}. ";
                    return true;
                }
                else
                {
                    response = "No se ha podido registrar la oferta";
                    return true;
                }
            }

            response = string.Empty;
            return false;
        }
    }
}

