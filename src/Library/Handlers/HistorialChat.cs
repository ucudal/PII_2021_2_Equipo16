using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class HistorialChat
    {
        /// <summary>
        /// Contiene los mensajes enviador por el Usuario.
        /// </summary>
        /// <typeparam name="string">Utiliza el tipo string.</typeparam>
        /// <returns></returns>
        public List<string> MensajesDelUser = new List<string>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="string"></typeparam>
        /// <returns></returns>
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

        /// <summary>
        /// Chequeo para ver si su ultimo comando ingresado es el buscado en los handlers
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        public bool ComprobarUltimoComandoIngresado(string comando)
        {
            foreach (string elemento in MensajesDelUser)
            {
               MensajesDelUserReves.Add(elemento); 
               Console.WriteLine("Este elemento es" + elemento);
            }
            MensajesDelUserReves.Reverse();

            foreach (string item in MensajesDelUserReves)
            {
                if (item.StartsWith("/"))
                {
                    if (item == comando)
                    {
                        MensajesDelUserReves.Clear();
                        return true;
                    } 
                    MensajesDelUserReves.Clear();
                    return false;
                }
                
            }
            MensajesDelUserReves.Clear();
            return false;
        }
    }

}