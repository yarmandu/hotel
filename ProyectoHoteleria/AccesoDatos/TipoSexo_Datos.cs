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
    public class TipoSexo_Datos
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public IEnumerable<Sexo> Retrieve(MySqlConnection cn, Sexo Item)
        {
            List<Sexo> listatiposexo = null;
            cn = new MySqlConnection(msqlconnection);
            cn.Open();

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspTipoSexoListar",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            
            using (MySqlDataReader dtr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    listatiposexo = new List<Sexo>();
                    while (dtr.Read())
                    {
                        listatiposexo.Add(new Sexo
                        {
                            IdTipoSexo = !dtr.IsDBNull(dtr.GetOrdinal("idTipoSexo")) ? dtr.GetInt32(dtr.GetOrdinal("idTipoSexo")) : 0,
                            tipoSexo = !dtr.IsDBNull(dtr.GetOrdinal("tipoSexo")) ? dtr.GetString(dtr.GetOrdinal("tipoSexo")) : ""
                        });
                    }
                }

            }
            return listatiposexo;
        }
    }
}
