using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo_Entidades;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace AccesoDatos
{
    public class Login_Datos
    {
        string msqlconnection = ConfigurationManager.ConnectionStrings["ConexionHotel"].ConnectionString;

        public IEnumerable<Login> RetrieveUsuario(MySqlConnection cn, Login Item)
        {
            List<Login> listaUsuario = null;
            cn = new MySqlConnection(msqlconnection);
            cn.Open();

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspIngresarSistema",
                CommandType = CommandType.StoredProcedure,
                Connection = cn
            };

            MySqlParameter param1 = cmd.Parameters.AddWithValue("v_usuario", Item.Usuario ?? "");
            param1.Direction = ParameterDirection.Input;
            MySqlParameter param2 = cmd.Parameters.AddWithValue("v_clave", Item.Clave ?? "");
            param2.Direction = ParameterDirection.Input;

            using (MySqlDataReader dtr = cmd.ExecuteReader(CommandBehavior.SingleResult))
            {
                if (dtr != null)
                {
                    listaUsuario = new List<Login>();
                    while (dtr.Read())
                    {
                        listaUsuario.Add(new Login
                        {
                            Usuario = !dtr.IsDBNull(dtr.GetOrdinal("usuario")) ? dtr.GetString(dtr.GetOrdinal("usuario")) : "",
                            Clave = !dtr.IsDBNull(dtr.GetOrdinal("clave")) ? dtr.GetString(dtr.GetOrdinal("clave")) : "",
                            Nombre = !dtr.IsDBNull(dtr.GetOrdinal("Nombre")) ? dtr.GetString(dtr.GetOrdinal("Nombre")) : "",
                            apePaterno = !dtr.IsDBNull(dtr.GetOrdinal("apePaterno")) ? dtr.GetString(dtr.GetOrdinal("apePaterno")) : "",
                            apeMaterno = !dtr.IsDBNull(dtr.GetOrdinal("apeMaterno")) ? dtr.GetString(dtr.GetOrdinal("apeMaterno")) : ""//,
                            //fechaFin = Convert.ToDateTime(dtr.GetDateTime(dtr.GetOrdinal("fechaFin")) )
                        });
                    }
                }
            }
            return listaUsuario;
        }

        public Login RetrieveUsuario1(MySqlConnection Cn, Login Item)
        {
            Login oCliente = null;

            MySqlCommand cmd = new MySqlCommand
            {
                CommandText = "uspIngresarSistema",
                CommandType = CommandType.StoredProcedure,
                Connection = Cn
            };


            MySqlParameter param1 = cmd.Parameters.AddWithValue("v_usuario", Item.Usuario ?? "");
            param1.Direction = ParameterDirection.Input;
            MySqlParameter param2 = cmd.Parameters.AddWithValue("v_clave", Item.Clave ?? "");
            param2.Direction = ParameterDirection.Input;

            using (MySqlDataReader dtr = cmd.ExecuteReader())
            {
                if (dtr != null)
                {
                    oCliente = new Login();
                    while (dtr.Read())
                    {
                        oCliente = (new Login
                        {
                            Usuario = !dtr.IsDBNull(dtr.GetOrdinal("usuario")) ? dtr.GetString(dtr.GetOrdinal("usuario")) : "",
                            Clave = !dtr.IsDBNull(dtr.GetOrdinal("clave")) ? dtr.GetString(dtr.GetOrdinal("clave")) : "",
                            Nombre = !dtr.IsDBNull(dtr.GetOrdinal("Nombre")) ? dtr.GetString(dtr.GetOrdinal("Nombre")) : "",
                            apePaterno = !dtr.IsDBNull(dtr.GetOrdinal("apePaterno")) ? dtr.GetString(dtr.GetOrdinal("apePaterno")) : "",
                            apeMaterno = !dtr.IsDBNull(dtr.GetOrdinal("apeMaterno")) ? dtr.GetString(dtr.GetOrdinal("apeMaterno")) : ""
                        });
                    }
                }

            }
            return oCliente;
        }


    }
}
