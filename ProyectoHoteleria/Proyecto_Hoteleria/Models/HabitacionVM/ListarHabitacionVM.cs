using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo_Entidades;
using Proyecto_Hoteleria.App_Start.Extenciones;
using System.Web.Mvc;

namespace Proyecto_Hoteleria.Models
{
    public class ListarHabitacionVM
    {
        public Habitacion Filtro { get; set; }
        public IEnumerable<Habitacion> Elementos { get; set; }
        public IEnumerable<SelectListItem> TipoHabitacion { get; set; }
        public IEnumerable<SelectListItem> TipoServicio { get; set; }

        public ListarHabitacionVM(Habitacion filtro, IEnumerable<Habitacion> listaHabitacion, IEnumerable<TipoHabitacion> listaHabitaciones, IEnumerable<TipoServicio> listaServicio)
        {
            Filtro = filtro;
            Elementos = listaHabitacion;
            TipoHabitacion = listaHabitaciones.GenerarLista(true);
            TipoServicio = listaServicio.GenerarLista(true);
        }
    }
}