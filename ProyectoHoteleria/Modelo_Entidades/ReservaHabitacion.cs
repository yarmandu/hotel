using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Entidades
{
    public class ReservaHabitacion
    {
        public int      idReserva    {get;set;}
        public int IdHotel { get; set; }
        public int IdTipoDocumento { get; set; }
        public string descTipoDoc { get; set; }
        public int   cantHabitacion   {get;set;}
        public int idTipoHabitacion { get; set; }
        public string   tipoHabitacion   {get;set;}
        public DateTime   fechaInicio   {get;set;}
        public DateTime   fechaFin   {get;set;}
        public decimal   Precio    {get;set;}
        public decimal   precioTotal   {get;set;}
        public int   idtipoPago    {get;set;}
        public string tipoPago { get; set; }
        public decimal   total    {get;set;}
        public int   estado { get;set;}

        public string tipoDocumento { get; set; }
    }
}
