using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class RegistroEmprendedorHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public RegistroEmprendedorHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"/registrarme"};
        }

        /// <summary>
        /// Procesa el mensaje "Registrarse" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/registrarme"))
            {
                respuesta = string.Empty;
                return false;
            }
            // cambiar este canhandle por algo tipo, si en el historial, el ultimo comando es /Registrarse, entra al if.
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
                        //Console.WriteLine("Entro aca");
                    }
                    else if (listaConParametros.Count == 1)
                    {
                        respuesta = "Ingrese la ubicacion";
                        return true;
                    }
                    else if (listaConParametros.Count == 2)
                    {
                        respuesta = $"Ingrese rubro\n {Singleton<ContenedorPrincipal>.Instancia.ContenedorRubrosHabs.textoListaRubros()}";
                        return true;
                    }
                    else if (listaConParametros.Count == 3)
                    {
                        respuesta = "Ingrese especializaciones";
                        return true;
                    }
                    else if (listaConParametros.Count == 4)
                    {
                        string nombreEmprendedor = listaConParametros[3];
                        string ubicacionEmprendedor = listaConParametros[2];
                        string rubroEmprendedor = listaConParametros[1];
                        string especializacionesEmprendedor = listaConParametros[0];

                        try
                        {
                            LogicaEmprendedor.RegistroEmprendedor(nombreEmprendedor, ubicacionEmprendedor, rubroEmprendedor, especializacionesEmprendedor, mensaje.Id);
                        }
                        catch (System.ArgumentException e)
                        {
                            respuesta = e.Message;
                            return true; // Tengo entendido que esto podria ser false ya que en realidad falla. consultar con profe
                        }

                        Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].HistorialClear();
                        respuesta = $"Usted se ha registrado como un Emprendedor con el nombre {nombreEmprendedor}, ubicado en {ubicacionEmprendedor}, con el rubro {rubroEmprendedor}, y la especializacion {especializacionesEmprendedor}. {OpcionesUso.AccionesEmprendedor()}";
                        return true;
                    }
                }
                
            }

            respuesta = string.Empty;
            return false;   
        }
    }
}