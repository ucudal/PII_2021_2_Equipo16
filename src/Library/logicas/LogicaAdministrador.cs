using System;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de la lógica relacionada con el Administrador.
    /// </summary>
    public static class LogicaAdministrador
    {
        /// <summary>
        /// Este método sirve para registrar al administrador en el bot.
        /// Por defecto la clave para registrarse iniciamente es "equipo_16", debe verificar para poder registrarse.
        /// </summary>
        /// <param name="nombre">Recibe el nombre del Administrador como un string.</param>
        /// <param name="clave">Recibe una clave de acceso que es suministrada al Admin.</param>
        /// <param name="id">Recibe el id del Admin.</param>
        public static void RegistroAdministrador(string nombre, string clave, string id)
        {
            if (clave == "equipo_16")
            {
                Administrador admin = new Administrador(nombre, clave);
                Singleton<ContenedorPrincipal>.Instancia.Administradores.Add(id, admin);
            }
            else
            {
                throw new ArgumentException ("No se ha podido acceder como administrador");
            }
        }

        /// <summary>
        /// Invita a la empresa a unirse al bot.
        /// </summary>
        /// <param name="administrador"></param>
        /// <param name="nombreEmpresa"></param>
        public static void InvitarEmpresa(Administrador administrador, string nombreEmpresa)
        {
            if (administrador == null)
            {
                throw new ArgumentNullException ("El administrador no puede ser null.");
            }
            else
            {
                foreach (Empresa empresa in administrador.Empresas)
                {
                    if (nombreEmpresa == empresa.Nombre)
                    {
                        administrador.InvitarEmpresa(empresa);
                        ConsolePrinter.DatoPrinter($"Se ha agregado a {empresa.Nombre}.");
                    }
                    else
                    {
                        ConsolePrinter.DatoPrinter($"La empresa {empresa.Nombre} no esta en los registros del bot.");
                    }
                }
            }
        }

        /// <summary>
        /// Implementa los cambios de claves del Administrador.
        /// Inicialmente se le recomienda al Administrador cambiar su clave cuando se registra.
        /// </summary>
        /// <param name="administrador">Recibe por parametro el Administrador de referencia.</param>
        /// <param name="clave">Recibe por parametro la pass antigua.</param>
        /// <param name="nuevaClave">Recibe por parametro la nueva pass.</param>
        public static void CambioClave(Administrador administrador,string clave, string nuevaClave)
        {
            administrador.CambioClave(clave, nuevaClave);
        }

        /// <summary>
        /// Este método crea una nueva empresa conocida por el administrador.
        /// </summary>
        /// <param name="administrador">Recibe por parametro el Administrador de referencia.</param>
        /// <param name="nombreEmpresa">Recibe por parametro el nombre de la empresa.</param>
        /// <param name="ubicacionEmpresa">Recibe por paramtro la ubicacion de la empresa.</param>
        /// <param name="rubroEmpresa">Recibe por parametro el rubro al que pertenece la empresa.</param>
        public static void CrearEmpresa(Administrador administrador, string nombreEmpresa, string ubicacionEmpresa, string rubroEmpresa)
        {
            administrador.CrearEmpresa(nombreEmpresa, ubicacionEmpresa, rubroEmpresa);
        }
    }
}