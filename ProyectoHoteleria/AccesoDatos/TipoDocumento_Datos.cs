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
    public class TipoDocumento_Datos
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public IEnumerable<TipoDocumento> Retrieve(MySqlConnection cn, TipoDocumento Item)
        {
            List<TipoDocumento> listatipoDoc = null;
            cn = new MySqlConnection(msqlconnection);
            cn.Open();

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspTipoDocumentoListar",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            
            using (MySqlDataReader dtr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    listatipoDoc = new List<TipoDocumento>();
                    while (dtr.Read())
                    {
                        listatipoDoc.Add(new TipoDocumento
                        {
                            IdTipoDocumento = !dtr.IsDBNull(dtr.GetOrdinal("idTipoDocumento")) ? dtr.GetInt32(dtr.GetOrdinal("idTipoDocumento")) : 0,
                            tipoDocumento = !dtr.IsDBNull(dtr.GetOrdinal("tipoDocumento")) ? dtr.GetString(dtr.GetOrdinal("tipoDocumento")) : ""
                        });
                    }
                }

            }
            return listatipoDoc;
        }

    }
}
