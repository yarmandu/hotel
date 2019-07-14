using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Entidades
{
    public  class Habitacion
    {
        public int NroHanitacion         { get;set;}
        public int    idTipoHabitacion      { get;set;}
        public int    idtipoServicio        { get;set;}
        public decimal precio               { get;set;}
        public int cantCamas { get; set; }
                    
        //tipo habitacion    
        public string tipoHabitacion { get; set; }

        //tipo servicio
        public string tipoServicio { get; set; }
    }
}

