using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Administrador 
    {
        public List<Empresa> Empresas = new List<Empresa>();
        
        public void InvitarEmpresa(Empresa empresa)
        {
            this.Empresas.Add(empresa);
            
        }

        
        
    }
}

