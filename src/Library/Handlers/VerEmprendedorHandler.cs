using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "hola".
    /// </summary>
    public class VerEmprendedorHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="next"></param>
        public VerEmprendedorHandler(BaseHandler next):base(next)
        {
            this.Keywords = new string[] {"/veremprendedor"};
        }

        /// <summary>
        /// Este método procesa el mensaje "/VerEmprendedor" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="mensaje">Recibe por parametro el mensaje a procesar.</param>
        /// <param name="respuesta">Recibe por paramtro la respuesta al mensaje procesado.</param>
        /// <returns>Retorna true si se ha podido realizar la operación, o false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje mensaje, out string respuesta)
        {
            if (!this.ChequearHandler(mensaje, "/veremprendedor"))
            {
                respuesta = string.Empty;
                return false;
            }

<<<<<<< HEAD
            if (Singleton<Logica>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/veremprendedor") == true)
            {
                ConsolePrinter.DatoPrinter("Entro en empre");
                List<string> listaConParametros = Singleton<Logica>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/veremprendedor");
                if (Singleton<Logica>.Instancia.Emprendedores.ContainsKey(mensaje.Id))
                {
                    Emprendedor value = Singleton<Logica>.Instancia.Emprendedores[mensaje.Id];
=======
            if (Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].ComprobarUltimoComandoIngresado("/veremprendedor") == true)
            {
                ConsolePrinter.DatoPrinter("Entro en empre");
                List<string> listaConParametros = Singleton<ContenedorPrincipal>.Instancia.HistorialDeChats[mensaje.Id].BuscarUltimoComando("/veremprendedor");
                if (Singleton<ContenedorPrincipal>.Instancia.Emprendedores.ContainsKey(mensaje.Id))
                {
                    Emprendedor value = Singleton<ContenedorPrincipal>.Instancia.Emprendedores[mensaje.Id];
>>>>>>> deV2
                    respuesta = $"La información del emprendedor es la siguiente : {LogicaEmprendedor.VerEmprendedor(value)} {OpcionesUso.AccionesEmprendedor()}";
                    return true;
                }
            }
            
            respuesta = string.Empty;
            return false;
        }
    }
}