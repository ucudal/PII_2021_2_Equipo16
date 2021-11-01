using System;
using System.Collections.Generic;
using System.Text;


namespace ClassLibrary
{
    /// <summary>
    /// Esta clase representa un limpiador de cadenas para permitir leer las cadenas correctamente
    /// </summary>
    public class LimpiadorCadena
    {
        /// <summary>
        /// Este método sirve para limpiar las cadenas y permitir que no hayan errores de tipeo, 
        /// y se pueda leer el texto que sea ingresado por un usuario de la aplicación
        /// </summary>
        /// <param name="cadena">Recibe por parametro un cadena de tipo String</param>
        /// <returns>Retorna la cadena una vez que se le aplicaron todos los limpiadores de cadena</returns>
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