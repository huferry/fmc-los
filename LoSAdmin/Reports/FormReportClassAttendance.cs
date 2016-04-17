using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//using Microsoft.Reporting.WinForms;
using Los.Core;

namespace LoSAdmin.Reports
{
    public partial class FormReportClassAttendance : Form
    {
        public FormReportClassAttendance(IEnumerable<Course> courses)
        {
            InitializeComponent();
            BindingSource.DataSource = (new ClassAttendance(courses)).GetStudents();            
        }

        private void FormReportClassAttendance_Load(object sender, EventArgs e)
        {
            /*
            this.reportViewer1.RefreshReport();
            
            this.reportViewer1.LocalReport.SetParameters(
                new ReportParameter[]
                    {
                        new ReportParameter("ClassDate", DateTime.Today.ToShortDateString())
                    }
                );
                */
        }


        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {
            
        }

        private void reportViewer1_Load_2(object sender, EventArgs e)
        {

        }

        private void BindingSource_CurrentChanged_1(object sender, EventArgs e)
        {

        }
    }
}
