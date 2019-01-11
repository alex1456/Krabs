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
            Baza baza = new Baza();
            if (metroTextBox14.Text == "" || metroTextBox15.Text == "" || metroTextBox16.Text == "" || metroTextBox17.Text == "" || metroTextBox18.Text == "" ||
             metroTextBox19.Text == "" || metroTextBox20.Text == "" || metroTextBox21.Text == "" || metroTextBox22.Text == "" || metroTextBox25.Text == ""
             || metroComboBox1.Text == "")

            {
                MetroFramework.MetroMessageBox.Show(this, "Предупреждение!", "Не все поля заполнены!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {



               // baza.SQLExute("INSERT INTO `krabs`.`zacaz_p` (`Id`, `Data_oform`, `Data_sdachi`, `Data_oplaty`, `Scidca`,`Summa`, `Compani`, `Country`, `Addres`,`Pocht`, `phone`,`Fax`, `Email`,`Predstav`) VALUES (c, '" + metroDateTime4.Value.ToString("yyyy-MM-dd") + "', '" + metroDateTime5.Value.ToString("yyyy-MM-dd") + "', '" + metroDateTime6.Value.ToString("yyyy-MM-dd") + "', '" + metroTextBox15.Text + "', '" + metroTextBox16.Text + "', '" + metroComboBox1.Text + "', '" + metroTextBox17.Text + "', '" + metroTextBox18.Text + "', '" + metroTextBox19.Text + "',  '" + metroTextBox20.Text + "', '" + metroTextBox21.Text + "', '" + metroTextBox22.Text + "', '" + metroTextBox25.Text + "');");
                baza.SQLExute("UPDATE `krabs`.`zacaz_p` SET `Data_oform` = '" + metroDateTime4.Value.ToString("yyyy-MM-dd") + "', `Data_sdachi` = '" + metroDateTime5.Value.ToString("yyyy-MM-dd") + "', `Data_oplaty` = '" + metroDateTime6.Value.ToString("yyyy-MM-dd") + "', `Scidca` = '" + metroTextBox15.Text + "', `Summa` = '" + metroTextBox16.Text + "', `Compani` = '" + metroComboBox1.Text + "', `Country` = '" + metroTextBox17.Text + "', `Addres` = '" + metroTextBox18.Text + "', `Pocht` = '" + metroTextBox19.Text + "', `phone` = '" + metroTextBox20.Text + "', `Fax` = '" + metroTextBox21.Text + "', `Email` = '" + metroTextBox22.Text + "', `Predstav` = '" + metroTextBox25.Text + "' WHERE(`Id` = '" + metroTextBox14.Text+"');");
                Menu zacaz = Application.OpenForms["Menu"] as Menu;
                zacaz.Zacaz();
                this.Close();
                //tabel3();
                //Report_up report = new Report_up(metroTextBox1.Text, metroDateTime1.Value.ToString("dd/MM/yyyy"), metroDateTime2.Value.ToString("dd/MM/yyyy"), metroDateTime3.Value.ToString("dd/MM/yyyy"), metroTextBox3.Text, metroTextBox4.Text, metroTextBox5.Text, metroTextBox6.Text, metroTextBox7.Text, metroTextBox8.Text, list, metroTextBox2.Text);
                //report.ShowDialog();



            }
        }
    }
}
