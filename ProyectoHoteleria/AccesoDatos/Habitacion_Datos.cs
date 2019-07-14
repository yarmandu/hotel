using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using Modelo_Entidades;

namespace AccesoDatos
{
    public class Habitacion_Datos
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public int Insert(MySqlConnection cn, Habitacion Item)
        {
            cn = new MySqlConnection(msqlconnection);
            int rpta = -1;

            cn.Open();

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspinsertarHabitacion",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };

            MySqlParameter param1 = cmd.Parameters.AddWithValue("v_NroHabitacion", Item.NroHanitacion);
            param1.Direction = ParameterDirection.Input;
            MySqlParameter param2 = cmd.Parameters.AddWithValue("v_idTipoHabitacion", Item.idTipoHabitacion);
            param2.Direction = ParameterDirection.Input;
            MySqlParameter param3 = cmd.Parameters.AddWithValue("v_idtipoServicio", Item.idtipoServicio);
            param3.Direction = ParameterDirection.Input;
            MySqlParameter param4 = cmd.Parameters.AddWithValue("v_precio", Item.precio);
            param4.Direction = ParameterDirection.Input;
            MySqlParameter param5 = cmd.Parameters.AddWithValue("v_cantCamas", Item.cantCamas);
            param5.Direction = ParameterDirection.Input;

            rpta = cmd.ExecuteNonQuery();

            return rpta;

        }

        public IEnumerable<Habitacion> Retrieve(MySqlConnection cn, Habitacion Item)
        {
            List<Habitacion> listaHabitacion = null;
            cn = new MySqlConnection(msqlconnection);
            cn.Open();

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspHabitacionListar",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };

            MySqlParameter param1 = cmd.Parameters.AddWithValue("v_idtipohabitacion", Item.idTipoHabitacion);
            param1.Direction = ParameterDirection.Input;
            MySqlParameter param2 = cmd.Parameters.AddWithValue("v_idtiposervicio", Item.idtipoServicio);
            param2.Direction = ParameterDirection.Input;
            MySqlParameter param3 = cmd.Parameters.AddWithValue("v_precio", Item.precio);
            param3.Direction = ParameterDirection.Input;
            MySqlParameter param4 = cmd.Parameters.AddWithValue("v_cantCama", Item.cantCamas);
            param4.Direction = ParameterDirection.Input;

            using (MySqlDataReader dtr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    listaHabitacion = new List<Habitacion>();
                    while (dtr.Read())
                    {
                        listaHabitacion.Add(new Habitacion
                        {
                            NroHanitacion = !dtr.IsDBNull(dtr.GetOrdinal("nroHabitacion")) ? dtr.GetInt32(dtr.GetOrdinal("nroHabitacion")) : 0,
                            idTipoHabitacion = !dtr.IsDBNull(dtr.GetOrdinal("idtipoHabitacion")) ? dtr.GetInt32(dtr.GetOrdinal("idtipoHabitacion")) : 0,
                            tipoHabitacion = !dtr.IsDBNull(dtr.GetOrdinal("tipoHabitacion")) ? dtr.GetString(dtr.GetOrdinal("tipoHabitacion")) : "",
                            idtipoServicio = !dtr.IsDBNull(dtr.GetOrdinal("idtiposervicio")) ? dtr.GetInt32(dtr.GetOrdinal("idtiposervicio")) : 0,
                            tipoServicio = !dtr.IsDBNull(dtr.GetOrdinal("tiposervicio")) ? dtr.GetString(dtr.GetOrdinal("tiposervicio")) : "",
                            precio = !dtr.IsDBNull(dtr.GetOrdinal("precio")) ? dtr.GetDecimal(dtr.GetOrdinal("precio")) : 0,
                            cantCamas = !dtr.IsDBNull(dtr.GetOrdinal("cantCama")) ? dtr.GetInt32(dtr.GetOrdinal("cantCama")) : 0
                        });
                    }
                }
            }
            return listaHabitacion;
        }

        public Habitacion Find(MySqlConnection Cn, Habitacion Item)
        {
            Habitacion oHabitacion = null;
            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspHabitacionEditar",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            MySqlParameter param1 = cmd.Parameters.AddWithValue("v_nroHabitacion", Item.NroHanitacion);
            param1.Direction = ParameterDirection.Input;

            using (MySqlDataReader dtr = cmd.ExecuteReader())
            {
                if (dtr != null)
                {
                    oHabitacion = new Habitacion();
                    while (dtr.Read())
                    {
                        oHabitacion = (new Habitacion
                        {
                            NroHanitacion = !dtr.IsDBNull(dtr.GetOrdinal("nroHabitacion")) ? dtr.GetInt32(dtr.GetOrdinal("nroHabitacion")) : 0,
                            idTipoHabitacion = !dtr.IsDBNull(dtr.GetOrdinal("idtipoHabitacion")) ? dtr.GetInt32(dtr.GetOrdinal("idtipoHabitacion")) : 0,
                            tipoHabitacion = !dtr.IsDBNull(dtr.GetOrdinal("tipoHabitacion")) ? dtr.GetString(dtr.GetOrdinal("tipoHabitacion")) : "",
                            idtipoServicio = !dtr.IsDBNull(dtr.GetOrdinal("idtiposervicio")) ? dtr.GetInt32(dtr.GetOrdinal("idtiposervicio")) : 0,
                            tipoServicio = !dtr.IsDBNull(dtr.GetOrdinal("tiposervicio")) ? dtr.GetString(dtr.GetOrdinal("tiposervicio")) : "",
                            precio = !dtr.IsDBNull(dtr.GetOrdinal("precio")) ? dtr.GetDecimal(dtr.GetOrdinal("precio")) : 0,
                            cantCamas = !dtr.IsDBNull(dtr.GetOrdinal("cantCama")) ? dtr.GetInt32(dtr.GetOrdinal("cantCama")) : 0
                        });
                    }
                }

            }
            return oHabitacion;
        }
        public int Delete(MySqlConnection Cn, Habitacion Item)
        {
            int rpta = -1;
            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspHabitacionEliminar",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            MySqlParameter param1 = cmd.Parameters.AddWithValue("v_nroHabitacion", Item.NroHanitacion);
            param1.Direction = ParameterDirection.Input;
            rpta = cmd.ExecuteNonQuery();
            return rpta;
        }

    }

}
