using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelo_Entidades;
using System.Web.Mvc;
using Proyecto_Hoteleria.App_Start.Extenciones;

namespace Proyecto_Hoteleria.Models
{
    public class EditarHabitacionVM
    {
        public Habitacion Item { get; set; }
        public IEnumerable<SelectListItem> TipoHabitacion { get; set; }
        public IEnumerable<SelectListItem> TipoServicio { get; set; }

        public EditarHabitacionVM(Habitacion item, IEnumerable<TipoHabitacion> listaHabitacion, IEnumerable<TipoServicio> listaServicio)
        {
            Item = item;
            TipoHabitacion = listaHabitacion.GenerarLista(true);
            TipoServicio = listaServicio.GenerarLista(true);
        }
    }
}