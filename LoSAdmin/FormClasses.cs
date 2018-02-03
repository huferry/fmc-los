using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Core;
using Los.Core;

namespace LoSAdmin
{    
    public partial class FormClasses : Form
    {
        List<Course> all_courses = Repository.GetAll<Course>().ToList();

        Course displayed_course = null;

		private Thread textboxChangeThread;

        public FormClasses()
        {
            FormWaiting.ShowMessage("Getting class information");
            try
            {
                InitializeComponent();

                comboBoxLevel.Items.Add("-- all --");
                comboBoxLevel.Items.AddRange(Level.All.ToArray());
                comboBoxLevel.SelectedIndex = 0;

                UpdateCourseTreeByYear(all_courses);

				textboxChangeThread = new Thread(new ThreadStart(TextboxChangeThreadHandler));
				textboxChangeThread.Start();

				this.FormClosing += (object sender, FormClosingEventArgs e) => textboxChangeThread.Abort();

            }
            finally
            {
                FormWaiting.Finished();
            }
		
        }

		private void TextboxChangeThreadHandler()
		{
			DateTime keybTime = DateTime.Now;
			bool changed = false;

			textBoxContainStudent.TextChanged += (object sender, EventArgs e) => 
			{
				keybTime = DateTime.Now;
				changed = true;
			};

			while (true) 
			{
				Thread.Sleep (600);
				if (changed && (DateTime.Now.Subtract (keybTime).TotalMilliseconds > 600))
				{
					changed = false;
					UpdateCourseTreeByYear (all_courses);
				}
			}
		}
		
        private IEnumerable<Course> GuiFilter(IEnumerable<Course> courses)
        {

            CompoundCourseFilter filter = new CompoundCourseFilter();
            
            filter.AddFilter(new CourseLevelFilter(comboBoxLevel.SelectedItem));


            ActiveStatus a_s = radioButtonClosed.Checked ? ActiveStatus.Closed : 
                (radioButtonRunning.Checked ? ActiveStatus.Active : ActiveStatus.All);
            filter.AddFilter(new CourseActiveFilter(a_s));

            filter.AddFilter(new CourseStudentFilter(textBoxContainStudent.Text));

            return courses.Where(x => filter.Choose(x));
        }

        private void UpdateCourseTreeByYear(IEnumerable<Course> courses)
        {
            var sel_courses = GuiFilter(courses);

            treeViewCourses.BeginUpdate();
            try
            {
                treeViewCourses.Nodes.Clear();
                var root = treeViewCourses.Nodes.Add("Year");
                root.SelectedImageIndex = 2;
                root.ImageIndex = 2;

                var years = sel_courses.Select(x => x.DateStart.Year).Distinct().OrderBy(x => -x);
                int progress = 1;
                foreach (int year in years)
                {
                    FormWaiting.SetProgress(progress++ * 100 / years.Count());
                    var year_node = root.Nodes.Add("year", year.ToString());
                    year_node.ImageIndex = 3;
                    year_node.SelectedImageIndex = 3;
                    year_node.Tag = year;

                    var levels = sel_courses.Select(x => x.Level).Distinct().OrderBy(x => x);

                    foreach (Level l in levels)
                    {
                        var level_node = year_node.Nodes.Add("level_year", l.ToString());
                        level_node.ImageIndex = 0;
                        level_node.SelectedImageIndex = 0;
                        level_node.Tag = l;

                        var in_courses = sel_courses.Where(x => (x.Level == l) && (x.DateStart.Year == year));

                        foreach (Course c in in_courses)
                        {
                            var course_node = level_node.Nodes.Add("course", c.Name);
                            course_node.Tag = c;
                            course_node.SelectedImageIndex = 1;
                            course_node.ImageIndex = 1;
                        }

                        if (level_node.Nodes.Count == 0)
                        {
                            level_node.Remove();
                        }
                        else
                        {
                            level_node.Expand();
                        }
                    }
                    if (year == DateTime.Today.Year)
                        year_node.Expand();
                }
                root.ExpandAll();
            }
            finally
            {
                treeViewCourses.EndUpdate();
            }
        }

