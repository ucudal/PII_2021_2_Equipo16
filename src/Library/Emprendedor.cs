using System;
using System.Collections.Generic;
using System.Text;


namespace ClassLibrary
{
    //Crear lista de ofertas por fuera de metodos
    //Crear metodo impresion de lista
    //a los metodos de busqueda, clean al principio de lista
    //llamar a metodo impresion dentro de buscadores para verlas graficamente
    //en interesadoenoferta, chequear si la lista de ofertas tiene la oferta que busco
    //concatenar con nombre de emprendedor(temporal)
    public class Emprendedor : Usuario, IHabilitaciones
    {
        public List<Habilitaciones> Habilitaciones = new List<Habilitaciones>();
        private string especializaciones;
        public Emprendedor(string nombre, string ubicacion, Rubro rubro, string especializaciones)
            :base(nombre, ubicacion, rubro)
        {
            
            this.Especializaciones = especializaciones;
        }
        
        public string Especializaciones {get; set;}
        private List<Oferta> ofertasAceptadas = new List<Oferta>();
        // Por Creator
        public void AddHabilitacion(string nombre)
        {
            Habilitaciones habilitacion = new Habilitaciones(nombre);
            this.Habilitaciones.Add(habilitacion);
            Console.WriteLine($"Habilitación '{habilitacion.Nombre}' agregada exitosamente.");
        }
        public void RemoveHabilitacion(string nombre)
        {
            Habilitaciones habilitacion = new Habilitaciones(nombre);
            this.Habilitaciones.Remove(habilitacion);
            Console.WriteLine( $"Habilitación '{habilitacion.Nombre}' eliminada exitosamente.");
        }
        
        public void GetHabilitacionList()
        {
            StringBuilder getHabilitaciones = new StringBuilder("Habilitaciones: \n");
            foreach (Habilitaciones habilitacion in Habilitaciones)
            {
                getHabilitaciones.Append($"- {habilitacion.Nombre}.");   
            }
            Console.WriteLine(getHabilitaciones.ToString());
        }
        public List <Oferta> BuscarOfertasPorTag(Publicaciones publicaciones, string tag)
        {
            List<Oferta> resultado = new List<Oferta>();
            BuscadorTags buscador = new BuscadorTags();
            foreach(Oferta oferta in buscador.Buscar(publicaciones, tag))
            {
                resultado.Add(oferta);
            }
            return resultado;
        }

        public List<Oferta> BuscarOfertasPorUbicacion(Publicaciones publicaciones, string ubicacion)
        {
            List<Oferta> resultado = new List<Oferta>();
            BuscadorUbicacion buscador = new BuscadorUbicacion();
            foreach(Oferta oferta in buscador.Buscar(publicaciones, ubicacion))
            {
                resultado.Add(oferta);
            }
            return resultado;
        }

        //buscar justificar (patron)
        public List<Oferta> BuscarOfertasPorMaterial(Publicaciones publicaciones, string material)
        {
            List<Oferta> resultado = new List<Oferta>();
            BuscadorMaterial buscador = new BuscadorMaterial();
            foreach(Oferta oferta in buscador.Buscar(publicaciones, material))
            {
                resultado.Add(oferta);
            }
            return resultado;
        }
        
        public void InteresadoEnOferta(Oferta oferta) //
        {
            
        }
        public int CalcularMaterialesConsumidosSegunTiempo() //lista ofertas compradas cada vez que compro se agrega una, me fijo por fecha
        {
            return 0; //modificar
        }


    }
}
