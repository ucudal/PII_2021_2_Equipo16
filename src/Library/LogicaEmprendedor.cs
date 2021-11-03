namespace ClassLibrary
{
    /// <summary>
    /// Esta clase contiene la lógica del emprendedor.
    /// </summary>
    /// <remarks>
    /// Contiene un método para llamar a cada método de la clase Emprendedor.
    /// </remarks>
    public class LogicaEmprendedor
    {
        /// <summary>
        /// Este método se encarga de llamar a AddHabilitación de Emprendedor.
        /// </summary>
        /// <param name="habilitacionBuscada">Nombre de la habilitación a agregar.</param>
        /// <param name="emprendedor">Un emprendedor.</param>
        public static void AddHabilitacion(Emprendedor emprendedor, string habilitacionBuscada)
        {
            emprendedor.AddHabilitacion(habilitacionBuscada);
        }

        /// <summary>
        /// Este método se encarga de llamar a RemoveHabilitación de Emprendedor.
        /// </summary>
        /// <param name="habilitacion">Nombre de la habilitación a remover.</param>
        /// <param name="emprendedor">Un emprendedor.</param>
        public static void RemoveHabilitacion(Emprendedor emprendedor, string habilitacion)
        {
            emprendedor.RemoveHabilitacion(habilitacion);
        }

        /// <summary>
        /// Este método llama a GetHabilitacionList de Emprendedor.
        /// </summary>
        /// <param name="emprendedor">Un emprendedor.</param>
        public static void GetHabilitacionList(Emprendedor emprendedor)
        {
            emprendedor.GetHabilitacionList();
        }

        /// <summary>
        /// Este método llama a InteresadoEnOferta de Emprendedor.
        /// </summary>
        /// <param name="emprendedor">Un emprendedor.</param>
        /// <param name="oferta">Una oferta.</param>
        
        // Se hizo en equipo.
        public static void InteresadoEnOferta(Emprendedor emprendedor, string nombreOferta)
        {
            foreach (Oferta item in Logica.PublicacionesA.OfertasPublicados)
            {
               if (item.Nombre == nombreOferta)
               {
                    item.interesado = emprendedor.Nombre;
                    item.EmpresaCreadora.InteresadosEnOfertas.Add(item); //agregado para solucionar test
               } 
            }
        }

        /// <summary>
        /// Este método llama a CalcularOfertasCompradas de Emprendedor.
        /// </summary>
        /// <param name="emprendedor">Un emprendedor.</param>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFinal"></param>
        public static void CalcularOfertasCompradas(Emprendedor emprendedor, string fechaInicio, string fechaFinal)
        {
            emprendedor.CalcularOfertasCompradas(fechaInicio, fechaFinal);
        }
    }
}