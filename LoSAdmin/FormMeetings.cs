using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Los.Core;
using System.Diagnostics;
using System.IO;


namespace LoSAdmin
{
	public partial class FormMeetings : Form
	{
		private List<Course> courses = new List<Course>();

		public FormMeetings()
		{
			InitializeComponent();
			FormWaiting.ShowMessage("Getting data");
			try
			{                
				courses.AddRange(Course.GetActiveCourses().OrderBy(x => x.Level).ToArray());
				UpdateTree(courses);
				UpdateBlockings();
			}
			finally
			{
				FormWaiting.Finished();
			}
            
		}

		private void buttonBlockings_Click(object sender, EventArgs e)
		{
			var form = new FormBlockings();
			form.ShowDialog();
		}

		private void UpdateBlockings()
		{
			var blockings = Calendar.GetByDates(DateTime.Today.AddDays(-200), DateTime.Today.AddDays(500)).ToList();
			listViewBlockings.BeginUpdate();
			try
			{
				listViewBlockings.Items.Clear();
				foreach (Calendar b in blockings.Where(x => x.Blocking))
				{
					var item = listViewBlockings.Items.Add(b.Name);
					item.SubItems.Add(b.DateStart.ToLongDateString());
					item.SubItems.Add(b.DateEnd.ToLongDateString());
				}
			}
			finally
			{
				listViewBlockings.EndUpdate();
			}

		}

		private void UpdateTree(IEnumerable<Course> coursesToDisplay)
		{
			object selected = GetSelectedObject();
			treeView1.BeginUpdate();
			try
			{
				var local_courses = coursesToDisplay.ToList();
				treeView1.Nodes.Clear();
				foreach (Course course in local_courses)
				{
					// adding courses
					var course_node = treeView1.Nodes.Add(course.Name);
					course_node.Tag = course;
					UpdateNode(course_node);

					// adding lessons
					var lessons = course.Level.Lessons.ToList();
					foreach (Lesson les in lessons)
					{
						var lesson_node = course_node.Nodes.Add(les.GetCompleteName());
						lesson_node.Tag = les;
						UpdateNode(lesson_node);
					}
					FormWaiting.SetProgress(local_courses.IndexOf(course) * 100 / local_courses.Count);
				}
				SetSelectedByObject(selected);
			}
			finally
			{
				treeView1.EndUpdate();
			}
		}

		private void UpdateNode(TreeNode node)
		{
			object tag = node.Tag;
			if (tag != null)
			{
				if (tag is Course)
				{
					var completed = (tag as Course).IsMeetingComplete();
					node.ImageIndex = completed ? 3 : 2;
					node.SelectedImageIndex = completed ? 3 : 2;                    
				}

				if (tag is Lesson)
				{
					Course c = (Course)node.Parent.Tag;
					var planned = c.GetMeetingByLesson(tag as Lesson) != null;
					node.ImageIndex = planned ? 1 : 0;
					node.SelectedImageIndex = planned ? 1 : 0;
				}
			}
		}

		private object GetSelectedObject()
		{
			return treeView1.SelectedNode != null ? treeView1.SelectedNode.Tag : null;
		}

		private void SetSelectedByObject(object tag, TreeNodeCollection nodes)
		{
			foreach (TreeNode node in nodes)
			{
				if (node.Tag == tag)
				{
					treeView1.SelectedNode = node;
					return;
				}
				SetSelectedByObject(tag, node.Nodes);
			}
		}

		private void SetSelectedByObject(object tag)
		{
			if (tag != null)
			{
				SetSelectedByObject(tag, treeView1.Nodes);
			}
		}

		private Course GetSelectedCourse()
		{
			var node = GetSelectedCourseNode();
			return node != null ? (Course)node.Tag : null;
		}

		private TreeNode GetSelectedCourseNode()
		{
			object selected = treeView1.SelectedNode != null ? treeView1.SelectedNode.Tag : null;
			if ((selected is Lesson) && (treeView1.SelectedNode.Parent != null))
			{
				if (treeView1.SelectedNode.Parent.Tag is Course)
					return treeView1.SelectedNode.Parent;
			}

			return selected is Course ? treeView1.SelectedNode : null;
		}

		private void buttonPlanner_Click(object sender, EventArgs e)
		{
			Course c = GetSelectedCourse();
			if (c != null)
			{
				if (FormMeetingPlanner.Execute(c))
				{
					var c_node = GetSelectedCourseNode();
					UpdateNode(c_node);
					foreach (TreeNode les in c_node.Nodes)
						UpdateNode(les);
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Course c = GetSelectedCourse();
			if (c != null)
			{
				FormMeetingAttendance.Execute(c);
			}
		}

		private void buttonReport_Click(object sender, EventArgs e)
		{
			
			//LoSAdmin.dto.Course course = LoSAdmin.dto.Course.Import (courses.First ());
			var report = ReadReportTemplate();
			var data = LoSAdmin.dto.Course.ExportToJson(courses.ToArray());

			report = report.Replace("%data%", data);

			var filename = string.Format("report{0}.html", DateTime.Now.ToString("yyyyMMddHHmm"));
			var file = new FileStream(filename, FileMode.Create);
			var writer = new StreamWriter(file);
			writer.WriteLine(report);
			writer.Flush();
			file.Flush();
			file.Close();

			var si = new ProcessStartInfo
			{ 
				FileName = filename
			};
			Process.Start(si);
			//var form = new FormReportMeetingAttendance(courses);
			//form.ShowDialog();
		}

		private string ReadReportTemplate()
		{
			var file = new FileStream("report_template", FileMode.Open);
			var reader = new StreamReader(file);

			var template = reader.ReadToEnd();

			file.Close();

			return template;
		}

		private void buttonAbsent_Click(object sender, EventArgs e)
		{
			FormAbsentDialog.ExecuteEnterAbsence();
		}

	}
}
