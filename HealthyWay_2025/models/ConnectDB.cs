using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace HealthyWay_2025.models
{
    internal class ConnectDB
    {
        public MySqlConnection connManager = new MySqlConnection();
        string server = "127.0.0.1;";
        string database = "healthyway;";
        string user = "root;";
        string pass = "root;";

        public MySqlConnection DataSource()
        {
            connManager = new MySqlConnection($"server={server} " +
                $"database={database} Uid={user} password={pass}");
            return connManager;
        }

        public void ConnectOpened()
        {

            connManager.Open();
        }
        public void ConnectClosed()
        {
            DataSource();
            connManager.Close();
        }

        public bool ExecuteQuery(string sql)
        {
            bool result = false;
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, DataSource());
                ConnectOpened();

                cmd.ExecuteNonQuery();
                result = true;
                //ConnectClosed();
            }
            catch (Exception w)
            {
                Console.WriteLine("ERROOOOOOR " + w.Message);

                ConnectClosed();
            }
            finally
            {
                ConnectClosed();
            }
            return result;
        }
    }
}
