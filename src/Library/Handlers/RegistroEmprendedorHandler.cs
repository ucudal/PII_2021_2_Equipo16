using Telegram.Bot.Types;

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
            this.Keywords = new string[] {"Registrarse", "registrarse"};
        }

        /// <summary>
        /// Procesa el mensaje "Registrarse" y retorna true; retorna false en caso contrario.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(IMensaje message, out string response)
        {
            if (this.CanHandle(message))
            {
                // Se le pide al usuario que ingrese "Registrarse, nombre, ubicacion, rubro, especializaion
                // Para poder hacerle un split.
                // El usuario ya conoce los comandos y de que forma me tiene que ingresar los datos.
                string[] mensajeProcesado = message.Text.Split();
                // El 0 es Registrarse.
                string nombreEmprendedor = mensajeProcesado[1];
                string ubicacionEmprendedor = mensajeProcesado[2];
                string rubroEmprendedor = mensajeProcesado[3];
                string especializacionesEmprendedor = mensajeProcesado[4];
                
                // En el ultimo param le agrego el Id del chat para saber quien es. (Emprendedor o empresa)
                LogicaEmprendedor.RegistroEmprendedor(nombreEmprendedor, ubicacionEmprendedor, rubroEmprendedor, especializacionesEmprendedor, message.Id);

                response = $"Se ha registrado con nombre {nombreEmprendedor}, ubicacion {ubicacionEmprendedor}, rubro {rubroEmprendedor}, especializacion {especializacionesEmprendedor}. ";
                
                return true;
            }

            response = string.Empty;
            return false;
        }
    }
}