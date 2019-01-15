using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MySql.Data.MySqlClient;

namespace Krabs
{
    public partial class Raspred : MetroUserControl
    {
        public Raspred()
        {
            InitializeComponent();
            tabel1();
            tabel2();
        }

        public void tabel1()
        {
            metroGrid3.Rows.Clear();
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM zacaz_u", conn);
            // объект для чтения ответа сервера
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                metroGrid3.Rows.Add(reader["№"].ToString(), reader["Data_oform"].ToString(), reader["Data_sdachi"].ToString(), reader["Data_oplaty"].ToString(), reader["Scidca"].ToString(), reader["Surname"].ToString(), reader["Name"].ToString(), reader["Lastname"].ToString(), reader["Phone"].ToString(), reader["Email"].ToString(), reader["usluga"].ToString(), reader["Stoim"].ToString());

            }
            reader.Close();
            conn.Close();
        }

        public void tabel2()
        {
            metroGrid6.Rows.Clear();
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM zacaz_p", conn);
            // объект для чтения ответа сервера
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                metroGrid6.Rows.Add(reader["Id"].ToString(), reader["Data_oform"].ToString(), reader["Data_sdachi"].ToString(), reader["Data_oplaty"].ToString(), reader["Scidca"].ToString(), reader["Summa"].ToString(), reader["Compani"].ToString(), reader["Country"].ToString(), reader["Addres"].ToString(), reader["Pocht"].ToString(), reader["phone"].ToString(), reader["Fax"].ToString(), reader["Email"].ToString(), reader["Predstav"].ToString());

            }
            reader.Close();
            conn.Close();
        }
    }
}
