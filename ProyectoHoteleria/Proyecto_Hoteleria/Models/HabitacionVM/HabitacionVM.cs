using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Hoteleria.Models
{
    public class HabitacionVM
    {
        public int NroHanitacion { get; set; }
        public int idTipoHabitacion { get; set; }
        public int idtipoServicio { get; set; }
        public decimal precio { get; set; }
        public int cantCamas { get; set; }

        //tipo habitacion    
        public string tipoHabitacion { get; set; }

        //tipo servicio
        public string tipoServicio { get; set; }
    }
}