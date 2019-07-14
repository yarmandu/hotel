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
    public class TipoCliente_Logica
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public IEnumerable<TipoCliente> Retrieve(TipoCliente Item)
        {
            IEnumerable<TipoCliente> ltipoCliente = null;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(msqlconnection))
                {
                    cn.Open();
                    TipoCliente_Datos otipoClienteDatos = new TipoCliente_Datos();
                    ltipoCliente = otipoClienteDatos.Retrieve(cn, Item);
                }
            }
            catch (Exception ex)
            {
                ltipoCliente = null;
                throw ex;
            }

            return ltipoCliente;
        }
    }
}
