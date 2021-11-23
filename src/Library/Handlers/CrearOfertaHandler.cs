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
        /// <param name="mensaje"></param>
        /// <param name="respuesta"></param>
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
                    if ((mensaje.Text.StartsWith("/") == false) && (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/crearoferta") == true))
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

            if (Logica.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/crearoferta") == true)
            {
                List<string> listaConParametros = Logica.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/crearoferta");
                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese el nombre de la oferta";
                    return true;
                }
                else if (listaConParametros.Count == 1)
                {
                    respuesta = "Ingrese el material";
                    return true;
                }
                else if (listaConParametros.Count == 2)
                {
                    respuesta = "Ingrese el precio";
                    return true;
                }
                else if (listaConParametros.Count == 3)
                {
                    respuesta = "Ingrese unidad";
                    return true;
                }
                else if (listaConParametros.Count == 4)
                {
                    respuesta = "Ingrese un tag";
                    return true;
                }
                else if (listaConParametros.Count == 5)
                {
                    respuesta = "Ingrese una ubicación";
                    return true;
                }
                else if (listaConParametros.Count == 6)
                {
                    respuesta = "Elija si es una oferta puntual o constante";
                    return true;
                }
                else if (listaConParametros.Count == 7)
                {
                    string puntualConstante = listaConParametros[0];
                    string ubicacionOferta = listaConParametros[1];
                    string tagOferta = listaConParametros[2];
                    string unidadesOferta = listaConParametros[3];
                    string precioOferta = listaConParametros[4];
                    string materialOferta = listaConParametros[5];
                    string nombreOferta = listaConParametros[6];
                    if (Logica.Empresas.ContainsKey(mensaje.Id))
                    {
                        Empresa value = Logica.Empresas[mensaje.Id];
                        LogicaEmpresa.CrearOferta(value, nombreOferta, materialOferta, precioOferta, unidadesOferta, tagOferta, ubicacionOferta, puntualConstante);
                        respuesta = $"Se ha registrado con nombre {nombreOferta}, de material {materialOferta}, del tipo {puntualConstante}, unidades: {unidadesOferta}, al precio de: {precioOferta}, con la ubicación en {ubicacionOferta} y los tags {tagOferta}. {OpcionesUso.AccionesEmpresas()}";
                        return true;
                    }
                }
                else
                {
                    respuesta = "No se ha podido registrar la oferta" +OpcionesUso.AccionesEmpresas();
                    return true;
                }
            }
            respuesta= string.Empty;
            return false;
        }
    }
}