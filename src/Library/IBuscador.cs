using System;
using System.Collections.Generic;
using System.Text;


namespace ClassLibrary
{
     /// <summary>
     /// Interfaz IBuscador que define el metodo a implementar por las clases de busqueda
     /// </summary>
   public interface IBuscador
    {
         /// <summary>
         /// Interfaz IBuscador
         /// </summary>
         /// <param name="publicaciones">Recibe parametro del tipo Publicaciones </param>
         /// <param name="busqueda"> Recibe parametro del tipo string </param>
         /// <returns></returns>
         List<Oferta> Buscar(Publicaciones publicaciones, string busqueda);
       
        
    }

}

