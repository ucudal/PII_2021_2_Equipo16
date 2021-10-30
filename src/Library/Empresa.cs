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
                    // Lo ideal podria ser agregarlo sinque tengaese metodo el producto
                    // Por ejemplo pasarle como parametro en constructor una lista de habilitaciones a la oferta, y de aca accedera eso
                    // if esa habilitacion esta en las habilitaciones totales
                    // productoCreado.habilitaciones.add()
                    // Haciendo eso podemos sacar responsabilidades de producto y hacer que no implemente IHabilitaciones
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