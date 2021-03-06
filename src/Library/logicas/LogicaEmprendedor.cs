using System;
namespace ClassLibrary
{
    /// <summary>
    /// Esta clase contiene la lógica del emprendedor.
    /// </summary>
    /// <remarks>
    /// Contiene un método para llamar a cada método de la clase Emprendedor.
    /// La creación de clases y la asignación de responsabilidades se hizo en base en un patron GRASP: Low Coupling and High Cohesion,
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
        /// <param name="email">Email del emprendedor, para contacatrlo.</param>
        /// <param name="id">Id del chat.</param>
        public static void RegistroEmprendedor(string nombre, string ubicacion, string rubro, string especializaciones, string email, string id)
        {
            Emprendedor nuevoEmprendedor = new Emprendedor(nombre, ubicacion, rubro, especializaciones, email); 
            Singleton<ContenedorPrincipal>.Instancia.Emprendedores.Add(id, nuevoEmprendedor); // Agrego a la lista de emprendedores registrados.    
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
                foreach (Oferta item in Singleton<ContenedorPrincipal>.Instancia.Publicaciones.OfertasPublicados)
                {
                    if (item.Nombre == nombreOferta)
                    {
                        emprendedor.OfertasInteresado.Add(item);
                        item.Interesado.Add(emprendedor.Nombre);
                        if (!item.EmpresaCreadora.InteresadosEnOfertas.Contains(item))
                        {
                            item.EmpresaCreadora.InteresadosEnOfertas.Add(item);
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
        /// <returns>Retorna las ofertas consumidas dentro del período de tiempo especificado.</returns>
        public static int CalcularOfertasConsumidas(Emprendedor emprendedor, string fechaInicio, string fechaFinal)
        {
            if (emprendedor == null)
            {
                throw new ArgumentNullException("El Emprendedor no puede ser nulo.");
            }
            else
            {
                return emprendedor.CalcularOfertasConsumidas(fechaInicio, fechaFinal);
            }
        }

        /// <summary>
        /// Este método permite crear una ficha del emprendedor en texto, para poder obtener sus datos.
        /// </summary>
        /// <param name="emprendedor">Recibe por parámetro un objeto de tipo Emprendedor.</param>
        /// <returns>Retorna la información de un Emprendedor.</returns>
        public static string VerEmprendedor(Emprendedor emprendedor)
        {
            return emprendedor.TextoEmprendedor();
        }
    }
}