        private void treeViewCourses_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Tag is Course)
            {
                Course course = e.Node.Tag as Course;
                displayed_course = course;
                listViewStudents.BeginUpdate();
                try
                {
                    listViewStudents.Items.Clear();
                    var students = course.GetStudents().OrderBy(x => x.ToString());
                    int i = 1;
                    foreach (Relation rel in students)
                    {
                        var status = course.GetStudentStatus(rel);
                        var item = listViewStudents.Items.Add((i++).ToString());
                        item.Tag = rel;
                        item.SubItems.Add(rel.ToString());
                        item.SubItems.Add(status.IsFinished ? "Finished" : "");
                        item.SubItems.Add(status.System.HasValue
                            ? $"System {status.System}" 
                            : string.Empty);
                    }
                    textBoxEnrollments.Text = students.Count().ToString();
                    checkBoxOpenEnrollment.Checked = course.OpenEnrollment;
                }
                finally
                {
                    listViewStudents.EndUpdate();
                }
                labelCourseName.Text = course.Name;
                textBoxDescription.Text = course.Description;
                textBoxLevel.Text = course.Level.ToString();
                buttonUpdateDesc.Enabled = false;
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (treeViewCourses.SelectedNode != null) 
            {
                //LoSAdmin.Reports.FormReportClassAttendance rep = 
                //    new LoSAdmin.Reports.FormReportClassAttendance(GetUnderlyingCourses());
				MessageBox.Show ("test");
				/*
                rep.ShowDialog();
                */
            } 
        }

        private IEnumerable<Course> GetUnderlyingCourses()
        {
            if (treeViewCourses.SelectedNode != null)
            {
                List<Course> list = new List<Course>();
                GetUnderlyingCourses(treeViewCourses.SelectedNode, list);
                return list;
            }
            return null;
        }

        private void GetUnderlyingCourses(TreeNode node, List<Course> list)
        {
            if (node.Tag is Course)
                list.Add(node.Tag as Course);
            foreach (TreeNode child in node.Nodes)
                GetUnderlyingCourses(child, list);
        }

        private void buttonNewSeason_Click(object sender, EventArgs e)
        {
            var f = new FormNewSeason();
            f.ShowDialog();
        }

        private void buttonNewClass_Click(object sender, EventArgs e)
        {
            var new_course = FormNewCourse.CreateNew();
            if (new_course != null)
            {
                all_courses.Add(new_course);
                UpdateCourseTreeByYear(all_courses);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
			/*
            LoSAdmin.Reports.FormReportEnrolInvitation rep =
                new LoSAdmin.Reports.FormReportEnrolInvitation();
            rep.ShowDialog();
            */
        }

        private void markFinishedCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (displayed_course != null)
            {
                foreach (ListViewItem item in listViewStudents.SelectedItems)
                {
                    Relation rel = (Relation)item.Tag;
                    StudentCourseStatus.SetFinished(displayed_course, rel, true);
                    item.SubItems[2].Text = "Finished";
                }
            }
        }

