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
using Microsoft.Reporting.WinForms;

namespace Krabs
{
    public partial class Zacaz : MetroUserControl
    {
        string cid = "";
        double sum = 0;
        int sum1 = 0;
        int h = 0;
        public Zacaz()
        {
            InitializeComponent();
            tabel();
            tabel1();
            tabel3();
            tabel4();
            tabel5();
           
            combo();
            id();
            id1();
        }

        public void tabel6()
        {
           
                try
                {
                    metroGrid7.Rows.Clear();
                    Baza baza = new Baza();
                    string comp = metroGrid6.CurrentRow.Cells[6].Value.ToString();
                    DateTime dt1 = Convert.ToDateTime(metroGrid6.CurrentRow.Cells[1].Value);

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
                        metroGrid7.Rows.Add(reader["Id"].ToString(), reader["Compani"].ToString(), reader["Data"].ToString(), reader["Name"].ToString(), reader["Cena"].ToString() , reader["col"].ToString(), reader["Summa"].ToString());

                    }
                    reader.Close();
                    conn.Close();
                }
                catch (Exception ex) { }
            

        }
        public void tabel5()
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
                metroGrid6.Rows.Add(reader["Id"].ToString(), reader["Data_oform"].ToString(), reader["Data_sdachi"].ToString(), reader["Data_oplaty"].ToString(),  reader["Scidca"].ToString(), reader["Summa"].ToString(), reader["Compani"].ToString(), reader["Country"].ToString(), reader["Addres"].ToString(), reader["Pocht"].ToString(), reader["phone"].ToString(), reader["Fax"].ToString(), reader["Email"].ToString(), reader["Predstav"].ToString());

            }
            reader.Close();
            conn.Close();
        }

        public int idt()
        {
            int id = 0;
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM tovar", conn);
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

        public void tabel4()
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
        public void id1()
        {
            int id = 0;
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM zacaz_p", conn);
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
            metroTextBox14.Text = Convert.ToString(id + 1);

        }

        public void id()
        {
            int id = 0;
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM zacaz_u", conn);
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
            metroTextBox1.Text = Convert.ToString(id+1);

        }
        public void tabel3()
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
        public void tabel()
        {
            metroGrid1.Rows.Clear();
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM klients", conn);
            // объект для чтения ответа сервера
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                metroGrid1.Rows.Add( reader["Surname"].ToString(), reader["Name"].ToString(), reader["Lastname"].ToString(),  reader["Mb.phone"].ToString(), reader["Email"].ToString());
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
                metroGrid2.Rows.Add(reader["Name"].ToString(), reader["Opis"].ToString(), new Bitmap(Application.StartupPath + @"\images\u\" + reader["Image"].ToString(), false), reader["Cena"].ToString());

            }
            reader.Close();
            conn.Close();
        }

        private void metroLabel15_Click(object sender, EventArgs e)
        {

        }

        private void metroGrid1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                metroTextBox4.Text = metroGrid1.CurrentRow.Cells[0].Value.ToString();
                metroTextBox5.Text = metroGrid1.CurrentRow.Cells[1].Value.ToString();
                metroTextBox6.Text = metroGrid1.CurrentRow.Cells[2].Value.ToString();
                metroTextBox7.Text = metroGrid1.CurrentRow.Cells[3].Value.ToString();
                metroTextBox8.Text = metroGrid1.CurrentRow.Cells[4].Value.ToString();
            }catch(Exception ex)
            {

            }
        }

        private void metroGrid2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                metroTextBox10.Text = metroGrid2.CurrentRow.Cells[0].Value.ToString();
                metroTextBox11.Text = metroGrid2.CurrentRow.Cells[1].Value.ToString();
                metroTextBox12.Text = metroGrid2.CurrentRow.Cells[3].Value.ToString();
                pictureBox1.Image = (Bitmap)metroGrid2.CurrentRow.Cells[2].Value;
            }catch(Exception ex)
            {

            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            
            if(metroTextBox10.Text!="" && metroTextBox11.Text != "" && metroTextBox12.Text != "")
            {
                if (metroTextBox2.Text == "0")
                {
                    listBox1.Items.Add(metroTextBox10.Text);
                    sum += Convert.ToDouble(metroTextBox12.Text);
                    metroTextBox3.Text = sum.ToString();
                }
                else
                {
                    listBox1.Items.Add(metroTextBox10.Text);
                    sum += Convert.ToDouble(metroTextBox12.Text) - (Convert.ToDouble(metroTextBox12.Text) *(Convert.ToDouble(metroTextBox2.Text)/100));
                    metroTextBox3.Text = sum.ToString();
                }

            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "Внимание", "Выберите услугу из таблице!",  MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            try
            {
                int cena = 0;
                if (listBox1.SelectedIndex != -1)
                {
                    Baza baza = new Baza();
                    MySqlConnection conn = baza.GetConnection();
                    MySqlCommand command = new MySqlCommand("SELECT * FROM price_u WHERE Name='" + listBox1.Items[listBox1.SelectedIndex].ToString() + "'", conn);
                    // объект для чтения ответа сервера
                    conn.Open();
                    MySqlDataReader reader = command.ExecuteReader();
                    // читаем результат
                    while (reader.Read())
                    {
                        // элементы массива [] - это значения столбцов из запроса SELECT
                        cena = Convert.ToInt32(reader["Cena"].ToString());

                    }
                    reader.Close();
                    conn.Close();
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    if (metroTextBox2.Text == "0")
                    {
                        sum -= cena;
                        cena = 0;
                        metroTextBox3.Text = sum.ToString();
                    }
                    else
                    {
                        sum -= cena - (cena / Convert.ToInt32(metroTextBox2.Text));
                        cena = 0;
                        metroTextBox3.Text = sum.ToString();
                    }
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "Внимание", "Выберите элемент для удаления!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }catch(Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, "Ошибка", ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            id();
            
            listBox1.Items.Clear();
            clear();
        }
        public void clear()
        {
            sum = 0;
            id();
            listBox1.Items.Clear();
            metroTextBox2.Text="0";
            metroDateTime1.Value= DateTime.Now;
            metroDateTime2.Value = DateTime.Now;
            metroDateTime3.Value = DateTime.Now;
            metroTextBox3.Clear();
            metroTextBox4.Clear();
            metroTextBox5.Clear();
            metroTextBox6.Clear();
            metroTextBox7.Clear();
            metroTextBox8.Clear();
            metroTextBox9.Clear();
            metroTextBox10.Clear();
            metroTextBox11.Clear();
            metroTextBox12.Clear();
            metroTextBox13.Clear();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            metroGrid2.Rows.Clear();
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM price_u WHERE CONCAT(`Name`, `Opis`, `Cena`) LIKE '%" + metroTextBox13.Text + "%'", conn);
            // объект для чтения ответа сервера
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                metroGrid2.Rows.Add(reader["Name"].ToString(), reader["Opis"].ToString(), new Bitmap(Application.StartupPath + @"\images\u\" + reader["Image"].ToString(), false), reader["Cena"].ToString());

            }
            reader.Close();
            conn.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroGrid1.Rows.Clear();
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM klients WHERE CONCAT(`Surname`,`Name`, `Lastname`, `Mb.phone`,`Email`) LIKE '%" + metroTextBox9.Text + "%'", conn);
            // объект для чтения ответа сервера
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                metroGrid1.Rows.Add(reader["Surname"].ToString(), reader["Name"].ToString(), reader["Lastname"].ToString(), reader["Mb.phone"].ToString(), reader["Email"].ToString());

            }
            reader.Close();
            conn.Close();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            if(metroTextBox1.Text=="" || metroTextBox2.Text == "" || metroTextBox3.Text == "" || metroTextBox4.Text == "" || metroTextBox5.Text == "" ||
               metroTextBox6.Text == "" || metroTextBox7.Text == "" || metroTextBox8.Text == "" || metroTextBox10.Text == "" || metroTextBox11.Text == ""
               || metroTextBox12.Text == "")
               
            {
                MetroFramework.MetroMessageBox.Show(this, "Предупреждение!","Не все поля заполнены!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string list = "";
                Baza baza = new Baza();
                for(int i=0; i < listBox1.Items.Count; i++)
                {
                    if (i == 0)
                    {
                        list += listBox1.Items[i].ToString();
                    }
                    else
                    {
                        list +=", "+ listBox1.Items[i].ToString();
                    }
                }
                baza.SQLExute("INSERT INTO `krabs`.`zacaz_u` (`№`, `Data_oform`, `Data_sdachi`, `Data_oplaty`, `Scidca`, `Name`, `Lastname`, `Phone`, `Email`, `usluga`, `Stoim`, `Surname`) VALUES ('"+metroTextBox1.Text+"', '"+metroDateTime1.Value.ToString("yyyy-MM-dd") + "', '" + metroDateTime2.Value.ToString("yyyy-MM-dd") + "', '" + metroDateTime3.Value.ToString("yyyy-MM-dd") + "', '"+metroTextBox2.Text+ "', '" + metroTextBox5.Text + "', '" + metroTextBox6.Text + "', '" + metroTextBox7.Text + "', '" + metroTextBox8.Text + "', '"+list+ "', '" + metroTextBox3.Text + "', '" + metroTextBox4.Text + "');");
                tabel3();
                Report_up report = new Report_up(metroTextBox1.Text, metroDateTime1.Value.ToString("dd/MM/yyyy"),metroDateTime2.Value.ToString("dd/MM/yyyy"), metroDateTime3.Value.ToString("dd/MM/yyyy"), metroTextBox3.Text, metroTextBox4.Text, metroTextBox5.Text, metroTextBox6.Text, metroTextBox7.Text, metroTextBox8.Text,list, metroTextBox2.Text);
                report.ShowDialog();
              // report(list);
                clear();
            }
        }

        private void metroGrid3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void редактироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string str = null;
                string[] strArr = null;
                metroTextBox1.Text = metroGrid3.CurrentRow.Cells[0].Value.ToString();
                metroDateTime1.Value = Convert.ToDateTime(metroGrid3.CurrentRow.Cells[1].Value);
                metroDateTime2.Value = Convert.ToDateTime(metroGrid3.CurrentRow.Cells[2].Value);
                metroDateTime3.Value = Convert.ToDateTime(metroGrid3.CurrentRow.Cells[3].Value);
                metroTextBox2.Text = metroGrid3.CurrentRow.Cells[4].Value.ToString();
                metroTextBox3.Text = metroGrid3.CurrentRow.Cells[11].Value.ToString();
                sum=Convert.ToDouble( metroGrid3.CurrentRow.Cells[11].Value.ToString());
                metroTextBox4.Text = metroGrid3.CurrentRow.Cells[5].Value.ToString();
                metroTextBox5.Text = metroGrid3.CurrentRow.Cells[6].Value.ToString();
                metroTextBox6.Text = metroGrid3.CurrentRow.Cells[7].Value.ToString();
                metroTextBox7.Text = metroGrid3.CurrentRow.Cells[8].Value.ToString();
                metroTextBox8.Text = metroGrid3.CurrentRow.Cells[9].Value.ToString();
                str = metroGrid3.CurrentRow.Cells[10].Value.ToString();
                
                
                int count = 0;
               
                char[] splitchar = { ',',' ' };
                strArr = str.Split(splitchar);
                for (count = 0; count <= strArr.Length - 1; count++)
                {
                    if (strArr[count] == "")
                    {
                        continue;
                    }
                    else
                    {
                        listBox1.Items.Add(strArr[count]);
                    }

                    
                }
                metroButton7.Visible = true;
                metroTabControl1.SelectedIndex = 0;
            }
            catch (Exception ex){}
            
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "" || metroTextBox2.Text == "" || metroTextBox3.Text == "" || metroTextBox4.Text == "" || metroTextBox5.Text == "" ||
              metroTextBox6.Text == "" || metroTextBox7.Text == "" || metroTextBox8.Text == "" || metroTextBox10.Text == "" || metroTextBox11.Text == ""
              || metroTextBox12.Text == "")

            {
                MetroFramework.MetroMessageBox.Show(this, "Предупреждение!", "Не все поля заполнены!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string list = "";
                Baza baza = new Baza();
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (i == 0)
                    {
                        list += listBox1.Items[i].ToString();
                    }
                    else
                    {
                        list += ", " + listBox1.Items[i].ToString();
                    }
                }
                baza.SQLExute("UPDATE `krabs`.`zacaz_u` SET `Data_oform`='" + metroDateTime1.Value.ToString("yyyy-MM-dd") + "',`Data_sdachi` = '" + metroDateTime2.Value.ToString("yyyy-MM-dd") + "',`Data_oplaty` = '" + metroDateTime3.Value.ToString("yyyy-MM-dd") + "',`Scidca`='" + metroTextBox2.Text + "',`Surname`='" + metroTextBox4.Text + "',`Name`='" + metroTextBox5.Text + "',`Lastname`='" + metroTextBox6.Text + "',`Phone`='" + metroTextBox7.Text + "',`Email`='" + metroTextBox8.Text + "',`usluga`='" + list + "',`Stoim`='" + metroTextBox3.Text + "' WHERE(`№` = '" + metroTextBox1.Text + "');");
                tabel3();
                clear();
                sum = 0;
                metroButton7.Visible = false;
                metroTabControl1.SelectedIndex = 1;
            }
        }

        public void report()
        {
            
           //report.reportViewer1.LocalReport.ReportPath = Application.StartupPath + @"\Zacaz_u.rdlc";
          // report.reportViewer1.LocalReport.ReportEmbeddedResource = "Krabs.Zacaz_u.rdlc";
            //report.reportViewer1.LocalReport.Refresh();
            
            
            //report.ShowDialog();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Baza baza = new Baza();
                baza.SQLExute("DELETE FROM `krabs`.`zacaz_u` WHERE `№`=" + metroGrid3.CurrentRow.Cells[0].Value.ToString() + " ;");
                tabel3();
                clear();
            }catch(Exception ex) { }
        }

        private void metroTabControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(metroTabControl3.SelectedIndex == 0)
            {
                metroTabControl2.SelectedIndex = 0;
            }
            else
            {
                metroTabControl2.SelectedIndex = 1;
            }
        }

        private void metroTabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControl2.SelectedIndex == 0)
            {
                metroTabControl3.SelectedIndex = 0;
            }
            else
            {
                metroTabControl3.SelectedIndex = 1;
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void распечататьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string str = null;
               
                metroTextBox1.Text = metroGrid3.CurrentRow.Cells[0].Value.ToString();
                metroDateTime1.Value = Convert.ToDateTime(metroGrid3.CurrentRow.Cells[1].Value);
                metroDateTime2.Value = Convert.ToDateTime(metroGrid3.CurrentRow.Cells[2].Value);
                metroDateTime3.Value = Convert.ToDateTime(metroGrid3.CurrentRow.Cells[3].Value);
                metroTextBox2.Text = metroGrid3.CurrentRow.Cells[4].Value.ToString();
                metroTextBox3.Text = metroGrid3.CurrentRow.Cells[11].Value.ToString();
                sum = Convert.ToDouble(metroGrid3.CurrentRow.Cells[11].Value.ToString());
                metroTextBox4.Text = metroGrid3.CurrentRow.Cells[5].Value.ToString();
                metroTextBox5.Text = metroGrid3.CurrentRow.Cells[6].Value.ToString();
                metroTextBox6.Text = metroGrid3.CurrentRow.Cells[7].Value.ToString();
                metroTextBox7.Text = metroGrid3.CurrentRow.Cells[8].Value.ToString();
                metroTextBox8.Text = metroGrid3.CurrentRow.Cells[9].Value.ToString();
                str = metroGrid3.CurrentRow.Cells[10].Value.ToString();


              
                Report_up report = new Report_up(metroTextBox1.Text, metroDateTime1.Value.ToString("dd/MM/yyyy"), metroDateTime2.Value.ToString("dd/MM/yyyy"), metroDateTime3.Value.ToString("dd/MM/yyyy"), metroTextBox3.Text, metroTextBox4.Text, metroTextBox5.Text, metroTextBox6.Text, metroTextBox7.Text, metroTextBox8.Text, str, metroTextBox2.Text);
                report.ShowDialog();
                clear();
            }
            catch (Exception ex) { }
        }

        private void contextMenuStrip1_Opening_1(object sender, CancelEventArgs e)
        {

        }

        private void tableLayoutPanel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroLabel33_Click(object sender, EventArgs e)
        {

        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            metroGrid5.Rows.Clear();
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM price_m WHERE CONCAT(`Name`, `Opis`, `Coll`,`Cena`) LIKE '%" + metroTextBox23.Text + "%'", conn);
            // объект для чтения ответа сервера
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                metroGrid5.Rows.Add(reader["Name"].ToString(), reader["Opis"].ToString(), new Bitmap(Application.StartupPath + @"\images\m\" + reader["Image"].ToString(), false), reader["Coll"].ToString(), reader["Cena"].ToString());

            }
            reader.Close();
            conn.Close();
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Baza baza = new Baza();
                MySqlConnection conn = baza.GetConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM compani WHERE Name='" + metroComboBox1.Text + "'", conn);
                // объект для чтения ответа сервера
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                // читаем результат
                while (reader.Read())
                {
                    // элементы массива [] - это значения столбцов из запроса SELECT
                    metroTextBox17.Text = reader["Country"].ToString();
                    metroTextBox18.Text = reader["Location"].ToString();
                    metroTextBox19.Text = reader["Poct.ind"].ToString();
                    metroTextBox20.Text = reader["Phone"].ToString();
                    metroTextBox21.Text = reader["Fax"].ToString();
                    metroTextBox22.Text = reader["Email"].ToString();
                    metroTextBox25.Text = reader["Predstav"].ToString();

                }
                reader.Close();
                conn.Close();
            }
            catch { }

        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            if (metroTextBox24.Text=="" || metroTextBox24.Text == "0")
            {
                MetroFramework.MetroMessageBox.Show(this, "Предупреждение!", "Заполните поле 'Количество'!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string id= metroGrid5.CurrentRow.Cells[0].Value.ToString();
                string name=metroGrid5.CurrentRow.Cells[1].Value.ToString();
                string opis = metroGrid5.CurrentRow.Cells[2].Value.ToString();
                string col= metroGrid5.CurrentRow.Cells[4].Value.ToString();
                string cena = metroGrid5.CurrentRow.Cells[5].Value.ToString();
                int col1 = 0;
                double itog = 0;
                if(Convert.ToInt32(col)> Convert.ToInt32(metroTextBox24.Text))
                {
                    if (metroTextBox15.Text == "0")
                    {
                        itog= Convert.ToDouble(cena) * Convert.ToDouble(metroTextBox24.Text);
                        col1 = Convert.ToInt32(col) - Convert.ToInt32(metroTextBox24.Text);
                        Baza baza = new Baza();
                        baza.SQLExute("UPDATE `krabs`.`price_m` SET `Coll` = '" + col1.ToString() + "' WHERE (`Id` = '" + id + "');");
                        tabel4();
                        metroGrid4.Rows.Add( name, metroTextBox24.Text, cena, itog);
                        sum1 += Convert.ToInt32(itog);
                        metroTextBox16.Text = sum1.ToString();
                        metroTextBox24.Clear();
                    }
                    else
                    {
                        double x = Convert.ToDouble(cena) * Convert.ToDouble(metroTextBox24.Text);
                     
                        double y = Convert.ToDouble(metroTextBox15.Text) / 100;
                      
                        itog = x - (x * y);
                       
                        col1 = Convert.ToInt32(col) - Convert.ToInt32(metroTextBox24.Text);
                        Baza baza = new Baza();
                        baza.SQLExute("UPDATE `krabs`.`price_m` SET `Coll` = '" + col1.ToString() + "' WHERE (`Id` = '" + id + "');");
                        tabel4();
                        metroGrid4.Rows.Add(name, metroTextBox24.Text, cena, itog);
                        sum1 += Convert.ToInt32(itog);
                        metroTextBox16.Text = sum1.ToString();
                        metroTextBox24.Clear();
                    }
                }
                else if(Convert.ToInt32(col) < Convert.ToInt32(metroTextBox24.Text))
                {
                    MetroFramework.MetroMessageBox.Show(this, "Ошибка!", "На складе недостаточно товара!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (metroTextBox15.Text == "0")
                    {
                        itog = Convert.ToDouble(cena) * Convert.ToDouble(metroTextBox24.Text);
                        col1 = Convert.ToInt32(col) - Convert.ToInt32(metroTextBox24.Text);
                        Baza baza = new Baza();
                        baza.SQLExute("UPDATE `krabs`.`price_m` SET `Coll` = '" + col1.ToString() + "' WHERE (`Id` = '" + id + "');");
                        tabel4();
                        metroGrid4.Rows.Add(name, opis, metroTextBox24.Text, cena, itog);
                        sum1 += Convert.ToInt32(itog);
                        metroTextBox16.Text = sum1.ToString();
                        metroTextBox24.Clear();
                    }
                    else
                    {
                        double x = Convert.ToDouble(cena) * Convert.ToDouble(metroTextBox24.Text);
                        
                        double y = Convert.ToDouble(metroTextBox15.Text) / 100;
                        
                        itog = x - (x * y);
                        
                        col1 = Convert.ToInt32(col) - Convert.ToInt32(metroTextBox24.Text);
                        Baza baza = new Baza();
                        baza.SQLExute("UPDATE `krabs`.`price_m` SET `Coll` = '" + col1.ToString() + "' WHERE (`Id` = '" + id + "');");
                        tabel4();
                        metroGrid4.Rows.Add(name, opis, metroTextBox24.Text, cena, itog);
                        sum1 += Convert.ToInt32(itog);
                        metroTextBox16.Text = sum1.ToString();
                        metroTextBox24.Clear();
                    }
                }

                




            }
        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            
            clearcom();
        }

        public void clearcom()
        {
            sum1 = 0;
            id1();
            metroDateTime4.Value = DateTime.Now;
            metroDateTime5.Value = DateTime.Now;
            metroDateTime6.Value = DateTime.Now;
            metroTextBox15.Text = "0";
            metroTextBox16.Clear();
            metroTextBox25.Clear();
            combo();
            metroTextBox17.Clear();
            metroTextBox18.Clear();
            metroTextBox19.Clear();
            metroTextBox20.Clear();
            metroTextBox21.Clear();
            metroTextBox22.Clear();
            metroGrid4.Rows.Clear();

        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            sum1-= Convert.ToInt32(metroGrid4.CurrentRow.Cells[3].Value.ToString());
            int a = metroGrid4.CurrentRow.Index;
            metroGrid4.Rows.Remove(metroGrid4.Rows[a]);
            metroTextBox16.Text = sum1.ToString();
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            if (metroTextBox14.Text == "" || metroTextBox15.Text == "" || metroTextBox16.Text == "" || metroTextBox17.Text == "" || metroTextBox18.Text == "" ||
             metroTextBox19.Text == "" || metroTextBox20.Text == "" || metroTextBox21.Text == "" || metroTextBox22.Text == "" || metroTextBox25.Text == ""
             || metroComboBox1.Text == "")

            {
                MetroFramework.MetroMessageBox.Show(this, "Предупреждение!", "Не все поля заполнены!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                
                Baza baza = new Baza();
                for(int i = 0; i < metroGrid4.RowCount; i++)
                {
                    try
                    {
                        if (metroGrid4.Rows[i].Cells[2].Value.ToString()=="")
                        {

                        }
                        else
                        {

                            baza.SQLExute("INSERT INTO `krabs`.`tovar` (`Id`, `Compani`, `Data`, `Name`, `col`, `Cena`, `Summa`) VALUES ('" + (idt()+1) + "', '" + metroComboBox1.Text + "','" + metroDateTime6.Value.ToString("yyyy-MM-dd") + "', '" + metroGrid4.Rows[i].Cells[1].Value.ToString() + "', '" + metroGrid4.Rows[i].Cells[2].Value.ToString() + "', '" + metroGrid4.Rows[i].Cells[3].Value.ToString() + "', '" + metroGrid4.Rows[i].Cells[4].Value.ToString() + "');");
                        }
                        
                    }catch(Exception ex) { }
                    

                }

                baza.SQLExute("INSERT INTO `krabs`.`zacaz_p` (`Id`, `Data_oform`, `Data_sdachi`, `Data_oplaty`, `Scidca`,`Summa`, `Compani`, `Country`, `Addres`,`Pocht`, `phone`,`Fax`, `Email`,`Predstav`) VALUES ('" + metroTextBox14.Text + "', '" + metroDateTime4.Value.ToString("yyyy-MM-dd") + "', '" + metroDateTime5.Value.ToString("yyyy-MM-dd") + "', '" + metroDateTime6.Value.ToString("yyyy-MM-dd") + "', '" + metroTextBox15.Text + "', '" + metroTextBox16.Text + "', '" + metroComboBox1.Text + "', '" + metroTextBox17.Text + "', '" + metroTextBox18.Text + "', '" + metroTextBox19.Text + "',  '" + metroTextBox20.Text + "', '" + metroTextBox21.Text + "', '" + metroTextBox22.Text + "', '" + metroTextBox25.Text + "');");
                //tabel3();
                //Report_up report = new Report_up(metroTextBox1.Text, metroDateTime1.Value.ToString("dd/MM/yyyy"), metroDateTime2.Value.ToString("dd/MM/yyyy"), metroDateTime3.Value.ToString("dd/MM/yyyy"), metroTextBox3.Text, metroTextBox4.Text, metroTextBox5.Text, metroTextBox6.Text, metroTextBox7.Text, metroTextBox8.Text, list, metroTextBox2.Text);
                //report.ShowDialog();

                clearcom();
            }
        }

        private void metroTextBox26_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel22_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroGrid6_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            if (metroTextBox26.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Предупреждение!", "Заполните поля для поиска!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                metroGrid7.Rows.Clear();
                Baza baza = new Baza();
                // string comp = metroGrid6.CurrentRow.Cells[6].Value.ToString();
                // DateTime dt1 = Convert.ToDateTime(metroGrid6.CurrentRow.Cells[1].Value);

                //MessageBox.Show(comp + " " + data);
                MySqlConnection conn = baza.GetConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM tovar WHERE Compani='" + metroTextBox26.Text + "' AND Data='" + metroDateTime7.Value.ToString("yyyy-MM-dd") + "'", conn);
                // объект для чтения ответа сервера
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                // читаем результат
                while (reader.Read())
                {
                    // элементы массива [] - это значения столбцов из запроса SELECT
                    metroGrid7.Rows.Add(reader["Id"].ToString(), reader["Compani"].ToString(), reader["Data"].ToString(), reader["Name"].ToString(), reader["col"].ToString(), reader["Cena"].ToString(), reader["Summa"].ToString());

                }
                reader.Close();
                conn.Close();
            }
           
        }

        private void редактироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (metroGrid7.RowCount-1 == 0)
            {
                MetroFramework.MetroMessageBox.Show(this, "Внимание", "Выберите запись в таблице!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
               /* sum1 = Convert.ToInt32(metroGrid6.CurrentRow.Cells[5].Value.ToString());
                metroTextBox14.Text = metroGrid6.CurrentRow.Cells[0].Value.ToString();
                metroDateTime4.Value = Convert.ToDateTime(metroGrid6.CurrentRow.Cells[1].Value.ToString());
                metroDateTime5.Value = Convert.ToDateTime(metroGrid6.CurrentRow.Cells[2].Value.ToString());
                metroDateTime6.Value = Convert.ToDateTime(metroGrid6.CurrentRow.Cells[3].Value.ToString());
                metroTextBox15.Text = metroGrid6.CurrentRow.Cells[4].Value.ToString();
                metroTextBox16.Text = metroGrid6.CurrentRow.Cells[5].Value.ToString();
                metroComboBox1.Text = metroGrid6.CurrentRow.Cells[6].Value.ToString();
                metroTextBox17.Text = metroGrid6.CurrentRow.Cells[7].Value.ToString();
                metroTextBox18.Text = metroGrid6.CurrentRow.Cells[8].Value.ToString();
                metroTextBox19.Text = metroGrid6.CurrentRow.Cells[9].Value.ToString();
                metroTextBox20.Text = metroGrid6.CurrentRow.Cells[10].Value.ToString();
                metroTextBox21.Text = metroGrid6.CurrentRow.Cells[10].Value.ToString();
                metroTextBox22.Text = metroGrid6.CurrentRow.Cells[11].Value.ToString();
                metroTextBox25.Text = metroGrid6.CurrentRow.Cells[12].Value.ToString();*/
                Zacaz_red red = new Zacaz_red(metroGrid6.CurrentRow.Cells[0].Value.ToString(),
                    metroGrid6.CurrentRow.Cells[1].Value.ToString(),
                   metroGrid6.CurrentRow.Cells[2].Value.ToString(),
                   metroGrid6.CurrentRow.Cells[3].Value.ToString(),
                   metroGrid6.CurrentRow.Cells[6].Value.ToString(),
                   metroGrid6.CurrentRow.Cells[13].Value.ToString(),
                   metroGrid6.CurrentRow.Cells[7].Value.ToString(),
                   metroGrid6.CurrentRow.Cells[8].Value.ToString(),
                   metroGrid6.CurrentRow.Cells[9].Value.ToString(),
                   metroGrid6.CurrentRow.Cells[10].Value.ToString(),
                   metroGrid6.CurrentRow.Cells[11].Value.ToString(),
                   metroGrid6.CurrentRow.Cells[12].Value.ToString(),
                 metroGrid6.CurrentRow.Cells[4].Value.ToString(),
                 metroGrid6.CurrentRow.Cells[5].Value.ToString()
                   );
                red.ShowDialog();
                //metroGrid4.Rows.Clear();
                /*try
                {
                    for (int i = 0; i < metroGrid7.RowCount; i++)
                    {
                        metroGrid4.Rows.Add(metroGrid7.Rows[i].Cells[3].Value.ToString(), metroGrid7.Rows[i].Cells[4].Value.ToString(), metroGrid7.Rows[i].Cells[5].Value.ToString(), metroGrid7.Rows[i].Cells[6].Value.ToString());
                    }
                }
                catch (Exception ex) { }*/
                //metroButton13.Visible = true;
                //metroTabControl1.SelectedIndex = 2;
            }
        }

        private void metroGrid6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tabel6();
        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            if (metroTextBox14.Text == "" || metroTextBox15.Text == "" || metroTextBox16.Text == "" || metroTextBox17.Text == "" || metroTextBox18.Text == "" ||
            metroTextBox19.Text == "" || metroTextBox20.Text == "" || metroTextBox21.Text == "" || metroTextBox22.Text == "" || metroTextBox25.Text == ""
            || metroComboBox1.Text == "")

            {
                MetroFramework.MetroMessageBox.Show(this, "Предупреждение!", "Не все поля заполнены!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                Baza baza = new Baza();
                for (int i = 0; i < metroGrid4.RowCount; i++)
                {
                    try
                    {
                        if (metroGrid4.Rows[i].Cells[2].Value.ToString() == "")
                        {

                        }
                        else
                        {

                            string res = "";
                            string name = metroGrid4.CurrentRow.Cells[0].Value.ToString();
                            string col = metroGrid4.CurrentRow.Cells[1].Value.ToString();
                            string sum = metroGrid4.CurrentRow.Cells[3].Value.ToString();
                            try
                            {

                                //DateTime dt1 = Convert.ToDateTime(metroGrid6.CurrentRow.Cells[1].Value);

                                //MessageBox.Show(comp + " " + data);
                                MySqlConnection conn = baza.GetConnection();
                                MySqlCommand command = new MySqlCommand("SELECT * FROM tovar WHERE Compani='" + metroComboBox1.Text + "' AND Data='" + metroDateTime4.Value.ToString("yyyy-MM-dd") + "' AND Name='"+name+"'", conn);
                                // объект для чтения ответа сервера
                                conn.Open();
                                MySqlDataReader reader = command.ExecuteReader();
                                // читаем результат
                                while (reader.Read())
                                {
                                    // элементы массива [] - это значения столбцов из запроса SELECT
                                    res = reader["Name"].ToString();

                                }
                                reader.Close();
                                conn.Close();
                            }
                            catch (Exception ex) { }
                            if (res == name)
                            {
                                baza.SQLExute("UPDATE `krabs`.`tovar` SET `col` = '"+col+"', `Summa` = '"+sum+"'  WHERE (`Name` = '" + name+"');");
                            }
                            else
                            {
                                baza.SQLExute("INSERT INTO `krabs`.`tovar` (`Id`, `Compani`, `Data`, `Name`, `col`, `Cena`, `Summa`) VALUES ('" + (idt() + 1) + "', '" + metroComboBox1.Text + "','" + metroDateTime6.Value.ToString("yyyy-MM-dd") + "', '" + metroGrid4.Rows[i].Cells[1].Value.ToString() + "', '" + metroGrid4.Rows[i].Cells[2].Value.ToString() + "', '" + metroGrid4.Rows[i].Cells[3].Value.ToString() + "', '" + metroGrid4.Rows[i].Cells[4].Value.ToString() + "');");
                            }
                           

                        }

                    }
                    catch (Exception ex) { }


                }

                baza.SQLExute("UPDATE `krabs`.`zacaz_p` SET `Data_oform` = '"+metroDateTime4.Value.ToString("yyyy-MM-dd") + "', `Data_sdachi` = '" + metroDateTime5.Value.ToString("yyyy-MM-dd") + "', `Data_oplaty` = '" + metroDateTime6.Value.ToString("yyyy-MM-dd") + "', `Scidca` = '"+metroTextBox15.Text+ "', `Summa` = '" + metroTextBox16.Text + "', `Compani` = '"+metroComboBox1.Text+ "', `Country` = '" + metroTextBox17.Text + "', `Addres` = '" + metroTextBox18.Text + "', `Pocht` = '" + metroTextBox19.Text + "', `phone` = '" + metroTextBox20.Text + "', `Fax` = '" + metroTextBox21.Text + "', `Email` = '" + metroTextBox22.Text + "', `Predstav` = '" + metroTextBox25.Text + "' WHERE (`Id` = '" + metroTextBox14.Text + "');");
                tabel5();
                //Report_up report = new Report_up(metroTextBox1.Text, metroDateTime1.Value.ToString("dd/MM/yyyy"), metroDateTime2.Value.ToString("dd/MM/yyyy"), metroDateTime3.Value.ToString("dd/MM/yyyy"), metroTextBox3.Text, metroTextBox4.Text, metroTextBox5.Text, metroTextBox6.Text, metroTextBox7.Text, metroTextBox8.Text, list, metroTextBox2.Text);
                //report.ShowDialog();

                clearcom();
                metroButton13.Visible = false;
                metroTabControl1.SelectedIndex = 3;
            }
        }
    }
}
