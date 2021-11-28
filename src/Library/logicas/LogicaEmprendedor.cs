using System;
namespace ClassLibrary
{
    /// <summary>
    /// Esta clase contiene la lógica del emprendedor.
    /// </summary>
    /// <remarks>
    /// Contiene un método para llamar a cada método de la clase Emprendedor.
    /// La creción de clases y la asignación de responsabilidades se hizo en base en un patron GRASP: Low Coupling and High Cohesion,
    /// buscando mantener un equilibrio entre cohesión y acoplamiento.
    /// </remarks>
    public static class LogicaEmprendedor
    {
        /// <summary>
        /// Registro de usuario para ser emprendedor.
        /// </summary>
        /// <param name="nombre">Nombre del emprendedor.</param>
        /// <param name="ubicacion">Ubicacion del emprendedor.</param>
        /// <param name="rubro">Rubro del emprendedor.</param>
        /// <param name="especializaciones">Especializaciones del emprendedor.</param>
        /// <param name="id">Id del chat.</param>
        public static void RegistroEmprendedor(string nombre, string ubicacion, string rubro, string especializaciones, string id)
        {
<<<<<<< HEAD
            if (Rubro.CheckRubro(rubro))
            { 
                Emprendedor nuevoEmprendedor = new Emprendedor(nombre, ubicacion, rubro, new Habilitaciones(), especializaciones); 
                Singleton<Logica>.Instancia.Emprendedores.Add(id, nuevoEmprendedor); // Agrego a la lista de emprendedores registrados.
            }
            else
            {
                ConsolePrinter.DatoPrinter("El rubro no existe.");
            }      
=======
            Emprendedor nuevoEmprendedor = new Emprendedor(nombre, ubicacion, rubro, especializaciones); 
            Singleton<ContenedorPrincipal>.Instancia.Emprendedores.Add(id, nuevoEmprendedor); // Agrego a la lista de emprendedores registrados.    
>>>>>>> deV2
        }

        /// <summary>
        /// Este método se encarga de llamar a AddHabilitación de Emprendedor.
        /// </summary>
        /// <param name="emprendedor">Un emprendedor.</param>
        /// <param name="habilitacionBuscada">Nombre de la habilitación a agregar.</param>
        public static void AddHabilitacion(Emprendedor emprendedor, string habilitacionBuscada)
        {
            if (emprendedor == null)
            {
                throw new ArgumentNullException("El Emprendedor no puede ser nulo.");
            }
            else
            {
                emprendedor.AddHabilitacion(habilitacionBuscada);
            }
        }

        /// <summary>
        /// Este método se encarga de llamar a RemoveHabilitación de Emprendedor.
        /// </summary>
        /// <param name="emprendedor">Un emprendedor.</param>
        /// <param name="habilitacion">Nombre de la habilitación a remover.</param>
        public static void RemoveHabilitacion(Emprendedor emprendedor, string habilitacion)
        {
            if (emprendedor == null)
            {
                throw new ArgumentNullException("El Emprendedor no puede ser nulo.");
            }
            else
            {
                emprendedor.RemoveHabilitacion(habilitacion);
            }
        }


        /// <summary>
        /// Este método llama a InteresadoEnOferta de Emprendedor.
        /// </summary>
        /// <param name="emprendedor">Un emprendedor.</param>
        /// <param name="nombreOferta">Una oferta.</param>
        // Se hizo en equipo.
        public static void InteresadoEnOferta(Emprendedor emprendedor, string nombreOferta)
        {
            if (emprendedor == null)
            {
                throw new ArgumentNullException("El Emprendedor no puede ser nulo.");
            }
            else
            {
<<<<<<< HEAD
                foreach (Oferta item in Singleton<Logica>.Instancia.Publicaciones.OfertasPublicados)
=======
                foreach (Oferta item in Singleton<ContenedorPrincipal>.Instancia.Publicaciones.OfertasPublicados)
>>>>>>> deV2
                {
                    if (item.Nombre == nombreOferta)
                    {
                        emprendedor.OfertasInteresado.Add(item);
                        item.Interesado.Add(emprendedor.Nombre);
                        if (!item.EmpresaCreadora.InteresadosEnOfertas.Contains(item))
                        {
                            item.EmpresaCreadora.InteresadosEnOfertas.Add(item); // Agregado para solucionar test
                        }
                        emprendedor.FechaDeOfertasCompradas.Add(DateTime.Now, item); // La fecha en la que se compró la oferta
                    }
                }
            }
        }

        /// <summary>
        /// Este método llama a CalcularOfertasCompradas de Emprendedor.
        /// </summary>
        /// <param name="emprendedor">Un emprendedor.</param>
        /// <param name="fechaInicio">Fecha de inicio.</param>
        /// <param name="fechaFinal">Fecha de final.</param>
        /// <returns>Retorna las ofertas compradas dentro del período de tiempo especificado.</returns>
        public static int CalcularOfertasCompradas(Emprendedor emprendedor, string fechaInicio, string fechaFinal)
        {
            if (emprendedor == null)
            {
                throw new ArgumentNullException("El Emprendedor no puede ser nulo.");
            }
            else
            {
                return emprendedor.CalcularOfertasCompradas(fechaInicio, fechaFinal);
            }
        }

        /// <summary>
        /// Este método permite crear una ficha del emprendedor en texto, para poder obtener sus datos.
        /// </summary>
        /// <param name="emprendedor">Recibe por parametro un objeto de tipo Emprendedor.</param>
        /// <returns></returns>
        public static string VerEmprendedor(Emprendedor emprendedor)
        {
            return emprendedor.TextoEmprendedor();
        }
    }
}