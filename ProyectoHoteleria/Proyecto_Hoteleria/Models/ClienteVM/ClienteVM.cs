using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto_Hoteleria.Models
{
    public class ClienteVM
    {
        public int IdCliente { get; set; }
        public int IdTipoDocumento { get; set; }
        public string descTipoDoc { get; set; }
        public string Nombres { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdTipoSexo { get; set; }
        public int IdTipoCliente { get; set; }
        public int IdTipoResidencia { get; set; }
        public int estado { get; set; }
    }
}