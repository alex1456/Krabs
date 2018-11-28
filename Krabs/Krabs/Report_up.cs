using Microsoft.Reporting.WinForms;
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
    public partial class Report_up : MetroFramework.Forms.MetroForm
    {
        Zacaz zacaz = new Zacaz();
        public Report_up(string N,string data1,string data2,string data3, string itog, string surname,string name, string lastname,string phone,string email,string usluga,string scidca)
        {
            InitializeComponent();
            reportViewer1.Reset();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Krabs.Zacaz_u.rdlc";
            // reportViewer1.LocalReport.ReportPath = @"C:\Users\lehaf\Desktop\Krab's\Krabs\Krabs\bin\Debug\Zacaz_u.rdlc";
            // reportViewer1.LocalReport.SetParameters(new ReportParameter("N", "1"));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("N", N));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("data_oform", data1));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("data_sdachi", data2));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("data_oplati", data3));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("scidca", scidca));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("itog", itog));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("surname", surname));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("name", name));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("lastname", lastname));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("phone", phone));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("email", email));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("usluga", usluga));
            reportViewer1.RefreshReport();
        }

        private void Report_up_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }
    }
}
