using System;
namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsability que implementa el comando "hola".
    /// </summary>
    public class AddHabEmpresaHandler : BaseHandler
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase.
        /// Esta clase procesa el mensaje ingresado por el usuario.
        /// </summary>
        /// <param name="next"></param>
        public AddHabEmpresaHandler(BaseHandler next):base(next)
        {
            this.Keywords = new string[] {"Agregar habilitación", "agregar habilitacion"};
        }

        /// <summary>
        /// Este método procesa el mensaje "Agregar habilitación" y retorna true.
        /// En caso contrario retorna false.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado.</param>
        /// <returns></returns>
        protected override bool InternalHandle(IMensaje message, out string response)
        {
             if (this.CanHandle(message))
            {
                string[] mensajeTratado = message.Text.Split();
                if (Logica.Empresas.ContainsKey(message.Id))
                {
                    Console.WriteLine("EntreAddHab");
                    Empresa value = Logica.Empresas[message.Id];
                    LogicaEmpresa.AddHabilitacion(value, mensajeTratado[1]);
                    
                    response = $"Se ha agregado la habilitación {mensajeTratado[1]}.";
                    return true;
                }
            }
            
            response = string.Empty;
            return false;
        }
    }
}