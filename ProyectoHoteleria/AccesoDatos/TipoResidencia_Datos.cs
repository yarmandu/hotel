using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Modelo_Entidades;
using System.Configuration;
using System.Data;

namespace AccesoDatos
{
    public class TipoResidencia_Datos
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public IEnumerable<Residencia> Retrieve(MySqlConnection cn, Residencia Item)
        {
            List<Residencia> listatiporesidencia = null;
            cn = new MySqlConnection(msqlconnection);
            cn.Open();

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspTipoResidenciaListar",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };

            using (MySqlDataReader dtr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    listatiporesidencia = new List<Residencia>();
                    while (dtr.Read())
                    {
                        listatiporesidencia.Add(new Residencia
                        {
                            IdTipoResidencia = !dtr.IsDBNull(dtr.GetOrdinal("idTipoResidencia")) ? dtr.GetInt32(dtr.GetOrdinal("idTipoResidencia")) : 0,
                            tipoResidencia = !dtr.IsDBNull(dtr.GetOrdinal("tipoResidencia")) ? dtr.GetString(dtr.GetOrdinal("tipoResidencia")) : ""
                        });
                    }
                }

            }
            return listatiporesidencia;
        }
    }
}
