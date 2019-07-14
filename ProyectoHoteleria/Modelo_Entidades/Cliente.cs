using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_Entidades
{
    public class Cliente
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

        //tipocliente
        
        public string tipoCliente { get; set; }
        //Sexo
        public string tipoSexo { get; set; }

        //tipo Residencia
        
        public string tipoResidencia { get; set; }

        //tipo documentto
        
        public string tipoDocumento { get; set; }

    }
}
