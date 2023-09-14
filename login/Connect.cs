using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;

namespace login
{
    internal class Connect
    {
        private MySqlConnection conn;
        private string server;
        private string user;
        private string pass;
        private string db;

        public Connect()
        { 
            Initialize();
        }

        private void Initialize()
        {
            server = "localhost";
            db = "pharmacy";
            user = "root";
            pass = "";
            string connectionSring;
            connectionSring = "Data Source=" + server + ";Database=" + db + ";User Id" + user + ";password=" + pass + ";SSL Mode=0";
            conn = new MySqlConnection(connectionSring);
            
        }
        public bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException e)
            {

                switch(e.Number)
                {
                    case 0:
                        MessageBox.Show("Nem lehet csatlakozni a szerverhez.");
                        break;
                        case 1045:
                        MessageBox.Show("Rossz felhasználónév vagy jelszó,próbáld újra.");
                        break;
                }
                return false;
            }
        }
        public void close_conn()
        {
            this.conn.Close();
        }
        public MySqlConnection get_connection()
        {
            return this.conn;
        }
    }
}
