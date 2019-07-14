using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo_Entidades;
using System.Web.Mvc;
using Proyecto_Hoteleria.App_Start.Extenciones;

namespace Proyecto_Hoteleria.Models.ReservaVM
{
    public class ListarReservaVM
    {
        public ReservaHabitacion Filtro { get; set; }
        public IEnumerable<ReservaHabitacion> Elementos { get; set; }
        public IEnumerable<SelectListItem> TipoPago { get; set; }
        public IEnumerable<SelectListItem> TipoHabitacion { get; set; }

        public ListarReservaVM(ReservaHabitacion filtro, IEnumerable<ReservaHabitacion> listaReservaHabitacion, 
            IEnumerable<TipoPago> listaPago, IEnumerable<TipoHabitacion> listaHabitaciones)
        {
            Filtro = filtro;
            Elementos = listaReservaHabitacion;
            TipoPago = listaPago.GenerarLista(true);
            TipoHabitacion = listaHabitaciones.GenerarLista(true);
        }
    }
}