using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Modelo_Entidades;
using AccesoDatos;
using System.Configuration;

namespace CapaLogica
{
    public class TipoServicio_Logica
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public IEnumerable<TipoServicio> Retrieve(TipoServicio Item)
        {
            IEnumerable<TipoServicio> ltipoDocumento = null;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(msqlconnection))
                {
                    cn.Open();
                    TipoServicio_Datos otipoDocumentoDatos = new TipoServicio_Datos();
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
