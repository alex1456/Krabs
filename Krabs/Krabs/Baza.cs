using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using System.Windows.Forms;

namespace Krabs
{
    public class Baza
    {
        public MySqlConnection GetConnection()
        {
            string serverName = "root@localhost";
            string userName = "root"; // Имя пользователя 
            string dbName = "krabs"; //Имя базы данных 
            string port = "3310"; // Порт для подключения 
            string password = ""; // Пароль для подключения 

            /*string connStr = "server=" + serverName +
            ";user=" + userName +
            ";database=" + dbName +
            ";port=" + port +
            ";password=" + password + ";" + "SslMode=none;Charset=utf8;Allow User Variables=True";*/
            string connStr = "server=localhost;user=root;database=krabs;port=3310;password=;";

            //MySqlConnection connection = new MySqlConnection("datasource=localhost;port=3306;Initial Catalog ='krabs';username=root;password=root;Charset=utf8;Allow User Variables=True;SslMode=none");
            return new MySqlConnection(connStr);
        }

        public void SQLExute(string sql)
        {
            try
            {
                MySqlCommand command;
                MySqlConnection connection= GetConnection();
                connection.Open();
                // объект для выполнения SQL-запроса
                MySqlCommand comand = new MySqlCommand(sql, connection);
                // выполняем запрос
                comand.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(null, "Ошибка", ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

