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
    public partial class Zacaz_red : MetroFramework.Forms.MetroForm
    {
        public Zacaz_red(string n,string data_oform,string data_sdachi,string data_oplaty,string compani,string predstav,
            string countri,string addres,string pocht_ind,string phone,string fax,string email,string scidca,string itog)
        {
            InitializeComponent();
            combo();
            metroTextBox14.Text = n;
            metroDateTime4.Value = Convert.ToDateTime(data_oform);
            metroDateTime5.Value = Convert.ToDateTime(data_sdachi);
            metroDateTime6.Value = Convert.ToDateTime(data_oplaty);
            metroTextBox15.Text = scidca;
            metroTextBox16.Text = itog;
            metroComboBox1.Text = compani;
            metroTextBox17.Text = countri;
            metroTextBox18.Text = addres;
            metroTextBox19.Text = pocht_ind;
            metroTextBox20.Text = phone;
            metroTextBox21.Text = fax;
            metroTextBox22.Text = email;
            metroTextBox25.Text = predstav;
        }

        public Zacaz_red()
        {
            InitializeComponent();
            
        }


        public void combo()
        {
            metroComboBox1.Items.Clear();
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM compani", conn);
            // объект для чтения ответа сервера
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                metroComboBox1.Items.Add(reader["Name"].ToString());

            }
            reader.Close();
            conn.Close();

        }

        private void metroDateTime5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel21_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel20_Click(object sender, EventArgs e)
        {

        }

        private void metroDateTime4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            tovar tovar = new tovar(metroDateTime4.Value.ToString("yyyy - MM - dd"),metroComboBox1.Text,Convert.ToInt32(metroTextBox16.Text));
            tovar.ShowDialog();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
