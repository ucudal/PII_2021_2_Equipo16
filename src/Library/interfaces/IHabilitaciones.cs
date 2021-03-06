namespace ClassLibrary
{
    /// <summary>
    /// Esta interface contiene los métodos para agregar, quitar o consultar habilitaciones.
    /// </summary>
    /// <remarks>
    /// Mediante el uso de esta interfaz, se puede incluir el comportamiento de varias fuentes en una clase.
    /// Por ejemplo, la implementacion que realizan las clases Emprendedor, Empresa y Ofertas.
    /// </remarks>
    public interface IHabilitaciones
    {
        /// <summary>
        /// Este método se implementará para agregar habilitaciones a las diferentes clases que lo requieran.
        /// </summary>
        /// <param name="habilitacionBuscada">Recibe un string del nombre de la habilitación que se desea agregar.</param>
        void AddHabilitacion(string habilitacionBuscada);

        /// <summary>
        /// Este método se implementará para eliminar habilitaciones de las diferentes clases.
        /// </summary>
        /// <param name="habilitacion">Recibe un string con el nombre de la habilitación que se quiere eliminar.</param>
        void RemoveHabilitacion(string habilitacion);
    }
}