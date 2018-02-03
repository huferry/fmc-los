using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Core;
using Los.Core;

namespace LoSAdmin
{
    public partial class FormEnrolClass : Form
    {
        private Relation student;

        private FormEnrolClass()
        {
            InitializeComponent();
        }

        static public bool Execute(Relation rel)
        {
            // check possible classes
            var last = Course.GetLastClosedCourseByRelation(rel);

            var form = new FormEnrolClass();
            form.student = rel;
            form.textBoxName.Text = rel.ToString();
            form.textBoxLastClass.Text = last == null ? "" : last.Name;
            form.checkBoxFinished.Checked = (last != null) && last.GetStudentStatus(rel).IsFinished;
            form.checkBoxAll_Click(null, null);
            return form.ShowDialog() == DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Course course = (Course)comboBoxClasses.SelectedItem;
            course.EnrolStudent(student);
        }

        private void comboBoxClasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = comboBoxClasses.SelectedIndex != -1;
        }

        private void checkBoxAll_Click(object sender, EventArgs e)
        {
            comboBoxClasses.BeginUpdate();
            try
            {
                comboBoxClasses.Items.Clear();
                bool active = checkBoxActiveOnly.Checked;
                if (checkBoxAll.Checked)
                {
                    var courses = active ?
                        Course.GetActiveCourses().ToArray() :
                        Repository.GetAll<Course>();
                    comboBoxClasses.Items.AddRange(courses);
                }
                else
                {
                    comboBoxClasses.Items.AddRange(Course.GetNextPossibleCoursesByRelation(student).ToArray());
                }
                button1.Enabled = false;
            }
            finally
            {
                comboBoxClasses.EndUpdate();
            }
        }
    }
}
