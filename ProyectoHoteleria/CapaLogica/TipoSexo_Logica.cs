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
    public class TipoSexo_Logica
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public IEnumerable<Sexo> Retrieve(Sexo Item)
        {
            IEnumerable<Sexo> ltipoSexo = null;
            try
            {
                using (MySqlConnection cn = new MySqlConnection(msqlconnection))
                {
                    cn.Open();
                    TipoSexo_Datos otipoSexoDatos = new TipoSexo_Datos();
                    ltipoSexo = otipoSexoDatos.Retrieve(cn, Item);
                }
            }
            catch (Exception ex)
            {
                ltipoSexo = null;
                throw ex;
            }

            return ltipoSexo;
        }

    }
}
