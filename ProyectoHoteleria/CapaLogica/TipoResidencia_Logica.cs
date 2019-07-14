using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo_Entidades;
using MySql.Data.MySqlClient;
using AccesoDatos;
using System.Configuration;

namespace CapaLogica
{
    public class TipoResidencia_Logica
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public IEnumerable<Residencia> Retrieve(Residencia Item)
        {
            IEnumerable<Residencia> ltipoResidencia = null;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(msqlconnection))
                {
                    cn.Open();
                    TipoResidencia_Datos otipoResidenciaDatos = new TipoResidencia_Datos();
                    ltipoResidencia = otipoResidenciaDatos.Retrieve(cn, Item);
                }
            }
            catch (Exception ex)
            {
                ltipoResidencia = null;
                throw ex;
            }

            return ltipoResidencia;
        }

    }
}
