using BUS;
using DAL.Model;
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

namespace QuanLySach
{
    public partial class FormReportQLSach : Form
    {
        public FormReportQLSach()
        {
            InitializeComponent();
        }

        private void FormReportQLSach_Load(object sender, EventArgs e)
        {
            //List<Sach> listSach = SachService.sortByYear()

            reportViewer1.LocalReport.ReportPath = "ReportQLSach.rdlc";
            var source = new ReportDataSource("DataSetSach", SachService.sortByYear());
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(source);

            this.reportViewer1.RefreshReport();

            
        }
    }
}
