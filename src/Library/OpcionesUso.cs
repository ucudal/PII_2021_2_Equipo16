namespace ClassLibrary
{
    /// <summary>
    /// Esta clase contiene los métodos para poder hacer más fácil la tarea de que el usuario ingrese un comando para poder operar en el bot.
    /// Se utilizan métodos estaticos porque no se requiere instanciar la clase para utilizarlos.
    /// </summary>
    public class OpcionesUso
    {
        /// <summary>
        /// Este método contiene todas las instrucciones que un emprendedor puede llegar a realizar.
        /// </summary>
        /// <returns>Retorna un string con cada comando.</returns>
        public static string AccionesEmprendedor()
        {
            string acciones = $" \nOpciones:\n- /agregarhabilitacionemprendedor \n- /buscarmaterial\n- /buscartag\n- /buscarubicacion\n- /calcularofertascompradas\n- /listadehabilitacionesemprendedor\n- /verubicacion\n- /ubicacionoferta";
            return acciones;
        }
        
        /// <summary>
        /// Este método contiene todas las instrucciones que una empresa puede llegar a utilizar.
        /// </summary>
        /// <returns>Retorna un string con cada comando.</returns>
        public static string AccionesEmpresas()
        {
            string acciones = $" \nOpciones:\n- /aceptaroferta\n- /agregarhabilitacionempresa\n- /calcularofertasvendidas\n- /crearoferta\n- /crearhaboferta\n- /removerhaboferta\n- /eliminaroferta\n- /removerhabempresa\n- /verinteresados\n- /verubicacionempresa";
            return acciones;
        }

        /// <summary>
        /// Este método contiene todas las instrucciones que un Administrador puede llegar a utilizar.
        /// </summary>
        /// <returns>Retorna un string con cada comando.</returns>
        public static string AccionesAdministradores()
        {
            string acciones = $" \nOpciones: \n- /crearempresa \n- /invitarempresa\n- /cambiarclave ";
            return acciones;
        }
    }
}