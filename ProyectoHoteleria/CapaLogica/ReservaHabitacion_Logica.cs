using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo_Entidades;
using AccesoDatos;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace CapaLogica
{
    public class ReservaHabitacion_Logica
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public int Edit(ReservaHabitacion Item)
        {
            int rpta = -1;
            using (MySqlConnection cn = new MySqlConnection(msqlconnection))
            {
                cn.Open();
                ReservaHabitacion_Datos reserva = new ReservaHabitacion_Datos();
                rpta = reserva.Insert(cn, Item);
            }
            return rpta;
        }

        public IEnumerable<ReservaHabitacion> Retrieve(ReservaHabitacion Item)
        {
            IEnumerable<ReservaHabitacion> lReserva = null;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(msqlconnection))
                {
                    cn.Open();
                    ReservaHabitacion_Datos reserva = new ReservaHabitacion_Datos();
                    lReserva = reserva.Retrieve(cn, Item);
                }
            }
            catch (Exception ex)
            {
                lReserva = null;
                throw ex;
            }

            return lReserva;
        }

        public IEnumerable<ReservaHabitacion> ListarNotificacion(ReservaHabitacion Item)
        {
            IEnumerable<ReservaHabitacion> lReserva = null;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(msqlconnection))
                {
                    cn.Open();
                    ReservaHabitacion_Datos reserva = new ReservaHabitacion_Datos();
                    lReserva = reserva.ListarNotificacion(cn, Item);
                }
            }
            catch (Exception ex)
            {
                lReserva = null;
                throw ex;
            }

            return lReserva;
        }

        public ReservaHabitacion Find(ReservaHabitacion Item)
        {
            ReservaHabitacion lReserva = null;

            using (MySqlConnection cn = new MySqlConnection(msqlconnection))
            {
                cn.Open();
                ReservaHabitacion_Datos reserva = new ReservaHabitacion_Datos();
                lReserva = reserva.Find(cn, Item);
            }

            return lReserva;
        }
        public int Delete(ReservaHabitacion Item)
        {

            int rpta = -1;
            using (MySqlConnection cn = new MySqlConnection(msqlconnection))
            {
                cn.Open();
                ReservaHabitacion_Datos reserva = new ReservaHabitacion_Datos();
                rpta = reserva.Delete(cn, Item);
            }
            return rpta;
        }

        public int AprobarNotificacion(ReservaHabitacion Item)
        {

            int rpta = -1;
            using (MySqlConnection cn = new MySqlConnection(msqlconnection))
            {
                cn.Open();
                ReservaHabitacion_Datos reserva = new ReservaHabitacion_Datos();
                rpta = reserva.AprobarNotificacion(cn, Item);
            }
            return rpta;
        }
        
    }
}
