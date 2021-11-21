using System.Collections.Generic;

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
            this.Keywords = new string[] {"/crearoferta"};
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
                    Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                }
                else
                {
                    if ((message.Text.StartsWith("/") == false) && (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("/crearoferta") == true))
                    {
                        Logica.HistorialDeChats[message.Id].MensajesDelUser.Add(message.Text); 
                    }
                    else
                    {
                        response = string.Empty;
                        return false;
                    }
                }
            }

            if (Logica.HistorialDeChats[message.Id].ComprobarUltimoComandoIngresado("/crearoferta") == true)
            {
                List<string> listaConParam = Logica.HistorialDeChats[message.Id].BuscarUltimoComando("/crearoferta");
                if (listaConParam.Count == 0)
                {
                    response = "Ingrese el nombre de la oferta";
                    return true;
                }
                else if (listaConParam.Count == 1)
                {
                    response = "Ingrese el material";
                    return true;
                }
                else if (listaConParam.Count == 2)
                {
                    response = "Ingrese el precio";
                    return true;
                }
                else if (listaConParam.Count == 3)
                {
                    response = "Ingrese unidad";
                    return true;
                }
                else if (listaConParam.Count == 4)
                {
                    response = "Ingrese un tag";
                    return true;
                }
                else if (listaConParam.Count == 5)
                {
                    response = "Ingrese una ubicación";
                    return true;
                }
                else if (listaConParam.Count == 6)
                {
                    response = "Elija si es una oferta puntual o constante";
                    return true;
                }
                else if (listaConParam.Count == 7)
                {
                    string puntualConstante = listaConParam[0];
                    string ubicacionOferta = listaConParam[1];
                    string tagOferta = listaConParam[2];
                    string unidadesOferta = listaConParam[3];
                    string precioOferta = listaConParam[4];
                    string materialOferta = listaConParam[5];
                    string nombreOferta = listaConParam[6];
                    if (Logica.Empresas.ContainsKey(message.Id))
                    {
                        Empresa value = Logica.Empresas[message.Id];
                        LogicaEmpresa.CrearOferta(value, nombreOferta, materialOferta, precioOferta, unidadesOferta, tagOferta, ubicacionOferta, puntualConstante);
                        response = $"Se ha registrado con nombre {nombreOferta}, de material {materialOferta}, del tipo {puntualConstante}, unidades: {unidadesOferta}, al precio de: {precioOferta}, con la ubicación en {ubicacionOferta} y los tags {tagOferta}.";
                        return true;
                    }
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