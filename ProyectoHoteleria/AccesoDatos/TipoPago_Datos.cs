using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo_Entidades;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace AccesoDatos
{
    public class TipoPago_Datos
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public IEnumerable<TipoPago> Retrieve(MySqlConnection cn, TipoPago Item)
        {
            List<TipoPago> listapago = null;
            cn = new MySqlConnection(msqlconnection);
            cn.Open();

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspTipoPagoListar",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };

            using (MySqlDataReader dtr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    listapago = new List<TipoPago>();
                    while (dtr.Read())
                    {
                        listapago.Add(new TipoPago
                        {
                            idtipoPago = !dtr.IsDBNull(dtr.GetOrdinal("idtipoPago")) ? dtr.GetInt32(dtr.GetOrdinal("idtipoPago")) : 0,
                            tipoPago = !dtr.IsDBNull(dtr.GetOrdinal("tipoPago")) ? dtr.GetString(dtr.GetOrdinal("tipoPago")) : ""
                        });
                    }
                }

            }
            return listapago;
        }
    }
}
