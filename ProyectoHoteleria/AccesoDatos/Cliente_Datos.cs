using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Modelo_Entidades;
using System.Data;

namespace AccesoDatos
{
    public class Cliente_Datos
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public int Insert(MySqlConnection cn, Cliente Item)
        {
            cn = new MySqlConnection(msqlconnection);
            int rpta = -1;

            cn.Open();

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspClienteInsertar",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };

            MySqlParameter param1 = cmd.Parameters.AddWithValue("v_IdCliente", Item.IdCliente);
            param1.Direction = ParameterDirection.Input;
            MySqlParameter param2 = cmd.Parameters.AddWithValue("v_IdTipoDocumento", Item.IdTipoDocumento);
            param2.Direction = ParameterDirection.Input;
            MySqlParameter param3 = cmd.Parameters.AddWithValue("v_descTipoDoc", Item.descTipoDoc ?? "");
            param3.Direction = ParameterDirection.Input;
            MySqlParameter param4 = cmd.Parameters.AddWithValue("v_Nombres", Item.Nombres ?? "");
            param4.Direction = ParameterDirection.Input;
            MySqlParameter param5 = cmd.Parameters.AddWithValue("v_ApePaterno", Item.ApePaterno ?? "");
            param5.Direction = ParameterDirection.Input;
            MySqlParameter param6 = cmd.Parameters.AddWithValue("v_ApeMaterno", Item.ApeMaterno ?? "");
            param6.Direction = ParameterDirection.Input;
            MySqlParameter param7 = cmd.Parameters.AddWithValue("v_Direccion", Item.Direccion ?? "");
            param7.Direction = ParameterDirection.Input;
            MySqlParameter param8 = cmd.Parameters.AddWithValue("v_Telefono", Item.Telefono ?? "");
            param8.Direction = ParameterDirection.Input;
            MySqlParameter param9 = cmd.Parameters.AddWithValue("v_IdTipoSexo", Item.IdTipoSexo);
            param9.Direction = ParameterDirection.Input;
            MySqlParameter param10 = cmd.Parameters.AddWithValue("v_IdTipoCliente", Item.IdTipoCliente);
            param10.Direction = ParameterDirection.Input;
            MySqlParameter param11 = cmd.Parameters.AddWithValue("v_IdTipoResidencia", Item.IdTipoResidencia);
            param11.Direction = ParameterDirection.Input;

            rpta =  cmd.ExecuteNonQuery();
            
            return rpta;

        }

