using MySql.Data.MySqlClient;
using System.Collections.Generic;
using WebApiRuleta.Entidades;
namespace WebApiRuleta.AccesoDatos
{
    public class DLApuesta
    {
        readonly string sql = ";server=localhost;user id=root;password=;port=3306;database=ruleta";
        public int CrearApuesta(Apuesta objApuesta)
        {
            int id;
            using (MySqlConnection conn = new MySqlConnection(sql))
            {
                conn.Open();
                string query = "INSERT INTO `apuesta` (`id_ruleta`,`usuario`,`montoApuesta`,`numeroApuesta`,`color`) VALUES ('" + objApuesta.IdRuleta + "','" + objApuesta.Usuario + "', '" + objApuesta.MontoApuesta + "', '" + objApuesta.NumeroApuesta + "','" + objApuesta.ColorApuesta + "');";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                id = (int)cmd.LastInsertedId;
            }

            return id;
        }
        public List<Apuesta> ConsultarApuestaIdRuleta(int id)
        {
            List<Apuesta> lstApuestas = new List<Apuesta>();
            Apuesta objApuesta = new Apuesta();
            using (MySqlConnection conn = new MySqlConnection(sql))
            {
                conn.Open();
                string query = "SELECT * FROM `apuesta` WHERE `id_ruleta` =" + id + ";";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    objApuesta.IdRuleta = (int)dataReader["id_ruleta"];
                    objApuesta.Usuario = dataReader["usuario"].ToString();
                    objApuesta.MontoApuesta = (double)dataReader["montoApuesta"];
                    objApuesta.NumeroApuesta = (int)dataReader["numeroApuesta"];
                    objApuesta.ColorApuesta = dataReader["color"].ToString().Contains("roj") ? Color.rojo : Color.negro;
                    lstApuestas.Add(objApuesta);
                }
            }

            return lstApuestas;
        }
    }
}
