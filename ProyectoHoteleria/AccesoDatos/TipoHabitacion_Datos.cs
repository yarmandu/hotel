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
    public class TipoHabitacion_Datos
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public IEnumerable<TipoHabitacion> Retrieve(MySqlConnection cn, TipoHabitacion Item)
        {
            List<TipoHabitacion> listatipoDoc = null;
            cn = new MySqlConnection(msqlconnection);
            cn.Open();

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspTipoHabitacionListar",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };

            using (MySqlDataReader dtr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    listatipoDoc = new List<TipoHabitacion>();
                    while (dtr.Read())
                    {
                        listatipoDoc.Add(new TipoHabitacion
                        {
                            idTipoHabitacion = !dtr.IsDBNull(dtr.GetOrdinal("idtipoHabitacion")) ? dtr.GetInt32(dtr.GetOrdinal("idtipoHabitacion")) : 0,
                            tipoHabitacion = !dtr.IsDBNull(dtr.GetOrdinal("tipoHabitacion")) ? dtr.GetString(dtr.GetOrdinal("tipoHabitacion")) : ""
                        });
                    }
                }

            }
            return listatipoDoc;
        }
    }
}
