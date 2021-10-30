using System;
using System.Collections.Generic;
using System.Text;


namespace ClassLibrary
{
   public interface IBuscador
    {
         Oferta Buscar(Publicaciones publicaciones, string busqueda);
       
        
    }

}

