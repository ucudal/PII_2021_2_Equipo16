using ClassLibrary;
using NUnit.Framework;

namespace Test.Library
{
    /// <summary>
    /// Esta clase permite testear todas los comportamientos que va a tener la clase LimpiadorCadenas
    /// Dicha clase lo que hace es tomar las cadenas de caracteres que el usuario
    /// de la aplicacion ingreso y las pasa a un tipo de cadena, que son las que se espera recibir,
    /// en minusculas, sin tildes y sin espacios accidentales.
    /// En el este caso trabaja tambien con numeros, los cuales no modifica.
    /// </summary>
    [TestFixture]
    public class LimpiadorCadenasTests
    {
        /// <summary>
        /// Este metodo permite testear la cadena "Ho lA" que fue ingresada por un Usuario
        /// como existen muchas formas de escribir la palabra "hola", tales como "Hola","HOLA","hola", etc. 
        /// Necesitamos alguna forma de poder trabajar con esa cadena, por lo cual utilizamos
        /// el método LimpiaCadena de la Clase LimpiadorCadenas.
        /// </summary>
        [Test]
        public void TestLimpiaCadena()
        {
            string cadena = "Hó lA";
            string expected = "hola";
            Assert.AreEqual(expected, LimpiadorCadenas.LimpiaCadena(cadena));
        }

        /// <summary>
        /// Este método de prueba permite comprobar que lo unico que se modifica aplicando el metodo LimpiaCadena
        /// son los caracteres alfabeticos, que en el caso de contener numeros, los mismos continuan estando tal como se ingresaron.
        /// </summary>
        [Test]
        public void TestLimpiaCadena2()
        {
            string cadena = "H0l4";
            string expected = "h0l4";
            Assert.AreEqual(expected, LimpiadorCadenas.LimpiaCadena(cadena));
        }

        /// <summary>
        /// Este test permite validar el método LimpiaCadenaRespuesta de la clase LimpiadorCadenas.
        /// En los ejemplos anteriores teniamos pruebas para cuando se ingresaba solo una palabra como Nombre, rubro, etc.
        /// Ahora con este método se permite evaluar acciones o respuestas del usuario. 
        /// para este test utilizaremos la cadena "Hola, COMO estás?" que contiene todos los elementos para testear.
        /// </summary>
        [Test]
        public void TestLimpiaCadenaRespuesta()
        {
            string cadena = "Hola, COMO estás?";
            string expected = "hola, como estas?";
            Assert.AreEqual(expected, LimpiadorCadenas.LimpiaCadenaRespuesta(cadena));
        }
    }
}