using System;

namespace ClassLibrary
{
    /// <summary>
    /// Esta clase se encarga de la lógica relacioanda a Empresa.
    /// </summary>
    public class LogicaEmpresa
    {
        /// <summary>
        /// Acepta la invitación del administrador
        /// </summary>
        public void AceptarInvitacion()
        {

        }

        /// <summary>
        /// Llama al método CrearProducto en empresa con los parametros pasados.
        /// </summary>
        /// <param name="empresa">Empresa que creará la oferta</param>
        /// <param name="publicaciones">La publicación donde se encuentran las ofertas</param>
        /// <param name="nombre">Nombre de la oferta</param>
        /// <param name="material">Material de lo que se oferece</param>
        /// <param name="precio">Precio de la oferta</param>
        /// <param name="unidad">Unidad tipo (Kg, g, ml, o unidad normal)</param>
        /// <param name="tags">Palabra clave</param>
        /// <param name="ubicacion">Ubicacion dónde se encuentra la oferta</param>
        public void CrearProducto(Empresa empresa, Publicaciones publicaciones, string nombre, string material, int precio, string unidad, string tags, string ubicacion)
        {
            empresa.CrearProducto(publicaciones, nombre, material, precio, unidad, tags, ubicacion);
        }

        /// <summary>
        /// Llama al método EliminarProducto en empresa con los parametros pasados.
        /// </summary>
        /// <param name="empresa">Empresa que eliminará la oferta</param>
        /// <param name="publicaciones">La publicación donde se encuentran las ofertas</param>
        /// <param name="oferta">Oferta que se desea elimianr</param>
        public void EliminarProducto(Empresa empresa, Publicaciones publicaciones, Oferta oferta)
        {
            empresa.EliminarProducto(oferta, publicaciones);
        }

        /// <summary>
        /// Llama al método AceptarOferta en empresa con los parametros pasados.
        /// </summary>
        /// <param name="empresa">Empresa que aceptará la oferta</param>
        /// <param name="publicaciones">La publicación donde se encuentran las ofertas</param>
        /// <param name="oferta">Oferta que se desea Aceptar</param>
        public void AceptarOferta(Empresa empresa, Publicaciones publicaciones, Oferta oferta)
        {
            empresa.AceptarOferta(oferta, publicaciones);
        }

        /// <summary>
        /// Llama al método CalcularOfertasVendidasSegunTiempo en empresa con los parametros pasados.
        /// </summary>
        /// <param name="empresa">Empresa que quiere calcular sus ofertas vendidas segun x tiempo</param>
        /// <param name="fechaInicio">Fecha inicio, se debe pasar fecha con formato AAAA-MM-DD</param>
        /// <param name="fechaFinal">Fecha final, se debe pasar fecha con formato AAAA-MM-DD</param>
        public void CalcularOfertasVendidasSegunTiempo(Empresa empresa, string fechaInicio, string fechaFinal)
        {
            empresa.CalcularOfertasVendidasSegunTiempo(fechaInicio, fechaFinal);
        }

        /// <summary>
        /// Llama al método AddHabilitacion en empresa con los parametros pasados.
        /// </summary>
        /// <param name="empresa">Empresa a la que se desea agregar una habilitacion</param>
        /// <param name="habilitacionBuscada">Habilitacion para ser agregada</param>
        public void AddHabilitacion(Empresa empresa, string habilitacionBuscada)
        {
            empresa.AddHabilitacion(habilitacionBuscada);
        }

        /// <summary>
        /// Llama al método RemoveHabilitacion en empresa con los parametros pasados.
        /// </summary>
        /// <param name="empresa">Empresa a la que se desea remover una habilitacion</param>
        /// <param name="habilitacion">Habilitacion para ser removida</param>
        public void RemoveHabilitacion(Empresa empresa, string habilitacion)
        {
            empresa.RemoveHabilitacion(habilitacion);
        }

        /// <summary>
        /// Llama al método GetHabilitacion en empresa con los parametros pasados.
        /// </summary>
        /// <param name="empresa">Empresa</param>
        public void GetHabilitacionList(Empresa empresa)
        {
            empresa.GetHabilitacionList();
        }

    }
}