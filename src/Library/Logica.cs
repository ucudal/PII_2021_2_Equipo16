using System;
using System.Collections.Generic;
using System.Text;


namespace ClassLibrary
{
    public class Logica
    {
        public static void logica()
        {
            Administrador admin = new Administrador("SoyAdmin");
            Empresa empresa1 = new Empresa("empresa1", "calle A", new Rubro("textil"), new Habilitaciones("apa"));
            Emprendedor emprendedor1 = new Emprendedor("emprendedor1", "calle B", new Rubro("Industria"), "metalurgica");
            Publicaciones publicaciones = new Publicaciones();
            
            /*
            // Rol administrador
            Console.WriteLine("Bienvenido Administrador: ");
            entrada:
            Console.WriteLine("Que accion desea realizar: ");
            Console.WriteLine("1- Invitar empresa\n2- Salir");
            int accionesAdm = Int32.Parse(Console.ReadLine());
            if (accionesAdm == 1)
            {
                admin.InvitarEmpresa(empresa1);
                goto entrada;
            } else if (accionesAdm == 2)
            {
                goto terminar;
            }
            else
            {
                Console.WriteLine("La opcion seleccionada no es correcta. Debe ingresar el valor numerico de forma correcta");
                goto entrada;
            }
            */

            // Rol empresa
            Console.WriteLine($"Bienvenido Empresa {empresa1.Nombre}: ");
            empresa1.AceptarInvitacion();
            EntradaEmp:
            Console.WriteLine("1- Crear oferta.\n2- Eliminar Oferta.\n3- Agregar Habilitación.\n4- Eliminar Habilitación.\n5- Ver habilitaciones. \n6- Salir.");

            int accionesEmp = Int32.Parse(Console.ReadLine());
            if (accionesEmp == 1)
            {
                Console.WriteLine("Indique nombre de publicación: ");
                string nombre = Console.ReadLine();
                Console.WriteLine("Indique material: ");
                string material = Console.ReadLine();
                Console.WriteLine("Indique material: ");
                int precio = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Indique unidad: ");
                string unidad = Console.ReadLine();
                Console.WriteLine("Indique etiquetas: ");
                string tags = Console.ReadLine();
                Console.WriteLine("Indique ubicación: ");
                string ubicacion = Console.ReadLine();
                empresa1.CrearProducto(publicaciones, nombre,  material,  precio,  unidad,  tags,  ubicacion ,new Guid());
                goto EntradaEmp;
            } else if (accionesEmp == 2)
            {
                StringBuilder delOferta = new StringBuilder("Ofertas: \n");
                int enumOfertas = 1;
                foreach (Oferta oferta in publicaciones.OfertasPublicados)
                {
                    delOferta.Append($"{enumOfertas}- {oferta.Nombre}, código {oferta.Id}.\n");
                    enumOfertas ++;
                }
                delOferta.Append("Que oferta desea eliminar. Indique la posición de la oferta.");
                Console.WriteLine(delOferta.ToString());
                int delOferta1 = Int32.Parse(Console.ReadLine());
                empresa1.EliminarProducto(publicaciones.OfertasPublicados[delOferta1-1], publicaciones);
                goto EntradaEmp;
            } else if (accionesEmp == 3)
            {   
                Console.WriteLine("Ingrese nombre de la habilitación:");
                string hab = Console.ReadLine();
                empresa1.AddHabilitacion(hab);
                goto EntradaEmp;
            } else if (accionesEmp == 4)
            {
               empresa1.GetHabilitacionList();
               Console.WriteLine("Indique que habilitación desea eliminar: ");
               int delHab = Int32.Parse(Console.ReadLine());
               empresa1.RemoveHabilitacion(empresa1.habilitacionesEmpresa[delHab-1]);
               goto EntradaEmp;
            } else if (accionesEmp == 5)
            {
                empresa1.GetHabilitacionList();
                goto EntradaEmp;
            } else if (accionesEmp == 6)
            {
                goto terminar;
            }
            else
            {
                Console.WriteLine("La opcion seleccionada no es correcta, por favor ingrese nuevamente.");
                goto EntradaEmp;
            }

            


            // Rol emprendedor
            Console.WriteLine($"Bienvenido emprendedor {emprendedor1.Nombre}: ");;
            EntradaEmpren:
            Console.WriteLine("1- Agregar Habilitaciones \n2- Eliminar Habilitaciones \n3- Ver habilitaciones \n4- Buscar Oferta por Tag \n5- Buscar Oferta por ubicación \n6- Buscar Oferta por Material \n7- Ver ofertas en que estoy interesado \n8- Calcular productos consumidos \n9 Salir");
            int accionesEmpren = Int32.Parse(Console.ReadLine());
            if (accionesEmpren == 1)
            {   
                Console.WriteLine("Ingrese nombre de la habilitación:");
                string hab = Console.ReadLine();
                empresa1.AddHabilitacion(hab);
                goto EntradaEmpren;
            } else if (accionesEmpren == 2)
            {
               empresa1.GetHabilitacionList();
               Console.WriteLine("Indique que habilitación desea eliminar: ");
               int delHab = Int32.Parse(Console.ReadLine());
               empresa1.RemoveHabilitacion(empresa1.habilitacionesEmpresa[delHab-1]);
               goto EntradaEmpren;
            } else if (accionesEmpren == 3)
            {
                empresa1.GetHabilitacionList();
                goto EntradaEmpren;
            } else if (accionesEmpren ==4)
            {
                string tagBusqueda = Console.ReadLine();
                emprendedor1.BuscarOfertasPorTag(publicaciones, tagBusqueda);
                goto EntradaEmpren;
            } else if (accionesEmpren == 5)
            {
                string ubicacionBusqueda = Console.ReadLine();
                emprendedor1.BuscarOfertasPorUbicacion(publicaciones, ubicacionBusqueda);
                goto EntradaEmpren;
            } else if (accionesEmpren == 6)
            {
                string materialBusqueda = Console.ReadLine();
                emprendedor1.BuscarOfertasPorMaterial(publicaciones, materialBusqueda);
                goto EntradaEmpren;
            } else if (accionesEmpren == 7)
            {
                // falta agregar esta parte
                goto EntradaEmpren;
            } else if (accionesEmpren == 8)
            {
                //falta la implementacion
                goto EntradaEmpren;
            } else if (accionesEmpren == 9)
            {   
                goto terminar;
            }
            else
            {
                Console.WriteLine("La opcion seleccionada no es correcta, por favor ingrese nuevamente.");
                goto EntradaEmp;
            }


            
            terminar:
            Console.WriteLine("El programa finalizo con exito. gracias por participar");
            Console.ReadKey();
        }
    }

}