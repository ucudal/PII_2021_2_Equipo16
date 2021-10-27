using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public static class Publicaciones 
    {
        
        public static List<Producto> ProductosPublicados = new List<Producto>();
        // Por Creator 
        public static void AddProducto(string nombre, string material, int precio, string unidad, int cantidad, string tags, string ubicacion)
        {
            Producto producto = new Producto(nombre, material, precio, unidad, cantidad, tags, ubicacion);
            ProductosPublicados.Add(producto);
        }
        // Por Creator
        public static void RemoveProducto(string nombre, string material, int precio, string unidad, int cantidad, string tags, string ubicacion)
        {
            Producto producto = new Producto(nombre, material, precio, unidad, cantidad, tags, ubicacion);
            ProductosPublicados.Remove(producto);
        }
        public static void GetProductosPublicados()
        {
            StringBuilder getProductosPublicados = new StringBuilder("Productos: \n");
            foreach (Producto producto in ProductosPublicados)
            {
                getProductosPublicados.Append($"- {producto.Nombre}.");   
            }
            Console.WriteLine(getProductosPublicados.ToString());
        }
        public static Producto GetProducto(Producto producto)
        {
            ProductosPublicados.Remove(producto);
            return producto;
        }


        
    }
}
