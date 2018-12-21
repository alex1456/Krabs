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
    public partial class tovar : MetroFramework.Forms.MetroForm
    {
        int sum1 = 0;
        string compani = "";
        string data = "";
        public tovar(string data,string compani,int sum)
        {
            this.compani = compani;
            this.data = data;
            sum1 = sum;
            InitializeComponent();
            metroTextBox2.Text = sum1.ToString();
            tabel1();
            tabel2();
        }

        public void tabel2()
        {

            try
            {
                metroGrid4.Rows.Clear();
                Baza baza = new Baza();
                string comp = compani;
                DateTime dt1 = Convert.ToDateTime(data);

                //MessageBox.Show(comp + " " + data);
                MySqlConnection conn = baza.GetConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM tovar WHERE Compani='" + comp + "' AND Data='" + dt1.ToString("yyyy-MM-dd") + "'", conn);
                // объект для чтения ответа сервера
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                // читаем результат
                while (reader.Read())
                {
                    // элементы массива [] - это значения столбцов из запроса SELECT
                    metroGrid4.Rows.Add(reader["Name"].ToString(), reader["col"].ToString(), reader["Cena"].ToString(), reader["Summa"].ToString());

                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex) { }


        }

        public void tabel1()
        {
            metroGrid5.Rows.Clear();
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
                metroGrid5.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Opis"].ToString(), new Bitmap(Application.StartupPath + @"\images\m\" + reader["Image"].ToString(), false), reader["Coll"].ToString(), reader["Cena"].ToString());

            }
            reader.Close();
            conn.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string id = metroGrid5.CurrentRow.Cells[0].Value.ToString();
            string name = metroGrid5.CurrentRow.Cells[1].Value.ToString();
            string opis = metroGrid5.CurrentRow.Cells[2].Value.ToString();
            string col = metroGrid5.CurrentRow.Cells[4].Value.ToString();
            string cena = metroGrid5.CurrentRow.Cells[5].Value.ToString();
            int col1 = 0;
            double itog = 0;
            if (Convert.ToInt32(col) > Convert.ToInt32(numericUpDown1.Value.ToString()))
            {
                if (metroTextBox1.Text == "0")
                {
                    itog = Convert.ToDouble(cena) * Convert.ToDouble(numericUpDown1.Value.ToString());
                    col1 = Convert.ToInt32(col) - Convert.ToInt32(numericUpDown1.Value.ToString());
                    Baza baza = new Baza();
                    //baza.SQLExute("UPDATE `krabs`.`price_m` SET `Coll` = '" + col1.ToString() + "' WHERE (`Id` = '" + id + "');");
                    //tabel1();
                    metroGrid4.Rows.Add(name, numericUpDown1.Value.ToString(), cena, itog);
                    sum1 += Convert.ToInt32(itog);
                    metroTextBox2.Text = sum1.ToString();
                    numericUpDown1.Value=0;
                }
                else
                {
                    double x = Convert.ToDouble(cena) * Convert.ToDouble(numericUpDown1.Value.ToString());

                    double y = Convert.ToDouble(metroTextBox1.Text) / 100;

                    itog = x - (x * y);

                    col1 = Convert.ToInt32(col) - Convert.ToInt32(numericUpDown1.Value.ToString());
                    Baza baza = new Baza();
                    //baza.SQLExute("UPDATE `krabs`.`price_m` SET `Coll` = '" + col1.ToString() + "' WHERE (`Id` = '" + id + "');");
                    //tabel1();
                    metroGrid4.Rows.Add(name, numericUpDown1.Value.ToString(), cena, itog);
                    sum1 += Convert.ToInt32(itog);
                    metroTextBox2.Text = sum1.ToString();
                    numericUpDown1.Value = 0;
                }
            }
            else if (Convert.ToInt32(col) < Convert.ToInt32(numericUpDown1.Value.ToString()))
            {
                MetroFramework.MetroMessageBox.Show(this, "Ошибка!", "На складе недостаточно товара!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (metroTextBox1.Text == "0")
                {
                    itog = Convert.ToDouble(cena) * Convert.ToDouble(numericUpDown1.Value.ToString());
                    col1 = Convert.ToInt32(col) - Convert.ToInt32(numericUpDown1.Value.ToString());
                    Baza baza = new Baza();
                    //baza.SQLExute("UPDATE `krabs`.`price_m` SET `Coll` = '" + col1.ToString() + "' WHERE (`Id` = '" + id + "');");
                    //tabel1();
                    metroGrid4.Rows.Add(name, opis, numericUpDown1.Value.ToString(), cena, itog);
                    sum1 += Convert.ToInt32(itog);
                    metroTextBox2.Text = sum1.ToString();
                    numericUpDown1.Value=0;
                }
                else
                {
                    double x = Convert.ToDouble(cena) * Convert.ToDouble(numericUpDown1.Value.ToString());

                    double y = Convert.ToDouble(metroTextBox1.Text) / 100;

                    itog = x - (x * y);

                    col1 = Convert.ToInt32(col) - Convert.ToInt32(numericUpDown1.Value.ToString());
                    Baza baza = new Baza();
                    //baza.SQLExute("UPDATE `krabs`.`price_m` SET `Coll` = '" + col1.ToString() + "' WHERE (`Id` = '" + id + "');");
                    //tabel1();
                    metroGrid4.Rows.Add(name, opis, numericUpDown1.Value.ToString(), cena, itog);
                    sum1 += Convert.ToInt32(itog);
                    metroTextBox2.Text = sum1.ToString();
                    numericUpDown1.Value=0;
                }
            }






        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sum1 -= Convert.ToInt32(metroGrid4.CurrentRow.Cells[3].Value.ToString());
            int a = metroGrid4.CurrentRow.Index;
            metroGrid4.Rows.Remove(metroGrid4.Rows[a]);
            metroTextBox2.Text = sum1.ToString();
        }
    }
    }


