using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo_Entidades;
using System.Web.Mvc;
using Proyecto_Hoteleria.App_Start.Extenciones;

namespace Proyecto_Hoteleria.Models.ReservaVM
{
    public class EditarReservaVM
    {
        public ReservaHabitacion Item { get; set; }
        public IEnumerable<SelectListItem> TipoDocumentos { get; set; }
        public IEnumerable<SelectListItem> TipoPago { get; set; }
        public IEnumerable<SelectListItem> TipoHabitacion { get; set; }

        public EditarReservaVM(ReservaHabitacion item, IEnumerable<TipoPago> listaPago, IEnumerable<TipoHabitacion> listaHabitacion, 
            IEnumerable<TipoDocumento> listadocumento)
        {
            Item = item;
            TipoDocumentos = listadocumento.GenerarLista(true); 
            TipoPago = listaPago.GenerarLista(true);
            TipoHabitacion = listaHabitacion.GenerarLista(true);
        }
    }
}