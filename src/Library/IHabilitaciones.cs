using System.Collections.Generic;


namespace ClassLibrary
{
    public interface IHabilitaciones 
    {
        void AddHabilitacion(string nombre);
        void RemoveHabilitacion(string nombre);
        void GetHabilitacionList();
    }
}
