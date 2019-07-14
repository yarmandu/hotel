using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using Modelo_Entidades;
using System.Data;

namespace AccesoDatos
{
    public class TipoServicio_Datos
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public IEnumerable<TipoServicio> Retrieve(MySqlConnection cn, TipoServicio Item)
        {
            List<TipoServicio> listatipoDoc = null;
            cn = new MySqlConnection(msqlconnection);
            cn.Open();

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspTipoServicioListar",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };

            using (MySqlDataReader dtr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    listatipoDoc = new List<TipoServicio>();
                    while (dtr.Read())
                    {
                        listatipoDoc.Add(new TipoServicio
                        {
                            idtipoServicio = !dtr.IsDBNull(dtr.GetOrdinal("idTipoServicio")) ? dtr.GetInt32(dtr.GetOrdinal("idTipoServicio")) : 0,
                            tipoServicio = !dtr.IsDBNull(dtr.GetOrdinal("tipoServicio")) ? dtr.GetString(dtr.GetOrdinal("tipoServicio")) : ""
                        });
                    }
                }

            }
            return listatipoDoc;
        }
    }
}
