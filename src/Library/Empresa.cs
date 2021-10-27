using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Empresa: Usuario, IHabilitaciones
    {


        public string Nombre{get;set;}
        public Rubro Rubro{get;set;}
        public Empresa(String nombre, Rubro rubro)
        {
            this.Nombre = nombre;
            this.Rubro = rubro;
        }
        List<Producto> productosAceptados = new List<Producto>();

        public void AceptarInvitacion()
        {

        }

        public void CrearProducto()
        {
            Producto productoCreado = new Producto();
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