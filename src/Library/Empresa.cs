using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Empresa: Usuario, IHabilitaciones
    {


        //public string Nombre{get;set;}
        //public Rubro Rubro{get;set;}

        //public string Ubicacion{get;set;}
        public Empresa(String nombre, String ubicacion, Rubro rubro):base(nombre, ubicacion, rubro)
        {

        }
        List<Oferta> ofertasAceptados = new List<Oferta>();

        public void AceptarInvitacion()
        {

        }

        

        public void CrearProducto(Publicaciones publicaciones, string nombre, string material, int precio, string unidad, string tags, string ubicacion)
        {
            bool habilitacionesAgregadas = false;
            Oferta productoCreado = new Oferta(nombre, material, precio, unidad, tags, ubicacion);
            publicaciones.OfertasPublicados.Add(productoCreado);
            //Falta agregar habilitaciones
            while (habilitacionesAgregadas)
            {
                Console.WriteLine("Desea agregar mas habilitaciones");
                if (Console.ReadLine() == "Si")
                {
                    productoCreado.AddHabilitacion();
                }
                else
                {
                    habilitacionesAgregadas = true;
                }
            }
        }

        public void EliminarProducto(Oferta oferta, Publicaciones publicaciones)
        {
            publicaciones.OfertasPublicados.Remove(oferta);
        }

        //Habilitaciones que tengo yo a nivel de empresa

        public void AddHabilitacion()
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