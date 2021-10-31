using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Empresa: Usuario, IHabilitaciones
    {
        public Empresa(String nombre, String ubicacion, Rubro rubro, Habilitaciones habilitacion):base(nombre, ubicacion, rubro)
        {
            this.habilitacion = habilitacion;
        }
        public List<string> habilitacionesEmpresa = new List<string>();
        public List<Oferta> ofertasAceptados = new List<Oferta>();
        public List<Oferta> interesadosEnOfertas = new List<Oferta>();

        private Habilitaciones habilitacion{get;set;}

    


        public void AceptarInvitacion()
        {
            // Cuando tengamos conocimiento de telegram se implementa
        }

        
        //Creator
        public void CrearProducto(Publicaciones publicaciones, string nombre, string material, int precio, string unidad, string tags, string ubicacion, Guid id)
        {

            bool habilitacionesAgregadas = false;
            Oferta productoCreado = new Oferta(nombre, material, precio, unidad, tags, ubicacion, id);
            publicaciones.OfertasPublicados.Add(productoCreado);
          
            while (habilitacionesAgregadas)
            {
                // Todo lo que es console.writeline y ReadLine, es para tenerlo claro en consola, 
                // Cuando conozcamos sobre Telegram se debería modificar.
                Console.WriteLine("Desea agregar mas habilitaciones");
                if (Console.ReadLine() == "Si")
                {
                    Console.WriteLine("Escriba cual quiere agregar");
                    string habilitacionParaAgregar = Console.ReadLine();
                    productoCreado.AddHabilitacion(habilitacionParaAgregar);
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

        public void AddHabilitacion(string habilitacionBuscada)
        {
            if (habilitacion.ListaHabilitaciones.Contains(habilitacionBuscada))
            {
                habilitacionesEmpresa.Add(habilitacionBuscada);
            }
        }

        public void RemoveHabilitacion(string habilitacion)
        {
            habilitacionesEmpresa.Remove(habilitacion);
        }

        public void GetHabilitacionList()
        {
            habilitacion.HabilitacionesDisponibles();
        }

    }
}