        private void listViewStudents_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Right) && (displayed_course != null))
            {
                var item = listViewStudents.GetItemAt(e.X, e.Y);
                Relation student = item != null ? (Relation)item.Tag : null;

                if (student != null)
                {
                    var finished = displayed_course.GetStudentStatus(student).IsFinished; 
                    markFinishedCourseToolStripMenuItem.Visible = !finished;
                    unmarkFinishedCourseToolStripMenuItem.Visible = finished;
                    removeStudentToolStripMenuItem.Visible = displayed_course.CanRemoveStudent(student);
                }
                else
                {
                    markFinishedCourseToolStripMenuItem.Visible = true;
                    unmarkFinishedCourseToolStripMenuItem.Visible = true;
                    removeStudentToolStripMenuItem.Visible = false;
                }
            }
        }

        private void unmarkFinishedCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (displayed_course != null)
            {
                foreach (ListViewItem item in listViewStudents.SelectedItems)
                {
                    Relation rel = (Relation)item.Tag;
                    StudentCourseStatus.SetFinished(displayed_course, rel, false);
                    item.SubItems[2].Text = "";
                }
            }
        }

        private void comboBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateCourseTreeByYear(all_courses);
        }

        private void radioButtonClosed_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCourseTreeByYear(all_courses);
        }

        private void buttonDeleteCourse_Click(object sender, EventArgs e)
        {
            var courses = GetUnderlyingCourses();

            var cannot_delete = courses.Where(x => !x.CanDelete());

            if (cannot_delete.Count() > 0)
            {
                string failed = "";
                foreach (Course c in cannot_delete)
                    failed += "  - " + c.Name + "\r\n";

                MessageBox.Show(
                    "Cannot delete the following course(s). The course(s) might not be empty:\r\n" + failed, 
                    "Deletion failed", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);

                return;
            }

            string coursenames = "";
            foreach (Course c in courses)
                coursenames += "  - " + c.Name + "\r\n";

            if (MessageBox.Show(
                  "You are about to delete the following course(s): \r\n" + coursenames + 
                  "\r\nAre your sure?",
                  "Deleting course(s)",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (Course c in courses)
                {
                    all_courses.Remove(c);
                    Repository.Delete(c);
                }
                UpdateCourseTreeByYear(all_courses);
            }
        }

        private void removeStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (displayed_course != null)
            {
                listViewStudents.BeginUpdate();
                try
                {
                    var student_items = listViewStudents.SelectedItems.Cast<ListViewItem>().ToArray();
                    foreach (ListViewItem item in student_items)
                    {
                        Relation rel = (Relation)item.Tag;
                        displayed_course.RemoveStudent(rel);
                        listViewStudents.Items.Remove(item);
                    }
                }
                finally
                {
                    listViewStudents.EndUpdate();
                }
            }
        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (displayed_course != null)
            {
                foreach (ListViewItem item in listViewStudents.SelectedItems)
                {
                    Relation rel = (Relation)item.Tag;
                    displayed_course.GetStudentStatus(rel).System = null;
                    item.SubItems[3].Text = "";
                }                
            }
        }

        private void system2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (displayed_course != null)
            {
                foreach (ListViewItem item in listViewStudents.SelectedItems)
                {
                    Relation rel = (Relation)item.Tag;
                    displayed_course.GetStudentStatus(rel).System = 2;
                    item.SubItems[3].Text = "System 2";
                }
            }
        }

        private void textBoxDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            buttonUpdateDesc.Enabled = true;
        }

        private void buttonUpdateDesc_Click(object sender, EventArgs e)
        {
            displayed_course.Description = textBoxDescription.Text;
            Repository.Save(displayed_course);
        }
    }

    abstract class CourseFilter
    {
        abstract public bool Choose(Course course);
    }

    class CompoundCourseFilter : CourseFilter
    {
        private List<CourseFilter> filters = new List<CourseFilter>();

        public CompoundCourseFilter()
        {
        }

        public CompoundCourseFilter(CourseFilter[] filters)
        {
            this.filters.AddRange(filters);
        }

        public void AddFilter(CourseFilter filter)
        {
            filters.Add(filter);
        }

        public override bool Choose(Course course)
        {
            foreach (CourseFilter filter in filters)
            {
                if (!filter.Choose(course))
                    return false;
            }
            return true;
        }
    }

    class CourseLevelFilter : CourseFilter
    {
        private List<Level> levels = new List<Level>();

        public CourseLevelFilter(Level[] levels)
        {
            this.levels.AddRange(levels);
        }

        public CourseLevelFilter(object level)
        {
            if (level is Level)
                levels.Add((Level)level);
        }

        public override bool Choose(Course course)
        {
            if (levels.Count == 0)
                return true;

            foreach (Level l in levels)
            {
                if (course.Level == l)
                    return true;
            }
            return false;
        }
    }


    enum ActiveStatus
    { 
        Closed = 0,
        Active = 1,
        All = 2
    }


    class CourseActiveFilter : CourseFilter
    {
        private ActiveStatus status;

        public CourseActiveFilter(ActiveStatus status)
        {
            this.status = status;
        }

        public override bool Choose(Course course)
        {
            switch (status)
            {
                case ActiveStatus.All:
                    return true;
                case ActiveStatus.Active:
                    return course.IsActive;
                case ActiveStatus.Closed:
                    return !course.IsActive;
                default:
                    throw new Exception("Cannot determine the activestatus");
            }
        }
    }

    class CourseStudentFilter : CourseFilter
    {
        private string name;

        public CourseStudentFilter(string name)
        {
            this.name = name;
        }

        public override bool Choose(Course course)
        {
            if (name.Length == 0)
                return true;

            foreach (Relation rel in course.GetStudents())
            {
                if (rel.CalcSearchScore(name) > 0.6)
                    return true;
            }

            return false;             
        }
    }

}
