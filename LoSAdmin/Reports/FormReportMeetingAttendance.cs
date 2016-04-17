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
    public partial class FormReportMeetingAttendance : Form
    {
        public FormReportMeetingAttendance(Course course)
        {
            InitializeComponent();
            BindingSource.DataSource = CourseStudentMeetingAttendance.GetByCourse(course);            
        }

        public FormReportMeetingAttendance(IEnumerable<Course> courses)
        {
            InitializeComponent();
            BindingSource.DataSource = CourseStudentMeetingAttendance.GetByCourses(courses);
        }

        private void FormReportMeetingAttendance_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
