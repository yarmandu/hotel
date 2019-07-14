using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo_Entidades;
using MySql.Data.MySqlClient;
using AccesoDatos;
using System.Configuration;

namespace CapaLogica
{
    public class TipoPago_Logica
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public IEnumerable<TipoPago> Retrieve(TipoPago Item)
        {
            IEnumerable<TipoPago> ltipoPago = null;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(msqlconnection))
                {
                    cn.Open();
                    TipoPago_Datos pago = new TipoPago_Datos();
                    ltipoPago = pago.Retrieve(cn, Item);
                }
            }
            catch (Exception ex)
            {
                ltipoPago = null;
                throw ex;
            }

            return ltipoPago;
        }
    }
}
