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
    public class TipoHabitacion_Logica
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public IEnumerable<TipoHabitacion> Retrieve(TipoHabitacion Item)
        {
            IEnumerable<TipoHabitacion> ltipoDocumento = null;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(msqlconnection))
                {
                    cn.Open();
                    TipoHabitacion_Datos otipoDocumentoDatos = new TipoHabitacion_Datos();
                    ltipoDocumento = otipoDocumentoDatos.Retrieve(cn, Item);
                }
            }
            catch (Exception ex)
            {
                ltipoDocumento = null;
                throw ex;
            }

            return ltipoDocumento;
        }
    }
}
