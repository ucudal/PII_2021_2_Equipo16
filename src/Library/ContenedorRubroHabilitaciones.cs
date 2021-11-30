using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Contenedor que tiene Lista de rubros y habilitaciones posibles para el cliente.
    /// Se usa el patrón Singleton ya que así podemos tener una única instancia de esta clase y evitar tener métodos estáticos,
    /// con el fin de hacer más rígido el programa.
    /// Por otra parte también se utiliza el patrón Expert.
    /// /// </summary>
    public class ContenedorRubroHabilitaciones: IJsonConvertible
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonConstructor]
        public ContenedorRubroHabilitaciones()
        {

        }

       /// <summary>
       /// Constructor sin parametros de la clase ContenedorRubroHabilitaciones, ya que es esencial el atributo JsonConstructor
       /// para la serialización de datos en la clase.
       /// </summary>
       /// <returns></returns>
        [JsonInclude]
        public List<Rubro> ListaRubros {get; set;} = new List<Rubro>()
        {
            new Rubro("textil"),
            new Rubro("metalurgia"),
            new Rubro("deportes"),
        };

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [JsonInclude]

        public List<Habilitaciones> ListaHabilitaciones {get; set;} = new List<Habilitaciones>()
        {
            new Habilitaciones("apa"),
            new Habilitaciones("iso"),
            new Habilitaciones("soa"),
        };

        
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
            foreach (Habilitaciones item in this.ListaHabilitaciones)
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
            foreach (Rubro item in this.ListaRubros)
            {
                texto.Append($"-{item.Nombre}\n");
            }
            return texto.ToString();
        }

        /// <summary>
        /// Crea un rubro y lo agrega a la lista de rubros.
        /// </summary>
        /// <param name="nombreRubro"></param>
        public void CrearRubro(string nombreRubro)
        {
            Rubro rubro = new Rubro(nombreRubro);
            this.ListaRubros.Add(rubro);
        }
        
        /// <summary>
        /// Crea una habilitacion y la agrega a la lista de habilitaciones.
        /// </summary>
        /// <param name="nombreHabilitacion"></param>
        public void CrearHabilitacion(string nombreHabilitacion)
        {
            Habilitaciones hab = new Habilitaciones(nombreHabilitacion);
            this.ListaHabilitaciones.Add(hab);
        }
        
        /// <summary>
        /// Metodo que utiliza gracias a la interfaz IJsonConvertible para convertir a formato Json y aplicar en persistencia. 
        /// </summary>
        /// <returns></returns>
        public string ConvertirJson()
        {
            JsonSerializerOptions opciones = new()
            {
                WriteIndented = true,
                ReferenceHandler = MyReferenceHandler.Instance,
            };

            return JsonSerializer.Serialize(this, opciones);
        }
    }
}