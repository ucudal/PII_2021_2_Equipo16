using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class ContenedorRubroHabilitaciones
    {
        private ContenedorRubroHabilitaciones()
        {

        }
        private static ContenedorRubroHabilitaciones instancia;

        public static ContenedorRubroHabilitaciones Instancia
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ContenedorRubroHabilitaciones();
                }

                return instancia;
            }
        }


        private List<Rubro> listaRubros = new List<Rubro>()
        {
            new Rubro("textil"),
            new Rubro("metalurgia"),
            new Rubro("deportes"),
        };

        private List<Habilitaciones> listaHabilitaciones = new List<Habilitaciones>()
        {
            new Habilitaciones("apa"),
            new Habilitaciones("iso"),
            new Habilitaciones("soa"),
        };

        public List<Habilitaciones> ListaHabilitaciones { get => listaHabilitaciones;}
        public List<Rubro> ListaRubros { get => listaRubros;}
        

        public bool ChequearRubro(string rubroString)
        {
            foreach (Rubro rubro in this.ListaRubros)
            {
                if (rubro.Nombre == rubroString)
                {
                    return true;
                }
            }
            return false;
        }
        public Rubro GetRubro(string rubroString)
        {
            foreach (Rubro rubro in this.ListaRubros)
            {
                if (rubro.Nombre == rubroString)
                {
                    return rubro;
                }
            }
            return null;
        }

        public bool ChequearHabilitacion(string habilitacionString)
        {
            foreach (Habilitaciones hab in this.ListaHabilitaciones)
            {
                if (hab.Nombre == habilitacionString)
                {
                    return true;
                }
            }
            return false;
        }

        public Habilitaciones GetHabilitacion(string habilitacionString)
        {
            foreach (Habilitaciones hab in this.ListaHabilitaciones)
            {
                if (hab.Nombre == habilitacionString)
                {
                    return hab;
                }
            }
            return null;
        }

        public string textoListaHabilitaciones()
        {
            StringBuilder texto = new StringBuilder();
            foreach (Habilitaciones item in this.listaHabilitaciones)
            {
                texto.Append($"-{item.Nombre}\n");
            }
            return texto.ToString();
        }

        public string textoListaRubros()
        {
            StringBuilder texto = new StringBuilder();
            foreach (Rubro item in this.listaRubros)
            {
                texto.Append($"-{item.Nombre}\n");
            }
            return texto.ToString();
        }
    }
}