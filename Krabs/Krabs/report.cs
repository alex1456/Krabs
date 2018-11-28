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
using Microsoft.Reporting.WinForms;

namespace Krabs
{
    public partial class report : MetroUserControl
    {
        public report()
        {
            InitializeComponent();
            //reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportEmbeddedResource = "Krabs.Zacaz_u.rdlc";
            reportViewer1.RefreshReport();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            reff();
        }
        public void reff()
        {
            reportViewer1.RefreshReport();
        }
    }
}
