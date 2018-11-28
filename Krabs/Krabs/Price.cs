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
using System.IO;

namespace Krabs
{
    public partial class Price : MetroUserControl
    {
        String id = "";
        string cid = "";
        public Price()
        {
            InitializeComponent();
        }

        private void Price_Load(object sender, EventArgs e)
        {
            tabel();
            tabel1();
        }

        public void tabel()
        {
            metroGrid1.Rows.Clear();
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM price_m", conn);
            // объект для чтения ответа сервера
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                metroGrid1.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Opis"].ToString(), reader["Coll"].ToString(), reader["Cena"].ToString(), new Bitmap(Application.StartupPath + @"\images\m\" + reader["Image"].ToString(), false));
                cid = reader["Id"].ToString();
            }
            reader.Close();
            conn.Close();
        }
        public void tabel1()
        {
            metroGrid2.Rows.Clear();
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM price_u", conn);
            // объект для чтения ответа сервера
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                metroGrid2.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Opis"].ToString(),reader["Cena"].ToString(), new Bitmap(Application.StartupPath + @"\images\u\" + reader["Image"].ToString(), false));
                
            }
            reader.Close();
            conn.Close();
        }

        private void metroGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                metroTextBox1.Text = metroGrid1.CurrentRow.Cells[1].Value.ToString();
                metroTextBox2.Text = metroGrid1.CurrentRow.Cells[2].Value.ToString();
                metroTextBox3.Text = metroGrid1.CurrentRow.Cells[3].Value.ToString();
                metroTextBox5.Text = metroGrid1.CurrentRow.Cells[4].Value.ToString();
                pictureBox1.Image = (Bitmap)metroGrid1.CurrentRow.Cells[5].Value;
                id = metroGrid1.CurrentRow.Cells[0].Value.ToString();
            }
            catch(Exception ex)
            {

            }
            
           
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroGrid1.Rows.Clear();
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM price_m WHERE CONCAT(`Id`, `Name`, `Opis`, `Coll`, `Cena`) LIKE '%" + metroTextBox4.Text + "%'", conn);
            // объект для чтения ответа сервера
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                metroGrid1.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Opis"].ToString(), reader["Coll"].ToString(), reader["Cena"].ToString(),new Bitmap(Application.StartupPath + @"\images\m\" + reader["Image"].ToString(), false));
                cid = reader["Id"].ToString();
            }
            reader.Close();
            conn.Close();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            tabel();
        }

        private void metroGrid2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                metroTextBox6.Text = metroGrid2.CurrentRow.Cells[1].Value.ToString();
                metroTextBox7.Text = metroGrid2.CurrentRow.Cells[2].Value.ToString();
                metroTextBox8.Text = metroGrid2.CurrentRow.Cells[3].Value.ToString();
                pictureBox2.Image = (Bitmap)metroGrid2.CurrentRow.Cells[4].Value;
                
            }
            catch (Exception ex)
            {

            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            metroGrid2.Rows.Clear();
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM price_u WHERE CONCAT(`Id`, `Name`, `Opis`, `Cena`) LIKE '%" + metroTextBox9.Text + "%'", conn);
            // объект для чтения ответа сервера
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                metroGrid2.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Opis"].ToString(),  reader["Cena"].ToString(), new Bitmap(Application.StartupPath + @"\images\u\" + reader["Image"].ToString(), false));
                
            }
            reader.Close();
            conn.Close();
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            tabel1();
        }
    }
}
