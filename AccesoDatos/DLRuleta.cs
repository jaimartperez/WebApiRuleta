using System.Collections.Generic;
using MySqlConnector;
using WebApiRuleta.Entidades;
namespace WebApiRuleta.AccesoDatos
{
    public class DLRuleta
    {        
        readonly string sql = ";server=localhost;user id=root;password=;port=3306;database=ruleta";
        public int CrearRuleta(Ruleta objRuleta)
        {
            int id;
            using (MySqlConnection conn = new MySqlConnection(sql))
            {
                conn.Open();
                string query = "INSERT INTO `ruleta` (`estado`) VALUES ('" + objRuleta.Estado + "');";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                id = (int)cmd.LastInsertedId;
            }

            return id;
        }
        public int CambiarEstadoRuleta(Ruleta objRuleta)
        {
            int id;
            using (MySqlConnection conn = new MySqlConnection(sql))
            {
                conn.Open();
                string query = "UPDATE `ruleta` SET `estado` = '" + objRuleta.Estado + "' WHERE `id` =" + objRuleta.Id +";";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                id = (int)cmd.LastInsertedId;
            }

            return id;
        }
        public Ruleta ConsultarRuletaID(int id)
        {
            Ruleta objRuleta = new Ruleta();
            using (MySqlConnection conn = new MySqlConnection(sql))
            {
                conn.Open();
                string query = "SELECT * FROM `ruleta` WHERE `id` =" + id + ";";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    objRuleta.Id = (int)dataReader["id"];
                    objRuleta.Estado = dataReader["estado"].ToString().Contains("abi") ? Estado.abierto : Estado.cerrado;
                }
            }
            
            return objRuleta;
        }
        public List<Ruleta> ConsultarRuletas()
        {
            List<Ruleta> lstRuleta = new List<Ruleta>();            
            using (MySqlConnection conn = new MySqlConnection(sql))
            {
                conn.Open();
                string query = "SELECT * FROM `ruleta`;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    Ruleta objRuleta = new Ruleta();
                    objRuleta.Id = (int)dataReader["id"];
                    objRuleta.Estado = dataReader["estado"].ToString().Contains("abi") ? Estado.abierto : Estado.cerrado;
                    lstRuleta.Add(objRuleta);
                }
            }

            return lstRuleta;
        }
    }
}
