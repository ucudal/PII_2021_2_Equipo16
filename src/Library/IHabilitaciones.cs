using System.Collections.Generic;


namespace ClassLibrary
{
    public interface IHabilitaciones 
    {
        void AddHabilitacion(string nombre, string certificador);
        void RemoveHabilitacion(string nombre, string certificador);
        void GetHabilitacionList();
    }
}
