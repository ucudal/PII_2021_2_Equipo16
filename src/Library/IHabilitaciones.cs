using System.Collections.Generic;


namespace ClassLibrary
{
    /// <summary>
    /// Esta interface contiene los métodos para agregar, quitar o consultar habilitaciones
    /// </summary>
    public interface IHabilitaciones 
    {
        /// <summary>
        /// Este método se implementará para agregar habilitaciones a las diferentes clases que lo requieran
        /// </summary>
        /// <param name="nombre">Recibe un string del nombre de la habilitación que se desea agregar</param>
        void AddHabilitacion(string nombre);
        /// <summary>
        /// Este método se implementará para eliminar habilitaciones de las diferentes clases
        /// </summary>
        /// <param name="nombre">Recibe un string con el nombre de la habilitacion que se quiere eliminar</param>
        void RemoveHabilitacion(string nombre);
        /// <summary>
        /// Este método se implementará para obtener la en texto la lista de habilitaciones de las clases
        /// </summary>
        void GetHabilitacionList();
    }
}
