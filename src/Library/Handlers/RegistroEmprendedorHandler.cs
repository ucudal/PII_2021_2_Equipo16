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
            this.Keywords = new string[] {"/registrarse"};
        }

        /// <summary>
        /// Procesa el mensaje "Registrarse" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/registrarse"))
            {
                respuesta = string.Empty;
                return false;
            }
            
            // cambiar este canhandle por algo tipo, si en el historial, el ultimo comando es /Registrarse, entra al if.
<<<<<<< HEAD
            if (Singleton<Logica>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/registrarse") == true)
            {
                List<string> listaConParametros = Singleton<Logica>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/registrarse");
=======
            if (Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/registrarse") == true)
            {
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/registrarse");
>>>>>>> deV2
                if (listaConParametros.Count == 0)
                {
                    respuesta = "Ingrese el nombre";
                    return true;
                    //Console.WriteLine("Entro aca");
                }
                if (listaConParametros.Count == 1)
                {
                    respuesta = "Ingrese la ubicacion";
                    return true;
                }
                if (listaConParametros.Count == 2)
                {
                    respuesta = $"Ingrese rubro\n {Singleton<ContenedorRubroHabilitaciones>.Instancia.textoListaRubros()}";
                    return true;
                }
                if (listaConParametros.Count == 3)
                {
                    respuesta = "Ingrese especializaciones";
                    return true;
                }
                if (listaConParametros.Count == 4)
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

                    respuesta = $"Usted se ha registrado como un Emprendedor con el nombre {nombreEmprendedor}, la ubicacion {ubicacionEmprendedor}, el rubro {rubroEmprendedor}, y la especializacion {especializacionesEmprendedor}. {OpcionesUso.AccionesEmprendedor()}";
                    return true;
                }
            }

            respuesta = string.Empty;
            return false;   
        }
    }
}