using System;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de la lógica relacionada a Empresa.
    /// </summary>
    public static class LogicaEmpresa
    {
        /// <summary>
        /// Acepta la invitación del administrador.
        /// </summary>
        /// <param name="empresa">Empresa.</param>
        /// <param name="nombreEmpresa">Nombre de la Empresa.</param>
        public static void AceptarInvitacion(Empresa empresa, string nombreEmpresa)
        {
            empresa.AceptarInvitacion(nombreEmpresa);
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
        public static void CrearProducto(Empresa empresa, string nombre, string material, int precio, string unidad, string tags, string ubicacion, string constantesPuntuales)
        {
            if (Logica.ListaNombreOfertas.Contains(nombre))
            {
                Console.WriteLine("Nombre usado, por favor cambielo para poder crear el producto");
            }
            else
            {
                empresa.CrearProducto(Logica.PublicacionesA, nombre, material, precio, unidad, tags, ubicacion, constantesPuntuales);
                Logica.ListaNombreOfertas.Add(nombre);
                Console.WriteLine("Producto creado exitosamente");
            }
            
        }

        /// <summary>
        /// Llama al método EliminarProducto en empresa con los parametros pasados.
        /// </summary>
        /// <param name="empresa">Empresa que eliminará la oferta.</param>
        /// <param name="oferta">Oferta que se desea eliminar.</param>
        public static void EliminarProducto(Empresa empresa, Oferta oferta)
        {
            Empresa.EliminarProducto(oferta, Logica.PublicacionesA); // Cambie empresa por Empresa porque declare como static al método EliminarProducto de Empresa.
            Console.WriteLine("Producto eliminado exitosamente");
        }

        /// <summary>
        /// Llama al método AceptarOferta en empresa con los parametros pasados.
        /// </summary>
        /// <param name="empresa">Empresa que aceptará la oferta.</param>
        /// <param name="ofertaQueSeAcepta">Nombre de oferta que se desea Aceptar.</param>
        public static void AceptarOferta(Empresa empresa, string ofertaQueSeAcepta)
        {
            empresa.AceptarOferta(ofertaQueSeAcepta, Logica.PublicacionesA);
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
            empresa.RemoveHabilitacion(habilitacion);
        }

        /// <summary>
        /// Llama al método GetHabilitacion en empresa con los parametros pasados.
        /// </summary>
        /// <param name="empresa">Empresa.</param>
        public static void GetHabilitacionList(Empresa empresa)
        {
            empresa.GetHabilitacionList();
        }
    }
}