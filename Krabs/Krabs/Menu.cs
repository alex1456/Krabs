using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Krabs
{
    public partial class Menu : MetroFramework.Forms.MetroForm
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        public void klient()
        {
            this.Text = "";
            this.Text = "Клиенты";
            metroPanel2.Controls.Clear();
            var myControl = new Krabs.Klient();
            myControl.Dock= DockStyle.Fill;
            metroPanel2.Controls.Add(myControl);
            


        }
        public void Price()
        {
            this.Text = "";
            this.Text = "Прайс-лист";
            metroPanel2.Controls.Clear();
            var Control = new Krabs.Price();
            Control.Dock = DockStyle.Fill;
            metroPanel2.Controls.Add(Control);
            
        }

        public void Zacaz()
        {
            this.Text = "";
            this.Text = "Заказы";
            metroPanel2.Controls.Clear();
            var Control = new Krabs.Zacaz();
            Control.Dock = DockStyle.Fill;
            metroPanel2.Controls.Add(Control);
            
        }

        public void Report()
        {
            report report = new report();
            
            this.Text = "";
            this.Text = "Отчёты";
            //report.reportViewer1.ProcessingMode = ProcessingMode.Local;
            //report.reportViewer1.LocalReport.ReportPath = "Zacaz_u.rdlc";
            // report.reportViewer1.RefreshReport();
             metroPanel2.Controls.Clear();
            
            var Control = new Krabs.report();

            Control.Dock = DockStyle.Fill;
            metroPanel2.Controls.Add(Control);
            report.reportViewer1.RefreshReport();
        }

        public void ras_pred()
        {
            

            this.Text = "";
            this.Text = "Распределение заказов";
            //report.reportViewer1.ProcessingMode = ProcessingMode.Local;
            //report.reportViewer1.LocalReport.ReportPath = "Zacaz_u.rdlc";
            // report.reportViewer1.RefreshReport();
            metroPanel2.Controls.Clear();

            var Control = new Krabs.Raspred();

            Control.Dock = DockStyle.Fill;
            metroPanel2.Controls.Add(Control);
            
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            klient();
        }

        private void metroTile2_Click(object sender, EventArgs e)
        {
            Price();
        }

        private void metroTile3_Click(object sender, EventArgs e)
        {
            Zacaz();
        }

        private void metroTile4_Click(object sender, EventArgs e)
        {
           
            Report();
        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            ras_pred();
        }
    }
}
