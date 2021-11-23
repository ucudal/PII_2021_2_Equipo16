 
namespace ClassLibrary
{
    public class OpcionesUso
    {
        public static string AccionesEmprendedor()
        {
            string acciones = $" \nOpciones:\n- /agregarhabilitacionemprendedor \n- /buscarmaterial\n- /buscartag\n- /buscarubicacion\n- /calcularofertascompradas\n- /listahabilitacionesemprendedor";
            return acciones;
        }
        
        public static string AccionesEmpresas()
        {
            string acciones = $" \nOpciones:\n- /aceptaroferta\n- /agregarhabilitacionempresa\n- /calcularofertasvendidas\n- /crearoferta\n- /crearhaboferta\n- /removerhaboferta\n- /eliminaroferta\n- /removerhabempresa\n- /verinteresados";
            return acciones;
        }
    }
   
}