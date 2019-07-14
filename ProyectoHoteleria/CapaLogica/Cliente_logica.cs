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
    public class Cliente_logica
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public int Edit(Cliente Item)
        {
            int rpta = -1;
            using (MySqlConnection cn = new MySqlConnection(msqlconnection))
            {
                cn.Open();
                Cliente_Datos cliente = new Cliente_Datos();
                rpta =  cliente.Insert(cn, Item);
            }
            return rpta;
        }

        public IEnumerable<Cliente> Retrieve(Cliente Item)
        {
                IEnumerable<Cliente> lCliente = null;
            try {
                using (MySqlConnection cn = new MySqlConnection(msqlconnection))
                {
                    cn.Open();
                    Cliente_Datos oClienteDatos = new Cliente_Datos();
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

        public Cliente Find(Cliente Item)
        {
            Cliente lCliente = null;

            using (MySqlConnection cn = new MySqlConnection(msqlconnection))
            {
                cn.Open();
                Cliente_Datos oClienteDatos = new Cliente_Datos();
                lCliente = oClienteDatos.Find(cn, Item);
            }

            return lCliente;
        }
        public int Delete(Cliente Item)
        {

            int rpta = -1;
            using (MySqlConnection cn = new MySqlConnection(msqlconnection))
            {
                 cn.Open();
                Cliente_Datos oClienteDatos = new Cliente_Datos();
                rpta = oClienteDatos.Delete(cn, Item);
            }
            return rpta;
        }

    }
}
