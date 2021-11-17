using Telegram.Bot.Types;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "hola".
    /// </summary>
    public class CrearProductoHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase Esta clase procesa el mensaje "hola".
        /// </summary>
        /// <param name="next">El próximo "handler".</param>
        public CrearProductoHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] {"Crear producto", "crear producto"};
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="response"></param>
        /// <returns></returns>
        protected override bool InternalHandle(IMensaje message, out string response)
        {
            if (this.CanHandle(message))
            {
                // El mensaje debe tener el formato "Agregar habilitacion de oferta,habilitacion ,nombre de la oferta" o sus keywords
                string[] mensajeProcesado = message.Text.Split();
                if (Logica.Empresas.ContainsKey(message.Id))
                {
                    Empresa value = Logica.Empresas[message.Id];
                    LogicaEmpresa.CrearProducto(value, mensajeProcesado[1], mensajeProcesado[2]);

                    response = $"Se ha creado la oferta {mensajeProcesado[2]}.";
                    return true;
                }

            }

            response = string.Empty;
            return false;
        }

