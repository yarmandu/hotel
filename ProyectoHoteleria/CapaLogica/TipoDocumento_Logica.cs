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
    public class TipoDocumento_Logica
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public IEnumerable<TipoDocumento> Retrieve(TipoDocumento Item)
        {
            IEnumerable<TipoDocumento> ltipoDocumento = null;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(msqlconnection))
                {
                    cn.Open();
                    TipoDocumento_Datos otipoDocumentoDatos = new TipoDocumento_Datos();
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
