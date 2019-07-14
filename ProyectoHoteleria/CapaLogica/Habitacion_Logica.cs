using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo_Entidades;
using MySql.Data.MySqlClient;
using System.Configuration;
using AccesoDatos;

namespace CapaLogica
{
    public class Habitacion_Logica
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public int Edit(Habitacion Item)
        {
            int rpta = -1;
            using (MySqlConnection cn = new MySqlConnection(msqlconnection))
            {
                cn.Open();
                Habitacion_Datos cliente = new Habitacion_Datos();
                rpta = cliente.Insert(cn, Item);
            }
            return rpta;
        }

        public IEnumerable<Habitacion> Retrieve(Habitacion Item)
        {
            IEnumerable<Habitacion> lCliente = null;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(msqlconnection))
                {
                    cn.Open();
                    Habitacion_Datos oClienteDatos = new Habitacion_Datos();
                    lCliente = oClienteDatos.Retrieve(cn, Item);
                }
            }
            catch (Exception ex)
            {
                lCliente = null;
                throw ex;
            }

            return lCliente;
        }

        public Habitacion Find(Habitacion Item)
        {
            Habitacion lCliente = null;

            using (MySqlConnection cn = new MySqlConnection(msqlconnection))
            {
                cn.Open();
                Habitacion_Datos oClienteDatos = new Habitacion_Datos();
                lCliente = oClienteDatos.Find(cn, Item);
            }

            return lCliente;
        }
        public int Delete(Habitacion Item)
        {

            int rpta = -1;
            using (MySqlConnection cn = new MySqlConnection(msqlconnection))
            {
                cn.Open();
                Habitacion_Datos oClienteDatos = new Habitacion_Datos();
                rpta = oClienteDatos.Delete(cn, Item);
            }
            return rpta;
        }
    }
}
