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
    public partial class Klient : MetroUserControl
    {
        String id = "";
        String id1 = "";
        string cid = "";
        string cid1 = "";
        string input = "";
        string name = "";
        public Klient()
        {
            InitializeComponent();
        }

        private void metroUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void Klient_Load(object sender, EventArgs e)
        {
            tabel();
            tabel1();
            comboCity();
            comboCountry();
            
        }

        public void comboCity()
        {
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            conn.Open();
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM city", conn);
            DataTable tbl1 = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command1);
            da.Fill(tbl1);
            metroComboBox2.DataSource = tbl1;
            metroComboBox2.DisplayMember = "City";// столбец для отображения
            metroComboBox2.ValueMember = "Id";//столбец с id
            metroComboBox2.SelectedIndex = -1;
            conn.Close();
        }
        public void comboCountry()
        {
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            conn.Open();
            MySqlCommand command1 = new MySqlCommand("SELECT * FROM countri", conn);
            DataTable tbl1 = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(command1);
            da.Fill(tbl1);
            metroComboBox3.DataSource = tbl1;
            metroComboBox3.DisplayMember = "Countri";// столбец для отображения
            metroComboBox3.ValueMember = "Id";//столбец с id
            metroComboBox3.SelectedIndex = -1;
            conn.Close();
        }
        public void tabel1()
        {
            metroGrid2.Rows.Clear();
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
                metroGrid2.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Location"].ToString(), reader["City"].ToString(), reader["Poct.ind"].ToString(), reader["Country"].ToString(), reader["Predstav"].ToString(), reader["Phone"].ToString(),reader["Fax"].ToString(),reader["Email"].ToString());
                cid1 = reader["Id"].ToString();
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
                metroGrid1.Rows.Add(reader["Id"].ToString(), reader["Surname"].ToString(), reader["Name"].ToString(), reader["Lastname"].ToString(), reader["Data"].ToString(), reader["Pol"].ToString(), reader["Mb.phone"].ToString(), reader["Email"].ToString());
                cid = reader["Id"].ToString();
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
                metroDateTime1.Value = Convert.ToDateTime(metroGrid1.CurrentRow.Cells[4].Value);
                metroComboBox1.Text = metroGrid1.CurrentRow.Cells[5].Value.ToString();
                metroTextBox4.Text = metroGrid1.CurrentRow.Cells[6].Value.ToString();
                metroTextBox5.Text = metroGrid1.CurrentRow.Cells[7].Value.ToString();
                id = metroGrid1.CurrentRow.Cells[0].Value.ToString();
            }catch(Exception ex)
            {

            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            //int selRowNum = metroGrid1.CurrentCell.RowIndex-1;

            clear();
            // metroLabel8.Text= Convert.ToString( metroGrid1.Rows[selRowNum].Cells[0].Value.ToString());
        
            //active(false);
            

        }
        public void clear()
        {
            
            metroTextBox1.Clear();
            metroTextBox2.Clear();
            metroTextBox3.Clear();
            metroDateTime1.Value = DateTime.Now;
            metroComboBox1.SelectedIndex=-1;
            metroTextBox4.Clear();
            metroTextBox5.Clear();
            id = "";

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            
            if (metroTextBox1.Text == "" || metroTextBox2.Text == "" || metroTextBox3.Text == "" || metroTextBox4.Text == "" || metroTextBox5.Text == "" || metroComboBox1.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Ошибка", "Не все поля заполнины!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                
                Baza baza = new Baza();
                MySqlConnection conn = baza.GetConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `krabs`.`klients` WHERE `Name`='"+ metroTextBox2.Text+ "' AND `Surname`='" + metroTextBox1.Text + "' AND `Lastname`='" + metroTextBox3.Text + "'", conn);
                // объект для чтения ответа сервера
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                // читаем результат
                while (reader.Read())
                {
                    name = reader["Name"].ToString();
                    
                }
               // MessageBox.Show(name);
                reader.Close();
                conn.Close();
                if (metroTextBox2.Text==name)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Ошибка", "Данный клиент уже занесён в базу!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();
                }
                else {

                    
                    baza.SQLExute("INSERT INTO `krabs`.`klients` (`Id`, `Name`, `Surname`, `Lastname`, `Data`, `Mb.phone`, `Email`, `Pol`) VALUES ('" + (Convert.ToInt32(cid) + 1) + "', '" + metroTextBox2.Text + "', '" + metroTextBox1.Text + "', '" + metroTextBox3.Text + "', '" + metroDateTime1.Value.ToString("yyyy-MM-dd") + "', '" + metroTextBox4.Text + "', '" + metroTextBox5.Text + "', '" + metroComboBox1.Text + "');");
                    tabel();
                    clear();
                }
               // active(true);
                
            }

        }

        public void active(bool bol)
        {
            metroTextBox1.ReadOnly = bol;
            metroTextBox2.ReadOnly = bol;
            metroTextBox3.ReadOnly = bol;
            metroTextBox4.ReadOnly = bol;
            metroTextBox5.ReadOnly = bol;
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "" || metroTextBox2.Text == "" || metroTextBox3.Text == "" || metroTextBox4.Text == "" || metroTextBox5.Text == "" || metroComboBox1.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Ошибка", "Не все поля заполнины!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                Baza baza = new Baza();
                baza.SQLExute("UPDATE `krabs`.`klients` SET `Name`='" + metroTextBox2.Text + "', `Surname`='" + metroTextBox1.Text + "', `Lastname`='" + metroTextBox3.Text + "', `Data`='" + metroDateTime1.Value.ToString("yyyy-MM-dd") + "', `Mb.phone`='" + metroTextBox4.Text + "', `Email`='" + metroTextBox5.Text + "', `Pol`='" + metroComboBox1.Text + "'  WHERE `Id`=" + id + " ;");
                tabel();
                clear();
            }

        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "" || metroTextBox2.Text == "" || metroTextBox3.Text == "" || metroTextBox4.Text == "" || metroTextBox5.Text == "" || metroComboBox1.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Ошибка", "Не выбран обьект удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result= MetroFramework.MetroMessageBox.Show(this, "", "Вы точно хотите удалить эти данные", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Baza baza = new Baza();
                    baza.SQLExute("DELETE FROM `krabs`.`klients` WHERE `Id`=" + id + " ;");
                    tabel();
                    clear();
                }
            }

        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            tabel();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            
            metroGrid1.Rows.Clear();
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM klients WHERE CONCAT(`Id`, `Name`, `Surname`, `Lastname`, `Data`, `Mb.phone`, `Email`, `Pol`) LIKE '%" + metroTextBox6.Text+ "%'", conn);
            // объект для чтения ответа сервера
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                metroGrid1.Rows.Add(reader["Id"].ToString(), reader["Surname"].ToString(), reader["Name"].ToString(), reader["Lastname"].ToString(), reader["Data"].ToString(), reader["Pol"].ToString(), reader["Mb.phone"].ToString(), reader["Email"].ToString());
                
            }
            reader.Close();
            conn.Close();
        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            metroGrid2.Rows.Clear();
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM compani WHERE CONCAT(`Id`, `Name`, `Location`, `City`, `Predstav`, `Poct.ind`, `Country`, `Phone`, `Fax`, `Email`) LIKE '%" + metroTextBox14.Text + "%'", conn);
            // объект для чтения ответа сервера
            conn.Open();
            MySqlDataReader reader = command.ExecuteReader();
            // читаем результат
            while (reader.Read())
            {
                // элементы массива [] - это значения столбцов из запроса SELECT
                metroGrid2.Rows.Add(reader["Id"].ToString(), reader["Name"].ToString(), reader["Location"].ToString(), reader["City"].ToString(), reader["Predstav"].ToString(), reader["Poct.ind"].ToString(), reader["Country"].ToString(), reader["Phone"].ToString(), reader["Fax"].ToString(), reader["Email"].ToString());
                
            }
            reader.Close();
            conn.Close();

        }

        private void metroGrid2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                metroTextBox7.Text = metroGrid2.CurrentRow.Cells[1].Value.ToString();
                metroTextBox8.Text = metroGrid2.CurrentRow.Cells[2].Value.ToString();
                metroComboBox2.Text = metroGrid2.CurrentRow.Cells[3].Value.ToString();
                metroTextBox10.Text = metroGrid2.CurrentRow.Cells[6].Value.ToString();
                metroTextBox9.Text = metroGrid2.CurrentRow.Cells[4].Value.ToString();
                metroComboBox3.Text = metroGrid2.CurrentRow.Cells[5].Value.ToString();
                metroTextBox12.Text = metroGrid2.CurrentRow.Cells[7].Value.ToString();
                metroTextBox11.Text = metroGrid2.CurrentRow.Cells[8].Value.ToString();
                metroTextBox13.Text = metroGrid2.CurrentRow.Cells[9].Value.ToString();
                id1 = metroGrid2.CurrentRow.Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {

            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {

            ShowMyDialogBox("Добавление Города","Введите название города.","city","City", "Данный город уже есть!");
            comboCity();

        }

        public void ShowMyDialogBox(string titel,string messege,string tabel,string cell,string mess)
        {
            Input testDialog = new Input(titel,messege);
            testDialog.Owner = new Menu();
            testDialog.ShowDialog();
            Baza baza = new Baza();
            MySqlConnection conn = baza.GetConnection();

            // Show testDialog as a modal dialog and determine if DialogResult = OK.
            if (testDialog.DialogResult == DialogResult.OK)
            {
                // Read the contents of testDialog TextBox.
                this.input = testDialog.metroTextBox1.Text;
                conn.Open();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `krabs`.`"+tabel+"` WHERE "+cell+"='"+input+"'", conn);
                MySqlDataReader reader = command.ExecuteReader();
                // читаем результат
                while (reader.Read())
                {
                    name = reader[""+cell+""].ToString();

                }
                reader.Close();
                conn.Close();


                int cout=0;
                conn.Open();
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM `krabs`.`"+tabel+"`", conn);
                MySqlDataReader reader1 = command1.ExecuteReader();
                // читаем результат
                while (reader1.Read())
                {
                    cout++;

                }
                reader1.Close();
                conn.Close();

                if (input == name)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Ошибка", mess, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                   baza.SQLExute("INSERT INTO "+tabel+"(Id,"+cell+") VALUES("+(cout+1)+",'"+input+"')");
                    //metroComboBox2.Items.Clear();
                    
                }

            }
            else
            {
                
            }
            testDialog.Dispose();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            ShowMyDialogBox("Добавление Страны", "Введите название Страны.","countri","Countri","Данная страна уже есть!");
            comboCountry();
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            if (metroTextBox7.Text == "" ||  metroTextBox8.Text == "" || metroTextBox9.Text == "" || metroTextBox10.Text == "" || metroTextBox11.Text == "" || metroComboBox2.Text == "" || metroComboBox3.Text == "" || metroTextBox12.Text == "" || metroTextBox13.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Ошибка", "Не все поля заполнины!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                Baza baza = new Baza();
                MySqlConnection conn = baza.GetConnection();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `krabs`.`compani` WHERE `Name`='" + metroTextBox7.Text + "'", conn);
                // объект для чтения ответа сервера
                conn.Open();
                MySqlDataReader reader = command.ExecuteReader();
                // читаем результат
                while (reader.Read())
                {
                    name = reader["Name"].ToString();

                }
                // MessageBox.Show(name);
                reader.Close();
                conn.Close();
                if (metroTextBox7.Text == name)
                {
                    MetroFramework.MetroMessageBox.Show(this, "Ошибка", "Данная компания уже занесёна в базу!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    clear();
                }
                else
                {


                    baza.SQLExute("INSERT INTO `krabs`.`compani` (`Id`, `Name`, `Location`, `City`, `Poct.ind`, `Country`, `Predstav`, `Phone`, `Fax`, `Email`) VALUES ('" + (Convert.ToInt32(cid1) + 1) + "', '" + metroTextBox7.Text + "', '" + metroTextBox8.Text + "', '" + metroComboBox2.Text + "',  '" + metroTextBox9.Text + "', '" + metroComboBox3.Text + "', '" + metroTextBox10.Text + "', '" + metroTextBox12.Text + "', '" + metroTextBox11.Text + "', '" + metroTextBox13.Text + "');");
                    tabel1();
                    clear1();
                }
            }
        }

        private void clear1()
        {
            metroTextBox7.Clear();
            metroTextBox8.Clear();
            metroTextBox9.Clear();
            metroTextBox10.Clear();
            metroTextBox11.Clear();
            metroTextBox12.Clear();
            metroTextBox13.Clear();
            metroComboBox2.SelectedIndex = -1;
            metroComboBox3.SelectedIndex = -1;

        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            clear1();
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            if (metroTextBox7.Text == "" || metroTextBox8.Text == "" || metroTextBox9.Text == "" || metroTextBox10.Text == "" && metroTextBox11.Text == "" || metroComboBox2.Text == "" || metroComboBox3.Text == "" || metroTextBox12.Text == "" || metroTextBox13.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Ошибка", "Не все поля заполнины!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                Baza baza = new Baza();




                baza.SQLExute("UPDATE `krabs`.`compani` SET `Name`='" + metroTextBox7.Text + "', `Location`='" + metroTextBox8.Text + "', `City`='" + metroComboBox2.Text + "', `Poct.ind`='" + metroTextBox9.Text + "', `Country`='" + metroComboBox3.Text + "', `Predstav`='" + metroTextBox10.Text + "', `Phone`='" + metroTextBox12.Text + "' , `Fax`='" + metroTextBox11.Text + "', `Email`='" + metroTextBox13.Text + "' WHERE `Id`=" + id1 + " ;");
                tabel1();
                clear1();

            }
        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            if (metroTextBox7.Text == "" || metroTextBox8.Text == "" || metroTextBox9.Text == "" || metroTextBox10.Text == "" || metroTextBox11.Text == "" || metroComboBox2.Text == "" && metroComboBox3.Text == "" || metroTextBox12.Text == "" || metroTextBox13.Text == "")
            {
                MetroFramework.MetroMessageBox.Show(this, "Ошибка", "Не выбран обьект удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult result = MetroFramework.MetroMessageBox.Show(this, "", "Вы точно хотите удалить эти данные", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.Yes)
                {
                    Baza baza = new Baza();
                    baza.SQLExute("DELETE FROM `krabs`.`compani` WHERE `Id`=" + id1 + " ;");
                    tabel1();
                    clear1();
                }
            }
        }
    }
    
}