        public IEnumerable<Cliente> Retrieve(MySqlConnection cn, Cliente Item)
        {            
            List<Cliente> listaCliente = null;
            cn = new MySqlConnection(msqlconnection);
            cn.Open();

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspClienteListar",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };

            MySqlParameter param1 = cmd.Parameters.AddWithValue("v_descTipoDoc", Item.descTipoDoc ?? "");
            param1.Direction = ParameterDirection.Input;

            using (MySqlDataReader dtr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    listaCliente = new List<Cliente>();
                    while (dtr.Read())
                    {
                        listaCliente.Add(new Cliente
                        {
                            IdCliente = !dtr.IsDBNull(dtr.GetOrdinal("IdCliente")) ? dtr.GetInt32(dtr.GetOrdinal("IdCliente")) : 0,
                            descTipoDoc = !dtr.IsDBNull(dtr.GetOrdinal("descTipoDoc")) ? dtr.GetString(dtr.GetOrdinal("descTipoDoc")) : "",
                            Nombres = !dtr.IsDBNull(dtr.GetOrdinal("Nombres")) ? dtr.GetString(dtr.GetOrdinal("Nombres")) : "",
                            ApePaterno = !dtr.IsDBNull(dtr.GetOrdinal("ApePaterno")) ? dtr.GetString(dtr.GetOrdinal("ApePaterno")) : "",
                            ApeMaterno = !dtr.IsDBNull(dtr.GetOrdinal("ApeMaterno")) ? dtr.GetString(dtr.GetOrdinal("ApeMaterno")) : "",
                            Direccion = !dtr.IsDBNull(dtr.GetOrdinal("Direccion")) ? dtr.GetString(dtr.GetOrdinal("Direccion")) : "",
                            Telefono = !dtr.IsDBNull(dtr.GetOrdinal("telefono")) ? dtr.GetString(dtr.GetOrdinal("telefono")) : "",
                            IdTipoCliente = !dtr.IsDBNull(dtr.GetOrdinal("IdTipoCliente")) ? dtr.GetInt32(dtr.GetOrdinal("IdTipoCliente")) : 0,
                            tipoCliente = !dtr.IsDBNull(dtr.GetOrdinal("tipoCliente")) ? dtr.GetString(dtr.GetOrdinal("tipoCliente")) : "",
                            IdTipoResidencia = !dtr.IsDBNull(dtr.GetOrdinal("IdTipoResidencia")) ? dtr.GetInt32(dtr.GetOrdinal("IdTipoResidencia")) : 0,
                            tipoResidencia = !dtr.IsDBNull(dtr.GetOrdinal("tipoResidencia")) ? dtr.GetString(dtr.GetOrdinal("tipoResidencia")) : ""
                        });
                    }
                }
            }
            return listaCliente;
        }

        public Cliente Find(MySqlConnection Cn, Cliente Item)
        {
            Cliente oCliente = null;
            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspClienteEditar",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            MySqlParameter param1 = cmd.Parameters.AddWithValue("v_IdCliente", Item.IdCliente);
            param1.Direction = ParameterDirection.Input;

            using (MySqlDataReader dtr =  cmd.ExecuteReader())
            {
                if (dtr != null)
                {
                    oCliente = new Cliente();
                    while (dtr.Read())
                    {
                        oCliente = (new Cliente
                        {
                            IdCliente = !dtr.IsDBNull(dtr.GetOrdinal("IdCliente")) ? dtr.GetInt32(dtr.GetOrdinal("IdCliente")) : 0,
                            IdTipoDocumento= !dtr.IsDBNull(dtr.GetOrdinal("idTipoDocumento")) ? dtr.GetInt32(dtr.GetOrdinal("idTipoDocumento")) : 0,
                            tipoDocumento = !dtr.IsDBNull(dtr.GetOrdinal("tipoDocumento")) ? dtr.GetString(dtr.GetOrdinal("tipoDocumento")) : "",
                            descTipoDoc = !dtr.IsDBNull(dtr.GetOrdinal("descTipoDoc")) ? dtr.GetString(dtr.GetOrdinal("descTipoDoc")) : "",
                            Nombres = !dtr.IsDBNull(dtr.GetOrdinal("Nombres")) ? dtr.GetString(dtr.GetOrdinal("Nombres")) : "",
                            ApePaterno = !dtr.IsDBNull(dtr.GetOrdinal("ApePaterno")) ? dtr.GetString(dtr.GetOrdinal("ApePaterno")) : "",
                            ApeMaterno = !dtr.IsDBNull(dtr.GetOrdinal("ApeMaterno")) ? dtr.GetString(dtr.GetOrdinal("ApeMaterno")) : "",
                            Direccion = !dtr.IsDBNull(dtr.GetOrdinal("Direccion")) ? dtr.GetString(dtr.GetOrdinal("Direccion")) : "",
                            Telefono = !dtr.IsDBNull(dtr.GetOrdinal("telefono")) ? dtr.GetString(dtr.GetOrdinal("telefono")) : "",
                            IdTipoSexo = !dtr.IsDBNull(dtr.GetOrdinal("IdTipoSexo")) ? dtr.GetInt32(dtr.GetOrdinal("IdTipoSexo")) : 0,
                            IdTipoCliente = !dtr.IsDBNull(dtr.GetOrdinal("IdTipoCliente")) ? dtr.GetInt32(dtr.GetOrdinal("IdTipoCliente")) : 0,
                            tipoCliente = !dtr.IsDBNull(dtr.GetOrdinal("tipoCliente")) ? dtr.GetString(dtr.GetOrdinal("tipoCliente")) : "",
                            IdTipoResidencia = !dtr.IsDBNull(dtr.GetOrdinal("IdTipoResidencia")) ? dtr.GetInt32(dtr.GetOrdinal("IdTipoResidencia")) : 0,
                            tipoResidencia = !dtr.IsDBNull(dtr.GetOrdinal("tipoResidencia")) ? dtr.GetString(dtr.GetOrdinal("tipoResidencia")) : "",
                            tipoSexo = !dtr.IsDBNull(dtr.GetOrdinal("tipoSexo")) ? dtr.GetString(dtr.GetOrdinal("tipoSexo")) : ""
                        });
                    }
                }

            }
            return oCliente;
        }
        public int Delete(MySqlConnection Cn, Cliente Item)
        {
            int rpta = -1;
            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspClienteEliminar",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            MySqlParameter param1 = cmd.Parameters.AddWithValue("v_IdCliente", Item.IdCliente);
            param1.Direction = ParameterDirection.Input;
            rpta = cmd.ExecuteNonQuery();
            return rpta;
        }

    }
}
