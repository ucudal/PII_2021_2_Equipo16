using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un "Handler" del patrón Chain of Responsibility que implementa el comando "/registrarme" y se encarga
    /// de manejar el caso en que un nuevo Emprendedor se quiera registrar en el Bot.
    /// </summary>
    public class RegistroEmprendedorHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RegistroEmprendedorHandler"/>.
        /// </summary>
        /// <param name="next">Handler siguiente.</param>
        public RegistroEmprendedorHandler(BaseHandler next)
            : base(next)
        {
            this.Keywords = new string[] { "/registrarme" };
        }

        /// <summary>
        /// Procesa el mensaje para que un Emprendedor se pueda registrar.
        /// </summary>
        /// <param name="mensaje">Mensaje que debe procesar.</param>
        /// <param name="respuesta">Respuesta al mensaje procesado.</param>
        /// <returns>Retorna <c>True</c> si se ha podido realizar la operación, o <c>False</c> en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/registrarme"))
            {
                respuesta = string.Empty;
                return false;
            }
            else if (Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/registrarme"))
            {
                if (Singleton<ContenedorPrincipal>.Instancia.Empresas.ContainsKey(mensaje.Id))
                {
                    respuesta = "Error: Usted ya se ha registrado como una empresa previamente.";
                    return true;
                }
                else if (Singleton<ContenedorPrincipal>.Instancia.Emprendedores.ContainsKey(mensaje.Id))
                {
                    respuesta = "Usted ya se ha registrado previamente.";
                    return true;
                }
                else
                {
                    List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/registrarme");
                    if (listaConParametros.Count == 0)
                    {
                        respuesta = "Ingrese el nombre";
                        return true;
                    }
                    else if (listaConParametros.Count == 1)
                    {
                        respuesta = "Ingrese la ubicacion";
                        return true;
                    }
                    else if (listaConParametros.Count == 2)
                    {
                        respuesta = $"Ingrese rubro\n {Singleton<ContenedorPrincipal>.Instancia.ContenedorRubrosHabs.TextoListaRubros()}";
                        return true;
                    }
                    else if (listaConParametros.Count == 3)
                    {
                        respuesta = "Ingrese especializaciones";
                        return true;
                    }
                    else if (listaConParametros.Count == 4)
                    {
                        respuesta = "Ingrese su email de contacto";
                        return true;
                    }
                    else if (listaConParametros.Count == 5)
                    {
                        string nombreEmprendedor = listaConParametros[4];
                        string ubicacionEmprendedor = listaConParametros[3];
                        string rubroEmprendedor = listaConParametros[2];
                        string especializacionesEmprendedor = listaConParametros[1];
                        string emailEmprendedor = listaConParametros[0];

                        try
                        {
                            LogicaEmprendedor.RegistroEmprendedor(nombreEmprendedor, ubicacionEmprendedor, rubroEmprendedor, especializacionesEmprendedor, emailEmprendedor,  mensaje.Id);
                        }
                        catch (System.ArgumentException e)
                        {
                            respuesta = e.Message;
                            return true;
                        }

                        Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                        respuesta = $"Usted se ha registrado como un Emprendedor con el nombre {nombreEmprendedor}, ubicado en {ubicacionEmprendedor}, con el rubro {rubroEmprendedor}, y la especializacion {especializacionesEmprendedor}, con Email {emailEmprendedor}. {OpcionesUso.AccionesEmprendedor()}";
                        return true;
                    }
                }
            }

            respuesta = string.Empty;
            return false;   
        }
    }
}