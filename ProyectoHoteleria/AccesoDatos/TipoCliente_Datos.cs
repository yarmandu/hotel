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
    public class TipoCliente_Datos
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public IEnumerable<TipoCliente> Retrieve(MySqlConnection cn, TipoCliente Item)
        {
            List<TipoCliente> listatipocliente = null;
            cn = new MySqlConnection(msqlconnection);
            cn.Open();

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspTipoClienteListar",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            
            using (MySqlDataReader dtr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    listatipocliente = new List<TipoCliente>();
                    while (dtr.Read())
                    {
                        listatipocliente.Add(new TipoCliente
                        {
                            IdTipoCliente = !dtr.IsDBNull(dtr.GetOrdinal("idTipoClientes")) ? dtr.GetInt32(dtr.GetOrdinal("idTipoClientes")) : 0,
                            tipoCliente = !dtr.IsDBNull(dtr.GetOrdinal("tipoCliente")) ? dtr.GetString(dtr.GetOrdinal("tipoCliente")) : ""
                        });
                    }
                }

            }
            return listatipocliente;
        }

    }
}
