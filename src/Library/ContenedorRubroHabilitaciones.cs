using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor que tiene Lista de rubros y habilitaciones posibles para el cliente.
    /// Se usa el patrón Singleton ya que así podemos tener una única instancia de esta clase y evitar tener métodos estáticos,
    /// con el fin de hacer más rígido el programa.
    /// Por otra parte también se utiliza el patrón Expert.
    /// /// </summary>
    public class ContenedorRubroHabilitaciones
    {
        private ContenedorRubroHabilitaciones()
        {

        }
        private static ContenedorRubroHabilitaciones instancia;

        /// <summary>
        /// Méotdo de acceso static, para poder obetener la instancia o en su defecto crearla si no existe.
        /// </summary>
        /// <value></value>
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

        /// <summary>
        /// Lista que contiene las habilitaciones disponibles para el cliente.
        /// </summary>
        /// <value></value>
        public List<Habilitaciones> ListaHabilitaciones { get => listaHabilitaciones;}

        /// <summary>
        /// Lista que contiene los rubros disponibles para el cliente.
        /// </summary>
        /// <value></value>
        public List<Rubro> ListaRubros { get => listaRubros;}
        
        /// <summary>
        /// Método agregado para poder chequear si el rubro que se ingresa, existe en la lista de los rubros disponibles.
        /// </summary>
        /// <param name="rubroString"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método que se encarga de retornar un rubro, si el Rubro.Nombre es igual al pasado por parametros.
        /// </summary>
        /// <param name="rubroString"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Método agregado para poder chequear la habilitación que se ingresa, existe en la lista de las habilitaciones disponibles.
        /// </summary>
        /// <param name="habilitacionString"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método que se encarga de retornar una habilitación, si la Habilitacion.Nombre es igual al pasado por parametros.
        /// </summary>
        /// <param name="habilitacionString"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Método que se encarga de retornar los nombres(string) de las habilitaciones que están la lista de habilitaciones.
        /// </summary>
        /// <returns></returns>
        public string textoListaHabilitaciones()
        {
            StringBuilder texto = new StringBuilder();
            foreach (Habilitaciones item in this.listaHabilitaciones)
            {
                texto.Append($"-{item.Nombre}\n");
            }
            return texto.ToString();
        }

        /// <summary>
        /// Método que se encarga de retornar los nombres(string) de los rubros que están la lista de rubros.
        /// </summary>
        /// <returns></returns>
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