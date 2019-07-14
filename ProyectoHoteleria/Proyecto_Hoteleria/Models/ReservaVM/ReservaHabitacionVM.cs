using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Hoteleria.Models.ReservaVM
{
    public class ReservaHabitacionVM
    {
        public int idReserva { get; set; }
        public string dniCliente { get; set; }
        public int cantHabitacion { get; set; }
        public int codHabitacion { get; set; }
        public int idTipoHabitacion { get; set; }
        public string tipoHabitacion { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public decimal Precio { get; set; }
        public decimal precioTotal { get; set; }
        public int idtipoPago { get; set; }
        public string tipoPago { get; set; }
        public decimal total { get; set; }
        public int estado { get; set; }
    }
}