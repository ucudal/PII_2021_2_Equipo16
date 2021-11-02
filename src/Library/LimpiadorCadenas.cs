using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


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

        /// <summary>
        /// Este método sirve para limpiar las cadenas de respuestas que el usuario ingresará.
        /// Creemos necesario tener un limpiador de cadenas así, ya que el usuario podria
        /// digitar el texto de cualquier forma, con mayusculas, minusculas o combinaciones de ambas.
        /// 
        /// </summary>
        /// <param name="respuesta">Recibe como parametro una cadena de caracteres de tipo String</param>
        /// <returns>Devuelve la cadena pero con las modificaciones realizadas</returns>
        public static string LimpiaCadenaRespuesta(string respuesta)
        {
            ArrayList subRespuesta = new ArrayList();
            subRespuesta.Add(respuesta.Split(" "));
            ArrayList subRespuesta1 = new ArrayList();
            string varCadena;
            foreach (string cadena in subRespuesta)
            {
                varCadena = cadena.Replace("á", "a");
                varCadena = cadena.Replace("é", "e");
                varCadena = cadena.Replace("í", "i");
                varCadena = cadena.Replace("ó", "o");
                varCadena = cadena.Replace("ú", "u");
                subRespuesta1.Add(varCadena.ToLower());
            }
            respuesta = String.Join(" ",subRespuesta1);
            return respuesta;
        }

    }
}