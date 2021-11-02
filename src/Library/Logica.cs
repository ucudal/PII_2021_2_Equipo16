using System;
using System.Text;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class Logica
    {
        public static Publicaciones PublicacionesA = Publicaciones.Instance;

        public static BuscadorUbicacion buscadorUbi = new BuscadorUbicacion();

        public static BuscadorTags buscadorTag = new BuscadorTags();

        public static BuscadorMaterial buscadorMat = new BuscadorMaterial();

        public static ConsolePrinter printerConsola = new ConsolePrinter();



    }
    
}