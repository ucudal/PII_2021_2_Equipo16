using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Empresa: Usuario, IHabilitaciones
    {


        public string Nombre{get;set;}
        public Rubro Rubro{get;set;}
        public Empresa(string nombre,string ubicacion, Rubro rubro)
            : base(nombre, ubicacion, rubro)
        {
        }
        List<Oferta> productosAceptados = new List<Oferta>();

        public void AceptarInvitacion()
        {

        }

        public void CrearProducto()
        {
            Oferta productoCreado = new Oferta();
        }

        public void EliminarProducto()
        {

        }

        public void AgregarHabilitacion()
        {

        }

        public void EliminarHabilitacion()
        {

        }

        public void VerHabilitaciones()
        {

        }

    }
}