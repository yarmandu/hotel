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
    public class ReservaHabitacion_Datos
    {
        
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;
        
        public int Insert(MySqlConnection cn, ReservaHabitacion Item)
        {
            
            cn = new MySqlConnection(msqlconnection);
            int rpta = -1;

            cn.Open();

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspinsertarReservaHabitacion",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };

            MySqlParameter param1 = cmd.Parameters.AddWithValue("v_idReserva", Item.idReserva);
            param1.Direction = ParameterDirection.Input;
            MySqlParameter param2 = cmd.Parameters.AddWithValue("v_IdHotel", 1);
            param2.Direction = ParameterDirection.Input;
            MySqlParameter param3 = cmd.Parameters.AddWithValue("v_IdTipoDocumento", Item.IdTipoDocumento);
            param3.Direction = ParameterDirection.Input;
            MySqlParameter param4 = cmd.Parameters.AddWithValue("v_descTipoDoc", Item.descTipoDoc ?? "");
            param4.Direction = ParameterDirection.Input;
            MySqlParameter param5 = cmd.Parameters.AddWithValue("v_cantHabitacion", Item.cantHabitacion);
            param5.Direction = ParameterDirection.Input;
            MySqlParameter param6 = cmd.Parameters.AddWithValue("v_idTipoHabitacion", Item.idTipoHabitacion);
            param6.Direction = ParameterDirection.Input;
            MySqlParameter param7 = cmd.Parameters.AddWithValue("v_fechaInicio", Item.fechaInicio);
            param7.Direction = ParameterDirection.Input;
            MySqlParameter param8 = cmd.Parameters.AddWithValue("v_fechaFin", Item.fechaFin);
            param8.Direction = ParameterDirection.Input;
            MySqlParameter param9 = cmd.Parameters.AddWithValue("v_precio", Item.Precio);
            param9.Direction = ParameterDirection.Input;
            MySqlParameter param10 = cmd.Parameters.AddWithValue("v_precioTotal", Item.precioTotal);
            param10.Direction = ParameterDirection.Input;
            MySqlParameter param11 = cmd.Parameters.AddWithValue("v_idtipoPago", Item.idtipoPago);
            param11.Direction = ParameterDirection.Input;
            MySqlParameter param12 = cmd.Parameters.AddWithValue("v_total", Item.total);
            param12.Direction = ParameterDirection.Input;   

            rpta = cmd.ExecuteNonQuery();

            return rpta;

        }

        public IEnumerable<ReservaHabitacion> Retrieve(MySqlConnection cn, ReservaHabitacion Item)
        {
            List<ReservaHabitacion> listaReserva = null;
            cn = new MySqlConnection(msqlconnection);
            cn.Open();

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspReservaListar",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };

            MySqlParameter param1 = cmd.Parameters.AddWithValue("v_descTipoDoc", Item.descTipoDoc ??"");
            param1.Direction = ParameterDirection.Input;

            using (MySqlDataReader dtr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    listaReserva = new List<ReservaHabitacion>();
                    while (dtr.Read())
                    {
                        listaReserva.Add(new ReservaHabitacion
                        {
                            idReserva = !dtr.IsDBNull(dtr.GetOrdinal("idReserva")) ? dtr.GetInt32(dtr.GetOrdinal("idReserva")) : 0,
                            IdHotel = !dtr.IsDBNull(dtr.GetOrdinal("IdHotel")) ? dtr.GetInt32(dtr.GetOrdinal("IdHotel")) : 0,
                            descTipoDoc = !dtr.IsDBNull(dtr.GetOrdinal("descTipoDoc")) ? dtr.GetString(dtr.GetOrdinal("descTipoDoc")) : "",
                            cantHabitacion = !dtr.IsDBNull(dtr.GetOrdinal("cantHabitacion")) ? dtr.GetInt32(dtr.GetOrdinal("cantHabitacion")) : 0,
                            idTipoHabitacion = !dtr.IsDBNull(dtr.GetOrdinal("idTipoHabitacion")) ? dtr.GetInt32(dtr.GetOrdinal("idTipoHabitacion")) : 0,
                            tipoHabitacion = !dtr.IsDBNull(dtr.GetOrdinal("tipoHabitacion")) ? dtr.GetString(dtr.GetOrdinal("tipoHabitacion")) : "",
                            fechaInicio = Convert.ToDateTime(dtr["fechaInicio"].ToString()),
                            fechaFin = Convert.ToDateTime(dtr["fechaFin"].ToString()),
                            IdTipoDocumento = !dtr.IsDBNull(dtr.GetOrdinal("IdTipoDocumento")) ? dtr.GetInt32(dtr.GetOrdinal("IdTipoDocumento")) : 0,
                            tipoDocumento = !dtr.IsDBNull(dtr.GetOrdinal("tipoDocumento")) ? dtr.GetString(dtr.GetOrdinal("tipoDocumento")) : "",
                            Precio = !dtr.IsDBNull(dtr.GetOrdinal("Precio")) ? dtr.GetDecimal(dtr.GetOrdinal("Precio")) : 0,
                            precioTotal = !dtr.IsDBNull(dtr.GetOrdinal("precioTotal")) ? dtr.GetDecimal(dtr.GetOrdinal("precioTotal")) : 0,
                            idtipoPago = !dtr.IsDBNull(dtr.GetOrdinal("idtipoPago")) ? dtr.GetInt32(dtr.GetOrdinal("idtipoPago")) : 0,
                            tipoPago = !dtr.IsDBNull(dtr.GetOrdinal("tipoPago")) ? dtr.GetString(dtr.GetOrdinal("tipoPago")) : "",
                            total = !dtr.IsDBNull(dtr.GetOrdinal("total")) ? dtr.GetDecimal(dtr.GetOrdinal("total")) : 0
                        });
                    }
                }
            }
            return listaReserva;
        }

        public ReservaHabitacion Find(MySqlConnection Cn, ReservaHabitacion Item)
        {
            ReservaHabitacion oReserva = null;
            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspReservaEditar",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            MySqlParameter param1 = cmd.Parameters.AddWithValue("v_idReserva", Item.idReserva);
            param1.Direction = ParameterDirection.Input;

            using (MySqlDataReader dtr = cmd.ExecuteReader())
            {
                if (dtr != null)
                {
                    oReserva = new ReservaHabitacion();
                    while (dtr.Read())
                    {
                        oReserva = (new ReservaHabitacion
                        {
                            idReserva = !dtr.IsDBNull(dtr.GetOrdinal("idReserva")) ? dtr.GetInt32(dtr.GetOrdinal("idReserva")) : 0,
                            IdHotel = !dtr.IsDBNull(dtr.GetOrdinal("IdHotel")) ? dtr.GetInt32(dtr.GetOrdinal("IdHotel")) : 0,
                            descTipoDoc = !dtr.IsDBNull(dtr.GetOrdinal("descTipoDoc")) ? dtr.GetString(dtr.GetOrdinal("descTipoDoc")) : "",
                            cantHabitacion = !dtr.IsDBNull(dtr.GetOrdinal("cantHabitacion")) ? dtr.GetInt32(dtr.GetOrdinal("cantHabitacion")) : 0,
                            idTipoHabitacion = !dtr.IsDBNull(dtr.GetOrdinal("idTipoHabitacion")) ? dtr.GetInt32(dtr.GetOrdinal("idTipoHabitacion")) : 0,
                            tipoHabitacion = !dtr.IsDBNull(dtr.GetOrdinal("tipoHabitacion")) ? dtr.GetString(dtr.GetOrdinal("tipoHabitacion")) : "",
                            fechaInicio = Convert.ToDateTime(dtr["fechaInicio"].ToString()),
                            fechaFin = Convert.ToDateTime(dtr["fechaFin"].ToString()),
                            IdTipoDocumento = !dtr.IsDBNull(dtr.GetOrdinal("IdTipoDocumento")) ? dtr.GetInt32(dtr.GetOrdinal("IdTipoDocumento")) : 0,
                            tipoDocumento = !dtr.IsDBNull(dtr.GetOrdinal("tipoDocumento")) ? dtr.GetString(dtr.GetOrdinal("tipoDocumento")) : "",
                            Precio = !dtr.IsDBNull(dtr.GetOrdinal("Precio")) ? dtr.GetDecimal(dtr.GetOrdinal("Precio")) : 0,
                            precioTotal = !dtr.IsDBNull(dtr.GetOrdinal("precioTotal")) ? dtr.GetDecimal(dtr.GetOrdinal("precioTotal")) : 0,
                            idtipoPago = !dtr.IsDBNull(dtr.GetOrdinal("idtipoPago")) ? dtr.GetInt32(dtr.GetOrdinal("idtipoPago")) : 0,
                            tipoPago = !dtr.IsDBNull(dtr.GetOrdinal("tipoPago")) ? dtr.GetString(dtr.GetOrdinal("tipoPago")) : "",
                            total = !dtr.IsDBNull(dtr.GetOrdinal("total")) ? dtr.GetDecimal(dtr.GetOrdinal("total")) : 0,
                            estado = !dtr.IsDBNull(dtr.GetOrdinal("estado")) ? dtr.GetInt32(dtr.GetOrdinal("estado")) : 0
                        });
                    }
                }

            }
            return oReserva;
        }
        public int Delete(MySqlConnection Cn, ReservaHabitacion Item)
        {
            int rpta = -1;
            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspReservaEliminar",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };
            MySqlParameter param1 = cmd.Parameters.AddWithValue("v_idReserva", Item.idReserva);
            param1.Direction = ParameterDirection.Input;
            rpta = cmd.ExecuteNonQuery();
            return rpta;
        }

        public int AprobarNotificacion(MySqlConnection cn, ReservaHabitacion Item)
        {
            int rpta = -1;
            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspReservaAprobar",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };
            MySqlParameter param1 = cmd.Parameters.AddWithValue("v_idReserva", Item.idReserva);
            param1.Direction = ParameterDirection.Input;
            rpta = cmd.ExecuteNonQuery();
            return rpta;

        }

        public IEnumerable<ReservaHabitacion> ListarNotificacion(MySqlConnection cn, ReservaHabitacion Item)
        {
            List<ReservaHabitacion> listaReserva = null;
            cn = new MySqlConnection(msqlconnection);
            cn.Open();

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspNotificacionReservaListar",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };

            MySqlParameter param1 = cmd.Parameters.AddWithValue("v_descTipoDoc", Item.descTipoDoc ?? "");
            param1.Direction = ParameterDirection.Input;

            using (MySqlDataReader dtr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    listaReserva = new List<ReservaHabitacion>();
                    while (dtr.Read())
                    {
                        listaReserva.Add(new ReservaHabitacion
                        {
                            idReserva = !dtr.IsDBNull(dtr.GetOrdinal("idReserva")) ? dtr.GetInt32(dtr.GetOrdinal("idReserva")) : 0,
                            IdHotel = !dtr.IsDBNull(dtr.GetOrdinal("IdHotel")) ? dtr.GetInt32(dtr.GetOrdinal("IdHotel")) : 0,
                            descTipoDoc = !dtr.IsDBNull(dtr.GetOrdinal("descTipoDoc")) ? dtr.GetString(dtr.GetOrdinal("descTipoDoc")) : "",
                            cantHabitacion = !dtr.IsDBNull(dtr.GetOrdinal("cantHabitacion")) ? dtr.GetInt32(dtr.GetOrdinal("cantHabitacion")) : 0,
                            idTipoHabitacion = !dtr.IsDBNull(dtr.GetOrdinal("idTipoHabitacion")) ? dtr.GetInt32(dtr.GetOrdinal("idTipoHabitacion")) : 0,
                            tipoHabitacion = !dtr.IsDBNull(dtr.GetOrdinal("tipoHabitacion")) ? dtr.GetString(dtr.GetOrdinal("tipoHabitacion")) : "",
                            fechaInicio = Convert.ToDateTime(dtr["fechaInicio"].ToString()),
                            fechaFin = Convert.ToDateTime(dtr["fechaFin"].ToString()),
                            IdTipoDocumento = !dtr.IsDBNull(dtr.GetOrdinal("IdTipoDocumento")) ? dtr.GetInt32(dtr.GetOrdinal("IdTipoDocumento")) : 0,
                            tipoDocumento = !dtr.IsDBNull(dtr.GetOrdinal("tipoDocumento")) ? dtr.GetString(dtr.GetOrdinal("tipoDocumento")) : "",
                            Precio = !dtr.IsDBNull(dtr.GetOrdinal("Precio")) ? dtr.GetDecimal(dtr.GetOrdinal("Precio")) : 0,
                            precioTotal = !dtr.IsDBNull(dtr.GetOrdinal("precioTotal")) ? dtr.GetDecimal(dtr.GetOrdinal("precioTotal")) : 0,
                            idtipoPago = !dtr.IsDBNull(dtr.GetOrdinal("idtipoPago")) ? dtr.GetInt32(dtr.GetOrdinal("idtipoPago")) : 0,
                            tipoPago = !dtr.IsDBNull(dtr.GetOrdinal("tipoPago")) ? dtr.GetString(dtr.GetOrdinal("tipoPago")) : "",
                            total = !dtr.IsDBNull(dtr.GetOrdinal("total")) ? dtr.GetDecimal(dtr.GetOrdinal("total")) : 0
                        });
                    }
                }
            }
            return listaReserva;
        }

    }
}
