using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Krabs
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        public string name1(string post)
        {
            string name = "";
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM sotrudnici WHERE Post='" + post + "'", conn);
            // объект для чтения ответа сервера
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                name = reader["Surname"].ToString();
                
            }
            reader.Close();
            conn.Close();
            return name;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if(metroTextBox1.Text==""&& metroTextBox2.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Внимание!", "Не все поля заполнены", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string login = "";
                string password = "";
                string name = "";
                string post = "";
                Baza baza = new Baza();
                MySqlConnection conn = baza.GetConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM avtor WHERE Login='"+metroTextBox1.Text+"'", conn);
                // объект для чтения ответа сервера
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                // читаем результат
                while (reader.Read())
                {
                    // элементы массива [] - это значения столбцов из запроса SELECT
                    login = reader["Login"].ToString();
                    password = reader["Password"].ToString();
                    post = reader["Post"].ToString();
                }
                reader.Close();
                conn.Close();


               name= name1(post);


                if (metroTextBox1.Text==login && metroTextBox2.Text == password)
                {
                    
                    if (post== "Администратор")
                    {
                        Menu menu = new Menu(name);
                        menu.Show();
                        menu.klient();
                        this.Hide();
                        metroTextBox1.Text = "";
                        metroTextBox2.Text = "";
                    }
                   
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Ошибка", "Неверный логин или пароль!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    metroTextBox1.Text = "";
                    metroTextBox2.Text = "";
                }
            }
        }
    }
}
