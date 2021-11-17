using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class HistorialChat
    {
        public List<string> MensajesDelUser = new List<string>();

        public List<string> MensajesDelUserReves = new List<string>();

        /// <summary>
        /// Devueleve una lista que contiene los mensajes despues de el comando ingresado
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        public List<string> BuscarUltimoComando(string comando)
        {
            List<string> ParametrosIngresadosDelComando = new List<string>();

            foreach (string elemento in MensajesDelUser)
            {
               MensajesDelUserReves.Add(elemento); 
            }

            MensajesDelUserReves.Reverse(); 
            int contador = -1; //Ya que el index de las listas empieza en 0
            foreach (string mensajeParametro in MensajesDelUserReves)
            {
                if (mensajeParametro == comando)
                {
                    return ParametrosIngresadosDelComando;
                }
                ParametrosIngresadosDelComando.Add(mensajeParametro);
            }
            MensajesDelUserReves.Clear(); // Dejo en 0 esta lista para q no de errores cuando se inicialize el metodo mas de una vez
            return ParametrosIngresadosDelComando;
        }
    }

}