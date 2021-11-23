using System;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de la lógica relacionada a Empresa.
    /// </summary>
    /// <remarks>La creción de clases y la asignación de responsabilidades se hizo en base en un patron GRASP: Low Coupling and High Cohesion,
    /// buscando mantener un equilibrio entre cohesión y acoplamiento.
    /// </remarks>
    public static class LogicaEmpresa
    {
        /// <summary>
        /// Acepta la invitación del administrador.
        /// </summary>
        /// <param name="empresa">Empresa.</param>
        /// <param name="nombreEmpresa">Nombre de la Empresa.</param>
        public static void AceptarInvitacion(Empresa empresa, string nombreEmpresa)
        {
            if (empresa == null)
            {
                throw new ArgumentNullException("La Empresa no puede ser null.");
            }
            else
            {
                empresa.AceptarInvitacion(nombreEmpresa);
            }
        }

        /// <summary>
        /// Llama al método CrearProducto en empresa con los parametros pasados.
        /// </summary>
        /// <param name="empresa">Empresa que creará la oferta.</param>
        /// <param name="nombre">Nombre de la oferta.</param>
        /// <param name="material">Material de lo que se ofrece.</param>
        /// <param name="precio">Precio de la oferta.</param>
        /// <param name="unidad">Unidad tipo (Kg, g, ml, o unidad normal).</param>
        /// <param name="tags">Palabra clave.</param>
        /// <param name="ubicacion">Ubicacion dónde se encuentra la oferta.</param>
        /// <param name="constantesPuntuales">Si la oferta es constante o puntual.</param>
        public static void CrearOferta(Empresa empresa, string nombre, string material, string precio, string unidad, string tags, string ubicacion, string constantesPuntuales)
        {
            if (Logica.ListaNombreOfertas.Contains(nombre))
            {
                ConsolePrinter.DatoPrinter("El nombre ingresado ya existe, por favor intente de nuevo.");
            }
            else
            {
                empresa.CrearOferta(Logica.Publicaciones, nombre, material, precio, unidad, tags, ubicacion, constantesPuntuales);
                Logica.ListaNombreOfertas.Add(nombre);
                ConsolePrinter.DatoPrinter("Oferta creada exitosamente.");
            }
        }

        /// <summary>
        /// Llama al método EliminarProducto en empresa con los parametros pasados.
        /// </summary>
        /// <param name="empresa">Empresa que eliminará la oferta.</param>
        /// <param name="nombre">Nombre de la oferta que se desea eliminar.</param>
        public static void EliminarOferta(Empresa empresa, string nombre)
        {
            if (!Logica.ListaNombreOfertas.Contains(nombre))
            {
                ConsolePrinter.DatoPrinter("No existe una oferta con ese nombre, por favor intente de nuevo.");
            }
            else
            {
                empresa.EliminarOferta(nombre, Logica.Publicaciones); // Cambie empresa por Empresa porque declare como static al método EliminarProducto de Empresa.
                ConsolePrinter.DatoPrinter("Oferta eliminada exitosamente");
            }
        }

        /// <summary>
        /// Llama al método AceptarOferta en empresa con los parametros pasados.
        /// </summary>
        /// <param name="empresa">Empresa que aceptará la oferta.</param>
        /// <param name="ofertaQueSeAcepta">Nombre de oferta que se desea Aceptar.</param>
        public static void AceptarOferta(Empresa empresa, string ofertaQueSeAcepta)
        {
            empresa.AceptarOferta(ofertaQueSeAcepta, Logica.Publicaciones);
        }

        /// <summary>
        /// Llama al método CalcularOfertasVendidasSegunTiempo en empresa con los parametros pasados.
        /// </summary>
        /// <param name="empresa">Empresa que quiere calcular sus ofertas vendidas segun x tiempo.</param>
        /// <param name="fechaInicio">Fecha inicio, se debe pasar fecha con formato AAAA-MM-DD.</param>
        /// <param name="fechaFinal">Fecha final, se debe pasar fecha con formato AAAA-MM-DD.</param>
        /// <returns>Retorna las ofertas vendidas dentro del período de tiempo especificado.</returns>
        public static int CalcularOfertasVendidas(Empresa empresa, string fechaInicio, string fechaFinal)
        {
            return empresa.CalcularOfertasVendidas(fechaInicio, fechaFinal);
        }

        /// <summary>
        /// Llama al método AddHabilitacion en empresa con los parametros pasados.
        /// </summary>
        /// <param name="empresa">Empresa a la que se desea agregar una habilitación.</param>
        /// <param name="habilitacionBuscada">Habilitacion para ser agregada.</param>
        public static void AddHabilitacion(Empresa empresa, string habilitacionBuscada)
        {
            empresa.AddHabilitacion(habilitacionBuscada);
        }

        /// <summary>
        /// Llama al método RemoveHabilitacion en empresa con los parametros pasados.
        /// </summary>
        /// <param name="empresa">Empresa a la que se desea remover una habilitación.</param>
        /// <param name="habilitacion">Habilitacion para ser removida.</param>
        public static void RemoveHabilitacion(Empresa empresa, string habilitacion)
        {
            if (empresa == null)
            {
                throw new ArgumentNullException("La Empresa no puede ser null.");
            }
            else
            {
                empresa.RemoveHabilitacion(habilitacion);
            }
        }
        
        /// <summary>
        /// Metodo AddHabilitacionOferta de las ofertas de la empresa.
        /// </summary>
        /// <param name="empresa">empresa</param>
        /// <param name="habilitacion">habilitacion a agregar</param>
        /// <param name="nombreOferta">nombre de la oferta</param>
        public static void AddHabilitacionOferta(Empresa empresa, string habilitacion, string nombreOferta)
        {
            if (empresa == null)
            {
                throw new ArgumentNullException("La Empresa no puede ser null.");
            }
            else
            {    
                foreach (Oferta oferta in empresa.MisOfertas)
                {
                    if (oferta.Nombre == nombreOferta)
                    {
                        oferta.AddHabilitacion(habilitacion);
                    }
                }
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="habilitacion"></param>
        /// <param name="nombreOferta"></param>
        public static void RemoveHabilitacionOferta(Empresa empresa, string habilitacion, string nombreOferta)
        {   
            if (empresa == null)
            {
                throw new ArgumentNullException("La Empresa no puede ser null.");
            }
            else
            {
                Oferta ofertaH = null;
                foreach (Oferta oferta in empresa.MisOfertas)
                {
                    if (oferta.Nombre == nombreOferta)
                    {
                        ofertaH = oferta;
                    }
                }
                
                ofertaH.RemoveHabilitacion(habilitacion);
            }
        }
        
        /// <summary>
        /// Llama al método GetHabilitacion en empresa con los parametros pasados.
        /// </summary>
        /// <param name="empresa">Empresa.</param>
        public static string GetListaHabilitaciones(Empresa empresa)
        {
            return empresa.GetListaHabilitaciones();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="empresa"></param>
        /// <returns></returns>
        public static string VerInteresados(Empresa empresa)
        {
            return empresa.VerInteresados();
        }
    }
}