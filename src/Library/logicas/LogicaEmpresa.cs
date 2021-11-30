using System;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de la lógica relacionada a Empresa.
    /// </summary>
    /// <remarks>La creación de clases y la asignación de responsabilidades se hizo en base en un patron GRASP: Low Coupling and High Cohesion,
    /// buscando mantener un equilibrio entre cohesión y acoplamiento.
    /// </remarks>
    public static class LogicaEmpresa
    {
        /// <summary>
        /// Inicializa una nueva instancia de Oferta.
        /// </summary>
        /// <param name="empresa">Recibe por parametro la empresa que creo la oferta.</param>
        /// <param name="nombre">Recibe por parametro el nombre de la oferta.</param>
        /// <param name="nombreMaterial">Recibe por parametro el nombre del material de la oferta.</param>
        /// <param name="cantidad">Recibe por parametro la cantidad de la oferta.</param>
        /// <param name="precio">Recibe por parametro el precio de la oferta.</param>
        /// <param name="unidad">Recibe por parametro la unidad de la oferta.</param>
        /// <param name="tags">Recibe por parametro el tags de la oferta.</param>
        /// <param name="ubicacion">Recibe por parametro la ubicacion de la oferta.</param>
        /// <param name="constantesPuntuales">Recibe por parametro que indica si es contante de la oferta.</param>
        public static void CrearOferta(Empresa empresa, string nombre, string nombreMaterial, string cantidad, string precio, string unidad, string tags, string ubicacion, string constantesPuntuales)
        {
            if (Singleton<ContenedorPrincipal>.Instancia.ListaNombreOfertas.Contains(nombre))
            {
                ConsolePrinter.DatoPrinter("El nombre ingresado ya existe, por favor intente de nuevo.");
                throw new ArgumentException("El nombre ingresado ya existe, por favor intente uno nuevo.");
            }
            else
            {
                empresa.CrearOferta(Singleton<ContenedorPrincipal>.Instancia.Publicaciones, nombre, nombreMaterial, cantidad, precio, unidad, tags, ubicacion, constantesPuntuales);
                Singleton<ContenedorPrincipal>.Instancia.ListaNombreOfertas.Add(nombre);
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
            if (!Singleton<ContenedorPrincipal>.Instancia.ListaNombreOfertas.Contains(nombre))
            {
                ConsolePrinter.DatoPrinter("No existe una oferta con ese nombre, por favor intente de nuevo.");
            }
            else
            {
                empresa.EliminarOferta(nombre, Singleton<ContenedorPrincipal>.Instancia.Publicaciones);
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
            empresa.AceptarOferta(ofertaQueSeAcepta, Singleton<ContenedorPrincipal>.Instancia.Publicaciones);
        }

        /// <summary>
        /// Llama al método CalcularOfertasVendidasSegunTiempo en empresa con los parametros pasados.
        /// </summary>
        /// <param name="empresa">Empresa que quiere calcular sus ofertas vendidas segun x tiempo.</param>
        /// <param name="fechaInicio">Fecha inicio, se debe pasar fecha con formato YYYY-MM-DD.</param>
        /// <param name="fechaFinal">Fecha final, se debe pasar fecha con formato YYYY-MM-DD.</param>
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
        /// Este método se encarga de agregar habilitaciones para las ofertas.
        /// </summary>
        /// <param name="empresa">empresa.</param>
        /// <param name="habilitacion">habilitacion a agregar.</param>
        /// <param name="nombreOferta">nombre de la oferta.</param>
        public static void AgregarHabilitacionOferta(Empresa empresa, string habilitacion, string nombreOferta)
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
        /// Este método se encarga de remover habilitaciones para las ofertas.
        /// </summary>
        /// <param name="empresa">Empresa.</param>
        /// <param name="habilitacion">Nombre de la habilitacion.</param>
        /// <param name="nombreOferta">Nombre de la oferta.</param>
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
        /// Este método muestra los interesados en una oferta.
        /// </summary>
        /// <param name="empresa">Empresa.</param>
        /// <returns>Retorna los interesados en la oferta.</returns>
        public static string VerInteresados(Empresa empresa)
        {
            return empresa.VerInteresados();
        }

        /// <summary>
        /// Método que devuelve todos los atributos de la empresa.
        /// </summary>
        /// <param name="empresa">Empresa.</param>
        /// <returns>Retorna la información de la Empresa.</returns>
        public static string VerEmpresa(Empresa empresa)
        {
            return empresa.TextoEmpresa();
        }

        /// <summary>
        /// Método que devuelve las ofertas publicadas por la empresa.
        /// </summary>
        /// <param name="empresa">Empresa.</param>
        /// <returns></returns>
        public static string VerMisOfertas(Empresa empresa)
        {
            return PlataformaPrinter.BusquedaPrinter(empresa.VerMisOfertas());
        }
    }
}