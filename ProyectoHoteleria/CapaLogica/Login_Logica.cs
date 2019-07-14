using AccesoDatos;
using Modelo_Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CapaLogica
{
    public class Login_Logica
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public IEnumerable<Login> RetrieveUsuario(Login Item)
        {
            IEnumerable<Login> lusuario = null;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(msqlconnection))
                { 
                    cn.Open();
                    Login_Datos oLoginDatos = new Login_Datos();
                    lusuario = oLoginDatos.RetrieveUsuario(cn, Item);                
                }
                        
            }
            catch (Exception ex)
            {
                lusuario = null;
                throw ex;
            }

            return lusuario;
        }

        public Login RetrieveUsuario1(Login Item)
        {
            Login lCliente = null;

            using (MySqlConnection cn = new MySqlConnection(msqlconnection))
            {
                cn.Open();
                Login_Datos oClienteDatos = new Login_Datos();
                lCliente = oClienteDatos.RetrieveUsuario1(cn, Item);
            }

            return lCliente;
        }

    }
}
