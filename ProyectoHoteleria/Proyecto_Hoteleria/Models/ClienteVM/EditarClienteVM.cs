using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo_Entidades;
using System.Web.Mvc;
using Proyecto_Hoteleria.App_Start.Extenciones;

namespace Proyecto_Hoteleria.Models
{
    public class EditarClienteVM
    {
        public Cliente Item { get; set; }
        public IEnumerable<SelectListItem> TipoDocumento { get; set; }
        public IEnumerable<SelectListItem> TipoSexo { get; set; }
        public IEnumerable<SelectListItem> TipoCliente { get; set; }
        public IEnumerable<SelectListItem> TipoResidencia { get; set; }

        public EditarClienteVM(Cliente item, IEnumerable<TipoDocumento> listadocumento, IEnumerable<Sexo> listaSexo, 
           IEnumerable<TipoCliente> listatipoCliente, IEnumerable<Residencia> listatipoResidencia)
        {
            Item = item;
            TipoDocumento = listadocumento.GenerarLista(true);
            TipoSexo = listaSexo.GenerarLista(true);
            TipoCliente = listatipoCliente.GenerarLista(true);
            TipoResidencia = listatipoResidencia.GenerarLista(true);
        }
    }
}