using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Los.Core;

namespace LoSAdmin.Reports
{
    public partial class FormReportEnrolInvitation : Form
    {
        private BindingSource BindingSource;
        private IContainer components;
       // private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    
        public FormReportEnrolInvitation()
        {
            InitializeComponent();

            var students = Relation.GetAll()
                            .Select(x => new { Student = x, NextCourses = Course.GetNextPossibleCoursesByRelation(x) })
                            .Where(s => s.NextCourses.Count() > 0)
                            .OrderBy(s => s.NextCourses.First().Level)
                            .Select(s => new StudentEnrolInvitation(s.Student));

            BindingSource.DataSource = students;

            /*
            string mimeType;
            string encoding;
            string ext;
            string[] streams;
            Warning[] warnings;

            FileStream file = new FileStream("C:\\temp\\registration.pdf", FileMode.Create);
            byte[] content = this.reportViewer1.LocalReport.Render("Image", null, out mimeType, out encoding, out ext, out streams, out warnings);
            file.Write(content, 0, content.Count());
            file.Close();
             */

        }

        private void FormReportEnrolInvitation_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "StudentEnrolInvitation";
            reportDataSource1.Value = this.BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LoSAdmin.ReportStudentInvitation.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(800, 678);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load_1);
            // 
            // BindingSource
            // 
            this.BindingSource.DataSource = typeof(LoSAdmin.Reports.StudentEnrolInvitation);
            this.BindingSource.Sort = "CourseName";
            // 
            // FormReportEnrolInvitation
            // 
            this.ClientSize = new System.Drawing.Size(800, 678);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormReportEnrolInvitation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormReportEnrolInvitation_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        private void FormReportEnrolInvitation_Load_1(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
