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
        int sum2 = 0;
        string compani = "";
        string data = "";
        public tovar(string data,string compani,int sum)
        {
            this.compani = compani;
            this.data = data;
            sum1 = sum;
            sum2 = sum;
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
                MySqlCommand command = new MySqlCommand("SELECT * FROM tovar_m WHERE Compani='" + comp + "' AND Data='" + dt1.ToString("yyyy-MM-dd") + "'", conn);
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
                    //Baza baza = new Baza();
                    //baza.SQLExute("UPDATE `krabs`.`price_m` SET `Coll` = '" + col1.ToString() + "' WHERE (`Id` = '" + id + "');");
                    //tabel1();
                    metroGrid5.CurrentRow.Cells[4].Value = col1;
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
                    //Baza baza = new Baza();
                    //baza.SQLExute("UPDATE `krabs`.`price_m` SET `Coll` = '" + col1.ToString() + "' WHERE (`Id` = '" + id + "');");
                    //tabel1();
                    metroGrid5.CurrentRow.Cells[4].Value = col1;
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
                    metroGrid5.CurrentRow.Cells[4].Value = col1;
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
                    metroGrid5.CurrentRow.Cells[4].Value = col1;
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

        public int idt()
        {
            int id = 0;
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM tovar_m", conn);
            // объект для чтения ответа сервера
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                id++;

            }
            reader.Close();
            conn.Close();
            return id;

        }

     

        private void metroButton2_Click(object sender, EventArgs e)
        {

             Baza baza = new Baza();
             for (int i = 0; i < metroGrid5.RowCount-1; i++)
             {
                 string id = metroGrid5.Rows[i].Cells[0].Value.ToString();
                 string col = metroGrid5.Rows[i].Cells[4].Value.ToString();
                 baza.SQLExute("UPDATE `krabs`.`price_m` SET `Coll` = '" + col.ToString() + "' WHERE (`Id` = '" + id + "');");
             }


            DateTime dt1 = Convert.ToDateTime(data);
            //MessageBox.Show(ident[i].ToString());
            baza.SQLExute(" DELETE FROM `krabs`.`tovar_m` WHERE Data = '" + dt1.ToString("yyyy-MM-dd") + "' AND Compani='"+compani+"';");
            
            
                    
          

            int id1 = idt();
            for (int i = 0; i < metroGrid4.RowCount; i++)
            {
                try
                {

                    string name = metroGrid4.Rows[i].Cells[0].Value.ToString();
                    string col = metroGrid4.Rows[i].Cells[1].Value.ToString();
                    string cena = metroGrid4.Rows[i].Cells[2].Value.ToString();
                    string sum = metroGrid4.Rows[i].Cells[3].Value.ToString();
                    //MessageBox.Show(name + " " + col + " " + cena + " " + sum);
                    //baza.SQLExute(" INSERT INTO tovar_m (`Id`, `Compani`,`Name`) VALUES("+(id+1)+", '" + metroComboBox1.Text + "','" + name + "')");
                    baza.SQLExute(" INSERT INTO `krabs`.`tovar_m` (`Id`, `Compani`, `Data`, `Name`, `Col`, `Cena`, `Summa`) VALUES(" + (id1 + 1) + ", '" + compani + "', '" +dt1.ToString("yyyy-MM-dd") + "', '" + name + "', '" + col + "', '" + cena + "', '" + sum + "');");
                    id1++;
                }
                catch { }

            }
            Zacaz_red zacaz = Application.OpenForms["Zacaz_red"] as Zacaz_red;
            zacaz.metroTextBox16.Text = metroTextBox2.Text;
            zacaz.metroTextBox15.Text = metroTextBox1.Text;
            //zacaz.Refresh();
            this.Close();

        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            
            metroTextBox2.Text = sum2.ToString();
            tabel1();
            tabel2();

        }

        private void tovar_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "krabsDataSet.tovar_m". При необходимости она может быть перемещена или удалена.
            this.tovar_mTableAdapter.Fill(this.krabsDataSet.tovar_m);

        }
    }
    }


