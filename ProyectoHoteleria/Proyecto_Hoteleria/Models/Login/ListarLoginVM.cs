using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo_Entidades;

namespace Proyecto_Hoteleria.Models.Login
{
    public class ListarLoginVM
    {        
            public Modelo_Entidades.Login Filtro { get; set; }
            public IEnumerable<Modelo_Entidades.Login> Elementos { get; set; }

            public ListarLoginVM(Modelo_Entidades.Login filtro, IEnumerable<Modelo_Entidades.Login> listaLogin_User)
            {
                Filtro = filtro;
                Elementos = listaLogin_User;

            }
        

    }
}