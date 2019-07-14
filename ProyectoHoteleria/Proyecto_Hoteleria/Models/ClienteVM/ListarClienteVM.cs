using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo_Entidades;

namespace Proyecto_Hoteleria.Models
{
    public class ListarClienteVM
    {
        public Cliente Filtro { get; set; }
        public IEnumerable<Cliente> Elementos { get; set; }

        public ListarClienteVM(Cliente filtro, IEnumerable<Cliente> listaAgent)
        {
            Filtro = filtro;
            Elementos = listaAgent;
        }
    }
}