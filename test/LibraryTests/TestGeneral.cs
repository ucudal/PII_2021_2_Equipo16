using NUnit.Framework;
using ClassLibrary;
using System;
using System.Collections.Generic;

namespace Test.Library
{ 
    /// <summary>
    /// Clase de pruebas de TestGeneral
    /// </summary>
    [TestFixture]
    public class TestGeneral

    {
        [Test]
        public void TestGeneral1()
        {
            Logica logi1 = new Logica();
            
            Empresa  empresaConaprole = new Empresa("Conaprole", "Pakistan", new Rubro("textil"), new Habilitaciones());
            Emprendedor emprendedor1 = new Emprendedor("Lebron James", "Korea del Norte", new Rubro("textil"), new Habilitaciones(), "Decorado de interiores");

            Oferta ofertaDebug = new Oferta("Coca-Cola1", "Nix", 2000, "Litros", "bebidas", "Guyana Francesa", empresaConaprole);
            Logica.PublicacionesA.OfertasPublicados.Add(ofertaDebug);

            string expectedEmpresa = "Conaprole";
            string expectedEmprendedor = "Lebron James";

            // Quiero como empresa publicar varias oferta.

            LogicaEmpresa.CrearProducto(empresaConaprole, "Coca-cola", "Nix", 2000, "Litros", "bebidas", "Guyana Francesa");
            LogicaEmpresa.CrearProducto(empresaConaprole, "Coca-cola ZERO", "Nix", 2000, "Litros", "bebidas", "Guyana Francesa");
            LogicaEmpresa.CrearProducto(empresaConaprole, "Fiat 1", "El mejor de todos", 5500, "Cantidad", "auto", "Carrasco");

            int expectedPublicaciones = 4; // Esperado numero de ofertas en lista

            // Quiero como emprendedor buscar bebidas.
            // Al buscar por tags, deberian aparecer 2 opciones.

            LogicaBuscadores.BuscarPorTags("bebidas");

            // Se espera que se impriman las 2 ofertas

            // Quiero adquirir la oferta con nombre Coca-Cola

            List<int> lista = new List<int>();
            lista.Add(1);
            lista.Add(2);
            lista.Add(3);

            LogicaEmprendedor.InteresadoEnOferta(emprendedor1, "Coca-Cola1");

            // Quiero como empresa saber si se interesaron en alguna de mis ofertas

            int expectedInteresados = 1;

            
            

            Assert.AreEqual(expectedEmpresa, empresaConaprole.Nombre);
            Assert.AreEqual(expectedEmprendedor, emprendedor1.Nombre);
            Assert.AreEqual(expectedPublicaciones, Logica.PublicacionesA.OfertasPublicados.Count);
            Assert.AreEqual(expectedInteresados, empresaConaprole.InteresadosEnOfertas.Count);

            



        }
        



    }
}