using System;
using System.Collections.Generic;
using System.Text;


namespace ClassLibrary
{
    public class LimpiadorCadena
    {
        public static string LimpiaCadena(string cadena)
        {
            cadena = cadena.Replace(" ", "");
            cadena = cadena.ToLower();
            cadena = cadena.Replace("á", "a");
            cadena = cadena.Replace("é", "e");
            cadena = cadena.Replace("í", "i");
            cadena = cadena.Replace("ó", "o");
            cadena = cadena.Replace("ú", "u");
            return cadena;
        }
    }
}